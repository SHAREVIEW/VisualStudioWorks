namespace AmbarTakip
{
    partial class CPSKayit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtYTNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMalzemeAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSpect = new System.Windows.Forms.TextBox();
            this.picMalzeme = new System.Windows.Forms.PictureBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dlgResim = new System.Windows.Forms.OpenFileDialog();
            this.txtResim = new System.Windows.Forms.TextBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCPS = new System.Windows.Forms.DataGridView();
            this.bsCPS = new System.Windows.Forms.BindingSource(this.components);
            this.dsCPS = new AmbarTakip.AmbarTakipDataSet1();
            this.btnReset = new System.Windows.Forms.Button();
            this.taCPS = new AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter();
            this.yTNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mALZEMEADIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mARKADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPECTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picMalzeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCPS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtYTNO
            // 
            this.txtYTNO.Location = new System.Drawing.Point(95, 12);
            this.txtYTNO.Name = "txtYTNO";
            this.txtYTNO.Size = new System.Drawing.Size(245, 20);
            this.txtYTNO.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "YT NUMARASI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MARKA";
            // 
            // txtMarka
            // 
            this.txtMarka.Location = new System.Drawing.Point(95, 64);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(245, 20);
            this.txtMarka.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "MALZEME ADI";
            // 
            // txtMalzemeAdi
            // 
            this.txtMalzemeAdi.Location = new System.Drawing.Point(95, 38);
            this.txtMalzemeAdi.Name = "txtMalzemeAdi";
            this.txtMalzemeAdi.Size = new System.Drawing.Size(245, 20);
            this.txtMalzemeAdi.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "SPECT";
            // 
            // txtSpect
            // 
            this.txtSpect.Location = new System.Drawing.Point(95, 90);
            this.txtSpect.Name = "txtSpect";
            this.txtSpect.Size = new System.Drawing.Size(245, 20);
            this.txtSpect.TabIndex = 3;
            // 
            // picMalzeme
            // 
            this.picMalzeme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMalzeme.Location = new System.Drawing.Point(95, 144);
            this.picMalzeme.Name = "picMalzeme";
            this.picMalzeme.Size = new System.Drawing.Size(245, 176);
            this.picMalzeme.TabIndex = 14;
            this.picMalzeme.TabStop = false;
            // 
            // btnCikis
            // 
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Location = new System.Drawing.Point(265, 326);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "Çýkýþ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(103, 326);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtResim
            // 
            this.txtResim.BackColor = System.Drawing.SystemColors.Window;
            this.txtResim.Location = new System.Drawing.Point(95, 119);
            this.txtResim.Name = "txtResim";
            this.txtResim.ReadOnly = true;
            this.txtResim.Size = new System.Drawing.Size(184, 20);
            this.txtResim.TabIndex = 17;
            // 
            // btnGozat
            // 
            this.btnGozat.Location = new System.Drawing.Point(285, 117);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(55, 23);
            this.btnGozat.TabIndex = 4;
            this.btnGozat.Text = "Gözat...";
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "RESÝM";
            // 
            // dgvCPS
            // 
            this.dgvCPS.AllowUserToAddRows = false;
            this.dgvCPS.AllowUserToDeleteRows = false;
            this.dgvCPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCPS.AutoGenerateColumns = false;
            this.dgvCPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCPS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yTNODataGridViewTextBoxColumn,
            this.mALZEMEADIDataGridViewTextBoxColumn,
            this.mARKADataGridViewTextBoxColumn,
            this.sPECTDataGridViewTextBoxColumn});
            this.dgvCPS.DataSource = this.bsCPS;
            this.dgvCPS.Location = new System.Drawing.Point(346, 12);
            this.dgvCPS.Name = "dgvCPS";
            this.dgvCPS.Size = new System.Drawing.Size(643, 308);
            this.dgvCPS.TabIndex = 20;
            this.dgvCPS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCPS_CellDoubleClick);
            this.dgvCPS.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCPS_RowValidated);
            // 
            // bsCPS
            // 
            this.bsCPS.DataMember = "CPS";
            this.bsCPS.DataSource = this.dsCPS;
            this.bsCPS.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCPS_ListChanged);
            // 
            // dsCPS
            // 
            this.dsCPS.DataSetName = "AmbarTakipDataSet1";
            this.dsCPS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(184, 326);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // taCPS
            // 
            this.taCPS.ClearBeforeFill = true;
            // 
            // yTNODataGridViewTextBoxColumn
            // 
            this.yTNODataGridViewTextBoxColumn.DataPropertyName = "YTNO";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yTNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.yTNODataGridViewTextBoxColumn.HeaderText = "YT NO";
            this.yTNODataGridViewTextBoxColumn.Name = "yTNODataGridViewTextBoxColumn";
            this.yTNODataGridViewTextBoxColumn.ReadOnly = true;
            this.yTNODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.yTNODataGridViewTextBoxColumn.Width = 150;
            // 
            // mALZEMEADIDataGridViewTextBoxColumn
            // 
            this.mALZEMEADIDataGridViewTextBoxColumn.DataPropertyName = "MALZEMEADI";
            this.mALZEMEADIDataGridViewTextBoxColumn.HeaderText = "MALZEME ADI";
            this.mALZEMEADIDataGridViewTextBoxColumn.Name = "mALZEMEADIDataGridViewTextBoxColumn";
            this.mALZEMEADIDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mALZEMEADIDataGridViewTextBoxColumn.Width = 150;
            // 
            // mARKADataGridViewTextBoxColumn
            // 
            this.mARKADataGridViewTextBoxColumn.DataPropertyName = "MARKA";
            this.mARKADataGridViewTextBoxColumn.HeaderText = "MARKA";
            this.mARKADataGridViewTextBoxColumn.Name = "mARKADataGridViewTextBoxColumn";
            this.mARKADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mARKADataGridViewTextBoxColumn.Width = 150;
            // 
            // sPECTDataGridViewTextBoxColumn
            // 
            this.sPECTDataGridViewTextBoxColumn.DataPropertyName = "SPECT";
            this.sPECTDataGridViewTextBoxColumn.HeaderText = "SPECT";
            this.sPECTDataGridViewTextBoxColumn.Name = "sPECTDataGridViewTextBoxColumn";
            this.sPECTDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sPECTDataGridViewTextBoxColumn.Width = 150;
            // 
            // CPSKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 357);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvCPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGozat);
            this.Controls.Add(this.txtResim);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.picMalzeme);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSpect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMalzemeAdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMarka);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYTNO);
            this.KeyPreview = true;
            this.Name = "CPSKayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPS Kayýt";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CPSKayit_KeyDown);
            this.Load += new System.EventHandler(this.CPSKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMalzeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtYTNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMalzemeAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSpect;
        private System.Windows.Forms.PictureBox picMalzeme;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.OpenFileDialog dlgResim;
        private System.Windows.Forms.TextBox txtResim;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsCPS;
        private System.Windows.Forms.DataGridView dgvCPS;
        private System.Windows.Forms.Button btnReset;
        private AmbarTakipDataSet1 dsCPS;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter taCPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn yTNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mALZEMEADIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mARKADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPECTDataGridViewTextBoxColumn;
    }
}