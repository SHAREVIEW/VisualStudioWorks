using System;
using System.Collections.Generic;
using System.Text;

using InTheHand.Net;
using InTheHand.Net.Sockets;

using System.Threading;
using System.IO;
using System.Net.Sockets;

namespace BTChat
{
    class Mesajlasma
    {
        private BluetoothClient sunucu = null; // Sunucuya nesnesi.
        private Stream sunucuStream = null; // mesajlaþmak için gereken stream nesnesi.
        
        private BluetoothAddress sunucuAdresi = null;
        private Guid servisAdi; // servis uuid
        private String sunucuAdi = null;

        private AnaPencere anaPencere = null;

        private Thread baglantiKanali = null;

        private bool baglantiKuruldu = false;

        public bool BaglantiKuruldu
        {
            get { return baglantiKuruldu; }
            set { baglantiKuruldu = value; }
        }

        public Mesajlasma(BluetoothAddress adres, AnaPencere pencere, String ad)
        {
            this.sunucuAdresi = adres;
            this.anaPencere = pencere;
            this.sunucuAdi = ad;

            servisAdi = new Guid(Sabitler.SERVIS_GUID); // Sunucu servisi.

            try
            {
                baglantiKanali = new Thread(new ThreadStart(Baglan));
                baglantiKanali.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Baglan()
        {
            int deneme = 0;
            sunucu = null;

            // Uzak makina ile baðlantý kurmaya çalýþýyoruz...
            do
            {
                try
                {
                    sunucu = new BluetoothClient();
                    sunucu.Connect(new BluetoothEndPoint(sunucuAdresi, servisAdi));
                }
                catch (SocketException ex)
                {
                    if (deneme >= Sabitler.MAX_DENEME_SAYISI)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                deneme += 1;
            } while (sunucu == null && deneme < Sabitler.MAX_DENEME_SAYISI);

            if (sunucu.Connected == false)
            {
                HataGoster();
                return;
            }

            if (sunucuStream == null)
            {
                try
                {
                    sunucuStream = sunucu.GetStream();
                }
                catch (Exception)
                {
                    HataGoster();
                    return;
                }
            }
            anaPencere.ArastirmaBilgisi(sunucuAdi + " aygýtý ile baðlantý kuruldu.");
            anaPencere.MesajBilgisi(sunucuAdi + " aygýtý ile baðlantý kuruldu.");
            anaPencere.BaglanButonu();
            baglantiKuruldu = true; // Sunucu ile baðlantý kuruldu...
        }

        /// <summary>
        /// Görsel arayüzde hata bilgisini gösterir.
        /// </summary>
        private void HataGoster()
        {
            anaPencere.ArastirmaBilgisi(sunucuAdi + " aygýtý ile baðlantý kurulamadý.");
            anaPencere.MesajBilgisi(sunucuAdi + " aygýtý ile baðlantý kurulamadý.");
            anaPencere.BaglanButonu();
        }

        /// <summary>
        /// Baðlantý kurulmuþ sunucuya mesaj gönderir.
        /// </summary>
        /// <param name="mesaj">Gönderilecek mesaj katarý</param>
        /// <returns>Mesaj gönderme iþleminin sonucu</returns>
        public bool MesajGonder(String mesaj)
        {
            byte[] mesajDizisi = Encoding.Default.GetBytes(mesaj);

            if (sunucu.Connected == false)
            {
                anaPencere.MesajBilgisi(sunucuAdi + " ile baðlantý kurulamadý.");
                return false;
            }

            try
            {
                sunucuStream.WriteByte(Convert.ToByte(mesajDizisi.Length));
                sunucuStream.Flush();

                sunucuStream.Write(mesajDizisi, 0, mesajDizisi.Length);
                sunucuStream.Flush();
                sunucuStream.ReadByte();

                anaPencere.MesajBilgisi(sunucuAdi + " aygýtýna mesajýnýz gönderildi.");
            }
            catch (Exception)
            {
                anaPencere.MesajBilgisi(sunucuAdi + " aygýtýna mesajýnýz gönderilirken hata oluþtu.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sunucu ile baðlantýyý keser.
        /// </summary>
        public void Kapat() 
        {
            try
            {
                MesajGonder("bye$?"); // sunucu ile baðlantýyý koparmak için gereken mesajý gönder
                
                if(sunucu!=null) {
                    if (sunucuStream != null)
                    {
                        sunucuStream.Close(); // I/O nesnelerini kapat
                    }
                    sunucu.Close(); // sunucu ile baðlantýyý kes
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
