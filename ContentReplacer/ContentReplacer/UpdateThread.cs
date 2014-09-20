using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using ContentReplacer.Properties;

namespace ContentReplacer
{
    public delegate void LogDelegate(object sender, LogEventArgs logArgs);
    public delegate void StoppedDelegate();
    public delegate void CompletedDelegate(bool enabled);

    public class UpdateThread
    {
        private string klasor = string.Empty;
        private string uzanti = string.Empty;
        private string eskiDeger = string.Empty;
        private string yeniDeger = string.Empty;
        private bool recursive = false;
        private Thread isParcasi;

        public event LogDelegate OnLogEvent;
        public event StoppedDelegate OnStopEvent;
        public event CompletedDelegate OnCompletedEvent;

        public Thread IsParcasi
        {
            get
            {
                return this.isParcasi;
            }
        }

        public UpdateThread(
            string klasor, 
            string uzanti, 
            string eDeger, 
            string yDeger, 
            bool recursive)
        {
            this.klasor = klasor;
            this.uzanti = uzanti;
            this.eskiDeger = eDeger;
            this.yeniDeger = yDeger;
            this.recursive = recursive;

            isParcasi = new Thread(new ThreadStart(run));
        }

        private void run()
        {
            try
            {
                Guncelle();
            }
            catch (ArgumentException e1)
            {
                MessageBox.Show(null, e1.Message, Resources.strBilgiCaption, MessageBoxButtons.OK);
                isParcasi.Abort();
                OnStopEventChanged(); // StopOperations...
            }
            catch (Exception e2)
            {
                MessageBox.Show(null, e2.Message, Resources.strHataCaption, MessageBoxButtons.OK);
                isParcasi.Abort();
                OnStopEventChanged();
            }
        }

        private void Guncelle()
        {
            string[] okunanSatirlar;
            int dosyaSayisi, satir;
            StringBuilder stringYapici = new StringBuilder();
            bool tekDegerBulundu = false;

            string[] files = IOManager.GetFilesFromDirectory(klasor, uzanti, recursive);
            if (files.Length == 0)
            {
                throw new ArgumentException(uzanti + " " + Resources.strDosyalarYok);
            }

            for (dosyaSayisi = 0; dosyaSayisi < files.Length; dosyaSayisi++)
            {
                OnLogEventChanged(new LogEventArgs(files[dosyaSayisi] + " " + Resources.strGuncelleniyor, dosyaSayisi));
                
                okunanSatirlar = IOManager.GelLinesFromFile(files[dosyaSayisi]);

                for (satir = 0; satir < okunanSatirlar.Length; satir++)
                {
                    string okunanSatir = okunanSatirlar[satir];

                    if (!recursive && !tekDegerBulundu)
                    {
                        okunanSatir = DegerGuncelle(okunanSatir);
                        if (!string.IsNullOrEmpty(okunanSatir))
                            tekDegerBulundu = true;
                    }
                    else
                    {
                        okunanSatir = okunanSatir.Replace(eskiDeger, yeniDeger);
                    }

                    stringYapici.AppendLine(okunanSatir);
                }
                
                try
                {
                    File.WriteAllText(files[dosyaSayisi], stringYapici.ToString(), Constants.AppEncoding);
                }
                catch (Exception ex) // ~ ile başlayan  temp dosyalar olabilir.
                {
                    OnLogEventChanged(new LogEventArgs(files[dosyaSayisi] + " " + Resources.strGuncellemeHata));
                    OnLogEventChanged(new LogEventArgs("\t " + Resources.strHataCaption + ": " + ex.Message));
                }

                tekDegerBulundu = false;
                stringYapici = new StringBuilder();
            }


            OnLogEventChanged(new LogEventArgs(files.Length + " " + Resources.strGuncellemeBitti));

            OnCompletedEventChange(true); // anaForm.DisableEnableComponents(true);
        }

        private string DegerGuncelle(string okunanSatir)
        {
            int indexDeger = okunanSatir.LastIndexOf(eskiDeger);
            if (indexDeger > -1)
            {
                okunanSatir = okunanSatir.Replace(eskiDeger, yeniDeger);
            }
            return okunanSatir;
        }

        protected virtual void OnStopEventChanged()
        {
            if (this.OnStopEvent != null)
                OnStopEvent();
        }

        protected virtual void OnLogEventChanged(LogEventArgs logEventArgs)
        {
            if (this.OnLogEvent != null)
                OnLogEvent(this, logEventArgs);
        }

        protected virtual void OnCompletedEventChange(bool enabled)
        {
            if (OnCompletedEvent != null)
                OnCompletedEvent(enabled);
        }
    }
}
