namespace Miro_TV_Manager
{
    partial class frmSettingsV3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbltheTVDB = new System.Windows.Forms.LinkLabel();
            this.txtUserkey = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkWatch = new System.Windows.Forms.CheckBox();
            this.nmMinutes = new System.Windows.Forms.NumericUpDown();
            this.btnApplyToAll = new System.Windows.Forms.Button();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.chkNewSeason = new System.Windows.Forms.CheckBox();
            this.chkAfter = new System.Windows.Forms.CheckBox();
            this.chkBefore = new System.Windows.Forms.CheckBox();
            this.pcbxSeries = new System.Windows.Forms.PictureBox();
            this.cmbSeries = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.nmDuration = new System.Windows.Forms.NumericUpDown();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.cmbTimeframe = new System.Windows.Forms.ComboBox();
            this.lblAtOn = new System.Windows.Forms.Label();
            this.chkTaskbar = new System.Windows.Forms.CheckBox();
            this.chkEnded = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lnkProwl = new System.Windows.Forms.LinkLabel();
            this.txtProwlID = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblPlex = new System.Windows.Forms.Label();
            this.TxtPlex = new System.Windows.Forms.TextBox();
            this.ChkPlex = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDuration)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbltheTVDB);
            this.groupBox1.Controls.Add(this.txtUserkey);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "theTVDB.com";
            // 
            // lbltheTVDB
            // 
            this.lbltheTVDB.AutoSize = true;
            this.lbltheTVDB.Location = new System.Drawing.Point(104, 51);
            this.lbltheTVDB.Name = "lbltheTVDB";
            this.lbltheTVDB.Size = new System.Drawing.Size(244, 13);
            this.lbltheTVDB.TabIndex = 2;
            this.lbltheTVDB.TabStop = true;
            this.lbltheTVDB.Text = "Retrieve username and Account ID from theTVDB";
            this.lbltheTVDB.Click += new System.EventHandler(this.lbltheTVDB_Click);
            // 
            // txtUserkey
            // 
            this.txtUserkey.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUserkey.Location = new System.Drawing.Point(262, 28);
            this.txtUserkey.Name = "txtUserkey";
            this.txtUserkey.Size = new System.Drawing.Size(113, 20);
            this.txtUserkey.TabIndex = 1;
            this.txtUserkey.Text = "ID key";
            this.txtUserkey.Enter += new System.EventHandler(this.txtUserkey_Enter);
            this.txtUserkey.Leave += new System.EventHandler(this.txtUserkey_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsername.Location = new System.Drawing.Point(67, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(113, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Username";
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(206, 509);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkWatch);
            this.groupBox2.Controls.Add(this.nmMinutes);
            this.groupBox2.Controls.Add(this.btnApplyToAll);
            this.groupBox2.Controls.Add(this.lblMinutes);
            this.groupBox2.Controls.Add(this.chkNewSeason);
            this.groupBox2.Controls.Add(this.chkAfter);
            this.groupBox2.Controls.Add(this.chkBefore);
            this.groupBox2.Controls.Add(this.pcbxSeries);
            this.groupBox2.Controls.Add(this.cmbSeries);
            this.groupBox2.Location = new System.Drawing.Point(9, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 194);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notify me of...";
            // 
            // chkWatch
            // 
            this.chkWatch.AutoSize = true;
            this.chkWatch.Location = new System.Drawing.Point(268, 131);
            this.chkWatch.Name = "chkWatch";
            this.chkWatch.Size = new System.Drawing.Size(99, 17);
            this.chkWatch.TabIndex = 9;
            this.chkWatch.Text = "Missed episode";
            this.chkWatch.UseVisualStyleBackColor = true;
            this.chkWatch.CheckedChanged += new System.EventHandler(this.chkWatch_CheckedChanged);
            // 
            // nmMinutes
            // 
            this.nmMinutes.Enabled = false;
            this.nmMinutes.Location = new System.Drawing.Point(86, 132);
            this.nmMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmMinutes.Name = "nmMinutes";
            this.nmMinutes.Size = new System.Drawing.Size(66, 20);
            this.nmMinutes.TabIndex = 8;
            this.nmMinutes.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nmMinutes.ValueChanged += new System.EventHandler(this.nmMinutes_ValueChanged);
            // 
            // btnApplyToAll
            // 
            this.btnApplyToAll.Location = new System.Drawing.Point(186, 165);
            this.btnApplyToAll.Name = "btnApplyToAll";
            this.btnApplyToAll.Size = new System.Drawing.Size(75, 23);
            this.btnApplyToAll.TabIndex = 7;
            this.btnApplyToAll.Text = "Apply to All";
            this.btnApplyToAll.UseVisualStyleBackColor = true;
            this.btnApplyToAll.Click += new System.EventHandler(this.btnApplyToAll_Click);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(33, 135);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(47, 13);
            this.lblMinutes.TabIndex = 6;
            this.lblMinutes.Text = "Minutes:";
            // 
            // chkNewSeason
            // 
            this.chkNewSeason.AutoSize = true;
            this.chkNewSeason.Location = new System.Drawing.Point(268, 109);
            this.chkNewSeason.Name = "chkNewSeason";
            this.chkNewSeason.Size = new System.Drawing.Size(129, 17);
            this.chkNewSeason.TabIndex = 4;
            this.chkNewSeason.Text = "New season revealed";
            this.chkNewSeason.UseVisualStyleBackColor = true;
            this.chkNewSeason.CheckedChanged += new System.EventHandler(this.chkNewSeason_CheckedChanged);
            // 
            // chkAfter
            // 
            this.chkAfter.AutoSize = true;
            this.chkAfter.Location = new System.Drawing.Point(198, 109);
            this.chkAfter.Name = "chkAfter";
            this.chkAfter.Size = new System.Drawing.Size(48, 17);
            this.chkAfter.TabIndex = 3;
            this.chkAfter.Text = "After";
            this.chkAfter.UseVisualStyleBackColor = true;
            this.chkAfter.CheckedChanged += new System.EventHandler(this.chkAfter_CheckedChanged);
            // 
            // chkBefore
            // 
            this.chkBefore.AutoSize = true;
            this.chkBefore.Location = new System.Drawing.Point(86, 109);
            this.chkBefore.Name = "chkBefore";
            this.chkBefore.Size = new System.Drawing.Size(66, 17);
            this.chkBefore.TabIndex = 2;
            this.chkBefore.Text = "Before...";
            this.chkBefore.UseVisualStyleBackColor = true;
            this.chkBefore.CheckedChanged += new System.EventHandler(this.chkBefore_CheckedChanged);
            // 
            // pcbxSeries
            // 
            this.pcbxSeries.Location = new System.Drawing.Point(86, 46);
            this.pcbxSeries.Name = "pcbxSeries";
            this.pcbxSeries.Size = new System.Drawing.Size(311, 57);
            this.pcbxSeries.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries.TabIndex = 1;
            this.pcbxSeries.TabStop = false;
            // 
            // cmbSeries
            // 
            this.cmbSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeries.FormattingEnabled = true;
            this.cmbSeries.Location = new System.Drawing.Point(130, 19);
            this.cmbSeries.MaxDropDownItems = 10;
            this.cmbSeries.Name = "cmbSeries";
            this.cmbSeries.Size = new System.Drawing.Size(218, 21);
            this.cmbSeries.TabIndex = 0;
            this.cmbSeries.SelectedIndexChanged += new System.EventHandler(this.cmbSeries_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtTime);
            this.groupBox3.Controls.Add(this.nmDuration);
            this.groupBox3.Controls.Add(this.chkUpdate);
            this.groupBox3.Controls.Add(this.cmbTimeframe);
            this.groupBox3.Controls.Add(this.lblAtOn);
            this.groupBox3.Controls.Add(this.chkTaskbar);
            this.groupBox3.Controls.Add(this.chkEnded);
            this.groupBox3.Location = new System.Drawing.Point(9, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 90);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Settings";
            // 
            // dtTime
            // 
            this.dtTime.CustomFormat = "HH:mm tt";
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTime.Location = new System.Drawing.Point(318, 63);
            this.dtTime.Name = "dtTime";
            this.dtTime.ShowUpDown = true;
            this.dtTime.Size = new System.Drawing.Size(84, 20);
            this.dtTime.TabIndex = 2;
            this.dtTime.Value = new System.DateTime(2016, 5, 30, 6, 0, 0, 0);
            this.dtTime.Visible = false;
            this.dtTime.ValueChanged += new System.EventHandler(this.dtTime_ValueChanged);
            // 
            // nmDuration
            // 
            this.nmDuration.Location = new System.Drawing.Point(180, 64);
            this.nmDuration.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmDuration.Name = "nmDuration";
            this.nmDuration.Size = new System.Drawing.Size(34, 20);
            this.nmDuration.TabIndex = 5;
            this.nmDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmDuration.ValueChanged += new System.EventHandler(this.nmDuration_ValueChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(62, 65);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(123, 17);
            this.chkUpdate.TabIndex = 7;
            this.chkUpdate.Text = "Update series every:";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // cmbTimeframe
            // 
            this.cmbTimeframe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeframe.FormattingEnabled = true;
            this.cmbTimeframe.Items.AddRange(new object[] {
            "Hours",
            "Days",
            "Months"});
            this.cmbTimeframe.Location = new System.Drawing.Point(220, 63);
            this.cmbTimeframe.Name = "cmbTimeframe";
            this.cmbTimeframe.Size = new System.Drawing.Size(71, 21);
            this.cmbTimeframe.TabIndex = 6;
            this.cmbTimeframe.SelectedIndexChanged += new System.EventHandler(this.cmbTimeframe_SelectedIndexChanged);
            // 
            // lblAtOn
            // 
            this.lblAtOn.AutoSize = true;
            this.lblAtOn.Location = new System.Drawing.Point(297, 66);
            this.lblAtOn.Name = "lblAtOn";
            this.lblAtOn.Size = new System.Drawing.Size(19, 13);
            this.lblAtOn.TabIndex = 4;
            this.lblAtOn.Text = "at:";
            this.lblAtOn.Visible = false;
            // 
            // chkTaskbar
            // 
            this.chkTaskbar.AutoSize = true;
            this.chkTaskbar.Location = new System.Drawing.Point(6, 42);
            this.chkTaskbar.Name = "chkTaskbar";
            this.chkTaskbar.Size = new System.Drawing.Size(200, 17);
            this.chkTaskbar.TabIndex = 1;
            this.chkTaskbar.Text = "Minimize to notification area on Close";
            this.chkTaskbar.UseVisualStyleBackColor = true;
            this.chkTaskbar.CheckedChanged += new System.EventHandler(this.chkTaskbar_CheckedChanged);
            // 
            // chkEnded
            // 
            this.chkEnded.AutoSize = true;
            this.chkEnded.Location = new System.Drawing.Point(6, 19);
            this.chkEnded.Name = "chkEnded";
            this.chkEnded.Size = new System.Drawing.Size(193, 17);
            this.chkEnded.TabIndex = 0;
            this.chkEnded.Text = "Notify me of series that have ended";
            this.chkEnded.UseVisualStyleBackColor = true;
            this.chkEnded.CheckedChanged += new System.EventHandler(this.chkEnded_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lnkProwl);
            this.groupBox4.Controls.Add(this.txtProwlID);
            this.groupBox4.Location = new System.Drawing.Point(9, 388);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 80);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Prowl Notification";
            // 
            // lnkProwl
            // 
            this.lnkProwl.AutoSize = true;
            this.lnkProwl.Location = new System.Drawing.Point(3, 42);
            this.lnkProwl.Name = "lnkProwl";
            this.lnkProwl.Size = new System.Drawing.Size(140, 13);
            this.lnkProwl.TabIndex = 5;
            this.lnkProwl.TabStop = true;
            this.lnkProwl.Text = "Retrieve API Key from Prowl";
            this.lnkProwl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProwl_LinkClicked);
            // 
            // txtProwlID
            // 
            this.txtProwlID.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProwlID.Location = new System.Drawing.Point(6, 19);
            this.txtProwlID.Name = "txtProwlID";
            this.txtProwlID.Size = new System.Drawing.Size(240, 20);
            this.txtProwlID.TabIndex = 4;
            this.txtProwlID.Text = "API key";
            this.txtProwlID.TextChanged += new System.EventHandler(this.txtProwlID_TextChanged);
            this.txtProwlID.Enter += new System.EventHandler(this.txtProwlID_Enter);
            this.txtProwlID.Leave += new System.EventHandler(this.txtProwlID_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 501);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(482, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(482, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Page 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ChkPlex);
            this.groupBox5.Controls.Add(this.TxtPlex);
            this.groupBox5.Controls.Add(this.LblPlex);
            this.groupBox5.Location = new System.Drawing.Point(7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(469, 74);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Plex";
            // 
            // LblPlex
            // 
            this.LblPlex.AutoSize = true;
            this.LblPlex.Enabled = false;
            this.LblPlex.Location = new System.Drawing.Point(185, 20);
            this.LblPlex.Name = "LblPlex";
            this.LblPlex.Size = new System.Drawing.Size(117, 13);
            this.LblPlex.TabIndex = 0;
            this.LblPlex.Text = "Plex database location:";
            // 
            // TxtPlex
            // 
            this.TxtPlex.Enabled = false;
            this.TxtPlex.Location = new System.Drawing.Point(301, 17);
            this.TxtPlex.Name = "TxtPlex";
            this.TxtPlex.Size = new System.Drawing.Size(162, 20);
            this.TxtPlex.TabIndex = 1;
            this.TxtPlex.Click += new System.EventHandler(this.TxtPlex_Click);
            this.TxtPlex.TextChanged += new System.EventHandler(this.TxtPlex_TextChanged);
            // 
            // ChkPlex
            // 
            this.ChkPlex.AutoSize = true;
            this.ChkPlex.Location = new System.Drawing.Point(6, 20);
            this.ChkPlex.Name = "ChkPlex";
            this.ChkPlex.Size = new System.Drawing.Size(139, 17);
            this.ChkPlex.TabIndex = 2;
            this.ChkPlex.Text = "Update seen from Plex?";
            this.ChkPlex.UseVisualStyleBackColor = true;
            this.ChkPlex.CheckedChanged += new System.EventHandler(this.ChkPlex_CheckedChanged);
            // 
            // frmSettingsV3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 544);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettingsV3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDuration)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtUserkey;
        public System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.LinkLabel lbltheTVDB;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pcbxSeries;
        private System.Windows.Forms.CheckBox chkNewSeason;
        private System.Windows.Forms.CheckBox chkAfter;
        private System.Windows.Forms.CheckBox chkBefore;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Button btnApplyToAll;
        public System.Windows.Forms.ComboBox cmbSeries;
        private System.Windows.Forms.NumericUpDown nmMinutes;
        public System.Windows.Forms.CheckBox chkEnded;
        public System.Windows.Forms.CheckBox chkTaskbar;
        private System.Windows.Forms.CheckBox chkWatch;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblAtOn;
        public System.Windows.Forms.DateTimePicker dtTime;
        public System.Windows.Forms.ComboBox cmbTimeframe;
        public System.Windows.Forms.NumericUpDown nmDuration;
        public System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel lnkProwl;
        public System.Windows.Forms.TextBox txtProwlID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblPlex;
        public System.Windows.Forms.CheckBox ChkPlex;
        public System.Windows.Forms.TextBox TxtPlex;
    }
}