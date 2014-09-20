using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace PikseLChess
{
    class UndoRedo
    {
        public static Stack undoNoktalar = new Stack();
        public static Stack undoTaslar = new Stack();
        public static Stack redoNoktalar = new Stack();
        public static Stack redoTaslar = new Stack();

        private static string Hamle = "";

        public static void Undo(oyunMotoru motor) // Geri Al...
        {
            int x2, y2, x1, y1;

            Point pKaynak = (Point)undoNoktalar.Pop(); // x2, y2 alýndý
            Point pHedef = (Point)undoNoktalar.Pop(); // x1, y1 alýndý
            Tas yenilenTas = (Tas)undoTaslar.Pop();
            Tas tasinacakTas = (Tas)undoTaslar.Pop();

            x2 = pKaynak.X; y2 = pKaynak.Y;
            x1 = pHedef.X; y1 = pHedef.Y;

            OyuncuDegistir(motor);

            SecilenTasIptal(motor);

            UndoRok(motor);

            motor.satrancTaslari[x2, y2].Gizle(motor.g);
            motor.Tasi(x2, y2, x1, y1);
            motor.satrancTaslari[x1, y1].Goster(motor.g);

            if (yenilenTas != null) // Yenilen taþ varsa
            {
                motor.satrancTaslari[x2, y2] = yenilenTas;
                motor.satrancTaslari[x2, y2].Goster(motor.g);
            }

            motor.hamleSayisi--;
            Log.SilHamle(motor.hamleSayisi);

            // Undo'nun kaynaðý Redo'nun hedefi olur...
            redoNoktalar.Push(pKaynak); // x2,y2 bas
            redoNoktalar.Push(pHedef); // x1,y1 bas
            redoTaslar.Push(yenilenTas);
            redoTaslar.Push(tasinacakTas);
        }

        public static void Redo(oyunMotoru motor)
        {
            int x1, y1, x2, y2;
            Point pKaynak = (Point)redoNoktalar.Pop(); // x1, y1 alýndý
            Point pHedef = (Point)redoNoktalar.Pop(); // x2, y2 alýndý
            Tas tasinacakTas = (Tas)redoTaslar.Pop();
            Tas yenilenTas = (Tas)redoTaslar.Pop();

            x1 = pKaynak.X; y1 = pKaynak.Y;
            x2 = pHedef.X; y2 = pHedef.Y;

            SecilenTasIptal(motor);

            if (yenilenTas != null)
            {
                motor.satrancTaslari[x2, y2].Gizle(motor.g);
            }

            motor.satrancTaslari[x1, y1].Gizle(motor.g);
            motor.Tasi(x1, y1, x2, y2);
            motor.satrancTaslari[x2, y2].Goster(motor.g);

            RedoRok(motor);

            Hamle = (string)Log.redoHamle.Pop();
            Log.LogHamle(motor.hamleSayisi, motor.handleLView, motor.Sira, motor.satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2, Hamle);
            motor.hamleSayisi++;

            OyuncuDegistir(motor);

            undoNoktalar.Push(pKaynak);
            undoNoktalar.Push(pHedef);
            undoTaslar.Push(tasinacakTas);
            undoTaslar.Push(yenilenTas);
        }

        private static void RedoRok(oyunMotoru motor)
        {
            Hamle = (string)Log.redoHamle.Peek();
            if (Hamle == "bRok")
            {
                Point sahYeri = motor.sahBul();
                motor.Rok(sahYeri.X, sahYeri.Y, "bRok");
            }
            else if (Hamle == "kRok")
            {
                Point sahYeri = motor.sahBul();
                motor.Rok(sahYeri.X, sahYeri.Y, "kRok");
            }
        }

        private static void UndoRok(oyunMotoru motor)
        {
            // Hamlede rok varsa kaleyi eski yerine getir...
            Hamle = (string)Log.undoHamle.Peek();
            if (Hamle == "bRok")
            {
                Point sahYeri = motor.sahBul();
                motor.satrancTaslari[sahYeri.X + 1, sahYeri.Y].Gizle(motor.g);
                motor.Tasi(sahYeri.X + 1, sahYeri.Y, sahYeri.X - 2, sahYeri.Y);
                motor.satrancTaslari[sahYeri.X - 2, sahYeri.Y].Goster(motor.g);
            }
            else if (Hamle == "kRok")
            {
                Point sahYeri = motor.sahBul();
                motor.satrancTaslari[sahYeri.X - 1, sahYeri.Y].Gizle(motor.g);
                motor.Tasi(sahYeri.X - 1, sahYeri.Y, sahYeri.X + 1, sahYeri.Y);
                motor.satrancTaslari[sahYeri.X + 1, sahYeri.Y].Goster(motor.g);
            }
        }

        private static void OyuncuDegistir(oyunMotoru motor)
        {
            if (motor.Sira == Renkler.Beyaz) // Oyuncuyu deðiþtir
                motor.Sira = Renkler.Siyah;
            else
                motor.Sira = Renkler.Beyaz;
        }

        private static void SecilenTasIptal(oyunMotoru motor)
        {
            if (motor.Secim) // Undo/Redo yaparken bir taþ seçili ise hamlelerini ve yolunu sil.
            {
                motor.Secim = false;
                motor.satrancTaslari[motor.x1, motor.y1].YolGizle(motor.g);
                motor.satrancTaslari[motor.x1, motor.y1].Gizle(motor.g);
                motor.satrancTaslari[motor.x1, motor.y1].Hamleler.Clear();
                oyunAlani.TaslarGoster(motor.satrancTaslari, motor.g);
            }
        }
    }
}