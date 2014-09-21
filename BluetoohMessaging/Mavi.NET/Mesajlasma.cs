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
        private Stream sunucuStream = null; // mesajla�mak i�in gereken stream nesnesi.
        
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

            // Uzak makina ile ba�lant� kurmaya �al���yoruz...
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
            anaPencere.ArastirmaBilgisi(sunucuAdi + " ayg�t� ile ba�lant� kuruldu.");
            anaPencere.MesajBilgisi(sunucuAdi + " ayg�t� ile ba�lant� kuruldu.");
            anaPencere.BaglanButonu();
            baglantiKuruldu = true; // Sunucu ile ba�lant� kuruldu...
        }

        /// <summary>
        /// G�rsel aray�zde hata bilgisini g�sterir.
        /// </summary>
        private void HataGoster()
        {
            anaPencere.ArastirmaBilgisi(sunucuAdi + " ayg�t� ile ba�lant� kurulamad�.");
            anaPencere.MesajBilgisi(sunucuAdi + " ayg�t� ile ba�lant� kurulamad�.");
            anaPencere.BaglanButonu();
        }

        /// <summary>
        /// Ba�lant� kurulmu� sunucuya mesaj g�nderir.
        /// </summary>
        /// <param name="mesaj">G�nderilecek mesaj katar�</param>
        /// <returns>Mesaj g�nderme i�leminin sonucu</returns>
        public bool MesajGonder(String mesaj)
        {
            byte[] mesajDizisi = Encoding.Default.GetBytes(mesaj);

            if (sunucu.Connected == false)
            {
                anaPencere.MesajBilgisi(sunucuAdi + " ile ba�lant� kurulamad�.");
                return false;
            }

            try
            {
                sunucuStream.WriteByte(Convert.ToByte(mesajDizisi.Length));
                sunucuStream.Flush();

                sunucuStream.Write(mesajDizisi, 0, mesajDizisi.Length);
                sunucuStream.Flush();
                sunucuStream.ReadByte();

                anaPencere.MesajBilgisi(sunucuAdi + " ayg�t�na mesaj�n�z g�nderildi.");
            }
            catch (Exception)
            {
                anaPencere.MesajBilgisi(sunucuAdi + " ayg�t�na mesaj�n�z g�nderilirken hata olu�tu.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sunucu ile ba�lant�y� keser.
        /// </summary>
        public void Kapat() 
        {
            try
            {
                MesajGonder("bye$?"); // sunucu ile ba�lant�y� koparmak i�in gereken mesaj� g�nder
                
                if(sunucu!=null) {
                    if (sunucuStream != null)
                    {
                        sunucuStream.Close(); // I/O nesnelerini kapat
                    }
                    sunucu.Close(); // sunucu ile ba�lant�y� kes
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
