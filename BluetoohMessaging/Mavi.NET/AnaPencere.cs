using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

// 32feet API...
using InTheHand.Net;        
using InTheHand.Net.Sockets;

namespace BTChat
{
    public partial class AnaPencere : Form
    {
        #region Genel De�i�kenler

        /// <summary>
        /// Bluetooth ba�lant�lar�n� y�netir.
        /// </summary>
        private Sunucu sunucu = null;

        /// <summary>
        /// Ortamdaki bluetooth ayg�tlar�n� ara�t�r�r.
        /// </summary>
        private Arastirma arastirma = null;

        /// <summary>
        /// Bluetooth sunucusuna ba�lan�r ve text mesaj g�nderir.
        /// </summary>
        private Mesajlasma mesajlasma = null;

        /// <summary>
        /// Ayg�t ara�t�rma sonucu bulunan ayg�tlar�n(sunucular�n) adreslerini saklar.
        /// </summary>
        private List<BluetoothAddress> SunucuAdresleri;

        /// <summary>
        /// Sunucuya ba�lanan ayg�tlar�n(istemcilerin) adreslerini saklar.
        /// </summary>
        private List<BluetoothAddress> IstemciAdresleri;

        // Thread-safe i�in gerekli temsilciler...
        // Uygulamada birden fazla thread kullan�ld���dan ve ayn� anda 
        // birden fazla thread'�n g�rsel bir bile�ene eri�mesi yasak oldu�undan
        // bile�enlere g�venli bir �ekilde eri�im sa�lanmal�d�r.
        private delegate void TemsilciArastirmaButonu();
        private delegate void TemsilciBaglanButonu();
        private delegate void TemsilciSunucuEkle(String aygitAdi);
        private delegate void TemsilciArastirmaDurumuGoster(String durum);
        private delegate void TemsilciMesajDurumuGoster(String durum);
        private delegate void TemsilciIstemciSayisiGoster(String bilgi);
        private delegate void TemsilciSunucuUyariGoster(String mesaj);
        private delegate void TemsilciGelenMesajGoster(String mesaj, String ad);
        private delegate void TemsilciIstemciEkle(String istemciAdi);
        private delegate void TemsilciIstemciCikar(int index);

        /// <summary>
        /// Mesajla�ma i�leminin listedeki hangi ayg�t(sunucu) ile yap�laca��n� saklar.
        /// </summary>
        private int secilenAygit = -1;

        /// <summary>
        /// Ba�lant� kurulan sunucu ad�n� saklar.
        /// </summary>
        String sunucuAdi = null;

        /// <summary>
        /// �stemcilerden gelen mesajlar� formatlar ve metin penceresinde g�sterir.
        /// </summary>
        private MesajFormat mesajFormat;

        #endregion

        public AnaPencere()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mesajFormat = new MesajFormat(); // MesajFormat s�n�f�n� �rnekle.
            SunucuAdresleri = new List<BluetoothAddress>();
            IstemciAdresleri = new List<BluetoothAddress>();
            sunucu = new Sunucu(this); // Sunucu �rne�i olu�tur, sunucu �al��t�r�lm�� olur.
            txtMesaj.MaxLength = Sabitler.MAX_MESAJ_UZUNLUGU; // Max mesaj uzunlu�u 255 karakter.
        }

        private void btnArastir_Click(object sender, EventArgs e)
        {
            cmbAygitlar.Items.Clear(); // Listeyi temizle.
            SunucuAdresleri.Clear(); // Sunucu adreslerini temizle...

            cmbAygitlar.Text = "Ayg�t Se�in";
            secilenAygit = -1; // Se�ilen ayg�t yok.

            btnArastir.Enabled = false;
            lblArastirma.Text = "Durum: Arastirma ba�lad�. L�tfen bekleyiniz...";

            arastirma = new Arastirma(this); // Ayg�t ara�t�rmay� ba�lat...
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            BluetoothAddress secilenAdres = null;

            secilenAygit = cmbAygitlar.SelectedIndex;

            if (secilenAygit < 0)
            {
                lblArastirma.Text = "Durum: L�tfen ayg�t se�in.";
                return;
            }

            if (cmbAygitlar.Items.Count <= 0)
            {
                return;
            }

            btnBaglan.Enabled = false;

            secilenAdres = SunucuAdresleri[secilenAygit]; // Sunucu adresini al.
            sunucuAdi = cmbAygitlar.SelectedItem.ToString(); // sunucu ad�n� al.

            if (mesajlasma != null) // Daha �nce bir sunucu ile ba�lant� kurulmu�sa kapat.
            {
                mesajlasma.Kapat();
                mesajlasma = null; // mesajlasma nesnesini yoket.
            }

            ArastirmaBilgisi(sunucuAdi + " ile ba�lant� kuruluyor...");
            MesajBilgisi(sunucuAdi + " ile ba�lant� kuruluyor...");
            
            mesajlasma = new Mesajlasma(secilenAdres, this, sunucuAdi); // Se�ilen ayg�ta(sunucuya) ba�lan.
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            String mesaj = txtMesaj.Text.Trim();

            if (mesaj.Length == 0)
            {
                lblMesajlasma.Text = "Durum: L�tfen mesaj girin.";
                return;
            }

            if (mesajlasma == null) // Sunucu ile ba�lant� kurulmam��
            {
                lblMesajlasma.Text = "Durum: L�tfen bir ayg�t ile ba�lant� kurun.";
                return;
            }

            if (mesajlasma.BaglantiKuruldu == false)
            {
                lblMesajlasma.Text = "Durum: L�tfen bir ayg�t ile ba�lant� kurun.";
                return;
            }

            lblMesajlasma.Text = "Durum: Mesaj g�nderiliyor...";
            if (mesajlasma != null)
            {
                if (mesajlasma.MesajGonder(mesaj))
                {
                    mesajFormat.MesajGoster(mesaj, "-> " + sunucuAdi, txtGidenMesajlar);
                    txtMesaj.Clear();
                }
            }
        }

