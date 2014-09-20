using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PikseLChess
{
    class Kale : Tas
    {
        public Kale(Point p, Taslar tas, Renkler renk)
            : base(p, tas, renk)
        {
        }

        public override void HamleHesapla(Tas[,] t)
        {
            int i;

            if (Yer.X > 0) // Sola
            {
                for (i = Yer.X - 1; i >= 0; i--)
                {
                    if (t[i, Yer.Y] == null)
                    {
                        Hamleler.Add(i); Hamleler.Add(Yer.Y);
                    }
                    else
                    {
                        DigerTasaHamle(t, i, Yer.Y);
                        break;
                    }
                }
            }

            if (Yer.X < 7) // Saða
            {
                for (i = Yer.X + 1; i < 8; i++)
                {
                    if (t[i, Yer.Y] == null)
                    {
                        Hamleler.Add(i); Hamleler.Add(Yer.Y);
                    }
                    else
                    {
                        DigerTasaHamle(t, i, Yer.Y);
                        break;
                    }
                }
            }

            if (Yer.Y < 7) // Aþaðý
            {
                for (i = Yer.Y + 1; i < 8; i++)
                {
                    if (t[Yer.X, i] == null)
                    {
                        Hamleler.Add(Yer.X); Hamleler.Add(i);
                    }
                    else
                    {
                        DigerTasaHamle(t, Yer.X, i);
                        break;
                    }
                }
            }

            if (Yer.Y > 0)// Yukarý
            {
                for (i = Yer.Y - 1; i >= 0; i--)
                {
                    if (t[Yer.X, i] == null)
                    {
                        Hamleler.Add(Yer.X); Hamleler.Add(i);
                    }
                    else
                    {
                        DigerTasaHamle(t, Yer.X, i);
                        break;
                    }
                }
            }
        }

        private void DigerTasaHamle(Tas[,] t, int x, int y)
        {
            if (Renk == Renkler.Siyah && t[x, y].Renk == Renkler.Beyaz) // siyah kale beyazý yesin
            {
                Hamleler.Add(x); Hamleler.Add(y);
            }

            if (Renk == Renkler.Beyaz && t[x, y].Renk == Renkler.Siyah) // beyaz kale siyahý yesin
            {
                Hamleler.Add(x); Hamleler.Add(y);
            }
        }
    }
}
