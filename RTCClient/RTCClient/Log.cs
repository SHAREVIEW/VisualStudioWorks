using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

using System.Xml;

namespace RTCClient
{
    public class Log
    {
        public static string istemciURI = String.Empty;
        static String gecerliDizin = Directory.GetCurrentDirectory() + "\\Mesajlar";
        static string istemciKlasorYolu;

        public static void MesajLogla(string uri, ArrayList mesajlar)
        {
            string kisiURI = Regex.Replace(uri, @"\W", "_");
            istemciKlasorYolu = Regex.Replace(istemciURI, @"\W", "_");

            StringBuilder dosyaAdi = new StringBuilder();
            dosyaAdi.Append("mesajlar_").Append(kisiURI).Append(".xml");

            if (!Directory.Exists(gecerliDizin)) // Mesajlar klasörü yoksa oluþtur...
            {
                Directory.CreateDirectory(gecerliDizin);
            }

            if (!Directory.Exists(gecerliDizin + "\\" + istemciKlasorYolu)) // istemcinin klasörü yoksa oluþtur...
            {
                Directory.CreateDirectory(gecerliDizin + "\\" + istemciKlasorYolu);
            }

            if (!File.Exists(gecerliDizin + "\\" + istemciKlasorYolu + "\\MesajlarXSL.xsl"))
            {
                try
                {
                    File.Copy(gecerliDizin + "\\MesajlarXSL.xsl", gecerliDizin + "\\" + istemciKlasorYolu + "\\MesajlarXSL.xsl");
                }
                catch (IOException)
                {
                }
            }

            if (!File.Exists(gecerliDizin + "\\" + istemciKlasorYolu + "\\" + dosyaAdi)) // log dosyasý yoksa oluþtur...
            {
                XmlTextWriter writer = new XmlTextWriter(gecerliDizin + "\\" + istemciKlasorYolu + "\\" + dosyaAdi, Encoding.GetEncoding(1254));
                
                writer.WriteStartDocument();
                    writer.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='MesajlarXSL.xsl'");
                    writer.WriteStartElement("Log"); // kök elemaný oluþtur
                    writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Close();
                writer = null;
            }

            Loging(mesajlar, dosyaAdi);
        }

        private static void Loging(ArrayList mesajlar, StringBuilder dosyaAdi)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement mesajNode;
            XmlElement kimdenNode;
            XmlElement kimeNode;
            XmlElement yaziNode;

            try
            {
                xmlDoc.Load(gecerliDizin + "\\" + istemciKlasorYolu + "\\" + dosyaAdi);
            }
            catch (XmlException ex)
            {
            }

            for (int i = 0; i < mesajlar.Count; i++)
            {
                mesajNode = xmlDoc.CreateElement("Mesaj");
                mesajNode.SetAttribute("Tarih", ((LogRecord)mesajlar[i]).Tarih);
                mesajNode.SetAttribute("Saat", ((LogRecord)mesajlar[i]).Saat);
                mesajNode.SetAttribute("TarihSaat", ((LogRecord)mesajlar[i]).TarihSaat);
                xmlDoc.DocumentElement.AppendChild(mesajNode);

                kimdenNode = xmlDoc.CreateElement("Kimden");
                kimeNode = xmlDoc.CreateElement("Kime");
                yaziNode = xmlDoc.CreateElement("Yazý");

                XmlText kimdenText = xmlDoc.CreateTextNode(((LogRecord)mesajlar[i]).Kimden);
                XmlText kimeText = xmlDoc.CreateTextNode(((LogRecord)mesajlar[i]).Kime);
                XmlText yaziText = xmlDoc.CreateTextNode(((LogRecord)mesajlar[i]).Mesaj);

                mesajNode.AppendChild(kimdenNode);
                mesajNode.AppendChild(kimeNode);
                mesajNode.AppendChild(yaziNode);

                kimdenNode.AppendChild(kimdenText);
                kimeNode.AppendChild(kimeText);
                yaziNode.AppendChild(yaziText);
            }
            xmlDoc.Save(gecerliDizin + "\\" + istemciKlasorYolu + "\\" + dosyaAdi);
        }
    }

    public class LogRecord
    {
        public String Tarih;
        public String Saat;
        public String TarihSaat;
        public String Kimden;
        public String Kime;
        public String Mesaj;

        public LogRecord(string from, string to, string msj)
        {
            this.Tarih = DateTime.Now.ToShortDateString();
            this.Saat = DateTime.Now.ToLongTimeString();
            this.TarihSaat = DateTime.Now.ToString();
            this.Kimden = from;
            this.Kime = to;
            this.Mesaj = msj;
        }
    }
}
