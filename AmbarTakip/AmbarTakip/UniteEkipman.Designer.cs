namespace AmbarTakip
{
    partial class UniteEkipman
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUniteAdi = new System.Windows.Forms.TextBox();
            this.btnUniteEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEkipmanEkle = new System.Windows.Forms.Button();
            this.txtEkipmanAdi = new System.Windows.Forms.TextBox();
            this.cmbUniteler = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgUnite = new System.Windows.Forms.DataGridView();
            this.bsUnite = new System.Windows.Forms.BindingSource(this.components);
            this.dsUniteEkipman = new AmbarTakip.AmbarTakipDataSet1();
            this.dgEkipman = new System.Windows.Forms.DataGridView();
            this.bsEkipman = new System.Windows.Forms.BindingSource(this.components);
            this.taUnite = new AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter();
            this.taEkipman = new AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.eKIPMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uNITEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUniteEkipman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEkipman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUniteAdi);
            this.groupBox1.Controls.Add(this.btnUniteEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ünite Ekle";
            // 
            // txtUniteAdi
            // 
            this.txtUniteAdi.Location = new System.Drawing.Point(64, 20);
            this.txtUniteAdi.Name = "txtUniteAdi";
            this.txtUniteAdi.Size = new System.Drawing.Size(286, 20);
            this.txtUniteAdi.TabIndex = 3;
            this.txtUniteAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUniteAdi_KeyDown);
            // 
            // btnUniteEkle
            // 
            this.btnUniteEkle.Location = new System.Drawing.Point(275, 87);
            this.btnUniteEkle.Name = "btnUniteEkle";
            this.btnUniteEkle.Size = new System.Drawing.Size(75, 23);
            this.btnUniteEkle.TabIndex = 2;
            this.btnUniteEkle.Text = "Ekle";
            this.btnUniteEkle.UseVisualStyleBackColor = true;
            this.btnUniteEkle.Click += new System.EventHandler(this.btnUniteEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ünite Adý";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEkipmanEkle);
            this.groupBox2.Controls.Add(this.txtEkipmanAdi);
            this.groupBox2.Controls.Add(this.cmbUniteler);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(374, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ekipman Ekle";
            // 
            // btnEkipmanEkle
            // 
            this.btnEkipmanEkle.Location = new System.Drawing.Point(275, 87);
            this.btnEkipmanEkle.Name = "btnEkipmanEkle";
            this.btnEkipmanEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkipmanEkle.TabIndex = 5;
            this.btnEkipmanEkle.Text = "Ekle";
            this.btnEkipmanEkle.UseVisualStyleBackColor = true;
            this.btnEkipmanEkle.Click += new System.EventHandler(this.btnEkipmanEkle_Click);
            // 
            // txtEkipmanAdi
            // 
            this.txtEkipmanAdi.Location = new System.Drawing.Point(81, 58);
            this.txtEkipmanAdi.Name = "txtEkipmanAdi";
            this.txtEkipmanAdi.Size = new System.Drawing.Size(269, 20);
            this.txtEkipmanAdi.TabIndex = 4;
            this.txtEkipmanAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEkipmanAdi_KeyDown);
            // 
            // cmbUniteler
            // 
            this.cmbUniteler.FormattingEnabled = true;
            this.cmbUniteler.Location = new System.Drawing.Point(80, 20);
            this.cmbUniteler.Name = "cmbUniteler";
            this.cmbUniteler.Size = new System.Drawing.Size(270, 21);
            this.cmbUniteler.TabIndex = 3;
            this.cmbUniteler.Text = "Ünite Seçin";
            this.cmbUniteler.SelectedIndexChanged += new System.EventHandler(this.cmbUniteler_SelectedIndexChanged);
            this.cmbUniteler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUniteler_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ünite Adý";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ekipman Adý";
            // 
            // dgUnite
            // 
            this.dgUnite.AllowUserToAddRows = false;
            this.dgUnite.AutoGenerateColumns = false;
            this.dgUnite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUnite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uNITEDataGridViewTextBoxColumn});
            this.dgUnite.DataSource = this.bsUnite;
            this.dgUnite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUnite.Location = new System.Drawing.Point(0, 0);
            this.dgUnite.Name = "dgUnite";
            this.dgUnite.Size = new System.Drawing.Size(357, 389);
            this.dgUnite.TabIndex = 2;
            // 
            // bsUnite
            // 
            this.bsUnite.DataMember = "Unite";
            this.bsUnite.DataSource = this.dsUniteEkipman;
            // 
            // dsUniteEkipman
            // 
            this.dsUniteEkipman.DataSetName = "AmbarTakipDataSet1";
            this.dsUniteEkipman.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgEkipman
            // 
            this.dgEkipman.AllowUserToAddRows = false;
            this.dgEkipman.AutoGenerateColumns = false;
            this.dgEkipman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEkipman.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eKIPMANDataGridViewTextBoxColumn});
            this.dgEkipman.DataSource = this.bsEkipman;
            this.dgEkipman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEkipman.Location = new System.Drawing.Point(0, 0);
            this.dgEkipman.Name = "dgEkipman";
            this.dgEkipman.Size = new System.Drawing.Size(357, 389);
            this.dgEkipman.TabIndex = 3;
            // 
            // bsEkipman
            // 
            this.bsEkipman.DataMember = "UniteEkipman";
            this.bsEkipman.DataSource = this.bsUnite;
            // 
            // taUnite
            // 
            this.taUnite.ClearBeforeFill = true;
            // 
            // taEkipman
            // 
            this.taEkipman.ClearBeforeFill = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 134);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgUnite);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgEkipman);
            this.splitContainer1.Size = new System.Drawing.Size(718, 389);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 4;
            // 
            // eKIPMANDataGridViewTextBoxColumn
            // 
            this.eKIPMANDataGridViewTextBoxColumn.DataPropertyName = "EKIPMAN";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.eKIPMANDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.eKIPMANDataGridViewTextBoxColumn.HeaderText = "EKIPMAN";
            this.eKIPMANDataGridViewTextBoxColumn.Name = "eKIPMANDataGridViewTextBoxColumn";
            this.eKIPMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uNITEDataGridViewTextBoxColumn
            // 
            this.uNITEDataGridViewTextBoxColumn.DataPropertyName = "UNITE";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uNITEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.uNITEDataGridViewTextBoxColumn.HeaderText = "UNITE";
            this.uNITEDataGridViewTextBoxColumn.Name = "uNITEDataGridViewTextBoxColumn";
            this.uNITEDataGridViewTextBoxColumn.ReadOnly = true;
            this.uNITEDataGridViewTextBoxColumn.Width = 150;
            // 
            // UniteEkipman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 535);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "UniteEkipman";
            this.Text = "Üniteler ve Ekipmanlar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UniteEkipman_KeyDown);
            this.Load += new System.EventHandler(this.UniteEkipman_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUniteEkipman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEkipman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEkipman)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUniteEkle;
        private System.Windows.Forms.ComboBox cmbUniteler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEkipmanAdi;
        private System.Windows.Forms.Button btnEkipmanEkle;
        private System.Windows.Forms.TextBox txtUniteAdi;
        private System.Windows.Forms.DataGridView dgUnite;
        private System.Windows.Forms.DataGridView dgEkipman;
        private System.Windows.Forms.BindingSource bsUnite;
        private System.Windows.Forms.BindingSource bsEkipman;
        private AmbarTakipDataSet1 dsUniteEkipman;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.UniteTableAdapter taUnite;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.EkipmanTableAdapter taEkipman;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNITEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eKIPMANDataGridViewTextBoxColumn;
    }
}