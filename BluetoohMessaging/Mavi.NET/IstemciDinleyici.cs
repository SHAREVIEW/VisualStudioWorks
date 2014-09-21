using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using InTheHand.Net;
using InTheHand.Net.Sockets;

using System.IO;

namespace BTChat
{
    class IstemciDinleyici
    {
        private AnaPencere anaPencere = null;

        private BluetoothClient istemci = null;
        private Stream stream = null;

        private bool istemciDinleniyor = false;

        private String istemciAdi = null;
        private BluetoothAddress istemciAdresi = null;

        private Thread istemciKanali;

        public IstemciDinleyici(BluetoothClient istemci, AnaPencere pencere)
        {
            this.istemci = istemci;
            this.anaPencere = pencere;

            istemciAdi = this.istemci.RemoteMachineName;
            istemciAdresi = ((BluetoothEndPoint)(this.istemci.Client.RemoteEndPoint)).Address; // :D

            anaPencere.SunucuUyariGoster("Ýstemci baðlandý: " + istemciAdi);

            istemciKanali = new Thread(new ThreadStart(Kanal));
            istemciKanali.Start();
        }

        private void Kanal()
        {
            anaPencere.IstemciSayisiArtir(istemciAdi, istemciAdresi);

            stream = istemci.GetStream(); // I/O nesnelerini al.

            Dinle(); // Ýstemci dinleniyor...

            anaPencere.IstemciSayisiAzalt(istemciAdresi,istemciAdi);
        }

        private void Dinle()
        {
            istemciDinleniyor = true;
            String gelenMesaj = null;

            while (istemciDinleniyor)
            {
                gelenMesaj = MesajOku(Sabitler.MAX_MESAJ_UZUNLUGU);
                if (gelenMesaj == null)
                {
                    istemciDinleniyor = false;
                }
                else
                {
                    if (gelenMesaj.Trim().Equals("bye$?"))
                    {
                        istemciDinleniyor = false;
                    }
                    else
                    {
                        anaPencere.GelenMesajGoster(gelenMesaj, istemciAdi);
                    }
                }
            }
        }

        private String MesajOku(int maxUzunluk)
        {
            int okunan = 0;
            byte[] veri = new byte[maxUzunluk];
            String okunanVeri = null;

            try
            {
                okunan = stream.ReadByte();

                stream.Read(veri, 0, maxUzunluk);

                stream.WriteByte(0);
                stream.Flush();

                okunanVeri = Encoding.Default.GetString(veri, 0, okunan);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: Gelen mesaj okunamýyor." + ex.ToString());
                return null;
            }
           
            return okunanVeri;
        }

        public void Kapat()
        {
            istemciDinleniyor = false;

            try
            {
                if (istemci != null)
                {
                    istemci.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: Gelen mesaj okunamýyor." + ex.ToString());
            }
        }

    }
}
