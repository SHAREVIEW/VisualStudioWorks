using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmbarTakip
{
    public partial class ResimGoster : Form
    {
        private String resimAdi;
        private String malzemeAdi;
        private Image resimDosyasi = null;

        public ResimGoster()
        {
            InitializeComponent();
        }

        public ResimGoster(String resim, String malzeme)
        {
            InitializeComponent();

            this.resimAdi = resim;
            this.malzemeAdi = malzeme;
        }

        private void ResimGoster_Load(object sender, EventArgs e)
        {
            picResim.SizeMode = PictureBoxSizeMode.AutoSize;

            try
            {
                resimDosyasi = Image.FromFile(Sabitler.resimKlasoru + resimAdi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            this.Text = malzemeAdi;
            picResim.Image = resimDosyasi;
        }
    }
}