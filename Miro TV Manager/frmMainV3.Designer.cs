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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Season1", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainV3));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pcbxSeries6 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries6)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(135, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
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
            this.pcbxSearch.BackgroundImage = global::Miro_TV_Manager.Properties.Resources.tvdb_logo_2x;
            this.pcbxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSearch.Location = new System.Drawing.Point(12, 55);
            this.pcbxSearch.Name = "pcbxSearch";
            this.pcbxSearch.Size = new System.Drawing.Size(458, 84);
            this.pcbxSearch.TabIndex = 3;
            this.pcbxSearch.TabStop = false;
            // 
            // lblEnded
            // 
            this.lblEnded.BackColor = System.Drawing.Color.Transparent;
            this.lblEnded.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnded.Location = new System.Drawing.Point(177, 244);
            this.lblEnded.Name = "lblEnded";
            this.lblEnded.Size = new System.Drawing.Size(123, 15);
            this.lblEnded.TabIndex = 64;
            this.lblEnded.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            listViewGroup1.Header = "Season1";
            listViewGroup1.Name = "Season 1";
            this.lstOverview.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lstOverview.Location = new System.Drawing.Point(12, 396);
            this.lstOverview.MinimumSize = new System.Drawing.Size(458, 273);
            this.lstOverview.MultiSelect = false;
            this.lstOverview.Name = "lstOverview";
            this.lstOverview.Size = new System.Drawing.Size(458, 273);
            this.lstOverview.TabIndex = 61;
            this.lstOverview.UseCompatibleStateImageBehavior = false;
            this.lstOverview.View = System.Windows.Forms.View.Details;
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
            this.Aired.Text = "Aired?";
            this.Aired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Aired.Width = 48;
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
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
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
            this.lblAirsAt.BackColor = System.Drawing.Color.Transparent;
            this.lblAirsAt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirsAt.ForeColor = System.Drawing.Color.Black;
            this.lblAirsAt.Location = new System.Drawing.Point(306, 259);
            this.lblAirsAt.Name = "lblAirsAt";
            this.lblAirsAt.Size = new System.Drawing.Size(43, 15);
            this.lblAirsAt.TabIndex = 60;
            this.lblAirsAt.Text = "Airs at:";
            // 
            // lblAirsOn
            // 
            this.lblAirsOn.AutoSize = true;
            this.lblAirsOn.BackColor = System.Drawing.Color.Transparent;
            this.lblAirsOn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirsOn.ForeColor = System.Drawing.Color.Black;
            this.lblAirsOn.Location = new System.Drawing.Point(303, 223);
            this.lblAirsOn.Name = "lblAirsOn";
            this.lblAirsOn.Size = new System.Drawing.Size(47, 15);
            this.lblAirsOn.TabIndex = 58;
            this.lblAirsOn.Text = "Airs on:";
            // 
            // lblEpisodes
            // 
            this.lblEpisodes.AutoSize = true;
            this.lblEpisodes.BackColor = System.Drawing.Color.Transparent;
            this.lblEpisodes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodes.ForeColor = System.Drawing.Color.Black;
            this.lblEpisodes.Location = new System.Drawing.Point(292, 187);
            this.lblEpisodes.Name = "lblEpisodes";
            this.lblEpisodes.Size = new System.Drawing.Size(56, 15);
            this.lblEpisodes.TabIndex = 56;
            this.lblEpisodes.Text = "Episodes:";
            // 
            // lblSeasons
            // 
            this.lblSeasons.AutoSize = true;
            this.lblSeasons.BackColor = System.Drawing.Color.Transparent;
            this.lblSeasons.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeasons.ForeColor = System.Drawing.Color.Black;
            this.lblSeasons.Location = new System.Drawing.Point(294, 151);
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
            this.lblGenre.BackColor = System.Drawing.Color.Transparent;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.Location = new System.Drawing.Point(18, 259);
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
            this.lblRating.BackColor = System.Drawing.Color.Transparent;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(18, 223);
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
            this.lblActors.BackColor = System.Drawing.Color.Transparent;
            this.lblActors.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActors.Location = new System.Drawing.Point(18, 187);
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
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(18, 151);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 15);
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "Title:";
            // 
            // pcbxSeries1
            // 
            this.pcbxSeries1.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries1.Location = new System.Drawing.Point(739, 55);
            this.pcbxSeries1.Name = "pcbxSeries1";
            this.pcbxSeries1.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries1.TabIndex = 65;
            this.pcbxSeries1.TabStop = false;
            // 
            // pcbxSeries2
            // 
            this.pcbxSeries2.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries2.Location = new System.Drawing.Point(739, 145);
            this.pcbxSeries2.Name = "pcbxSeries2";
            this.pcbxSeries2.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries2.TabIndex = 66;
            this.pcbxSeries2.TabStop = false;
            // 
            // pcbxSeries3
            // 
            this.pcbxSeries3.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries3.Location = new System.Drawing.Point(739, 235);
            this.pcbxSeries3.Name = "pcbxSeries3";
            this.pcbxSeries3.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries3.TabIndex = 67;
            this.pcbxSeries3.TabStop = false;
            // 
            // pcbxSeries4
            // 
            this.pcbxSeries4.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries4.Location = new System.Drawing.Point(739, 325);
            this.pcbxSeries4.Name = "pcbxSeries4";
            this.pcbxSeries4.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries4.TabIndex = 68;
            this.pcbxSeries4.TabStop = false;
            // 
            // pcbxSeries6
            // 
            this.pcbxSeries6.BackColor = System.Drawing.Color.Transparent;
            this.pcbxSeries6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxSeries6.Location = new System.Drawing.Point(739, 415);
            this.pcbxSeries6.Name = "pcbxSeries6";
            this.pcbxSeries6.Size = new System.Drawing.Size(458, 84);
            this.pcbxSeries6.TabIndex = 69;
            this.pcbxSeries6.TabStop = false;
            // 
            // frmMainV3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pcbxSeries6);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries6)).EndInit();
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
        private System.Windows.Forms.PictureBox pcbxSeries6;
    }
}