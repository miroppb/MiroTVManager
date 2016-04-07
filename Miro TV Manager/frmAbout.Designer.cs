namespace Miro_TV_Manager
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pcbxLogo = new System.Windows.Forms.PictureBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.pcbxTheTVDB = new System.Windows.Forms.PictureBox();
            this.pcbxTwitter = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.lnkTHETVDB = new System.Windows.Forms.LinkLabel();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTheTVDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTwitter)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbxLogo
            // 
            this.pcbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbxLogo.BackgroundImage = global::Miro_TV_Manager.Properties.Resources.logo3;
            this.pcbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbxLogo.Location = new System.Drawing.Point(113, 12);
            this.pcbxLogo.Name = "pcbxLogo";
            this.pcbxLogo.Size = new System.Drawing.Size(579, 96);
            this.pcbxLogo.TabIndex = 1;
            this.pcbxLogo.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxLogo, "Visit my site: http://miroppb.com");
            this.pcbxLogo.Click += new System.EventHandler(this.pcbxLogo_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.BackColor = System.Drawing.Color.Transparent;
            this.lblAbout.Location = new System.Drawing.Point(15, 111);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(763, 263);
            this.lblAbout.TabIndex = 0;
            this.lblAbout.Text = resources.GetString("lblAbout.Text");
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pcbxTheTVDB
            // 
            this.pcbxTheTVDB.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTheTVDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbxTheTVDB.BackgroundImage")));
            this.pcbxTheTVDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbxTheTVDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbxTheTVDB.Location = new System.Drawing.Point(18, 377);
            this.pcbxTheTVDB.Name = "pcbxTheTVDB";
            this.pcbxTheTVDB.Size = new System.Drawing.Size(261, 136);
            this.pcbxTheTVDB.TabIndex = 2;
            this.pcbxTheTVDB.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxTheTVDB, "http://thetvdb.com");
            this.pcbxTheTVDB.Click += new System.EventHandler(this.pcbxTheTVDB_Click);
            // 
            // pcbxTwitter
            // 
            this.pcbxTwitter.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTwitter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbxTwitter.BackgroundImage")));
            this.pcbxTwitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbxTwitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbxTwitter.Location = new System.Drawing.Point(647, 384);
            this.pcbxTwitter.Name = "pcbxTwitter";
            this.pcbxTwitter.Size = new System.Drawing.Size(119, 119);
            this.pcbxTwitter.TabIndex = 3;
            this.pcbxTwitter.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxTwitter, "Follow me on Twitter: @miroppb");
            this.pcbxTwitter.Click += new System.EventHandler(this.pcbxTwitter_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Location = new System.Drawing.Point(333, 491);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(76, 34);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Placeholder\r\nText";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lnkTHETVDB
            // 
            this.lnkTHETVDB.AutoSize = true;
            this.lnkTHETVDB.BackColor = System.Drawing.Color.Transparent;
            this.lnkTHETVDB.Location = new System.Drawing.Point(197, 281);
            this.lnkTHETVDB.Name = "lnkTHETVDB";
            this.lnkTHETVDB.Size = new System.Drawing.Size(116, 17);
            this.lnkTHETVDB.TabIndex = 5;
            this.lnkTHETVDB.TabStop = true;
            this.lnkTHETVDB.Text = "http://thetvdb.com";
            this.lnkTHETVDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTHETVDB_LinkClicked);
            // 
            // lnkEmail
            // 
            this.lnkEmail.AutoSize = true;
            this.lnkEmail.BackColor = System.Drawing.Color.Transparent;
            this.lnkEmail.Location = new System.Drawing.Point(645, 332);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(126, 17);
            this.lnkEmail.TabIndex = 6;
            this.lnkEmail.TabStop = true;
            this.lnkEmail.Text = "miro@miroppb.com";
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Miro_TV_Manager.Properties.Resources.circuit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(798, 534);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.lnkTHETVDB);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pcbxTwitter);
            this.Controls.Add(this.pcbxTheTVDB);
            this.Controls.Add(this.pcbxLogo);
            this.Controls.Add(this.lblAbout);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About - Miro TV Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTheTVDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTwitter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbxLogo;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.PictureBox pcbxTheTVDB;
        private System.Windows.Forms.PictureBox pcbxTwitter;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel lnkTHETVDB;
        private System.Windows.Forms.LinkLabel lnkEmail;
    }
}