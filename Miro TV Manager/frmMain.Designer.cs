namespace Miro_TV_Manager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcbxCurrentSeries = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblSeasons = new System.Windows.Forms.Label();
            this.lblEpisodes = new System.Windows.Forms.Label();
            this.lblAirsOn = new System.Windows.Forms.Label();
            this.lblAirsAt = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtActors = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtEpisodes = new System.Windows.Forms.TextBox();
            this.txtSeasons = new System.Windows.Forms.TextBox();
            this.txtAirsAt = new System.Windows.Forms.TextBox();
            this.txtAirsOn = new System.Windows.Forms.TextBox();
            this.lstOverview = new System.Windows.Forms.ListView();
            this.Ep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstAired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Aired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSeriesDescription = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pcbxSearchDelete = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.progressSearch = new System.Windows.Forms.ProgressBar();
            this.pcbxTop1 = new System.Windows.Forms.PictureBox();
            this.pcbxUp = new System.Windows.Forms.PictureBox();
            this.pcbxTop2 = new System.Windows.Forms.PictureBox();
            this.pcbxTop3 = new System.Windows.Forms.PictureBox();
            this.pcbxTop4 = new System.Windows.Forms.PictureBox();
            this.pcbxTop5 = new System.Windows.Forms.PictureBox();
            this.pcbxDown = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pcbxDelete1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pcbxDelete2 = new System.Windows.Forms.PictureBox();
            this.pcbxDelete3 = new System.Windows.Forms.PictureBox();
            this.pcbxDelete4 = new System.Windows.Forms.PictureBox();
            this.pcbxDelete5 = new System.Windows.Forms.PictureBox();
            this.ntfy = new System.Windows.Forms.NotifyIcon(this.components);
            this.rchEpisodeDescription = new System.Windows.Forms.RichTextBox();
            this.timerNotify = new System.Windows.Forms.Timer(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblNextShow = new System.Windows.Forms.Label();
            this.timerNextShow = new System.Windows.Forms.Timer(this.components);
            this.lblEnded = new System.Windows.Forms.Label();
            this.timerVersionCheck = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxCurrentSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSearchDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete5)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exiToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exiToolStripMenuItem
            // 
            this.exiToolStripMenuItem.Name = "exiToolStripMenuItem";
            this.exiToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exiToolStripMenuItem.Text = "Exit";
            this.exiToolStripMenuItem.Click += new System.EventHandler(this.exiToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearCacheToolStripMenuItem,
            this.forceUpdateToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Image = global::Miro_TV_Manager.Properties.Resources.broom_icon;
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.clearCacheToolStripMenuItem.Text = "Clear Cache";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItem_Click);
            // 
            // forceUpdateToolStripMenuItem
            // 
            this.forceUpdateToolStripMenuItem.Image = global::Miro_TV_Manager.Properties.Resources.Apps_system_software_update_icon;
            this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.forceUpdateToolStripMenuItem.Text = "Force Update";
            this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::Miro_TV_Manager.Properties.Resources.Gear_icon;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changelogToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Image = global::Miro_TV_Manager.Properties.Resources.Text_Document_icon;
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for Update...";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pcbxCurrentSeries
            // 
            this.pcbxCurrentSeries.BackColor = System.Drawing.Color.Transparent;
            this.pcbxCurrentSeries.Location = new System.Drawing.Point(40, 39);
            this.pcbxCurrentSeries.Name = "pcbxCurrentSeries";
            this.pcbxCurrentSeries.Size = new System.Drawing.Size(379, 70);
            this.pcbxCurrentSeries.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxCurrentSeries.TabIndex = 1;
            this.pcbxCurrentSeries.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(18, 115);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 15);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            // 
            // lblActors
            // 
            this.lblActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActors.AutoSize = true;
            this.lblActors.BackColor = System.Drawing.Color.Transparent;
            this.lblActors.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActors.Location = new System.Drawing.Point(18, 151);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(44, 15);
            this.lblActors.TabIndex = 3;
            this.lblActors.Text = "Actors:";
            // 
            // lblRating
            // 
            this.lblRating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRating.AutoSize = true;
            this.lblRating.BackColor = System.Drawing.Color.Transparent;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(18, 187);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(44, 15);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Rating:";
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenre.AutoSize = true;
            this.lblGenre.BackColor = System.Drawing.Color.Transparent;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.Location = new System.Drawing.Point(18, 223);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(41, 15);
            this.lblGenre.TabIndex = 5;
            this.lblGenre.Text = "Genre:";
            // 
            // lblSeasons
            // 
            this.lblSeasons.AutoSize = true;
            this.lblSeasons.BackColor = System.Drawing.Color.Transparent;
            this.lblSeasons.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeasons.ForeColor = System.Drawing.Color.Black;
            this.lblSeasons.Location = new System.Drawing.Point(276, 115);
            this.lblSeasons.Name = "lblSeasons";
            this.lblSeasons.Size = new System.Drawing.Size(53, 15);
            this.lblSeasons.TabIndex = 6;
            this.lblSeasons.Text = "Seasons:";
            // 
            // lblEpisodes
            // 
            this.lblEpisodes.AutoSize = true;
            this.lblEpisodes.BackColor = System.Drawing.Color.Transparent;
            this.lblEpisodes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodes.ForeColor = System.Drawing.Color.Black;
            this.lblEpisodes.Location = new System.Drawing.Point(274, 151);
            this.lblEpisodes.Name = "lblEpisodes";
            this.lblEpisodes.Size = new System.Drawing.Size(56, 15);
            this.lblEpisodes.TabIndex = 7;
            this.lblEpisodes.Text = "Episodes:";
            // 
            // lblAirsOn
            // 
            this.lblAirsOn.AutoSize = true;
            this.lblAirsOn.BackColor = System.Drawing.Color.Transparent;
            this.lblAirsOn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirsOn.ForeColor = System.Drawing.Color.Black;
            this.lblAirsOn.Location = new System.Drawing.Point(285, 187);
            this.lblAirsOn.Name = "lblAirsOn";
            this.lblAirsOn.Size = new System.Drawing.Size(47, 15);
            this.lblAirsOn.TabIndex = 8;
            this.lblAirsOn.Text = "Airs on:";
            // 
            // lblAirsAt
            // 
            this.lblAirsAt.AutoSize = true;
            this.lblAirsAt.BackColor = System.Drawing.Color.Transparent;
            this.lblAirsAt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirsAt.ForeColor = System.Drawing.Color.Black;
            this.lblAirsAt.Location = new System.Drawing.Point(288, 223);
            this.lblAirsAt.Name = "lblAirsAt";
            this.lblAirsAt.Size = new System.Drawing.Size(43, 15);
            this.lblAirsAt.TabIndex = 9;
            this.lblAirsAt.Text = "Airs at:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(188, 226);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 15);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(60, 112);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(188, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // txtActors
            // 
            this.txtActors.BackColor = System.Drawing.Color.White;
            this.txtActors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActors.Location = new System.Drawing.Point(60, 148);
            this.txtActors.Name = "txtActors";
            this.txtActors.ReadOnly = true;
            this.txtActors.Size = new System.Drawing.Size(188, 23);
            this.txtActors.TabIndex = 2;
            // 
            // txtRating
            // 
            this.txtRating.BackColor = System.Drawing.Color.White;
            this.txtRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRating.Location = new System.Drawing.Point(60, 184);
            this.txtRating.Name = "txtRating";
            this.txtRating.ReadOnly = true;
            this.txtRating.Size = new System.Drawing.Size(109, 23);
            this.txtRating.TabIndex = 3;
            // 
            // txtGenre
            // 
            this.txtGenre.BackColor = System.Drawing.Color.White;
            this.txtGenre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenre.Location = new System.Drawing.Point(60, 220);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.ReadOnly = true;
            this.txtGenre.Size = new System.Drawing.Size(109, 23);
            this.txtGenre.TabIndex = 4;
            // 
            // txtEpisodes
            // 
            this.txtEpisodes.BackColor = System.Drawing.Color.White;
            this.txtEpisodes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpisodes.Location = new System.Drawing.Point(333, 148);
            this.txtEpisodes.Name = "txtEpisodes";
            this.txtEpisodes.ReadOnly = true;
            this.txtEpisodes.Size = new System.Drawing.Size(119, 23);
            this.txtEpisodes.TabIndex = 6;
            // 
            // txtSeasons
            // 
            this.txtSeasons.BackColor = System.Drawing.Color.White;
            this.txtSeasons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeasons.Location = new System.Drawing.Point(333, 112);
            this.txtSeasons.Name = "txtSeasons";
            this.txtSeasons.ReadOnly = true;
            this.txtSeasons.Size = new System.Drawing.Size(119, 23);
            this.txtSeasons.TabIndex = 5;
            // 
            // txtAirsAt
            // 
            this.txtAirsAt.BackColor = System.Drawing.Color.White;
            this.txtAirsAt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAirsAt.Location = new System.Drawing.Point(333, 220);
            this.txtAirsAt.Name = "txtAirsAt";
            this.txtAirsAt.ReadOnly = true;
            this.txtAirsAt.Size = new System.Drawing.Size(119, 23);
            this.txtAirsAt.TabIndex = 8;
            // 
            // txtAirsOn
            // 
            this.txtAirsOn.BackColor = System.Drawing.Color.White;
            this.txtAirsOn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAirsOn.Location = new System.Drawing.Point(333, 184);
            this.txtAirsOn.Name = "txtAirsOn";
            this.txtAirsOn.ReadOnly = true;
            this.txtAirsOn.Size = new System.Drawing.Size(119, 23);
            this.txtAirsOn.TabIndex = 7;
            // 
            // lstOverview
            // 
            this.lstOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstOverview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ep,
            this.Title,
            this.Rating,
            this.FirstAired,
            this.Aired});
            this.lstOverview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOverview.FullRowSelect = true;
            this.lstOverview.Location = new System.Drawing.Point(12, 360);
            this.lstOverview.MultiSelect = false;
            this.lstOverview.Name = "lstOverview";
            this.lstOverview.Size = new System.Drawing.Size(440, 181);
            this.lstOverview.TabIndex = 10;
            this.lstOverview.UseCompatibleStateImageBehavior = false;
            this.lstOverview.View = System.Windows.Forms.View.Details;
            this.lstOverview.SelectedIndexChanged += new System.EventHandler(this.lstOverview_SelectedIndexChanged);
            // 
            // Ep
            // 
            this.Ep.Text = "Ep";
            this.Ep.Width = 28;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Title.Width = 180;
            // 
            // Rating
            // 
            this.Rating.Text = "Rating";
            this.Rating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Rating.Width = 90;
            // 
            // FirstAired
            // 
            this.FirstAired.Text = "First Aired";
            this.FirstAired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstAired.Width = 72;
            // 
            // Aired
            // 
            this.Aired.Text = "Aired?";
            this.Aired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Aired.Width = 48;
            // 
            // txtSeriesDescription
            // 
            this.txtSeriesDescription.BackColor = System.Drawing.Color.White;
            this.txtSeriesDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesDescription.Location = new System.Drawing.Point(12, 245);
            this.txtSeriesDescription.Multiline = true;
            this.txtSeriesDescription.Name = "txtSeriesDescription";
            this.txtSeriesDescription.ReadOnly = true;
            this.txtSeriesDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSeriesDescription.Size = new System.Drawing.Size(440, 109);
            this.txtSeriesDescription.TabIndex = 9;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSearch.Location = new System.Drawing.Point(313, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pcbxSearchDelete
            // 
            this.pcbxSearchDelete.BackColor = System.Drawing.Color.White;
            this.pcbxSearchDelete.Image = global::Miro_TV_Manager.Properties.Resources.System_Delete_icon;
            this.pcbxSearchDelete.Location = new System.Drawing.Point(431, 12);
            this.pcbxSearchDelete.Name = "pcbxSearchDelete";
            this.pcbxSearchDelete.Size = new System.Drawing.Size(19, 19);
            this.pcbxSearchDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxSearchDelete.TabIndex = 22;
            this.pcbxSearchDelete.TabStop = false;
            this.pcbxSearchDelete.Visible = false;
            this.pcbxSearchDelete.Click += new System.EventHandler(this.pcbxSearchDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(456, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(53, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // progressSearch
            // 
            this.progressSearch.BackColor = System.Drawing.Color.White;
            this.progressSearch.Location = new System.Drawing.Point(313, 10);
            this.progressSearch.Name = "progressSearch";
            this.progressSearch.Size = new System.Drawing.Size(139, 23);
            this.progressSearch.TabIndex = 0;
            this.progressSearch.Visible = false;
            // 
            // pcbxTop1
            // 
            this.pcbxTop1.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTop1.Location = new System.Drawing.Point(456, 52);
            this.pcbxTop1.Name = "pcbxTop1";
            this.pcbxTop1.Size = new System.Drawing.Size(379, 70);
            this.pcbxTop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxTop1.TabIndex = 26;
            this.pcbxTop1.TabStop = false;
            this.pcbxTop1.Click += new System.EventHandler(this.pcbxTop1_Click);
            // 
            // pcbxUp
            // 
            this.pcbxUp.BackColor = System.Drawing.Color.Transparent;
            this.pcbxUp.Image = global::Miro_TV_Manager.Properties.Resources.arrow_up;
            this.pcbxUp.Location = new System.Drawing.Point(841, 8);
            this.pcbxUp.Name = "pcbxUp";
            this.pcbxUp.Size = new System.Drawing.Size(40, 44);
            this.pcbxUp.TabIndex = 27;
            this.pcbxUp.TabStop = false;
            this.pcbxUp.Visible = false;
            this.pcbxUp.Click += new System.EventHandler(this.pcbxUp_Click);
            this.pcbxUp.MouseLeave += new System.EventHandler(this.pcbxUp_MouseLeave);
            this.pcbxUp.MouseHover += new System.EventHandler(this.pcbxUp_MouseHover);
            // 
            // pcbxTop2
            // 
            this.pcbxTop2.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTop2.Location = new System.Drawing.Point(456, 128);
            this.pcbxTop2.Name = "pcbxTop2";
            this.pcbxTop2.Size = new System.Drawing.Size(379, 70);
            this.pcbxTop2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxTop2.TabIndex = 28;
            this.pcbxTop2.TabStop = false;
            this.pcbxTop2.Click += new System.EventHandler(this.pcbxTop2_Click);
            // 
            // pcbxTop3
            // 
            this.pcbxTop3.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTop3.Location = new System.Drawing.Point(456, 204);
            this.pcbxTop3.Name = "pcbxTop3";
            this.pcbxTop3.Size = new System.Drawing.Size(379, 70);
            this.pcbxTop3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxTop3.TabIndex = 29;
            this.pcbxTop3.TabStop = false;
            this.pcbxTop3.Click += new System.EventHandler(this.pcbxTop3_Click);
            // 
            // pcbxTop4
            // 
            this.pcbxTop4.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTop4.Location = new System.Drawing.Point(456, 280);
            this.pcbxTop4.Name = "pcbxTop4";
            this.pcbxTop4.Size = new System.Drawing.Size(379, 70);
            this.pcbxTop4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxTop4.TabIndex = 30;
            this.pcbxTop4.TabStop = false;
            this.pcbxTop4.Click += new System.EventHandler(this.pcbxTop4_Click);
            // 
            // pcbxTop5
            // 
            this.pcbxTop5.BackColor = System.Drawing.Color.Transparent;
            this.pcbxTop5.Location = new System.Drawing.Point(457, 356);
            this.pcbxTop5.Name = "pcbxTop5";
            this.pcbxTop5.Size = new System.Drawing.Size(379, 70);
            this.pcbxTop5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxTop5.TabIndex = 31;
            this.pcbxTop5.TabStop = false;
            this.pcbxTop5.Click += new System.EventHandler(this.pcbxTop5_Click);
            // 
            // pcbxDown
            // 
            this.pcbxDown.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDown.Image = global::Miro_TV_Manager.Properties.Resources.arrow_down;
            this.pcbxDown.Location = new System.Drawing.Point(841, 424);
            this.pcbxDown.Name = "pcbxDown";
            this.pcbxDown.Size = new System.Drawing.Size(40, 44);
            this.pcbxDown.TabIndex = 32;
            this.pcbxDown.TabStop = false;
            this.pcbxDown.Visible = false;
            this.pcbxDown.Click += new System.EventHandler(this.pcbxDown_Click);
            this.pcbxDown.MouseLeave += new System.EventHandler(this.pcbxDown_MouseLeave);
            this.pcbxDown.MouseHover += new System.EventHandler(this.pcbxDown_MouseHover);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(175, 183);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 23);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add to Favorites";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pcbxDelete1
            // 
            this.pcbxDelete1.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDelete1.Image = global::Miro_TV_Manager.Properties.Resources.Delete;
            this.pcbxDelete1.Location = new System.Drawing.Point(841, 69);
            this.pcbxDelete1.Name = "pcbxDelete1";
            this.pcbxDelete1.Size = new System.Drawing.Size(40, 40);
            this.pcbxDelete1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxDelete1.TabIndex = 34;
            this.pcbxDelete1.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxDelete1, "Remove ... from Favorites");
            this.pcbxDelete1.Visible = false;
            this.pcbxDelete1.Click += new System.EventHandler(this.pcbxDelete1_Click);
            // 
            // pcbxDelete2
            // 
            this.pcbxDelete2.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDelete2.Image = global::Miro_TV_Manager.Properties.Resources.Delete;
            this.pcbxDelete2.Location = new System.Drawing.Point(841, 142);
            this.pcbxDelete2.Name = "pcbxDelete2";
            this.pcbxDelete2.Size = new System.Drawing.Size(40, 40);
            this.pcbxDelete2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxDelete2.TabIndex = 35;
            this.pcbxDelete2.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxDelete2, "Remove ... from Favorites");
            this.pcbxDelete2.Visible = false;
            this.pcbxDelete2.Click += new System.EventHandler(this.pcbxDelete2_Click);
            // 
            // pcbxDelete3
            // 
            this.pcbxDelete3.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDelete3.Image = global::Miro_TV_Manager.Properties.Resources.Delete;
            this.pcbxDelete3.Location = new System.Drawing.Point(841, 218);
            this.pcbxDelete3.Name = "pcbxDelete3";
            this.pcbxDelete3.Size = new System.Drawing.Size(40, 40);
            this.pcbxDelete3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxDelete3.TabIndex = 36;
            this.pcbxDelete3.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxDelete3, "Remove ... from Favorites");
            this.pcbxDelete3.Visible = false;
            this.pcbxDelete3.Click += new System.EventHandler(this.pcbxDelete3_Click);
            // 
            // pcbxDelete4
            // 
            this.pcbxDelete4.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDelete4.Image = global::Miro_TV_Manager.Properties.Resources.Delete;
            this.pcbxDelete4.Location = new System.Drawing.Point(841, 294);
            this.pcbxDelete4.Name = "pcbxDelete4";
            this.pcbxDelete4.Size = new System.Drawing.Size(40, 40);
            this.pcbxDelete4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxDelete4.TabIndex = 37;
            this.pcbxDelete4.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxDelete4, "Remove ... from Favorites");
            this.pcbxDelete4.Visible = false;
            this.pcbxDelete4.Click += new System.EventHandler(this.pcbxDelete4_Click);
            // 
            // pcbxDelete5
            // 
            this.pcbxDelete5.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDelete5.Image = global::Miro_TV_Manager.Properties.Resources.Delete;
            this.pcbxDelete5.Location = new System.Drawing.Point(841, 370);
            this.pcbxDelete5.Name = "pcbxDelete5";
            this.pcbxDelete5.Size = new System.Drawing.Size(40, 40);
            this.pcbxDelete5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxDelete5.TabIndex = 38;
            this.pcbxDelete5.TabStop = false;
            this.toolTip1.SetToolTip(this.pcbxDelete5, "Remove ... from Favorites");
            this.pcbxDelete5.Visible = false;
            this.pcbxDelete5.Click += new System.EventHandler(this.pcbxDelete5_Click);
            // 
            // ntfy
            // 
            this.ntfy.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfy.Icon")));
            this.ntfy.Visible = true;
            // 
            // rchEpisodeDescription
            // 
            this.rchEpisodeDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEpisodeDescription.BackColor = System.Drawing.Color.White;
            this.rchEpisodeDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchEpisodeDescription.Location = new System.Drawing.Point(458, 432);
            this.rchEpisodeDescription.Name = "rchEpisodeDescription";
            this.rchEpisodeDescription.ReadOnly = true;
            this.rchEpisodeDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rchEpisodeDescription.Size = new System.Drawing.Size(377, 109);
            this.rchEpisodeDescription.TabIndex = 40;
            this.rchEpisodeDescription.Text = "";
            this.rchEpisodeDescription.Visible = false;
            // 
            // timerNotify
            // 
            this.timerNotify.Interval = 60000;
            this.timerNotify.Tick += new System.EventHandler(this.timerNotify_Tick);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdated.Location = new System.Drawing.Point(515, 13);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(82, 15);
            this.lblLastUpdated.TabIndex = 41;
            this.lblLastUpdated.Text = "Last Updated: ";
            // 
            // lblNextShow
            // 
            this.lblNextShow.BackColor = System.Drawing.Color.Transparent;
            this.lblNextShow.Location = new System.Drawing.Point(455, 35);
            this.lblNextShow.Name = "lblNextShow";
            this.lblNextShow.Size = new System.Drawing.Size(380, 15);
            this.lblNextShow.TabIndex = 42;
            this.lblNextShow.Text = "Next Show: ";
            this.lblNextShow.Click += new System.EventHandler(this.lblNextShow_Click);
            // 
            // timerNextShow
            // 
            this.timerNextShow.Enabled = true;
            this.timerNextShow.Interval = 60000;
            this.timerNextShow.Tick += new System.EventHandler(this.timerNextShow_Tick);
            // 
            // lblEnded
            // 
            this.lblEnded.BackColor = System.Drawing.Color.Transparent;
            this.lblEnded.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnded.Location = new System.Drawing.Point(168, 208);
            this.lblEnded.Name = "lblEnded";
            this.lblEnded.Size = new System.Drawing.Size(123, 15);
            this.lblEnded.TabIndex = 43;
            this.lblEnded.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerVersionCheck
            // 
            this.timerVersionCheck.Enabled = true;
            this.timerVersionCheck.Interval = 86400000;
            this.timerVersionCheck.Tick += new System.EventHandler(this.timerVersionCheck_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Miro_TV_Manager.Properties.Resources._114851;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(893, 553);
            this.Controls.Add(this.lblEnded);
            this.Controls.Add(this.pcbxSearchDelete);
            this.Controls.Add(this.lblNextShow);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.rchEpisodeDescription);
            this.Controls.Add(this.pcbxDelete5);
            this.Controls.Add(this.pcbxDelete4);
            this.Controls.Add(this.pcbxDelete3);
            this.Controls.Add(this.pcbxDelete2);
            this.Controls.Add(this.pcbxDelete1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pcbxDown);
            this.Controls.Add(this.pcbxTop5);
            this.Controls.Add(this.pcbxTop4);
            this.Controls.Add(this.pcbxTop3);
            this.Controls.Add(this.pcbxTop2);
            this.Controls.Add(this.pcbxUp);
            this.Controls.Add(this.pcbxTop1);
            this.Controls.Add(this.progressSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtSeriesDescription);
            this.Controls.Add(this.lstOverview);
            this.Controls.Add(this.txtAirsAt);
            this.Controls.Add(this.txtAirsOn);
            this.Controls.Add(this.txtEpisodes);
            this.Controls.Add(this.txtSeasons);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtActors);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAirsAt);
            this.Controls.Add(this.lblAirsOn);
            this.Controls.Add(this.lblEpisodes);
            this.Controls.Add(this.lblSeasons);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pcbxCurrentSeries);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miro TV Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxCurrentSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSearchDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxTop5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDelete5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox pcbxCurrentSeries;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.Label lblEpisodes;
        private System.Windows.Forms.Label lblAirsOn;
        private System.Windows.Forms.Label lblAirsAt;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtActors;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtEpisodes;
        private System.Windows.Forms.TextBox txtSeasons;
        private System.Windows.Forms.TextBox txtAirsAt;
        private System.Windows.Forms.TextBox txtAirsOn;
        private System.Windows.Forms.ListView lstOverview;
        private System.Windows.Forms.TextBox txtSeriesDescription;
        private System.Windows.Forms.ColumnHeader Ep;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Rating;
        private System.Windows.Forms.ColumnHeader FirstAired;
        private System.Windows.Forms.ColumnHeader Aired;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pcbxSearchDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ProgressBar progressSearch;
        private System.Windows.Forms.PictureBox pcbxTop1;
        private System.Windows.Forms.PictureBox pcbxUp;
        private System.Windows.Forms.PictureBox pcbxTop2;
        private System.Windows.Forms.PictureBox pcbxTop3;
        private System.Windows.Forms.PictureBox pcbxTop4;
        private System.Windows.Forms.PictureBox pcbxTop5;
        private System.Windows.Forms.PictureBox pcbxDown;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pcbxDelete1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pcbxDelete2;
        private System.Windows.Forms.PictureBox pcbxDelete3;
        private System.Windows.Forms.PictureBox pcbxDelete4;
        private System.Windows.Forms.PictureBox pcbxDelete5;
        private System.Windows.Forms.ToolStripMenuItem exiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon ntfy;
        private System.Windows.Forms.RichTextBox rchEpisodeDescription;
        private System.Windows.Forms.Timer timerNotify;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label lblNextShow;
        private System.Windows.Forms.Timer timerNextShow;
        private System.Windows.Forms.Label lblEnded;
        private System.Windows.Forms.Timer timerVersionCheck;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
    }
}

