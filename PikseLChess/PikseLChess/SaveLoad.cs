using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PikseLChess
{
    class SaveLoad
    {
        public static void Save(oyunMotoru motor, string dosyaYolu)
        {
            int i, j;
            StreamWriter Yaz = new StreamWriter(dosyaYolu);

            try
            {
                for (i = 0; i < 8; i++)
                {
                    for (j = 0; j < 8; j++)
                    {
                        if (motor.satrancTaslari[i, j] != null)
                        {
                            Tas tas = motor.satrancTaslari[i, j];
                            Yaz.WriteLine(tas.Yer.X.ToString() + "" + tas.Yer.Y.ToString() + "" + (int)tas.Renk + "" + (int)tas.tasTipi);
                        }
                    }
                }

                for (i = 0; i < Log.lvHamleler.Items.Count; i++)
                {
                    Yaz.WriteLine(Log.lvHamleler.Items[i].Text + "," +
                                  Log.lvHamleler.Items[i].SubItems[1].Text + "," +
                                  Log.lvHamleler.Items[i].SubItems[2].Text);
                }
                Yaz.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show("Oyun kaydedilemedi\n\n" + e.Source, "PikseLChess Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Load(oyunMotoru motor, string dosyaYolu)
        {
            string Satir;
            int i=0;
            int x, y, renk, tip;

            StreamReader Oku = new StreamReader(dosyaYolu);
            try
            {
                while ((Satir = Oku.ReadLine()) != null)
                {
                    if (Satir.Length == 4) // Ta�lar okunuyor...
                    {
                        x = Convert.ToInt32(Satir.Substring(0, 1));
                        y = Convert.ToInt32(Satir.Substring(1, 1));
                        renk = Convert.ToInt32(Satir.Substring(2, 1));
                        tip = Convert.ToInt32(Satir.Substring(3, 1));
                        oyunAlani.TasOlustur(motor.satrancTaslari, x, y, (Renkler)renk, (Taslar)tip);
                    }
                    else if (Satir.Length > 4) // listview'e de�erler yazd�r�l�yor
                    {
                        i = motor.hamleSayisi;
                        string[] Hamle = Satir.Split(',');

                        Log.lvHamleler.Items.Add(Hamle[0]); // oyuncu
                        Log.lvHamleler.Items[i].SubItems.Add(Hamle[1]); // ta�
                        Log.lvHamleler.Items[i].SubItems.Add(Hamle[2]); // hamle

                        motor.hamleSayisi++;
                    }
                }
                Oku.Close();

                if (Log.lvHamleler.Items.Count > 0)
                {
                    if (Log.lvHamleler.Items[i].Text == "Beyaz") // S�ray� belirle, listview'deki son sat�ra bak�yoruz
                        motor.Sira = Renkler.Siyah;
                    else
                        motor.Sira = Renkler.Beyaz;
                }

                oyunAlani.TaslarGoster(motor.satrancTaslari, motor.g);
            }
            catch (IOException e)
            {
                MessageBox.Show("Oyun y�klenemedi\n\n" + e.Source, "PikseLChess Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
