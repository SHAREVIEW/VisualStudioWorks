using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace AmbarTakip
{
    public partial class MalzemeGiris : Form
    {
        private OleDbConnection baglanti;
        private OleDbDataAdapter odaCPS;
        private OleDbDataAdapter odaUnite;
        private OleDbDataAdapter odaEkipman;
        private OleDbDataAdapter odaMalzeme;
        private DataSet dsAmbar; // Daha hýzlý arama için..

        private String YTNO = null;
        private int Adet = 0;
        private String RafNo = null;
        private String MalzemeAdi = null;
        private String Marka = null;
        private String Spect = null;
        private int MIN = 0;
        private int MAX = 0;
        private int UniteID = 0;
        private int EkipmanID = 0;

        private bool ytSiliniyor = false;

        public MalzemeGiris()
        {
            InitializeComponent();
        }

        private void MalzemeGiris_Load(object sender, EventArgs e)
        {
            if (!Baglan())
            {
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            picMalzeme.SizeMode = PictureBoxSizeMode.StretchImage;
            txtYTNO.MaxLength = 10;
        }

        private bool Baglan()
        {
            try
            {
                baglanti = new OleDbConnection(Sabitler.veritabaniAdresi);

                odaCPS = new OleDbDataAdapter("Select * From CPS", baglanti);
                odaUnite = new OleDbDataAdapter("Select * From Unite",baglanti);
                odaEkipman = new OleDbDataAdapter("Select * From Ekipman", baglanti);
                odaMalzeme = new OleDbDataAdapter("Select * From Malzeme", baglanti);

                dsAmbar = new DataSet();
                odaUnite.Fill(dsAmbar, "Unite");
                odaEkipman.Fill(dsAmbar, "Ekipman");
                odaMalzeme.Fill(dsAmbar, "Malzeme");
                odaCPS.Fill(dsAmbar, "CPS");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            UniteDoldur();
            return true;
        }

        private void txtYTNO_TextChanged(object sender, EventArgs e)
        {
            Image resim = null;
            String raf = null;
            String yt = txtYTNO.Text.Trim();

            // backspace e basýlýyorsa herþeyi sil ve arama yapma
            // backspace haricinde herhangi bri karakter giriþinde arama iþlemi tekrar baþlayacak
            if (ytSiliniyor) 
            {
                AramaTemizle();
                return;
            }

            try
            {
                dsAmbar.Tables["CPS"].Clear();
                odaCPS.SelectCommand.CommandText = "Select * From CPS Where YTNO like '" + yt + "%'";
                odaCPS.Fill(dsAmbar, "CPS");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            if (dsAmbar.Tables["CPS"].Rows.Count != 1)
            {
                AramaTemizle();
                return;
            }
            else if (dsAmbar.Tables["CPS"].Rows.Count == 1) // Kayýt bulundu, malzemeyi göster...
            {
                try
                {
                    DataRow satir = dsAmbar.Tables["CPS"].Rows[0];

                    txtYTNO.Text = satir["YTNO"].ToString();
                    txtMalzemeAdi.Text = satir["MALZEMEADI"].ToString();
                    txtSpect.Text = satir["SPECT"].ToString();
                    txtMarka.Text = satir["MARKA"].ToString();
                    resim = Image.FromFile(Sabitler.resimKlasoru + satir["RESIM"]);
                    picMalzeme.Image = resim;

                    if((raf = RafBul(txtYTNO.Text)) != null) // Malzeme daha önce eklenmiþse raf giriþi yok...
                    {
                        txtRAFNO.Text = raf;
                        txtRAFNO.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
            
            this.Text = dsAmbar.Tables["CPS"].Rows.Count.ToString();
        }

        private void AramaTemizle()
        {
            txtMalzemeAdi.Clear();
            txtMarka.Clear();
            txtSpect.Clear();
            txtRAFNO.Clear();
            txtRAFNO.Enabled = true;
            picMalzeme.Image = null;
            return;
        }

        private String RafBul(String YT)
        {
            try
            {
                dsAmbar.Tables["Malzeme"].Clear();
                odaMalzeme.SelectCommand.CommandText = "Select * From Malzeme";
                odaMalzeme.Fill(dsAmbar, "Malzeme");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            foreach (DataRow satir in dsAmbar.Tables["Malzeme"].Rows)
            {
                if (satir["YTNO"].ToString() == YT)
                {
                    return satir["RAFNO"].ToString();
                }
            }
            return null;
        }

        #region ComboBox Doldurma Metodlarý
        private void UniteDoldur()
        {
            OleDbDataReader dataReader = null;
            OleDbCommand com = null;

            try
            {
                com = new OleDbCommand();
                com.Connection = baglanti;
                com.CommandText = "Select * From Unite";
                com.Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            try
            {
                dataReader = com.ExecuteReader(); // SQL Komutunu çalýþtýr...
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            while (dataReader.Read())
            {
                cmbUniteler.Items.Add(dataReader.GetString(1));
            }

            com.Connection.Close(); // Baðlantýyý kes...
        }

        private void EkipmanDoldur()
        {
            OleDbDataReader dataReader = null;
            OleDbCommand com = null;

            try
            {
                com = new OleDbCommand();
                com.Connection = baglanti;
                com.CommandText = "Select * From Ekipman where UNITE_ID=" + UniteID + "";
                com.Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            try
            {
                dataReader = com.ExecuteReader(); // SQL Komutunu çalýþtýr...
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            while (dataReader.Read())
            {
                cmbEkipmanlar.Items.Add(dataReader.GetString(2));
            }

            com.Connection.Close(); // Baðlantýyý kes...
        } 
        #endregion

        private void cmbUnite_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (VeriAl() == false)// Girilen deðerleri deðiþkenlere yükle...
            {
                MessageBox.Show(this, Sabitler.hataBilgiEksik, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (YTNO.Length == 10 && Adet > 0 && RafNo.Length > 0 && UniteID > 0 && EkipmanID > 0 && MIN > 0 && MAX > 0)
            {
                if (RafKontrol()) // Rafý varsa hata ver...
                {
                    MessageBox.Show(this, Sabitler.hataRafNo, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (KayitEkle() == false)
                {
                    MessageBox.Show(this, Sabitler.hataKayitEkleme, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, Sabitler.hataBilgiEksik, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Temizle();
        }

        private bool VeriAl()
        {
            try
            {
                YTNO = txtYTNO.Text.Trim();
                MalzemeAdi = txtMalzemeAdi.Text.Trim();
                Marka = txtMarka.Text.Trim();
                Spect = txtSpect.Text.Trim();
                RafNo = txtRAFNO.Text.Trim();
                Adet = Convert.ToInt32(txtAdet.Text.Trim());
                MIN = Convert.ToInt32(txtMIN.Text.Trim());
                MAX = Convert.ToInt32(txtMAX.Text.Trim());
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private bool RafKontrol()
        {
            // Rafýn baþka bir malzeme tarafýndan kullanýlmasý durumunu kontrol eder.
            try
            {
                dsAmbar.Tables["Malzeme"].Clear();
                odaMalzeme.SelectCommand.CommandText = "Select * From Malzeme Where RAFNO='" + RafNo + "' And YTNO<>'" + YTNO + "'";
                odaMalzeme.Fill(dsAmbar, "Malzeme");
                if (dsAmbar.Tables["Malzeme"].Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool KayitEkle()
        {
            OleDbCommand com = null;

            try
            {
                com = new OleDbCommand();
                com.Connection = baglanti;
                com.CommandText = "INSERT INTO Malzeme(YTNO,ADET,RAFNO,UNITE,EKIPMAN,[MIN],[MAX])";
                com.CommandText += " VALUES('" + YTNO + "','" + Adet + "','" + RafNo + "'," + UniteID + "," + EkipmanID + "";
                com.CommandText += "," + MIN + "," + MAX + ")";
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

        private void cmbUnite_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow satir in dsAmbar.Tables["Unite"].Rows)
            {
                if (satir["UNITE"].ToString() == cmbUniteler.SelectedItem.ToString())
                {
                    UniteID = Convert.ToInt32(satir["ID"]); // Ekipman eklemek için gereken ünite deðerini al.
                }
            }
            cmbEkipmanlar.Items.Clear();
            cmbEkipmanlar.Text = "Ekipman Seçin";
            EkipmanDoldur();
        }

        private void cmbEkipman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UniteID > 0) // Ünite seçilmiþse
            {
                foreach (DataRow satir in dsAmbar.Tables["Ekipman"].Rows)
                {
                    if (Convert.ToInt32(satir["UNITE_ID"]) == UniteID)
                    {
                        EkipmanID = Convert.ToInt32(satir["ID"]); // Ekipman eklemek için gereken ünite deðerini al.
                    }
                }
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

        private void MalzemeGiris_KeyDown(object sender, KeyEventArgs e)
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

        private void Temizle()
        {
            txtAdet.Clear();
            txtRAFNO.Clear();
            txtMalzemeAdi.Clear();
            txtMarka.Clear();
            txtMIN.Clear();
            txtMAX.Clear();
            txtSpect.Clear();
            picMalzeme.Image = null;
                cmbUniteler.Text = "Ünite Seçin";
                cmbEkipmanlar.Text = "Ekipman Seçin";
                cmbEkipmanlar.Items.Clear();
            dsAmbar.Tables["CPS"].Clear();
                txtYTNO.Clear();
                txtYTNO.Focus();
        }

        private void txtYTNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                ytSiliniyor = true;
            }
            else
            {
                ytSiliniyor = false;
            }
        }
    }
}