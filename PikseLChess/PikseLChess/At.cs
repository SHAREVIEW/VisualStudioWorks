using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PikseLChess
{
    class At : Tas
    {
        public At(Point p, Taslar tas, Renkler renk)
            : base(p, tas, renk)
        {
        }

        public override void HamleHesapla(Tas[,] t)
        {
            if (Yer.X + 2 <= 7) // X'i kontrol ediyoruz
            {
                LKontrol(t, Yer.X + 2, 1); // Y yi de kontrol ediyoruz...
            }

            if (Yer.X + 1 <= 7)
            {
                LKontrol(t, Yer.X + 1, 2);
            }

            if (Yer.X - 2 >=0)
            {
                LKontrol(t, Yer.X - 2, 1);
            }

            if (Yer.X - 1 >= 0)
            {
                LKontrol(t, Yer.X - 1, 2);
            }
        }

        private void LKontrol(Tas[,] t,int x, int fark)
        {
            if (Yer.Y + fark <= 7)
            {
                if (t[x, Yer.Y + fark] == null)
                {
                    Hamleler.Add(x); Hamleler.Add(Yer.Y + fark);
                }
                else
                {
                    DigerTasaHamle(t, x, Yer.Y + fark);
                }
            }

            if (Yer.Y - fark >= 0)
            {
                if (t[x, Yer.Y - fark] == null)
                {
                    Hamleler.Add(x); Hamleler.Add(Yer.Y - fark);
                }
                else
                {
                    DigerTasaHamle(t,x, Yer.Y - fark);
                }
            }
        }

        private void DigerTasaHamle(Tas[,] t,int x,int y)
        {
            if (Renk == Renkler.Siyah && t[x, y].Renk == Renkler.Beyaz)
            {
                Hamleler.Add(x); Hamleler.Add(y);
            }

            if (Renk == Renkler.Beyaz && t[x, y].Renk == Renkler.Siyah)
            {
                Hamleler.Add(x); Hamleler.Add(y);
            }
        }
    }
}
