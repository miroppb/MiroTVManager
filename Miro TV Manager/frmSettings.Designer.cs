namespace Miro_TV_Manager
{
    partial class frmSettings
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
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.lblTheTVDB = new System.Windows.Forms.Label();
            this.lnkDontHave = new System.Windows.Forms.LinkLabel();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.grpNotify = new System.Windows.Forms.GroupBox();
            this.pcbxCurrent = new System.Windows.Forms.PictureBox();
            this.btnApplyToAll = new System.Windows.Forms.Button();
            this.cmbBeforeTime = new System.Windows.Forms.ComboBox();
            this.chkAfter = new System.Windows.Forms.CheckBox();
            this.chkBefore = new System.Windows.Forms.CheckBox();
            this.lblNotifyMe = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.cmbSeriesList = new System.Windows.Forms.ComboBox();
            this.grpNotifications = new System.Windows.Forms.GroupBox();
            this.txtProwl = new System.Windows.Forms.TextBox();
            this.lblProwl = new System.Windows.Forms.Label();
            this.lblCloseToSave = new System.Windows.Forms.Label();
            this.grpUser.SuspendLayout();
            this.grpNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxCurrent)).BeginInit();
            this.grpNotifications.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.lblCloseToSave);
            this.grpUser.Controls.Add(this.lblTheTVDB);
            this.grpUser.Controls.Add(this.lnkDontHave);
            this.grpUser.Controls.Add(this.txtAccountID);
            this.grpUser.Location = new System.Drawing.Point(6, 12);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(524, 67);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "User Information";
            // 
            // lblTheTVDB
            // 
            this.lblTheTVDB.AutoSize = true;
            this.lblTheTVDB.Location = new System.Drawing.Point(113, 25);
            this.lblTheTVDB.Name = "lblTheTVDB";
            this.lblTheTVDB.Size = new System.Drawing.Size(86, 15);
            this.lblTheTVDB.TabIndex = 2;
            this.lblTheTVDB.Text = "TheTVDB.com:";
            // 
            // lnkDontHave
            // 
            this.lnkDontHave.AutoSize = true;
            this.lnkDontHave.Location = new System.Drawing.Point(336, 25);
            this.lnkDontHave.Name = "lnkDontHave";
            this.lnkDontHave.Size = new System.Drawing.Size(66, 15);
            this.lnkDontHave.TabIndex = 0;
            this.lnkDontHave.TabStop = true;
            this.lnkDontHave.Text = "Get yours...";
            this.lnkDontHave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDontHave_LinkClicked);
            // 
            // txtAccountID
            // 
            this.txtAccountID.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAccountID.Location = new System.Drawing.Point(205, 22);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(125, 23);
            this.txtAccountID.TabIndex = 1;
            this.txtAccountID.Text = "Account Identifier...";
            this.txtAccountID.TextChanged += new System.EventHandler(this.txtAccountID_TextChanged);
            this.txtAccountID.Enter += new System.EventHandler(this.txtAccountID_Enter);
            this.txtAccountID.Leave += new System.EventHandler(this.txtAccountID_Leave);
            // 
            // grpNotify
            // 
            this.grpNotify.Controls.Add(this.pcbxCurrent);
            this.grpNotify.Controls.Add(this.btnApplyToAll);
            this.grpNotify.Controls.Add(this.cmbBeforeTime);
            this.grpNotify.Controls.Add(this.chkAfter);
            this.grpNotify.Controls.Add(this.chkBefore);
            this.grpNotify.Controls.Add(this.lblNotifyMe);
            this.grpNotify.Controls.Add(this.lblLine);
            this.grpNotify.Controls.Add(this.cmbSeriesList);
            this.grpNotify.Location = new System.Drawing.Point(6, 85);
            this.grpNotify.Name = "grpNotify";
            this.grpNotify.Size = new System.Drawing.Size(524, 196);
            this.grpNotify.TabIndex = 1;
            this.grpNotify.TabStop = false;
            this.grpNotify.Text = "Notification Specifications";
            // 
            // pcbxCurrent
            // 
            this.pcbxCurrent.Location = new System.Drawing.Point(106, 22);
            this.pcbxCurrent.Name = "pcbxCurrent";
            this.pcbxCurrent.Size = new System.Drawing.Size(303, 56);
            this.pcbxCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxCurrent.TabIndex = 2;
            this.pcbxCurrent.TabStop = false;
            // 
            // btnApplyToAll
            // 
            this.btnApplyToAll.Location = new System.Drawing.Point(211, 168);
            this.btnApplyToAll.Name = "btnApplyToAll";
            this.btnApplyToAll.Size = new System.Drawing.Size(87, 23);
            this.btnApplyToAll.TabIndex = 6;
            this.btnApplyToAll.Text = "Apply to All";
            this.btnApplyToAll.UseVisualStyleBackColor = true;
            this.btnApplyToAll.Click += new System.EventHandler(this.btnApplyToAll_Click);
            // 
            // cmbBeforeTime
            // 
            this.cmbBeforeTime.FormattingEnabled = true;
            this.cmbBeforeTime.Items.AddRange(new object[] {
            "1 hour",
            "30 minutes",
            "15 minutes",
            "10 minutes",
            "5 minutes"});
            this.cmbBeforeTime.Location = new System.Drawing.Point(288, 116);
            this.cmbBeforeTime.Name = "cmbBeforeTime";
            this.cmbBeforeTime.Size = new System.Drawing.Size(121, 23);
            this.cmbBeforeTime.TabIndex = 5;
            this.cmbBeforeTime.SelectedIndexChanged += new System.EventHandler(this.cmbBeforeTime_SelectedIndexChanged);
            // 
            // chkAfter
            // 
            this.chkAfter.AutoSize = true;
            this.chkAfter.Location = new System.Drawing.Point(133, 145);
            this.chkAfter.Name = "chkAfter";
            this.chkAfter.Size = new System.Drawing.Size(124, 19);
            this.chkAfter.TabIndex = 4;
            this.chkAfter.Text = "After the show airs";
            this.chkAfter.UseVisualStyleBackColor = true;
            this.chkAfter.CheckedChanged += new System.EventHandler(this.chkAfter_CheckedChanged);
            // 
            // chkBefore
            // 
            this.chkBefore.AutoSize = true;
            this.chkBefore.Location = new System.Drawing.Point(133, 120);
            this.chkBefore.Name = "chkBefore";
            this.chkBefore.Size = new System.Drawing.Size(132, 19);
            this.chkBefore.TabIndex = 3;
            this.chkBefore.Text = "Before the show airs";
            this.chkBefore.UseVisualStyleBackColor = true;
            this.chkBefore.CheckedChanged += new System.EventHandler(this.chkBefore_CheckedChanged);
            // 
            // lblNotifyMe
            // 
            this.lblNotifyMe.AutoSize = true;
            this.lblNotifyMe.Location = new System.Drawing.Point(14, 132);
            this.lblNotifyMe.Name = "lblNotifyMe";
            this.lblNotifyMe.Size = new System.Drawing.Size(63, 15);
            this.lblNotifyMe.TabIndex = 2;
            this.lblNotifyMe.Text = "Notify me:";
            // 
            // lblLine
            // 
            this.lblLine.Location = new System.Drawing.Point(74, 128);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(438, 24);
            this.lblLine.TabIndex = 1;
            this.lblLine.Text = "_________________________________________________________________________________" +
    "";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbSeriesList
            // 
            this.cmbSeriesList.FormattingEnabled = true;
            this.cmbSeriesList.Location = new System.Drawing.Point(166, 84);
            this.cmbSeriesList.Name = "cmbSeriesList";
            this.cmbSeriesList.Size = new System.Drawing.Size(197, 23);
            this.cmbSeriesList.TabIndex = 0;
            this.cmbSeriesList.SelectedIndexChanged += new System.EventHandler(this.cmbSeriesList_SelectedIndexChanged);
            // 
            // grpNotifications
            // 
            this.grpNotifications.Controls.Add(this.txtProwl);
            this.grpNotifications.Controls.Add(this.lblProwl);
            this.grpNotifications.Location = new System.Drawing.Point(6, 287);
            this.grpNotifications.Name = "grpNotifications";
            this.grpNotifications.Size = new System.Drawing.Size(524, 126);
            this.grpNotifications.TabIndex = 7;
            this.grpNotifications.TabStop = false;
            this.grpNotifications.Text = "Ways to Get Notified";
            // 
            // txtProwl
            // 
            this.txtProwl.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProwl.Location = new System.Drawing.Point(194, 16);
            this.txtProwl.Name = "txtProwl";
            this.txtProwl.Size = new System.Drawing.Size(252, 23);
            this.txtProwl.TabIndex = 1;
            this.txtProwl.Text = "API Key...";
            this.txtProwl.TextChanged += new System.EventHandler(this.txtProwl_TextChanged);
            this.txtProwl.Enter += new System.EventHandler(this.txtProwl_Enter);
            this.txtProwl.Leave += new System.EventHandler(this.txtProwl_Leave);
            // 
            // lblProwl
            // 
            this.lblProwl.AutoSize = true;
            this.lblProwl.Location = new System.Drawing.Point(82, 19);
            this.lblProwl.Name = "lblProwl";
            this.lblProwl.Size = new System.Drawing.Size(106, 15);
            this.lblProwl.TabIndex = 0;
            this.lblProwl.Text = "Prowl Notification:";
            // 
            // lblCloseToSave
            // 
            this.lblCloseToSave.AutoSize = true;
            this.lblCloseToSave.Location = new System.Drawing.Point(178, 48);
            this.lblCloseToSave.Name = "lblCloseToSave";
            this.lblCloseToSave.Size = new System.Drawing.Size(185, 15);
            this.lblCloseToSave.TabIndex = 3;
            this.lblCloseToSave.Text = "Close the window in order to save";
            this.lblCloseToSave.Visible = false;
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(544, 430);
            this.Controls.Add(this.grpNotifications);
            this.Controls.Add(this.grpNotify);
            this.Controls.Add(this.grpUser);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyUp);
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.grpNotify.ResumeLayout(false);
            this.grpNotify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxCurrent)).EndInit();
            this.grpNotifications.ResumeLayout(false);
            this.grpNotifications.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Label lblTheTVDB;
        private System.Windows.Forms.LinkLabel lnkDontHave;
        private System.Windows.Forms.GroupBox grpNotify;
        private System.Windows.Forms.ComboBox cmbSeriesList;
        private System.Windows.Forms.CheckBox chkAfter;
        private System.Windows.Forms.CheckBox chkBefore;
        private System.Windows.Forms.Label lblNotifyMe;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.ComboBox cmbBeforeTime;
        private System.Windows.Forms.Button btnApplyToAll;
        private System.Windows.Forms.PictureBox pcbxCurrent;
        private System.Windows.Forms.GroupBox grpNotifications;
        private System.Windows.Forms.TextBox txtProwl;
        private System.Windows.Forms.Label lblProwl;
        private System.Windows.Forms.Label lblCloseToSave;
    }
}