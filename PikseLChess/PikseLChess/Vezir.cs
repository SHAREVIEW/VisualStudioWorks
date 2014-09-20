using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PikseLChess
{
    class Vezir : Tas
    {
        public Vezir(Point p, Taslar tas, Renkler renk) : base(p, tas, renk)
        {
        }

        public override void HamleHesapla(Tas[,] t)
        {
            int i;

            // Vezirin bulunduðu yerde kale ve fil oluþturup hamleleri hesaplýyoruz
            Kale tasKale = new Kale(new Point(Yer.X, Yer.Y), Taslar.Kale, Renk); 
            Fil tasFil = new Fil(new Point(Yer.X,Yer.Y),Taslar.Fil, Renk);

            tasKale.HamleHesapla(t);
            tasFil.HamleHesapla(t);

            for (i = 0; i < tasFil.Hamleler.Count; i+=2)
            {
                Hamleler.Add(tasFil.Hamleler[i]); 
                Hamleler.Add(tasFil.Hamleler[i + 1]);
            }

            for (i = 0; i < tasKale.Hamleler.Count; i+=2)
            {
                Hamleler.Add(tasKale.Hamleler[i]); 
                Hamleler.Add(tasKale.Hamleler[i + 1]);
            }
        }
    }
}
