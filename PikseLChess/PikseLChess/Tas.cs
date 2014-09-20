using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Threading;

namespace PikseLChess
{
    public enum Taslar { Piyon, Kale, At, Fil, Vezir, Sah };
    public enum Renkler { Siyah, Beyaz };

    class Tas
    {
        public static string oyunKlasoru;

        public Point Yer;
        public Taslar tasTipi;
        public Renkler Renk;
        public ArrayList Hamleler = new ArrayList();

        private Image Resim;
        private Image acikZemin = Image.FromFile(oyunKlasoru + "\\images\\acik.jpg");
        private Image koyuZemin = Image.FromFile(oyunKlasoru + "\\images\\koyu.jpg");
        private Image secim = Image.FromFile(oyunKlasoru + "\\images\\secim.gif");
        private Image yolYesil = Image.FromFile(oyunKlasoru + "\\images\\yol_yesil.gif");
        private Image yolKirmizi = Image.FromFile(oyunKlasoru + "\\images\\yol_kirmizi.gif");
        private int kareEnBoy = 50;
        private int resimEnBoy = 32;

        public virtual void HamleHesapla(Tas[,] taslar)
        {
            /* Bu fonksiyonu Tas sýnýfýný miras alan sýnýflarda tekrar tanýmlayýp(override) içini her taþ için 
            ayrý ayrý dolduracaðýz. Böylece tas nesnesi üzerinden tüm taþlarýn özelliklerinin yaný sýra
            bu metodada da "." notasyonu ile eriþmiþ olacaðýz. Kýsaca Polymorhism(çok biçimlilik) iþlemini gerçekleþtireceðiz.
            Yani her taþ için ayrý ayrý nesneler oluþturmak yerine Tas sýnýfýndan oluþturacaðýmýz nesne ile tüm sýnýflara
            eriþim saðlayacaðýz. */
        }

        public Tas(Point p, Taslar tip, Renkler renk)
        {
            Yer = p;
            tasTipi = tip;
            Renk = renk;

            try
            {
                if (Renk == Renkler.Beyaz)
                {
                    if (tasTipi == Taslar.Piyon)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\bPiyon.gif");

                    if (tasTipi == Taslar.Kale)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\bKale.gif");

                    if (tasTipi == Taslar.At)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\bAt.gif");

                    if (tasTipi == Taslar.Fil)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\bFil.gif");

                    if (tasTipi == Taslar.Vezir)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\bVezir.gif");

                    if (tasTipi == Taslar.Sah)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\bSah.gif");
                }
                if (Renk == Renkler.Siyah)
                {
                    if (tasTipi == Taslar.Piyon)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\sPiyon.gif");

                    if (tasTipi == Taslar.Kale)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\sKale.gif");

                    if (tasTipi == Taslar.At)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\sAt.gif");

                    if (tasTipi == Taslar.Fil)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\sFil.gif");

                    if (tasTipi == Taslar.Vezir)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\sVezir.gif");

                    if (tasTipi == Taslar.Sah)
                        Resim = Image.FromFile(oyunKlasoru + "\\images\\sSah.gif");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }
        }

        public void Goster(Graphics g)
        {
            Rectangle Kare = new Rectangle(Yer.X * kareEnBoy + 9, Yer.Y * kareEnBoy + 9, resimEnBoy, resimEnBoy);
            g.DrawImage(Resim, Kare);
        }

        public void Gizle(Graphics g)
        {
            Rectangle Kare = new Rectangle(Yer.X * kareEnBoy, Yer.Y * kareEnBoy, kareEnBoy, kareEnBoy);
            Image zemin = (Yer.X + Yer.Y) % 2 == 0 ? acikZemin : koyuZemin;
            g.DrawImage(zemin, Kare);
        }

        public void SecimGoster(Graphics g)
        {
            Rectangle Kare = new Rectangle(Yer.X * kareEnBoy, Yer.Y * kareEnBoy, kareEnBoy, kareEnBoy);
            g.DrawImage(secim, Kare);
        }

        public void YolGoster(Tas[,] taslar, Graphics g)
        {                      
            int i;
            SolidBrush fircaYesil = new SolidBrush(Color.FromArgb(127, Color.Green));
            SolidBrush fircaKirmizi = new SolidBrush(Color.FromArgb(127, Color.Red));

            for (i = 0; i < Hamleler.Count; i += 2)
            {
                Rectangle Kare = new Rectangle((int)Hamleler[i] * kareEnBoy, (int)Hamleler[i + 1] * kareEnBoy, kareEnBoy, kareEnBoy);

                if (taslar[(int)Hamleler[i], (int)Hamleler[i + 1]] == null)
                {
                    g.DrawImage(yolYesil, Kare);
                    //g.FillRectangle(fircaYesil, Kare);
                }
                else
                {
                    g.DrawImage(yolKirmizi, Kare);
                    //g.FillRectangle(fircaKirmizi, Kare);
                }
            }
        }

        public void YolGizle(Graphics g)
        {
            int i;

            for (i = 0; i < Hamleler.Count; i += 2)
            {
                Rectangle Kare = new Rectangle((int)Hamleler[i] * kareEnBoy, (int)Hamleler[i + 1] * kareEnBoy, kareEnBoy, kareEnBoy);
                Image zemin = ((int)Hamleler[i] + (int)Hamleler[i + 1]) % 2 == 0 ? acikZemin : koyuZemin;
                g.DrawImage(zemin, Kare);
            }
        }

    }
}
