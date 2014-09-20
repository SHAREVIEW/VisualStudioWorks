using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PikseLChess
{
    class Sah : Tas
    {
        public Sah(Point p, Taslar tas, Renkler renk) : base(p,tas,renk)
        {
        }

        public override void HamleHesapla(Tas[,] t)
        {
            if (SahKaleKontrol()) // �ah ve Kale daha �nce hareket etmemi�se...
            {
                if (Renk == Renkler.Siyah && Yer.X == 4 && Yer.Y == 0)
                {
                    RokHesapla(t);
                }
                else if (Renk == Renkler.Beyaz && Yer.X == 4 && Yer.Y == 7)
                {
                    RokHesapla(t);
                }
            }

            // Vezir ile �ah hareketleri benzerdir.
            // �ah, vezirin k�rp�lm�� halidir :)
            Vezir tasVezir = new Vezir(new Point(Yer.X, Yer.Y), Taslar.Vezir, Renk);
            tasVezir.HamleHesapla(t);

            SahHareket(tasVezir, Yer.X - 1, Yer.Y); // Sola
            SahHareket(tasVezir, Yer.X + 1, Yer.Y); // Sa�a
            SahHareket(tasVezir, Yer.X - 1, Yer.Y + 1); // Sol Alt
            SahHareket(tasVezir, Yer.X - 1, Yer.Y - 1); // Sol �st
            SahHareket(tasVezir, Yer.X, Yer.Y - 1); // Yukar�
            SahHareket(tasVezir, Yer.X, Yer.Y + 1); // A�a��
            SahHareket(tasVezir, Yer.X + 1, Yer.Y + 1); // Sa� Alt
            SahHareket(tasVezir, Yer.X + 1, Yer.Y - 1); // Sa� �st
        }

        private void SahHareket(Vezir tasVezir, int x, int y)
        {
            int i;
            // E�er vezirin gitti�i yerlerde g�nderdi�imiz koordinat da varsa hamle yaps�n...
            for (i = 0; i < tasVezir.Hamleler.Count; i += 2)
            {
                if ((int)tasVezir.Hamleler[i] == x && (int)tasVezir.Hamleler[i + 1] == y)
                {
                    Hamleler.Add(tasVezir.Hamleler[i]); Hamleler.Add(tasVezir.Hamleler[i + 1]);
                }
            }
        }

        private void RokHesapla(Tas[,] t)
        {
            // B�y�k Rok yap
            if (t[Yer.X - 4, Yer.Y] != null && t[Yer.X - 4, Yer.Y].tasTipi == Taslar.Kale)
            {
                if (t[Yer.X - 1, Yer.Y] == null && t[Yer.X - 2, Yer.Y] == null && t[Yer.X - 3, Yer.Y] == null)
                {
                    Hamleler.Add(Yer.X - 2); Hamleler.Add(Yer.Y);
                }
            }
            // K���k Rok yap
            if (t[Yer.X + 3, Yer.Y] != null && t[Yer.X + 3, Yer.Y].tasTipi == Taslar.Kale)
            {
                if (t[Yer.X + 1, Yer.Y] == null && t[Yer.X + 2, Yer.Y] == null)
                {
                    Hamleler.Add(Yer.X + 2); Hamleler.Add(Yer.Y);
                }
            }
        }

        public bool SahKaleKontrol()
        {
            for (int i = 0; i < Log.lvHamleler.Items.Count; i++)
            {
                // Oyuncu daha �nce �ah ve kalesini hareket ettirmi� mi?
                if (Log.lvHamleler.Items[i].Text == Renk.ToString() &&
                   (Log.lvHamleler.Items[i].SubItems[1].Text == "S" || Log.lvHamleler.Items[i].SubItems[1].Text == "K"))
                {
                    return false;
                }
            }
            return true; // �ah ve Kale hamle yapmam��
        }

    }
}
