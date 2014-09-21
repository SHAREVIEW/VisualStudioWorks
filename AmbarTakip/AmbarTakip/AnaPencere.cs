using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmbarTakip
{
    public partial class AnaPencere : Form
    {
        public AnaPencere()
        {
            InitializeComponent();
        }

        private void AnaPencere_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dsAmbar.Malzeme' table. You can move, or remove it, as needed.
                this.malzemeTableAdapter.Fill(this.dsAmbar.Malzeme);
                // TODO: This line of code loads data into the 'dsAmbar.Ekipman' table. You can move, or remove it, as needed.
                this.ekipmanTableAdapter.Fill(this.dsAmbar.Ekipman);
                // TODO: This line of code loads data into the 'dsAmbar.Unite' table. You can move, or remove it, as needed.
                this.uniteTableAdapter.Fill(this.dsAmbar.Unite);
                // TODO: This line of code loads data into the 'dsAmbar.CPS' table. You can move, or remove it, as needed.
                this.cPSTableAdapter.Fill(this.dsAmbar.CPS);
            }
            catch (Exception)
            {
                MessageBox.Show(this, Sabitler.hataBaglanti, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            this.KeyPreview = true;
            Guncelle();
        }

        #region Form Gösterme Metodlarý
        private void MalzemeGirisGoster()
        {
            MalzemeGiris malzemeGiris = new MalzemeGiris();
            malzemeGiris.ShowDialog();
        }

        private void MalzemeYonetimGoster()
        {
            MalzemeYonetim malzemeCikis = new MalzemeYonetim();
            malzemeCikis.ShowDialog();
        }

        private void MalzemeAramaGoster()
        {
            MalzemeArama malzemeArama = new MalzemeArama();
            malzemeArama.ShowDialog();
        }

        private void MalzemeIzlemeGoster()
        {
            MalzemeIzleme malzemeGuncelleme = new MalzemeIzleme();
            malzemeGuncelleme.ShowDialog();
        }

        private void UniteEkipmanGoster()
        {
            UniteEkipman uniteEkipman = new UniteEkipman();
            uniteEkipman.ShowDialog();
        }

        private void CPSKayitGoster()
        {
            CPSKayit cpsKayit = new CPSKayit();
            cpsKayit.ShowDialog();
        } 
        #endregion

        private void AnaPencere_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                MalzemeGirisGoster();
            else if (e.KeyCode == Keys.F2)
                MalzemeYonetimGoster();
            else if (e.KeyCode == Keys.F3)
                MalzemeAramaGoster();
            else if (e.KeyCode == Keys.F4)
                MalzemeIzlemeGoster();
            else if (e.KeyCode == Keys.F5)
                UniteEkipmanGoster();
            else if (e.KeyCode == Keys.F6)
                CPSKayitGoster();
        }

        private void btnMalzemeGiris_Click(object sender, EventArgs e)
        {
            MalzemeGirisGoster();
        }

        private void btnMalzemeCikis_Click(object sender, EventArgs e)
        {
            MalzemeYonetimGoster();
        }

        private void btnMalzemeArama_Click(object sender, EventArgs e)
        {
            MalzemeAramaGoster();
        }

        private void btnMalzemeIzleme_Click(object sender, EventArgs e)
        {
            MalzemeIzlemeGoster();
        }

        private void btnCPSKayit_Click(object sender, EventArgs e)
        {
            CPSKayitGoster();
        }

        private void btnUniteEkipman_Click(object sender, EventArgs e)
        {
            UniteEkipmanGoster();
        }

        private void Guncelle()
        {
            lblBugun.Text = "Bugün " + DateTime.Now.ToShortDateString();
            lblCPS.Text = "CPS'de kayýtlý malzeme miktarý: " + CPSSayisi().ToString();
            lblUnite.Text = "Toplam ünite miktarý: " + UniteSayisi().ToString();
            lblEkipman.Text = "Toplam ekipman miktarý: " + EkipmanSayisi().ToString();
            lblMalzeme.Text = "Toplam malzeme miktarý: " + MalzemeSayisi().ToString();
        }

        private int CPSSayisi()
        {
            int i = 0;
            foreach (DataRow satir in dsAmbar.CPS.Rows)
            {
                i++;
            }
            return i;
        }

        private int UniteSayisi()
        {
            int i = 0;
            foreach (DataRow satir in dsAmbar.Unite.Rows)
            {
                i++;
            }
            return i;
        }

        private int EkipmanSayisi()
        {
            int i = 0;
            foreach (DataRow satir in dsAmbar.Ekipman.Rows)
            {
                i++;
            }
            return i;
        }

        private int MalzemeSayisi()
        {
            int i = 0;
            foreach (DataRow satir in dsAmbar.Malzeme.Rows)
            {
                i++;
            }
            return i;
        }

        private void mnuKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnaPencere_Activated(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void mnuHakkýnda_Click(object sender, EventArgs e)
        {
            Hakkýnda form = new Hakkýnda();
            form.ShowDialog();
        }
    }
}