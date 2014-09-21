namespace RTCClient
{
    partial class frmGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSunucu = new System.Windows.Forms.TextBox();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.cmbTransfer = new System.Windows.Forms.ComboBox();
            this.cmdTamam = new System.Windows.Forms.Button();
            this.cmdIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanýcý URI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sunucu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transfer";
            // 
            // txtSunucu
            // 
            this.txtSunucu.Location = new System.Drawing.Point(86, 33);
            this.txtSunucu.Name = "txtSunucu";
            this.txtSunucu.Size = new System.Drawing.Size(244, 20);
            this.txtSunucu.TabIndex = 5;
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(86, 6);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(244, 20);
            this.txtURI.TabIndex = 4;
            // 
            // cmbTransfer
            // 
            this.cmbTransfer.FormattingEnabled = true;
            this.cmbTransfer.Items.AddRange(new object[] {
            "TCP",
            "TLS",
            "UDP"});
            this.cmbTransfer.Location = new System.Drawing.Point(86, 59);
            this.cmbTransfer.Name = "cmbTransfer";
            this.cmbTransfer.Size = new System.Drawing.Size(121, 21);
            this.cmbTransfer.TabIndex = 6;
            this.cmbTransfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTransfer_KeyPress);
            // 
            // cmdTamam
            // 
            this.cmdTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdTamam.Location = new System.Drawing.Point(174, 96);
            this.cmdTamam.Name = "cmdTamam";
            this.cmdTamam.Size = new System.Drawing.Size(75, 23);
            this.cmdTamam.TabIndex = 6;
            this.cmdTamam.Text = "Tamam";
            this.cmdTamam.UseVisualStyleBackColor = true;
            this.cmdTamam.Click += new System.EventHandler(this.cmdTamam_Click);
            // 
            // cmdIptal
            // 
            this.cmdIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdIptal.Location = new System.Drawing.Point(255, 96);
            this.cmdIptal.Name = "cmdIptal";
            this.cmdIptal.Size = new System.Drawing.Size(75, 23);
            this.cmdIptal.TabIndex = 7;
            this.cmdIptal.Text = "Ýptal";
            this.cmdIptal.UseVisualStyleBackColor = true;
            // 
            // frmGiris
            // 
            this.AcceptButton = this.cmdTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdIptal;
            this.ClientSize = new System.Drawing.Size(342, 123);
            this.ControlBox = false;
            this.Controls.Add(this.cmdIptal);
            this.Controls.Add(this.cmdTamam);
            this.Controls.Add(this.cmbTransfer);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.txtSunucu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kullanýcý Giriþi";
            this.Load += new System.EventHandler(this.GirisForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSunucu;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.ComboBox cmbTransfer;
        private System.Windows.Forms.Button cmdTamam;
        private System.Windows.Forms.Button cmdIptal;
    }
}