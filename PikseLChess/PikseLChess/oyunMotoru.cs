using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PikseLChess
{
    class oyunMotoru
    {
        public Renkler Sira = Renkler.Beyaz; // Oyuna Beyaz oyuncu baþlasýn...
        public Renkler Oyuncu; // Oyuncu rengini belirlemek için...
        public Graphics g;
        public int hamleSayisi = 0; // Hamle numaralarýný belirlemek için. ListView ve bazý iþlemlerde yardýmcý olacak.
        public Tas[,] satrancTaslari = new Tas[8, 8]; // Taþlarýn tutulduðu dizi...

        public bool Secim = false; // Oyuncu taþý seçerse true olacak...
        public int x1, y1; // Seçilen taþý taþýmak için ilk koordinatlarýný tutuyoruz...
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
                    x1 = -1; y1 = -1; // Seçili taþ yok
                    Secim = false;  // Yeni seçim yapýlsýn.
                    return;
                }
            }

            if (secilenTas != null) // Herhangi bir taþ seçilmiþse
            {
                if (secilenTas.Renk == Renkler.Beyaz) // Hangi oyuncu olduðunu belirle
                    Oyuncu = Renkler.Beyaz;
                else
                    Oyuncu = Renkler.Siyah;

                if (Sira == Oyuncu)
                {
                    Secim = true; // Seçim yapýldý. Hamle yapmaya hazýrýz...

                    if (x1 >= 0 && y1 >= 0) // Daha önce oyuncunun taþý seçilmiþse, Yolunu temizlemek için...
                    {
                        satrancTaslari[x1, y1].YolGizle(g);
                        satrancTaslari[x1, y1].Gizle(g); // Daha önce ayný renkte taþ seçildiyse seçimi gizle...
                        oyunAlani.TaslarGoster(satrancTaslari, g);
                    }

                    satrancTaslari[mX, mY].HamleHesapla(satrancTaslari); // Gidebileceði yerleri diziye doldur...
                    satrancTaslari[mX, mY].SecimGoster(g); // yeni seçilen taþýn seçimini göster
                    satrancTaslari[mX, mY].YolGoster(satrancTaslari, g);
                    oyunAlani.TaslarGoster(satrancTaslari, g);

                    x1 = mX; // Taþýn hamleden öncekini yerini tut...
                    y1 = mY;
                }
                else
                {
                    if (x1 >= 0 && y1 >= 0) // Yolu temizlemek için(Kendi taþýný seçtikenten sonra rakip taþý seçerse)
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
            satrancTaslari[x1, y1].Gizle(g); // Taþý Sil.

            Tasi(x1, y1, x2, y2); // Taþý götür...

                sahYeri = sahBul();   // Oyuncunun þahýnýn yerini bul...
                if (sahCekildi(sahYeri)) // Diðer taþlar tarafýndan þah çekliliyor mu?
                {
                    if (alinanTas != null) // Taþ alýnmýþsa sakla (Tasi metodunda)
                    {
                        temp = alinanTas;
                    }

                    Tasi(x2, y2, x1, y1); // Mat olacak, taþý eski yerine getir...
                    satrancTaslari[x1, y1].Goster(g); // Taþý Göster
                    satrancTaslari[x1, y1].Hamleler.Clear();

                    if (temp != null) // Alýnan taþý da yerine koy
                    {
                        satrancTaslari[x2, y2] = temp;
                        satrancTaslari[x2, y2].Goster(g);
                        temp = null;
                    }

                    oyunAlani.TaslarGoster(satrancTaslari, g); // Refresh
                    Secim = false; // Oyuncu deðiþmeden yeni hamle yapýlsýn
                    return;
                } 

            // Piyon'un Vezir'e dönüþmesi
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

            // Undo'dan sonra kullanýcý hamle yaparsa redo dan hamle çýkar
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

            if (alinanTas != null) // Alýnan taþ varsa yýðýna at
            {
                UndoRedo.undoTaslar.Push(alinanTas);
                alinanTas.Gizle(g);
            }
            else
            {
                UndoRedo.undoTaslar.Push(null); // Alýnan taþ yoksa null bas
            }

            satrancTaslari[x2, y2].Goster(g); // Taþý Göster
            satrancTaslari[x2, y2].Hamleler.Clear();
            oyunAlani.TaslarGoster(satrancTaslari, g); // Refresh..

            if (Sira == Renkler.Beyaz) // Oyuncuyu deðiþtir
                Sira = Renkler.Siyah;
            else
                Sira = Renkler.Beyaz;

            /*Þah-Mat Kontrolü...
            Sýra diðer oyuncuya geçti ama daha önce Diðer Oyuncunun þahýnýn yerini bul...*/
            sahYeri = sahBul();
            if (sahCekildi(sahYeri)) // Yapýlan hamle sonucunda Diðer oyuncuya þah çekildi mi?
            {
                if (matOldu()) // Þah çekildiyse mat oldu mu?
                {
                    Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2,"Mat");
                    MessageBox.Show(Sira.ToString() + " Mat oldu. Oyunu " + Oyuncu.ToString() + " kazandý", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hamleSayisi++;
                    return;
                }
                else
                {
                    Log.LogHamle(hamleSayisi, handleLView, Oyuncu, satrancTaslari[x2, y2].tasTipi, x1, y1, x2, y2,"Þah");
                    hamleSayisi++;
                    return;
                }
            }

            if (satrancTaslari[x2, y2].tasTipi == Taslar.Sah) // Þah taþýndýysa Rok Yaptý Mý?
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

        public bool sahCekildi(Point sahYeri) // Diðer oyuncu'nun þah çekip çekmediðini kontrol ediyoruz... 
        {
            Renkler tasRengi;
            int i, j, k;

            if (Sira == Renkler.Beyaz)
            {
                tasRengi = Renkler.Siyah; // Þah beyaz ise siyah taþlarý kontrol edeceðiz...
            }
            else
            {
                tasRengi = Renkler.Beyaz; // Þah siyah ise beyaz taþlarý kontrol edeceðiz...
            }

            // oyunun her karesine bakýp, karþý tarafýn taþlarýný bul
            // ve bu taþlarýn þah çekip çekmediðini kontrol et...
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((satrancTaslari[i, j] != null) && (satrancTaslari[i, j].Renk == tasRengi))
                    {
                        if (satrancTaslari[i, j].tasTipi == Taslar.Sah)
                        {
                            continue;  // Þah Þaha Þah çekemez...
                        }

                        satrancTaslari[i, j].HamleHesapla(satrancTaslari); // taþ hamle yapsýn...

                        for (k = 0; k < satrancTaslari[i, j].Hamleler.Count; k += 2)
                        {
                            // Þah a hamle yaptý!
                            if ((int)satrancTaslari[i, j].Hamleler[k] == sahYeri.X && (int)satrancTaslari[i, j].Hamleler[k + 1] == sahYeri.Y)
                            {
                                satrancTaslari[i, j].Hamleler.Clear(); // Hamleleri geri al...
                                return true; // Þah Çekti !
                            }
                        }

                        satrancTaslari[i, j].Hamleler.Clear(); // Hamleleri geri al...
                    }
                }
            }
            return false; // Þah çekme durumu yok.
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
                            if (alinanTas != null) // Taþ alýnmýþsa sakla...
                            {
                                temp = alinanTas;
                            }

                            sahYeri = sahBul();
                            if (!sahCekildi(sahYeri)) // Hala þah çekiliyorsa...
                            {
                                // Taþý geri getir, 
                                Tasi(x2, y2, i, j);
                                if (temp != null)
                                {
                                    satrancTaslari[x2, y2] = temp;
                                    temp = null;
                                }
                                satrancTaslari[i, j].Hamleler.Clear();
                                return false; //Þahý koruyabildik veya þah kaçtý... 
                            }
                            // Taþý geri getir, 
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

        public Point sahBul() // Sýra kimde ise Þahý'nýn yerini bulur...
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
                Tasi(sahX - 2, sahY, sahX + 1, sahY); // Kaleyi þahýn saðýna taþý...
                satrancTaslari[sahX + 1, sahY].Goster(g); // Kaleyi göster...
            }
            else if (rokTuru == "kRok")
            {
                satrancTaslari[sahX + 1, sahY].Gizle(g); // Kaleyi gizle...
                Tasi(sahX + 1, sahY, sahX - 1, sahY); // Kaleyi þahýn soluna taþý...
                satrancTaslari[sahX - 1, sahY].Goster(g); // Kaleyi göster...
            }
        }

        public void Tasi(int x1, int y1, int x2, int y2) // Hamle sonucunda dizideki taþýn hedefe taþýnmasý
        {
            if (satrancTaslari[x2, y2] != null) // Alinan taþ varsa kaydet...
            {
                alinanTas = satrancTaslari[x2, y2]; 
            }
            else
            {
                alinanTas = null;
            }

            satrancTaslari[x2, y2] = satrancTaslari[x1, y1]; // Taþý hedefe kopyala...
            satrancTaslari[x1, y1] = null;  // Taþý sil

            satrancTaslari[x2, y2].Yer.X = x2; // Yer özelliðini güncelle
            satrancTaslari[x2, y2].Yer.Y = y2;
        } 
    }
}