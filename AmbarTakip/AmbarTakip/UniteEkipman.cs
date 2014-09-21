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
    public partial class UniteEkipman : Form
    {
        private String uniteAdi = null;
        private String ekipmanAdi = null;

        private int UniteID = 0;

        public UniteEkipman()
        {
            InitializeComponent();
        }

        private void UniteEkipman_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dsUniteEkipman.Ekipman' table. You can move, or remove it, as needed.
                this.taEkipman.Fill(this.dsUniteEkipman.Ekipman);
                // TODO: This line of code loads data into the 'ambarTakipDataSet1.Unite' table. You can move, or remove it, as needed.
                this.taUnite.Fill(this.dsUniteEkipman.Unite);
            }
            catch (Exception)
            {
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            UniteDoldur();
        }

        private void btnUniteEkle_Click(object sender, EventArgs e)
        {
            uniteAdi = txtUniteAdi.Text.Trim();

            if (uniteAdi.Length > 0)
            {
                if (UniteKontrol(uniteAdi))
                {
                    MessageBox.Show(this, Sabitler.hataUniteVar, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (UniteEkle() == false)
                {
                    MessageBox.Show(this, Sabitler.hataUniteEkle, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, Sabitler.hataUnite, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtUniteAdi.Clear();
            txtUniteAdi.Focus();
            UniteDoldur();
        }

        private void btnEkipmanEkle_Click(object sender, EventArgs e)
        {
            ekipmanAdi = txtEkipmanAdi.Text.Trim();

            if (ekipmanAdi.Length > 0 && UniteID > 0)
            {
                if (EkipmanKontrol(ekipmanAdi))
                {
                    MessageBox.Show(this, Sabitler.hataEkipmanVar, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (EkipmanEkle() == false)
                {
                    MessageBox.Show(this, Sabitler.hataEkipmanEkle, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, Sabitler.hataUniteEkipman, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtEkipmanAdi.Clear();
            txtEkipmanAdi.Focus();
        }

        private bool UniteKontrol(String ad)
        {
            foreach (DataRow satir in dsUniteEkipman.Unite.Rows)
            {
                if (satir["UNITE"].ToString() == ad)
                {
                    return true;
                }
            }
            return false;
        }

        private bool EkipmanKontrol(String ad)
        {
            foreach (DataRow satir in dsUniteEkipman.Ekipman.Rows)
            {
                if (satir["EKIPMAN"].ToString() == ad)
                {
                    return true;
                }
            }
            return false;
        }

        private bool UniteEkle()
        {
            try
            {
                dsUniteEkipman.Unite.Clear();
                taUnite.Insert(uniteAdi);
                taUnite.Fill(dsUniteEkipman.Unite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            try
            {
                taUnite.Update(dsUniteEkipman.Unite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        private bool EkipmanEkle()
        {
            try
            {
                dsUniteEkipman.Ekipman.Clear();
                taEkipman.Insert(UniteID, ekipmanAdi);
                taEkipman.Fill(dsUniteEkipman.Ekipman);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            try
            {
                taEkipman.Update(dsUniteEkipman.Ekipman);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        private void cmbUniteler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbUniteler.SelectedIndex;
            foreach (DataRow satir in dsUniteEkipman.Unite.Rows)
            {
                if (satir["UNITE"].ToString() == cmbUniteler.SelectedItem.ToString())
                {
                    UniteID = Convert.ToInt32(satir["ID"]); // Ekipman eklemek için gereken ünite deðerini al.
                }
            }
        }

        private void cmbUniteler_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UniteDoldur()
        {
            cmbUniteler.Items.Clear();

            try
            {
                foreach (DataRow satir in dsUniteEkipman.Unite.Rows)
                {
                    cmbUniteler.Items.Add(satir["UNITE"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void txtUniteAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnUniteEkle_Click(sender, e);
            }
        }

        private void txtEkipmanAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnEkipmanEkle_Click(sender, e);
            }
        }

        private void UniteEkipman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}