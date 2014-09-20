using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PikseLChess
{
    class Log
    {
        static String[] Harfler = { "a", "b", "c", "d", "e", "f", "g", "h" };
        static String[] Rakamlar = { "8", "7","6","5","4","3","2","1" };
        public static ListView lvHamleler;
        public static Stack undoHamle = new Stack();
        public static Stack redoHamle = new Stack();

        public static void LogHamle(int i, IntPtr hwdnsLstBox, Renkler Oyuncu, Taslar tasTipi, int x1, int y1, int x2, int y2, String Hamle)
        {
            String tasBasHarf = tasTipi.ToString().Substring(0, 1);
            lvHamleler.Items.Add(Oyuncu.ToString());
            lvHamleler.Items[i].SubItems.Add(tasBasHarf);

            undoHamle.Push(Hamle); // Log daki "Þah", "Mat", "bRok", "kRok" ve "" deðerlerinin(Hamle deðerlerinin) tutulmasý...

            Hamle = (Hamle!="") ? (" - " + Hamle) : ("");
            lvHamleler.Items[i].SubItems.Add(Harfler[x1] + Rakamlar[y1] + "-" + Harfler[x2] + Rakamlar[y2] + Hamle);
        }

        public static void SilHamle(int No)
        {
            redoHamle.Push(undoHamle.Pop()); 
            lvHamleler.Items[No].Remove();
        }
    }
}
