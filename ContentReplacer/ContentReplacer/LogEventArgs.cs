using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentReplacer
{
    public class LogEventArgs : EventArgs 
    {
        private string logMessage;
        private int dosyaSayisi;

        public string LogMessage
        { 
            get { return this.logMessage; }
            set { this.logMessage = value; }
        }

        public int DosyaSayisi
        {
            get { return this.dosyaSayisi; }
            set { this.dosyaSayisi = value; }
        }

        public LogEventArgs(string message)
        {
            this.logMessage = message;
            this.dosyaSayisi = -1;
        }

        public LogEventArgs(string message, int dosyaSayisi)
        {
            this.logMessage = message;
            this.dosyaSayisi = dosyaSayisi;
        }
    }
}
