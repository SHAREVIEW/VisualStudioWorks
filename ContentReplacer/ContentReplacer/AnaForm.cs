using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.IO;
using ContentReplacer.Properties;

namespace ContentReplacer
{
    public partial class AnaForm : Form
    {
        UpdateThread thread;

        public AnaForm()
        {
            InitializeComponent();
        }

        #region Events
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.IsParcasi.IsAlive)
            {
                thread.IsParcasi.Abort();
                StartOperations();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtKlasor.Text.Trim()) ||
                    !string.IsNullOrEmpty(txtUzantı.Text.Trim()) ||
                    !string.IsNullOrEmpty(txtEskiDeger.Text.Trim()) ||
                    !string.IsNullOrEmpty(txtYeniDeger.Text.Trim()))
                {
                    StopOperations();

                    thread = new UpdateThread(txtKlasor.Text, txtUzantı.Text, txtEskiDeger.Text,
                        txtYeniDeger.Text, rdoRecursive.Checked ? true : false);
                    
                    thread.OnLogEvent += this.Log;
                    thread.OnStopEvent += this.StopOperations;
                    thread.OnCompletedEvent += this.DisableEnableComponents;

                    thread.IsParcasi.Start();
                }
                else
                {
                    MessageBox.Show(this, Properties.Resources.strEksikbilgi, Properties.Resources.strHataCaption, MessageBoxButtons.OK);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            StartOperations();
        }
        
        private void btnGozat_Click(object sender, EventArgs e)
        {
            if (dlgKlasor.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlgKlasor.SelectedPath))
                    txtKlasor.Text = dlgKlasor.SelectedPath;
            }
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            StartOperations();
        }
        #endregion

        #region Private Methods
        public void DisableEnableComponents(bool enabled)
        {
            txtYeniDeger.Enabled = enabled;
            txtUzantı.Enabled = enabled;
            txtKlasor.Enabled = enabled;
            txtEskiDeger.Enabled = enabled;
            btnGozat.Enabled = enabled;
            btnGuncelle.Enabled = enabled;
            btnSifirla.Enabled = enabled;
            rdoRecursive.Enabled = enabled;
            rdoTek.Enabled = enabled;
        }

        public void Log(object sender, LogEventArgs args)
        {
            if (args.DosyaSayisi == 0)
            {
                prgrsDurum.Minimum = 0;
                prgrsDurum.Maximum = args.DosyaSayisi;
                prgrsDurum.Step = 1;
            }
            else if (args.DosyaSayisi >= 0)
            {
                prgrsDurum.PerformStep();
                ListeyeEkle(args.LogMessage);
                lblDurum.Text = (args.DosyaSayisi + 1) + " / " + args.DosyaSayisi;
            }
        }

        private void ListeyeEkle(string durum)
        {
            lstLog.Items.Add(durum);
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
        }

        private void StartOperations()
        {
            txtKlasor.Text = ConfigurationSettings.AppSettings[Resources.cfgKlasor]; ;
            txtUzantı.Text = ConfigurationSettings.AppSettings[Resources.cfgUzanti]; ;
            txtEskiDeger.Text = ConfigurationSettings.AppSettings[Resources.cfgEskiDeger];
            txtYeniDeger.Text = ConfigurationSettings.AppSettings[Resources.cfgYeniDeger];

            this.btnGuncelle.Text = Resources.btnBaslatText;
            lblDurum.Text = "0 / 0";
            prgrsDurum.Value = 0;
            lstLog.Items.Clear();
            DisableEnableComponents(true);
            this.ActiveControl = btnGozat;
        }

        private void StopOperations()
        {
            DisableEnableComponents(true);
            this.btnGuncelle.Text = Resources.btnDurdurText;
        }
	    #endregion
    }
}
