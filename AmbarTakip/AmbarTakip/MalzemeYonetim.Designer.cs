namespace AmbarTakip
{
    partial class MalzemeYonetim
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtYTNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUniteler = new System.Windows.Forms.ComboBox();
            this.cmbEkipmanlar = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvYonetim = new System.Windows.Forms.DataGridView();
            this.yTNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAFNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMalzeme = new System.Windows.Forms.BindingSource(this.components);
            this.dsMalzeme = new AmbarTakip.AmbarTakipDataSet1();
            this.taMalzeme = new AmbarTakip.AmbarTakipDataSet1TableAdapters.MalzemeTableAdapter();
            this.bsUnite = new System.Windows.Forms.BindingSource(this.components);
            this.bsEkipman = new System.Windows.Forms.BindingSource(this.components);
            this.taUnite = new AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter();
            this.taEkipman = new AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter();
            this.bsCPS = new System.Windows.Forms.BindingSource(this.components);
            this.taCPS = new AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYonetim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMalzeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMalzeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCPS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "YTNO";
            // 
            // txtYTNO
            // 
            this.txtYTNO.Location = new System.Drawing.Point(49, 19);
            this.txtYTNO.Name = "txtYTNO";
            this.txtYTNO.Size = new System.Drawing.Size(209, 20);
            this.txtYTNO.TabIndex = 1;
            this.txtYTNO.TextChanged += new System.EventHandler(this.txtYTNO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ÜNÝTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "EKÝPMAN";
            // 
            // cmbUniteler
            // 
            this.cmbUniteler.FormattingEnabled = true;
            this.cmbUniteler.Location = new System.Drawing.Point(358, 19);
            this.cmbUniteler.Name = "cmbUniteler";
            this.cmbUniteler.Size = new System.Drawing.Size(256, 21);
            this.cmbUniteler.TabIndex = 6;
            this.cmbUniteler.Text = "Ünite Seçin";
            this.cmbUniteler.SelectedIndexChanged += new System.EventHandler(this.cmbUniteler_SelectedIndexChanged);
            this.cmbUniteler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUniteler_KeyPress);
            // 
            // cmbEkipmanlar
            // 
            this.cmbEkipmanlar.FormattingEnabled = true;
            this.cmbEkipmanlar.Location = new System.Drawing.Point(714, 20);
            this.cmbEkipmanlar.Name = "cmbEkipmanlar";
            this.cmbEkipmanlar.Size = new System.Drawing.Size(226, 21);
            this.cmbEkipmanlar.TabIndex = 7;
            this.cmbEkipmanlar.Text = "Ekipman Seçin";
            this.cmbEkipmanlar.SelectedIndexChanged += new System.EventHandler(this.cmbEkipmanlar_SelectedIndexChanged);
            this.cmbEkipmanlar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUniteler_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbUniteler);
            this.groupBox1.Controls.Add(this.cmbEkipmanlar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtYTNO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arama Seçenekleri";
            // 
            // dgvYonetim
            // 
            this.dgvYonetim.AllowUserToAddRows = false;
            this.dgvYonetim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYonetim.AutoGenerateColumns = false;
            this.dgvYonetim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYonetim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yTNODataGridViewTextBoxColumn,
            this.aDETDataGridViewTextBoxColumn,
            this.rAFNODataGridViewTextBoxColumn,
            this.mINDataGridViewTextBoxColumn,
            this.mAXDataGridViewTextBoxColumn});
            this.dgvYonetim.DataSource = this.bsMalzeme;
            this.dgvYonetim.Location = new System.Drawing.Point(12, 82);
            this.dgvYonetim.Name = "dgvYonetim";
            this.dgvYonetim.Size = new System.Drawing.Size(946, 378);
            this.dgvYonetim.TabIndex = 9;
            this.dgvYonetim.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArama_CellDoubleClick);
            this.dgvYonetim.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYonetim_RowValidated);
            // 
            // yTNODataGridViewTextBoxColumn
            // 
            this.yTNODataGridViewTextBoxColumn.DataPropertyName = "YTNO";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yTNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.yTNODataGridViewTextBoxColumn.HeaderText = "YTNO";
            this.yTNODataGridViewTextBoxColumn.Name = "yTNODataGridViewTextBoxColumn";
            this.yTNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDETDataGridViewTextBoxColumn
            // 
            this.aDETDataGridViewTextBoxColumn.DataPropertyName = "ADET";
            this.aDETDataGridViewTextBoxColumn.HeaderText = "ADET";
            this.aDETDataGridViewTextBoxColumn.Name = "aDETDataGridViewTextBoxColumn";
            // 
            // rAFNODataGridViewTextBoxColumn
            // 
            this.rAFNODataGridViewTextBoxColumn.DataPropertyName = "RAFNO";
            this.rAFNODataGridViewTextBoxColumn.HeaderText = "RAFNO";
            this.rAFNODataGridViewTextBoxColumn.Name = "rAFNODataGridViewTextBoxColumn";
            // 
            // mINDataGridViewTextBoxColumn
            // 
            this.mINDataGridViewTextBoxColumn.DataPropertyName = "MIN";
            this.mINDataGridViewTextBoxColumn.HeaderText = "MIN";
            this.mINDataGridViewTextBoxColumn.Name = "mINDataGridViewTextBoxColumn";
            // 
            // mAXDataGridViewTextBoxColumn
            // 
            this.mAXDataGridViewTextBoxColumn.DataPropertyName = "MAX";
            this.mAXDataGridViewTextBoxColumn.HeaderText = "MAX";
            this.mAXDataGridViewTextBoxColumn.Name = "mAXDataGridViewTextBoxColumn";
            // 
            // bsMalzeme
            // 
            this.bsMalzeme.DataMember = "Malzeme";
            this.bsMalzeme.DataSource = this.dsMalzeme;
            this.bsMalzeme.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsMalzeme_ListChanged);
            // 
            // dsMalzeme
            // 
            this.dsMalzeme.DataSetName = "AmbarTakipDataSet1";
            this.dsMalzeme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taMalzeme
            // 
            this.taMalzeme.ClearBeforeFill = true;
            // 
            // bsUnite
            // 
            this.bsUnite.DataMember = "Unite";
            this.bsUnite.DataSource = this.dsMalzeme;
            // 
            // bsEkipman
            // 
            this.bsEkipman.DataMember = "Ekipman";
            this.bsEkipman.DataSource = this.dsMalzeme;
            // 
            // taUnite
            // 
            this.taUnite.ClearBeforeFill = true;
            // 
            // taEkipman
            // 
            this.taEkipman.ClearBeforeFill = true;
            // 
            // bsCPS
            // 
            this.bsCPS.DataMember = "CPS";
            this.bsCPS.DataSource = this.dsMalzeme;
            // 
            // taCPS
            // 
            this.taCPS.ClearBeforeFill = true;
            // 
            // MalzemeYonetim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 472);
            this.Controls.Add(this.dgvYonetim);
            this.Controls.Add(this.groupBox1);
            this.Name = "MalzemeYonetim";
            this.Text = "Malzeme Yönetim";
            this.Load += new System.EventHandler(this.MalzemeArama_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYonetim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMalzeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMalzeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCPS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYTNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUniteler;
        private System.Windows.Forms.ComboBox cmbEkipmanlar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvYonetim;
        private System.Windows.Forms.BindingSource bsMalzeme;
        private AmbarTakipDataSet1 dsMalzeme;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.MalzemeTableAdapter taMalzeme;
        private System.Windows.Forms.BindingSource bsUnite;
        private System.Windows.Forms.BindingSource bsEkipman;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter taUnite;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter taEkipman;
        private System.Windows.Forms.BindingSource bsCPS;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter taCPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn yTNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAFNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAXDataGridViewTextBoxColumn;
    }
}