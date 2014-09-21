using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using InTheHand.Net;
using InTheHand.Net.Sockets;

using System.IO;

namespace BTChat
{
    class Sunucu
    {
        private AnaPencere anaPencere = null;

        private BluetoothListener istemciDinleyici = null;
        private List<IstemciDinleyici> isParcalari = null;

        private Guid servisAdi; // servis uuid

        private bool sunucuCalisiyor = false;

        private Thread dinlemeKanali; // �stemcilerin dinlendi�i i� hatt�.

        public Sunucu(AnaPencere pencere)
        {
            anaPencere = pencere;
            servisAdi = new Guid(Sabitler.SERVIS_GUID);
            isParcalari = new List<IstemciDinleyici>();
            dinlemeKanali = new Thread(new ThreadStart(Kanal));
            dinlemeKanali.Start();
        }

        private void Kanal()
        {
            if (!sunucuCalisiyor)
            {
                if (ServisOlustur())
                {
                    anaPencere.SunucuUyariGoster("Servis olu�turuldu. �stemciler dinleniyor...");
                    sunucuCalisiyor = true;
                }
                else
                {
                    anaPencere.SunucuUyariGoster("Servis olu�turulamad�! Bluetooth ayg�t�n�n tak�l� olup olmad���n� denetleyin.");
                    return;
                }
            }

            while (sunucuCalisiyor)
            {
                BluetoothClient istemci = null;

                try 
	            {	        
                    // �stemci ba�lant�lar� i�in bekliyoruz.
		            istemci = istemciDinleyici.AcceptBluetoothClient();
                    // istemci ile ba�lant� kuruldu!
	            }
	            catch (Exception)
	            {
            		continue;
	            }

                // �stemci i�in yeni bir i� hatt� olu�tur ve i�hatt�n� koleksiyona ekle...
                IstemciDinleyici thread = new IstemciDinleyici(istemci, this.anaPencere);
                isParcalari.Add(thread);
            }
        }

        private bool ServisOlustur()
        {
            try
            {
                istemciDinleyici = new BluetoothListener(servisAdi);
                istemciDinleyici.Start();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Kapat()
        {
            if (sunucuCalisiyor)
                sunucuCalisiyor = false;

            try
            {
                istemciDinleyici.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: Gelen mesaj okunam�yor." + ex.ToString());
            }

            IstemciDinleyici thread = null;
            for (int i = 0; i < isParcalari.Count; i++)
            {
                thread = isParcalari[i];
                thread.Kapat();
            }
        }
    }
}
