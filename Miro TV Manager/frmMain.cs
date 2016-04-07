using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections;
using System.Xml;
using System.Diagnostics;
using ImageMagick;

namespace Miro_TV_Manager
{
    public partial class frmMain : Form
    {
        //common variables
        public string API = "B6A934518784BE16";
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Miro TV Manager\";
        public string settingsVersion = "2.0.0.1";
        public string accountID = "";
        public bool favoritesExist = false;
        public bool internet = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        string currentSearchID = "";
        string currentNextShow = "";
        bool currentEnded = false;
        string seriesThatEnded = "The following series have ended:\r\n";
        bool seriesThatEndedBool = false;
        int seriesThatEndedCount = 0;
        ArrayList seriesThatEndedList = new ArrayList();
        int currentSelected = -1;
        string checkmark = "✓";
        int currentTopImages = 5;
        bool lastFavorites = false;
        Dictionary<string, string> settingsAlertBefore = new Dictionary<string,string>();
        Dictionary<string, string> settingsAlertAfter = new Dictionary<string, string>();
        string prowl = "";
        bool warned = false; /*About TheTVDB.com account*/
        int press = 0; /*Pressing button seems to trigger twice*/

        //top series
        ArrayList oldTop = new ArrayList();
        ArrayList topSeries = new ArrayList();
        Dictionary<string, string> seriesInfo = new Dictionary<string, string>();

        public frmMain()
        {
            InitializeComponent();

            bool IsExists = System.IO.Directory.Exists(path);
            if (!IsExists) { System.IO.Directory.CreateDirectory(path); }
            if (!File.Exists(path + "settingsVersion.txt"))
            {
                StreamWriter writer = new StreamWriter(path + "settingsVersion.txt");
                writer.Write(settingsVersion);
                writer.Close();
            }
            else
            {
                StreamReader reader = new StreamReader(path + "settingsVersion.txt");
                string nv = reader.ReadLine();
                reader.Close();
                if (nv != settingsVersion)
                {
                    File.Delete(path + "settings.*");
                }
            }
            File.Copy(Application.StartupPath + @"\no_banner.png", path + @"no_banner.png",true);
            forceUpdate();
            checkForNotifications();
            updateNextShow();
        }

