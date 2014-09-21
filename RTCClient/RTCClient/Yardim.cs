using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using RTCCORELib;

namespace RTCClient
{
    class Yardim
    {
        private static int imgIndex;

        public static int ImgIndex
        {
            get { return Yardim.imgIndex; }
        }

        public static bool Basarili(int durum)
        {
            return (durum >= 0);
        }

        public static string KisiAdiOlustur(IRTCBuddy2 kisi)
        {
            RTC_PRESENCE_STATUS bulunmaDurumu = kisi.Status; // kiþinin durumunu al

            string isim = Yardim.KisiAdiAl(kisi);
            string gorunumDurumu = Yardim.GorunumDurumuOlustur(bulunmaDurumu); // isim ve duruma göre kiþi string i oluþtur

            if (isim == null || isim.Length == 0)
            {
                return null;
            }

            return (isim + gorunumDurumu);
        }

        public static string KisiAdiAl(IRTCBuddy2 kisi)
        {
            string kisiAdi;

            try
            {
                kisiAdi = kisi.get_PresenceProperty(RTC_PRESENCE_PROPERTY.RTCPP_DISPLAYNAME);
            }
            catch (COMException)
            {
                kisiAdi = null;
            }

            if (kisiAdi == null)
            {
                try
                {
                    kisiAdi = kisi.PresentityURI;
                }
                catch (COMException)
                {
                    kisiAdi = null;
                }
            }
            return kisiAdi;
        }

        public static string GorunumDurumuOlustur(RTC_PRESENCE_STATUS bulunmaDurumu)
        {
            StringBuilder sbGorunenAd = new StringBuilder();

            switch (bulunmaDurumu)
            {
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_ONLINE:
                    sbGorunenAd.Append(" (Çevrimiçi)");
                    imgIndex = 1;
                    break;
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_BUSY:
                    sbGorunenAd.Append(" (Meþgul)");
                    imgIndex = 2;
                    break;
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_BE_RIGHT_BACK:
                    sbGorunenAd.Append(" (Hemen dönecek)");
                    imgIndex = 3;
                    break;
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_AWAY:
                    sbGorunenAd.Append(" (Dýþarýda)");
                    imgIndex = 4;
                    break;
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_ON_THE_PHONE:
                    sbGorunenAd.Append(" (Telefonda)");
                    imgIndex = 5;
                    break;
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OUT_TO_LUNCH:
                    sbGorunenAd.Append(" (Öðle yemeðinde)");
                    imgIndex = 6;
                    break;
                case RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OFFLINE:
                    sbGorunenAd.Append(" (Çevrimdýþý)");
                    imgIndex = 7;
                    break;
                default:
                    break;
            }
            return sbGorunenAd.ToString();
        }


        public static string KisiOzellikeri(IRTCBuddy2 kisi)
        {
            StringBuilder ozellikler = new StringBuilder();
            string gorunenAd, telefon, email, uri, notlar, veri;
            bool Kararlilik;
            string bulunmaDurumu;

            try
            {
                gorunenAd = kisi.get_PresenceProperty(RTC_PRESENCE_PROPERTY.RTCPP_DISPLAYNAME);
            }
            catch (COMException)
            {
                gorunenAd = "Belirtilmemiþ";
            }

            try
            {
                telefon = kisi.get_PresenceProperty(RTC_PRESENCE_PROPERTY.RTCPP_PHONENUMBER);
            }
            catch (COMException)
            {
                telefon = "Belirtilmemiþ";
            }

            try
            {
                email = kisi.get_PresenceProperty(RTC_PRESENCE_PROPERTY.RTCPP_EMAIL);
            }
            catch (COMException)
            {
                email = "Belirtilmemiþ";
            }

            try
            {
                uri = kisi.PresentityURI;
            }
            catch (COMException)
            {
                uri = "Belirtilmemiþ";
            }

            try
            {
                Kararlilik = kisi.Persistent;
            }
            catch (COMException)
            {
                Kararlilik = false;
            }

            try
            {
                bulunmaDurumu = GorunumDurumuOlustur(kisi.Status);
            }
            catch (COMException)
            {
                bulunmaDurumu = GorunumDurumuOlustur(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OFFLINE);
            }

            try
            {
                notlar = kisi.Notes;
            }
            catch (COMException)
            {
                notlar = "Belirtilmemiþ";
            }

            try
            {
                veri = kisi.Data;
            }
            catch (COMException)
            {
                veri = "Belirtilmemiþ";
            }

            ozellikler.Append(string.Format("Kiþi Adý: {0}\nTelefon: {1}\nEmail: {2}\n", gorunenAd, telefon, email));
            ozellikler.Append(string.Format("URI: {0}\nDurum: {1}\nKararlýlýk: {2}\nNotlar: {3}\nVeri: {4}\n", uri, bulunmaDurumu, Kararlilik, notlar, veri));
            return ozellikler.ToString();
        }
    }
}
