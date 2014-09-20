namespace ContentReplacer
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKlasor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUzantı = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnGozat = new System.Windows.Forms.Button();
            this.txtEskiDeger = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYeniDeger = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dlgKlasor = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgrsDurum = new System.Windows.Forms.ToolStripProgressBar();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoRecursive = new System.Windows.Forms.RadioButton();
            this.rdoTek = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klasör";
            // 
            // txtKlasor
            // 
            this.txtKlasor.Location = new System.Drawing.Point(73, 6);
            this.txtKlasor.Name = "txtKlasor";
            this.txtKlasor.Size = new System.Drawing.Size(277, 20);
            this.txtKlasor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uzantı";
            // 
            // txtUzantı
            // 
            this.txtUzantı.Location = new System.Drawing.Point(73, 33);
            this.txtUzantı.Name = "txtUzantı";
            this.txtUzantı.Size = new System.Drawing.Size(67, 20);
            this.txtUzantı.TabIndex = 2;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuncelle.Location = new System.Drawing.Point(321, 410);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 22);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Başlat";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnGozat
            // 
            this.btnGozat.Location = new System.Drawing.Point(361, 4);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(31, 23);
            this.btnGozat.TabIndex = 0;
            this.btnGozat.Text = "...";
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // txtEskiDeger
            // 
            this.txtEskiDeger.Location = new System.Drawing.Point(73, 59);
            this.txtEskiDeger.Name = "txtEskiDeger";
            this.txtEskiDeger.Size = new System.Drawing.Size(319, 20);
            this.txtEskiDeger.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Eski Değer";
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Location = new System.Drawing.Point(0, 0);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(386, 276);
            this.lstLog.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Update Log";
            // 
            // txtYeniDeger
            // 
            this.txtYeniDeger.Location = new System.Drawing.Point(73, 88);
            this.txtYeniDeger.Name = "txtYeniDeger";
            this.txtYeniDeger.Size = new System.Drawing.Size(319, 20);
            this.txtYeniDeger.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Yeni Değer";
            // 
            // dlgKlasor
            // 
            this.dlgKlasor.ShowNewFolderButton = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgrsDurum,
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(404, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prgrsDurum
            // 
            this.prgrsDurum.Name = "prgrsDurum";
            this.prgrsDurum.Size = new System.Drawing.Size(200, 16);
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(57, 17);
            this.lblDurum.Text = "lblDurum";
            // 
            // btnSifirla
            // 
            this.btnSifirla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSifirla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSifirla.Location = new System.Drawing.Point(240, 409);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(75, 23);
            this.btnSifirla.TabIndex = 8;
            this.btnSifirla.Text = "Sıfırla";
            this.btnSifirla.UseVisualStyleBackColor = true;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstLog);
            this.panel1.Location = new System.Drawing.Point(10, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 276);
            this.panel1.TabIndex = 18;
            // 
            // rdoRecursive
            // 
            this.rdoRecursive.AutoSize = true;
            this.rdoRecursive.Checked = true;
            this.rdoRecursive.Location = new System.Drawing.Point(146, 34);
            this.rdoRecursive.Name = "rdoRecursive";
            this.rdoRecursive.Size = new System.Drawing.Size(73, 17);
            this.rdoRecursive.TabIndex = 19;
            this.rdoRecursive.TabStop = true;
            this.rdoRecursive.Text = "Recursive";
            this.rdoRecursive.UseVisualStyleBackColor = true;
            // 
            // rdoTek
            // 
            this.rdoTek.AutoSize = true;
            this.rdoTek.Location = new System.Drawing.Point(225, 34);
            this.rdoTek.Name = "rdoTek";
            this.rdoTek.Size = new System.Drawing.Size(103, 17);
            this.rdoTek.TabIndex = 20;
            this.rdoTek.Text = "Tek Güncelleme";
            this.rdoTek.UseVisualStyleBackColor = true;
            // 
            // AnaForm
            // 
            this.AcceptButton = this.btnGuncelle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSifirla;
            this.ClientSize = new System.Drawing.Size(404, 462);
            this.Controls.Add(this.rdoTek);
            this.Controls.Add(this.rdoRecursive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSifirla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtYeniDeger);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEskiDeger);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGozat);
            this.Controls.Add(this.txtUzantı);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKlasor);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(420, 500);
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İçerik Güncelle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKlasor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUzantı;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.TextBox txtEskiDeger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYeniDeger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog dlgKlasor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prgrsDurum;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoRecursive;
        private System.Windows.Forms.RadioButton rdoTek;
    }
}

