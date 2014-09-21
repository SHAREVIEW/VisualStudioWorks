namespace RTCClient
{
    partial class frmDogrulama
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.txtKimlik = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.cmdTamam = new System.Windows.Forms.Button();
            this.cmdIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanýcý Adý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Þifre";
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(86, 6);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(249, 20);
            this.txtURI.TabIndex = 3;
            // 
            // txtKimlik
            // 
            this.txtKimlik.Location = new System.Drawing.Point(86, 32);
            this.txtKimlik.Name = "txtKimlik";
            this.txtKimlik.Size = new System.Drawing.Size(249, 20);
            this.txtKimlik.TabIndex = 4;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(86, 58);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(249, 20);
            this.txtSifre.TabIndex = 5;
            // 
            // cmdTamam
            // 
            this.cmdTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdTamam.Location = new System.Drawing.Point(179, 84);
            this.cmdTamam.Name = "cmdTamam";
            this.cmdTamam.Size = new System.Drawing.Size(75, 23);
            this.cmdTamam.TabIndex = 6;
            this.cmdTamam.Text = "Tamam";
            this.cmdTamam.UseVisualStyleBackColor = true;
            this.cmdTamam.Click += new System.EventHandler(this.cmdTamam_Click);
            // 
            // cmdIptal
            // 
            this.cmdIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdIptal.Location = new System.Drawing.Point(260, 84);
            this.cmdIptal.Name = "cmdIptal";
            this.cmdIptal.Size = new System.Drawing.Size(75, 23);
            this.cmdIptal.TabIndex = 7;
            this.cmdIptal.Text = "Ýptal";
            this.cmdIptal.UseVisualStyleBackColor = true;
            // 
            // frmDogrulama
            // 
            this.AcceptButton = this.cmdTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdIptal;
            this.ClientSize = new System.Drawing.Size(347, 116);
            this.Controls.Add(this.cmdIptal);
            this.Controls.Add(this.cmdTamam);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKimlik);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDogrulama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kullanýcý Doðrulama";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.TextBox txtKimlik;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button cmdTamam;
        private System.Windows.Forms.Button cmdIptal;
    }
}