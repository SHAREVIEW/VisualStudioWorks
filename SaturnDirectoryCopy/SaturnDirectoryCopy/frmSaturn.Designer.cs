namespace SaturnDirectoryCopy
{
    partial class frmSaturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaturn));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKaynak = new System.Windows.Forms.TextBox();
            this.txtHedef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKaynak = new System.Windows.Forms.Button();
            this.btnHedef = new System.Windows.Forms.Button();
            this.lvDosyalar = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgResimler = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbAddNewFiles = new System.Windows.Forms.CheckBox();
            this.dlgAc = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDurum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kopyalama için kaynak klasör seçin";
            // 
            // txtKaynak
            // 
            this.txtKaynak.Location = new System.Drawing.Point(28, 25);
            this.txtKaynak.Name = "txtKaynak";
            this.txtKaynak.Size = new System.Drawing.Size(300, 20);
            this.txtKaynak.TabIndex = 1;
            // 
            // txtHedef
            // 
            this.txtHedef.Location = new System.Drawing.Point(28, 64);
            this.txtHedef.Name = "txtHedef";
            this.txtHedef.Size = new System.Drawing.Size(300, 20);
            this.txtHedef.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kopyalama için hedef klasör seçin";
            // 
            // btnKaynak
            // 
            this.btnKaynak.Location = new System.Drawing.Point(334, 25);
            this.btnKaynak.Name = "btnKaynak";
            this.btnKaynak.Size = new System.Drawing.Size(77, 20);
            this.btnKaynak.TabIndex = 4;
            this.btnKaynak.Text = "Gözat...";
            this.btnKaynak.UseVisualStyleBackColor = true;
            this.btnKaynak.Click += new System.EventHandler(this.btnKaynak_Click);
            // 
            // btnHedef
            // 
            this.btnHedef.Location = new System.Drawing.Point(334, 64);
            this.btnHedef.Name = "btnHedef";
            this.btnHedef.Size = new System.Drawing.Size(77, 20);
            this.btnHedef.TabIndex = 5;
            this.btnHedef.Text = "Gözat...";
            this.btnHedef.UseVisualStyleBackColor = true;
            this.btnHedef.Click += new System.EventHandler(this.btnHedef_Click);
            // 
            // lvDosyalar
            // 
            this.lvDosyalar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvDosyalar.Location = new System.Drawing.Point(29, 96);
            this.lvDosyalar.Name = "lvDosyalar";
            this.lvDosyalar.Size = new System.Drawing.Size(382, 229);
            this.lvDosyalar.SmallImageList = this.imgResimler;
            this.lvDosyalar.TabIndex = 6;
            this.lvDosyalar.UseCompatibleStateImageBehavior = false;
            this.lvDosyalar.View = System.Windows.Forms.View.Details;
            this.lvDosyalar.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDosyalar_ColumnClick);
            this.lvDosyalar.SelectedIndexChanged += new System.EventHandler(this.lvDosyalar_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dosya Adý";
            this.columnHeader1.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kopyalama Sonucu";
            this.columnHeader2.Width = 220;
            // 
            // imgResimler
            // 
            this.imgResimler.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgResimler.ImageStream")));
            this.imgResimler.TransparentColor = System.Drawing.Color.Transparent;
            this.imgResimler.Images.SetKeyName(0, "bos.jpg");
            this.imgResimler.Images.SetKeyName(1, "ok.jpg");
            this.imgResimler.Images.SetKeyName(2, "bitti.jpg");
            this.imgResimler.Images.SetKeyName(3, "hata.jpg");
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(351, 357);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 24);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Çýkýþ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(285, 357);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(60, 24);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Kopyala";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbAddNewFiles
            // 
            this.cbAddNewFiles.AutoSize = true;
            this.cbAddNewFiles.Checked = true;
            this.cbAddNewFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAddNewFiles.Location = new System.Drawing.Point(28, 364);
            this.cbAddNewFiles.Name = "cbAddNewFiles";
            this.cbAddNewFiles.Size = new System.Drawing.Size(191, 17);
            this.cbAddNewFiles.TabIndex = 9;
            this.cbAddNewFiles.Text = "Deðiþtirilen dosyalarý tekrar kopyala";
            this.cbAddNewFiles.UseVisualStyleBackColor = true;
            // 
            // dlgAc
            // 
            this.dlgAc.FileName = "openFileDialog1";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(28, 328);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(44, 13);
            this.lblDurum.TabIndex = 10;
            this.lblDurum.Text = "Durum: ";
            // 
            // frmSaturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 393);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.cbAddNewFiles);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lvDosyalar);
            this.Controls.Add(this.btnHedef);
            this.Controls.Add(this.btnKaynak);
            this.Controls.Add(this.txtHedef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKaynak);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saturn - Directory Copy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSaturn_FormClosing);
            this.Load += new System.EventHandler(this.frmSaturn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKaynak;
        private System.Windows.Forms.TextBox txtHedef;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKaynak;
        private System.Windows.Forms.Button btnHedef;
        private System.Windows.Forms.ListView lvDosyalar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox cbAddNewFiles;
        private System.Windows.Forms.OpenFileDialog dlgAc;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.ImageList imgResimler;
    }
}

