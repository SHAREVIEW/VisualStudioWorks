using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using InTheHand.Net;
using InTheHand.Net.Sockets;

namespace BTChat
{
    class Arastirma
    {
        private BluetoothClient localAygit = null; // Local bluetooth ayg�t�na eri�im sa�lar.

        // Ayg�t ara�t�rma sonucu bulunan ayg�tlar� depolar.
        private BluetoothDeviceInfo[] Aygitlar = new BluetoothDeviceInfo[Sabitler.MAX_AYGIT_SAYISI];

        // Ayg�t ara�t�rma i�in i� par�as�
        private Thread aramaKanali;

        // Uygulama penceresine eri�im sa�lar.
        private AnaPencere anaPencere = null;

        public Arastirma(AnaPencere pencere)
        {
            anaPencere = pencere;
            localAygit = new BluetoothClient(); // Local bluetooth ayg�t�na eri�iyoruz.
            aramaKanali = new Thread(new ThreadStart(AygitArama)); // Ara�t�rma i�in i� par�as� olu�tur.
            aramaKanali.Start(); // �� par�as�n� ba�lat.
        }

        private void AygitArama()
        {
            try
            {
                // Ay�t ara�t�rma ba�lad�. Uygulama bloklan�r.
                Aygitlar = localAygit.DiscoverDevices(Sabitler.MAX_AYGIT_SAYISI); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                anaPencere.ArastirmaBilgisi("Arastirma s�ras�nda hata olu�tu. " + Aygitlar.Length + " ayg�t bulundu.");
                anaPencere.ArastirmaButonu(); // Ara�t�r butonunu aktifle�tir.
                return;
            }

            anaPencere.ArastirmaBilgisi("Arastirma tamamland�. " + Aygitlar.Length + " ayg�t bulundu.");

            for (int i = 0; i < Aygitlar.Length; i++)
            {
                anaPencere.AdresEkle(Aygitlar[i].DeviceAddress); // Adresleri koleksiyona ekle.
                anaPencere.SunucuEkle(Aygitlar[i].DeviceName); // �simleri koleksiyona ekle.
            }

            anaPencere.ArastirmaButonu(); // Ara�t�r butonunu aktifle�tir.
        }
    }
}
