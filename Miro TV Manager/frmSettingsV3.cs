using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Data.SQLite;

namespace Miro_TV_Manager
{
    public partial class frmSettingsV3 : Form
    {
        public string token;
        SQLiteConnection dbConnection;
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Miro TV Manager\";
        public bool u = false;

        public frmSettingsV3()
        {
            InitializeComponent();
            dbConnection = new SQLiteConnection("Data Source=" + path + "database.sqlite;Version=3;");
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtUsername.Text == "Username")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaption);
            }
        }

        private void txtUserkey_Enter(object sender, EventArgs e)
        {
            if (txtUserkey.Text == "ID key")
            {
                txtUserkey.Text = "";
                txtUserkey.ForeColor = Color.Black;
            }
        }

        private void txtUserkey_Leave(object sender, EventArgs e)
        {
            if (txtUserkey.Text == "" || txtUserkey.Text == "ID key")
            {
                txtUserkey.Text = "ID key";
                txtUserkey.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaption);
            }
        }

        private void lbltheTVDB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You might have to log in first before you see your Account ID");
            Process.Start("http://thetvdb.com/?tab=userinfo");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "Username" && txtUsername.Text != "")
            {
                //test the credentials
                Dictionary<string, string> j = new Dictionary<string, string>();
                j.Add("apikey", "B6A934518784BE16");
                //j.Add("username", txtUsername.Text);
                j.Add("userkey", txtUserkey.Text);
                string json = JsonConvert.SerializeObject(j);

                var baseAddress = "https://api.thetvdb.com/login";

                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";

                string parsedContent = json;
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(parsedContent);

                try
                {
                    Stream newStream = http.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();

                    var response = http.GetResponse();

                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    var content = sr.ReadToEnd();

                    RootObject d = JsonConvert.DeserializeObject<RootObject>(content);
                    token = d.token;
                }
                catch
                {
                    MessageBox.Show("An error has occured. You most likely entered the wrong username or ID. Please try again, or remove both fields.");
                }
            }

            this.Hide();
        }

        public class RootObject
        {
            public string token { get; set; }
        }

        #region SQLite code
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dbConnection);
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(dbConnection);
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand(conn);
            comm.CommandText = sql;
            int rowsUpdated = comm.ExecuteNonQuery();
            conn.Close();
            return rowsUpdated;
        }

        public int ExecuteNonQueryWithBlob(string sql, string blobFieldName, byte[] blob)
        {
            SQLiteConnection con = new SQLiteConnection(dbConnection);
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = String.Format(sql);
            SQLiteParameter param = new SQLiteParameter("@" + blobFieldName, System.Data.DbType.Binary);
            param.Value = blob;
            cmd.Parameters.Add(param);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
            con.Close();
            return 0;
        }

        public bool Update(string tableName, Dictionary<string, string> data, string where)
        {
            string vals = "";
            bool returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<string, string> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery(String.Format("UPDATE {0} SET {1} WHERE {2}", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        public bool Delete(string tableName, string where)
        {
            bool returnCode = true;
            try
            {
                this.ExecuteNonQuery(String.Format("DELETE FROM {0} WHERE {1}", tableName, where));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                returnCode = false;
            }
            return returnCode;
        }

        public bool Insert(string tableName, Dictionary<string, string> data)
        {
            string columns = "";
            string values = "";
            bool returnCode = true;
            foreach (KeyValuePair<string, string> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery(String.Format("INSERT INTO {0}({1}) VALUES({2});", tableName, columns, values));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                returnCode = false;
            }
            return returnCode;
        }
        public void Prepare(string sql, List<SQLiteParameter> data)
        {
            SQLiteConnection conn = new SQLiteConnection(dbConnection);
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand(conn);
            comm.CommandText = sql;
            for (int c = 0; c < data.Count(); c++)
                comm.Parameters.Add(data[c]);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
        #region Image-related code
        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }
        public byte[] getByteArray(DataRow row, int offset)
        {
            object blob = row[offset];
            if (blob == null) return null;
            if (blob == DBNull.Value) return null;
            byte[] arData = (byte[])blob;
            return arData;
        }
        /// <summary>
        /// Load Image from database as image for a picturebox, with tooltip and Tag, and changes the Cursor to Hand
        /// </summary>
        /// <param name="p">The PictureBox to use</param>
        /// <param name="sql">SQL to get the image from database</param>
        /// <param name="tool">Tooltip. Name of series</param>
        /// <param name="tag">Tag. ID of series, for reference when selecting or deleting</param>
        private void LoadImage(PictureBox p, string sql)
        {
            SQLiteConnection con = new SQLiteConnection(dbConnection);
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            con.Open();
            try
            {
                IDataReader rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        if (rdr[0] == DBNull.Value)
                        {
                            p.Image = Image.FromFile(path + "no_banner.png");
                        }
                        else
                        {
                            byte[] a = (System.Byte[])rdr[0];
                            p.Image = ByteToImage(a);
                        }
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();
        }
        #endregion

        private void cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeries.SelectedIndex != -1)
            {
                //get series id
                DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[cmbSeries.SelectedIndex].ToString() + "\"");
                if (id.Rows.Count > 0)
                {
                    LoadImage(pcbxSeries, "SELECT banner FROM series WHERE id = " + id.Rows[0].ItemArray[0].ToString());
                    u = true;
                    DataTable n = GetDataTable("SELECT * FROM notify WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                    if (n.Rows.Count > 0)
                    {
                        switch (Convert.ToInt16(n.Rows[0].ItemArray[1].ToString()))
                        {
                            case -1:
                                chkBefore.Checked = false;
                                chkAfter.Checked = false;
                                break;
                            case 0:
                                chkBefore.Checked = true;
                                chkAfter.Checked = false;
                                nmMinutes.Value = Convert.ToInt16(n.Rows[0].ItemArray[2].ToString());
                                nmMinutes.Enabled = true;
                                break;
                            case 1:
                                chkBefore.Checked = false;
                                chkAfter.Checked = true;
                                break;
                            case 2:
                                chkBefore.Checked = true;
                                chkAfter.Checked = true;
                                nmMinutes.Value = Convert.ToInt16(n.Rows[0].ItemArray[2].ToString());
                                nmMinutes.Enabled = true;
                                break;
                        }
                        if (n.Rows[0].ItemArray[3].ToString() == "1")
                            chkNewSeason.Checked = true;
                        else
                            chkNewSeason.Checked = false;
                        if (n.Rows[0].ItemArray[5].ToString() == "1")
                            chkWatch.Checked = true;
                        else
                            chkWatch.Checked = false;

                    }
                    else
                    {
                        chkBefore.Checked = false;
                        chkAfter.Checked = false;
                        chkNewSeason.Checked = false;
                        nmMinutes.Value = 15;
                        ExecuteNonQuery("INSERT INTO notify VALUES(" + id.Rows[0].ItemArray[0].ToString() + ", -1, 15, 0, NULL, 0)");
                    }
                    u = false;
                    //when clicking checkboxes, and entering minutes, automatically save into database
                    //when apply-all, show messagebox with settings, and yes/no to apply to all
                }
                else
                    MessageBox.Show("An error has occured :/. Please contact miro@miroppb.com meow!");
            }
        }

        private void chkBefore_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[cmbSeries.SelectedIndex].ToString() + "\"");
                if (id.Rows.Count > 0)
                {
                    switch (chkBefore.Checked)
                    {
                        case true:
                            nmMinutes.Enabled = true;
                            if (chkAfter.Checked)
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = 2 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            else
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = 0 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            break;
                        case false:
                            nmMinutes.Enabled = false;
                            if (chkAfter.Checked)
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = 1 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            else
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = -1 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            break;
                    }
                }
            }
        }

        private void chkAfter_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[cmbSeries.SelectedIndex].ToString() + "\"");
                if (id.Rows.Count > 0)
                {
                    switch (chkAfter.Checked)
                    {
                        case true:
                            if (chkBefore.Checked)
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = 2 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            else
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = 1 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            break;
                        case false:
                            if (chkBefore.Checked)
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = 0 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            else
                                ExecuteNonQuery("UPDATE notify SET beforeAfter = -1 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            break;
                    }
                }
            }
        }

        private void chkNewSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[cmbSeries.SelectedIndex].ToString() + "\"");
                if (id.Rows.Count > 0)
                {
                    switch (chkNewSeason.Checked)
                    {
                        case true:
                            DataTable a = GetDataTable("SELECT seasonNumber FROM episodes WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString() + " AND seasonNumber > 0 AND date(dateAired) < date('now') GROUP BY seasonNumber ORDER BY seasonNumber DESC LIMIT 0,1");
                            string cs = "0";
                            if (a.Rows.Count > 0)
                                cs = a.Rows[0].ItemArray[0].ToString();
                            ExecuteNonQuery("UPDATE notify SET newSeason = 1, currentSeason = " + cs + " WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            break;
                        case false:
                            ExecuteNonQuery("UPDATE notify SET newSeason = 0, currentSeason = NULL WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                            break;
                    }
                }
            }
        }

        private void nmMinutes_ValueChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[cmbSeries.SelectedIndex].ToString() + "\"");
                if (id.Rows.Count > 0)
                {
                    ExecuteNonQuery("UPDATE notify SET beforeTime = " + nmMinutes.Value.ToString() + " WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                }
            }
        }

        private void btnApplyToAll_Click(object sender, EventArgs e)
        {
            string b = "";
            if (chkBefore.Checked)
                b = "\n\rNotify " + nmMinutes.Value.ToString() + " minutes before the episode airs";
            string a = "";
            if (chkAfter.Checked)
                a = "\n\rNotify as soon as the episode has aired";
            string n = "";
            if (chkNewSeason.Checked)
                n = "\n\rNotify when an air date for a new season is revealed";
            string w = "";
            if (chkWatch.Checked)
                w = "\n\rNotify if I missed an episode";
            if (b == "" && a == "" && n == "" && w == "")
                n = "--Remove all notification--";
            if (MessageBox.Show("Are you sure you want to apply to following settings to all series?\n\r" + b + a + n, "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (chkBefore.Checked)
                {
                    case true:
                        if (chkAfter.Checked)
                            ExecuteNonQuery("UPDATE notify SET beforeAfter = 2");
                        else
                            ExecuteNonQuery("UPDATE notify SET beforeAfter = 0");
                        break;
                    case false:
                        if (chkAfter.Checked)
                            ExecuteNonQuery("UPDATE notify SET beforeAfter = 1");
                        else
                            ExecuteNonQuery("UPDATE notify SET beforeAfter = -1");
                        break;
                }
                ExecuteNonQuery("UPDATE notify SET beforeTime = " + nmMinutes.Value.ToString());

                for (int c = 0; c < cmbSeries.Items.Count; c++)
                {
                    DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[c].ToString() + "\"");
                    if (id.Rows.Count > 0)
                    {
                        switch (chkNewSeason.Checked)
                        {
                            case true:
                                DataTable aa = GetDataTable("SELECT seasonNumber FROM episodes WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString() + " AND seasonNumber > 0 AND date(dateAired) < date('now') GROUP BY seasonNumber ORDER BY seasonNumber DESC LIMIT 0,1");
                                string cs = "0";
                                if (aa.Rows.Count > 0)
                                    cs = aa.Rows[0].ItemArray[0].ToString();
                                ExecuteNonQuery("UPDATE notify SET newSeason = 1, currentSeason = " + cs + " WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                                break;
                            case false:
                                ExecuteNonQuery("UPDATE notify SET newSeason = 0, currentSeason = NULL WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                                break;
                        }
                    }
                }
                if (chkWatch.Checked)
                    ExecuteNonQuery("UPDATE notify SET notifyWatch = 1");
                else
                    ExecuteNonQuery("UPDATE notify SET notifyWatch = 0");
            }
        }

        private void chkWatch_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                DataTable id = GetDataTable("SELECT id FROM series WHERE name = \"" + cmbSeries.Items[cmbSeries.SelectedIndex].ToString() + "\"");
                if (id.Rows.Count > 0)
                {
                    if (chkWatch.Checked)
                        ExecuteNonQuery("UPDATE notify SET notifyWatch = 1 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                    else
                        ExecuteNonQuery("UPDATE notify SET notifyWatch = 0 WHERE seriesID = " + id.Rows[0].ItemArray[0].ToString());
                }
            }
        }

        private void chkTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                if (chkTaskbar.Checked)
                    ExecuteNonQuery("UPDATE settings SET minimizeClose = 1");
                else
                    ExecuteNonQuery("UPDATE settings SET minimizeClose = 0");
            }
        }

        private void chkEnded_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                if (chkEnded.Checked)
                    ExecuteNonQuery("UPDATE settings SET notifyEnded = 1");
                else
                    ExecuteNonQuery("UPDATE settings SET notifyEnded = 0");
            }
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                if (chkUpdate.Checked)
                    ExecuteNonQuery("UPDATE settings SET updateSeries = 1");
                else
                    ExecuteNonQuery("UPDATE settings SET updateSeries = 0");
            }
        }

        private void nmDuration_ValueChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                ExecuteNonQuery("UPDATE settings SET updateEvery = \"" + nmDuration.Value + "," + cmbTimeframe.SelectedIndex + "\"");
            }
        }

        private void cmbTimeframe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                ExecuteNonQuery("UPDATE settings SET updateEvery = \"" + nmDuration.Value + "," + cmbTimeframe.SelectedIndex + "\"");
            }
            if (cmbTimeframe.SelectedIndex == 0)
            {
                lblAtOn.Visible = false;
                dtTime.Visible = false;
            }
            else
            {
                lblAtOn.Visible = false;
                dtTime.Visible = false;
            }
            if (cmbTimeframe.SelectedIndex == 1)
            {
                lblAtOn.Visible = true;
                lblAtOn.Text = "at:";
                dtTime.Visible = true;
                dtTime.CustomFormat = "HH:mm tt";
            }
            if (cmbTimeframe.SelectedIndex == 2)
            {
                lblAtOn.Visible = true;
                lblAtOn.Text = "on:";
                dtTime.Visible = true;
                dtTime.CustomFormat = "dd"; //Change the text around a bit, to be more appealing
            }
            if (!u)
            {
                if (cmbTimeframe.SelectedIndex == 1)
                    ExecuteNonQuery("UPDATE settings SET updateAt = \"" + dtTime.Value.ToShortTimeString() + "\"");
                else if (cmbTimeframe.SelectedIndex == 2)
                    ExecuteNonQuery("UPDATE settings SET updateAt = \"" + dtTime.Value.Day.ToString() + "\"");
            }
        }

        private void dtTime_ValueChanged(object sender, EventArgs e)
        {
            if (!u)
            {
                if (cmbTimeframe.SelectedIndex == 1)
                    ExecuteNonQuery("UPDATE settings SET updateAt = \"" + dtTime.Value.ToShortTimeString() + "\"");
                else if (cmbTimeframe.SelectedIndex == 2)
                    ExecuteNonQuery("UPDATE settings SET updateAt = \"" + dtTime.Value.Day.ToString() + "\"");
            }
        }

        private void txtProwlID_Enter(object sender, EventArgs e)
        {
            if (txtProwlID.Text == "API key")
            {
                txtProwlID.Text = "";
                txtProwlID.ForeColor = Color.Black;
            }
        }

        private void txtProwlID_Leave(object sender, EventArgs e)
        {
            if (txtProwlID.Text == "" || txtProwlID.Text == "API key")
            {
                txtProwlID.Text = "API key";
                txtProwlID.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaption);
            }
        }

        private void lnkProwl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://www.prowlapp.com/api_settings.php");
        }

        private void txtProwlID_TextChanged(object sender, EventArgs e)
        {
            if (!u)
                ExecuteNonQuery("UPDATE settings SET prowlID = \"" + txtProwlID.Text + "\"");
        }

        private void TxtPlex_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Database|com.plexapp.plugins.library.db";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TxtPlex.Text = ofd.FileName;
            }
        }

        private void ChkPlex_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPlex.Checked)
            {
                LblPlex.Enabled = true;
                TxtPlex.Enabled = true;
            }
            else
            {
                LblPlex.Enabled = false;
                TxtPlex.Enabled = false;
                TxtPlex.Text = "";
            }
        }

        private void TxtPlex_TextChanged(object sender, EventArgs e)
        {
            if (!u)
                ExecuteNonQuery("UPDATE settings SET plex = \"" + TxtPlex.Text + "\"");
        }
    }
}
