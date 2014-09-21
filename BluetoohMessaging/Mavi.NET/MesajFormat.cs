using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace BTChat
{
    class MesajFormat
    {
        private Font yazilarFont = new Font("Verdana", 9, FontStyle.Regular);
        private Color yazilarFontColor = Color.Black;
        private int yazilarKertmeDegeri = 10;

        private Font adtarihFont = new Font("Verdana", 9, FontStyle.Regular);
        private Color adtarihFontColor = Color.Gray;
        private int adtarihKertmeDegeri = 3;

        #region Mesaj/Uyar� G�sterme Metodlar�
        public void MesajGoster(string msj, string ad, RichTextBox txtMesajlar)
        {
            StringBuilder sbAdTarih = new StringBuilder();

            if (txtMesajlar.Text != "") // �lk mesaj geldi�inde bir alt sat�ra(caret i�in) ge�ilmesin, di�er mesajlarda ge�ilsin...
            {
                txtMesajlar.AppendText("\r\n");
            }

            sbAdTarih.Append(ad).Append(" [").Append(DateTime.Now.ToShortTimeString()).Append("] : ");
            Yazdir(sbAdTarih.ToString(), adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "\r\n", txtMesajlar);
            Yazdir(msj, yazilarFontColor, yazilarFont, yazilarKertmeDegeri, "",txtMesajlar);

            txtMesajlar.ScrollToCaret(); // Scroolbar a�a�� insin. caret = cursor
        }

        public void UyariGoster(string msj, RichTextBox txtMesajlar)
        {
            if (txtMesajlar.Text != "")
            {
                txtMesajlar.AppendText("\r\n");
            }

            Yazdir("Bilgi: " + msj, adtarihFontColor, adtarihFont, adtarihKertmeDegeri, "", txtMesajlar);
            txtMesajlar.ScrollToCaret();
        }

        private void Yazdir(String yazi, Color renk, Font font, int kertmeDegeri, string yeniSatir, RichTextBox txtMesajlar)
        {
            txtMesajlar.SelectionColor = renk;
            txtMesajlar.SelectionFont = font;
            txtMesajlar.SelectionIndent = kertmeDegeri;
            txtMesajlar.SelectedText = yazi + yeniSatir;
        }
        #endregion

    }
}
