using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PikseLChess
{
    class Fil : Tas
    {
        public Fil(Point p, Taslar tas, Renkler renk)
            : base(p, tas, renk)
        {
        }

        public override void HamleHesapla(Tas[,] t)
        {
            int i;

            if(Yer.X < 7 && Yer.Y < 7) // Sa� alt �apraz
            {
                for (i = Yer.X + 1; i < 8 && (Yer.Y + i - Yer.X) < 8; i++) // Yolu kontrol et
                {
                    if (t[i, Yer.Y + i - Yer.X] == null)
                    {
                        Hamleler.Add(i); Hamleler.Add(Yer.Y + i - Yer.X);
                    }
                    else
                    {
                        DigerTasaHamle(t, i, Yer.Y + i - Yer.X);
                        break;
                    }
                }
            }

            if (Yer.X < 7 && Yer.Y > 0) // Sa� �st �apraza oynans�n.. 
            {
                for (i = Yer.X + 1; i < 8 && (Yer.Y + Yer.X - i) >= 0 ; i++) // Yolu kontrol et
                {
                    if (t[i, Yer.Y + Yer.X - i] == null)
                    {
                        Hamleler.Add(i); Hamleler.Add(Yer.Y + Yer.X - i);
                    }
                    else
                    {
                        DigerTasaHamle(t, i, Yer.Y + Yer.X - i);
                        break;
                    }
                }
            }

            if (Yer.X > 0 && Yer.Y < 7) // Sol alt �apraza oynans�n..
            {
                for (i = Yer.X - 1; i >= 0 && (Yer.Y + Yer.X - i) < 8; i--) // Yolu kontrol et
                {
                    if (t[i, Yer.Y + Yer.X - i] == null)
                    {
                        Hamleler.Add(i); Hamleler.Add(Yer.Y + Yer.X - i);
                    }
                    else
                    {
                        DigerTasaHamle(t, i, Yer.Y + Yer.X - i);
                        break;
                    }
                }
            }

            if (Yer.X > 0 && Yer.Y > 0) // Sol �st �apraza oynans�n..
            {
                for (i = Yer.X - 1; i >= 0 && (Yer.Y + i - Yer.X) >= 0; i--) // Yolu kontrol et
                {
                    if (t[i, Yer.Y + i - Yer.X] == null)
                    {
                        Hamleler.Add(i); Hamleler.Add(Yer.Y + i - Yer.X);
                    }
                    else
                    {
                        DigerTasaHamle(t, i, Yer.Y + i - Yer.X);
                        break;
                    }
                }
            }
        }

        private void DigerTasaHamle(Tas[,] t, int x, int y)
        {
            if (Renk == Renkler.Siyah && t[x, y].Renk == Renkler.Beyaz) // siyah fil beyaz� yesin
            {
                Hamleler.Add(x); Hamleler.Add(y);
            }

            if (Renk == Renkler.Beyaz && t[x, y].Renk == Renkler.Siyah) // beyaz fil siyah� yesin
            {
                Hamleler.Add(x); Hamleler.Add(y);
            }
        }
    }
}
