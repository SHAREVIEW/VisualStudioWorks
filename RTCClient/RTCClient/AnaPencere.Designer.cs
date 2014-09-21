namespace RTCClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaPencere));
            this.contextTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuMesajGonder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuVideoSes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuKisiSil = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuOzellikler = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.ntfyRTCClient = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOturumAc = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuOturumKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDurumum = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCevrimici = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMesgul = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDonecek = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDisarida = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTelefonda = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuYemekte = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCevrimdisi = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.imgResimler = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDosya = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOturumAc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOturumKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDurumum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCevrimici = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMesgul = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDonecek = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisarida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTelefonda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYemekte = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCevrimdisi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEylemler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKisiEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvKisiler = new System.Windows.Forms.TreeView();
            this.contextTreeView.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextNotifyIcon.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextTreeView
            // 
            this.contextTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuMesajGonder,
            this.cmnuVideoSes,
            this.cmnuKisiSil,
            this.cmnuOzellikler});
            this.contextTreeView.Name = "contextMenuStrip1";
            this.contextTreeView.Size = new System.Drawing.Size(217, 92);
            // 
            // cmnuMesajGonder
            // 
            this.cmnuMesajGonder.Name = "cmnuMesajGonder";
            this.cmnuMesajGonder.Size = new System.Drawing.Size(216, 22);
            this.cmnuMesajGonder.Text = "Mesaj Gönder";
            this.cmnuMesajGonder.Click += new System.EventHandler(this.cmnuMesajGonder_Click);
            // 
            // cmnuVideoSes
            // 
            this.cmnuVideoSes.Name = "cmnuVideoSes";
            this.cmnuVideoSes.Size = new System.Drawing.Size(216, 22);
            this.cmnuVideoSes.Text = "Video/Ses Görüþmesi Baþlat";
            this.cmnuVideoSes.Click += new System.EventHandler(this.cmnuVideoSes_Click);
            // 
            // cmnuKisiSil
            // 
            this.cmnuKisiSil.Name = "cmnuKisiSil";
            this.cmnuKisiSil.Size = new System.Drawing.Size(216, 22);
            this.cmnuKisiSil.Text = "Kiþiyi Sil";
            this.cmnuKisiSil.Click += new System.EventHandler(this.cmnuKisiSil_Click);
            // 
            // cmnuOzellikler
            // 
            this.cmnuOzellikler.Name = "cmnuOzellikler";
            this.cmnuOzellikler.Size = new System.Drawing.Size(216, 22);
            this.cmnuOzellikler.Text = "Özellikler";
            this.cmnuOzellikler.Click += new System.EventHandler(this.mnuOzellikler_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(363, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "Çevrimdýþý";
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(55, 17);
            this.lblDurum.Text = "Çevrimdýþý";
            // 
            // stslblDurum
            // 
            this.stslblDurum.Name = "stslblDurum";
            this.stslblDurum.Size = new System.Drawing.Size(55, 17);
            this.stslblDurum.Text = "Çevrimdýþý";
            // 
            // ntfyRTCClient
            // 
            this.ntfyRTCClient.ContextMenuStrip = this.contextNotifyIcon;
            this.ntfyRTCClient.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfyRTCClient.Icon")));
            this.ntfyRTCClient.Text = "RTCClient";
            this.ntfyRTCClient.Visible = true;
            this.ntfyRTCClient.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextNotifyIcon
            // 
            this.contextNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOturumAc,
            this.cmnuOturumKapat,
            this.cmnuDurumum,
            this.cmnuCikis});
            this.contextNotifyIcon.Name = "contextNotifyIcon";
            this.contextNotifyIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextNotifyIcon.Size = new System.Drawing.Size(159, 92);
            // 
            // cmnuOturumAc
            // 
            this.cmnuOturumAc.Name = "cmnuOturumAc";
            this.cmnuOturumAc.Size = new System.Drawing.Size(158, 22);
            this.cmnuOturumAc.Text = "Oturum Aç";
            this.cmnuOturumAc.Click += new System.EventHandler(this.mnuOturumAc_Click);
            // 
            // cmnuOturumKapat
            // 
            this.cmnuOturumKapat.Name = "cmnuOturumKapat";
            this.cmnuOturumKapat.Size = new System.Drawing.Size(158, 22);
            this.cmnuOturumKapat.Text = "Oturumu Kapat";
            this.cmnuOturumKapat.Click += new System.EventHandler(this.mnuOturumKapat_Click);
            // 
            // cmnuDurumum
            // 
            this.cmnuDurumum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuCevrimici,
            this.cmnuMesgul,
            this.cmnuDonecek,
            this.cmnuDisarida,
            this.cmnuTelefonda,
            this.cmnuYemekte,
            this.cmnuCevrimdisi});
            this.cmnuDurumum.Name = "cmnuDurumum";
            this.cmnuDurumum.Size = new System.Drawing.Size(158, 22);
            this.cmnuDurumum.Text = "Durumum";
            // 
            // cmnuCevrimici
            // 
            this.cmnuCevrimici.Name = "cmnuCevrimici";
            this.cmnuCevrimici.Size = new System.Drawing.Size(168, 22);
            this.cmnuCevrimici.Text = "Çevrimiçi";
            this.cmnuCevrimici.Click += new System.EventHandler(this.mnuCevrimici_Click);
            // 
            // cmnuMesgul
            // 
            this.cmnuMesgul.Name = "cmnuMesgul";
            this.cmnuMesgul.Size = new System.Drawing.Size(168, 22);
            this.cmnuMesgul.Text = "Meþgul";
            this.cmnuMesgul.Click += new System.EventHandler(this.mnuMesgul_Click);
            // 
            // cmnuDonecek
            // 
            this.cmnuDonecek.Name = "cmnuDonecek";
            this.cmnuDonecek.Size = new System.Drawing.Size(168, 22);
            this.cmnuDonecek.Text = "Hemen Dönecek";
            this.cmnuDonecek.Click += new System.EventHandler(this.mnuDonecek_Click);
            // 
            // cmnuDisarida
            // 
            this.cmnuDisarida.Name = "cmnuDisarida";
            this.cmnuDisarida.Size = new System.Drawing.Size(168, 22);
            this.cmnuDisarida.Text = "Dýþarýda";
            this.cmnuDisarida.Click += new System.EventHandler(this.mnuDisarida_Click);
            // 
            // cmnuTelefonda
            // 
            this.cmnuTelefonda.Name = "cmnuTelefonda";
            this.cmnuTelefonda.Size = new System.Drawing.Size(168, 22);
            this.cmnuTelefonda.Text = "Telefonda";
            this.cmnuTelefonda.Click += new System.EventHandler(this.mnuTelefonda_Click);
            // 
            // cmnuYemekte
            // 
            this.cmnuYemekte.Name = "cmnuYemekte";
            this.cmnuYemekte.Size = new System.Drawing.Size(168, 22);
            this.cmnuYemekte.Text = "Yemekte";
            this.cmnuYemekte.Click += new System.EventHandler(this.mnuYemekte_Click);
            // 
            // cmnuCevrimdisi
            // 
            this.cmnuCevrimdisi.Name = "cmnuCevrimdisi";
            this.cmnuCevrimdisi.Size = new System.Drawing.Size(168, 22);
            this.cmnuCevrimdisi.Text = "Çevrimdýþý Göster";
            this.cmnuCevrimdisi.Click += new System.EventHandler(this.mnuCevrimdisi_Click);
            // 
            // cmnuCikis
            // 
            this.cmnuCikis.Name = "cmnuCikis";
            this.cmnuCikis.Size = new System.Drawing.Size(158, 22);
            this.cmnuCikis.Text = "Çýkýþ";
            this.cmnuCikis.Click += new System.EventHandler(this.cmnuCikis_Click);
            // 
            // imgResimler
            // 
            this.imgResimler.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgResimler.ImageStream")));
            this.imgResimler.TransparentColor = System.Drawing.Color.White;
            this.imgResimler.Images.SetKeyName(0, "right.png");
            this.imgResimler.Images.SetKeyName(1, "wlm8_glass_vert.ico");
            this.imgResimler.Images.SetKeyName(2, "wlm8_occupe.ico");
            this.imgResimler.Images.SetKeyName(3, "wlm8_glass_minute.ico");
            this.imgResimler.Images.SetKeyName(4, "wlm8_glass_absent.ico");
            this.imgResimler.Images.SetKeyName(5, "wlm8_telephone.ico");
            this.imgResimler.Images.SetKeyName(6, "wlm8_manger.ico");
            this.imgResimler.Images.SetKeyName(7, "wlm8_hors_ligne.ico");
            this.imgResimler.Images.SetKeyName(8, "down.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDosya,
            this.mnuEylemler});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(363, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDosya
            // 
            this.mnuDosya.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOturumAc,
            this.mnuOturumKapat,
            this.toolStripMenuItem1,
            this.mnuDurumum,
            this.toolStripMenuItem2,
            this.mnuKapat});
            this.mnuDosya.Name = "mnuDosya";
            this.mnuDosya.Size = new System.Drawing.Size(49, 20);
            this.mnuDosya.Text = "&Dosya";
            // 
            // mnuOturumAc
            // 
            this.mnuOturumAc.Name = "mnuOturumAc";
            this.mnuOturumAc.Size = new System.Drawing.Size(149, 22);
            this.mnuOturumAc.Text = "Oturum Aç";
            this.mnuOturumAc.Click += new System.EventHandler(this.mnuOturumAc_Click);
            // 
            // mnuOturumKapat
            // 
            this.mnuOturumKapat.Name = "mnuOturumKapat";
            this.mnuOturumKapat.Size = new System.Drawing.Size(149, 22);
            this.mnuOturumKapat.Text = "OturumKapat";
            this.mnuOturumKapat.Click += new System.EventHandler(this.mnuOturumKapat_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // mnuDurumum
            // 
            this.mnuDurumum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCevrimici,
            this.mnuMesgul,
            this.mnuDonecek,
            this.mnuDisarida,
            this.mnuTelefonda,
            this.mnuYemekte,
            this.mnuCevrimdisi});
            this.mnuDurumum.Name = "mnuDurumum";
            this.mnuDurumum.Size = new System.Drawing.Size(149, 22);
            this.mnuDurumum.Text = "Durumum";
            // 
            // mnuCevrimici
            // 
            this.mnuCevrimici.Name = "mnuCevrimici";
            this.mnuCevrimici.Size = new System.Drawing.Size(162, 22);
            this.mnuCevrimici.Text = "Çevrimiçi";
            this.mnuCevrimici.Click += new System.EventHandler(this.mnuCevrimici_Click);
            // 
            // mnuMesgul
            // 
            this.mnuMesgul.Name = "mnuMesgul";
            this.mnuMesgul.Size = new System.Drawing.Size(162, 22);
            this.mnuMesgul.Text = "Meþgul";
            this.mnuMesgul.Click += new System.EventHandler(this.mnuMesgul_Click);
            // 
            // mnuDonecek
            // 
            this.mnuDonecek.Name = "mnuDonecek";
            this.mnuDonecek.Size = new System.Drawing.Size(162, 22);
            this.mnuDonecek.Text = "Hemen Dönecek";
            this.mnuDonecek.Click += new System.EventHandler(this.mnuDonecek_Click);
            // 
            // mnuDisarida
            // 
            this.mnuDisarida.Name = "mnuDisarida";
            this.mnuDisarida.Size = new System.Drawing.Size(162, 22);
            this.mnuDisarida.Text = "Dýþarýda";
            this.mnuDisarida.Click += new System.EventHandler(this.mnuDisarida_Click);
            // 
            // mnuTelefonda
            // 
            this.mnuTelefonda.Name = "mnuTelefonda";
            this.mnuTelefonda.Size = new System.Drawing.Size(162, 22);
            this.mnuTelefonda.Text = "Telefonda";
            this.mnuTelefonda.Click += new System.EventHandler(this.mnuTelefonda_Click);
            // 
            // mnuYemekte
            // 
            this.mnuYemekte.Name = "mnuYemekte";
            this.mnuYemekte.Size = new System.Drawing.Size(162, 22);
            this.mnuYemekte.Text = "Yemekte";
            this.mnuYemekte.Click += new System.EventHandler(this.mnuYemekte_Click);
            // 
            // mnuCevrimdisi
            // 
            this.mnuCevrimdisi.Name = "mnuCevrimdisi";
            this.mnuCevrimdisi.Size = new System.Drawing.Size(162, 22);
            this.mnuCevrimdisi.Text = "Çevrimdýþý";
            this.mnuCevrimdisi.Click += new System.EventHandler(this.mnuCevrimdisi_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 6);
            // 
            // mnuKapat
            // 
            this.mnuKapat.Name = "mnuKapat";
            this.mnuKapat.Size = new System.Drawing.Size(149, 22);
            this.mnuKapat.Text = "Kapat";
            this.mnuKapat.Click += new System.EventHandler(this.mnuKapat_Click);
            // 
            // mnuEylemler
            // 
            this.mnuEylemler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKisiEkle});
            this.mnuEylemler.Name = "mnuEylemler";
            this.mnuEylemler.Size = new System.Drawing.Size(59, 20);
            this.mnuEylemler.Text = "Eylemler";
            // 
            // mnuKisiEkle
            // 
            this.mnuKisiEkle.Name = "mnuKisiEkle";
            this.mnuKisiEkle.Size = new System.Drawing.Size(122, 22);
            this.mnuKisiEkle.Text = "Kiþi Ekle";
            this.mnuKisiEkle.Click += new System.EventHandler(this.mnuKisiEkle_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tvKisiler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 424);
            this.panel1.TabIndex = 4;
            // 
            // tvKisiler
            // 
            this.tvKisiler.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tvKisiler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvKisiler.ContextMenuStrip = this.contextTreeView;
            this.tvKisiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvKisiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tvKisiler.ForeColor = System.Drawing.Color.Black;
            this.tvKisiler.FullRowSelect = true;
            this.tvKisiler.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tvKisiler.Indent = 23;
            this.tvKisiler.ItemHeight = 20;
            this.tvKisiler.Location = new System.Drawing.Point(0, 0);
            this.tvKisiler.Name = "tvKisiler";
            this.tvKisiler.ShowLines = false;
            this.tvKisiler.ShowNodeToolTips = true;
            this.tvKisiler.ShowPlusMinus = false;
            this.tvKisiler.Size = new System.Drawing.Size(361, 422);
            this.tvKisiler.TabIndex = 2;
            this.tvKisiler.TabStop = false;
            this.tvKisiler.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvKisiler_NodeMouseDoubleClick);
            this.tvKisiler.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvKisiler_BeforeCollapse);
            this.tvKisiler.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvKisiler_NodeMouseClick);
            this.tvKisiler.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvKisiler_AfterExpand);
            // 
            // AnaPencere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(363, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaPencere";
            this.Text = "RTC Client";
            this.Resize += new System.EventHandler(this.AnaPencere_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaPencere_FormClosing);
            this.Load += new System.EventHandler(this.AnaPencere_Load);
            this.contextTreeView.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextNotifyIcon.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblDurum;
        private System.Windows.Forms.ContextMenuStrip contextTreeView;
        private System.Windows.Forms.ToolStripMenuItem cmnuMesajGonder;
        private System.Windows.Forms.ToolStripMenuItem cmnuKisiSil;
        private System.Windows.Forms.NotifyIcon ntfyRTCClient;
        private System.Windows.Forms.ContextMenuStrip contextNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem cmnuOturumAc;
        private System.Windows.Forms.ToolStripMenuItem cmnuOturumKapat;
        private System.Windows.Forms.ToolStripMenuItem cmnuDurumum;
        private System.Windows.Forms.ToolStripMenuItem cmnuCevrimici;
        private System.Windows.Forms.ToolStripMenuItem cmnuMesgul;
        private System.Windows.Forms.ToolStripMenuItem cmnuDonecek;
        private System.Windows.Forms.ToolStripMenuItem cmnuDisarida;
        private System.Windows.Forms.ToolStripMenuItem cmnuTelefonda;
        private System.Windows.Forms.ToolStripMenuItem cmnuYemekte;
        private System.Windows.Forms.ToolStripMenuItem cmnuCevrimdisi;
        private System.Windows.Forms.ToolStripMenuItem cmnuCikis;
        private System.Windows.Forms.ImageList imgResimler;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDosya;
        private System.Windows.Forms.ToolStripMenuItem mnuOturumAc;
        private System.Windows.Forms.ToolStripMenuItem mnuOturumKapat;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDurumum;
        private System.Windows.Forms.ToolStripMenuItem mnuCevrimici;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuKapat;
        private System.Windows.Forms.ToolStripMenuItem mnuMesgul;
        private System.Windows.Forms.ToolStripMenuItem mnuDonecek;
        private System.Windows.Forms.ToolStripMenuItem mnuDisarida;
        private System.Windows.Forms.ToolStripMenuItem mnuTelefonda;
        private System.Windows.Forms.ToolStripMenuItem mnuYemekte;
        private System.Windows.Forms.ToolStripMenuItem mnuCevrimdisi;
        private System.Windows.Forms.ToolStripMenuItem mnuEylemler;
        private System.Windows.Forms.ToolStripMenuItem mnuKisiEkle;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private System.Windows.Forms.ToolStripMenuItem cmnuOzellikler;
        private System.Windows.Forms.ToolStripMenuItem cmnuVideoSes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvKisiler;
    }
}