        public void IstemciSayisiArtir(String istemciAdi, BluetoothAddress istemciAdresi) 
        {
            IstemciAdresleri.Add(istemciAdresi);
            IstemciEkle(istemciAdi);
            IstemciSayisiGoster("Sunucuya Ba�l� �stemciler: " + IstemciAdresleri.Count);
        }
        
        public void IstemciSayisiAzalt(BluetoothAddress istemciAdresi, String istemciAdi) 
        {
            int index = IstemciAdresleri.IndexOf(istemciAdresi);
            IstemciAdresleri.Remove(istemciAdresi);
            IstemciCikar(index);
            IstemciSayisiGoster("Sunucuya Ba�l� �stemciler: " + IstemciAdresleri.Count);
            SunucuUyariGoster(istemciAdi + " ile ba�lant� sona erdi.");
        }

        public void AdresEkle(BluetoothAddress adres)
        {
            try
            {
                SunucuAdresleri.Add(adres);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Kapat()
        {
            if (mesajlasma != null)
            {
                mesajlasma.Kapat();
            }
            if (sunucu != null)
            {
                sunucu.Kapat();
            }
            Thread.Sleep(200);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kapat();
        }

        private void txtMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnGonder_Click(sender, e);
            }
        }

        #region Thread-Safe Metodlar�
        public void SunucuEkle(String aygitAdi)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (cmbAygitlar.InvokeRequired)
            {
                TemsilciSunucuEkle t = new TemsilciSunucuEkle(SunucuEkle); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { aygitAdi });
            }
            else
            {
                this.cmbAygitlar.Items.Add(aygitAdi); // thread-safe sa�land�. ayg�t� listeye ekle...
            }
        }

        public void IstemciEkle(String istemciAdi)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (lstIstemciler.InvokeRequired)
            {
                TemsilciIstemciEkle t = new TemsilciIstemciEkle(IstemciEkle); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { istemciAdi });
            }
            else
            {
                lstIstemciler.Items.Add(istemciAdi);
            }
        }

        public void IstemciCikar(int index)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (lstIstemciler.InvokeRequired)
            {
                TemsilciIstemciCikar t = new TemsilciIstemciCikar(IstemciCikar); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { index });
            }
            else
            {
                lstIstemciler.Items.RemoveAt(index);
            }
        }

        public void ArastirmaButonu()
        {
            if (btnArastir.InvokeRequired)
            {
                TemsilciArastirmaButonu t = new TemsilciArastirmaButonu(ArastirmaButonu);
                this.Invoke(t, null);
            }
            else
            {
                btnArastir.Enabled = true;
            }
        }

        public void BaglanButonu()
        {
            if (btnBaglan.InvokeRequired)
            {
                TemsilciBaglanButonu t = new TemsilciBaglanButonu(BaglanButonu);
                this.Invoke(t, null);
            }
            else
            {
                btnBaglan.Enabled = true;
            }
        }

        public void ArastirmaBilgisi(String durum)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (lblArastirma.InvokeRequired)
            {
                TemsilciArastirmaDurumuGoster t = new TemsilciArastirmaDurumuGoster(ArastirmaBilgisi); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { durum });
            }
            else
            {
                lblArastirma.Text = "Durum: " + durum;
            }
        }

        public void MesajBilgisi(String durum)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (lblMesajlasma.InvokeRequired)
            {
                TemsilciMesajDurumuGoster t = new TemsilciMesajDurumuGoster(MesajBilgisi); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { durum });
            }
            else
            {
                lblMesajlasma.Text = "Durum : " + durum;
            }
        }

        public void IstemciSayisiGoster(String bilgi)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (lblIstemciSayisi.InvokeRequired)
            {
                TemsilciIstemciSayisiGoster t = new TemsilciIstemciSayisiGoster(IstemciSayisiGoster); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { bilgi});
            }
            else
            {
                lblIstemciSayisi.Text = bilgi;
            }
        }

        public void SunucuUyariGoster(String mesaj)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (txtGelenMesajlar.InvokeRequired)
            {
                TemsilciSunucuUyariGoster t = new TemsilciSunucuUyariGoster(SunucuUyariGoster); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { mesaj });
            }
            else
            {
                mesajFormat.UyariGoster(mesaj, txtGelenMesajlar);
            }
        }

        public void GelenMesajGoster(String mesaj, String ad)
        {
            // E�er kontrol� �a��ran thread ile onu olu�turan thread farkl� ise
            // temsilci olu�turulur ve invoke ile metodun kendisini asenkronize olarak �a��rmas� sa�lan�r...
            if (txtGelenMesajlar.InvokeRequired)
            {
                TemsilciGelenMesajGoster t = new TemsilciGelenMesajGoster(GelenMesajGoster); // rek�rsif olarak �a��r�yoruz...
                this.Invoke(t, new object[] { mesaj, ad });
            }
            else
            {
                mesajFormat.MesajGoster(mesaj, ad, txtGelenMesajlar);
            }
        }
        #endregion
    }
}