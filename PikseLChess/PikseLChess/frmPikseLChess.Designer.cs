namespace PikseLChess
{
    partial class frmPikseLChess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPikseLChess));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbYeni = new System.Windows.Forms.ToolStripButton();
            this.tbKaydet = new System.Windows.Forms.ToolStripButton();
            this.tbAc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripButton();
            this.tbRedo = new System.Windows.Forms.ToolStripButton();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYeni = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKaydet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.yardýmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picOyunAlani = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOyunAlani)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbYeni,
            this.tbKaydet,
            this.tbAc,
            this.toolStripSeparator1,
            this.tbUndo,
            this.tbRedo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(694, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbYeni
            // 
            this.tbYeni.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbYeni.Image = global::PikseLChess.Properties.Resources.New;
            this.tbYeni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbYeni.Name = "tbYeni";
            this.tbYeni.Size = new System.Drawing.Size(23, 22);
            this.tbYeni.Text = "Yeni Oyun";
            this.tbYeni.Click += new System.EventHandler(this.tbYeni_Click);
            // 
            // tbKaydet
            // 
            this.tbKaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbKaydet.Image = global::PikseLChess.Properties.Resources.Save;
            this.tbKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbKaydet.Name = "tbKaydet";
            this.tbKaydet.Size = new System.Drawing.Size(23, 22);
            this.tbKaydet.Text = "Kaydet";
            this.tbKaydet.Click += new System.EventHandler(this.tbKaydet_Click);
            // 
            // tbAc
            // 
            this.tbAc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAc.Image = global::PikseLChess.Properties.Resources.Open;
            this.tbAc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAc.Name = "tbAc";
            this.tbAc.Size = new System.Drawing.Size(23, 22);
            this.tbAc.Text = "Aç";
            this.tbAc.Click += new System.EventHandler(this.tbAc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Image = global::PikseLChess.Properties.Resources.Undo;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(23, 22);
            this.tbUndo.Text = "Geri Al";
            this.tbUndo.Click += new System.EventHandler(this.tbUndo_Click);
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Image = global::PikseLChess.Properties.Resources.Redo;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(23, 22);
            this.tbRedo.Text = "Ýleri Al";
            this.tbRedo.Click += new System.EventHandler(this.tbRedo_Click);
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvLog.Location = new System.Drawing.Point(463, 52);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(222, 450);
            this.lvLog.TabIndex = 5;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Oyuncu";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Taþ";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hamle";
            this.columnHeader4.Width = 90;
            // 
            // dlgOpen
            // 
            this.dlgOpen.Title = "Aç";
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "pcs";
            this.dlgSave.Title = "Kaydet";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.düzenToolStripMenuItem,
            this.yardýmToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "PikseLChess Menu";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuYeni,
            this.mnuAc,
            this.mnuKaydet,
            this.toolStripMenuItem1,
            this.mnuCikis});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // mnuYeni
            // 
            this.mnuYeni.Name = "mnuYeni";
            this.mnuYeni.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuYeni.Size = new System.Drawing.Size(157, 22);
            this.mnuYeni.Text = "Yeni";
            this.mnuYeni.Click += new System.EventHandler(this.tbYeni_Click);
            // 
            // mnuAc
            // 
            this.mnuAc.Name = "mnuAc";
            this.mnuAc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuAc.Size = new System.Drawing.Size(157, 22);
            this.mnuAc.Text = "Aç";
            this.mnuAc.Click += new System.EventHandler(this.tbAc_Click);
            // 
            // mnuKaydet
            // 
            this.mnuKaydet.Name = "mnuKaydet";
            this.mnuKaydet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuKaydet.Size = new System.Drawing.Size(157, 22);
            this.mnuKaydet.Text = "Kaydet";
            this.mnuKaydet.Click += new System.EventHandler(this.tbKaydet_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // mnuCikis
            // 
            this.mnuCikis.Name = "mnuCikis";
            this.mnuCikis.Size = new System.Drawing.Size(157, 22);
            this.mnuCikis.Text = "Çýkýþ";
            this.mnuCikis.Click += new System.EventHandler(this.mnuCikis_Click);
            // 
            // düzenToolStripMenuItem
            // 
            this.düzenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo,
            this.mnuRedo});
            this.düzenToolStripMenuItem.Name = "düzenToolStripMenuItem";
            this.düzenToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.düzenToolStripMenuItem.Text = "Düzen";
            // 
            // mnuUndo
            // 
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(148, 22);
            this.mnuUndo.Text = "Undo";
            this.mnuUndo.Click += new System.EventHandler(this.tbUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuRedo.Size = new System.Drawing.Size(148, 22);
            this.mnuRedo.Text = "Redo";
            this.mnuRedo.Click += new System.EventHandler(this.tbRedo_Click);
            // 
            // yardýmToolStripMenuItem
            // 
            this.yardýmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHakkinda});
            this.yardýmToolStripMenuItem.Name = "yardýmToolStripMenuItem";
            this.yardýmToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.yardýmToolStripMenuItem.Text = "Yardým";
            // 
            // mnuHakkinda
            // 
            this.mnuHakkinda.Name = "mnuHakkinda";
            this.mnuHakkinda.Size = new System.Drawing.Size(128, 22);
            this.mnuHakkinda.Text = "Hakkýnda";
            this.mnuHakkinda.Click += new System.EventHandler(this.mnuHakkinda_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = global::PikseLChess.Properties.Resources.zemin2;
            this.panel1.Controls.Add(this.picOyunAlani);
            this.panel1.Location = new System.Drawing.Point(5, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 450);
            this.panel1.TabIndex = 7;
            // 
            // picOyunAlani
            // 
            this.picOyunAlani.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picOyunAlani.Image = global::PikseLChess.Properties.Resources.tahta2;
            this.picOyunAlani.Location = new System.Drawing.Point(25, 25);
            this.picOyunAlani.Name = "picOyunAlani";
            this.picOyunAlani.Size = new System.Drawing.Size(400, 400);
            this.picOyunAlani.TabIndex = 5;
            this.picOyunAlani.TabStop = false;
            this.picOyunAlani.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picOyunAlani_MouseDown);
            this.picOyunAlani.Paint += new System.Windows.Forms.PaintEventHandler(this.picOyunAlani_Paint);
            // 
            // frmPikseLChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(694, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPikseLChess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PikseLChess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOyunAlani)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbYeni;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton tbKaydet;
        private System.Windows.Forms.ToolStripButton tbAc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbUndo;
        private System.Windows.Forms.ToolStripButton tbRedo;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuYeni;
        private System.Windows.Forms.ToolStripMenuItem mnuAc;
        private System.Windows.Forms.ToolStripMenuItem mnuKaydet;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCikis;
        private System.Windows.Forms.ToolStripMenuItem düzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripMenuItem yardýmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHakkinda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picOyunAlani;
    }
}