        private void forceUpdate()
        {
            //reading the settings.ini
            string[] settings;
            seriesInfo.Clear();
        loadSettings: ;
            if (File.Exists(path + "settings.ini"))
            {
                StreamReader reader = new StreamReader(path + "settings.ini");
                settings = reader.ReadToEnd().Split('\n');
                int c = 0;
                while (c < settings.Count()) { settings[c] = settings[c].Trim('\r'); c++; }
                reader.Close();
                try { if (settings[1].Contains("Prowl") && !settings[1].Contains("API Key...")) { prowl = settings[1].Replace("Prowl:", ""); } }
                catch { File.Delete(path + "settings.ini"); goto loadSettings; }
                c = 3;
                while (c < settings.Count() - 1 && settings.Count() != 4)
                {
                    string[] temp = settings[c].Split('*');
                    try { seriesInfo.Add(temp[0] + "-Before", temp[1]); }
                    catch { seriesInfo[temp[0] + "-Before"] = temp[1]; }
                    try { seriesInfo.Add(temp[0] + "-After", temp[2]); }
                    catch { seriesInfo[temp[0] + "-After"] = temp[2]; }
                    c++;
                }
                if (settings[0].Contains("ID:") && !settings[0].Contains("Account Identifier..."))
                {
                    accountID = settings[0].Replace("ID:", "");
                    //getting Favorites
                    int day = File.GetLastWriteTime(path + "favorites.xml").DayOfYear;
                    int old = DateTime.Today.DayOfYear - day;
                    if (File.Exists(path + "favorites.xml") && old < 7) { favoritesExist = true; }
                    else
                    {
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(@"http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID));
                            using (WebResponse response = request.GetResponse())
                            using (Stream stream = response.GetResponseStream())
                            {
                                string contentType = response.ContentType;
                                string filename = "favorites.xml";
                                using (Stream file = File.OpenWrite(path + filename))
                                {
                                    byte[] buffer = ReadFully(stream, 256);
                                    stream.Read(buffer, 0, buffer.Length);
                                    file.Write(buffer, 0, buffer.Length);
                                }
                            }
                            favoritesExist = true;
                        }
                    }
                    if (favoritesExist)
                    {
                        //parsing favorites.xml
                        frmSplash frm = new frmSplash();
                        frm.Show();
                        this.Hide();
                        XmlTextReader reader1 = new XmlTextReader(path + "favorites.xml");
                        while (!reader1.EOF)
                        {
                            reader1.ReadToFollowing("Series");
                            if (reader1.NodeType == XmlNodeType.None || reader1.NodeType == XmlNodeType.Whitespace) { break; }
                            topSeries.Add(reader1.ReadElementContentAsString());
                        }
                        reader1.Close();
                        //fetching all favorites oh boy lol
                        c = 0;
                        WebClient webClient_fetch = new WebClient();
                        while (c < topSeries.Count && internet)
                        {
                            if (!File.Exists(path + topSeries[c] + ".en.xml") || File.GetLastWriteTime(path + topSeries[c] + ".en.xml").Month < DateTime.Now.Month || File.GetLastWriteTime(path + topSeries[c] + ".en.xml").Month == 12)
                            {
                                //webClient_search.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_Search);
                                webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                                webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/" + API + "/series/" + topSeries[c] + "/all/en.xml"), path + topSeries[c] + ".en.xml");
                                while (webClient_fetch.IsBusy) { }
                            }
                            if (!File.Exists(path + topSeries[c] + ".jpg"))
                            {
                                reader1 = new XmlTextReader(path + topSeries[c] + ".en.xml");
                                reader1.ReadToFollowing("banner");
                                string banner = reader1.ReadElementContentAsString();
                                reader1.ReadToFollowing("fanart");
                                string fanart = reader1.ReadElementContentAsString();
                                reader1.Close();
                                if (banner != "")
                                {
                                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/banners/" + banner), path + topSeries[c] + ".jpg");
                                    while (webClient_fetch.IsBusy) { }
                                    //Making banners semi-transparent
                                    using (MagickImage image = new MagickImage(path + topSeries[c] + ".jpg"))
                                    {
                                        double opacitySetting = Quantum.Max / (Quantum.Max * 0.5);
                                        image.Alpha(AlphaOption.Set);
                                        image.Evaluate(Channels.Alpha, EvaluateOperator.Min, Quantum.Max / opacitySetting);
                                        if (File.Exists(path + topSeries[c] + ".png"))
                                        {
                                            File.Delete(path + topSeries[c] + ".png");
                                        }
                                        image.Write(path + topSeries[c] + ".png");
                                    }
                                }
                                else
                                {
                                    File.Copy(path + "no_banner.png", path + topSeries[c] + ".jpg");
                                    using (MagickImage image = new MagickImage(path + topSeries[c] + ".jpg"))
                                    {
                                        double opacitySetting = Quantum.Max / (Quantum.Max * 0.5);
                                        image.Alpha(AlphaOption.Set);
                                        image.Evaluate(Channels.Alpha, EvaluateOperator.Min, Quantum.Max / opacitySetting);
                                        if (File.Exists(path + topSeries[c] + ".png"))
                                        {
                                            File.Delete(path + topSeries[c] + ".png");
                                        }
                                        image.Write(path + topSeries[c] + ".png");
                                    }
                                }
                                if (fanart != "") { setImageBG(false, topSeries[c].ToString(), "http://thetvdb.com/banners/" + fanart); }

                            }
                            //process the files
                            reader1 = new XmlTextReader(path + topSeries[c] + ".en.xml");
                            try
                            {
                                reader1.ReadToFollowing("Airs_Time");
                                seriesInfo.Add(topSeries[c] + "-AirTime", reader1.ReadElementContentAsString());
                                reader1.ReadToFollowing("Runtime");
                                seriesInfo.Add(topSeries[c] + "-Runtime", reader1.ReadElementContentAsString());
                            }
                            catch
                            {
                                try { seriesInfo.Add(topSeries[c] + "-AirTime", "12:00 PM"); }
                                catch { seriesInfo[topSeries[c] + "-AirTime"] = "12:00 PM"; }
                            }
                            reader1.ReadToFollowing("SeriesName");
                            seriesInfo.Add(topSeries[c] + "-Title", reader1.ReadElementContentAsString());
                            string ep, se;
                            reader1.ReadToFollowing("Status");
                            if (reader1.ReadElementContentAsString() == "Ended")
                            {
                                seriesThatEndedBool = true;
                                seriesThatEnded += "\r\n-" + seriesInfo[topSeries[c] + "-Title"];
                                seriesThatEndedCount++;
                                seriesThatEndedList.Add(topSeries[c]);
                            }
                            reader1.ReadToFollowing("Episode");
                            if (reader1.EOF)
                            {
                                seriesInfo[topSeries[c] + "-NextAirSE"] = "0x0";
                                seriesInfo[topSeries[c] + "-NextAirEpisode"] = ".";
                                seriesInfo[topSeries[c] + "-AirTime"] = DateTime.Today.AddMonths(-1).ToString();
                                seriesInfo[topSeries[c] + "-NextAir"] = DateTime.Today.AddMonths(-1).ToString();
                                goto skipSeries;
                            }
                        ep_again: ;
                            reader1.ReadToFollowing("Combined_episodenumber");
                            ep = reader1.ReadElementContentAsString();
                            if (ep == "" || ep == null || ep == "0") { goto ep_again; }
                            reader1.ReadToFollowing("Combined_season");
                            se = reader1.ReadElementContentAsString();
                            seriesInfo.Add(topSeries[c] + "-NextAirSE", se + "x" + ep);
                            reader1.ReadToFollowing("EpisodeName");
                            seriesInfo.Add(topSeries[c] + "-NextAirEpisode", reader1.ReadElementContentAsString());
                            reader1.ReadToFollowing("FirstAired");
                            string air = reader1.ReadElementContentAsString();
                            if (air == "" || air == null || air == " ") { air = DateTime.Today.AddMonths(-1).ToString(); }
                            if (DateTime.Compare(DateTime.Parse(air), DateTime.Today) == -1)
                            {
                                while (DateTime.Compare(DateTime.Parse(air), DateTime.Today) == -1 && !reader1.EOF)
                                {
                                    try
                                    {
                                        reader1.ReadToFollowing("Combined_episodenumber");
                                        ep = reader1.ReadElementContentAsString();
                                        reader1.ReadToFollowing("Combined_season");
                                        se = reader1.ReadElementContentAsString();
                                        seriesInfo[topSeries[c] + "-NextAirSE"] = se + "x" + ep;
                                    }
                                    catch { seriesInfo[topSeries[c] + "-NextAirSE"] = "0x0"; }
                                    try
                                    {
                                        reader1.ReadToFollowing("EpisodeName");
                                        seriesInfo[topSeries[c] + "-NextAirEpisode"] = reader1.ReadElementContentAsString();
                                    }
                                    catch { seriesInfo[topSeries[c] + "-NextAirEpisode"] = "."; }
                                    reader1.ReadToFollowing("FirstAired");
                                    try { air = reader1.ReadElementContentAsString() + " " + seriesInfo[topSeries[c] + "-AirTime"]; }
                                    catch { }
                                    if (air == "" || air == null || air == " " || air == " " + seriesInfo[topSeries[c] + "-AirTime"]) { air = DateTime.Today.AddMonths(-1).ToString(); }
                                }
                            }
                            else { air = air + " " + topSeries[c] + "-AirTime"; }
                            try { seriesInfo.Add(topSeries[c] + "-NextAir", DateTime.Parse(air).ToString());}
                            catch {}
                        skipSeries: ;
                            reader1.Close();
                            frm.progressStart.Value = (100 * (c+1))/topSeries.Count;
                            frm.lblLoaded.Text = "Downloaded/Processed: " + (c + 1) + "/" + topSeries.Count;
                            frmBlink fB = new frmBlink();
                            fB.ShowDialog();
                            c++;
                        }
                        //lets try to sort the series
                        oldTop.Clear();
                        oldTop.AddRange(topSeries);
                        ArrayList list = new ArrayList();
                        int a = 0;
                        while (a < oldTop.Count)
                        {
                            list.Add(seriesInfo[oldTop[a] + "-Title"]);
                            a++;
                        }
                        list.Sort();
                        a = 0;
                        int b = 0;
                        topSeries.Clear();
                        while (a < oldTop.Count)
                        {
                            while (b < oldTop.Count)
                            {
                                if (seriesInfo[oldTop[b] + "-Title"].ToString() == list[a].ToString()) { topSeries.Add(oldTop[b]); }
                                b++;
                            }
                            b = 0;
                            a++;
                        }
                        //adding top series' images to the list (for now)
                        //process after (Runtime, NextAir, etc.)
                        c = 0;
                        updateTopSeriesImages();
                        if (settings[2].Contains("Favorites") && settings.Count() != 4)
                        {
                            c = 3;
                            while (c < settings.Count()-1)
                            {
                                string[] temp = settings[c].Split('*');
                                try { settingsAlertBefore.Add(temp[0], temp[1]); }
                                catch { settingsAlertBefore[temp[0]] = temp[1]; }
                                try { settingsAlertAfter.Add(temp[0], temp[2]); }
                                catch { settingsAlertAfter[temp[0]] = temp[2]; }
                                c++;
                            }
                        }
                        else
                        {
                            c = 0;
                            while (c < topSeries.Count) { settingsAlertAfter.Add(topSeries[c].ToString(), "0"); settingsAlertBefore.Add(topSeries[c].ToString(), "0"); c++; }
                        }
                        if (seriesThatEndedBool)
                        {
                            DialogResult result = MessageBox.Show(seriesThatEnded + "\r\n\r\nI recommend removing them from your favorites list, but you don't have to :)", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {
                                int z = 0;
                                while (z < seriesThatEndedCount)
                                {
                                    string series = seriesThatEndedList[z].ToString();
                                    topSeries.Remove(series);
                                    File.Delete(path + "favorites.xml");
                                    if (accountID != "" && accountID != null)
                                    {
                                        WebClient webClient_fetch_remove = new WebClient();
                                        webClient_fetch_remove.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                                        webClient_fetch_remove.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=remove&seriesid=" + series), path + "favorites.xml");
                                        while (webClient_fetch_remove.IsBusy) { }
                                    }
                                    else
                                    {
                                        if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                                        XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                                        writer.Formatting = Formatting.Indented;
                                        writer.WriteStartDocument();
                                        writer.WriteStartElement("Favorites");
                                        int zz = 0;
                                        while (zz < topSeries.Count)
                                        {
                                            writer.WriteStartElement("Series");
                                            writer.WriteString(topSeries[c].ToString());
                                            writer.WriteEndElement();
                                            zz++;
                                        }
                                        writer.WriteEndElement();
                                        writer.WriteEndDocument();
                                        writer.Close();
                                    }
                                    z++;
                                    saveSettings();
                                }
                            }
                        }
                        frm.Hide();
                    }
                    this.Show();
                }
            }
            lblLastUpdated.Text = "Last Updated: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            saveSettings();
            //end forceUpdate()
            var source = new AutoCompleteStringCollection();
            ArrayList tempList = new ArrayList();
            int d = 0;
            while (d<topSeries.Count)
            {
                tempList.Add(seriesInfo[topSeries[d] + "-Title"]);
                d++;
            }
            string[] tempArray = new string[topSeries.Count];
            tempList.CopyTo(tempArray);
            source.AddRange(tempArray);
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteCustomSource = source;
        }

        private void updateTopSeriesImages()
        {
            int c = 0;
            if (lastFavorites)
            {
                c = topSeries.Count;
                int a = 0;
                while (c > 5)
                {
                    c = c - 5;
                    a++;
                }
                c = (a * 5);
                pcbxDown.Enabled = false;
            }
            else
            {
                c = currentTopImages - 5;
            }
            int d = 1;
            pcbxUp.Visible = true;
            pcbxUp.Cursor = Cursors.Hand;
            pcbxDown.Visible = true;
            pcbxDown.Cursor = Cursors.Hand;
            if (c < 5) { pcbxUp.Enabled = false; }
            if (c == (topSeries.Count - 5)) { pcbxDown.Enabled = false; }
            while(c <= currentTopImages || d <= 5)
            {
                switch(d)
                {
                    case 1:
                        try
                        {
                            pcbxTop1.Image = Image.FromFile(path + topSeries[c] + ".png");
                            pcbxTop1.Tag = topSeries[c];
                            pcbxTop1.Cursor = Cursors.Hand;
                            //pcbxTop1.BackColor = Color.Black;
                            pcbxDelete1.Visible = true;
                            pcbxDelete1.Cursor = Cursors.Hand;
                            toolTip1.SetToolTip(pcbxTop1, seriesInfo[topSeries[c] + "-Title"]);
                            toolTip1.SetToolTip(pcbxDelete1, "Remove \"" + seriesInfo[topSeries[c] + "-Title"] + "\" from Favorites");
                        }
                        catch
                        {
                            pcbxTop1.Image = null;
                            pcbxTop1.Tag = "";
                            pcbxTop1.Cursor = Cursors.Default;
                            pcbxTop1.BackColor = Color.Transparent;
                            pcbxDelete1.Visible = false;
                            pcbxDelete1.Cursor = Cursors.Default;
                            toolTip1.SetToolTip(pcbxTop1, "");
                            toolTip1.SetToolTip(pcbxDelete1, "");
                        }
                        break;
                    case 2:
                        try
                        {
                            pcbxTop2.Image = Image.FromFile(path + topSeries[c] + ".png");
                            pcbxTop2.Tag = topSeries[c];
                            pcbxTop2.Cursor = Cursors.Hand;
                            //pcbxTop2.BackColor = Color.Black;
                            pcbxDelete2.Visible = true;
                            pcbxDelete2.Cursor = Cursors.Hand;
                            toolTip1.SetToolTip(pcbxTop2, seriesInfo[topSeries[c] + "-Title"]);
                            toolTip1.SetToolTip(pcbxDelete2, "Remove \"" + seriesInfo[topSeries[c] + "-Title"] + "\" from Favorites");
                        }
                        catch
                        {
                            pcbxTop2.Image = null;
                            pcbxTop2.Tag = "";
                            pcbxTop2.Cursor = Cursors.Default;
                            pcbxTop2.BackColor = Color.Transparent;
                            pcbxDelete2.Visible = false;
                            pcbxDelete2.Cursor = Cursors.Default;
                            toolTip1.SetToolTip(pcbxTop2, "");
                            toolTip1.SetToolTip(pcbxDelete2, "");
                        }
                        break;
                    case 3:
                        try
                        {
                            pcbxTop3.Image = Image.FromFile(path + topSeries[c] + ".png");
                            pcbxTop3.Tag = topSeries[c];
                            pcbxTop3.Cursor = Cursors.Hand;
                            //pcbxTop3.BackColor = Color.Black;
                            pcbxDelete3.Visible = true;
                            pcbxDelete3.Cursor = Cursors.Hand;
                            toolTip1.SetToolTip(pcbxTop3, seriesInfo[topSeries[c] + "-Title"]);
                            toolTip1.SetToolTip(pcbxDelete3, "Remove \"" + seriesInfo[topSeries[c] + "-Title"] + "\" from Favorites");
                        }
                        catch
                        {
                            pcbxTop3.Image = null;
                            pcbxTop3.Tag = "";
                            pcbxTop3.Cursor = Cursors.Default;
                            pcbxTop3.BackColor = Color.Transparent;
                            pcbxDelete3.Visible = false;
                            pcbxDelete3.Cursor = Cursors.Default;
                            toolTip1.SetToolTip(pcbxTop3, "");
                            toolTip1.SetToolTip(pcbxDelete3, "");
                        }
                        break;
                    case 4:
                        try
                        {
                            pcbxTop4.Image = Image.FromFile(path + topSeries[c] + ".png");
                            pcbxTop4.Tag = topSeries[c];
                            pcbxTop4.Cursor = Cursors.Hand;
                            //pcbxTop4.BackColor = Color.Black;
                            pcbxDelete4.Visible = true;
                            pcbxDelete4.Cursor = Cursors.Hand;
                            toolTip1.SetToolTip(pcbxTop4, seriesInfo[topSeries[c] + "-Title"]);
                            toolTip1.SetToolTip(pcbxDelete4, "Remove \"" + seriesInfo[topSeries[c] + "-Title"] + "\" from Favorites");
                        }
                        catch
                        {
                            pcbxTop4.Image = null;
                            pcbxTop4.Tag = "";
                            pcbxTop4.Cursor = Cursors.Default;
                            pcbxTop4.BackColor = Color.Transparent;
                            pcbxDelete4.Visible = false;
                            pcbxDelete4.Cursor = Cursors.Default;
                            toolTip1.SetToolTip(pcbxTop4, "");
                            toolTip1.SetToolTip(pcbxDelete4, "");
                        }
                        break;
                    case 5:
                        try
                        {
                            pcbxTop5.Image = Image.FromFile(path + topSeries[c] + ".png");
                            pcbxTop5.Tag = topSeries[c];
                            pcbxTop5.Cursor = Cursors.Hand;
                            //pcbxTop5.BackColor = Color.Black;
                            pcbxDelete5.Visible = true;
                            pcbxDelete5.Cursor = Cursors.Hand;
                            toolTip1.SetToolTip(pcbxTop5, seriesInfo[topSeries[c] + "-Title"]);
                            toolTip1.SetToolTip(pcbxDelete5, "Remove \"" + seriesInfo[topSeries[c] + "-Title"] + "\" from Favorites");
                        }
                        catch
                        {
                            pcbxTop5.Image = null;
                            pcbxTop5.Tag = "";
                            pcbxTop5.Cursor = Cursors.Default;
                            pcbxTop5.BackColor = Color.Transparent;
                            pcbxDelete5.Visible = false;
                            pcbxDelete5.Cursor = Cursors.Default;
                            toolTip1.SetToolTip(pcbxTop5, "");
                            toolTip1.SetToolTip(pcbxDelete5, "");
                        }
                        break;
                }
                d++;
                c++;
            }
        }

        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1) {
                initialLength = 32768;
            }


