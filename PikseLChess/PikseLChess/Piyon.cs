using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PikseLChess
{
    class Piyon : Tas
    {
        public Piyon(Point p, Taslar tas, Renkler renk) : base(p, tas, renk)
        {
        }

        private int Yon;

        public override void HamleHesapla(Tas[,] t)
        {
            bool ilkHamle = false;

            if (Renk == Renkler.Beyaz)
                Yon = -1;
            else
                Yon = 1;

            // piyonlar baþlangýç durumunda ise...
            if ((Yer.Y == 6 && Renk == Renkler.Beyaz) || (Yer.Y == 1 && Renk == Renkler.Siyah))
                ilkHamle = true;

            // Piyonun önünde boþ alan varsa...
            if (t[Yer.X, Yer.Y + Yon] == null)
            {
                Hamleler.Add(Yer.X); Hamleler.Add(Yer.Y + Yon);
            }

            // Piyonun ilk hamlesi ise ve önündeki iki alanda boþ ise...
            if (ilkHamle && t[Yer.X, Yer.Y + Yon] == null && t[Yer.X, Yer.Y + (2 * Yon)] == null)
            {
                Hamleler.Add(Yer.X); Hamleler.Add(Yer.Y + 2 * Yon);
            }

            // En saðdaki piyona týklandýðýnda saða hamle yolu göstermesini engelle...
            if (Yer.X + 1 < 8)
            {
                DigerTasaHamle(t, Yer.X + 1);
            }

            // En soldaki piyona týklandýðýnda sola hamle yolu gösterme
            if (Yer.X - 1 >= 0)
            {
                DigerTasaHamle(t, Yer.X - 1);
            }
        }

        private void DigerTasaHamle(Tas[,] t, int x)
        {
            if (Renk == Renkler.Siyah)
            {
                if (t[x, Yer.Y + Yon] != null && t[x, Yer.Y + Yon].Renk == Renkler.Beyaz)
                {
                    Hamleler.Add(x); Hamleler.Add(Yer.Y + Yon);
                }
            }
            if (Renk == Renkler.Beyaz)
            {
                if (t[x, Yer.Y + Yon] != null && t[x, Yer.Y + Yon].Renk == Renkler.Siyah)
                {
                    if (t[x, Yer.Y + Yon].Renk == Renkler.Siyah)
                    {
                        Hamleler.Add(x); Hamleler.Add(Yer.Y + Yon);
                    }
                }
            }
        }


    }
}
