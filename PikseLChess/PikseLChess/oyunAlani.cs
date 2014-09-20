using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PikseLChess
{
    class oyunAlani
    {
        public static void TaslarOlustur(Tas[,] sTaslari)
        {
            int i;
            sTaslari[0, 0] = new Kale(new Point(0, 0), Taslar.Kale, Renkler.Siyah);
            sTaslari[1, 0] = new At(new Point(1, 0), Taslar.At, Renkler.Siyah);
            sTaslari[2, 0] = new Fil(new Point(2, 0), Taslar.Fil, Renkler.Siyah);
            sTaslari[3, 0] = new Vezir(new Point(3, 0), Taslar.Vezir, Renkler.Siyah);
            sTaslari[4, 0] = new Sah(new Point(4, 0), Taslar.Sah, Renkler.Siyah);
            sTaslari[5, 0] = new Fil(new Point(5, 0), Taslar.Fil, Renkler.Siyah);
            sTaslari[6, 0] = new At(new Point(6, 0), Taslar.At, Renkler.Siyah);
            sTaslari[7, 0] = new Kale(new Point(7, 0), Taslar.Kale, Renkler.Siyah);

            for (i = 0; i < 8; i++)
            {
                sTaslari[i, 1] = new Piyon(new Point(i, 1), Taslar.Piyon, Renkler.Siyah);
                sTaslari[i, 6] = new Piyon(new Point(i, 6), Taslar.Piyon, Renkler.Beyaz);
            }

            sTaslari[0, 7] = new Kale(new Point(0, 7), Taslar.Kale, Renkler.Beyaz);
            sTaslari[1, 7] = new At(new Point(1, 7), Taslar.At, Renkler.Beyaz);
            sTaslari[2, 7] = new Fil(new Point(2, 7), Taslar.Fil, Renkler.Beyaz);
            sTaslari[3, 7] = new Vezir(new Point(3, 7), Taslar.Vezir, Renkler.Beyaz);
            sTaslari[4, 7] = new Sah(new Point(4, 7), Taslar.Sah, Renkler.Beyaz);
            sTaslari[5, 7] = new Fil(new Point(5, 7), Taslar.Fil, Renkler.Beyaz);
            sTaslari[6, 7] = new At(new Point(6, 7), Taslar.At, Renkler.Beyaz);
            sTaslari[7, 7] = new Kale(new Point(7, 7), Taslar.Kale, Renkler.Beyaz);
        }

        public static void TaslarGoster(Tas[,] sTaslari, Graphics g)
        {
            int i, j;

            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (sTaslari[j, i] != null)
                        sTaslari[j, i].Goster(g);
                }
        }

        public static void TaslarGizle(Graphics g)
        {
            int i, j;
            int kareEnBoy = 50;
            Image acikZemin = Image.FromFile(Tas.oyunKlasoru + "\\images\\acik.jpg");
            Image koyuZemin = Image.FromFile(Tas.oyunKlasoru + "\\images\\koyu.jpg");

            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    Rectangle Kare = new Rectangle(i * kareEnBoy, j * kareEnBoy, kareEnBoy, kareEnBoy);
                    Image zemin = (i + j) % 2 == 0 ? acikZemin : koyuZemin;
                    g.DrawImage(zemin, Kare);
                }
        }

        public static void TasOlustur(Tas[,] sTaslari, int x, int y, Renkler renk, Taslar tip)
        {
            switch (tip)
            {
                case Taslar.Piyon :
                    sTaslari[x, y] = new Piyon(new Point(x, y), Taslar.Piyon, renk);
                    break;
                case Taslar.Kale :
                    sTaslari[x, y] = new Kale(new Point(x, y), Taslar.Kale, renk);
                    break;
                case Taslar.At :
                    sTaslari[x, y] = new At(new Point(x, y), Taslar.At, renk);
                    break;
                case Taslar.Fil :
                    sTaslari[x, y] = new Fil(new Point(x, y), Taslar.Fil, renk);
                    break;
                case Taslar.Sah :
                    sTaslari[x, y] = new Sah(new Point(x, y), Taslar.Sah, renk);
                    break;
                case Taslar.Vezir :
                    sTaslari[x, y] = new Vezir(new Point(x, y), Taslar.Vezir, renk);
                    break;
            } 
        }
    }
}
