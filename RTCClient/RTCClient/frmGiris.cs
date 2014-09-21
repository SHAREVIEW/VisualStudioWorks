using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RTCClient
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        public string URI
        {
            get { return txtURI.Text; }
        }

        public string Sunucu
        {
            get { return txtSunucu.Text; }
        }

        public string Transfer
        {
            get { return cmbTransfer.Text; }
        }

        // Kullanýcýya kolaylýk olmasý için son girilen bilgler registry de saklanýr. System.Win32 eklendi
        private void GirisForm_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\rtcclient"); // dizin varsa açýlýr,yoksa oluþturulur

            this.txtURI.Text = (String)rk.GetValue("uri", "sip uri");
            this.txtSunucu.Text = (String)rk.GetValue("sunucu", "sip sunucu");
            this.cmbTransfer.Text = (String)rk.GetValue("transfer", "TCP");
        }

        private void cmdTamam_Click(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\rtcclient");

            rk.SetValue("uri", this.URI);
            rk.SetValue("sunucu", this.Sunucu);
            rk.SetValue("transfer", this.Transfer);
        }

        private void cmbTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}