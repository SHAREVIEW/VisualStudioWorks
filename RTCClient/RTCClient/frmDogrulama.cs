using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RTCClient
{
    public partial class frmDogrulama : Form
    {
        public frmDogrulama()
        {
            InitializeComponent();

            // yeni klas�r olu�tur veya a�
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\rtcpresence");

            // bilgiler varsa al yok default de�erler d�ner..
            this.txtURI.Text = (String)rk.GetValue("uri", "sip uri");
            this.txtKimlik.Text = (String)rk.GetValue("kullanici", "sip kullanici");
        }

        public string URI
        {
            get { return txtURI.Text; }
        }

        public string Kimlik
        {
            get { return txtKimlik.Text; }
        }

        public string Sifre
        {
            get { return txtSifre.Text; }
        }

        private void cmdTamam_Click(object sender, EventArgs e)
        {
            // klas�r� a�
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\rtcpresence");

            rk.SetValue("uri", this.URI);
            rk.SetValue("kullanici", this.Kimlik);
        }
    }
}