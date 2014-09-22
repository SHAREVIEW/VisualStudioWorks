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

        /* Hata Mesajlarý*/
        public static String hataResim = "Seçilen resim dosyasý gösterilemiyor.";
        public static String hataKopyalama = "Seçilen resim dosyasý gösterilemiyor. Lütfen resmi" + resimKlasoru + "adresine kopyalayýn.";
        public static String hataKayitEkleme = "Girilen bilgiler veritabanýna eklenemedi. Lütfen sistem yöneticiniz ile görüþün.";
        public static String hataYTNO = "Lütfen 10 haneli YTXXXXXXXX bilgisini giriniz.";
        public static String hataBaglanti = "Veritabaný ile baðlantý kurulamadý. Lütfen sistem yöneticiniz ile görüþün.\r\nHata: {0}";

        public static String hataUnite = "Lütfen Ünite girin.";
        public static String hataUniteEkipman = "Lütfen Ünite seçin ve Ekipman adý girin.";

        public static String hataUniteEkle = "Ünite eklenirken hata oluþtu. Lütfen sistem yöneticiniz ile görüþün.";
        public static String hataUniteVar = "Ünite zaten mevcut. Lütfen baþka bir ünite adý girin.";
        public static String hataEkipmanEkle = "Ekipman eklenirken hata oluþtu. Lütfen sistem yöneticiniz ile görüþün.";
        public static String hataEkipmanVar = "Ekipman zaten mevcut. Lütfen baþka bir ünite adý girin.";

        public static String hataBilgiEksik = "Lütfen bilgileri eksiksiz girin.";
        public static String hataSayisalVeri = "Sayýsal veri girmelisiniz.";
        public static String hataKayýtVar = "Girmiþ olduðunuz kayýt CPS'de bulunmaktadýr.";

        public static String hataRafNo = "Raf kullanýlmaktadýr. Lütfe baþka raf giriniz.";
    }
}
