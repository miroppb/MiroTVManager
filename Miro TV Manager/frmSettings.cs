using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Collections;

namespace Miro_TV_Manager
{
    public partial class frmSettings : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Miro TV Manager\";
        StreamReader reader;
        StreamWriter writer;
        string[] settings;
        Dictionary<string, string> seriesInfo = new Dictionary<string, string>();
        ArrayList topSeries = new ArrayList();

        public frmSettings()
        {
            InitializeComponent();
            if (File.Exists(path+"settings.ini"))
            {
                reader = new StreamReader(path + "settings.ini");
                settings = reader.ReadToEnd().Split('\n');
                reader.Close();
                int c = 0;
                while (c < settings.Count()) { settings[c] = settings[c].Trim('\r'); c++; }
                c = 3;
                while (c<settings.Count()-1 && settings.Count() != 4)
                {
                    string[] temp = settings[c].Split('*');
                    seriesInfo.Add(temp[0] + "-Title", temp[4]);
                    seriesInfo.Add(temp[0] + "-Before", temp[1]);
                    seriesInfo.Add(temp[0] + "-After", temp[2]);
                    seriesInfo.Add(temp[0] + "-NextAir", temp[3]);
                    seriesInfo.Add(temp[0] + "-NextAirSE", temp[5]);
                    seriesInfo.Add(temp[0] + "-NextAirEpisode", temp[6]);
                    topSeries.Add(temp[0]);
                    cmbSeriesList.Items.Add(temp[4]);
                    c++;
                }
                try { cmbSeriesList.SelectedIndex = 0; }
                catch { }
                if (!settings[0].Contains("Account Identifier...")) { txtAccountID.Text = settings[0].Replace("ID:", ""); }
                if (!settings[1].Contains("API Key...")) { txtProwl.Text = settings[1].Replace("Prowl:", ""); }
                if (cmbSeriesList.Items.Count == 0) { grpNotify.Visible = false; }
                else { grpNotify.Visible = true; }
            }
        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountID.Focused || txtAccountID.Text != "Account Identifier...") {txtAccountID.ForeColor = Color.Black; }
            else if (txtAccountID.Text.Length == 0)
            {
                txtAccountID.ForeColor = SystemColors.InactiveCaption;
                txtAccountID.Text = "Account Identifier...";
            }
            if (txtAccountID.Text.Length >= 16 && txtAccountID.Text.Length <= 32 && (settings[0] != "" || settings[0] != "Account Identifier...")) { lblCloseToSave.Visible = true; }
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //saving
            writer = new StreamWriter(path + "settings.ini");
            writer.WriteLine("ID:" + txtAccountID.Text);
            writer.WriteLine("Prowl:" + txtProwl.Text);
            //writer.WriteLine("[Favorites]");
            int c = 2;
            while (c < settings.Count()-1) { writer.WriteLine(settings[c]); c++; }
            writer.Close();
        }

        private void lnkDontHave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://thetvdb.com/?tab=userinfo");
        }

        private void txtAccountID_Enter(object sender, EventArgs e)
        {
            if (txtAccountID.Text == "Account Identifier...") { txtAccountID.Text = ""; }
        }

        private void txtAccountID_Leave(object sender, EventArgs e)
        {
            if (txtAccountID.Text == "" || txtAccountID.Text == null)
            {
                txtAccountID.ForeColor = SystemColors.InactiveCaption;
                txtAccountID.Text = "Account Identifier...";
            }
        }

        private void frmSettings_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Hide(); }
        }

        private void cmbSeriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = cmbSeriesList.SelectedIndex;
            //set image
            pcbxCurrent.Image = Image.FromFile(path + topSeries[s] + ".jpg");
            //check if any checkboxes need to be checked
            if (seriesInfo[topSeries[s] + "-Before"] == "0") { chkBefore.Checked = false; }
            else { chkBefore.Checked = true; }
            if (seriesInfo[topSeries[s] + "-After"] == "0") { chkAfter.Checked = false; }
            else { chkAfter.Checked = true; }
        }

        private void chkBefore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBefore.Checked) {
                cmbBeforeTime.Enabled = true;
                if (seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] != "0")
                {
                    int before = Convert.ToInt16(seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"]);
                    switch(before)
                    {
                        case 60:
                            cmbBeforeTime.SelectedIndex = 0;
                            break;
                        case 30:
                            cmbBeforeTime.SelectedIndex = 1;
                            break;
                        case 15:
                            cmbBeforeTime.SelectedIndex = 2;
                            break;
                        case 10:
                            cmbBeforeTime.SelectedIndex = 3;
                            break;
                        case 5:
                            cmbBeforeTime.SelectedIndex = 4;
                            break;
                    }
                }
                if (cmbBeforeTime.SelectedIndex == -1) { cmbBeforeTime.SelectedIndex = 0; }
            }
            else {
                cmbBeforeTime.Enabled = false; seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] = "0";
                cmbBeforeTime.SelectedIndex = -1;
            }
            updateSettings();
        }

        private void chkAfter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfter.Checked) { seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-After"] = "1"; }
            else { seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-After"] = "0"; }
            updateSettings();
        }
        
        private void cmbBeforeTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBeforeTime.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] = "60";
                    break;
                case 1:
                    seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] = "30";
                    break;
                case 2:
                    seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] = "15";
                    break;
                case 3:
                    seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] = "10";
                    break;
                case 4:
                    seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] = "5";
                    break;
            }
            updateSettings();
        }

        private void btnApplyToAll_Click(object sender, EventArgs e)
        {
            string set = "";
            if (chkBefore.Checked) { set += "● (Notify) " + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] + " minutes Before the show airs\r\n"; }
            else { set += "● (Don't Notify) Before the show airs\r\n"; }
            if (chkAfter.Checked) { set += "● (Notify)After the show airs"; }
            else { set += "● (Don't Notify) After the show airs"; }
            DialogResult result = MessageBox.Show("Are you sure you want to apply the following settings to all?\r\n\r\n" + set, "Miro TV Manager",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int c = 0;
                while (c < topSeries.Count)
                {
                    if (chkBefore.Checked) { seriesInfo[topSeries[c] + "-Before"] = seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"]; }
                    if (chkAfter.Checked) { seriesInfo[topSeries[c] + "-After"] = seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-After"]; }
                    settings[c + 3] = topSeries[c].ToString() + "*"
                        + seriesInfo[topSeries[c] + "-Before"] + "*"
                        + seriesInfo[topSeries[c] + "-After"] + "*"
                        + seriesInfo[topSeries[c] + "-NextAir"] + "*"
                        + seriesInfo[topSeries[c] + "-Title"] + "*"
                        + seriesInfo[topSeries[c] + "-NextAirSE"] + "*"
                        + seriesInfo[topSeries[c] + "-NextAirEpisode"];
                    c++;
                }
                MessageBox.Show("Successful");
            }
        }

        private void updateSettings()
        {
            settings[cmbSeriesList.SelectedIndex + 3] = topSeries[cmbSeriesList.SelectedIndex].ToString() + "*"
                    + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Before"] + "*"
                    + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-After"] + "*"
                    + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-NextAir"] + "*"
                    + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-Title"] + "*"
                    + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-NextAirSE"] + "*"
                    + seriesInfo[topSeries[cmbSeriesList.SelectedIndex] + "-NextAirEpisode"];
        }

        private void txtProwl_TextChanged(object sender, EventArgs e)
        {
            if (txtProwl.Focused || txtProwl.Text != "API Key...") { txtProwl.ForeColor = Color.Black; }
            else if (txtProwl.Text.Length == 0)
            {
                txtProwl.ForeColor = SystemColors.InactiveCaption;
                txtProwl.Text = "API Key...";
            }
            if (txtProwl.Text.Length > 40) { txtProwl.Text = txtProwl.Text.Trim(' '); }
        }

        private void txtProwl_Enter(object sender, EventArgs e)
        {
            if (txtProwl.Text == "API Key...") { txtProwl.Text = ""; }
        }

        private void txtProwl_Leave(object sender, EventArgs e)
        {
            if (txtProwl.Text == "" || txtProwl.Text == null)
            {
                txtProwl.ForeColor = SystemColors.InactiveCaption;
                txtProwl.Text = "API Key...";
            }
        }
    }
}
