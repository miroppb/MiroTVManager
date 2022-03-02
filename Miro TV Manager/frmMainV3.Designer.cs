using System;

namespace Miro_TV_Manager
{
    partial class frmMainV3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainV3));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceFullUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCurrentSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadCurrentSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatShowEndedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcbxSearch = new System.Windows.Forms.PictureBox();
            this.lblEnded = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSeriesDescription = new System.Windows.Forms.TextBox();
            this.lstOverview = new System.Windows.Forms.ListView();
            this.Watched = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstAired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Aired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAirsAt = new System.Windows.Forms.TextBox();
            this.txtAirsOn = new System.Windows.Forms.TextBox();
            this.txtEpisodes = new System.Windows.Forms.TextBox();
            this.txtSeasons = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtActors = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAirsAt = new System.Windows.Forms.Label();
            this.lblAirsOn = new System.Windows.Forms.Label();
            this.lblEpisodes = new System.Windows.Forms.Label();
            this.lblSeasons = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pcbxSeries1 = new System.Windows.Forms.PictureBox();
            this.pcbxSeries2 = new System.Windows.Forms.PictureBox();
            this.pcbxSeries3 = new System.Windows.Forms.PictureBox();
            this.pcbxSeries4 = new System.Windows.Forms.PictureBox();
            this.pcbxSeries5 = new System.Windows.Forms.PictureBox();
            this.lblLoaded = new System.Windows.Forms.Label();
            this.progressStart = new System.Windows.Forms.ProgressBar();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblNextEpisode = new System.Windows.Forms.Label();
            this.pcbxDown = new System.Windows.Forms.PictureBox();
            this.pcbxUp = new System.Windows.Forms.PictureBox();
            this.timerNextShow = new System.Windows.Forms.Timer(this.components);
            this.pbSearch = new System.Windows.Forms.ProgressBar();
            this.rchEpisodeDescription = new System.Windows.Forms.RichTextBox();
            this.timerNotify = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMorning = new System.Windows.Forms.Timer(this.components);
            this.pcbxDel3 = new System.Windows.Forms.PictureBox();
            this.pcbxDel4 = new System.Windows.Forms.PictureBox();
            this.pcbxDel1 = new System.Windows.Forms.PictureBox();
            this.pcbxDel2 = new System.Windows.Forms.PictureBox();
            this.pcbxDel5 = new System.Windows.Forms.PictureBox();
            this.btnSeenAll = new System.Windows.Forms.Button();
            this.timerPlex = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxUp)).BeginInit();
            this.cmsNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(135, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.backupDatabaseToolStripMenuItem,
            this.showMeToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.editToolStripMenuItem.Text = "Tools";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceFullUpdateToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem1,
            this.updateCurrentSeriesToolStripMenuItem,
            this.reloadCurrentSeriesToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.updateToolStripMenuItem.Text = "Update...";
            // 
            // forceFullUpdateToolStripMenuItem
            // 
            this.forceFullUpdateToolStripMenuItem.Name = "forceFullUpdateToolStripMenuItem";
            this.forceFullUpdateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.forceFullUpdateToolStripMenuItem.Text = "Force Full Update";
            this.forceFullUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem1
            // 
            this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            this.checkForUpdatesToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.checkForUpdatesToolStripMenuItem1.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem1_Click);
            // 
            // updateCurrentSeriesToolStripMenuItem
            // 
            this.updateCurrentSeriesToolStripMenuItem.Name = "updateCurrentSeriesToolStripMenuItem";
            this.updateCurrentSeriesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.updateCurrentSeriesToolStripMenuItem.Text = "Update Current Series";
            this.updateCurrentSeriesToolStripMenuItem.Click += new System.EventHandler(this.UpdateCurrentSeriesToolStripMenuItem_Click);
            // 
            // reloadCurrentSeriesToolStripMenuItem
            // 
            this.reloadCurrentSeriesToolStripMenuItem.Name = "reloadCurrentSeriesToolStripMenuItem";
            this.reloadCurrentSeriesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reloadCurrentSeriesToolStripMenuItem.Text = "Reload Current Series";
            this.reloadCurrentSeriesToolStripMenuItem.Click += new System.EventHandler(this.ReloadCurrentSeriesToolStripMenuItem_Click);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.backupDatabaseToolStripMenuItem.Text = "Import/Export";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.importToolStripMenuItem.Text = "Import Database";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exportToolStripMenuItem.Text = "Export Database";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // showMeToolStripMenuItem
            // 
            this.showMeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatShowEndedToolStripMenuItem});
            this.showMeToolStripMenuItem.Name = "showMeToolStripMenuItem";
            this.showMeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.showMeToolStripMenuItem.Text = "Show me...";
            // 
            // whatShowEndedToolStripMenuItem
            // 
            this.whatShowEndedToolStripMenuItem.Name = "whatShowEndedToolStripMenuItem";
            this.whatShowEndedToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.whatShowEndedToolStripMenuItem.Text = "What show ended";
            this.whatShowEndedToolStripMenuItem.Click += new System.EventHandler(this.WhatShowEndedToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // pcbxSearch
            // 
            this.pcbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSearch.Image = global::Miro_TV_Manager.Properties.Resources.tvdb_logo;
            this.pcbxSearch.Location = new System.Drawing.Point(12, 55);
            this.pcbxSearch.Name = "pcbxSearch";
            this.pcbxSearch.Size = new System.Drawing.Size(458, 84);
            this.pcbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSearch.TabIndex = 3;
            this.pcbxSearch.TabStop = false;
            // 
            // lblEnded
            // 
            this.lblEnded.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEnded.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnded.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEnded.Location = new System.Drawing.Point(177, 244);
            this.lblEnded.Name = "lblEnded";
            this.lblEnded.Size = new System.Drawing.Size(134, 15);
            this.lblEnded.TabIndex = 64;
            this.lblEnded.Text = "This series has ended :(";
            this.lblEnded.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEnded.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(193, 216);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 23);
            this.btnAdd.TabIndex = 63;
            this.btnAdd.Text = "Add to Favorites";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSeriesDescription
            // 
            this.txtSeriesDescription.BackColor = System.Drawing.Color.White;
            this.txtSeriesDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesDescription.Location = new System.Drawing.Point(12, 281);
            this.txtSeriesDescription.Multiline = true;
            this.txtSeriesDescription.Name = "txtSeriesDescription";
            this.txtSeriesDescription.ReadOnly = true;
            this.txtSeriesDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSeriesDescription.Size = new System.Drawing.Size(458, 109);
            this.txtSeriesDescription.TabIndex = 59;
            // 
            // lstOverview
            // 
            this.lstOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstOverview.CheckBoxes = true;
            this.lstOverview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Watched,
            this.Ep,
            this.Title,
            this.Rating,
            this.FirstAired,
            this.Aired});
            this.lstOverview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOverview.FullRowSelect = true;
            this.lstOverview.HideSelection = false;
            this.lstOverview.Location = new System.Drawing.Point(12, 396);
            this.lstOverview.MinimumSize = new System.Drawing.Size(458, 273);
            this.lstOverview.MultiSelect = false;
            this.lstOverview.Name = "lstOverview";
            this.lstOverview.Size = new System.Drawing.Size(458, 273);
            this.lstOverview.TabIndex = 61;
            this.lstOverview.UseCompatibleStateImageBehavior = false;
            this.lstOverview.View = System.Windows.Forms.View.Details;
            this.lstOverview.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstOverview_ItemChecked);
            this.lstOverview.SelectedIndexChanged += new System.EventHandler(this.lstOverview_SelectedIndexChanged);
            // 
            // Watched
            // 
            this.Watched.DisplayIndex = 5;
            this.Watched.Text = "👀";
            this.Watched.Width = 29;
            // 
            // Ep
            // 
            this.Ep.DisplayIndex = 0;
            this.Ep.Text = "Ep";
            this.Ep.Width = 34;
            // 
            // Title
            // 
            this.Title.DisplayIndex = 1;
            this.Title.Text = "Title";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Title.Width = 180;
            // 
            // Rating
            // 
            this.Rating.DisplayIndex = 2;
            this.Rating.Text = "Rating";
            this.Rating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Rating.Width = 90;
            // 
            // FirstAired
            // 
            this.FirstAired.DisplayIndex = 3;
            this.FirstAired.Text = "First Aired";
            this.FirstAired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstAired.Width = 72;
            // 
            // Aired
            // 
            this.Aired.DisplayIndex = 4;
            this.Aired.Text = "📺";
            this.Aired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Aired.Width = 45;
            // 
            // txtAirsAt
            // 
            this.txtAirsAt.BackColor = System.Drawing.Color.White;
            this.txtAirsAt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAirsAt.Location = new System.Drawing.Point(351, 256);
            this.txtAirsAt.Name = "txtAirsAt";
            this.txtAirsAt.ReadOnly = true;
            this.txtAirsAt.Size = new System.Drawing.Size(119, 23);
            this.txtAirsAt.TabIndex = 57;
            // 
            // txtAirsOn
            // 
            this.txtAirsOn.BackColor = System.Drawing.Color.White;
            this.txtAirsOn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAirsOn.Location = new System.Drawing.Point(351, 220);
            this.txtAirsOn.Name = "txtAirsOn";
            this.txtAirsOn.ReadOnly = true;
            this.txtAirsOn.Size = new System.Drawing.Size(119, 23);
            this.txtAirsOn.TabIndex = 55;
            // 
            // txtEpisodes
            // 
            this.txtEpisodes.BackColor = System.Drawing.Color.White;
            this.txtEpisodes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpisodes.Location = new System.Drawing.Point(351, 184);
            this.txtEpisodes.Name = "txtEpisodes";
            this.txtEpisodes.ReadOnly = true;
            this.txtEpisodes.Size = new System.Drawing.Size(119, 23);
            this.txtEpisodes.TabIndex = 53;
            // 
            // txtSeasons
            // 
            this.txtSeasons.BackColor = System.Drawing.Color.White;
            this.txtSeasons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeasons.Location = new System.Drawing.Point(351, 148);
            this.txtSeasons.Name = "txtSeasons";
            this.txtSeasons.ReadOnly = true;
            this.txtSeasons.Size = new System.Drawing.Size(119, 23);
            this.txtSeasons.TabIndex = 51;
            // 
            // txtGenre
            // 
            this.txtGenre.BackColor = System.Drawing.Color.White;
            this.txtGenre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenre.Location = new System.Drawing.Point(60, 256);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.ReadOnly = true;
            this.txtGenre.Size = new System.Drawing.Size(109, 23);
            this.txtGenre.TabIndex = 49;
            // 
            // txtRating
            // 
            this.txtRating.BackColor = System.Drawing.Color.White;
            this.txtRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRating.Location = new System.Drawing.Point(60, 220);
            this.txtRating.Name = "txtRating";
            this.txtRating.ReadOnly = true;
            this.txtRating.Size = new System.Drawing.Size(109, 23);
            this.txtRating.TabIndex = 47;
            // 
            // txtActors
            // 
            this.txtActors.BackColor = System.Drawing.Color.White;
            this.txtActors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActors.Location = new System.Drawing.Point(60, 184);
            this.txtActors.Name = "txtActors";
            this.txtActors.ReadOnly = true;
            this.txtActors.Size = new System.Drawing.Size(188, 23);
            this.txtActors.TabIndex = 45;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(60, 148);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(188, 23);
            this.txtTitle.TabIndex = 44;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(211, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 15);
            this.lblDescription.TabIndex = 62;
            this.lblDescription.Text = "Description";
            // 
            // lblAirsAt
            // 
            this.lblAirsAt.AutoSize = true;
            this.lblAirsAt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAirsAt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirsAt.ForeColor = System.Drawing.Color.Black;
            this.lblAirsAt.Location = new System.Drawing.Point(308, 259);
            this.lblAirsAt.Name = "lblAirsAt";
            this.lblAirsAt.Size = new System.Drawing.Size(43, 15);
            this.lblAirsAt.TabIndex = 60;
            this.lblAirsAt.Text = "Airs at:";
            // 
            // lblAirsOn
            // 
            this.lblAirsOn.AutoSize = true;
            this.lblAirsOn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAirsOn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirsOn.ForeColor = System.Drawing.Color.Black;
            this.lblAirsOn.Location = new System.Drawing.Point(304, 223);
            this.lblAirsOn.Name = "lblAirsOn";
            this.lblAirsOn.Size = new System.Drawing.Size(47, 15);
            this.lblAirsOn.TabIndex = 58;
            this.lblAirsOn.Text = "Airs on:";
            // 
            // lblEpisodes
            // 
            this.lblEpisodes.AutoSize = true;
            this.lblEpisodes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEpisodes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodes.ForeColor = System.Drawing.Color.Black;
            this.lblEpisodes.Location = new System.Drawing.Point(295, 187);
            this.lblEpisodes.Name = "lblEpisodes";
            this.lblEpisodes.Size = new System.Drawing.Size(56, 15);
            this.lblEpisodes.TabIndex = 56;
            this.lblEpisodes.Text = "Episodes:";
            // 
            // lblSeasons
            // 
            this.lblSeasons.AutoSize = true;
            this.lblSeasons.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSeasons.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeasons.ForeColor = System.Drawing.Color.Black;
            this.lblSeasons.Location = new System.Drawing.Point(298, 151);
            this.lblSeasons.Name = "lblSeasons";
            this.lblSeasons.Size = new System.Drawing.Size(53, 15);
            this.lblSeasons.TabIndex = 54;
            this.lblSeasons.Text = "Seasons:";
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenre.AutoSize = true;
            this.lblGenre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.Location = new System.Drawing.Point(19, 259);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(41, 15);
            this.lblGenre.TabIndex = 52;
            this.lblGenre.Text = "Genre:";
            // 
            // lblRating
            // 
            this.lblRating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRating.AutoSize = true;
            this.lblRating.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(16, 223);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(44, 15);
            this.lblRating.TabIndex = 50;
            this.lblRating.Text = "Rating:";
            // 
            // lblActors
            // 
            this.lblActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActors.AutoSize = true;
            this.lblActors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblActors.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActors.Location = new System.Drawing.Point(16, 187);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(44, 15);
            this.lblActors.TabIndex = 48;
            this.lblActors.Text = "Actors:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(27, 151);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 15);
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "Title:";
            // 
            // pcbxSeries1
            // 
            this.pcbxSeries1.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pcbxSeries1.Location = new System.Drawing.Point(655, 55);
            this.pcbxSeries1.Name = "pcbxSeries1";
            this.pcbxSeries1.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries1.TabIndex = 65;
            this.pcbxSeries1.TabStop = false;
            this.pcbxSeries1.Click += new System.EventHandler(this.pcbxSeries1_Click);
            // 
            // pcbxSeries2
            // 
            this.pcbxSeries2.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pcbxSeries2.Location = new System.Drawing.Point(655, 145);
            this.pcbxSeries2.Name = "pcbxSeries2";
            this.pcbxSeries2.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries2.TabIndex = 66;
            this.pcbxSeries2.TabStop = false;
            this.pcbxSeries2.Click += new System.EventHandler(this.pcbxSeries2_Click);
            // 
            // pcbxSeries3
            // 
            this.pcbxSeries3.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pcbxSeries3.Location = new System.Drawing.Point(655, 235);
            this.pcbxSeries3.Name = "pcbxSeries3";
            this.pcbxSeries3.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries3.TabIndex = 67;
            this.pcbxSeries3.TabStop = false;
            this.pcbxSeries3.Click += new System.EventHandler(this.pcbxSeries3_Click);
            // 
            // pcbxSeries4
            // 
            this.pcbxSeries4.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pcbxSeries4.Location = new System.Drawing.Point(655, 325);
            this.pcbxSeries4.Name = "pcbxSeries4";
            this.pcbxSeries4.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries4.TabIndex = 68;
            this.pcbxSeries4.TabStop = false;
            this.pcbxSeries4.Click += new System.EventHandler(this.pcbxSeries4_Click);
            // 
            // pcbxSeries5
            // 
            this.pcbxSeries5.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries5.Cursor = System.Windows.Forms.Cursors.Default;
            this.pcbxSeries5.Location = new System.Drawing.Point(655, 415);
            this.pcbxSeries5.Name = "pcbxSeries5";
            this.pcbxSeries5.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries5.TabIndex = 69;
            this.pcbxSeries5.TabStop = false;
            this.pcbxSeries5.Click += new System.EventHandler(this.pcbxSeries5_Click);
            // 
            // lblLoaded
            // 
            this.lblLoaded.BackColor = System.Drawing.Color.Transparent;
            this.lblLoaded.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaded.Location = new System.Drawing.Point(739, 612);
            this.lblLoaded.Name = "lblLoaded";
            this.lblLoaded.Size = new System.Drawing.Size(513, 18);
            this.lblLoaded.TabIndex = 71;
            this.lblLoaded.Text = "Downloaded/Processed: ";
            this.lblLoaded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressStart
            // 
            this.progressStart.Location = new System.Drawing.Point(996, 633);
            this.progressStart.Name = "progressStart";
            this.progressStart.Size = new System.Drawing.Size(256, 36);
            this.progressStart.TabIndex = 70;
            // 
            // lblUpdated
            // 
            this.lblUpdated.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdated.Location = new System.Drawing.Point(944, 656);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(308, 13);
            this.lblUpdated.TabIndex = 72;
            this.lblUpdated.Text = "Last Updated:";
            this.lblUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNextEpisode
            // 
            this.lblNextEpisode.AutoSize = true;
            this.lblNextEpisode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNextEpisode.Location = new System.Drawing.Point(652, 36);
            this.lblNextEpisode.MaximumSize = new System.Drawing.Size(460, 13);
            this.lblNextEpisode.Name = "lblNextEpisode";
            this.lblNextEpisode.Size = new System.Drawing.Size(77, 13);
            this.lblNextEpisode.TabIndex = 73;
            this.lblNextEpisode.Text = "Next Episode:";
            this.lblNextEpisode.Click += new System.EventHandler(this.lblNextEpisode_Click);
            // 
            // pcbxDown
            // 
            this.pcbxDown.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDown.BackgroundImage = global::Miro_TV_Manager.Properties.Resources.arrow_down;
            this.pcbxDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxDown.Location = new System.Drawing.Point(1202, 505);
            this.pcbxDown.Name = "pcbxDown";
            this.pcbxDown.Size = new System.Drawing.Size(50, 55);
            this.pcbxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxDown.TabIndex = 74;
            this.pcbxDown.TabStop = false;
            this.pcbxDown.Click += new System.EventHandler(this.pcbxDown_Click);
            this.pcbxDown.MouseEnter += new System.EventHandler(this.pcbxDown_MouseEnter);
            this.pcbxDown.MouseLeave += new System.EventHandler(this.pcbxDown_MouseLeave);
            // 
            // pcbxUp
            // 
            this.pcbxUp.BackColor = System.Drawing.Color.Transparent;
            this.pcbxUp.BackgroundImage = global::Miro_TV_Manager.Properties.Resources.arrow_up;
            this.pcbxUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxUp.ErrorImage = null;
            this.pcbxUp.Location = new System.Drawing.Point(1202, 0);
            this.pcbxUp.Name = "pcbxUp";
            this.pcbxUp.Size = new System.Drawing.Size(50, 55);
            this.pcbxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxUp.TabIndex = 75;
            this.pcbxUp.TabStop = false;
            this.pcbxUp.Click += new System.EventHandler(this.pcbxUp_Click);
            this.pcbxUp.MouseEnter += new System.EventHandler(this.pcbxUp_MouseEnter);
            this.pcbxUp.MouseLeave += new System.EventHandler(this.pcbxUp_MouseLeave);
            // 
            // timerNextShow
            // 
            this.timerNextShow.Enabled = true;
            this.timerNextShow.Interval = 5000;
            this.timerNextShow.Tick += new System.EventHandler(this.timerNextShow_Tick);
            // 
            // pbSearch
            // 
            this.pbSearch.Location = new System.Drawing.Point(153, 26);
            this.pbSearch.MarqueeAnimationSpeed = 5;
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(317, 23);
            this.pbSearch.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbSearch.TabIndex = 76;
            this.pbSearch.Visible = false;
            // 
            // rchEpisodeDescription
            // 
            this.rchEpisodeDescription.Location = new System.Drawing.Point(476, 505);
            this.rchEpisodeDescription.Name = "rchEpisodeDescription";
            this.rchEpisodeDescription.Size = new System.Drawing.Size(462, 164);
            this.rchEpisodeDescription.TabIndex = 77;
            this.rchEpisodeDescription.Text = "";
            this.rchEpisodeDescription.Visible = false;
            // 
            // timerNotify
            // 
            this.timerNotify.Enabled = true;
            this.timerNotify.Interval = 60000;
            this.timerNotify.Tick += new System.EventHandler(this.timerNotify_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Miro TV Manager";
            this.notifyIcon1.Visible = true;
            // 
            // cmsNotify
            // 
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.cmsNotify.Name = "cmsNotify";
            this.cmsNotify.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // timerMorning
            // 
            this.timerMorning.Enabled = true;
            this.timerMorning.Interval = 60000;
            this.timerMorning.Tick += new System.EventHandler(this.timerMorning_Tick);
            // 
            // pcbxDel3
            // 
            this.pcbxDel3.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDel3.Image = ((System.Drawing.Image)(resources.GetObject("pcbxDel3.Image")));
            this.pcbxDel3.Location = new System.Drawing.Point(1113, 235);
            this.pcbxDel3.Name = "pcbxDel3";
            this.pcbxDel3.Size = new System.Drawing.Size(84, 84);
            this.pcbxDel3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxDel3.TabIndex = 79;
            this.pcbxDel3.TabStop = false;
            this.pcbxDel3.Visible = false;
            this.pcbxDel3.Click += new System.EventHandler(this.pcbxDel3_Click);
            // 
            // pcbxDel4
            // 
            this.pcbxDel4.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDel4.Image = ((System.Drawing.Image)(resources.GetObject("pcbxDel4.Image")));
            this.pcbxDel4.Location = new System.Drawing.Point(1113, 325);
            this.pcbxDel4.Name = "pcbxDel4";
            this.pcbxDel4.Size = new System.Drawing.Size(84, 84);
            this.pcbxDel4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxDel4.TabIndex = 80;
            this.pcbxDel4.TabStop = false;
            this.pcbxDel4.Visible = false;
            this.pcbxDel4.Click += new System.EventHandler(this.pcbxDel4_Click);
            // 
            // pcbxDel1
            // 
            this.pcbxDel1.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbxDel1.Image = ((System.Drawing.Image)(resources.GetObject("pcbxDel1.Image")));
            this.pcbxDel1.Location = new System.Drawing.Point(1113, 55);
            this.pcbxDel1.Name = "pcbxDel1";
            this.pcbxDel1.Size = new System.Drawing.Size(84, 84);
            this.pcbxDel1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxDel1.TabIndex = 81;
            this.pcbxDel1.TabStop = false;
            this.pcbxDel1.Visible = false;
            this.pcbxDel1.Click += new System.EventHandler(this.pcbxDel1_Click);
            // 
            // pcbxDel2
            // 
            this.pcbxDel2.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDel2.Image = ((System.Drawing.Image)(resources.GetObject("pcbxDel2.Image")));
            this.pcbxDel2.Location = new System.Drawing.Point(1113, 145);
            this.pcbxDel2.Name = "pcbxDel2";
            this.pcbxDel2.Size = new System.Drawing.Size(84, 84);
            this.pcbxDel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxDel2.TabIndex = 82;
            this.pcbxDel2.TabStop = false;
            this.pcbxDel2.Visible = false;
            this.pcbxDel2.Click += new System.EventHandler(this.pcbxDel2_Click);
            // 
            // pcbxDel5
            // 
            this.pcbxDel5.BackColor = System.Drawing.Color.Transparent;
            this.pcbxDel5.Image = ((System.Drawing.Image)(resources.GetObject("pcbxDel5.Image")));
            this.pcbxDel5.Location = new System.Drawing.Point(1113, 415);
            this.pcbxDel5.Name = "pcbxDel5";
            this.pcbxDel5.Size = new System.Drawing.Size(84, 84);
            this.pcbxDel5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxDel5.TabIndex = 83;
            this.pcbxDel5.TabStop = false;
            this.pcbxDel5.Visible = false;
            this.pcbxDel5.Click += new System.EventHandler(this.pcbxDel5_Click);
            // 
            // btnSeenAll
            // 
            this.btnSeenAll.Location = new System.Drawing.Point(476, 399);
            this.btnSeenAll.Name = "btnSeenAll";
            this.btnSeenAll.Size = new System.Drawing.Size(75, 23);
            this.btnSeenAll.TabIndex = 84;
            this.btnSeenAll.Text = "<- Seen all";
            this.btnSeenAll.UseVisualStyleBackColor = true;
            this.btnSeenAll.Visible = false;
            this.btnSeenAll.Click += new System.EventHandler(this.btnSeenAll_Click);
            // 
            // timerPlex
            // 
            this.timerPlex.Enabled = true;
            this.timerPlex.Interval = 3600000;
            this.timerPlex.Tick += new System.EventHandler(this.TimerPlex_Tick);
            // 
            // frmMainV3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Miro_TV_Manager.Properties.Resources._4673;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnSeenAll);
            this.Controls.Add(this.pcbxDel5);
            this.Controls.Add(this.pcbxDel4);
            this.Controls.Add(this.pcbxDel3);
            this.Controls.Add(this.rchEpisodeDescription);
            this.Controls.Add(this.pbSearch);
            this.Controls.Add(this.pcbxUp);
            this.Controls.Add(this.pcbxDown);
            this.Controls.Add(this.progressStart);
            this.Controls.Add(this.lblNextEpisode);
            this.Controls.Add(this.lblLoaded);
            this.Controls.Add(this.pcbxSeries5);
            this.Controls.Add(this.pcbxSeries4);
            this.Controls.Add(this.pcbxSeries3);
            this.Controls.Add(this.pcbxSeries2);
            this.Controls.Add(this.pcbxSeries1);
            this.Controls.Add(this.lblEnded);
            this.Controls.Add(this.btnAdd);
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
            this.Controls.Add(this.pcbxSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pcbxDel1);
            this.Controls.Add(this.pcbxDel2);
            this.Controls.Add(this.lblUpdated);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMainV3";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miro TV Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainV3_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxUp)).EndInit();
            this.cmsNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDel5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pcbxSearch;
        private System.Windows.Forms.Label lblEnded;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSeriesDescription;
        private System.Windows.Forms.ListView lstOverview;
        private System.Windows.Forms.ColumnHeader Ep;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Rating;
        private System.Windows.Forms.ColumnHeader FirstAired;
        private System.Windows.Forms.ColumnHeader Aired;
        private System.Windows.Forms.TextBox txtAirsAt;
        private System.Windows.Forms.TextBox txtAirsOn;
        private System.Windows.Forms.TextBox txtEpisodes;
        private System.Windows.Forms.TextBox txtSeasons;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtActors;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAirsAt;
        private System.Windows.Forms.Label lblAirsOn;
        private System.Windows.Forms.Label lblEpisodes;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader Watched;
        private System.Windows.Forms.PictureBox pcbxSeries1;
        private System.Windows.Forms.PictureBox pcbxSeries2;
        private System.Windows.Forms.PictureBox pcbxSeries3;
        private System.Windows.Forms.PictureBox pcbxSeries4;
        private System.Windows.Forms.PictureBox pcbxSeries5;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        public System.Windows.Forms.Label lblLoaded;
        public System.Windows.Forms.ProgressBar progressStart;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label lblNextEpisode;
        private System.Windows.Forms.PictureBox pcbxDown;
        private System.Windows.Forms.PictureBox pcbxUp;
        private System.Windows.Forms.Timer timerNextShow;
        private System.Windows.Forms.ProgressBar pbSearch;
        private System.Windows.Forms.RichTextBox rchEpisodeDescription;
        private System.Windows.Forms.Timer timerNotify;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Timer timerMorning;
        private System.Windows.Forms.PictureBox pcbxDel3;
        private System.Windows.Forms.PictureBox pcbxDel4;
        private System.Windows.Forms.PictureBox pcbxDel1;
        private System.Windows.Forms.PictureBox pcbxDel2;
        private System.Windows.Forms.PictureBox pcbxDel5;
        private System.Windows.Forms.Button btnSeenAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceFullUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateCurrentSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatShowEndedToolStripMenuItem;
        private System.Windows.Forms.Timer timerPlex;
        private System.Windows.Forms.ToolStripMenuItem reloadCurrentSeriesToolStripMenuItem;
    }
}