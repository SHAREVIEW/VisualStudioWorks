using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;

namespace AmbarTakip
{
    public partial class CPSKayit : Form
    {
        private String resimAdi = null; // Veritaban�na eklenecek resim dosyas�n�n ad�...
        private String kaynakDosyaYolu = null; // Se�ilen resim dosyas�n� yolu...
        private String hedefDosyaYolu = null; // uygulaman�n �al��t��� resimler klas�r�ndeki resim.
        private FileInfo kaynakDosya = null;
        private FileInfo hedefDosya = null;

        private String YTNO = null;
        private String malzemeAdi = null;
        private String marka = null;
        private String spect = null;

        private bool degisimCPS = false;

        public CPSKayit()
        {
            InitializeComponent();
        }

        private void CPSKayit_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dsCPS.CPS' table. You can move, or remove it, as needed.
                this.taCPS.Fill(this.dsCPS.CPS);
            }
            catch (Exception)
            {
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            dlgResimAyarla();
            txtYTNO.MaxLength = 10;
            picMalzeme.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            VeriAl();

            if (YTNO.Length == 10 && malzemeAdi.Length > 0 && marka.Length > 0 && spect.Length > 0)
            {
                if (KayitKontrol() == false) // Kay�t yok...
                {
                    if (kaynakDosyaYolu != null) // Resim se�ilmi�, kay�t ekleme i�in resimAdi ni ayarla...
                    {
                        ResimAdiAyarla(); // Kay�t i�in gereken resim ad� ve kopyalama i�in gereken path ayarlan�r...
                    }
                    else
                    {
                        resimAdi = Sabitler.varsayilanResimAdi;
                    }

                    if (KayitEkle() == false)
                    {
                        MessageBox.Show(this, Sabitler.hataKayitEkleme, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else // Kay�t sorunsuzca eklendikten sonra resim kopyalans�n...
                    {
                        if (kaynakDosyaYolu != null) // Resim se�ilmi�, resmi kopyala...
                        {
                            ResimKopyala();
                        }

                        Temizle();
                    }
                }
                else
                {
                    MessageBox.Show(this, Sabitler.hataKay�tVar, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, Sabitler.hataBilgiEksik, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VeriAl()
        {
            YTNO = txtYTNO.Text.Trim();
            malzemeAdi = txtMalzemeAdi.Text.Trim();
            marka = txtMarka.Text.Trim();
            spect = txtSpect.Text.Trim();
        }

        private bool KayitKontrol()
        {
            foreach (DataRow satir in dsCPS.CPS.Rows)
            {
                if (satir["YTNO"].ToString() == YTNO)
                {
                    return true;
                }
            }
            return false; // Kay�t bulunamad�...
        }

        private bool KayitEkle()
        {
            try
            {
                dsCPS.Clear();
                taCPS.Insert(YTNO, malzemeAdi, marka, spect, resimAdi);
                taCPS.Fill(dsCPS.CPS);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            try
            {
                this.taCPS.Update(this.dsCPS.CPS);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            kaynakDosyaYolu = null;

            dlgResim.ShowDialog();
            kaynakDosyaYolu = dlgResim.FileName;

            if (kaynakDosyaYolu.Trim().Length > 0) // Resim se�ilmi�...
            {
                if (ResimGoster())
                {
                    txtResim.Text = kaynakDosyaYolu;
                }
                else
                {
                    MessageBox.Show(this, Sabitler.hataResim, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Resim Metodlar�
        private bool ResimGoster()
        {
            Image resim = null;

            try
            {
                resim = Image.FromFile(kaynakDosyaYolu);
                picMalzeme.Image = resim; // Resmi g�ster...
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        private bool ResimKopyala()
        {
            try
            {
                if (hedefDosya.Exists)
                {
                    Console.WriteLine("Silindi...");
                    hedefDosya.Delete();
                }

                Console.WriteLine("Kopyaland�...");
                kaynakDosya.CopyTo(hedefDosyaYolu); // Resmi resimler klas�r�ne kopyala...
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        private void ResimAdiAyarla()
        {
            try
            {
                kaynakDosya = new FileInfo(kaynakDosyaYolu);
                hedefDosyaYolu = Sabitler.resimKlasoru + YTNO + kaynakDosya.Extension; // resim ad� YTNO ile ayn� olacak...
                hedefDosya = new FileInfo(hedefDosyaYolu);

                resimAdi = hedefDosya.Name; // Veritaban�na eklenecek resim ad�. ytxxxxxxxx.jpg �eklinde...
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        } 
        #endregion

        private void CPSKayit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnKaydet_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCikis_Click(sender, e);
            }
        }

        private void dgvCPS_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (degisimCPS)
            {
                try
                {
                    this.taCPS.Update(this.dsCPS.CPS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                degisimCPS = false;
            }
        }

        private void bsCPS_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dsCPS.HasChanges())
            {
                degisimCPS = true;
            }
        }

        private void dgvCPS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow satir = null;

            try
            {
                int index = e.RowIndex;
                satir = dsCPS.CPS.Rows[index];

                if (satir["RESIM"].ToString() == "adsiz.jpg" || satir["RESIM"].ToString() == "")
                {
                    Temizle(); // Kay�t giriliyorsa iptal, yoksa oral�k fena halde kar���r, zihohauahamnuana :D
                    YTNO = satir["YTNO"].ToString(); // YTNO resim ad i�in laz�m...

                    if (ResimGuncelle()==false) // resimAdi ni ayarla ve resmi hedefe kopyala...
                    {
                        return;
                    }

                    if (KayitGuncelle())
                    {
                        try
                        {
                            // TODO: This line of code loads data into the 'dsCPS.CPS' table. You can move, or remove it, as needed.
                            this.taCPS.Fill(this.dsCPS.CPS);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                satir = dsCPS.CPS.Rows[index];
                Resim resim = new Resim(satir, dsCPS);
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.ToString());
            }
        }

        private bool ResimGuncelle()
        {
            DialogResult cevap;
            kaynakDosyaYolu = null;

            cevap = dlgResim.ShowDialog();

            if (cevap == DialogResult.OK)
            {
                kaynakDosyaYolu = dlgResim.FileName;

                if (kaynakDosyaYolu.Trim().Length > 0) // Resim se�ilmi�...
                {
                    ResimAdiAyarla();
                    ResimKopyala();
                    MessageBox.Show(this, YTNO + " kayd�n�n resmi g�ncellendi", "Resim G�ncelleme ��lemi");
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        private bool KayitGuncelle()
        {
            OleDbCommand com = null;
            OleDbConnection baglanti;

            try
            {
                baglanti = new OleDbConnection(Sabitler.veritabaniAdresi);
                com = new OleDbCommand();
                com.Connection = baglanti;
                com.CommandText = "UPDATE CPS Set RESIM='" + resimAdi + "' where YTNO='" + YTNO +"'";
                com.Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            try
            {
                com.ExecuteNonQuery(); // SQL Komutunu �al��t�r...
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            com.Connection.Close(); // Ba�lant�y� kes...
            return true;
        }

        private void dlgResimAyarla()
        {
            dlgResim.Title = "Resim Se�";
            dlgResim.DefaultExt = "jpg"; // Kullan�c� isim yaz�p entere basarsa jpg uzant�l� dosya se�ilir.
            dlgResim.Filter = "Jpeg Dosyalar� (*.jpg)|*.jpg";
            dlgResim.Filter += "|Gif Dosyalar� (*.gif)|*.gif";
            dlgResim.Filter += "|Bitmap Dosyalar� (*.bmp)|*.bmp";
            dlgResim.Filter += "|PNG Dosyalar� (*.png)|*.png";
            //dlgResim.Filter += "|T�m Formatlar (*.*)|*.*";
            //dlgResim.InitialDirectory += Sabitler.uygulamaKlasoru; // �lk g�sterilecek klas�r...
        }

        private void Temizle()
        {
            txtMalzemeAdi.Clear();
            txtMarka.Clear();
            txtResim.Clear();
            txtSpect.Clear();
            txtYTNO.Clear();
            txtYTNO.Focus();
            kaynakDosya = null;
            hedefDosya = null;
            kaynakDosyaYolu = null;
            hedefDosyaYolu = null;
            picMalzeme.Image = null;
        }
    }
}