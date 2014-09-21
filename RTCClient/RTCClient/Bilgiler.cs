using System;
using System.Collections.Generic;
using System.Text;

namespace RTCClient
{
    public class Bilgiler
    {
        private string uri;
        public string URI
        {
            get { return uri; }
            set { uri = value; }
        }

        private string sunucu;
        public string Sunucu
        {
            get { return sunucu; }
            set { sunucu = value; }
        }

        private string transfer;
        public string Transfer
        {
            get { return transfer; }
            set { transfer = value; }
        }

        private string kimlik;
        public string Kimlik
        {
            get { return kimlik; }
            set { kimlik = value; }
        }

        private string sifre;
        public string Sifre
        {
            get { return sifre; }
            set { sifre = value; }
        }

        public Bilgiler()
        {
            uri = sunucu = transfer = kimlik = sifre = String.Empty;
        }

        public bool GecerliMi()
        {
            return (uri.Length != 0);
        }
    }
}
