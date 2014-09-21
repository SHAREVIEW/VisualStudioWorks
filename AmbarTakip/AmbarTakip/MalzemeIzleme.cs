using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmbarTakip
{
    public partial class MalzemeIzleme : Form
    {
        private bool degisimMalzeme = false;
        private bool degisimUnite = false;
        private bool degisimEkipman = false;

        public MalzemeIzleme()
        {
            InitializeComponent();
        }

        private void MalzemeGuncelleme_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsIzleme.CPS' table. You can move, or remove it, as needed.
            this.taCPS.Fill(this.dsIzleme.CPS);
            try
            {
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Malzeme' table. You can move, or remove it, as needed.
                this.taMalzeme.Fill(this.dsIzleme.Malzeme);
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Ekipman' table. You can move, or remove it, as needed.
                this.taEkipman.Fill(this.dsIzleme.Ekipman);
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Unite' table. You can move, or remove it, as needed.
                this.taUnite.Fill(this.dsIzleme.Unite);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void bsMalzeme_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dsIzleme.HasChanges())
            {
                degisimMalzeme = true;
            }
        }

        private void dgvMalzeme_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (degisimMalzeme)
            {
                try
                {
                    this.taMalzeme.Update(this.dsIzleme.Malzeme);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                degisimMalzeme = false;
            }
        }

        private void dgvMalzeme_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ResimGoster form = null;
            String resimAdi = null;
            String malzemeAdi = null;
            DataRow satir = null;

            try
            {
                int index = e.RowIndex;
                satir = dsIzleme.Malzeme.Rows[index];
                resimAdi = ResimAl(satir["YTNO"].ToString());
                malzemeAdi = MalzemeAdiAl(satir["YTNO"].ToString());

                if (resimAdi != null)
                {
                    try
                    {
                        form = new ResimGoster(resimAdi, malzemeAdi);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                this.Text = malzemeAdi + ", " + resimAdi;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.ToString());
            }
        }

        private String ResimAl(String yt)
        {
            foreach (DataRow satir in dsIzleme.CPS.Rows)
            {
                if (satir["YTNO"].ToString() == yt)
                {
                    return satir["RESIM"].ToString();
                }
            }
            return null;
        }

        private String MalzemeAdiAl(String yt)
        {
            foreach (DataRow satir in dsIzleme.CPS.Rows)
            {
                if (satir["YTNO"].ToString() == yt)
                {
                    return satir["MALZEMEADI"].ToString();
                }
            }
            return null;
        }

        private void bsUnite_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dsIzleme.HasChanges())
            {
                degisimUnite = true;
            }
        }

        private void bsEkipman_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dsIzleme.HasChanges())
            {
                degisimMalzeme = true;
            }
        }

        private void dgvUnite_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (degisimUnite)
            {
                try
                {
                    this.taUnite.Update(this.dsIzleme.Unite);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                degisimUnite = false;
            }
        }

        private void dgvEkipman_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (degisimEkipman)
            {
                try
                {
                    this.taEkipman.Update(this.dsIzleme.Ekipman);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                degisimEkipman = false;
            }
        }
    }
}