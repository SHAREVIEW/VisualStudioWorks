using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PikseLChess
{
    class oyunMotoru
    {
        public Renkler Sira = Renkler.Beyaz; // Oyuna Beyaz oyuncu ba�las�n...
        public Renkler Oyuncu; // Oyuncu rengini belirlemek i�in...
        public Graphics g;
        public int hamleSayisi = 0; // Hamle numaralar�n� belirlemek i�in. ListView ve baz� i�lemlerde yard�mc� olacak.
        public Tas[,] satrancTaslari = new Tas[8, 8]; // Ta�lar�n tutuldu�u dizi...

        public bool Secim = false; // Oyuncu ta�� se�erse true olacak...
        public int x1, y1; // Se�ilen ta�� ta��mak i�in ilk koordinatlar�n� tutuyoruz...
        private bool Hamle = false;
        private Tas alinanTas;
        public IntPtr handleLView;

        public oyunMotoru(IntPtr hwndLV, Graphics gPB)
        {
            Log.lvHamleler = (ListView)ListView.FromHandle(hwndLV);
            handleLView = hwndLV;
            g = gPB;
        }
        
        public void YeniOyun()
        {
            oyunAlani.TaslarOlustur(satrancTaslari);
            oyunAlani.TaslarGoster(satrancTaslari, g);
        }

        public void Play(int mX, int mY)
        {
            Tas secilenTas;
            int i;
            Hamle = false;
            secilenTas = satrancTaslari[mX, mY];

            if (Secim)
            {
                for (i = 0; i < satrancTaslari[x1, y1].Hamleler.Count; i += 2)
                {
                    if ((int)satrancTaslari[x1, y1].Hamleler[i] == mX && (int)satrancTaslari[x1, y1].Hamleler[i + 1] == mY)
                    {
                        Hamle = true; // Hamle yapabilir mi?
                    }
                }

                if (Hamle)
                {
                    HamleYap(x1, y1, mX, mY);
                    x1 = -1; y1 = -1; // Se�ili ta� yok
                    Secim = false;  // Yeni se�im yap�ls�n.
                    return;
                }
            }

            if (secilenTas != null) // Herhangi bir ta� se�ilmi�se
            {
                if (secilenTas.Renk == Renkler.Beyaz) // Hangi oyuncu oldu�unu belirle
                    Oyuncu = Renkler.Beyaz;
                else
                    Oyuncu = Renkler.Siyah;

                if (Sira == Oyuncu)
                {
                    Secim = true; // Se�im yap�ld�. Hamle yapmaya haz�r�z...

                    if (x1 >= 0 && y1 >= 0) // Daha �nce oyuncunun ta�� se�ilmi�se, Yolunu temizlemek i�in...
                    {
                        satrancTaslari[x1, y1].YolGizle(g);
                        satrancTaslari[x1, y1].Gizle(g); // Daha �nce ayn� renkte ta� se�ildiyse se�imi gizle...
                        oyunAlani.TaslarGoster(satrancTaslari, g);
                    }

                    satrancTaslari[mX, mY].HamleHesapla(satrancTaslari); // Gidebilece�i yerleri diziye doldur...
                    satrancTaslari[mX, mY].SecimGoster(g); // yeni se�ilen ta��n se�imini g�ster
                    satrancTaslari[mX, mY].YolGoster(satrancTaslari, g);
                    oyunAlani.TaslarGoster(satrancTaslari, g);

                    x1 = mX; // Ta��n hamleden �ncekini yerini tut...
                    y1 = mY;
                }
                else
                {
                    if (x1 >= 0 && y1 >= 0) // Yolu temizlemek i�in(Kendi ta��n� se�tikenten sonra rakip ta�� se�erse)
                    {
                        satrancTaslari[x1, y1].YolGizle(g);
                        satrancTaslari[x1, y1].Gizle(g);
                        oyunAlani.TaslarGoster(satrancTaslari, g);
                    }

                    Secim = false;
                }
            }
        }

        public void HamleYap(int x1, int y1, int x2, int y2)
        {
            Point sahYeri;
            Tas temp=null;

            satrancTaslari[x1, y1].YolGizle(g);
            satrancTaslari[x1, y1].Gizle(g); // Ta�� Sil.

            Tasi(x1, y1, x2, y2); // Ta�� g�t�r...

                sahYeri = sahBul();   // Oyuncunun �ah�n�n yerini bul...
                if (sahCekildi(sahYeri)) // Di�er ta�lar taraf�ndan �ah �ekliliyor mu?
                {
                    if (alinanTas != null) // Ta� al�nm��sa sakla (Tasi metodunda)
                    {
                        temp = alinanTas;
                    }

                    Tasi(x2, y2, x1, y1); // Mat olacak, ta�� eski yerine getir...
                    satrancTaslari[x1, y1].Goster(g); // Ta�� G�ster
                    satrancTaslari[x1, y1].Hamleler.Clear();

                    if (temp != null) // Al�nan ta�� da yerine koy
                    {
                        satrancTaslari[x2, y2] = temp;
                        satrancTaslari[x2, y2].Goster(g);
                        temp = null;
                    }

                    oyunAlani.TaslarGoster(satrancTaslari, g); // Refresh
                    Secim = false; // Oyuncu de�i�meden yeni hamle yap�ls�n
                    return;
                } 

            // Piyon'un Vezir'e d�n��mesi
            if (satrancTaslari[x2, y2].tasTipi == Taslar.Piyon)
            {
                if (Oyuncu == Renkler.Beyaz && satrancTaslari[x2, y2].Yer.Y == 0)
                {
                    satrancTaslari[x2, y2] = new Vezir(new Point(x2,y2), Taslar.Vezir, Renkler.Beyaz);
                }
                else if (Oyuncu == Renkler.Beyaz && satrancTaslari[x2, y2].Yer.Y == 7)
                {
                    satrancTaslari[x2, y2] = new Vezir(new Point(x2,y2), Taslar.Vezir, Renkler.Siyah);
                }
            }

            // Undo'dan sonra kullan�c� hamle yaparsa redo dan hamle ��kar
            if (UndoRedo.redoNoktalar.Count > 0)
            {
                UndoRedo.redoNoktalar.Pop();
                UndoRedo.redoNoktalar.Pop();
                UndoRedo.redoTaslar.Pop();
                UndoRedo.redoTaslar.Pop();
            }

            UndoRedo.undoNoktalar.Push(new Point(x1, y1));
            UndoRedo.undoNoktalar.Push(new Point(x2, y2));
            UndoRedo.undoTaslar.Push(satrancTaslari[x2, y2]);

            if (alinanTas != null) // Al�nan ta� varsa y���na at
            {
                UndoRedo.undoTaslar.Push(alinanTas);
                alinanTas.Gizle(g);
            }
            else
            {
                UndoRedo.undoTaslar.Push(null); // Al�nan ta� yoksa null bas
            }

            satrancTaslari[x2, y2].Goster(g); // Ta�� G�ster
            satrancTaslari[x2, y2].Hamleler.Clear();
            oyunAlani.TaslarGoster(satrancTaslari, g); // Refresh..

            if (Sira == Renkler.Beyaz) // Oyuncuyu de�i�tir
                Sira = Renkler.Siyah;
            else
                Sira = Renkler.Beyaz;

            /*�ah-Mat Kontrol�...
            S�ra di�er oyuncuya ge�ti ama daha �nce Di�er Oyuncunun �ah�n�n yerini bul...*/
            sahYeri = sahBul();
            if (sahCekildi(sahYeri)) // Yap�lan hamle sonucunda Di�er oyuncuya �ah �ekildi mi?
            {
                if (matOldu()) // �ah �ekildiyse mat oldu mu?
                {
                    Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2,"Mat");
                    MessageBox.Show(Sira.ToString() + " Mat oldu. Oyunu " + Oyuncu.ToString() + " kazand�", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hamleSayisi++;
                    return;
                }
                else
                {
                    Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2,"�ah");
                    hamleSayisi++;
                    return;
                }
            }

            if (satrancTaslari[x2, y2].tasTipi == Taslar.Sah) // �ah ta��nd�ysa Rok Yapt� M�?
            {
                if (x2 == x1 - 2)
                {
                    Rok(x2, y2, "bRok");
                    Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2, "bRok");
                    hamleSayisi++;
                    return;
                }
                else if (x2 == x1 + 2)
                {
                    Rok(x2, y2, "kRok");
                    Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2, "kRok");
                    hamleSayisi++;
                    return;
                }
            }

            Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2,""); // Normal Hamle
            hamleSayisi++;
        }

        public bool sahCekildi(Point sahYeri) // Di�er oyuncu'nun �ah �ekip �ekmedi�ini kontrol ediyoruz... 
        {
            Renkler tasRengi;
            int i, j, k;

            if (Sira == Renkler.Beyaz)
            {
                tasRengi = Renkler.Siyah; // �ah beyaz ise siyah ta�lar� kontrol edece�iz...
            }
            else
            {
                tasRengi = Renkler.Beyaz; // �ah siyah ise beyaz ta�lar� kontrol edece�iz...
            }

            // oyunun her karesine bak�p, kar�� taraf�n ta�lar�n� bul
            // ve bu ta�lar�n �ah �ekip �ekmedi�ini kontrol et...
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((satrancTaslari[i, j] != null) && (satrancTaslari[i, j].Renk == tasRengi))
                    {
                        if (satrancTaslari[i, j].tasTipi == Taslar.Sah)
                        {
                            continue;  // �ah �aha �ah �ekemez...
                        }

                        satrancTaslari[i, j].HamleHesapla(satrancTaslari); // ta� hamle yaps�n...

                        for (k = 0; k < satrancTaslari[i, j].Hamleler.Count; k += 2)
                        {
                            // �ah a hamle yapt�!
                            if ((int)satrancTaslari[i, j].Hamleler[k] == sahYeri.X && (int)satrancTaslari[i, j].Hamleler[k + 1] == sahYeri.Y)
                            {
                                satrancTaslari[i, j].Hamleler.Clear(); // Hamleleri geri al...
                                return true; // �ah �ekti !
                            }
                        }

                        satrancTaslari[i, j].Hamleler.Clear(); // Hamleleri geri al...
                    }
                }
            }
            return false; // �ah �ekme durumu yok.
        }

        public bool matOldu()
        {
            int i, j, k;
            int x2, y2;
            Point sahYeri;
            Tas temp = null;

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((satrancTaslari[i, j] != null) && (satrancTaslari[i, j].Renk == Sira))
                    {
                        satrancTaslari[i, j].HamleHesapla(satrancTaslari);

                        for (k = 0; k < satrancTaslari[i, j].Hamleler.Count; k += 2)
                        {
                            x2 = (int)satrancTaslari[i, j].Hamleler[k];
                            y2 = (int)satrancTaslari[i, j].Hamleler[k+1];
                        
                            Tasi(i, j, x2, y2);
                            if (alinanTas != null) // Ta� al�nm��sa sakla...
                            {
                                temp = alinanTas;
                            }

                            sahYeri = sahBul();
                            if (!sahCekildi(sahYeri)) // Hala �ah �ekiliyorsa...
                            {
                                // Ta�� geri getir, 
                                Tasi(x2, y2, i, j);
                                if (temp != null)
                                {
                                    satrancTaslari[x2, y2] = temp;
                                    temp = null;
                                }
                                satrancTaslari[i, j].Hamleler.Clear();
                                return false; //�ah� koruyabildik veya �ah ka�t�... 
                            }
                            // Ta�� geri getir, 
                            Tasi(x2, y2, i, j);
                            if (temp != null)
                            {
                                satrancTaslari[x2, y2] = temp;
                                temp = null;
                            }
                        }

                        satrancTaslari[i, j].Hamleler.Clear();
                    }
                }
            }
            return true; // Mat oldu...
        }

        public Point sahBul() // S�ra kimde ise �ah�'n�n yerini bulur...
        {
            Point p = new Point();
            int i, j;

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (satrancTaslari[i, j] != null)
                    {
                        if ((satrancTaslari[i, j].tasTipi == Taslar.Sah) && (satrancTaslari[i, j].Renk == Sira))
                        {
                            p.X = i;
                            p.Y = j;
                            return p;
                        }
                    }
                }
            }
            return p;
        }

        public void Rok(int sahX, int sahY, string rokTuru)
        {
            if (rokTuru == "bRok")
            {
                satrancTaslari[sahX - 2, sahY].Gizle(g); // Kaleyi gizle...
                Tasi(sahX - 2, sahY, sahX + 1, sahY); // Kaleyi �ah�n sa��na ta��...
                satrancTaslari[sahX + 1, sahY].Goster(g); // Kaleyi g�ster...
            }
            else if (rokTuru == "kRok")
            {
                satrancTaslari[sahX + 1, sahY].Gizle(g); // Kaleyi gizle...
                Tasi(sahX + 1, sahY, sahX - 1, sahY); // Kaleyi �ah�n soluna ta��...
                satrancTaslari[sahX - 1, sahY].Goster(g); // Kaleyi g�ster...
            }
        }

        public void Tasi(int x1, int y1, int x2, int y2) // Hamle sonucunda dizideki ta��n hedefe ta��nmas�
        {
            if (satrancTaslari[x2, y2] != null) // Alinan ta� varsa kaydet...
            {
                alinanTas = satrancTaslari[x2, y2]; 
            }
            else
            {
                alinanTas = null;
            }

            satrancTaslari[x2, y2] = satrancTaslari[x1, y1]; // Ta�� hedefe kopyala...
            satrancTaslari[x1, y1] = null;  // Ta�� sil

            satrancTaslari[x2, y2].Yer.X = x2; // Yer �zelli�ini g�ncelle
            satrancTaslari[x2, y2].Yer.Y = y2;
        } 
    }
}