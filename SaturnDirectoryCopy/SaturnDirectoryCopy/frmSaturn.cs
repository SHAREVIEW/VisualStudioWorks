using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SaturnDirectoryCopy
{
    public partial class frmSaturn : Form
    {
        public frmSaturn()
        {
            InitializeComponent();
        }

        public Thread Kanal;    //Ýþ parçasý tanýmlandý.

        private String kaynakKlasor;
        private String hedefKlasor;
        FileInfo sDosya;
        FileInfo dDosya;
        private String[] dosyaYollari;

        #region frmSaturn
        private void frmSaturn_Load(object sender, EventArgs e)
        {
            lvDosyalar.MultiSelect = false;
            lvDosyalar.View = View.Details;
            Control.CheckForIllegalCrossThreadCalls = false; // Thread içinde kontrollerin özellikleri deðiþebilsin.
        }

        private void frmSaturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult mesaj = MessageBox.Show(this, "Çýkmak istediðinizden emin misiniz?", "Saturn - Directory Copy",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mesaj == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Butonlar
        private void btnKaynak_Click(object sender, EventArgs e)
        {
            dlgFolder.ShowDialog();
            kaynakKlasor = dlgFolder.SelectedPath;
            txtKaynak.Text = kaynakKlasor;

            lvDosyalar.Items.Clear(); // listView'i temizle
            if(Directory.Exists(kaynakKlasor)) // Kaynak klasör seçilmiþse.
            {
                dosyaYollari = Directory.GetFiles(kaynakKlasor); // tüm dosya yollarýný diziye at.
                for(int i=0; i<dosyaYollari.Length; i++)
                {
                    FileInfo mDosya = new FileInfo(dosyaYollari[i]);
                    lvDosyalar.Items.Add(mDosya.Name); // Dosya isimlerini ListView'e ekle.
                    lvDosyalar.Items[i].ImageIndex = 0;
                }
            }
        }

        private void btnHedef_Click(object sender, EventArgs e)
        {
            dlgFolder.ShowDialog();
            hedefKlasor = dlgFolder.SelectedPath;
            txtHedef.Text = hedefKlasor;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(kaynakKlasor))
            {
                if (Directory.Exists(hedefKlasor))
                {
                    if (lvDosyalar.Items.Count > 0)
                    {
                        if (SecimKontrol(lvDosyalar))
                        {
                            Kanal = new Thread(new ThreadStart(Kopyala)); //Kopyala prosedürü için kanal oluþtur
                            Kanal.Priority = ThreadPriority.Normal;
                            Kanal.Start(); // Kopyala metodunu kanal içinde çalýþtýr.
                        }
                        else
                        {
                            MessageBox.Show(this, "Lütfen dosya seçin", "Saturn Kopyalama Hatasý",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Kaynak klasörde dosya bulunamadý", "Saturn Kopyalama Hatasý",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Hedef klasör bulunamadý", "Saturn Kopyalama Hatasý", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Kaynak klasör bulunamadý", "Saturn Kopyalama Hatasý", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Metodlar
        private void Kopyala()
        {
            btnCopy.Enabled = false;
            for (int i = 0; i < lvDosyalar.Items.Count; i++)
            {
                if (lvDosyalar.Items[i].ImageIndex == 1) // Eðer dosya seçilmiþse
                {
                    sDosya = new FileInfo(dosyaYollari[i]);
                    dDosya = new FileInfo(hedefKlasor + "\\" + sDosya.Name);

                    if (dDosya.Exists) // Hedefte ayný dosya varsa
                    {
                        if (cbAddNewFiles.Checked) // AddNewFiles iþaretlenmiþse
                        {
                            if (sDosya.LastWriteTime > dDosya.LastWriteTime) // Dosya tarihlerini kontrol et.
                            {
                                lvDosyalar.Items[i].ImageIndex = 2; // Baþarýlý resmini koy
                                lvDosyalar.Items[i].SubItems.Add(""); // Durum göster
                                lvDosyalar.Items[i].SubItems[1].Text = "Hedef dosya güncellendi."; // Durum göster
                            }
                            else
                            {
                                lvDosyalar.Items[i].ImageIndex = 3; // Hata resmini koy
                                lvDosyalar.Items[i].SubItems.Add(""); // Durum göster
                                lvDosyalar.Items[i].SubItems[1].Text = "Kaynak dosya daha eski"; // Durum göster
                                continue;
                            }
                        }
                        else
                        {
                            lvDosyalar.Items[i].ImageIndex = 3; // Hata resmini koy
                            lvDosyalar.Items[i].SubItems.Add(""); // Durum göster
                            lvDosyalar.Items[i].SubItems[1].Text = "Hedef dosya ile kaynak dosya ayný"; // Durum göster
                            continue;
                        }
                    }
                    else // Hedef dosy yoksa normal kopyalam iþlemini yap
                    {
                        lvDosyalar.Items[i].ImageIndex = 2; // Baþarýlý resmini koy
                        lvDosyalar.Items[i].SubItems.Add(""); // Durum göster
                        lvDosyalar.Items[i].SubItems[1].Text = "Dosya kopyalandý..."; // Durum göster
                    }

                    lblDurum.Text = "Kopyalanýyor...\n" + sDosya.Name;
                    DosyaKopyala(dosyaYollari[i], hedefKlasor + "\\" + sDosya.Name);
                }
            }
            btnCopy.Enabled = true;
            lblDurum.Text = "Durum: Bütün dosyalar kopyalandý!";
        }

        private void DosyaKopyala(String source, String dest)
        {
            try
            {
                FileStream oku = File.OpenRead(source);
                FileStream yaz = File.OpenWrite(dest);
                BufferedStream bfoku = new BufferedStream(oku);
                BufferedStream bfyaz = new BufferedStream(yaz);

                byte[] buffer = new byte[4096];
                int okunanVeri;

                while ((okunanVeri = bfoku.Read(buffer, 0, 4096)) > 0)
                {
                    bfyaz.Write(buffer, 0, okunanVeri); ;
                }
                bfyaz.Flush(); // buffer da kalan veriyi hemen diske yaz...
                oku.Close(); bfoku.Close();
                yaz.Close(); bfyaz.Close();
            }
            catch (IOException hata)
            {
                MessageBox.Show(this, "Kopyalama sýrasýnda hata oluþtu\n" + hata, "Saturn Kopyalama Hatasý",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool SecimKontrol(ListView lvDosyalar)
        {
            for (int i = 0; i < lvDosyalar.Items.Count; i++)
            {
                if (lvDosyalar.Items[i].ImageIndex == 1)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region ListView Metodlarý

        private int index;
        // Bu metod herhangi bir eleman seçiminde SelectedIndices tarafýndan iki defa tetiklenir.
        private void lvDosyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDosyalar.SelectedIndices.Count == 1)
            {
                for (int i = 0; i < lvDosyalar.Items.Count; i++) // Tüm elemanlarý seçimini kaldýr.
                    lvDosyalar.Items[i].ImageIndex = 0;

                index = lvDosyalar.SelectedIndices[0];
                lvDosyalar.Items[index].ImageIndex = 1; // Seçili elemanýn resmi deðiþtir.
            }

            if (lvDosyalar.SelectedIndices.Count <= 0)
                lvDosyalar.Items[index].ImageIndex = 0; // Eleman terk edilmiþse resmi deðiþtir.
        }

        private void lvDosyalar_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                for (int i = 0; i < lvDosyalar.Items.Count; i++)
                    lvDosyalar.Items[i].ImageIndex = 1;
            }

            if (e.Column == 1)
            {
                for (int i = 0; i < lvDosyalar.Items.Count; i++)
                    lvDosyalar.Items[i].ImageIndex = 0;
            }
        }
        #endregion


    }
}