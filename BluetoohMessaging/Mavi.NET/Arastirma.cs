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
        private BluetoothClient localAygit = null; // Local bluetooth aygýtýna eriþim saðlar.

        // Aygýt araþtýrma sonucu bulunan aygýtlarý depolar.
        private BluetoothDeviceInfo[] Aygitlar = new BluetoothDeviceInfo[Sabitler.MAX_AYGIT_SAYISI];

        // Aygýt araþtýrma için iþ parçasý
        private Thread aramaKanali;

        // Uygulama penceresine eriþim saðlar.
        private AnaPencere anaPencere = null;

        public Arastirma(AnaPencere pencere)
        {
            anaPencere = pencere;
            localAygit = new BluetoothClient(); // Local bluetooth aygýtýna eriþiyoruz.
            aramaKanali = new Thread(new ThreadStart(AygitArama)); // Araþtýrma için iþ parçasý oluþtur.
            aramaKanali.Start(); // Ýþ parçasýný baþlat.
        }

        private void AygitArama()
        {
            try
            {
                // Ayýt araþtýrma baþladý. Uygulama bloklanýr.
                Aygitlar = localAygit.DiscoverDevices(Sabitler.MAX_AYGIT_SAYISI); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                anaPencere.ArastirmaBilgisi("Arastirma sýrasýnda hata oluþtu. " + Aygitlar.Length + " aygýt bulundu.");
                anaPencere.ArastirmaButonu(); // Araþtýr butonunu aktifleþtir.
                return;
            }

            anaPencere.ArastirmaBilgisi("Arastirma tamamlandý. " + Aygitlar.Length + " aygýt bulundu.");

            for (int i = 0; i < Aygitlar.Length; i++)
            {
                anaPencere.AdresEkle(Aygitlar[i].DeviceAddress); // Adresleri koleksiyona ekle.
                anaPencere.SunucuEkle(Aygitlar[i].DeviceName); // Ýsimleri koleksiyona ekle.
            }

            anaPencere.ArastirmaButonu(); // Araþtýr butonunu aktifleþtir.
        }
    }
}
