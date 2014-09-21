namespace RTCClient
{
    partial class frmKisiEkle
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
            this.cmdTamam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.cmdIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdTamam
            // 
            this.cmdTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdTamam.Location = new System.Drawing.Point(138, 32);
            this.cmdTamam.Name = "cmdTamam";
            this.cmdTamam.Size = new System.Drawing.Size(75, 23);
            this.cmdTamam.TabIndex = 5;
            this.cmdTamam.Text = "Tamam";
            this.cmdTamam.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kiþi URI";
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(59, 5);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(235, 20);
            this.txtURI.TabIndex = 0;
            // 
            // cmdIptal
            // 
            this.cmdIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdIptal.Location = new System.Drawing.Point(219, 32);
            this.cmdIptal.Name = "cmdIptal";
            this.cmdIptal.Size = new System.Drawing.Size(75, 23);
            this.cmdIptal.TabIndex = 3;
            this.cmdIptal.Text = "Ýptal";
            this.cmdIptal.UseVisualStyleBackColor = true;
            // 
            // frmKisiEkle
            // 
            this.AcceptButton = this.cmdTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdIptal;
            this.ClientSize = new System.Drawing.Size(306, 61);
            this.ControlBox = false;
            this.Controls.Add(this.cmdIptal);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdTamam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKisiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiþi Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTamam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.Button cmdIptal;
    }
}