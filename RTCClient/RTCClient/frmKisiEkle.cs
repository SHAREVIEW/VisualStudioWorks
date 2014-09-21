using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RTCClient
{
    public partial class frmKisiEkle : Form
    {
        public frmKisiEkle()
        {
            InitializeComponent();
            txtURI.Text = string.Empty;
        }

        public string URI
        {
            get { return txtURI.Text; }
        }
    }
}