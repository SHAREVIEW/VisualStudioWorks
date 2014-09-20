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

        public Thread Kanal;    //�� par�as� tan�mland�.

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
            Control.CheckForIllegalCrossThreadCalls = false; // Thread i�inde kontrollerin �zellikleri de�i�ebilsin.
        }

        private void frmSaturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult mesaj = MessageBox.Show(this, "��kmak istedi�inizden emin misiniz?", "Saturn - Directory Copy",
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
            if(Directory.Exists(kaynakKlasor)) // Kaynak klas�r se�ilmi�se.
            {
                dosyaYollari = Directory.GetFiles(kaynakKlasor); // t�m dosya yollar�n� diziye at.
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
                            Kanal = new Thread(new ThreadStart(Kopyala)); //Kopyala prosed�r� i�in kanal olu�tur
                            Kanal.Priority = ThreadPriority.Normal;
                            Kanal.Start(); // Kopyala metodunu kanal i�inde �al��t�r.
                        }
                        else
                        {
                            MessageBox.Show(this, "L�tfen dosya se�in", "Saturn Kopyalama Hatas�",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Kaynak klas�rde dosya bulunamad�", "Saturn Kopyalama Hatas�",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Hedef klas�r bulunamad�", "Saturn Kopyalama Hatas�", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Kaynak klas�r bulunamad�", "Saturn Kopyalama Hatas�", 
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
                if (lvDosyalar.Items[i].ImageIndex == 1) // E�er dosya se�ilmi�se
                {
                    sDosya = new FileInfo(dosyaYollari[i]);
                    dDosya = new FileInfo(hedefKlasor + "\\" + sDosya.Name);

                    if (dDosya.Exists) // Hedefte ayn� dosya varsa
                    {
                        if (cbAddNewFiles.Checked) // AddNewFiles i�aretlenmi�se
                        {
                            if (sDosya.LastWriteTime > dDosya.LastWriteTime) // Dosya tarihlerini kontrol et.
                            {
                                lvDosyalar.Items[i].ImageIndex = 2; // Ba�ar�l� resmini koy
                                lvDosyalar.Items[i].SubItems.Add(""); // Durum g�ster
                                lvDosyalar.Items[i].SubItems[1].Text = "Hedef dosya g�ncellendi."; // Durum g�ster
                            }
                            else
                            {
                                lvDosyalar.Items[i].ImageIndex = 3; // Hata resmini koy
                                lvDosyalar.Items[i].SubItems.Add(""); // Durum g�ster
                                lvDosyalar.Items[i].SubItems[1].Text = "Kaynak dosya daha eski"; // Durum g�ster
                                continue;
                            }
                        }
                        else
                        {
                            lvDosyalar.Items[i].ImageIndex = 3; // Hata resmini koy
                            lvDosyalar.Items[i].SubItems.Add(""); // Durum g�ster
                            lvDosyalar.Items[i].SubItems[1].Text = "Hedef dosya ile kaynak dosya ayn�"; // Durum g�ster
                            continue;
                        }
                    }
                    else // Hedef dosy yoksa normal kopyalam i�lemini yap
                    {
                        lvDosyalar.Items[i].ImageIndex = 2; // Ba�ar�l� resmini koy
                        lvDosyalar.Items[i].SubItems.Add(""); // Durum g�ster
                        lvDosyalar.Items[i].SubItems[1].Text = "Dosya kopyaland�..."; // Durum g�ster
                    }

                    lblDurum.Text = "Kopyalan�yor...\n" + sDosya.Name;
                    DosyaKopyala(dosyaYollari[i], hedefKlasor + "\\" + sDosya.Name);
                }
            }
            btnCopy.Enabled = true;
            lblDurum.Text = "Durum: B�t�n dosyalar kopyaland�!";
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
                MessageBox.Show(this, "Kopyalama s�ras�nda hata olu�tu\n" + hata, "Saturn Kopyalama Hatas�",
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

        #region ListView Metodlar�

        private int index;
        // Bu metod herhangi bir eleman se�iminde SelectedIndices taraf�ndan iki defa tetiklenir.
        private void lvDosyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDosyalar.SelectedIndices.Count == 1)
            {
                for (int i = 0; i < lvDosyalar.Items.Count; i++) // T�m elemanlar� se�imini kald�r.
                    lvDosyalar.Items[i].ImageIndex = 0;

                index = lvDosyalar.SelectedIndices[0];
                lvDosyalar.Items[index].ImageIndex = 1; // Se�ili eleman�n resmi de�i�tir.
            }

            if (lvDosyalar.SelectedIndices.Count <= 0)
                lvDosyalar.Items[index].ImageIndex = 0; // Eleman terk edilmi�se resmi de�i�tir.
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