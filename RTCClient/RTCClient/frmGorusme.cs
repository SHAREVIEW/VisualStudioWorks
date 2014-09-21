using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RTCCORELib;

namespace RTCClient
{
    public partial class frmGorusme : Form
    {
        #region Genel Deðiþkenler
        private IRTCSession imOturumu = null;
        private IRTCSession mediaOturumu = null;

        private Motor motor;
        private string uri;
        private string kisiAdi;
        private string mesaj;

        private Font yazilarFont = new Font("Verdana", 9, FontStyle.Regular);
        private Color yazilarFontColor = Color.Black;
        private int yazilarKertmeDegeri = 10;

        private Font adtarihFont = new Font("Verdana", 9, FontStyle.Regular);
        private Color adtarihFontColor = Color.Gray;
        private int adtarihKertmeDegeri = 3;

        private ArrayList Mesajlar;
        LogRecord kayit;

        private bool videoGorusmesi = false; 
        #endregion

        #region Özellikler
        public string URI
        {
            get { return uri; }
        }

        public string Mesaj
        {
            get { return mesaj; }
            set { mesaj = value; }
        }

        public bool VideoGorusmesi
        {
            get { return videoGorusmesi; }
            set { videoGorusmesi = value; }
        }

        public IntPtr HandlePicGiden
        {
            get { return this.picGiden.Handle; }
        }

        public IntPtr HandlePicGelen
        {
            get { return this.picGelen.Handle; }
        }

        public IRTCSession MediaOturumu
        {
            get { return mediaOturumu; }
            set { mediaOturumu = value; }
        }

        public IRTCSession IMOturumu
        {
            get { return imOturumu; }
            set { imOturumu = value; }
        }

        public int WidthPicGelen
        {
            get { return this.picGelen.Width; }
        }

        public int WidthPicGiden
        {
            get { return this.picGiden.Width; }
        }

        public int HeightPicGelen
        {
            get { return this.picGelen.Height; }
        }

        public int HeightPicGiden
        {
            get { return this.picGiden.Height; }
        } 
        #endregion

        public frmGorusme()
        {
        }

        public frmGorusme(Motor motor, string uri, string ad)
        {
            InitializeComponent();

            this.kisiAdi = ad;
            this.uri = uri;
            this.motor = motor;

            this.Text = ad + " - Görüþme";

            Mesajlar = new ArrayList();
        }

        #region Mesaj Gönderme
        private void cmdGonder_Click(object sender, EventArgs e)
        {
            if (txtMesaj.Text != "")
            {
                this.Mesaj = txtMesaj.Text;
                MesajGoster(txtMesaj.Text, motor.istemciAdi); // Kendi mesajýmýzý gösteriyoruz...

                motor.MesajGonder(uri, kisiAdi, txtMesaj.Text);

                txtMesaj.Clear();
            }
        } 
        #endregion

        #region Mesaj/Uyarý Gösterme Metodlarý
        public void MesajGoster(string msj, string ad)
        {
            StringBuilder sbAdTarih = new StringBuilder();

            MesajLogla(msj, ad);

            if (txtMesajlar.Text != "") // Ýlk mesaj geldiðinde bir alt satýra(caret için) geçilmesin, diðer mesajlarda geçilsin...
            {
                txtMesajlar.AppendText("\r\n");
            }
            
            sbAdTarih.Append(ad).Append(" [").Append(DateTime.Now.ToShortTimeString()).Append("] : ");
            Yazdir(sbAdTarih.ToString(), adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "\r\n");

            Regex rg = new Regex("\\n");
            String[] Satirlar = rg.Split(msj);
            int i = 0;

            for (i = 0; i < Satirlar.Length - 1; i++)
            {
                Yazdir(Satirlar[i],yazilarFontColor, yazilarFont, yazilarKertmeDegeri, "\n");
            }

            Yazdir(Satirlar[i],yazilarFontColor, yazilarFont, yazilarKertmeDegeri, "");

            txtMesajlar.ScrollToCaret(); // Scroolbar aþaðý insin. caret = cursor
        }

        public void UyariGoster(string msj)
        {
            if (txtMesajlar.Text != "")
            {
                txtMesajlar.AppendText("\r\n");
            }

            Regex rg = new Regex("#");
            String[] Satirlar = rg.Split(msj);

            if (Satirlar.Length > 1) // kabul et, reddet var.
            {
                Yazdir("Uyarý: " + Satirlar[0], adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "");
                txtMesajlar.InsertLink(Satirlar[1]); // kabul et
                Yazdir(Satirlar[2], adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "");
                txtMesajlar.InsertLink(Satirlar[3]); // reddet
                Yazdir(Satirlar[4], adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "");
            }
            else
            {
                Yazdir("Uyarý: " + msj, adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "");
            }

            txtMesajlar.ScrollToCaret();

            MesajLogla(msj, "");
        }

