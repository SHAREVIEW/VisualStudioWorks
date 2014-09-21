namespace BTChat
{
    partial class AnaPencere
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaPencere));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.lblArastirma = new System.Windows.Forms.Label();
            this.btnArastir = new System.Windows.Forms.Button();
            this.cmbAygitlar = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstIstemciler = new System.Windows.Forms.ListBox();
            this.lblIstemciSayisi = new System.Windows.Forms.Label();
            this.txtGelenMesajlar = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtGidenMesajlar = new System.Windows.Forms.RichTextBox();
            this.lblMesajlasma = new System.Windows.Forms.Label();
            this.btnGonder = new System.Windows.Forms.Button();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaglan);
            this.groupBox1.Controls.Add(this.lblArastirma);
            this.groupBox1.Controls.Add(this.btnArastir);
            this.groupBox1.Controls.Add(this.cmbAygitlar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bluetooth Aygýtlarý";
            // 
            // btnBaglan
            // 
            this.btnBaglan.Location = new System.Drawing.Point(244, 18);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(57, 23);
            this.btnBaglan.TabIndex = 2;
            this.btnBaglan.Text = "Baðlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // lblArastirma
            // 
            this.lblArastirma.AutoSize = true;
            this.lblArastirma.Location = new System.Drawing.Point(4, 76);
            this.lblArastirma.Name = "lblArastirma";
            this.lblArastirma.Size = new System.Drawing.Size(185, 13);
            this.lblArastirma.TabIndex = 2;
            this.lblArastirma.Text = "Durum: Aygýt araþtýrma için bekleniyor.";
            // 
            // btnArastir
            // 
            this.btnArastir.Location = new System.Drawing.Point(7, 47);
            this.btnArastir.Name = "btnArastir";
            this.btnArastir.Size = new System.Drawing.Size(69, 23);
            this.btnArastir.TabIndex = 0;
            this.btnArastir.Text = "Araþtýr";
            this.btnArastir.UseVisualStyleBackColor = true;
            this.btnArastir.Click += new System.EventHandler(this.btnArastir_Click);
            // 
            // cmbAygitlar
            // 
            this.cmbAygitlar.FormattingEnabled = true;
            this.cmbAygitlar.Location = new System.Drawing.Point(7, 20);
            this.cmbAygitlar.Name = "cmbAygitlar";
            this.cmbAygitlar.Size = new System.Drawing.Size(231, 21);
            this.cmbAygitlar.TabIndex = 1;
            this.cmbAygitlar.Text = "Aygýt Seçin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstIstemciler);
            this.groupBox2.Controls.Add(this.lblIstemciSayisi);
            this.groupBox2.Controls.Add(this.txtGelenMesajlar);
            this.groupBox2.Location = new System.Drawing.Point(325, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 338);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gelen Mesajlar";
            // 
            // lstIstemciler
            // 
            this.lstIstemciler.FormattingEnabled = true;
            this.lstIstemciler.Location = new System.Drawing.Point(347, 32);
            this.lstIstemciler.Name = "lstIstemciler";
            this.lstIstemciler.Size = new System.Drawing.Size(177, 290);
            this.lstIstemciler.TabIndex = 6;
            // 
            // lblIstemciSayisi
            // 
            this.lblIstemciSayisi.AutoSize = true;
            this.lblIstemciSayisi.Location = new System.Drawing.Point(344, 16);
            this.lblIstemciSayisi.Name = "lblIstemciSayisi";
            this.lblIstemciSayisi.Size = new System.Drawing.Size(140, 13);
            this.lblIstemciSayisi.TabIndex = 3;
            this.lblIstemciSayisi.Text = "Sunucuya Baðlý Ýstemciler: 0";
            // 
            // txtGelenMesajlar
            // 
            this.txtGelenMesajlar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtGelenMesajlar.Location = new System.Drawing.Point(6, 32);
            this.txtGelenMesajlar.Name = "txtGelenMesajlar";
            this.txtGelenMesajlar.ReadOnly = true;
            this.txtGelenMesajlar.Size = new System.Drawing.Size(335, 290);
            this.txtGelenMesajlar.TabIndex = 5;
            this.txtGelenMesajlar.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtGidenMesajlar);
            this.groupBox3.Controls.Add(this.lblMesajlasma);
            this.groupBox3.Controls.Add(this.btnGonder);
            this.groupBox3.Controls.Add(this.txtMesaj);
            this.groupBox3.Location = new System.Drawing.Point(12, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 219);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mesaj Gönder";
            // 
            // txtGidenMesajlar
            // 
            this.txtGidenMesajlar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtGidenMesajlar.Location = new System.Drawing.Point(6, 19);
            this.txtGidenMesajlar.Name = "txtGidenMesajlar";
            this.txtGidenMesajlar.ReadOnly = true;
            this.txtGidenMesajlar.Size = new System.Drawing.Size(289, 140);
            this.txtGidenMesajlar.TabIndex = 16;
            this.txtGidenMesajlar.Text = "";
            // 
            // lblMesajlasma
            // 
            this.lblMesajlasma.AutoSize = true;
            this.lblMesajlasma.Location = new System.Drawing.Point(2, 198);
            this.lblMesajlasma.Name = "lblMesajlasma";
            this.lblMesajlasma.Size = new System.Drawing.Size(105, 13);
            this.lblMesajlasma.TabIndex = 15;
            this.lblMesajlasma.Text = "Durum: Baðlantý yok.";
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(248, 163);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(53, 23);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(6, 165);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(236, 20);
            this.txtMesaj.TabIndex = 3;
            this.txtMesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMesaj_KeyDown);
            // 
            // AnaPencere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 362);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaPencere";
            this.Text = "Mavi.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnArastir;
        private System.Windows.Forms.ComboBox cmbAygitlar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtGelenMesajlar;
        private System.Windows.Forms.Label lblArastirma;
        private System.Windows.Forms.Label lblIstemciSayisi;
        private System.Windows.Forms.ListBox lstIstemciler;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtGidenMesajlar;
        private System.Windows.Forms.Label lblMesajlasma;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Button btnBaglan;
    }
}

