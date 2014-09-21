namespace AmbarTakip
{
    partial class MalzemeArama
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYTNO = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvArama = new System.Windows.Forms.DataGridView();
            this.yTNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mALZEMEADIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mARKADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPECTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uNITEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eKIPMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAFNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsArama = new System.Windows.Forms.BindingSource(this.components);
            this.dsArama = new AmbarTakip.AmbarTakipDataSet1();
            this.taArama = new AmbarTakip.AmbarTakipDataSet1TableAdapters.TumOzelliklerTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMalzemeAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpect = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsArama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsArama)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "YTNO";
            // 
            // txtYTNO
            // 
            this.txtYTNO.Location = new System.Drawing.Point(51, 28);
            this.txtYTNO.Name = "txtYTNO";
            this.txtYTNO.Size = new System.Drawing.Size(209, 20);
            this.txtYTNO.TabIndex = 1;
            this.txtYTNO.TextChanged += new System.EventHandler(this.txtYTNO_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSpect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMalzemeAdi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtYTNO);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arama Seçenekleri";
            // 
            // dgvArama
            // 
            this.dgvArama.AllowUserToAddRows = false;
            this.dgvArama.AllowUserToDeleteRows = false;
            this.dgvArama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArama.AutoGenerateColumns = false;
            this.dgvArama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArama.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yTNODataGridViewTextBoxColumn,
            this.mALZEMEADIDataGridViewTextBoxColumn,
            this.mARKADataGridViewTextBoxColumn,
            this.sPECTDataGridViewTextBoxColumn,
            this.uNITEDataGridViewTextBoxColumn,
            this.eKIPMANDataGridViewTextBoxColumn,
            this.rAFNODataGridViewTextBoxColumn,
            this.aDETDataGridViewTextBoxColumn,
            this.cMIN,
            this.cMAX});
            this.dgvArama.DataSource = this.bsArama;
            this.dgvArama.Location = new System.Drawing.Point(12, 82);
            this.dgvArama.Name = "dgvArama";
            this.dgvArama.Size = new System.Drawing.Size(946, 378);
            this.dgvArama.TabIndex = 9;
            this.dgvArama.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArama_CellDoubleClick);
            // 
            // yTNODataGridViewTextBoxColumn
            // 
            this.yTNODataGridViewTextBoxColumn.DataPropertyName = "YTNO";
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yTNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle41;
            this.yTNODataGridViewTextBoxColumn.HeaderText = "YTNO";
            this.yTNODataGridViewTextBoxColumn.Name = "yTNODataGridViewTextBoxColumn";
            this.yTNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mALZEMEADIDataGridViewTextBoxColumn
            // 
            this.mALZEMEADIDataGridViewTextBoxColumn.DataPropertyName = "MALZEMEADI";
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mALZEMEADIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle42;
            this.mALZEMEADIDataGridViewTextBoxColumn.HeaderText = "MALZEMEADI";
            this.mALZEMEADIDataGridViewTextBoxColumn.Name = "mALZEMEADIDataGridViewTextBoxColumn";
            this.mALZEMEADIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mARKADataGridViewTextBoxColumn
            // 
            this.mARKADataGridViewTextBoxColumn.DataPropertyName = "MARKA";
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mARKADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle43;
            this.mARKADataGridViewTextBoxColumn.HeaderText = "MARKA";
            this.mARKADataGridViewTextBoxColumn.Name = "mARKADataGridViewTextBoxColumn";
            this.mARKADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPECTDataGridViewTextBoxColumn
            // 
            this.sPECTDataGridViewTextBoxColumn.DataPropertyName = "SPECT";
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sPECTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle44;
            this.sPECTDataGridViewTextBoxColumn.HeaderText = "SPECT";
            this.sPECTDataGridViewTextBoxColumn.Name = "sPECTDataGridViewTextBoxColumn";
            this.sPECTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uNITEDataGridViewTextBoxColumn
            // 
            this.uNITEDataGridViewTextBoxColumn.DataPropertyName = "UNITE";
            dataGridViewCellStyle45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uNITEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle45;
            this.uNITEDataGridViewTextBoxColumn.HeaderText = "UNITE";
            this.uNITEDataGridViewTextBoxColumn.Name = "uNITEDataGridViewTextBoxColumn";
            this.uNITEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eKIPMANDataGridViewTextBoxColumn
            // 
            this.eKIPMANDataGridViewTextBoxColumn.DataPropertyName = "EKIPMAN";
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.eKIPMANDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle46;
            this.eKIPMANDataGridViewTextBoxColumn.HeaderText = "EKIPMAN";
            this.eKIPMANDataGridViewTextBoxColumn.Name = "eKIPMANDataGridViewTextBoxColumn";
            this.eKIPMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rAFNODataGridViewTextBoxColumn
            // 
            this.rAFNODataGridViewTextBoxColumn.DataPropertyName = "RAFNO";
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rAFNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle47;
            this.rAFNODataGridViewTextBoxColumn.HeaderText = "RAFNO";
            this.rAFNODataGridViewTextBoxColumn.Name = "rAFNODataGridViewTextBoxColumn";
            this.rAFNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDETDataGridViewTextBoxColumn
            // 
            this.aDETDataGridViewTextBoxColumn.DataPropertyName = "ADET";
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.aDETDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle48;
            this.aDETDataGridViewTextBoxColumn.HeaderText = "ADET";
            this.aDETDataGridViewTextBoxColumn.Name = "aDETDataGridViewTextBoxColumn";
            this.aDETDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cMIN
            // 
            this.cMIN.DataPropertyName = "MIN";
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cMIN.DefaultCellStyle = dataGridViewCellStyle49;
            this.cMIN.HeaderText = "MIN";
            this.cMIN.Name = "cMIN";
            this.cMIN.ReadOnly = true;
            // 
            // cMAX
            // 
            this.cMAX.DataPropertyName = "MIN";
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cMAX.DefaultCellStyle = dataGridViewCellStyle50;
            this.cMAX.HeaderText = "MAX";
            this.cMAX.Name = "cMAX";
            this.cMAX.ReadOnly = true;
            // 
            // bsArama
            // 
            this.bsArama.DataMember = "TumOzellikler";
            this.bsArama.DataSource = this.dsArama;
            // 
            // dsArama
            // 
            this.dsArama.DataSetName = "AmbarTakipDataSet1";
            this.dsArama.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taArama
            // 
            this.taArama.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MALZEME ADI";
            // 
            // txtMalzemeAdi
            // 
            this.txtMalzemeAdi.Location = new System.Drawing.Point(402, 28);
            this.txtMalzemeAdi.Name = "txtMalzemeAdi";
            this.txtMalzemeAdi.Size = new System.Drawing.Size(209, 20);
            this.txtMalzemeAdi.TabIndex = 3;
            this.txtMalzemeAdi.TextChanged += new System.EventHandler(this.txtMalzemeAdi_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SPECT";
            // 
            // txtSpect
            // 
            this.txtSpect.Location = new System.Drawing.Point(701, 28);
            this.txtSpect.Name = "txtSpect";
            this.txtSpect.Size = new System.Drawing.Size(209, 20);
            this.txtSpect.TabIndex = 5;
            this.txtSpect.TextChanged += new System.EventHandler(this.txtSpect_TextChanged);
            // 
            // MalzemeArama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 472);
            this.Controls.Add(this.dgvArama);
            this.Controls.Add(this.groupBox1);
            this.Name = "MalzemeArama";
            this.Text = "Malzeme Arama";
            this.Load += new System.EventHandler(this.MalzemeArama_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsArama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsArama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYTNO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvArama;
        private System.Windows.Forms.BindingSource bsArama;
        private AmbarTakipDataSet1 dsArama;
        private AmbarTakip.AmbarTakipDataSet1TableAdapters.TumOzelliklerTableAdapter taArama;
        private System.Windows.Forms.DataGridViewTextBoxColumn yTNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mALZEMEADIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mARKADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPECTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNITEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eKIPMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAFNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMAX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMalzemeAdi;
    }
}