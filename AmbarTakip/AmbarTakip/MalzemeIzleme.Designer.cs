namespace AmbarTakip
{
    partial class MalzemeIzleme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEkipman = new System.Windows.Forms.DataGridView();
            this.eKIPMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEkipman = new System.Windows.Forms.BindingSource(this.components);
            this.bsUnite = new System.Windows.Forms.BindingSource(this.components);
            this.dsIzleme = new AmbarTakip.AmbarTakipDataSet1();
            this.dgvUnite = new System.Windows.Forms.DataGridView();
            this.uNITEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitUniteEkipman = new System.Windows.Forms.SplitContainer();
            this.splitUEMalzeme = new System.Windows.Forms.SplitContainer();
            this.dgvMalzeme = new System.Windows.Forms.DataGridView();
            this.yTNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAFNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMalzeme = new System.Windows.Forms.BindingSource(this.components);
            this.taUnite = new AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter();
            this.taEkipman = new AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter();
            this.taMalzeme = new AmbarTakip.AmbarTakipDataSet1TableAdapters.MalzemeTableAdapter();
            this.dsCPS = new System.Windows.Forms.BindingSource(this.components);
            this.taCPS = new AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEkipman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIzleme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnite)).BeginInit();
            this.splitUniteEkipman.Panel1.SuspendLayout();
            this.splitUniteEkipman.Panel2.SuspendLayout();
            this.splitUniteEkipman.SuspendLayout();
            this.splitUEMalzeme.Panel1.SuspendLayout();
            this.splitUEMalzeme.Panel2.SuspendLayout();
            this.splitUEMalzeme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMalzeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCPS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEkipman
            // 
            this.dgvEkipman.AllowUserToAddRows = false;
            this.dgvEkipman.AutoGenerateColumns = false;
            this.dgvEkipman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEkipman.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eKIPMANDataGridViewTextBoxColumn});
            this.dgvEkipman.DataSource = this.bsEkipman;
            this.dgvEkipman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEkipman.Location = new System.Drawing.Point(0, 0);
            this.dgvEkipman.Name = "dgvEkipman";
            this.dgvEkipman.Size = new System.Drawing.Size(359, 240);
            this.dgvEkipman.TabIndex = 3;
            this.dgvEkipman.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEkipman_RowValidated);
            // 
            // eKIPMANDataGridViewTextBoxColumn
            // 
            this.eKIPMANDataGridViewTextBoxColumn.DataPropertyName = "EKIPMAN";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.eKIPMANDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.eKIPMANDataGridViewTextBoxColumn.HeaderText = "EKIPMAN";
            this.eKIPMANDataGridViewTextBoxColumn.Name = "eKIPMANDataGridViewTextBoxColumn";
            this.eKIPMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsEkipman
            // 
            this.bsEkipman.DataMember = "UniteEkipman";
            this.bsEkipman.DataSource = this.bsUnite;
            this.bsEkipman.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsEkipman_ListChanged);
            // 
            // bsUnite
            // 
            this.bsUnite.DataMember = "Unite";
            this.bsUnite.DataSource = this.dsIzleme;
            this.bsUnite.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsUnite_ListChanged);
            // 
            // dsIzleme
            // 
            this.dsIzleme.DataSetName = "AmbarTakipDataSet1";
            this.dsIzleme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvUnite
            // 
            this.dgvUnite.AllowUserToAddRows = false;
            this.dgvUnite.AutoGenerateColumns = false;
            this.dgvUnite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uNITEDataGridViewTextBoxColumn});
            this.dgvUnite.DataSource = this.bsUnite;
            this.dgvUnite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnite.Location = new System.Drawing.Point(0, 0);
            this.dgvUnite.Name = "dgvUnite";
            this.dgvUnite.Size = new System.Drawing.Size(359, 238);
            this.dgvUnite.TabIndex = 2;
            this.dgvUnite.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnite_RowValidated);
            // 
            // uNITEDataGridViewTextBoxColumn
            // 
            this.uNITEDataGridViewTextBoxColumn.DataPropertyName = "UNITE";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uNITEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.uNITEDataGridViewTextBoxColumn.HeaderText = "UNITE";
            this.uNITEDataGridViewTextBoxColumn.Name = "uNITEDataGridViewTextBoxColumn";
            this.uNITEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // splitUniteEkipman
            // 
            this.splitUniteEkipman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitUniteEkipman.Location = new System.Drawing.Point(0, 0);
            this.splitUniteEkipman.Name = "splitUniteEkipman";
            this.splitUniteEkipman.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitUniteEkipman.Panel1
            // 
            this.splitUniteEkipman.Panel1.Controls.Add(this.dgvUnite);
            // 
            // splitUniteEkipman.Panel2
            // 
            this.splitUniteEkipman.Panel2.Controls.Add(this.dgvEkipman);
            this.splitUniteEkipman.Size = new System.Drawing.Size(359, 482);
            this.splitUniteEkipman.SplitterDistance = 238;
            this.splitUniteEkipman.TabIndex = 4;
            // 
            // splitUEMalzeme
            // 
            this.splitUEMalzeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitUEMalzeme.Location = new System.Drawing.Point(0, 0);
            this.splitUEMalzeme.Name = "splitUEMalzeme";
            // 
            // splitUEMalzeme.Panel1
            // 
            this.splitUEMalzeme.Panel1.Controls.Add(this.splitUniteEkipman);
            // 
            // splitUEMalzeme.Panel2
            // 
            this.splitUEMalzeme.Panel2.Controls.Add(this.dgvMalzeme);
            this.splitUEMalzeme.Size = new System.Drawing.Size(1079, 482);
            this.splitUEMalzeme.SplitterDistance = 359;
            this.splitUEMalzeme.TabIndex = 6;
            // 
            // dgvMalzeme
            // 
            this.dgvMalzeme.AllowUserToAddRows = false;
            this.dgvMalzeme.AutoGenerateColumns = false;
            this.dgvMalzeme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalzeme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yTNODataGridViewTextBoxColumn,
            this.aDETDataGridViewTextBoxColumn,
            this.rAFNODataGridViewTextBoxColumn,
            this.mINDataGridViewTextBoxColumn,
            this.mAXDataGridViewTextBoxColumn});
            this.dgvMalzeme.DataSource = this.bsMalzeme;
            this.dgvMalzeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMalzeme.Location = new System.Drawing.Point(0, 0);
            this.dgvMalzeme.Name = "dgvMalzeme";
            this.dgvMalzeme.Size = new System.Drawing.Size(716, 482);
            this.dgvMalzeme.TabIndex = 6;
            this.dgvMalzeme.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMalzeme_CellDoubleClick);
            this.dgvMalzeme.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMalzeme_RowValidated);
            // 
            // yTNODataGridViewTextBoxColumn
            // 
            this.yTNODataGridViewTextBoxColumn.DataPropertyName = "YTNO";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yTNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
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
            this.bsMalzeme.DataMember = "EkipmanMalzeme";
            this.bsMalzeme.DataSource = this.bsEkipman;
            this.bsMalzeme.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsMalzeme_ListChanged);
            // 
            // taUnite
            // 
            this.taUnite.ClearBeforeFill = true;
            // 
            // taEkipman
            // 
            this.taEkipman.ClearBeforeFill = true;
            // 
            // taMalzeme
            // 
            this.taMalzeme.ClearBeforeFill = true;
            // 
            // dsCPS
            // 
            this.dsCPS.DataMember = "CPS";
            this.dsCPS.DataSource = this.dsIzleme;
            // 
            // taCPS
            // 
            this.taCPS.ClearBeforeFill = true;
            // 
            // MalzemeIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 482);
            this.Controls.Add(this.splitUEMalzeme);
            this.Name = "MalzemeIzleme";
            this.Text = "Malzeme Ýzleme";
            this.Load += new System.EventHandler(this.MalzemeGuncelleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEkipman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIzleme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnite)).EndInit();
            this.splitUniteEkipman.Panel1.ResumeLayout(false);
            this.splitUniteEkipman.Panel2.ResumeLayout(false);
            this.splitUniteEkipman.ResumeLayout(false);
            this.splitUEMalzeme.Panel1.ResumeLayout(false);
            this.splitUEMalzeme.Panel2.ResumeLayout(false);
            this.splitUEMalzeme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMalzeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCPS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEkipman;
        private System.Windows.Forms.DataGridView dgvUnite;
        private System.Windows.Forms.SplitContainer splitUniteEkipman;
        private System.Windows.Forms.SplitContainer splitUEMalzeme;
        private System.Windows.Forms.DataGridView dgvMalzeme;
        private System.Windows.Forms.BindingSource bsUnite;
        private AmbarTakipDataSet1 dsIzleme;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter taUnite;
        private System.Windows.Forms.BindingSource bsEkipman;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter taEkipman;
        private System.Windows.Forms.BindingSource bsMalzeme;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.MalzemeTableAdapter taMalzeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn eKIPMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNITEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yTNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAFNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAXDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dsCPS;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.CPSTableAdapter taCPS;

    }
}