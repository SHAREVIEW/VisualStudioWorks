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
    public partial class MalzemeYonetim : Form
    {
        private bool degisimMalzeme = false;
        private List<int> Uniteler = new List<int>();
        private List<int> Ekipmanlar = new List<int>();

        public MalzemeYonetim()
        {
            InitializeComponent();
        }

        private void MalzemeArama_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Ekipman' table. You can move, or remove it, as needed.
                this.taEkipman.Fill(this.dsMalzeme.Ekipman);
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Unite' table. You can move, or remove it, as needed.
                this.taUnite.Fill(this.dsMalzeme.Unite);
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Malzeme' table. You can move, or remove it, as needed.
                this.taMalzeme.Fill(this.dsMalzeme.Malzeme);
                // TODO: This line of code loads data into the 'dsMalzeme.CPS' table. You can move, or remove it, as needed.
                this.taCPS.Fill(this.dsMalzeme.CPS);

                cmbUniteler.Items.Add("Hepsi");
                cmbEkipmanlar.Items.Add("Hepsi");
                Uniteler.Add(0); // koleksiyonlarýn ilk elemaný hepsi...
                Ekipmanlar.Add(0);

                UniteDoldur();
                EkipmanDoldur();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void UniteDoldur()
        {
            try
            {
                foreach (DataRow satir in dsMalzeme.Unite.Rows)
                {
                    cmbUniteler.Items.Add(satir["UNITE"]);
                    Uniteler.Add(Convert.ToInt32(satir["ID"]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void EkipmanDoldur()
        {
            try
            {
                foreach (DataRow satir in dsMalzeme.Ekipman.Rows)
                {
                    cmbEkipmanlar.Items.Add(satir["EKIPMAN"]);
                    Ekipmanlar.Add(Convert.ToInt32(satir["ID"]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void txtYTNO_TextChanged(object sender, EventArgs e)
        {
            String sorgu = txtYTNO.Text.Trim();

            try
            {
                bsMalzeme.Filter = "YTNO like '" + sorgu + "%'";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void cmbUniteler_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvArama_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow satir = null;
            try
            {
                int index = e.RowIndex;
                satir = dsMalzeme.Malzeme.Rows[index];
                Resim resim = new Resim(satir, dsMalzeme);
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.ToString());
            }
        }

        private void cmbUniteler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbUniteler.SelectedIndex;
            int sorgu = Uniteler[i];

            try
            {
                if (i == 0)
                    bsMalzeme.Filter = "";
                else
                    bsMalzeme.Filter = "UNITE=" + sorgu + "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void cmbEkipmanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbEkipmanlar.SelectedIndex;
            int sorgu = Ekipmanlar[i];

            try
            {
                if (i == 0)
                    bsMalzeme.Filter = "";
                else
                    bsMalzeme.Filter = "EKIPMAN=" + sorgu + "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void bsMalzeme_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dsMalzeme.HasChanges())
            {
                degisimMalzeme = true;
            }
        }

        private void dgvYonetim_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (degisimMalzeme)
            {
                try
                {
                    this.taMalzeme.Update(this.dsMalzeme.Malzeme);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                degisimMalzeme = false;
            }
        }
    }
}