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
        private String resimAdi = null; // Veritabanýna eklenecek resim dosyasýnýn adý...
        private String kaynakDosyaYolu = null; // Seçilen resim dosyasýný yolu...
        private String hedefDosyaYolu = null; // uygulamanýn çalýþtýðý resimler klasöründeki resim.
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
                if (KayitKontrol() == false) // Kayýt yok...
                {
                    if (kaynakDosyaYolu != null) // Resim seçilmiþ, kayýt ekleme için resimAdi ni ayarla...
                    {
                        ResimAdiAyarla(); // Kayýt için gereken resim adý ve kopyalama için gereken path ayarlanýr...
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
                    else // Kayýt sorunsuzca eklendikten sonra resim kopyalansýn...
                    {
                        if (kaynakDosyaYolu != null) // Resim seçilmiþ, resmi kopyala...
                        {
                            ResimKopyala();
                        }

                        Temizle();
                    }
                }
                else
                {
                    MessageBox.Show(this, Sabitler.hataKayýtVar, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return false; // Kayýt bulunamadý...
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

            if (kaynakDosyaYolu.Trim().Length > 0) // Resim seçilmiþ...
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

        #region Resim Metodlarý
        private bool ResimGoster()
        {
            Image resim = null;

            try
            {
                resim = Image.FromFile(kaynakDosyaYolu);
                picMalzeme.Image = resim; // Resmi göster...
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

                Console.WriteLine("Kopyalandý...");
                kaynakDosya.CopyTo(hedefDosyaYolu); // Resmi resimler klasörüne kopyala...
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
                hedefDosyaYolu = Sabitler.resimKlasoru + YTNO + kaynakDosya.Extension; // resim adý YTNO ile ayný olacak...
                hedefDosya = new FileInfo(hedefDosyaYolu);

                resimAdi = hedefDosya.Name; // Veritabanýna eklenecek resim adý. ytxxxxxxxx.jpg þeklinde...
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
                    Temizle(); // Kayýt giriliyorsa iptal, yoksa oralýk fena halde karýþýr, zihohauahamnuana :D
                    YTNO = satir["YTNO"].ToString(); // YTNO resim ad için lazým...

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

                if (kaynakDosyaYolu.Trim().Length > 0) // Resim seçilmiþ...
                {
                    ResimAdiAyarla();
                    ResimKopyala();
                    MessageBox.Show(this, YTNO + " kaydýnýn resmi güncellendi", "Resim Güncelleme Ýþlemi");
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
                com.ExecuteNonQuery(); // SQL Komutunu çalýþtýr...
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            com.Connection.Close(); // Baðlantýyý kes...
            return true;
        }

        private void dlgResimAyarla()
        {
            dlgResim.Title = "Resim Seç";
            dlgResim.DefaultExt = "jpg"; // Kullanýcý isim yazýp entere basarsa jpg uzantýlý dosya seçilir.
            dlgResim.Filter = "Jpeg Dosyalarý (*.jpg)|*.jpg";
            dlgResim.Filter += "|Gif Dosyalarý (*.gif)|*.gif";
            dlgResim.Filter += "|Bitmap Dosyalarý (*.bmp)|*.bmp";
            dlgResim.Filter += "|PNG Dosyalarý (*.png)|*.png";
            //dlgResim.Filter += "|Tüm Formatlar (*.*)|*.*";
            //dlgResim.InitialDirectory += Sabitler.uygulamaKlasoru; // Ýlk gösterilecek klasör...
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