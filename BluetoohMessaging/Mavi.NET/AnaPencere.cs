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
        #region Genel Deðiþkenler

        /// <summary>
        /// Bluetooth baðlantýlarýný yönetir.
        /// </summary>
        private Sunucu sunucu = null;

        /// <summary>
        /// Ortamdaki bluetooth aygýtlarýný araþtýrýr.
        /// </summary>
        private Arastirma arastirma = null;

        /// <summary>
        /// Bluetooth sunucusuna baðlanýr ve text mesaj gönderir.
        /// </summary>
        private Mesajlasma mesajlasma = null;

        /// <summary>
        /// Aygýt araþtýrma sonucu bulunan aygýtlarýn(sunucularýn) adreslerini saklar.
        /// </summary>
        private List<BluetoothAddress> SunucuAdresleri;

        /// <summary>
        /// Sunucuya baðlanan aygýtlarýn(istemcilerin) adreslerini saklar.
        /// </summary>
        private List<BluetoothAddress> IstemciAdresleri;

        // Thread-safe için gerekli temsilciler...
        // Uygulamada birden fazla thread kullanýldýðýdan ve ayný anda 
        // birden fazla thread'ýn görsel bir bileþene eriþmesi yasak olduðundan
        // bileþenlere güvenli bir þekilde eriþim saðlanmalýdýr.
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
        /// Mesajlaþma iþleminin listedeki hangi aygýt(sunucu) ile yapýlacaðýný saklar.
        /// </summary>
        private int secilenAygit = -1;

        /// <summary>
        /// Baðlantý kurulan sunucu adýný saklar.
        /// </summary>
        String sunucuAdi = null;

        /// <summary>
        /// Ýstemcilerden gelen mesajlarý formatlar ve metin penceresinde gösterir.
        /// </summary>
        private MesajFormat mesajFormat;

        #endregion

        public AnaPencere()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mesajFormat = new MesajFormat(); // MesajFormat sýnýfýný örnekle.
            SunucuAdresleri = new List<BluetoothAddress>();
            IstemciAdresleri = new List<BluetoothAddress>();
            sunucu = new Sunucu(this); // Sunucu örneði oluþtur, sunucu çalýþtýrýlmýþ olur.
            txtMesaj.MaxLength = Sabitler.MAX_MESAJ_UZUNLUGU; // Max mesaj uzunluðu 255 karakter.
        }

        private void btnArastir_Click(object sender, EventArgs e)
        {
            cmbAygitlar.Items.Clear(); // Listeyi temizle.
            SunucuAdresleri.Clear(); // Sunucu adreslerini temizle...

            cmbAygitlar.Text = "Aygýt Seçin";
            secilenAygit = -1; // Seçilen aygýt yok.

            btnArastir.Enabled = false;
            lblArastirma.Text = "Durum: Arastirma baþladý. Lütfen bekleyiniz...";

            arastirma = new Arastirma(this); // Aygýt araþtýrmayý baþlat...
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            BluetoothAddress secilenAdres = null;

            secilenAygit = cmbAygitlar.SelectedIndex;

            if (secilenAygit < 0)
            {
                lblArastirma.Text = "Durum: Lütfen aygýt seçin.";
                return;
            }

            if (cmbAygitlar.Items.Count <= 0)
            {
                return;
            }

            btnBaglan.Enabled = false;

            secilenAdres = SunucuAdresleri[secilenAygit]; // Sunucu adresini al.
            sunucuAdi = cmbAygitlar.SelectedItem.ToString(); // sunucu adýný al.

            if (mesajlasma != null) // Daha önce bir sunucu ile baðlantý kurulmuþsa kapat.
            {
                mesajlasma.Kapat();
                mesajlasma = null; // mesajlasma nesnesini yoket.
            }

            ArastirmaBilgisi(sunucuAdi + " ile baðlantý kuruluyor...");
            MesajBilgisi(sunucuAdi + " ile baðlantý kuruluyor...");
            
            mesajlasma = new Mesajlasma(secilenAdres, this, sunucuAdi); // Seçilen aygýta(sunucuya) baðlan.
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            String mesaj = txtMesaj.Text.Trim();

            if (mesaj.Length == 0)
            {
                lblMesajlasma.Text = "Durum: Lütfen mesaj girin.";
                return;
            }

            if (mesajlasma == null) // Sunucu ile baðlantý kurulmamýþ
            {
                lblMesajlasma.Text = "Durum: Lütfen bir aygýt ile baðlantý kurun.";
                return;
            }

            if (mesajlasma.BaglantiKuruldu == false)
            {
                lblMesajlasma.Text = "Durum: Lütfen bir aygýt ile baðlantý kurun.";
                return;
            }

            lblMesajlasma.Text = "Durum: Mesaj gönderiliyor...";
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
            IstemciSayisiGoster("Sunucuya Baðlý Ýstemciler: " + IstemciAdresleri.Count);
        }
        
        public void IstemciSayisiAzalt(BluetoothAddress istemciAdresi, String istemciAdi) 
        {
            int index = IstemciAdresleri.IndexOf(istemciAdresi);
            IstemciAdresleri.Remove(istemciAdresi);
            IstemciCikar(index);
            IstemciSayisiGoster("Sunucuya Baðlý Ýstemciler: " + IstemciAdresleri.Count);
            SunucuUyariGoster(istemciAdi + " ile baðlantý sona erdi.");
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

        #region Thread-Safe Metodlarý
        public void SunucuEkle(String aygitAdi)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (cmbAygitlar.InvokeRequired)
            {
                TemsilciSunucuEkle t = new TemsilciSunucuEkle(SunucuEkle); // rekürsif olarak çaðýrýyoruz...
                this.Invoke(t, new object[] { aygitAdi });
            }
            else
            {
                this.cmbAygitlar.Items.Add(aygitAdi); // thread-safe saðlandý. aygýtý listeye ekle...
            }
        }

        public void IstemciEkle(String istemciAdi)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (lstIstemciler.InvokeRequired)
            {
                TemsilciIstemciEkle t = new TemsilciIstemciEkle(IstemciEkle); // rekürsif olarak çaðýrýyoruz...
                this.Invoke(t, new object[] { istemciAdi });
            }
            else
            {
                lstIstemciler.Items.Add(istemciAdi);
            }
        }

        public void IstemciCikar(int index)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (lstIstemciler.InvokeRequired)
            {
                TemsilciIstemciCikar t = new TemsilciIstemciCikar(IstemciCikar); // rekürsif olarak çaðýrýyoruz...
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
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (lblArastirma.InvokeRequired)
            {
                TemsilciArastirmaDurumuGoster t = new TemsilciArastirmaDurumuGoster(ArastirmaBilgisi); // rekürsif olarak çaðýrýyoruz...
                this.Invoke(t, new object[] { durum });
            }
            else
            {
                lblArastirma.Text = "Durum: " + durum;
            }
        }

        public void MesajBilgisi(String durum)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (lblMesajlasma.InvokeRequired)
            {
                TemsilciMesajDurumuGoster t = new TemsilciMesajDurumuGoster(MesajBilgisi); // rekürsif olarak çaðýrýyoruz...
                this.Invoke(t, new object[] { durum });
            }
            else
            {
                lblMesajlasma.Text = "Durum : " + durum;
            }
        }

        public void IstemciSayisiGoster(String bilgi)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (lblIstemciSayisi.InvokeRequired)
            {
                TemsilciIstemciSayisiGoster t = new TemsilciIstemciSayisiGoster(IstemciSayisiGoster); // rekürsif olarak çaðýrýyoruz...
                this.Invoke(t, new object[] { bilgi});
            }
            else
            {
                lblIstemciSayisi.Text = bilgi;
            }
        }

        public void SunucuUyariGoster(String mesaj)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (txtGelenMesajlar.InvokeRequired)
            {
                TemsilciSunucuUyariGoster t = new TemsilciSunucuUyariGoster(SunucuUyariGoster); // rekürsif olarak çaðýrýyoruz...
                this.Invoke(t, new object[] { mesaj });
            }
            else
            {
                mesajFormat.UyariGoster(mesaj, txtGelenMesajlar);
            }
        }

        public void GelenMesajGoster(String mesaj, String ad)
        {
            // Eðer kontrolü çaðýran thread ile onu oluþturan thread farklý ise
            // temsilci oluþturulur ve invoke ile metodun kendisini asenkronize olarak çaðýrmasý saðlanýr...
            if (txtGelenMesajlar.InvokeRequired)
            {
                TemsilciGelenMesajGoster t = new TemsilciGelenMesajGoster(GelenMesajGoster); // rekürsif olarak çaðýrýyoruz...
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