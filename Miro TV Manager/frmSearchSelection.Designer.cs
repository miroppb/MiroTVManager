namespace Miro_TV_Manager
{
    partial class frmSearchSelection
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
            this.lstSeries = new System.Windows.Forms.ListView();
            this.pcbxSeries = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.clmTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSeries
            // 
            this.lstSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTitle,
            this.clmDesc});
            this.lstSeries.FullRowSelect = true;
            this.lstSeries.Location = new System.Drawing.Point(12, 12);
            this.lstSeries.MultiSelect = false;
            this.lstSeries.Name = "lstSeries";
            this.lstSeries.Size = new System.Drawing.Size(369, 235);
            this.lstSeries.TabIndex = 0;
            this.lstSeries.UseCompatibleStateImageBehavior = false;
            this.lstSeries.View = System.Windows.Forms.View.Details;
            this.lstSeries.SelectedIndexChanged += new System.EventHandler(this.lstSeries_SelectedIndexChanged);
            this.lstSeries.DoubleClick += new System.EventHandler(this.lstSeries_DoubleClick);
            // 
            // pcbxSeries
            // 
            this.pcbxSeries.BackColor = System.Drawing.Color.Black;
            this.pcbxSeries.Location = new System.Drawing.Point(12, 260);
            this.pcbxSeries.Name = "pcbxSeries";
            this.pcbxSeries.Size = new System.Drawing.Size(369, 68);
            this.pcbxSeries.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxSeries.TabIndex = 1;
            this.pcbxSeries.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(159, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // clmTitle
            // 
            this.clmTitle.Text = "Title";
            this.clmTitle.Width = 130;
            // 
            // clmDesc
            // 
            this.clmDesc.Text = "Overview";
            this.clmDesc.Width = 200;
            // 
            // frmSearchSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(393, 369);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pcbxSeries);
            this.Controls.Add(this.lstSeries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSearchSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select the series...";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSeries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pcbxSeries;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ListView lstSeries;
        private System.Windows.Forms.ColumnHeader clmTitle;
        private System.Windows.Forms.ColumnHeader clmDesc;
    }
}