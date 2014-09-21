namespace AmbarTakip
{
    partial class ResimGoster
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
            this.picResim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResim)).BeginInit();
            this.SuspendLayout();
            // 
            // picResim
            // 
            this.picResim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picResim.Location = new System.Drawing.Point(0, 0);
            this.picResim.Name = "picResim";
            this.picResim.Size = new System.Drawing.Size(292, 266);
            this.picResim.TabIndex = 0;
            this.picResim.TabStop = false;
            // 
            // ResimGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.picResim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "ResimGoster";
            this.Text = "ResimGoster";
            this.Load += new System.EventHandler(this.ResimGoster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picResim;
    }
}