        private void Yazdir(String yazi, Color renk, Font font, int kertmeDegeri, string yeniSatir)
        {
            txtMesajlar.SelectionColor = renk;
            txtMesajlar.SelectionFont = font;
            txtMesajlar.SelectionIndent = kertmeDegeri;
            txtMesajlar.SelectedText = yazi + yeniSatir;
        }

        private void txtMesajlar_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            int yerKabul, yerReddet = 0;
            yerKabul = txtMesajlar.Find(Sabitler.VIDEOSES_KABULET, 0, RichTextBoxFinds.Reverse);
            yerReddet = txtMesajlar.Find(Sabitler.VIDEOSES_REDDET, 0, RichTextBoxFinds.Reverse);

            txtMesajlar.SelectionStart = yerKabul;
            txtMesajlar.SelectionLength = Sabitler.VIDEOSES_KABULET.Length;
            txtMesajlar.SelectedText = Sabitler.VIDEOSES_KABULET;

            txtMesajlar.SelectionStart = yerReddet;
            txtMesajlar.SelectionLength = Sabitler.VIDEOSES_REDDET.Length;
            txtMesajlar.SelectedText = Sabitler.VIDEOSES_REDDET;

            if (e.LinkText == Sabitler.VIDEOSES_KABULET)
            {
                motor.MediaOturumuBaslat(this.MediaOturumu, this.uri);
            }
            else if (e.LinkText == Sabitler.VIDEOSES_REDDET)
            {
                motor.MediaOturumuKapat(this.uri, this.MediaOturumu);
            }
        }
        #endregion

        #region Form Olaylarý
        private void frmGorusme_FormClosing(object sender, FormClosingEventArgs e)
        {
            OturumlariSonlandir();
            Log.MesajLogla(this.uri, Mesajlar);
        }

        private void frmGorusme_Activated(object sender, EventArgs e)
        {
            //FlashWindow.FlashWindowEx(this.Handle, FlashWindow.FLASHW_STOP);
        }
        #endregion

        #region Yardýmcý Metodlar
        public void MesajLogla(string msj, string ad)
        {
            string kimden, kime;
            if (ad == motor.istemciAdi)
            {
                kimden = motor.istemciAdi;
                kime = this.kisiAdi;
            }
            else if (ad == this.kisiAdi)
            {
                kimden = this.kisiAdi;
                kime = motor.istemciAdi;
            }
            else
            {
                kimden = "";
                kime = "";
            }
            kayit = new LogRecord(kimden, kime, msj);
            Mesajlar.Add(kayit);
        }

        private void OturumlariSonlandir()
        {
            if (imOturumu != null)
            {
                motor.IMOturumuKapat(this.uri, this.imOturumu);
            }

            if (mediaOturumu != null)
            {
                motor.MediaOturumuKapat(this.uri, this.mediaOturumu);
            }

            motor.GorusmePenceresiSil(uri);
        } 
        #endregion

        #region Menü Olaylarý
        private void mnuVideo_Click(object sender, EventArgs e)
        {
            if (videoGorusmesi)
            {
                motor.MediaOturumuKapat(this.uri, mediaOturumu);
            }
            else
            {
                motor.MediaOturumuYarat(uri, kisiAdi);
            }
        }

        public void MediaGorusmesiAyarla()
        {
            if (videoGorusmesi)
            {
                videoGorusmesi = false;
                mnuVideo.Text = "Video Görüþmesini Baþlat";
            }
            else
            {
                videoGorusmesi = true;
                mnuVideo.Text = "Video Görüþmesini Bitir";
            }
        }

        private void mnuAyar_Click(object sender, EventArgs e)
        {
            motor.AyarSihirbaziGoster(uri);
        }

        private void mnuCikis_Click(object sender, EventArgs e)
        {
            OturumlariSonlandir();
            Log.MesajLogla(this.uri, Mesajlar);
            this.Close();
        }
        #endregion

        #region Mesaj Yazma Olaylarý
        // Keydown olayý Keypress olayýndan önce tetiklenir...
        private void txtMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true)
            {
                if (e.KeyCode == Keys.Return)
                {
                    txtMesaj.AppendText("\r\n");
                }
            }
            else if (e.KeyCode == Keys.Return)
            {
                cmdGonder_Click(sender, e);
            }
        }
        // Enter tuþunu iptal etmez isek alt satýra geçildikten sonra mesaj gönderilir.
        private void txtMesaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                e.Handled = true;
        } 
        #endregion

        #region Splitter olaylarý
        private void splitMesajlar_SplitterMoving(object sender, SplitterEventArgs e)
        {
            if (e.Y <= pnlMesajlar.MinimumSize.Height)
                e.SplitY = pnlMesajlar.MinimumSize.Height;

            if (e.Y + splitMesajlar.Height >= pnlMesajGenel.Bottom - pnlMesajGenel.MinimumSize.Height)
                e.SplitY = pnlMesajGenel.Bottom - pnlMesajGenel.MinimumSize.Height - splitMesajlar.Height;
        } 
        #endregion
    }
}