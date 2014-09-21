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

        private Thread dinlemeKanali; // Ýstemcilerin dinlendiði iþ hattý.

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
                    anaPencere.SunucuUyariGoster("Servis oluþturuldu. Ýstemciler dinleniyor...");
                    sunucuCalisiyor = true;
                }
                else
                {
                    anaPencere.SunucuUyariGoster("Servis oluþturulamadý! Bluetooth aygýtýnýn takýlý olup olmadýðýný denetleyin.");
                    return;
                }
            }

            while (sunucuCalisiyor)
            {
                BluetoothClient istemci = null;

                try 
	            {	        
                    // Ýstemci baðlantýlarý için bekliyoruz.
		            istemci = istemciDinleyici.AcceptBluetoothClient();
                    // istemci ile baðlantý kuruldu!
	            }
	            catch (Exception)
	            {
            		continue;
	            }

                // Ýstemci için yeni bir iþ hattý oluþtur ve iþhattýný koleksiyona ekle...
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
                Console.WriteLine("Hata: Gelen mesaj okunamýyor." + ex.ToString());
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