            byte[] buffer = new byte[initialLength];
            int read = 0;


            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0) {
                read += chunk;


                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length) {
                    int nextByte = stream.ReadByte();


                    // End of stream? If so, we're done
                    if (nextByte == -1) {
                        return buffer;
                    }


                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Search...") { txtSearch.ForeColor = Color.Black; }
            if (txtSearch.Text.Length > 0) { pcbxSearchDelete.Visible = true; pcbxSearchDelete.BringToFront(); }
            else { pcbxSearchDelete.Visible = false; }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == null)
            {
                txtSearch.ForeColor = SystemColors.InactiveCaption;
                txtSearch.Text = "Search...";
            }
            pcbxSearchDelete.Visible = false;
            AcceptButton = btnAdd;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...") { txtSearch.Text = ""; }
            if (txtSearch.Text.Length > 0) { pcbxSearchDelete.Visible = true; pcbxSearchDelete.BringToFront(); }
            AcceptButton = btnSearch;
        }

        private void pcbxSearchDelete_Click(object sender, EventArgs e)
        {
            if (pcbxSearchDelete.Enabled) { txtSearch.Text = ""; pcbxSearchDelete.Visible = false; }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool update = false;
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
            StreamReader reader = new StreamReader(path + "settings.ini");
            string[] settings = reader.ReadToEnd().Split('\n');
            reader.Close();
            if (accountID == "" || accountID == null || (accountID != settings[0].Trim('\r').Replace("ID:","") && settings[0].Trim('\r').Replace("ID:","") != "Account Identifier...")) { update = true; }
            if (settings[0].Trim('\r').Length > 16 && settings[0].Trim('\r').Length < 32 && settings[0].Trim('\r') != "Account Identifier...") { accountID = settings[0].Trim('\r').Replace("ID:", ""); }
            if (!settings[1].Trim('\r').Contains("API Key...")) { prowl = settings[1].Replace("Prowl:", ""); }
            if (update) { File.Delete(path + "favorites.xml"); forceUpdate(); }
            checkForNotifications();
            this.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSearch.Enabled = false;
            progressSearch.Visible = true;
            lstOverview.SelectedItems.Clear();
            string search = txtSearch.Text.ToLower();
            if (internet)
            {
                WebClient webClient_search = new WebClient();
                webClient_search.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_Search);
                webClient_search.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient_search.DownloadFileAsync(new Uri("http://www.thetvdb.com/api/GetSeries.php?seriesname=" + search), path + @"\search.xml");
            }
            else { MessageBox.Show("Internet Connetion isn't available. You can't search for anything :(", "Miro TV Manager"); }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressSearch.Value = Convert.ToInt16(e.BytesReceived / e.TotalBytesToReceive);
            }
            catch { if (progressSearch.Value < 98) { progressSearch.Increment(1); } }
        }

        private void Completed_Search(object sender, AsyncCompletedEventArgs e)
        {
            //get the search results
            string searchSeriesID = "";
            string banner = "";
            btnSearch.Enabled = true;
            progressSearch.Visible = false;
            XmlTextReader reader = new XmlTextReader(path + "search.xml");
            reader.ReadToFollowing("Series");
            if (reader.NodeType == XmlNodeType.None)
            {
                MessageBox.Show("Search came back empty. Maybe you misspelled the Name of the Series.", "Miro TV Manager");
                reader.Close();
                goto searchEmpty;
            }
            reader.ReadToFollowing("seriesid");
            searchSeriesID = reader.ReadElementContentAsString();
            currentSearchID = searchSeriesID;
            reader.ReadToFollowing("SeriesName");
            txtTitle.Text = reader.ReadElementContentAsString();
            try { seriesInfo.Add(currentSearchID + "-Title", txtTitle.Text); }
            catch { seriesInfo[currentSearchID + "-Title"] = txtTitle.Text; }
            reader.ReadToFollowing("banner");
            if (reader.NodeType != XmlNodeType.None && reader.NodeType != XmlNodeType.Whitespace) { banner = reader.ReadElementContentAsString(); }
            else { banner = "no_banner"; reader.Close(); reader = new XmlTextReader(path + "search.xml"); }
            reader.ReadToFollowing("Overview");
            reader.Close();

            if (!topSeries.Contains(currentSearchID))
            {
                //download banner
                WebClient webClient_results = new WebClient();
                if (banner != "no_banner")
                {
                    webClient_results.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_results.DownloadFileAsync(new Uri("http://thetvdb.com/banners/" + banner), path + searchSeriesID + ".jpg");
                    while (webClient_results.IsBusy) { }
                    using (MagickImage image = new MagickImage(path + searchSeriesID + ".jpg"))
                    {
                        double opacitySetting = Quantum.Max / (Quantum.Max * 0.7);
                        image.Alpha(AlphaOption.Set);
                        image.Evaluate(Channels.Alpha, EvaluateOperator.Min, Quantum.Max / opacitySetting);
                        if (File.Exists(path + searchSeriesID + ".png"))
                        {
                            File.Delete(path + searchSeriesID + ".png");
                        }
                        image.Write(path + searchSeriesID + ".png");
                    }
                    pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".png");
                }
                else { pcbxCurrentSeries.Image = Image.FromFile(path + "no_banner.png"); }

                //download xml
                webClient_results = new WebClient();
                webClient_results.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_Results);
                webClient_results.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient_results.DownloadFileAsync(new Uri("http://thetvdb.com/api/" + API + "/series/" + searchSeriesID + "/all/en.xml"), path + @"\" + searchSeriesID + ".en.xml");
                while (webClient_results.IsBusy) { }
                XmlTextReader r = new XmlTextReader(path + searchSeriesID + ".en.xml");
                r.ReadToFollowing("fanart");
                string fanart = r.ReadElementContentAsString();
                setImageBG(false, searchSeriesID, "http://thetvdb.com/banners/" + fanart);
                setImageBG(true, searchSeriesID);
                r.Close();
            }
            else {
                pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".jpg");
                updateOverview();
                while (pcbxUp.Enabled) { pcbxUp_Click(sender, e); }
                while (pcbxDown.Enabled && pcbxTop1.Tag.ToString() != currentSearchID && pcbxTop2.Tag.ToString() != currentSearchID && pcbxTop3.Tag.ToString() != currentSearchID && pcbxTop4.Tag.ToString() != currentSearchID && pcbxTop5.Tag.ToString() != currentSearchID)
                {
                    pcbxDown_Click(sender, e);
                }
            }

        searchEmpty: ;
        }

        private void Completed_Results(object sender, AsyncCompletedEventArgs e)
        {
            updateOverview();
        }

        public void updateOverview()
        {
            lstOverview.Items.Clear();
            lstOverview.Groups.Clear();
            XmlTextReader reader = new XmlTextReader(path + currentSearchID + ".en.xml");
            //yay using the same method :/
            reader.ReadToFollowing("Actors");
            txtActors.Text = reader.ReadElementContentAsString();
            txtActors.Text = txtActors.Text.Trim('|');
            while (txtActors.Text.Contains('|')) { txtActors.Text = txtActors.Text.Replace("|", ", "); }
            reader.ReadToFollowing("Airs_DayOfWeek");
            txtAirsOn.Text = reader.ReadElementContentAsString();
            reader.ReadToFollowing("Airs_Time");
            txtAirsAt.Text = reader.ReadElementContentAsString();
            reader.ReadToFollowing("Genre");
            txtGenre.Text = reader.ReadElementContentAsString();
            txtGenre.Text = txtGenre.Text.Trim('|');
            while (txtGenre.Text.Contains('|'))
            {
                txtGenre.Text = txtGenre.Text.Replace("|", ", ");
            }
            reader.ReadToFollowing("Overview");
            txtSeriesDescription.Text = reader.ReadElementContentAsString();
            reader.ReadToFollowing("Rating");
            txtRating.Text = reader.ReadElementContentAsString();
            reader.ReadToFollowing("RatingCount");
            txtRating.Text += " (" + reader.ReadElementContentAsInt() + " votes)";
            reader.ReadToFollowing("Runtime");
            if (reader.NodeType != XmlNodeType.None)
            {
                try { seriesInfo.Add(currentSearchID + "-Runtime", reader.ReadElementContentAsString()); }
                catch { }
            }
            reader.ReadToFollowing("Status");
            if (reader.ReadElementContentAsString() == "Ended") { MessageBox.Show("This series has ended"); currentEnded = true; }
            reader.ReadToFollowing("fanart");
            setImageBG(true, currentSearchID);

            //Counting number of seasons and episodes
            reader.ReadToFollowing("Combined_season");
            int seasons = 0, episodes = 0;
            while (reader.NodeType != XmlNodeType.None && reader.NodeType != XmlNodeType.Whitespace)
            {
                seasons = reader.ReadElementContentAsInt();
                while (seasons == 0)
                {
                    reader.ReadToFollowing("Combined_season");
                    seasons = reader.ReadElementContentAsInt();
                }
                reader.ReadToFollowing("absolute_number");
                episodes++;
                reader.ReadToFollowing("Combined_season");
            }
            txtSeasons.Text = seasons.ToString();
            txtEpisodes.Text = episodes.ToString();
            reader.Close();
            reader = new XmlTextReader(path + currentSearchID + ".en.xml");

            //Populating lstOverview
            ListViewGroup[] groupArray = new ListViewGroup[Convert.ToInt16(txtSeasons.Text)];
            int c = 0;
            while (c < Convert.ToInt16(txtSeasons.Text))
            {
                groupArray[c] = new ListViewGroup("Season " + (c + 1), System.Windows.Forms.HorizontalAlignment.Left);
                c++;
            }
            c = 1;
            lstOverview.Groups.AddRange(groupArray);
            while (c <= Convert.ToInt16(txtEpisodes.Text))
            {
                reader.ReadToFollowing("Combined_season");
                while (reader.NodeType != XmlNodeType.None && reader.NodeType != XmlNodeType.Whitespace)
                {
                    seasons = reader.ReadElementContentAsInt();
                    while(seasons == 0)
                    {
                        reader.ReadToFollowing("Combined_season");
                        seasons = reader.ReadElementContentAsInt();
                    }
                }
        restartSeason: ;
                string epnumber = "";
                string[] eps = { "", "", "", "", "" };
                reader.ReadToFollowing("EpisodeName");
                if (reader.NodeType == XmlNodeType.None || reader.NodeType == XmlNodeType.Whitespace) { goto end; }
                eps[0] = reader.ReadElementContentAsString();
                reader.ReadToFollowing("EpisodeNumber");
                epnumber = reader.ReadElementContentAsString();
                if (epnumber == "0") { /*False episode. Go back*/ episodes--; goto restartSeason; }
                reader.ReadToFollowing("FirstAired");
                eps[2] = reader.ReadElementContentAsString();
                reader.ReadToFollowing("Overview");
                try { seriesInfo.Add(currentSearchID + "-s" + seasons.ToString() + "e" + epnumber, reader.ReadElementContentAsString()); }
                catch { }
                if (eps[2] != "")
                {
                    if (DateTime.Compare(DateTime.Parse(eps[2]), DateTime.Today) == -1)
                    {
                        eps[3] = checkmark;
                    }
                    if (eps[3] == checkmark)
                    {
                        reader.ReadToFollowing("Rating");
                        eps[1] = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("RatingCount");
                        eps[1] += " (" + reader.ReadElementContentAsString() + " votes)";
                    }
                    if (eps[3] != checkmark)
                    {
                        try
                        {
                            try { seriesInfo.Add(currentSearchID + "-NextAir", DateTime.Parse(eps[2] + " " + txtAirsAt.Text).ToString()); }
                            catch { }
                            seriesInfo.Add(currentSearchID + "-NextAirSE", seasons + "x" + epnumber);
                            seriesInfo.Add(currentSearchID + "-NextAirEpisode", eps[0]);
                        }
                        catch { }
                    }
                    reader.ReadToFollowing("Episode");
                }
                else
                {
                    try
                        {
                            try { seriesInfo.Add(currentSearchID + "-NextAir", DateTime.Today.AddMonths(-1).ToString()); }
                            catch { }
                            seriesInfo.Add(currentSearchID + "-NextAirSE", seasons + "x" + epnumber);
                            seriesInfo.Add(currentSearchID + "-NextAirEpisode", eps[0]);
                        }
                    catch { }
                }
            end: ;
                

                //adding to lstOverview
                lstOverview.Items.Add(Convert.ToString(epnumber)).SubItems.AddRange(eps);
                lstOverview.Items[c-1].Group = groupArray[seasons-1];

                c++;
                Array.Clear(eps,0,eps.Count());
            }
            reader.Close();
            btnAdd.Enabled = true;

            //notification balloon time!
            if (!currentEnded && (DateTime.Compare(DateTime.Parse(seriesInfo[currentSearchID + "-NextAir"]),DateTime.Now)) != -1)
            {
                try
                {
                    ntfy.BalloonTipIcon = ToolTipIcon.Info;
                    string[] temp = seriesInfo[currentSearchID + "-NextAirSE"].Split('x');
                    if (Convert.ToInt16(temp[0]) < 10) { temp[0] = "0" + temp[0]; }
                    if (Convert.ToInt16(temp[1]) < 10) { temp[1] = "0" + temp[1]; }
                    ntfy.BalloonTipTitle = txtTitle.Text + " S" + temp[0] + "E" + temp[1] + " \"" + seriesInfo[currentSearchID + "-NextAirEpisode"] + "\"";
                    Array.Clear(temp, 0, temp.Count());
                    temp = seriesInfo[currentSearchID + "-NextAir"].Split(' ');
                    ntfy.BalloonTipText = "Airs on: " + DateTime.Parse(temp[0]).ToLongDateString() + "\r\nAirs at: " + (temp[1] + " " + temp[2]).Replace(":00 ", " ");
                    ntfy.ShowBalloonTip(200);
                }
                catch { }
            }

            //check if current series is in favorites, if so, disable "Add to Favorites"
            if (topSeries.Contains(currentSearchID)) { btnAdd.Enabled = false; } else { btnAdd.Enabled = true; }
            if (currentEnded) { lblEnded.Text = "This series has ended."; lblEnded.ForeColor = Color.Red; currentEnded = false; } else { lblEnded.Text = ""; }
            
        }

        private void lstOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOverview.FocusedItem != null && lstOverview.FocusedItem.Index != currentSelected && lstOverview.FocusedItem.Text != "")
            {
                try
                {
                    currentSelected = lstOverview.FocusedItem.Index;
                    //now, lets find the item selected
                    string season = lstOverview.SelectedItems[0].Group.ToString().Replace("Season ", "");
                    string episode = lstOverview.SelectedItems[0].Text;
                    rchEpisodeDescription.Visible = true;
                    rchEpisodeDescription.Text = "";
                    rchEpisodeDescription.Text = txtTitle.Text + " S";
                    if (Convert.ToInt16(season) < 10) { rchEpisodeDescription.Text += "0"; }
                    rchEpisodeDescription.Text += season + "E";
                    if (Convert.ToInt16(episode) < 10) { rchEpisodeDescription.Text += "0"; }
                    rchEpisodeDescription.Text += episode + " \"" + lstOverview.SelectedItems[0].SubItems[1].Text + "\": " + seriesInfo[currentSearchID + "-s" + season + "e" + episode];
                    rchEpisodeDescription.SelectionLength = (rchEpisodeDescription.Text.IndexOf(":", txtTitle.TextLength) + 1);
                    rchEpisodeDescription.SelectionColor = Color.Red;
                    rchEpisodeDescription.SelectionFont = new System.Drawing.Font(rchEpisodeDescription.SelectionFont, rchEpisodeDescription.SelectionFont.Style ^ FontStyle.Bold);
                }
                catch { currentSelected = lstOverview.FocusedItem.Index; }
            }
        }

        private void pcbxUp_MouseHover(object sender, EventArgs e)
        {
            pcbxUp.Image = Miro_TV_Manager.Properties.Resources.arrow_up_green;
        }

        private void pcbxUp_MouseLeave(object sender, EventArgs e)
        {
            pcbxUp.Image = Miro_TV_Manager.Properties.Resources.arrow_up;
        }

        private void pcbxDown_MouseHover(object sender, EventArgs e)
        {
            pcbxDown.Image = Miro_TV_Manager.Properties.Resources.arrow_down_green;
        }

        private void pcbxDown_MouseLeave(object sender, EventArgs e)
        {
            pcbxDown.Image = Miro_TV_Manager.Properties.Resources.arrow_down;
        }

        private void pcbxUp_Click(object sender, EventArgs e)
        {
            if (pcbxUp.Enabled)
            {
                //remove images from memory
                if (pcbxTop1.Image != null) pcbxTop1.Image.Dispose();
                if (pcbxTop2.Image != null) pcbxTop2.Image.Dispose();
                if (pcbxTop3.Image != null) pcbxTop3.Image.Dispose();
                if (pcbxTop4.Image != null) pcbxTop4.Image.Dispose();
                if (pcbxTop5.Image != null) pcbxTop5.Image.Dispose();
                //go up (back)
                if (lastFavorites)
                {
                    lastFavorites = false;
                    int c = topSeries.Count;
                    int a = 0;
                    while (c > 5)
                    {
                        c = c - 5;
                        a++;
                    }
                    currentTopImages = (a * 5);
                }
                else
                {
                    currentTopImages = currentTopImages - 5;
                }
                updateTopSeriesImages();
            }
            if (topSeries.Count > 5 && (currentTopImages - 5) < topSeries.Count) { pcbxDown.Enabled = true; }
        }

        private void pcbxDown_Click(object sender, EventArgs e)
        {
            if (pcbxDown.Enabled)
            {
                //remove images from memory
                if (pcbxTop1.Image != null) pcbxTop1.Image.Dispose();
                if (pcbxTop2.Image != null) pcbxTop2.Image.Dispose();
                if (pcbxTop3.Image != null) pcbxTop3.Image.Dispose();
                if (pcbxTop4.Image != null) pcbxTop4.Image.Dispose();
                if (pcbxTop5.Image != null) pcbxTop5.Image.Dispose();
                //go down (forward)
                if ((currentTopImages + 5) <= topSeries.Count)
                {
                    currentTopImages = currentTopImages + 5;
                }
                else
                {
                    currentTopImages = topSeries.Count;
                    lastFavorites = true;
                }
                updateTopSeriesImages();
            }
            if (topSeries.Count > 5 && (currentTopImages) < topSeries.Count) { pcbxUp.Enabled = true; }
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (press == 0)
            {
                if (e.KeyCode == Keys.Down && !lstOverview.Focused) { pcbxDown_Click(sender, e); }
                if (e.KeyCode == Keys.Up && !lstOverview.Focused) { pcbxUp_Click(sender, e); }
                press = 1;
            }
            else { press = 0; }
        }

        private void forceUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                pcbxDelete1.Visible = false;
                pcbxDelete1.Cursor = Cursors.Default;
                pcbxDelete2.Visible = false;
                pcbxDelete2.Cursor = Cursors.Default;
                pcbxDelete3.Visible = false;
                pcbxDelete3.Cursor = Cursors.Default;
                pcbxDelete4.Visible = false;
                pcbxDelete4.Cursor = Cursors.Default;
                pcbxDelete5.Visible = false;
                pcbxDelete5.Cursor = Cursors.Default;
                try { pcbxTop1.Image.Dispose(); }
                catch { }
                try { pcbxTop2.Image.Dispose(); }
                catch { }
                try { pcbxTop3.Image.Dispose(); }
                catch { }
                try { pcbxTop4.Image.Dispose(); }
                catch { }
                try { pcbxTop5.Image.Dispose(); }
                catch { }
                try { pcbxCurrentSeries.Image.Dispose(); }
                catch { }
                try { this.BackgroundImage.Dispose(); }
                catch { }
                pcbxCurrentSeries.Image = null;
                this.BackgroundImage = null;
                this.BackgroundImage = Miro_TV_Manager.Properties.Resources._114851;
                pcbxTop1.Image = null;
                pcbxTop2.Image = null;
                pcbxTop3.Image = null;
                pcbxTop4.Image = null;
                pcbxTop5.Image = null;
                pcbxTop1.BackColor = Color.Transparent;
                pcbxTop2.BackColor = Color.Transparent;
                pcbxTop3.BackColor = Color.Transparent;
                pcbxTop4.BackColor = Color.Transparent;
                pcbxTop5.BackColor = Color.Transparent;
                pcbxUp.Visible = false;
                pcbxUp.Cursor = Cursors.Default;
                pcbxUp.Enabled = false;
                pcbxDown.Visible = false;
                pcbxDown.Cursor = Cursors.Default;
                pcbxDown.Enabled = false;
                txtActors.Text = "";
                txtAirsAt.Text = "";
                txtAirsOn.Text = "";
                txtEpisodes.Text = "";
                txtGenre.Text = "";
                txtRating.Text = "";
                txtSeasons.Text = "";
                txtSeriesDescription.Text = "";
                txtTitle.Text = "";
                lblNextShow.Text = "Next Show:";
                rchEpisodeDescription.Text = "";
                lstOverview.Items.Clear();
                lstOverview.Groups.Clear();
                topSeries.Clear();
                seriesInfo.Clear();
                string[] list = Directory.GetFiles(path);
                int c = 0;
                while (c < list.Count())
                {
                    if (!list[c].Contains("settings"))
                    {
                        File.Delete(list[c]);
                    }
                    c++;
                }
                this.Hide();
                forceUpdate();
                updateTopSeriesImages();
                this.Show();
            }
            else { MessageBox.Show("There is no Internet connection. There is no point in doing a Force Update. Please Connect to the Internet to get the latest updates. Thanks.", "Miro TV Manager"); }
        }

        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clearing all boxes, and such
            pcbxDelete1.Visible = false;
            pcbxDelete1.Cursor = Cursors.Default;
            pcbxDelete2.Visible = false;
            pcbxDelete2.Cursor = Cursors.Default;
            pcbxDelete3.Visible = false;
            pcbxDelete3.Cursor = Cursors.Default;
            pcbxDelete4.Visible = false;
            pcbxDelete4.Cursor = Cursors.Default;
            pcbxDelete5.Visible = false;
            pcbxDelete5.Cursor = Cursors.Default;
            pcbxTop1.Image.Dispose();
            pcbxTop2.Image.Dispose();
            pcbxTop3.Image.Dispose();
            pcbxTop4.Image.Dispose();
            pcbxTop5.Image.Dispose();
            try { pcbxCurrentSeries.Image.Dispose(); }
            catch { }
            pcbxCurrentSeries.Image = null;
            pcbxTop1.Image = null;
            pcbxTop2.Image = null;
            pcbxTop3.Image = null;
            pcbxTop4.Image = null;
            pcbxTop5.Image = null;
            pcbxTop1.BackColor = Color.Transparent;
            pcbxTop2.BackColor = Color.Transparent;
            pcbxTop3.BackColor = Color.Transparent;
            pcbxTop4.BackColor = Color.Transparent;
            pcbxTop5.BackColor = Color.Transparent;
            pcbxUp.Visible = false;
            pcbxUp.Cursor = Cursors.Default;
            pcbxUp.Enabled = false;
            pcbxDown.Visible = false;
            pcbxDown.Cursor = Cursors.Default;
            pcbxDown.Enabled = false;
            txtActors.Text = "";
            txtAirsAt.Text = "";
            txtAirsOn.Text = "";
            txtEpisodes.Text = "";
            txtGenre.Text = "";
            txtRating.Text = "";
            txtSeasons.Text = "";
            txtSeriesDescription.Text = "";
            txtTitle.Text = "";
            lblNextShow.Text = "Next Show:";
            rchEpisodeDescription.Text = "";
            lstOverview.Items.Clear();
            lstOverview.Groups.Clear();
            topSeries.Clear();
            seriesInfo.Clear();
            string[] list = Directory.GetFiles(path);
            int c = 0;
            while (c < list.Count())
            {
                if (!list[c].Contains("settings"))
                {
                    File.Delete(list[c]);
                }
                c++;
            }
        }

        private void pcbxTop1_Click(object sender, EventArgs e)
        {
            //here we go...clicking involved lol
            if (pcbxTop1.Image != null)
            {
                //find image name
                string top1 = pcbxTop1.Tag.ToString();
                currentSearchID = top1;
                pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".png");
                txtTitle.Text = seriesInfo[currentSearchID + "-Title"];
                setImageBG(true, currentSearchID);
                updateOverview();
                //!!!IN THE MORNING
                //create method, that will create semi-transparent images of banners and fanart
                //run at startup
                //try to make textboxes semi-transparent
                //hope this looks cool :D
            }
        }

        private void pcbxTop2_Click(object sender, EventArgs e)
        {
            if (pcbxTop2.Image != null)
            {
                //find image name
                string top2 = pcbxTop2.Tag.ToString();
                currentSearchID = top2;
                pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".png");
                txtTitle.Text = seriesInfo[currentSearchID + "-Title"];
                setImageBG(true, currentSearchID);
                updateOverview();
            }
        }

        private void pcbxTop3_Click(object sender, EventArgs e)
        {
            if (pcbxTop3.Image != null)
            {
                //find image name
                string top3 = pcbxTop3.Tag.ToString();
                currentSearchID = top3;
                pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".png");
                txtTitle.Text = seriesInfo[currentSearchID + "-Title"];
                setImageBG(true, currentSearchID);
                updateOverview();
            }
        }

        private void pcbxTop4_Click(object sender, EventArgs e)
        {
            if (pcbxTop4.Image != null)
            {
                //find image name
                string top4 = pcbxTop4.Tag.ToString();
                currentSearchID = top4;
                pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".png");
                txtTitle.Text = seriesInfo[currentSearchID + "-Title"];
                setImageBG(true, currentSearchID);
                updateOverview();
            }
        }

        private void pcbxTop5_Click(object sender, EventArgs e)
        {
            if (pcbxTop5.Image != null)
            {
                //find image name
                string top5 = pcbxTop5.Tag.ToString();
                currentSearchID = top5;
                pcbxCurrentSeries.Image = Image.FromFile(path + currentSearchID + ".png");
                txtTitle.Text = seriesInfo[currentSearchID + "-Title"];
                setImageBG(true, currentSearchID);
                updateOverview();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ntfy.Dispose();
            //will work on this later
        }

        private void exiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("changelog.txt");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string series = currentSearchID;
            //why so sssserious?
            DialogResult result;
            if (lblEnded.Text != "") { result = MessageBox.Show("Even though this series has ended, are you sure you want to add \"" + txtTitle.Text + "\" to your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation); }
            else { result = MessageBox.Show("Are you sure you want to add \"" + txtTitle.Text + "\" to your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation); }
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //yes, add favorites and redownload
                topSeries.Add(series);
                try { settingsAlertAfter.Add(series, "0"); }
                catch { settingsAlertAfter[series] = "0"; }
                try { settingsAlertBefore.Add(series, "0"); }
                catch { settingsAlertBefore[series] = "0"; }
                File.Delete(path + "favorites.xml");
                if (accountID != "" && accountID != null)
                {
                    WebClient webClient_fetch = new WebClient();
                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=add&seriesid=" + series), path + "favorites.xml");
                    while (webClient_fetch.IsBusy) { }
                }
                else
                {
                    if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                    XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");
                    int c = 0;
                    while (c<topSeries.Count)
                    {
                        writer.WriteStartElement("Series");
                        writer.WriteString(topSeries[c].ToString());
                        writer.WriteEndElement();
                        c++;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                currentTopImages = 5;
                lastFavorites = false;
                pcbxDown.Enabled = true;
                updateTopSeriesImages();
                while (pcbxUp.Enabled) { pcbxUp_Click(sender, e); }
                while (pcbxDown.Enabled && pcbxTop1.Tag.ToString() != currentSearchID && pcbxTop2.Tag.ToString() != currentSearchID && pcbxTop3.Tag.ToString() != currentSearchID && pcbxTop4.Tag.ToString() != currentSearchID && pcbxTop5.Tag.ToString() != currentSearchID)
                {
                    pcbxDown_Click(sender, e);
                }
                saveSettings();
            }
        }

        private void pcbxDelete1_Click(object sender, EventArgs e)
        {
            //okay, removing a series from favorites
            string series = pcbxTop1.Tag.ToString();
            //why so sssserious?
            DialogResult result = MessageBox.Show("Are you sure you want to remove\"" + seriesInfo[series + "-Title"] + "\" from your favorites?","Miro TV Manager",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //yes, remove favorites and redownload
                topSeries.Remove(series);
                File.Delete(path + "favorites.xml");
                if (accountID != "" && accountID != null)
                {
                    WebClient webClient_fetch = new WebClient();
                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=remove&seriesid=" + series), path + "favorites.xml");
                    while (webClient_fetch.IsBusy) { }
                }
                else
                {
                    if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                    XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");
                    int c = 0;
                    while (c<topSeries.Count)
                    {
                        writer.WriteStartElement("Series");
                        writer.WriteString(topSeries[c].ToString());
                        writer.WriteEndElement();
                        c++;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                currentTopImages = 5;
                updateTopSeriesImages();
                saveSettings();
            }
        }

        private void pcbxDelete2_Click(object sender, EventArgs e)
        {
            string series = pcbxTop2.Tag.ToString();
            //why so sssserious?
            DialogResult result = MessageBox.Show("Are you sure you want to remove\"" + seriesInfo[series + "-Title"] + "\" from your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //yes, remove favorites and redownload
                topSeries.Remove(series);
                File.Delete(path + "favorites.xml");
                if (accountID != "" && accountID != null)
                {
                    WebClient webClient_fetch = new WebClient();
                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=remove&seriesid=" + series), path + "favorites.xml");
                    while (webClient_fetch.IsBusy) { }
                }
                else
                {
                    if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                    XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");
                    int c = 0;
                    while (c < topSeries.Count)
                    {
                        writer.WriteStartElement("Series");
                        writer.WriteString(topSeries[c].ToString());
                        writer.WriteEndElement();
                        c++;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                currentTopImages = 5;
                updateTopSeriesImages();
                saveSettings();
            }
        }

        private void pcbxDelete3_Click(object sender, EventArgs e)
        {
            string series = pcbxTop3.Tag.ToString();
            //why so sssserious?
            DialogResult result = MessageBox.Show("Are you sure you want to remove\"" + seriesInfo[series + "-Title"] + "\" from your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //yes, remove favorites and redownload
                topSeries.Remove(series);
                File.Delete(path + "favorites.xml");
                if (accountID != "" && accountID != null)
                {
                    WebClient webClient_fetch = new WebClient();
                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=remove&seriesid=" + series), path + "favorites.xml");
                    while (webClient_fetch.IsBusy) { }
                }
                else
                {
                    if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                    XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");
                    int c = 0;
                    while (c < topSeries.Count)
                    {
                        writer.WriteStartElement("Series");
                        writer.WriteString(topSeries[c].ToString());
                        writer.WriteEndElement();
                        c++;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                currentTopImages = 5;
                updateTopSeriesImages();
                saveSettings();
            }
        }

        private void pcbxDelete4_Click(object sender, EventArgs e)
        {
            string series = pcbxTop4.Tag.ToString();
            //why so sssserious?
            DialogResult result = MessageBox.Show("Are you sure you want to remove\"" + seriesInfo[series + "-Title"] + "\" from your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //yes, remove favorites and redownload
                topSeries.Remove(series);
                File.Delete(path + "favorites.xml");
                if (accountID != "" && accountID != null)
                {
                    WebClient webClient_fetch = new WebClient();
                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=remove&seriesid=" + series), path + "favorites.xml");
                    while (webClient_fetch.IsBusy) { }
                }
                else
                {
                    if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                    XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");
                    int c = 0;
                    while (c < topSeries.Count)
                    {
                        writer.WriteStartElement("Series");
                        writer.WriteString(topSeries[c].ToString());
                        writer.WriteEndElement();
                        c++;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                currentTopImages = 5;
                updateTopSeriesImages();
                saveSettings();
            }
        }

        private void pcbxDelete5_Click(object sender, EventArgs e)
        {
            string series = pcbxTop5.Tag.ToString();
            //why so sssserious?
            DialogResult result = MessageBox.Show("Are you sure you want to remove\"" + seriesInfo[series + "-Title"] + "\" from your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //yes, remove favorites and redownload
                topSeries.Remove(series);
                File.Delete(path + "favorites.xml");
                if (accountID != "" && accountID != null)
                {
                    WebClient webClient_fetch = new WebClient();
                    webClient_fetch.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient_fetch.DownloadFileAsync(new Uri("http://thetvdb.com/api/User_Favorites.php?accountid=" + accountID + "&type=remove&seriesid=" + series), path + "favorites.xml");
                    while (webClient_fetch.IsBusy) { }
                }
                else
                {
                    if (!warned) { MessageBox.Show("It seems you didn't specify your TheTVDB.com account ID. Although its not necessary, it is highly recommended, as it will make keeping track of your favorite shows much easier. Please follow the link in Settings to get an account/retrieve your ID. Thanks."); warned = true; }
                    XmlTextWriter writer = new XmlTextWriter(path + "favorites.xml", null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");
                    int c = 0;
                    while (c < topSeries.Count)
                    {
                        writer.WriteStartElement("Series");
                        writer.WriteString(topSeries[c].ToString());
                        writer.WriteEndElement();
                        c++;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                currentTopImages = 5;
                updateTopSeriesImages();
                saveSettings();
            }
        }

        private void saveSettings()
        {
            StreamWriter writer = new StreamWriter(path + "settings.ini");
            int c = 0;
            try
            {
                writer.WriteLine("ID:" + accountID);
                writer.WriteLine("Prowl:" + prowl);
                if (File.Exists(path + "favorites.xml")) { writer.WriteLine("[Favorites]"); }
                while (c < topSeries.Count)
                {
                    writer.Write(topSeries[c] + "*");
                    writer.Write(settingsAlertBefore[topSeries[c].ToString()] + "*");
                    writer.Write(settingsAlertAfter[topSeries[c].ToString()] + "*");
                    try { writer.Write(seriesInfo[topSeries[c] + "-NextAir"] + "*"); }
                    catch { writer.Write(DateTime.Today.AddMonths(-1).ToString() + "*"); }
                    writer.Write(seriesInfo[topSeries[c] + "-Title"] + "*");
                    writer.Write(seriesInfo[topSeries[c] + "-NextAirSE"] + "*" + seriesInfo[topSeries[c] + "-NextAirEpisode"]);
                    writer.Write("\r\n");
                    c++;
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                writer.Close();
                writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log.miro");
                foreach (var entry in seriesInfo)
                    writer.WriteLine("[{0} {1}]", entry.Key, entry.Value);
                writer.WriteLine("Error with series: " + topSeries[c].ToString());
                writer.Write(ex.ToString());
                writer.Close();
                MessageBox.Show("Something went wrong. Please email the miro@miroppb.com the file \"log.miro\" that is located on your desktop, and restart this application. Thanks."); File.Delete(path + "settings.ini");
                StreamWriter w = new StreamWriter(path + "settings.ini");
                w.WriteLine("ID:" + accountID);
                w.WriteLine("Prowl:" + prowl);
                w.Close();
                Application.Exit();
            }
        }

        private void checkForNotifications()
        {
            int c = 0;
            bool notify = false;
            while (c < topSeries.Count)
            {
                try { if (seriesInfo[topSeries[c] + "-Before"] != "0") { notify = true; break; } }
                catch { seriesInfo.Add(topSeries[c] + "-Before", "0"); }
                try { if (seriesInfo[topSeries[c] + "-After"] != "0") { notify = true; break; } }
                catch { seriesInfo.Add(topSeries[c] + "-After","0"); }
                c++;
            }
            if (notify) { timerNotify.Enabled = true; timerNotify.Start(); }
            else { timerNotify.Enabled = false; timerNotify.Stop(); }
        }

        private void timerNotify_Tick(object sender, EventArgs e)
        {
            int c = 0;
            while (c < topSeries.Count)
            {
                //notify Before
                if (seriesInfo[topSeries[c]+"-Before"] != "0")
                {
                    if (!seriesInfo.ContainsKey(topSeries[c] + "-NextAir")) { }
                    else if (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() == DateTime.Parse(seriesInfo[topSeries[c] + "-NextAir"]).AddMinutes(0 - (Convert.ToInt16(seriesInfo[topSeries[c] + "-Before"]))).ToShortDateString() + " " + DateTime.Parse(seriesInfo[topSeries[c] + "-NextAir"]).AddMinutes(0 - (Convert.ToInt16(seriesInfo[topSeries[c] + "-Before"]))).ToShortTimeString())
                    {
                        try
                        {
                            ntfy.BalloonTipIcon = ToolTipIcon.Info;
                            string[] temp = seriesInfo[topSeries[c] + "-NextAirSE"].Split('x');
                            if (Convert.ToInt16(temp[0]) < 10) { temp[0] = "0" + temp[0]; }
                            if (Convert.ToInt16(temp[1]) < 10) { temp[1] = "0" + temp[1]; }
                            ntfy.BalloonTipTitle = seriesInfo[topSeries[c] +"-Title"] + " S" + temp[0] + "E" + temp[1] + " \"" + seriesInfo[topSeries[c] + "-NextAirEpisode"] + "\"";
                            ntfy.BalloonTipText = "Airs in: " + seriesInfo[topSeries[c] +"-Before"] + " minutes";
                            ntfy.ShowBalloonTip(200);
                            if (prowl != "")
                            {
                                Process pro = new Process();
                                pro.StartInfo.FileName = Application.StartupPath + @"\curl.exe";
                                pro.StartInfo.UseShellExecute = false;
                                pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                pro.StartInfo.Arguments = "--data \"apikey=" + prowl + "&application=" + seriesInfo[topSeries[c] + "-Title"] + "&event= S" + temp[0] + "E" + temp[1] + "<" + seriesInfo[topSeries[c] + "-NextAirEpisode"] + ">&description=" + "Airs in: " + seriesInfo[topSeries[c] + "-Before"] + " minutes\" http://api.prowlapp.com/publicapi/add";
                                pro.StartInfo.RedirectStandardOutput = true;
                                pro.Start();
                            }
                        }
                        catch { }
                    }
                }
                //notify After
                if (seriesInfo[topSeries[c] + "-After"] != "0")
                {
                    //MessageBox.Show(topSeries[c] + " " + DateTime.Parse(seriesInfo[topSeries[c] + "-NextAir"]).ToShortDateString() + " " + DateTime.Parse(seriesInfo[topSeries[c] + "-NextAir"]).AddMinutes(Convert.ToInt16(seriesInfo[topSeries[c] + "-Runtime"])).ToShortTimeString());
                    if (!seriesInfo.ContainsKey(topSeries[c] + "-NextAir")) { }
                    else if (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() == DateTime.Parse(seriesInfo[topSeries[c] + "-NextAir"]).ToShortDateString() + " " + DateTime.Parse(seriesInfo[topSeries[c] + "-NextAir"]).AddMinutes(Convert.ToInt16(seriesInfo[topSeries[c]+"-Runtime"])).ToShortTimeString())
                    {
                        try
                        {
                            ntfy.BalloonTipIcon = ToolTipIcon.Info;
                            string[] temp = seriesInfo[topSeries[c] + "-NextAirSE"].Split('x');
                            if (Convert.ToInt16(temp[0]) < 10) { temp[0] = "0" + temp[0]; }
                            if (Convert.ToInt16(temp[1]) < 10) { temp[1] = "0" + temp[1]; }
                            ntfy.BalloonTipTitle = seriesInfo[topSeries[c] + "-Title"] + " S" + temp[0] + "E" + temp[1] + "\"" + seriesInfo[topSeries[c] + "-NextAirEpisode"] + "\"";
                            ntfy.BalloonTipText = "Has finished airing :)";
                            ntfy.ShowBalloonTip(200);
                            if (prowl != "")
                            {
                                Process pro = new Process();
                                pro.StartInfo.FileName = Application.StartupPath + @"\curl.exe";
                                pro.StartInfo.UseShellExecute = false;
                                pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                pro.StartInfo.Arguments = "--data \"apikey=" + prowl + "&application=" + seriesInfo[topSeries[c] + "-Title"] + "&event= S" + temp[0] + "E" + temp[1] + " ::" + seriesInfo[topSeries[c] + "-NextAirEpisode"] + "::&description=" + "Has finished airing :)\" http://api.prowlapp.com/publicapi/add";
                                pro.StartInfo.RedirectStandardOutput = true;
                                pro.Start();
                            }
                        }
                        catch {  }
                    }
                }
                c++;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 6 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
            {
                seriesInfo.Clear();
                topSeries.Clear();
                forceUpdate();
                this.Show();
            }
        }

        private void timerNextShow_Tick(object sender, EventArgs e)
        {
            updateNextShow();
        }

        private void updateNextShow()
        {
            //figuring out next airing show
            if (topSeries.Count != 0)
            {
                int a = 0;
                try
                {
                    while (DateTime.Compare(DateTime.Now, DateTime.Parse(seriesInfo[topSeries[a] + "-NextAir"])) == 1)
                    {
                        a++;
                    }
                }
                catch { a++; }
                string[] temp = seriesInfo[topSeries[a] + "-NextAirSE"].Split('x');
                if (Convert.ToInt16(temp[0]) < 10) { temp[0] = "0" + temp[0]; }
                if (Convert.ToInt16(temp[1]) < 10) { temp[1] = "0" + temp[1]; }
                lblNextShow.Text = "Next Show: " + seriesInfo[topSeries[a] + "-Title"] + " S" + temp[0] + "E" + temp[1] + " \"" + seriesInfo[topSeries[a] + "-NextAirEpisode"] + "\" at: " + DateTime.Parse(seriesInfo[topSeries[a] + "-NextAir"]).ToShortDateString() + " " + DateTime.Parse(seriesInfo[topSeries[a] + "-NextAir"]).ToShortTimeString();
                lblNextShow.Tag = topSeries[a] + " " + seriesInfo[topSeries[a] + "-NextAirSE"];
                currentNextShow = topSeries[a].ToString();
                Array.Clear(temp, 0, 2);
                int b = a;
                while (b < topSeries.Count)
                {
                    try
                    {
                        if ((DateTime.Parse(seriesInfo[topSeries[b] + "-NextAir"]) - DateTime.Now).TotalHours < (DateTime.Parse(seriesInfo[topSeries[a] + "-NextAir"]) - DateTime.Now).TotalHours && DateTime.Compare(DateTime.Now, DateTime.Parse(seriesInfo[topSeries[b] + "-NextAir"])) == -1)
                        {
                            a = b;
                            temp = seriesInfo[topSeries[a] + "-NextAirSE"].Split('x');
                            if (Convert.ToInt16(temp[0]) < 10) { temp[0] = "0" + temp[0]; }
                            if (Convert.ToInt16(temp[1]) < 10) { temp[1] = "0" + temp[1]; }
                            lblNextShow.Text = "Next Show: " + seriesInfo[topSeries[b] + "-Title"] + " S" + temp[0] + "E" + temp[1] + " \"" + seriesInfo[topSeries[b] + "-NextAirEpisode"] + "\" at: " + DateTime.Parse(seriesInfo[topSeries[b] + "-NextAir"]).ToShortDateString() + " " + DateTime.Parse(seriesInfo[topSeries[b] + "-NextAir"]).ToShortTimeString();
                            lblNextShow.Tag = topSeries[a] + " " + seriesInfo[topSeries[a] + "-NextAirSE"];
                            currentNextShow = topSeries[a].ToString();
                        }
                    }
                    catch { }
                    b++;
                }
            }
        }

        private void lblNextShow_Click(object sender, EventArgs e)
        {
            string[] temp = lblNextShow.Tag.ToString().Split(' ');
            string[] temp2 = temp[1].Split('x');
            txtSearch.Text = seriesInfo[temp[0] + "-Title"];
            pcbxCurrentSeries.Image = Image.FromFile(path + currentNextShow + ".png");
            txtTitle.Text = txtSearch.Text;
            currentSearchID = currentNextShow;
            updateOverview();
            ListViewItem item = new ListViewItem();
            item = lstOverview.Groups[Convert.ToInt16(temp2[0]) - 1].Items[Convert.ToInt16(temp2[1]) - 1];
            lstOverview.EnsureVisible(item.Index);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            updateNextShow();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += currentDomain_UnhandledException;
            //Application.ThreadException += Application_ThreadException;
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Thread Exception. Restarting...");
            StreamWriter w = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log.miro");
            w.WriteLine(e.ToString());
            w.Close();
            Application.Restart();
        }

        void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled Exception. Restarting...");
            StreamWriter w = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log.miro");
            w.WriteLine(e.ToString());
            w.Close();
            Application.Restart();
        }

        private void timerVersionCheck_Tick(object sender, EventArgs e)
        {
            versionCheck(false);
        }

        private void setImageBG(bool setBG, string seriesID, string imageName = "none")
        {
            if (!setBG)
            {
                WebClient wc = new WebClient();
                wc.DownloadFileAsync(new Uri(imageName), path + seriesID + ".fa.jpg");
                while (wc.IsBusy) { }
                using (MagickImage image = new MagickImage(path + seriesID + ".fa.jpg"))
                {
                    double opacitySetting = Quantum.Max / (Quantum.Max * 0.3);
                    image.Alpha(AlphaOption.Set);
                    image.Evaluate(Channels.Alpha, EvaluateOperator.Min, Quantum.Max / opacitySetting);
                    if (File.Exists(path + seriesID + ".fa.png"))
                    {
                        this.BackgroundImage.Dispose();
                        this.BackgroundImage = null;
                        //this.BackgroundImage = Miro_TV_Manager.Properties.Resources._114851;
                        File.Delete(path + seriesID + ".fa.png");
                    }
                    image.Write(path + seriesID + ".fa.png");
                }
            }
            else { this.BackgroundImage = Image.FromFile(path + seriesID + ".fa.png"); }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            versionCheck(true);
        }

        private void versionCheck(bool popup)
        {
            if (internet)
            {
            checkAgain: ;
                File.Delete(path + "version.txt");
                WebClient wb = new WebClient();
                Random rand = new Random();
                try
                {
                    wb.DownloadFileAsync(new Uri("http://miroppb.com/TVManager/version.txt?r=" + rand.Next(9999)), path + "version.txt");
                }
                catch { }
                while (wb.IsBusy) { }
                StreamReader r = new StreamReader(path + "version.txt");
                string v = r.ReadLine();
                r.Close();
                if (v != System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() && v != null)
                {
                    if (MessageBox.Show("There is a new version of the application available. Would you like to update now?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) Application.Restart();
                }
                else if (v == null) { goto checkAgain; }
                else if (popup) { MessageBox.Show("No updates were found...Bummer...", "Miro TV Manager", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        //end program
    }
}
