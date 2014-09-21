namespace AmbarTakip
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
            this.components = new System.ComponentModel.Container();
            this.btnMalzemeGiris = new System.Windows.Forms.Button();
            this.btnMalzemeYonetim = new System.Windows.Forms.Button();
            this.btnMalzemeArama = new System.Windows.Forms.Button();
            this.btnMalzemeIzleme = new System.Windows.Forms.Button();
            this.btnCPSKayit = new System.Windows.Forms.Button();
            this.btnUniteEkipman = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBugun = new System.Windows.Forms.Label();
            this.lblMalzeme = new System.Windows.Forms.Label();
            this.lblEkipman = new System.Windows.Forms.Label();
            this.lblUnite = new System.Windows.Forms.Label();
            this.lblCPS = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.yardýmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHakkýnda = new System.Windows.Forms.ToolStripMenuItem();
            this.dsAmbar = new AmbarTakip.AmbarTakipDataSet1();
            this.bsCPS = new System.Windows.Forms.BindingSource(this.components);
            this.bsUnite = new System.Windows.Forms.BindingSource(this.components);
            this.bsEkipman = new System.Windows.Forms.BindingSource(this.components);
            this.bsMalzeme = new System.Windows.Forms.BindingSource(this.components);
            this.cPSTableAdapter = new AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter();
            this.uniteTableAdapter = new AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter();
            this.ekipmanTableAdapter = new AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter();
            this.malzemeTableAdapter = new AmbarTakip.AmbarTakipDataSet1TableAdapters.MalzemeTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMalzeme)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMalzemeGiris
            // 
            this.btnMalzemeGiris.Location = new System.Drawing.Point(6, 19);
            this.btnMalzemeGiris.Name = "btnMalzemeGiris";
            this.btnMalzemeGiris.Size = new System.Drawing.Size(203, 26);
            this.btnMalzemeGiris.TabIndex = 0;
            this.btnMalzemeGiris.Text = "Malzeme Giriþ (F1)";
            this.btnMalzemeGiris.UseVisualStyleBackColor = true;
            this.btnMalzemeGiris.Click += new System.EventHandler(this.btnMalzemeGiris_Click);
            // 
            // btnMalzemeYonetim
            // 
            this.btnMalzemeYonetim.Location = new System.Drawing.Point(6, 51);
            this.btnMalzemeYonetim.Name = "btnMalzemeYonetim";
            this.btnMalzemeYonetim.Size = new System.Drawing.Size(203, 26);
            this.btnMalzemeYonetim.TabIndex = 1;
            this.btnMalzemeYonetim.Text = "Malzeme Yönetim (F2)\r\n";
            this.btnMalzemeYonetim.UseVisualStyleBackColor = true;
            this.btnMalzemeYonetim.Click += new System.EventHandler(this.btnMalzemeCikis_Click);
            // 
            // btnMalzemeArama
            // 
            this.btnMalzemeArama.Location = new System.Drawing.Point(6, 83);
            this.btnMalzemeArama.Name = "btnMalzemeArama";
            this.btnMalzemeArama.Size = new System.Drawing.Size(203, 26);
            this.btnMalzemeArama.TabIndex = 2;
            this.btnMalzemeArama.Text = "Malzeme Arama (F3)";
            this.btnMalzemeArama.UseVisualStyleBackColor = true;
            this.btnMalzemeArama.Click += new System.EventHandler(this.btnMalzemeArama_Click);
            // 
            // btnMalzemeIzleme
            // 
            this.btnMalzemeIzleme.Location = new System.Drawing.Point(6, 115);
            this.btnMalzemeIzleme.Name = "btnMalzemeIzleme";
            this.btnMalzemeIzleme.Size = new System.Drawing.Size(203, 26);
            this.btnMalzemeIzleme.TabIndex = 3;
            this.btnMalzemeIzleme.Text = "Malzeme Ýzleme (F4)";
            this.btnMalzemeIzleme.UseVisualStyleBackColor = true;
            this.btnMalzemeIzleme.Click += new System.EventHandler(this.btnMalzemeIzleme_Click);
            // 
            // btnCPSKayit
            // 
            this.btnCPSKayit.Location = new System.Drawing.Point(6, 190);
            this.btnCPSKayit.Name = "btnCPSKayit";
            this.btnCPSKayit.Size = new System.Drawing.Size(203, 26);
            this.btnCPSKayit.TabIndex = 5;
            this.btnCPSKayit.Text = "CPS Kayýt (F6)";
            this.btnCPSKayit.UseVisualStyleBackColor = true;
            this.btnCPSKayit.Click += new System.EventHandler(this.btnCPSKayit_Click);
            // 
            // btnUniteEkipman
            // 
            this.btnUniteEkipman.Location = new System.Drawing.Point(6, 147);
            this.btnUniteEkipman.Name = "btnUniteEkipman";
            this.btnUniteEkipman.Size = new System.Drawing.Size(203, 26);
            this.btnUniteEkipman.TabIndex = 4;
            this.btnUniteEkipman.Text = "Ünite ve Ekipman Ekleme (F5)";
            this.btnUniteEkipman.UseVisualStyleBackColor = true;
            this.btnUniteEkipman.Click += new System.EventHandler(this.btnUniteEkipman_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMalzemeGiris);
            this.groupBox1.Controls.Add(this.btnMalzemeYonetim);
            this.groupBox1.Controls.Add(this.btnUniteEkipman);
            this.groupBox1.Controls.Add(this.btnMalzemeArama);
            this.groupBox1.Controls.Add(this.btnCPSKayit);
            this.groupBox1.Controls.Add(this.btnMalzemeIzleme);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 223);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ýþlemler";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBugun);
            this.groupBox2.Controls.Add(this.lblMalzeme);
            this.groupBox2.Controls.Add(this.lblEkipman);
            this.groupBox2.Controls.Add(this.lblUnite);
            this.groupBox2.Controls.Add(this.lblCPS);
            this.groupBox2.Location = new System.Drawing.Point(240, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 223);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ambar Bilgileri";
            // 
            // lblBugun
            // 
            this.lblBugun.AutoSize = true;
            this.lblBugun.Location = new System.Drawing.Point(6, 19);
            this.lblBugun.Name = "lblBugun";
            this.lblBugun.Size = new System.Drawing.Size(35, 13);
            this.lblBugun.TabIndex = 4;
            this.lblBugun.Text = "label1";
            // 
            // lblMalzeme
            // 
            this.lblMalzeme.AutoSize = true;
            this.lblMalzeme.Location = new System.Drawing.Point(6, 147);
            this.lblMalzeme.Name = "lblMalzeme";
            this.lblMalzeme.Size = new System.Drawing.Size(35, 13);
            this.lblMalzeme.TabIndex = 3;
            this.lblMalzeme.Text = "label1";
            // 
            // lblEkipman
            // 
            this.lblEkipman.AutoSize = true;
            this.lblEkipman.Location = new System.Drawing.Point(6, 115);
            this.lblEkipman.Name = "lblEkipman";
            this.lblEkipman.Size = new System.Drawing.Size(35, 13);
            this.lblEkipman.TabIndex = 2;
            this.lblEkipman.Text = "label1";
            // 
            // lblUnite
            // 
            this.lblUnite.AutoSize = true;
            this.lblUnite.Location = new System.Drawing.Point(6, 83);
            this.lblUnite.Name = "lblUnite";
            this.lblUnite.Size = new System.Drawing.Size(35, 13);
            this.lblUnite.TabIndex = 1;
            this.lblUnite.Text = "label1";
            // 
            // lblCPS
            // 
            this.lblCPS.AutoSize = true;
            this.lblCPS.Location = new System.Drawing.Point(6, 51);
            this.lblCPS.Name = "lblCPS";
            this.lblCPS.Size = new System.Drawing.Size(35, 13);
            this.lblCPS.TabIndex = 0;
            this.lblCPS.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.yardýmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKapat});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // mnuKapat
            // 
            this.mnuKapat.Name = "mnuKapat";
            this.mnuKapat.Size = new System.Drawing.Size(113, 22);
            this.mnuKapat.Text = "Kapat";
            this.mnuKapat.Click += new System.EventHandler(this.mnuKapat_Click);
            // 
            // yardýmToolStripMenuItem
            // 
            this.yardýmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHakkýnda});
            this.yardýmToolStripMenuItem.Name = "yardýmToolStripMenuItem";
            this.yardýmToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.yardýmToolStripMenuItem.Text = "Yardým";
            // 
            // mnuHakkýnda
            // 
            this.mnuHakkýnda.Name = "mnuHakkýnda";
            this.mnuHakkýnda.Size = new System.Drawing.Size(128, 22);
            this.mnuHakkýnda.Text = "Hakkýnda";
            this.mnuHakkýnda.Click += new System.EventHandler(this.mnuHakkýnda_Click);
            // 
            // dsAmbar
            // 
            this.dsAmbar.DataSetName = "AmbarTakipDataSet1";
            this.dsAmbar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsCPS
            // 
            this.bsCPS.DataMember = "CPS";
            this.bsCPS.DataSource = this.dsAmbar;
            // 
            // bsUnite
            // 
            this.bsUnite.DataMember = "Unite";
            this.bsUnite.DataSource = this.dsAmbar;
            // 
            // bsEkipman
            // 
            this.bsEkipman.DataMember = "Ekipman";
            this.bsEkipman.DataSource = this.dsAmbar;
            // 
            // bsMalzeme
            // 
            this.bsMalzeme.DataMember = "Malzeme";
            this.bsMalzeme.DataSource = this.dsAmbar;
            // 
            // cPSTableAdapter
            // 
            this.cPSTableAdapter.ClearBeforeFill = true;
            // 
            // uniteTableAdapter
            // 
            this.uniteTableAdapter.ClearBeforeFill = true;
            // 
            // ekipmanTableAdapter
            // 
            this.ekipmanTableAdapter.ClearBeforeFill = true;
            // 
            // malzemeTableAdapter
            // 
            this.malzemeTableAdapter.ClearBeforeFill = true;
            // 
            // AnaPencere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 260);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AnaPencere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambar Takip 1.0 Beta2";
            this.Activated += new System.EventHandler(this.AnaPencere_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnaPencere_KeyDown);
            this.Load += new System.EventHandler(this.AnaPencere_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMalzeme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMalzemeGiris;
        private System.Windows.Forms.Button btnMalzemeYonetim;
        private System.Windows.Forms.Button btnMalzemeArama;
        private System.Windows.Forms.Button btnMalzemeIzleme;
        private System.Windows.Forms.Button btnCPSKayit;
        private System.Windows.Forms.Button btnUniteEkipman;
        private AmbarTakipDataSet1 dsAmbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMalzeme;
        private System.Windows.Forms.Label lblEkipman;
        private System.Windows.Forms.Label lblUnite;
        private System.Windows.Forms.Label lblCPS;
        private System.Windows.Forms.Label lblBugun;
        private System.Windows.Forms.BindingSource bsCPS;
        private System.Windows.Forms.BindingSource bsUnite;
        private System.Windows.Forms.BindingSource bsEkipman;
        private System.Windows.Forms.BindingSource bsMalzeme;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter cPSTableAdapter;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter uniteTableAdapter;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter ekipmanTableAdapter;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.MalzemeTableAdapter malzemeTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuKapat;
        private System.Windows.Forms.ToolStripMenuItem yardýmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHakkýnda;
    }
}