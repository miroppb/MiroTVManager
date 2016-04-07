namespace Miro_TV_Manager
{
    partial class frmSplash
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
            this.progressStart = new System.Windows.Forms.ProgressBar();
            this.lblLoaded = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressStart
            // 
            this.progressStart.Location = new System.Drawing.Point(349, 510);
            this.progressStart.Name = "progressStart";
            this.progressStart.Size = new System.Drawing.Size(256, 36);
            this.progressStart.TabIndex = 0;
            // 
            // lblLoaded
            // 
            this.lblLoaded.BackColor = System.Drawing.Color.Transparent;
            this.lblLoaded.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaded.Location = new System.Drawing.Point(349, 489);
            this.lblLoaded.Name = "lblLoaded";
            this.lblLoaded.Size = new System.Drawing.Size(256, 18);
            this.lblLoaded.TabIndex = 2;
            this.lblLoaded.Text = "Downloaded/Processed: ";
            this.lblLoaded.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSplash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Miro_TV_Manager.Properties.Resources.film_and_movie_reel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(945, 593);
            this.ControlBox = false;
            this.Controls.Add(this.lblLoaded);
            this.Controls.Add(this.progressStart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressStart;
        public System.Windows.Forms.Label lblLoaded;

    }
}