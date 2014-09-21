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
    public partial class MalzemeArama : Form
    {
        public MalzemeArama()
        {
            InitializeComponent();
        }

        private void txtYTNO_TextChanged(object sender, EventArgs e)
        {
            String sorgu = txtYTNO.Text.Trim();

            try
            {
                bsArama.Filter = "YTNO like '" + sorgu + "%'";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void MalzemeArama_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.TumOzellikler' table. You can move, or remove it, as needed.
                this.taArama.Fill(this.dsArama.TumOzellikler);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dgvArama_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ResimGoster form = null;
            String resimAdi = null;
            String malzemeAdi = null;
            DataRow satir = null;

            try
            {
                int index = e.RowIndex;
                satir = dsArama.TumOzellikler.Rows[index];
                resimAdi = satir["RESIM"].ToString();
                malzemeAdi = satir["MALZEMEADI"].ToString();
                if (resimAdi != null)
                {
                    try
                    {
                        form = new ResimGoster(resimAdi, malzemeAdi);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                //this.Text = malzemeAdi + ", " + resimAdi;
            }
            catch (Exception)
            {
                
            }
        }

        private void txtMalzemeAdi_TextChanged(object sender, EventArgs e)
        {
            String sorgu = txtMalzemeAdi.Text.Trim();

            try
            {
                bsArama.Filter = "MALZEMEADI like '" + sorgu + "%'";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void txtSpect_TextChanged(object sender, EventArgs e)
        {
            String sorgu = txtSpect.Text.Trim();

            try
            {
                bsArama.Filter = "SPECT like '" + sorgu + "%'";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}