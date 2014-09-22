using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AmbarTakip
{
    class Sabitler
    {

        public static String uygulamaKlasoru = Directory.GetCurrentDirectory();
        public static String resimKlasoru = Directory.GetCurrentDirectory() + "\\resimler\\";

        public static String veritabaniAdresi = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + uygulamaKlasoru + "\\AmbarTakip.mdb";

        public static String varsayilanResimAdi = "adsiz.jpg";

        /* Hata Mesajlar�*/
        public static String hataResim = "Se�ilen resim dosyas� g�sterilemiyor.";
        public static String hataKopyalama = "Se�ilen resim dosyas� g�sterilemiyor. L�tfen resmi" + resimKlasoru + "adresine kopyalay�n.";
        public static String hataKayitEkleme = "Girilen bilgiler veritaban�na eklenemedi. L�tfen sistem y�neticiniz ile g�r���n.";
        public static String hataYTNO = "L�tfen 10 haneli YTXXXXXXXX bilgisini giriniz.";
        public static String hataBaglanti = "Veritaban� ile ba�lant� kurulamad�. L�tfen sistem y�neticiniz ile g�r���n.\r\nHata: {0}";

        public static String hataUnite = "L�tfen �nite girin.";
        public static String hataUniteEkipman = "L�tfen �nite se�in ve Ekipman ad� girin.";

        public static String hataUniteEkle = "�nite eklenirken hata olu�tu. L�tfen sistem y�neticiniz ile g�r���n.";
        public static String hataUniteVar = "�nite zaten mevcut. L�tfen ba�ka bir �nite ad� girin.";
        public static String hataEkipmanEkle = "Ekipman eklenirken hata olu�tu. L�tfen sistem y�neticiniz ile g�r���n.";
        public static String hataEkipmanVar = "Ekipman zaten mevcut. L�tfen ba�ka bir �nite ad� girin.";

        public static String hataBilgiEksik = "L�tfen bilgileri eksiksiz girin.";
        public static String hataSayisalVeri = "Say�sal veri girmelisiniz.";
        public static String hataKay�tVar = "Girmi� oldu�unuz kay�t CPS'de bulunmaktad�r.";

        public static String hataRafNo = "Raf kullan�lmaktad�r. L�tfe ba�ka raf giriniz.";
    }
}
