namespace RTCClient
{
    partial class frmGorusme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGorusme));
            this.pnlGoruntuR = new System.Windows.Forms.Panel();
            this.picGelen = new System.Windows.Forms.PictureBox();
            this.pnlGoruntuS = new System.Windows.Forms.Panel();
            this.picGiden = new System.Windows.Forms.PictureBox();
            this.pnlGenel = new System.Windows.Forms.Panel();
            this.pnlMesajlar = new System.Windows.Forms.Panel();
            this.txtMesajlar = new RichTextBoxLinks.RichTextBoxEx();
            this.splitMesajlar = new System.Windows.Forms.Splitter();
            this.pnlMesajGenel = new System.Windows.Forms.Panel();
            this.pnlMesaj = new System.Windows.Forms.Panel();
            this.cmdGonder = new System.Windows.Forms.Button();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.eylemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAyar = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgFont = new System.Windows.Forms.FontDialog();
            this.pnlGoruntuR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGelen)).BeginInit();
            this.pnlGoruntuS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGiden)).BeginInit();
            this.pnlGenel.SuspendLayout();
            this.pnlMesajlar.SuspendLayout();
            this.pnlMesajGenel.SuspendLayout();
            this.pnlMesaj.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGoruntuR
            // 
            this.pnlGoruntuR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGoruntuR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGoruntuR.Controls.Add(this.picGelen);
            this.pnlGoruntuR.Location = new System.Drawing.Point(422, 27);
            this.pnlGoruntuR.Name = "pnlGoruntuR";
            this.pnlGoruntuR.Size = new System.Drawing.Size(127, 106);
            this.pnlGoruntuR.TabIndex = 0;
            // 
            // picGelen
            // 
            this.picGelen.BackColor = System.Drawing.Color.Gray;
            this.picGelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGelen.Location = new System.Drawing.Point(0, 0);
            this.picGelen.Name = "picGelen";
            this.picGelen.Size = new System.Drawing.Size(125, 104);
            this.picGelen.TabIndex = 1;
            this.picGelen.TabStop = false;
            // 
            // pnlGoruntuS
            // 
            this.pnlGoruntuS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGoruntuS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGoruntuS.Controls.Add(this.picGiden);
            this.pnlGoruntuS.Location = new System.Drawing.Point(422, 353);
            this.pnlGoruntuS.Name = "pnlGoruntuS";
            this.pnlGoruntuS.Size = new System.Drawing.Size(127, 106);
            this.pnlGoruntuS.TabIndex = 3;
            // 
            // picGiden
            // 
            this.picGiden.BackColor = System.Drawing.Color.Gray;
            this.picGiden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGiden.Location = new System.Drawing.Point(0, 0);
            this.picGiden.Name = "picGiden";
            this.picGiden.Size = new System.Drawing.Size(125, 104);
            this.picGiden.TabIndex = 2;
            this.picGiden.TabStop = false;
            // 
            // pnlGenel
            // 
            this.pnlGenel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGenel.Controls.Add(this.pnlMesajlar);
            this.pnlGenel.Controls.Add(this.splitMesajlar);
            this.pnlGenel.Controls.Add(this.pnlMesajGenel);
            this.pnlGenel.Location = new System.Drawing.Point(9, 27);
            this.pnlGenel.Name = "pnlGenel";
            this.pnlGenel.Size = new System.Drawing.Size(402, 432);
            this.pnlGenel.TabIndex = 5;
            // 
            // pnlMesajlar
            // 
            this.pnlMesajlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMesajlar.Controls.Add(this.txtMesajlar);
            this.pnlMesajlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMesajlar.Location = new System.Drawing.Point(0, 0);
            this.pnlMesajlar.MinimumSize = new System.Drawing.Size(2, 200);
            this.pnlMesajlar.Name = "pnlMesajlar";
            this.pnlMesajlar.Size = new System.Drawing.Size(402, 304);
            this.pnlMesajlar.TabIndex = 2;
            // 
            // txtMesajlar
            // 
            this.txtMesajlar.BackColor = System.Drawing.SystemColors.Window;
            this.txtMesajlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMesajlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMesajlar.Location = new System.Drawing.Point(0, 0);
            this.txtMesajlar.MinimumSize = new System.Drawing.Size(0, 200);
            this.txtMesajlar.Name = "txtMesajlar";
            this.txtMesajlar.ReadOnly = true;
            this.txtMesajlar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMesajlar.Size = new System.Drawing.Size(400, 302);
            this.txtMesajlar.TabIndex = 8;
            this.txtMesajlar.TabStop = false;
            this.txtMesajlar.Text = "";
            this.txtMesajlar.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtMesajlar_LinkClicked);
            // 
            // splitMesajlar
            // 
            this.splitMesajlar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitMesajlar.Location = new System.Drawing.Point(0, 304);
            this.splitMesajlar.Name = "splitMesajlar";
            this.splitMesajlar.Size = new System.Drawing.Size(402, 3);
            this.splitMesajlar.TabIndex = 1;
            this.splitMesajlar.TabStop = false;
            this.splitMesajlar.SplitterMoving += new System.Windows.Forms.SplitterEventHandler(this.splitMesajlar_SplitterMoving);
            // 
            // pnlMesajGenel
            // 
            this.pnlMesajGenel.BackColor = System.Drawing.Color.White;
            this.pnlMesajGenel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMesajGenel.Controls.Add(this.pnlMesaj);
            this.pnlMesajGenel.Controls.Add(this.toolStrip1);
            this.pnlMesajGenel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMesajGenel.Location = new System.Drawing.Point(0, 307);
            this.pnlMesajGenel.MinimumSize = new System.Drawing.Size(2, 125);
            this.pnlMesajGenel.Name = "pnlMesajGenel";
            this.pnlMesajGenel.Size = new System.Drawing.Size(402, 125);
            this.pnlMesajGenel.TabIndex = 0;
            // 
            // pnlMesaj
            // 
            this.pnlMesaj.Controls.Add(this.cmdGonder);
            this.pnlMesaj.Controls.Add(this.txtMesaj);
            this.pnlMesaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMesaj.Location = new System.Drawing.Point(0, 25);
            this.pnlMesaj.Name = "pnlMesaj";
            this.pnlMesaj.Size = new System.Drawing.Size(400, 98);
            this.pnlMesaj.TabIndex = 10;
            // 
            // cmdGonder
            // 
            this.cmdGonder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdGonder.BackColor = System.Drawing.Color.Gainsboro;
            this.cmdGonder.Location = new System.Drawing.Point(330, 27);
            this.cmdGonder.Name = "cmdGonder";
            this.cmdGonder.Size = new System.Drawing.Size(59, 42);
            this.cmdGonder.TabIndex = 9;
            this.cmdGonder.Text = "Gönder";
            this.cmdGonder.UseVisualStyleBackColor = true;
            this.cmdGonder.Click += new System.EventHandler(this.cmdGonder_Click);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesaj.BackColor = System.Drawing.SystemColors.Window;
            this.txtMesaj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMesaj.Location = new System.Drawing.Point(-1, 1);
            this.txtMesaj.MinimumSize = new System.Drawing.Size(0, 100);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(320, 100);
            this.txtMesaj.TabIndex = 8;
            this.txtMesaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesaj_KeyPress);
            this.txtMesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMesaj_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(400, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.eylemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(558, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCikis});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // mnuCikis
            // 
            this.mnuCikis.Name = "mnuCikis";
            this.mnuCikis.Size = new System.Drawing.Size(106, 22);
            this.mnuCikis.Text = "Çýkýþ";
            this.mnuCikis.Click += new System.EventHandler(this.mnuCikis_Click);
            // 
            // eylemlerToolStripMenuItem
            // 
            this.eylemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVideo,
            this.mnuAyar});
            this.eylemlerToolStripMenuItem.Name = "eylemlerToolStripMenuItem";
            this.eylemlerToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.eylemlerToolStripMenuItem.Text = "Eylemler";
            // 
            // mnuVideo
            // 
            this.mnuVideo.Name = "mnuVideo";
            this.mnuVideo.Size = new System.Drawing.Size(214, 22);
            this.mnuVideo.Text = "Video Görüþmesini Baþlat";
            this.mnuVideo.Click += new System.EventHandler(this.mnuVideo_Click);
            // 
            // mnuAyar
            // 
            this.mnuAyar.Name = "mnuAyar";
            this.mnuAyar.Size = new System.Drawing.Size(214, 22);
            this.mnuAyar.Text = "Video ve Ses Ayar Sihirbazý";
            this.mnuAyar.Click += new System.EventHandler(this.mnuAyar_Click);
            // 
            // frmGorusme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(558, 465);
            this.Controls.Add(this.pnlGenel);
            this.Controls.Add(this.pnlGoruntuS);
            this.Controls.Add(this.pnlGoruntuR);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "frmGorusme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMesajGonder";
            this.Activated += new System.EventHandler(this.frmGorusme_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGorusme_FormClosing);
            this.pnlGoruntuR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGelen)).EndInit();
            this.pnlGoruntuS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGiden)).EndInit();
            this.pnlGenel.ResumeLayout(false);
            this.pnlMesajlar.ResumeLayout(false);
            this.pnlMesajGenel.ResumeLayout(false);
            this.pnlMesajGenel.PerformLayout();
            this.pnlMesaj.ResumeLayout(false);
            this.pnlMesaj.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGoruntuR;
        private System.Windows.Forms.Panel pnlGoruntuS;
        private System.Windows.Forms.Panel pnlGenel;
        private System.Windows.Forms.Panel pnlMesajGenel;
        private System.Windows.Forms.Panel pnlMesajlar;
        private System.Windows.Forms.Splitter splitMesajlar;
        private System.Windows.Forms.PictureBox picGelen;
        private System.Windows.Forms.PictureBox picGiden;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eylemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCikis;
        private System.Windows.Forms.ToolStripMenuItem mnuVideo;
        private System.Windows.Forms.ToolStripMenuItem mnuAyar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FontDialog dlgFont;
        private System.Windows.Forms.Panel pnlMesaj;
        private System.Windows.Forms.Button cmdGonder;
        private System.Windows.Forms.TextBox txtMesaj;
        private RichTextBoxLinks.RichTextBoxEx txtMesajlar;
    }
}