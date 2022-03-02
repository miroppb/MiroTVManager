using ImageMagick;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miro_TV_Manager
{
    public partial class frmMainV3 : Form
    {
        //common variables
        public const string APIurl = "https://api.thetvdb.com";
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Miro TV Manager\";
        public string settingsVersion = "3.0.0.0";
        public string accountID = "";
        public string prowl = "";
        public bool favoritesExist = false;
        public bool internet = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        string currentSearchID = "";
        readonly string checkmark = "✓";
        int current5 = 0;
        string[] httpMethod = { "GET", "POST", "PUT", "DELETE" };
        Dictionary<int, bool> updateSeries = new Dictionary<int, bool>();
        List<PictureBox> picBoxs = new List<PictureBox>();
        List<PictureBox> delPicBoxs = new List<PictureBox>();
        List<int> currentEpisodes = new List<int>();
        bool fu = false;
        int currentSelected = -1;
        int nextShowID = -1;
        bool exit = false;
        bool notifyEnded = false;
        public bool updateFailed = false;
        public string plex = "";

        public string token = "";

        SQLiteConnection dbConnection;

        private SynchronizationContext m_SynchronizationContext;

        public frmMainV3()
        {
            InitializeComponent();

            picBoxs.Add(pcbxSeries1);
            picBoxs.Add(pcbxSeries2);
            picBoxs.Add(pcbxSeries3);
            picBoxs.Add(pcbxSeries4);
            picBoxs.Add(pcbxSeries5);
            delPicBoxs.Add(pcbxDel1);
            delPicBoxs.Add(pcbxDel2);
            delPicBoxs.Add(pcbxDel3);
            delPicBoxs.Add(pcbxDel4);
            delPicBoxs.Add(pcbxDel5);

            m_SynchronizationContext = SynchronizationContext.Current;

            bool IsExists = Directory.Exists(path);
            if (!IsExists) { Directory.CreateDirectory(path); }
            if (!File.Exists(path + "database.sqlite"))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                SQLiteConnection.CreateFile(path + "database.sqlite");
                dbConnection = new SQLiteConnection("Data Source=" + path + "database.sqlite;Version=3;");

                string sql = "CREATE TABLE 'settings' ('thetvdbUsername' TEXT, 'thetvdbID' TEXT, 'prowlID' TEXT, 'settingsVersion' TEXT NOT NULL, 'notifyEnded' INT NOT NULL, "
                    + "'minimizeClose' INT NOT NULL, 'updateSeries' INT NOT NULL, 'updateEvery' TEXT, 'updateAt' TEXT, 'plex' TEXT); "
                    + "CREATE TABLE 'favorites' ('id' TEXT NOT NULL, 'name' TEXT);"
                    + "CREATE TABLE 'actors' ('seriesID' INT NOT NULL, 'actorID' INT NOT NULL, 'name' TEXT, 'role' TEXT, 'sortOrder' INT, 'image' TEXT); "
                    + "CREATE TABLE 'episodes' ('seriesID' INT NOT NULL, 'episodeID' INT NOT NULL, 'absoluteNumber' INT, 'seasonNumber' INT, 'episodeNumber' INT, 'episodeName' TEXT, "
                    + "'dateAired' TEXT, 'rating' TEXT, 'overview' TEXT); "
                    + "CREATE TABLE 'notify' ('seriesID' INT NOT NULL, 'beforeAfter' INT NOT NULL, 'beforeTime' INT, 'newSeason' INT, 'currentSeason' INT, 'notifyWatch' INT);"
                    + "CREATE TABLE 'posters' ('id' INT NOT NULL, 'poster' BLOB);"
                    + "CREATE TABLE 'series' ('id' INT NOT NULL, 'name' TEXT NOT NULL, 'banner' BLOB, 'status' INT, 'network' TEXT, 'runtime' INT, 'genre' TEXT, 'overview' TEXT, 'lastUpdated' INT, 'airsDayOfWeek' TEXT, "
                    + "'airsTime' TEXT, 'rating' TEXT, 'imdb' TEXT, 'siteRating' TEXT);"
                    + "CREATE TABLE 'watch' ('seriesID' INT NOT NULL, 'episodeID' INT NOT NULL, 'seen' INT);"
                    + "INSERT INTO settings VALUES(NULL, NULL, NULL, \"" + settingsVersion + "\", 0, 0, 1, \"1,1\", \"6:00 AM\", NULL)";
                ExecuteNonQuery(sql);
            }
            else
            {
                dbConnection = new SQLiteConnection("Data Source=" + path + "database.sqlite;Version=3;");

                DataTable version;
                string query = "SELECT settingsVersion, plex FROM settings";
                version = GetDataTable(query);
                if (version.Rows[0].ItemArray[0].ToString() != settingsVersion)
                {
                    //downloading updateDatabase file
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(new Uri("http://miroppb.com/TVManager/update/" + version.Rows[0].ItemArray[0].ToString().Replace(".", "") + "to" + settingsVersion.Replace(".", "") + ".txt"), path + "updateDatabase.sql");
                }
                plex = version.Rows[0].ItemArray[1].ToString();
            }
            File.Copy(Application.StartupPath + @"\no_banner.png", path + @"no_banner.png", true);
            forceUpdate(true);
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //read file and upgrade database
            StreamReader r = new StreamReader(path + "updateDatabase.sql");
            string sql = r.ReadToEnd();
            r.Close();
            ExecuteNonQuery(sql);

            Application.Restart();
        }

        private async void forceUpdate(bool popup)
        {
            lblLoaded.Visible = true;
            progressStart.Visible = true;
            lblUpdated.Visible = false;

            DataTable ne = GetDataTable("SELECT notifyEnded FROM settings");
            if (ne.Rows[0].ItemArray[0].ToString() == "1")
                notifyEnded = true;
            else
                notifyEnded = false;

            Task<int> done = forceUpdateAsync(popup);
            int d = await done;

            lblLoaded.Visible = false;
            progressStart.Visible = false;

            changeCurrent5Series(0);

            DataTable zz = GetDataTable("SELECT COUNT(id) FROM favorites");
            if ((Convert.ToInt32(zz.Rows[0].ItemArray[0].ToString())) > 5)
                pcbxDown.Cursor = Cursors.Hand;

            lblUpdated.Text = "Last Updated: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            lblUpdated.Visible = true;
            settingsToolStripMenuItem.Enabled = true;
            updateNextShow(true);
            if (popup)
            {
                checkNewSeasons();
                checkMissedEpisodes();
                if (notifyEnded)
                    checkEndedSeries();
            }
        }

        private Task<int> forceUpdateAsync(bool popup)
        {
            return Task.Run(() =>
            {
                updateLoaded("Logging into theTVDB.com...",0, 0,-1);
                updateSeries.Clear();
                //alright, here we go
                //login and get token
                bool linked = true;

                if (!refreshToken(popup))
                    goto forceUpdateEnd;

                string url = "", json = "";

                string ended = "";

                List<int> fav = new List<int>();

                //download favorites
                if (linked)
                {
                    updateLoaded("Downloading your favorites...",0, 0,-1);
                    url = APIurl + "/user/favorites";
                    json = "404";
                    while (json=="404")
                        json = getJSON(url, token, 0);

                    RootObject_user_favorites uf = JsonConvert.DeserializeObject<RootObject_user_favorites>(json);
                    ExecuteNonQuery("DELETE FROM favorites");
                    for (int c = 0; c < uf.data.favorites.Count; c++)
                    {
                        //V3.0 11.14.19
                        //V3 changed favortites to return the name, not the ID *shrug*
                        /*string js_ = getJSON(APIurl + "/search/series?name=" + uf.data.favorites[c], token, 0);
                        RootObject_search temp = JsonConvert.DeserializeObject<RootObject_search>(js_);
                        int id_ = 0;
                        foreach (Datum_search zz in temp.data)
                            if (zz.seriesName == uf.data.favorites[c])
                                id_ = zz.id;*/
                        string id_ = uf.data.favorites[c]; //12.05.19 Favorites reverted back to IDs. *shrug*

                        string js = getJSON(APIurl + "/series/" + id_, token, 0);
                        if (js != "404") //75340 ??
                        {
                            RootObject_series fs = JsonConvert.DeserializeObject<RootObject_series>(js);

                            updateLoaded(fs.data.seriesName, c + 1, c * 75 / uf.data.favorites.Count, uf.data.favorites.Count * 2);

                            ExecuteNonQuery("INSERT INTO favorites VALUES(\"" + id_ + "\", \"" + fs.data.seriesName.Replace("'", "''") + "\");");

                            DataTable lu = GetDataTable("SELECT lastUpdated FROM series WHERE id = " + id_);
                            if (lu.Rows.Count == 0)
                                updateSeries.Add(Convert.ToInt32(id_), true);
                            else if (lu.Rows[0].ItemArray[0].ToString() == "" || lu.Rows[0].ItemArray[0].ToString() == null)
                                updateSeries.Add(Convert.ToInt32(id_), true);
                            else if (Convert.ToInt32(lu.Rows[0].ItemArray[0].ToString()) < Convert.ToInt32(fs.data.lastUpdated))
                                updateSeries.Add(Convert.ToInt32(id_), true);
                            else
                                updateSeries.Add(Convert.ToInt32(id_), false);

                            DataTable banner = GetDataTable("SELECT banner FROM series WHERE id = " + id_);
                            byte[] b = null;
                            try
                            {
                                b = getByteArray(banner.Rows[0], 0);
                            }
                            catch { }
                            if (b == null && (fs.data.banner != "" || fs.data.banner != null))
                            {
                                b = downloadImageAndConvert("http://thetvdb.com/banners/" + fs.data.banner, 0.6);
                            }

                            string fa = getJSON(APIurl + "/series/" + id_ + "/images/query?keyType=fanart", token, 0);
                            byte[] fan = null;
                            if (fa != "404")
                            {
                                RootObject_fanart fart = JsonConvert.DeserializeObject<RootObject_fanart>(fa);

                                //find highest rating
                                double fr = 0.0;
                                int h = 0;
                                for (int z = 0; z < fart.data.Count; z++)
                                {
                                    if (fart.data[z].ratingsInfo.average > fr)
                                    {
                                        fr = fart.data[z].ratingsInfo.average;
                                        h = z;
                                    }
                                }

                                DataTable fanart = GetDataTable("SELECT poster FROM posters WHERE id = " + id_);
                                try { fan = getByteArray(fanart.Rows[0], 0); }
                                catch { }
                                if (fan == null && (fart.data[h].fileName != "" || fart.data[h].fileName != null))
                                {
                                    fan = downloadImageAndConvert("http://thetvdb.com/banners/" + fart.data[h].fileName, 1.0);
                                }
                            }
                            else
                                fan = null;

                            ExecuteNonQuery("DELETE FROM series WHERE id = " + id_);
                            int status = 1;
                            if (fs.data.status != "Continuing")
                                status = 0;

                            if (status == 0)
                                ended += "\n\r-" + fs.data.seriesName;

                            string genre = "";
                            for (int g = 0; g < fs.data.genre.Count; g++)
                                genre += fs.data.genre[g] + ", ";

                            string time = "00:00";
                            if (fs.data.airsTime != "")
                                time = DateTime.Parse(fs.data.airsTime).ToString("HH:mm:ss");

                            string over = "";
                            if (fs.data.overview != null)
                                over = fs.data.overview.Replace("'", "''");

                            if (fs.data.runtime == "")
                                fs.data.runtime = "0";

                            ExecuteNonQueryWithBlob("INSERT INTO series VALUES(" + fs.data.id + ", \""
                                + fs.data.seriesName.Replace("'", "''") + "\", @b, " + status
                                + ", \"" + fs.data.network + "\", " + fs.data.runtime + ", \""
                                + genre.TrimEnd(' ').TrimEnd(',') + "\", '" + over + "', "
                                + fs.data.lastUpdated + ", \"" + fs.data.airsDayOfWeek + "\", \""
                                + time + "\", \"" + fs.data.rating + "\", \""
                                + fs.data.imdbId + "\", \"" + fs.data.siteRating + "\");", "b", b);

                            ExecuteNonQuery("DELETE FROM posters WHERE id = " + id_);
                            ExecuteNonQueryWithBlob("INSERT INTO posters VALUES(" + id_ + ", @b);", "b", fan);

                            fav.Add(Convert.ToInt32(id_));
                        }
                    }
                }
                else
                {
                    DataTable f = GetDataTable("SELECT * FROM favorites");
                    if (f.Rows.Count == 0)
                        goto forceUpdateEnd;

                    updateLoaded("Downloading your series...",0,0, -1);

                    for(int c = 0; c<f.Rows.Count; c++)
                    {
                        string js = getJSON(APIurl + "/series/" + f.Rows[c].ItemArray[0].ToString(), token, 0);
                        RootObject_series fs = JsonConvert.DeserializeObject<RootObject_series>(js);

                        updateLoaded(fs.data.seriesName, c + 1, c * 75 / f.Rows.Count, f.Rows.Count * 2);

                        DataTable lu = GetDataTable("SELECT lastUpdated FROM series WHERE id = " + f.Rows[c].ItemArray[0].ToString());
                        if (lu.Rows.Count == 0)
                            updateSeries.Add(Convert.ToInt32(f.Rows[c].ItemArray[0].ToString()), true);
                        else if (lu.Rows[0].ItemArray[0].ToString() == "" || lu.Rows[0].ItemArray[0].ToString() == null)
                            updateSeries.Add(Convert.ToInt32(f.Rows[c].ItemArray[0].ToString()), true);
                        else if (Convert.ToInt32(lu.Rows[0].ItemArray[0].ToString()) < Convert.ToInt32(fs.data.lastUpdated))
                            updateSeries.Add(Convert.ToInt32(f.Rows[c].ItemArray[0].ToString()), true);
                        else
                            updateSeries.Add(Convert.ToInt32(f.Rows[c].ItemArray[0].ToString()), false);
                        
                        DataTable banner = GetDataTable("SELECT banner FROM series WHERE id = " + f.Rows[c].ItemArray[0].ToString());
                        byte[] b = getByteArray(banner.Rows[0], 0);
                        if (b == null && (fs.data.banner != "" || fs.data.banner != null))
                        {
                            b = downloadImageAndConvert("http://thetvdb.com/banners/" + fs.data.banner, 0.6);
                        }

                        string fa = getJSON(APIurl + "/series/" + f.Rows[c].ItemArray[0].ToString() + "/images/query?keyType=fanart", token, 0);
                        byte[] fan;
                        if (fa != "404")
                        {
                            RootObject_fanart fart = JsonConvert.DeserializeObject<RootObject_fanart>(fa);

                            //find highest rating
                            double fr = 0.0;
                            int h = 0;
                            for (int z = 0; z < fart.data.Count; z++)
                            {
                                if (fart.data[z].ratingsInfo.average > fr)
                                {
                                    fr = fart.data[z].ratingsInfo.average;
                                    h = z;
                                }
                            }

                            DataTable fanart = GetDataTable("SELECT poster FROM posters WHERE id = " + f.Rows[c].ItemArray[0].ToString());
                            fan = getByteArray(fanart.Rows[0], 0);
                            if (fan == null && (fart.data[h].fileName != "" || fart.data[h].fileName != null))
                            {
                                fan = downloadImageAndConvert("http://thetvdb.com/banners/" + fart.data[h].fileName, 1.0);
                            }
                        }
                        else
                        {
                            fan = null;
                        }

                        ExecuteNonQuery("DELETE FROM series WHERE id = " + f.Rows[c].ItemArray[0].ToString());
                        int status = 1;
                        if (fs.data.status != "Continuing")
                            status = 0;

                        if (status == 0)
                            ended += "\n\r-" + fs.data.seriesName;

                        string genre = "";
                        for (int g = 0; g < fs.data.genre.Count; g++)
                            genre += fs.data.genre[g] + ", ";

                        string time = "00:00";
                        if (fs.data.airsTime != "")
                            time = DateTime.Parse(fs.data.airsTime).ToString("HH:mm:ss");

                        string over = "";
                        if (fs.data.overview != null)
                            over = fs.data.overview.Replace("'", "''");

                        if (fs.data.runtime == "")
                            fs.data.runtime = "0";

                        ExecuteNonQueryWithBlob("INSERT INTO series VALUES(" + fs.data.id + ", '"
                            + fs.data.seriesName.Replace("'", "''") + "', @b, " + status
                            + ", \"" + fs.data.network + "\", " + fs.data.runtime + ", '"
                            + genre.TrimEnd(' ').TrimEnd(',') + "\", '" + over + "', "
                            + fs.data.lastUpdated + ", \"" + fs.data.airsDayOfWeek + "\", \""
                            + time + "\", \"" + fs.data.rating + "\", \""
                            + fs.data.imdbId + "\", \"" + fs.data.siteRating + "\");","b",b);

                        ExecuteNonQuery("DELETE FROM posters WHERE id = " + f.Rows[c].ItemArray[0].ToString());
                        ExecuteNonQueryWithBlob("INSERT INTO posters VALUES(" + f.Rows[c].ItemArray[0].ToString() + ", @b);", "b", fan);

                        fav.Add(Convert.ToInt32(f.Rows[c].ItemArray[0].ToString()));
                    }
                }
                //update database
                DataTable ff = GetDataTable("SELECT id, name FROM favorites");
                for (int c = 0; c < updateSeries.Count; c++)
                {
                    updateLoaded(ff.Rows[c].ItemArray[1].ToString(), c, (c + ff.Rows.Count) * (ff.Rows.Count * 2) / (ff.Rows.Count * 2), ff.Rows.Count * 2);

                    DataTable a = GetDataTable("SELECT actorID FROM actors WHERE seriesID = " + ff.Rows[c].ItemArray[0].ToString());
                    if (a.Rows.Count == 0)
                    {
                        //actors
                        string js = getJSON(APIurl + "/series/" + ff.Rows[c].ItemArray[0].ToString() + "/actors", token, 0);
                        if (js != "404")
                        {
                            RootObject_actors ac = JsonConvert.DeserializeObject<RootObject_actors>(js);
                            if (ac.data != null)
                            {
                                ExecuteNonQuery("DELETE FROM actors WHERE seriesID = " + ff.Rows[c].ItemArray[0].ToString());
                                for (int z = 0; z < ac.data.Count; z++)
                                {
                                    ExecuteNonQuery("INSERT INTO actors VALUES(" + ff.Rows[c].ItemArray[0].ToString()
                                        + ", " + ac.data[z].id + ", \"" + ac.data[z].name
                                        + "\", '" + ac.data[z].role.Replace("'", "''") + "', " + ac.data[z].sortOrder
                                        + ", \"" + ac.data[z].image + "\");");
                                }
                            }
                        } //else actors not received
                    }

                    if (updateSeries[Convert.ToInt32(ff.Rows[c].ItemArray[0].ToString())])
                    {
                        //alright, lets pull the info...
                        string j = getJSON(APIurl + "/series/" + ff.Rows[c].ItemArray[0].ToString() + "/episodes", token, 0);
                        if (j != "404")
                        {
                            RootObject_episodes ep = JsonConvert.DeserializeObject<RootObject_episodes>(j);

                            //before we add episodes, lets remove if there are any, so they don't conflict
                            ExecuteNonQuery("DELETE FROM episodes WHERE seriesID = " + ff.Rows[c].ItemArray[0].ToString());

                            int cp = ep.links.first;
                            while (cp <= ep.links.last)
                            {
                                //alright, lets get the info from each ep and insert into database!
                                //for each episode
                                for (int e = 0; e < ep.data.Count; e++)
                                {
                                    string jr = "404";
                                    int cc = 0;
                                    while (jr == "404" && cc < 5)
                                    {
                                        try
                                        {
                                            jr = getJSON(APIurl + "/episodes/" + ep.data[e].id, token, 0);
                                        }
                                        catch { jr = "404"; }
                                        cc++;
                                    }
                                    //if episode ID isn't found (idk why), use don't use rating
                                    if (cc < 5)
                                    {
                                        RootObject_episode r = JsonConvert.DeserializeObject<RootObject_episode>(jr);

                                        string an = "NULL";
                                        if (ep.data[e].absoluteNumber != null)
                                            an = ep.data[e].absoluteNumber.ToString();

                                        string o = "NULL";
                                        if (ep.data[e].overview != null)
                                            o = ep.data[e].overview.ToString();

                                        string en = "NULL";
                                        if (ep.data[e].episodeName != null)
                                            en = ep.data[e].episodeName.ToString();

                                        string ass = "NULL";
                                        if (ep.data[e].airedSeason != null)
                                            ass = ep.data[e].airedSeason.ToString();

                                        ExecuteNonQuery("INSERT INTO episodes VALUES("
                                            + ff.Rows[c].ItemArray[0].ToString() + ", "
                                            + ep.data[e].id + ", "
                                            + an + ", "
                                            + ass + ", "
                                            + ep.data[e].airedEpisodeNumber + ", '"
                                            + en.Replace("'", "''") + "', \""
                                            + ep.data[e].firstAired + "\", \""
                                            + r.data.siteRating + " (" + r.data.siteRatingCount + " votes)\", '"
                                            + o.Replace("'", "''") + "');");
                                        //that was easy...
                                    }
                                    else
                                    {
                                        string an = "NULL";
                                        if (ep.data[e].absoluteNumber != null)
                                            an = ep.data[e].absoluteNumber.ToString();

                                        string o = "NULL";
                                        if (ep.data[e].overview != null)
                                            o = ep.data[e].overview.ToString();

                                        string en = "NULL";
                                        if (ep.data[e].episodeName != null)
                                            en = ep.data[e].episodeName.ToString();

                                        string ass = "NULL";
                                        if (ep.data[e].airedSeason != null)
                                            ass = ep.data[e].airedSeason.ToString();

                                        ExecuteNonQuery("INSERT INTO episodes VALUES("
                                            + ff.Rows[c].ItemArray[0].ToString() + ", "
                                            + ep.data[e].id + ", "
                                            + an + ", "
                                            + ass + ", "
                                            + ep.data[e].airedEpisodeNumber + ", '"
                                            + en.Replace("'", "''") + "', \""
                                            + ep.data[e].firstAired + "\", \""
                                            + "0 (0 votes)\", '"
                                            + o.Replace("'", "''") + "');");
                                    }
                                    //check if episode exists in watch
                                    DataTable w = GetDataTable("SELECT * FROM watch WHERE episodeID = " + ep.data[e].id);
                                    //if no rows, create
                                    if (w.Rows.Count == 0)
                                        ExecuteNonQuery("INSERT INTO watch VALUES(" + ff.Rows[c].ItemArray[0].ToString() + ", " + ep.data[e].id + ", 0);");
                                }
                                //when done, get next page
                                //if last page, don't pull next page
                                if (cp != ep.links.last)
                                {
                                    j = getJSON(APIurl + "/series/" + ff.Rows[c].ItemArray[0].ToString() + "/episodes?page=" + ep.links.next.ToString(), token, 0);
                                    ep = JsonConvert.DeserializeObject<RootObject_episodes>(j);
                                }
                                cp = cp + 1;
                            }
                        }
                    }
                }
                //loop to next series

                forceUpdateEnd:;
                return 1;
            });
        }

        private void changeCurrent5Series(int a)
        {
            pcbxSeries1.Cursor = Cursors.Default;
            pcbxSeries2.Cursor = Cursors.Default;
            pcbxSeries3.Cursor = Cursors.Default;
            pcbxSeries4.Cursor = Cursors.Default;
            pcbxSeries5.Cursor = Cursors.Default;
            pcbxSeries1.Tag = "";
            pcbxSeries2.Tag = "";
            pcbxSeries3.Tag = "";
            pcbxSeries4.Tag = "";
            pcbxSeries5.Tag = "";

            DataTable z = GetDataTable("SELECT COUNT(id) FROM favorites");

            int aa = a + 5;

            if (a > 0)
                pcbxUp.Cursor = Cursors.Hand;
            else
                pcbxUp.Cursor = Cursors.Default;

            int b = 0;
            int c = Convert.ToInt32(z.Rows[0].ItemArray[0].ToString());
            if ((a + 5) > c)
                b = c;
            else
                b = a + 5;
            current5 = a;
            int p = 0;

            while (a < b)
            {
                DataTable t = GetDataTable("SELECT id, name FROM favorites ORDER BY name LIMIT " + a + ", 1;");
                LoadImage(picBoxs[p], "SELECT banner FROM series WHERE id = " + t.Rows[0].ItemArray[0].ToString(), t.Rows[0].ItemArray[1].ToString(), t.Rows[0].ItemArray[0].ToString());
                delPicBoxs[p].Visible = true;
                delPicBoxs[p].Cursor = Cursors.Hand;

                a++;
                p++;
            }
            p = (5-(aa-a));
            while (a<aa)
            {
                picBoxs[p].Tag = "";
                picBoxs[p].Cursor = Cursors.Default;
                toolTip1.SetToolTip(picBoxs[p], "");
                picBoxs[p].Image = null;
                delPicBoxs[p].Cursor = Cursors.Default;
                delPicBoxs[p].Visible = false;
                p++;
                a++;
                pcbxDown.Cursor = Cursors.Default;
            }
            //disable down if at end of favorites
            if (a >= Convert.ToInt32(z.Rows[0].ItemArray[0].ToString()))
                pcbxDown.Cursor = Cursors.Default;
            else
                pcbxDown.Cursor = Cursors.Hand;
        }

        public void updateLoaded(string p, int c, int v, int t)
        {
            m_SynchronizationContext.Post((@object) => {
                if (t == -1)
                    lblLoaded.Text = p;
                else
                {
                    lblLoaded.Text = "Processing: " + p.Replace("''","'") + " " + c + "/" + (t/2).ToString();
                    progressStart.Value = 100 * v / t;
                }
            },p);
        }

        private string thetvdbLogin(Dictionary<string,string> data, string url)
        {
            string json = JsonConvert.SerializeObject(data);

            var http = (HttpWebRequest)WebRequest.Create(new Uri(url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string parsedContent = json;
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            try
            {
                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                return content;
            }
            catch
            {
                updateFailed = true;
                return "failed";
            }
        }

        /// <summary>
        /// Send JSON to the specified URL, with the token as the Authorization, and method, and return JSON
        /// </summary>
        /// <param name="url">URL to request</param>
        /// <param name="token">Token for Authorization</param>
        /// <param name="method">HTTP Method (0=GET, 1=POST, 2=PUT, 3=DELETE)</param>
        /// <returns>JSON</returns>
        private string getJSON(string url, string token, int method)
        {
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("Authorization", "Bearer " + token);
            request.Method = httpMethod[method];
            try
            {
                var response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();

                return responseFromServer;
            }
            catch (WebException we)
            {
                HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                if (we.Status == WebExceptionStatus.Timeout)
                    return "404";
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return "404";
                }
                return "404";
            }
        }
        private string sendPOST(string url, Dictionary<string, string> d)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            string postData = "";
            List<string> k = new List<string>(d.Keys);
            for (int a = 0; a < d.Count; a++)
                postData += k[a] + "=" + d[k[a]] + "&";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
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

        #region JSON
        public class RootObject_token
        {
            public string token { get; set; }
        }
        public class Data_user_favorites
        {
            public List<string> favorites { get; set; }
        }
        public class RootObject_user_favorites
        {
            public object errors { get; set; }
            public Data_user_favorites data { get; set; }
        }
        public class Data_series
        {
            public int id { get; set; }
            public string seriesName { get; set; }
            public List<string> aliases { get; set; }
            public string banner { get; set; }
            public string seriesId { get; set; }
            public string status { get; set; }
            public string firstAired { get; set; }
            public string network { get; set; }
            public string networkId { get; set; }
            public string runtime { get; set; }
            public List<string> genre { get; set; }
            public string overview { get; set; }
            public int lastUpdated { get; set; }
            public string airsDayOfWeek { get; set; }
            public string airsTime { get; set; }
            public string rating { get; set; }
            public string imdbId { get; set; }
            public string zap2itId { get; set; }
            public string added { get; set; }
            public int? addedBy { get; set; }
            public double siteRating { get; set; }
        }
        public class RootObject_series
        {
            public Data_series data { get; set; }
        }

        public class Links
        {
            public int first { get; set; }
            public int last { get; set; }
            public int? next { get; set; }
            public int? prev { get; set; }
        }

        public class Language
        {
            public string episodeName { get; set; }
            public string overview { get; set; }
        }

        public class Datum
        {
            public int? absoluteNumber { get; set; }
            public int? airedEpisodeNumber { get; set; }
            public int? airedSeason { get; set; }
            public int? airedSeasonID { get; set; }
            public string dvdEpisodeNumber { get; set; }
            public string dvdSeason { get; set; }
            public string episodeName { get; set; }
            public string firstAired { get; set; }
            public int id { get; set; }
            public Language language { get; set; }
            public string overview { get; set; }
        }

        public class RootObject_episodes
        {
            public object errors { get; set; }
            public Links links { get; set; }
            public List<Datum> data { get; set; }
        }
        public class RatingsInfo
        {
            public double average { get; set; }
            public int count { get; set; }
        }

        public class Datum_fanart
        {
            public int id { get; set; }
            public string keyType { get; set; }
            public string subKey { get; set; }
            public string fileName { get; set; }
            public string resolution { get; set; }
            public RatingsInfo ratingsInfo { get; set; }
            public string thumbnail { get; set; }
        }

        public class RootObject_fanart
        {
            public List<Datum_fanart> data { get; set; }
        }

        public class Datum_actors
        {
            public int id { get; set; }
            public int seriesId { get; set; }
            public string name { get; set; }
            public string role { get; set; }
            public int? sortOrder { get; set; }
            public string image { get; set; }
            public int? imageAuthor { get; set; }
            public string imageAdded { get; set; }
            public string lastUpdated { get; set; }
        }

        public class RootObject_actors
        {
            public List<Datum_actors> data { get; set; }
        }
        public class Data
        {
            public int id { get; set; }
            public int? airedSeason { get; set; }
            public int? airedEpisodeNumber { get; set; }
            public string episodeName { get; set; }
            public string firstAired { get; set; }
            public List<string> guestStars { get; set; }
            public string director { get; set; }
            public List<string> writers { get; set; }
            public string overview { get; set; }
            public string productionCode { get; set; }
            public string showUrl { get; set; }
            public int? lastUpdated { get; set; }
            public string dvdDiscid { get; set; }
            public int? dvdSeason { get; set; }
            public string dvdEpisodeNumber { get; set; }
            public int? dvdChapter { get; set; }
            public int? absoluteNumber { get; set; }
            public string filename { get; set; }
            public string seriesId { get; set; }
            public string lastUpdatedBy { get; set; }
            public int? airsAfterSeason { get; set; }
            public int? airsBeforeSeason { get; set; }
            public int? airsBeforeEpisode { get; set; }
            public int? thumbAuthor { get; set; }
            public string thumbAdded { get; set; }
            public string thumbWidth { get; set; }
            public string thumbHeight { get; set; }
            public string imdbId { get; set; }
            public double siteRating { get; set; }
            public int? siteRatingCount { get; set; }
        }
        public class RootObject_episode
        {
            public Data data { get; set; }
        }
        public class Datum_search
        {
            public List<object> aliases { get; set; }
            public string banner { get; set; }
            public string firstAired { get; set; }
            public int id { get; set; }
            public string network { get; set; }
            public string overview { get; set; }
            public string seriesName { get; set; }
            public string status { get; set; }
        }

        public class RootObject_search
        {
            public List<Datum_search> data { get; set; }
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
        private byte[] downloadImageAndConvert(string url, double op)
        {
            //download
            string f = "";
            if (url == "http://thetvdb.com/banners/")
            {
                return null;
            }
            else
            {
                Uri u = new Uri(url);
                f = System.IO.Path.GetFileName(u.LocalPath);
                WebClient w = new WebClient();
                w.DownloadFileAsync(new Uri(url), path + f);
                while (w.IsBusy) { }
            }

            //change opacity
            using (MagickImage image = new MagickImage(path + f))
            {
                if (op != 0.0)
                {
                    double opacitySetting = Quantum.Max / (Quantum.Max * op);
                    image.Alpha(AlphaOption.Set);
                    image.Evaluate(Channels.Alpha, EvaluateOperator.Min, Quantum.Max / opacitySetting);
                }
                image.Write(path + f.Replace(".jpg", ".png"));
                f = f.Replace(".jpg", ".png");
            }

            //convert to byte
            Image i = Image.FromFile(path + f);
            byte[] ib = ImageToByte(i, System.Drawing.Imaging.ImageFormat.Png);
            i.Dispose();
            i = null;
            File.Delete(path + f);
            File.Delete(path + f.Replace(".png",".jpg"));
            return ib;
        }
        /// <summary>
        /// Load Image from database as image for a picturebox, with tooltip and Tag, and changes the Cursor to Hand
        /// </summary>
        /// <param name="p">The PictureBox to use</param>
        /// <param name="sql">SQL to get the image from database</param>
        /// <param name="tool">Tooltip. Name of series</param>
        /// <param name="tag">Tag. ID of series, for reference when selecting or deleting</param>
        private void LoadImage(PictureBox p, string sql, string tool, string tag)
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
                        toolTip1.SetToolTip(p, tool);
                        p.Tag = tag;
                        p.Cursor = Cursors.Hand;
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();
        }
        /// <summary>
        /// Load Image from database as the background image
        /// </summary>
        /// <param name="sql">SQL to get the background. Ex: SELECT poster FROM posters</param>
        private void LoadImage(string sql)
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
                            this.BackgroundImage = Properties.Resources._4673;
                        else
                        {
                            byte[] a = (System.Byte[])rdr[0];
                            this.BackgroundImage = ByteToImage(a);
                        }
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();
        }
        private void LoadInfoFromBanner(string id)
        {
            fu = true;
            currentSearchID = id;
            btnSeenAll.Visible = true;
            rchEpisodeDescription.Visible = false;
            rchEpisodeDescription.Text = "";
            
            //Here we go!!!!!
            //Lets get the first half...
            DataTable series = GetDataTable("SELECT name, status, runtime, genre, overview, airsDayOfWeek, airsTime, siteRating FROM series WHERE id = " + id);
            //Load the image...
            LoadImage("SELECT poster FROM posters WHERE id = " + id);
            try { pcbxSearch.Image.Dispose(); }
            catch { pcbxSearch.Image = null; }
            LoadImage(pcbxSearch, "SELECT banner FROM series WHERE id = " + id, series.Rows[0].ItemArray[0].ToString(), id);
            //Now the top info
            txtTitle.Text = series.Rows[0].ItemArray[0].ToString();
            if (series.Rows[0].ItemArray[1].ToString() == "0") { lblEnded.Visible = true; } else { lblEnded.Visible = false; }
            txtGenre.Text = series.Rows[0].ItemArray[3].ToString();
            txtSeriesDescription.Text = series.Rows[0].ItemArray[4].ToString();
            txtAirsOn.Text = series.Rows[0].ItemArray[5].ToString();
            txtAirsAt.Text = DateTime.Parse(series.Rows[0].ItemArray[6].ToString()).ToShortTimeString();
            txtRating.Text = series.Rows[0].ItemArray[7].ToString();
            //Actors
            DataTable actors = GetDataTable("SELECT name FROM actors WHERE seriesID = " + id + " ORDER BY sortOrder");
            string[] a = new string[actors.Rows.Count];
            for (int b = 0; b < actors.Rows.Count; b++)
                a[b] = actors.Rows[b].ItemArray[0].ToString();
            txtActors.Text = String.Join(", ", a);
            //Has the series ended?
            DataTable status = GetDataTable("SELECT status FROM series WHERE id = " + id);
            if (status.Rows[0].ItemArray[0].ToString() == "0")
                lblEnded.Visible = true;
            else
                lblEnded.Visible = false;

            //Seasons and episodes
            DataTable seasons = GetDataTable("SELECT seasonNumber FROM episodes WHERE seriesID = " + id + " AND seasonNumber > 0 GROUP BY seasonNumber");
            txtSeasons.Text = seasons.Rows.Count.ToString();
            DataTable episodes = GetDataTable("SELECT COUNT(episodeNumber) FROM episodes WHERE seriesID = " + id + " AND seasonNumber > 0");
            DataTable episodes2 = GetDataTable("SELECT COUNT(episodeNumber) FROM episodes WHERE seriesID = " + id + " AND seasonNumber == 0");
            txtEpisodes.Text = episodes.Rows[0].ItemArray[0].ToString();
            if (episodes2.Rows.Count > 0)
                txtEpisodes.Text += " + " + episodes2.Rows[0].ItemArray[0].ToString() + " specials";

            //Get series episodes!!!!
            lstOverview.Items.Clear();
            lstOverview.Groups.Clear();
            int d = Convert.ToInt32(txtSeasons.Text);
            int c = 0;
            if (episodes2.Rows[0].ItemArray[0].ToString() != "0")
            {
                d++;
                c++;
            }
            ListViewGroup[] groups = new ListViewGroup[d];
            bool s = false;
            if (episodes2.Rows[0].ItemArray[0].ToString() != "0")
            {
                groups[0] = new ListViewGroup("Specials", System.Windows.Forms.HorizontalAlignment.Left);
                s = true;
            }
            int ccc = 0;
            while (c < d)
            {
                groups[c] = new ListViewGroup("Season " + seasons.Rows[ccc].ItemArray[0].ToString(), System.Windows.Forms.HorizontalAlignment.Left);
                c++;
                ccc++;
            }
            lstOverview.Groups.AddRange(groups);
            currentEpisodes.Clear();
            //loop through each season
            int specials = 0;
            if (s)
            {
                //specials
                DataTable sp = GetDataTable("SELECT episodeName, rating, dateAired, seriesID, episodeID FROM episodes WHERE seasonNumber == 0 AND seriesID = " + id + " ORDER BY episodeNumber");
                DataTable time = GetDataTable("SELECT airsTime FROM series WHERE id = " + sp.Rows[0].ItemArray[3].ToString());
                specials = sp.Rows.Count;
                for (int aa = 0; aa < sp.Rows.Count; aa++)
                {
                    string ch = "";
                    if ((DateTime.Parse(sp.Rows[aa].ItemArray[2].ToString() + " " + time.Rows[0].ItemArray[0].ToString()) < DateTime.Now))
                        ch = checkmark;
                    if (sp.Rows[aa].ItemArray[2].ToString() == null || sp.Rows[aa].ItemArray[2].ToString() == "")
                        ch = "";

                    string en = sp.Rows[aa].ItemArray[0].ToString();
                    if (en == "NULL")
                        en = "";
                    string[] t = { (Convert.ToInt32(aa.ToString()) + 1).ToString(), en, sp.Rows[aa].ItemArray[1].ToString(), sp.Rows[aa].ItemArray[2].ToString(), ch };
                    DataTable w = GetDataTable("SELECT seen FROM watch WHERE episodeID = " + sp.Rows[aa].ItemArray[4].ToString());
                    ListViewItem i = new ListViewItem();
                    if (w.Rows.Count > 0)
                    {
                        if (w.Rows[0].ItemArray[0].ToString() == "1")
                            i.Checked = true;
                    }
                    i.SubItems.AddRange(t);
                    lstOverview.Items.Add(i);
                    lstOverview.Items[aa].Group = groups[0];
                    currentEpisodes.Add(Convert.ToInt32(sp.Rows[aa].ItemArray[4].ToString()));
                }
            }
            //alright, lets do the rest of the seasons
            int bb = specials;
            for (int season = 1; season <= Convert.ToInt32(txtSeasons.Text); season++)
            {
                DataTable sp = GetDataTable("SELECT episodeName, rating, dateAired, seriesID, episodeID FROM episodes WHERE seasonNumber == " + seasons.Rows[season-1].ItemArray[0].ToString() + " AND seriesID = " + id + " ORDER BY episodeNumber");
                DataTable time = GetDataTable("SELECT airsTime FROM series WHERE id = " + sp.Rows[0].ItemArray[3].ToString());
                int cc = 0;
                while (cc < sp.Rows.Count)
                {
                    string ch = "";
                    if ((DateTime.Parse(sp.Rows[cc].ItemArray[2].ToString() + " " + time.Rows[0].ItemArray[0].ToString()) < DateTime.Now))
                        ch = checkmark;
                    if (sp.Rows[cc].ItemArray[2].ToString() == null || sp.Rows[cc].ItemArray[2].ToString() == "")
                        ch = "";

                    string en = sp.Rows[cc].ItemArray[0].ToString();
                    if (en == "NULL")
                        en = "";
                    string[] t = { (Convert.ToInt32(cc.ToString()) + 1).ToString(), en, sp.Rows[cc].ItemArray[1].ToString(), sp.Rows[cc].ItemArray[2].ToString(), ch };
                    DataTable w = GetDataTable("SELECT seen FROM watch WHERE episodeID = " + sp.Rows[cc].ItemArray[4].ToString());
                    ListViewItem i = new ListViewItem();
                    if (w.Rows.Count > 0)
                    {
                        if (w.Rows[0].ItemArray[0].ToString() == "1")
                            i.Checked = true;
                    }
                    i.SubItems.AddRange(t);
                    lstOverview.Items.Add(i);
                    if (s)
                    {
                        lstOverview.Items[bb].Group = groups[season];
                    }
                    else
                        lstOverview.Items[bb].Group = groups[season - 1];
                    currentEpisodes.Add(Convert.ToInt32(sp.Rows[cc].ItemArray[4].ToString()));

                    cc++;
                    bb++;
                }
            }
            lstOverview.Columns[3].Width = -1;
            lstOverview.Columns[4].Width = -1;
            fu = false;

            DataTable aaa = GetDataTable("SELECT name FROM favorites WHERE id = " + currentSearchID);
            if (aaa.Rows.Count == 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }
        #endregion

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable s;
            s = GetDataTable("SELECT * FROM settings");
            frmSettingsV3 frm = new frmSettingsV3();
            frm.u = true;
            frm.txtUsername.Text = s.Rows[0].ItemArray[0].ToString();
            frm.txtUserkey.Text = s.Rows[0].ItemArray[1].ToString();
            frm.txtUsername.ForeColor = Color.Black;
            frm.txtUserkey.ForeColor = Color.Black;
            if (s.Rows[0].ItemArray[4].ToString() == "1")
                frm.chkEnded.Checked = true;
            else
                frm.chkEnded.Checked = false;
            if (s.Rows[0].ItemArray[5].ToString() == "1")
                frm.chkTaskbar.Checked = true;
            else
                frm.chkTaskbar.Checked = false;
            if (s.Rows[0].ItemArray[6].ToString() == "1")
                frm.chkUpdate.Checked = true;
            else
                frm.chkUpdate.Checked = false;
            string[] t = s.Rows[0].ItemArray[7].ToString().Split(',');
            frm.nmDuration.Value = Convert.ToDecimal(t[0]);
            frm.cmbTimeframe.SelectedIndex = Convert.ToInt16(t[1]);
            if (s.Rows[0].ItemArray[8].ToString().Contains(":"))
                frm.dtTime.Value = DateTime.Parse(s.Rows[0].ItemArray[8].ToString());
            else
                frm.dtTime.Value = DateTime.Parse("1/1/" + DateTime.Now.Year + " 12:00am");
            if (s.Rows[0].ItemArray[2].ToString() != "")
            {
                frm.txtProwlID.Text = s.Rows[0].ItemArray[2].ToString();
                frm.txtProwlID.ForeColor = Color.Black;
            }
            if (s.Rows[0].ItemArray[9].ToString() != "")
            {
                frm.TxtPlex.Text = s.Rows[0].ItemArray[9].ToString();
                frm.ChkPlex.Checked = true;
            }

            //populate cmbSeries
            DataTable ff = GetDataTable("SELECT name FROM favorites ORDER BY name");
            if (ff.Rows.Count > 0)
            {
                for (int a = 0; a < ff.Rows.Count; a++)
                    frm.cmbSeries.Items.Add(ff.Rows[a].ItemArray[0].ToString());
                
                frm.cmbSeries.SelectedIndex = 0;
                frm.groupBox2.Visible = true;
                frm.groupBox3.Visible = true;
            }
            else
            {
                frm.groupBox2.Visible = false;
                frm.groupBox3.Visible = false;
            }
            frm.u = false;

            frm.ShowDialog();

            if (frm.txtUsername.Text != "Username" && frm.txtUsername.Text != "")
            {
                //save settings
                token = frm.token;
                string sql = "UPDATE settings SET thetvdbUsername = @username, thetvdbID = @id";
                List<SQLiteParameter> data = new List<SQLiteParameter>();
                data.Add(new SQLiteParameter("@username", frm.txtUsername.Text));
                data.Add(new SQLiteParameter("@id", frm.txtUserkey.Text));
                Prepare(sql, data);
            }

            if (frm.TxtPlex.Text != "")
                plex = frm.TxtPlex.Text;

            //if first time, and no favorites exist, get them
            DataTable f;
            f = GetDataTable("SELECT * FROM favorites");
            if (f.Rows.Count == 0 && token != "")
                forceUpdate(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = true;
            Application.Exit();
        }

        private void pcbxSeries1_Click(object sender, EventArgs e)
        {
            if (pcbxSeries1.Cursor == Cursors.Hand)
            {
                LoadInfoFromBanner(pcbxSeries1.Tag.ToString());
                currentSearchID = pcbxSeries1.Tag.ToString();
            }
        }

        private void pcbxSeries2_Click(object sender, EventArgs e)
        {
            if (pcbxSeries2.Cursor == Cursors.Hand)
            {
                LoadInfoFromBanner(pcbxSeries2.Tag.ToString());
                currentSearchID = pcbxSeries2.Tag.ToString();
            }
        }

        private void pcbxSeries3_Click(object sender, EventArgs e)
        {
            if (pcbxSeries3.Cursor == Cursors.Hand)
            {
                LoadInfoFromBanner(pcbxSeries3.Tag.ToString());
                currentSearchID = pcbxSeries3.Tag.ToString();
            }
        }

        private void pcbxSeries4_Click(object sender, EventArgs e)
        {
            if (pcbxSeries4.Cursor == Cursors.Hand)
            {
                LoadInfoFromBanner(pcbxSeries4.Tag.ToString());
                currentSearchID = pcbxSeries4.Tag.ToString();
            }
        }

        private void pcbxSeries5_Click(object sender, EventArgs e)
        {
            if (pcbxSeries5.Cursor == Cursors.Hand)
            {
                LoadInfoFromBanner(pcbxSeries5.Tag.ToString());
                currentSearchID = pcbxSeries5.Tag.ToString();
            }
        }

        private void lstOverview_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //get index
            if (!fu)
            {
                switch(e.Item.Checked)
                {
                    case true:
                        ExecuteNonQuery("DELETE FROM watch WHERE episodeID = " + currentEpisodes[e.Item.Index].ToString());
                        ExecuteNonQuery("INSERT INTO watch VALUES(" + currentSearchID + ", " + currentEpisodes[e.Item.Index] + ", 1);");
                        break;
                    case false:
                        ExecuteNonQuery("DELETE FROM watch WHERE episodeID = " + currentEpisodes[e.Item.Index].ToString());
                        ExecuteNonQuery("INSERT INTO watch VALUES(" + currentSearchID + ", " + currentEpisodes[e.Item.Index] + ", 0);");
                        break;
                }
            }
        }

        private void pcbxUp_Click(object sender, EventArgs e)
        {
            if (pcbxUp.Cursor == Cursors.Hand)
            {
                changeCurrent5Series(current5 - 5);
            }
        }

        private void pcbxDown_Click(object sender, EventArgs e)
        {
            if (pcbxDown.Cursor == Cursors.Hand)
            {
                changeCurrent5Series(current5 + 5);
            }
        }

        private void pcbxUp_MouseEnter(object sender, EventArgs e)
        {
            if (pcbxUp.Cursor == Cursors.Hand)
            {
                pcbxUp.BackgroundImage = Properties.Resources.arrow_up_green;
            }
        }

        private void pcbxUp_MouseLeave(object sender, EventArgs e)
        {
            pcbxUp.BackgroundImage = Properties.Resources.arrow_up;
        }

        private void pcbxDown_MouseEnter(object sender, EventArgs e)
        {
            if (pcbxDown.Cursor == Cursors.Hand)
            {
                pcbxDown.BackgroundImage = Properties.Resources.arrow_down_green;
            }
        }

        private void pcbxDown_MouseLeave(object sender, EventArgs e)
        {
            pcbxDown.BackgroundImage = Properties.Resources.arrow_down;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                txtSearch.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                searchSeries(txtSearch.Text, false);
            }
        }

        private async void searchSeries(string text, bool cleared)
        {
            pbSearch.Visible = true;
            Task<int> done = searchSeriesAsync(text, cleared);
            int d = await done;
            if (currentSearchID != "")
            {
                LoadInfoFromBanner(currentSearchID);
            }
            pbSearch.Visible = false;

            //Find the searched episode, and scroll to it
            DataTable b = GetDataTable("SELECT * FROM favorites ORDER BY name");
            int c = 0;
            while (c < b.Rows.Count && b.Rows[c].ItemArray[1].ToString() != txtTitle.Text)
                c++;
            if (c != b.Rows.Count) //series exists in favorites
            {
                //get last digit, determine which 0 or 5 is before it, and updateTop5
                int cc = -1;
                if (c < 10)
                    cc = c;
                else
                    cc = Convert.ToInt16(c.ToString().Remove(0, 1));
                int aa = 0;
                while (cc != 0 && cc != 5)
                {
                    cc--;
                    aa++;
                }
                changeCurrent5Series(c - aa);

                btnAdd.Enabled = false;
            }
            else
                btnAdd.Enabled = true;
        }

        private Task<int> searchSeriesAsync(string s, bool cleared)
        {
            return Task.Run(() =>
            {
                //here we go!
                refreshToken(false);

                string j = "";
                if (s.StartsWith("tt"))
                    j = getJSON(APIurl + "/search/series?imdbId=" + s, token, 0);
                else
                    j = getJSON(APIurl + "/search/series?name=" + s, token, 0);

                if (j != "404")
                {
                    RootObject_search search = JsonConvert.DeserializeObject<RootObject_search>(j);


                    List<int> id = new List<int>();
                    List<string> series = new List<string>();
                    List<string> overview = new List<string>();
                    List<string> banners = new List<string>();

                    for (int c = 0; c < search.data.Count; c++)
                    {
                        id.Add(search.data[c].id);
                        series.Add(search.data[c].seriesName);
                        overview.Add(search.data[c].overview);
                        banners.Add(search.data[c].banner);
                    }

                    frmSearchSelection frm = new frmSearchSelection();
                    if (!cleared)
                    {
                        
                        frm.updateResults(id, series, overview, banners);
                        frm.ShowDialog();
                    }
                    else
                    {
                        frm.updateResults(id, series, overview, banners);
                        foreach (ListViewItem a in frm.lstSeries.Items)
                        {
                            if (a.Text == s)
                            {
                                frm.selected = a.Index;
                                break;
                            }
                        }

                    }
                    if (frm.selected != -1)
                    {
                        //get series and episodes info
                        string js = getJSON(APIurl + "/series/" + id[frm.selected].ToString(), token, 0);
                        RootObject_series fs = JsonConvert.DeserializeObject<RootObject_series>(js);

                        DataTable lu = GetDataTable("SELECT lastUpdated FROM series WHERE id = " + id[frm.selected].ToString());
                        bool u = false;
                        if (lu.Rows.Count == 0)
                            u = true;
                        else if (lu.Rows[0].ItemArray[0].ToString() == "" || lu.Rows[0].ItemArray[0].ToString() == null)
                            u = true;
                        else if (Convert.ToInt32(lu.Rows[0].ItemArray[0].ToString()) < Convert.ToInt32(fs.data.lastUpdated))
                            u = true;
                        else
                            u = false;

                        DataTable banner = GetDataTable("SELECT banner FROM series WHERE id = " + id[frm.selected].ToString());
                        byte[] b = null;
                        try
                        {
                            b = getByteArray(banner.Rows[0], 0);
                        }
                        catch { }
                        if (b == null && (fs.data.banner != "" || fs.data.banner != null))
                        {
                            b = downloadImageAndConvert("http://thetvdb.com/banners/" + fs.data.banner, 0.6);
                        }

                        string fa = getJSON(APIurl + "/series/" + id[frm.selected].ToString() + "/images/query?keyType=fanart", token, 0);
                        byte[] fan = null;
                        if (fa != "404")
                        {
                            RootObject_fanart fart = JsonConvert.DeserializeObject<RootObject_fanart>(fa);

                            //find highest rating
                            double fr = 0.0;
                            int h = 0;
                            for (int z = 0; z < fart.data.Count; z++)
                            {
                                if (fart.data[z].ratingsInfo.average > fr)
                                {
                                    fr = fart.data[z].ratingsInfo.average;
                                    h = z;
                                }
                            }

                            DataTable fanart = GetDataTable("SELECT poster FROM posters WHERE id = " + id[frm.selected].ToString());
                            try { fan = getByteArray(fanart.Rows[0], 0); }
                            catch { }
                            if (fan == null && (fart.data[h].fileName != "" || fart.data[h].fileName != null))
                            {
                                fan = downloadImageAndConvert("http://thetvdb.com/banners/" + fart.data[h].fileName, 1.0);
                            }
                        }
                        else
                            fan = null;

                        ExecuteNonQuery("DELETE FROM series WHERE id = " + id[frm.selected].ToString());
                        int status = 1;
                        if (fs.data.status != "Continuing")
                            status = 0;

                        string genre = "";
                        for (int g = 0; g < fs.data.genre.Count; g++)
                            genre += fs.data.genre[g] + ", ";

                        string time = "00:00";
                        if (fs.data.airsTime != "")
                            time = DateTime.Parse(fs.data.airsTime).ToString("HH:mm:ss");
                        if (fs.data.runtime == "")
                            fs.data.runtime = "0";

                        ExecuteNonQueryWithBlob("INSERT INTO series VALUES(" + fs.data.id + ", \""
                            + fs.data.seriesName.Replace("'", "''") + "\", @b, " + status
                            + ", \"" + fs.data.network + "\", " + fs.data.runtime + ", \""
                            + genre.TrimEnd(' ').TrimEnd(',') + "\", '" + fs.data.overview.Replace("'", "''") + "', "
                            + fs.data.lastUpdated + ", \"" + fs.data.airsDayOfWeek + "\", \""
                            + time + "\", \"" + fs.data.rating + "\", \""
                            + fs.data.imdbId + "\", \"" + fs.data.siteRating + "\");", "b", b);

                        ExecuteNonQuery("DELETE FROM posters WHERE id = " + id[frm.selected].ToString());
                        ExecuteNonQueryWithBlob("INSERT INTO posters VALUES(" + id[frm.selected].ToString() + ", @b);", "b", fan);

                        //GET EPISODES
                        if (u)
                        {
                            DataTable a = GetDataTable("SELECT actorID FROM actors WHERE seriesID = " + id[frm.selected].ToString());
                            if (a.Rows.Count == 0)
                            {
                                //actors
                                js = getJSON(APIurl + "/series/" + id[frm.selected].ToString() + "/actors", token, 0);
                                if (js != "404") //Guess sometimes there's no actors?
                                {
                                    RootObject_actors ac = JsonConvert.DeserializeObject<RootObject_actors>(js);
                                    ExecuteNonQuery("DELETE FROM actors WHERE seriesID = " + id[frm.selected].ToString());
                                    for (int z = 0; z < ac.data.Count; z++)
                                    {
                                        ExecuteNonQuery("INSERT INTO actors VALUES(" + id[frm.selected].ToString()
                                            + ", " + ac.data[z].id + ", \"" + ac.data[z].name
                                            + "\", '" + ac.data[z].role.Replace("'", "''") + "', " + ac.data[z].sortOrder
                                            + ", \"" + ac.data[z].image + "\");");
                                    }
                                }
                            }
                                
                            //alright, lets pull the info...
                            js = getJSON(APIurl + "/series/" + id[frm.selected].ToString() + "/episodes", token, 0);
                            if (js != "404") //episodes exist?
                            {
                                RootObject_episodes ep = JsonConvert.DeserializeObject<RootObject_episodes>(js);

                                //before we add episodes, lets remove if there are any, so they don't conflict
                                ExecuteNonQuery("DELETE FROM episodes WHERE seriesID = " + id[frm.selected].ToString());

                                int cp = ep.links.first;
                                while (cp <= ep.links.last)
                                {
                                    //alright, lets get the info from each ep and insert into database!
                                    //for each episode
                                    for (int e = 0; e < ep.data.Count; e++)
                                    {
                                        string jr = getJSON(APIurl + "/episodes/" + ep.data[e].id, token, 0);
                                        RootObject_episode r = JsonConvert.DeserializeObject<RootObject_episode>(jr);

                                        string an = "NULL";
                                        if (ep.data[e].absoluteNumber != null)
                                            an = ep.data[e].absoluteNumber.ToString();

                                        string o = "NULL";
                                        if (ep.data[e].overview != null)
                                            o = ep.data[e].overview.ToString();

                                        string en = "NULL";
                                        if (ep.data[e].episodeName != null)
                                            en = ep.data[e].episodeName.ToString();

                                        ExecuteNonQuery("INSERT INTO episodes VALUES("
                                            + id[frm.selected].ToString() + ", "
                                            + ep.data[e].id + ", "
                                            + an + ", "
                                            + ep.data[e].airedSeason + ", "
                                            + ep.data[e].airedEpisodeNumber + ", '"
                                            + en.Replace("'", "''") + "', \""
                                            + ep.data[e].firstAired + "\", \""
                                            + r.data.siteRating + " (" + r.data.siteRatingCount + " votes)\", '"
                                            + o.Replace("'", "''") + "');");
                                        //that was easy...
                                        //check if episode exists in watch
                                        DataTable w = GetDataTable("SELECT * FROM watch WHERE episodeID = " + ep.data[e].id);
                                        //if no rows, create
                                        if (w.Rows.Count == 0)
                                            ExecuteNonQuery("INSERT INTO watch VALUES(" + id[frm.selected].ToString() + ", " + ep.data[e].id + ", 0);");
                                    }
                                    //when done, get next page
                                    //if last page, don't pull next page
                                    if (cp != ep.links.last)
                                    {
                                        j = getJSON(APIurl + "/series/" + id[frm.selected].ToString() + "/episodes?page=" + ep.links.next.ToString(), token, 0);
                                        ep = JsonConvert.DeserializeObject<RootObject_episodes>(j);
                                    }
                                    cp = cp + 1;
                                }
                            }
                        }
                        if (frm.selected != -1)
                            currentSearchID = id[frm.selected].ToString();
                        else
                            currentSearchID = "";
                    }
                }
                else
                    MessageBox.Show("No results for \"" + s + "\". Please rephrase and try again.");

                return 1;
            });
        }

        private void timerNextShow_Tick(object sender, EventArgs e)
        {
            updateNextShow(false);
        }

        private void updateNextShow(bool now)
        {
            if (now)
            {
                DataTable b = GetDataTable("SELECT series.id, series.name, episodes.dateAired || \" \" || series.airsTime AS \"date and time\", episodes.episodeName FROM episodes, series "
                        + "WHERE datetime(episodes.dateAired || \" \" || series.airsTime) > datetime('now','localtime') AND series.id = episodes.seriesID "
                        + "ORDER BY episodes.dateAired || \" \" || series.airsTime LIMIT 0, 1");
                if (b.Rows.Count > 0)
                {
                    lblNextEpisode.Text = "Next Show: " + b.Rows[0].ItemArray[1].ToString().Replace("''", "'") + " // " + DateTime.Parse(b.Rows[0].ItemArray[2].ToString()).ToShortDateString() + " "
                               + DateTime.Parse(b.Rows[0].ItemArray[2].ToString()).ToShortTimeString() + " // " + b.Rows[0].ItemArray[3].ToString().Replace("''", "'");
                    nextShowID = Convert.ToInt32(b.Rows[0].ItemArray[0].ToString());
                }
            }
            else
            {
                int a = Convert.ToInt16(DateTime.Now.ToString("mm").Remove(0, 1));
                switch (a)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        timerNextShow.Interval = 60000;
                        break;
                    case 5:
                    case 0:
                        //here we go again!
                        DataTable b = GetDataTable("SELECT series.id, series.name, episodes.dateAired || \" \" || series.airsTime AS \"date and time\", episodes.episodeName FROM episodes, series "
                            + "WHERE datetime(episodes.dateAired || \" \" || series.airsTime) > datetime('now','localtime') AND series.id = episodes.seriesID "
                            + "ORDER BY episodes.dateAired || \" \" || series.airsTime LIMIT 0, 1");
                        if (b.Rows.Count > 0)
                        {
                            lblNextEpisode.Text = "Next Show: " + b.Rows[0].ItemArray[1].ToString().Replace("''","'") + " // " + DateTime.Parse(b.Rows[0].ItemArray[2].ToString()).ToShortDateString() + " "
                                + DateTime.Parse(b.Rows[0].ItemArray[2].ToString()).ToShortTimeString() + " // " + b.Rows[0].ItemArray[3].ToString().Replace("''","'");
                            nextShowID = Convert.ToInt32(b.Rows[0].ItemArray[0].ToString());
                        }
                        timerNextShow.Interval = 300000;
                        break;
                }
            }
        }

        private void lstOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOverview.FocusedItem != null && lstOverview.FocusedItem.Index != currentSelected)
            {
                try
                {
                    DataTable o = GetDataTable("SELECT overview FROM episodes WHERE episodeID = " + currentEpisodes[lstOverview.FocusedItem.Index].ToString());

                    currentSelected = lstOverview.FocusedItem.Index;
                    //now, lets find the item selected
                    string season = lstOverview.SelectedItems[0].Group.ToString().Replace("Season ", "");
                    string episode = lstOverview.SelectedItems[0].SubItems[1].Text;
                    rchEpisodeDescription.Visible = true;
                    rchEpisodeDescription.Text = "";
                    rchEpisodeDescription.Text = txtTitle.Text;
                    if (season != "Specials")
                    {
                        rchEpisodeDescription.Text += " S";
                        if (Convert.ToInt16(season) < 10) { rchEpisodeDescription.Text += "0"; }
                        rchEpisodeDescription.Text += season + "E";
                    }
                    else
                        rchEpisodeDescription.Text += " " + season + " E";
                    if (Convert.ToInt16(episode) < 10) { rchEpisodeDescription.Text += "0"; }
                    rchEpisodeDescription.Text += episode + " \"" + lstOverview.SelectedItems[0].SubItems[2].Text + "\": ";
                    int s = rchEpisodeDescription.Text.Length;
                    rchEpisodeDescription.Text += o.Rows[0].ItemArray[0].ToString();
                    rchEpisodeDescription.SelectionLength = s;
                    rchEpisodeDescription.SelectionColor = Color.Red;
                    rchEpisodeDescription.SelectionFont = new System.Drawing.Font(rchEpisodeDescription.SelectionFont, rchEpisodeDescription.SelectionFont.Style ^ FontStyle.Bold);
                }
                catch { currentSelected = lstOverview.FocusedItem.Index; }
            }
        }

        private void lblNextEpisode_Click(object sender, EventArgs e)
        {
            if (nextShowID != -1)
            {
                LoadInfoFromBanner(nextShowID.ToString());
                string[] b = lblNextEpisode.Text.Split('/');
                DataTable a = GetDataTable("SELECT episodeID FROM episodes WHERE episodeName = \"" + b[b.Count() - 1].Trim(' ') + "\"");
                ListViewItem item = new ListViewItem();
                item = lstOverview.Items[currentEpisodes.IndexOf(Convert.ToInt32(a.Rows[0].ItemArray[0].ToString()))];
                lstOverview.EnsureVisible(item.Index);
                lstOverview.Items[item.Index].Focused = true;
                lstOverview.Items[item.Index].Selected = true;
                lstOverview.Select();
            }
        }

        private void timerNotify_Tick(object sender, EventArgs e)
        {
            //before
            DataTable n = GetDataTable("SELECT series.name, episodes.seasonNumber, episodes.episodeNumber, episodes.episodeName, notify.beforeTime FROM series, episodes INNER JOIN notify ON"
                + " episodes.seriesID = notify.seriesID AND episodes.seriesID = series.id WHERE (notify.beforeAfter = 0 OR notify.beforeAfter = 2) AND"
                + " datetime('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','+' || notify.beforeTime || \" minutes\") = datetime(episodes.dateAired || \" \" || series.airsTime)");
            if (n.Rows.Count>0)
            {
                notifyIcon1.BalloonTipText = n.Rows[0].ItemArray[0].ToString() + " S" + n.Rows[0].ItemArray[1].ToString() + "E" + n.Rows[0].ItemArray[2].ToString() + " airs in "
                    + n.Rows[0].ItemArray[4].ToString() + " minutes:\n\r" + n.Rows[0].ItemArray[3].ToString();
                notifyIcon1.BalloonTipTitle = "Miro TV Manager";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(1000);

                DataTable p = GetDataTable("SELECT prowl FROM settings");
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("apikey", p.Rows[0].ItemArray[0].ToString());
                d.Add("application", "Miro TV Manager");
                d.Add("event", n.Rows[0].ItemArray[0].ToString().Replace("&", "%26") + " S" + n.Rows[0].ItemArray[1].ToString() + "E" + n.Rows[0].ItemArray[2].ToString());
                d.Add("description", "\"" + n.Rows[0].ItemArray[3].ToString().Replace("&", "%26") + "\" airs in "+ n.Rows[0].ItemArray[4].ToString() + " minutes");
                sendPOST("https://api.prowlapp.com/publicapi/add", d);
            }
            //after
            DataTable a = GetDataTable("SELECT series.name, episodes.seasonNumber, episodes.episodeNumber, episodes.episodeName, episodes.dateAired, notify.beforeTime FROM series, episodes INNER JOIN notify ON"
                + " episodes.seriesID = notify.seriesID AND episodes.seriesID = series.id WHERE notify.beforeAfter >= 1 AND"
                + " datetime('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "') = datetime(episodes.dateAired || \" \" || series.airsTime, '+' || series.runtime || ' minutes')");
            if (a.Rows.Count > 0)
            {
                notifyIcon1.BalloonTipText = a.Rows[0].ItemArray[0].ToString() + " S" + a.Rows[0].ItemArray[1].ToString() + "E" + a.Rows[0].ItemArray[2].ToString() + " has finished airing!";
                notifyIcon1.BalloonTipTitle = "Miro TV Manager";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(1000);

                DataTable p = GetDataTable("SELECT prowl FROM settings");
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("apikey", p.Rows[0].ItemArray[0].ToString());
                d.Add("application", "Miro TV Manager");
                d.Add("event", a.Rows[0].ItemArray[0].ToString().Replace("&", "%26") + " S" + a.Rows[0].ItemArray[1].ToString() + "E" + a.Rows[0].ItemArray[2].ToString());
                d.Add("description", "Has finished airing");
                sendPOST("https://api.prowlapp.com/publicapi/add", d);
            }
            //yay, now waiting for series to come back...or I could just change my time...nah...I'll wait for a nice evening...
        }

        private void checkNewSeasons()
        {
            DataTable n = GetDataTable("SELECT series.name, episodes.seasonNumber, episodes.episodeNumber, episodes.episodeName, datetime(episodes.dateAired || \" \" || series.airsTime), series.id"
                + " FROM series, episodes INNER JOIN notify ON episodes.seriesID = notify.seriesID AND episodes.seriesID = series.id WHERE notify.newSeason = 1 AND episodes.seasonNumber > notify.currentSeason"
                + " AND datetime(episodes.dateAired || \" \" || series.airsTime) NOT NULL AND episodes.episodeNumber = 1 GROUP BY episodes.seasonNumber ORDER BY episodes.episodeNumber");
            if (n.Rows.Count>0)
            {
                string a = "";
                for (int c = 0; c < n.Rows.Count; c++)
                {
                    a += "\n\r" + n.Rows[c].ItemArray[0].ToString() + " S" + n.Rows[c].ItemArray[1].ToString() + "E" + n.Rows[c].ItemArray[2].ToString() + " \"" + n.Rows[c].ItemArray[3].ToString() + "\" airs on " + DateTime.Parse(n.Rows[c].ItemArray[4].ToString()).ToString("MM.dd.yyyy hh:mm " + ("tt").ToLower());
                    ExecuteNonQuery("UPDATE notify SET currentSeason = " + n.Rows[c].ItemArray[1].ToString() + " WHERE seriesID = " + n.Rows[c].ItemArray[5].ToString());
                }
                MessageBox.Show("New season dates are released! Here they are:\n\r" + a, "Miro TV Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkMissedEpisodes()
        {
            DataTable m = GetDataTable("SELECT series.name, episodes.seasonNumber, episodes.episodeNumber, episodes.episodeName, episodes.dateAired FROM series, episodes INNER JOIN notify ON episodes.seriesID = notify.seriesID AND"
            + " episodes.seriesID = series.id INNER JOIN watch ON watch.episodeID = episodes.episodeID WHERE notify.notifyWatch = 1 AND watch.seen = 0"
            + " AND episodes.seasonNumber > 0 AND episodes.dateAired NOT NULL AND datetime(episodes.dateAired || \" \" || series.airsTime) > datetime('now','-1 month','localtime') AND datetime(episodes.dateAired || \" \" || series.airsTime) < datetime('now')"
            + " ORDER BY series.name, episodes.seasonNumber, episodes.episodeNumber");
            if (m.Rows.Count>0)
            {
                string a = "";
                for (int b = 0; b < m.Rows.Count; b++)
                    a += "\n\r" + m.Rows[b].ItemArray[0].ToString() + " S" + m.Rows[b].ItemArray[1].ToString() + "E" + m.Rows[b].ItemArray[2].ToString() + ": " + m.Rows[b].ItemArray[3].ToString() + " // " + m.Rows[b].ItemArray[4].ToString();
                MessageBox.Show("Oh no! You've missed the following episodes within the past month:\n\r" + a, "Miro TV Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void checkEndedSeries()
        {
            //Shouldn't be hard...
            DataTable e = GetDataTable("SELECT series.name, series.id FROM series INNER JOIN favorites ON series.id = favorites.id WHERE status = 0");
            if (e.Rows.Count>0)
            {
                string ended = "";
                for (int a = 0; a < e.Rows.Count; a++)
                    ended += "\n\r-" + e.Rows[a].ItemArray[0].ToString();
                if (MessageBox.Show("Good news everyone! The following series have ended:\n\r" + ended + "\n\r\n\rWould you like me to remove them from your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    for (int b = 0; b < e.Rows.Count; b++)
                        deleteSeries(e.Rows[b].ItemArray[1].ToString());
                    forceUpdate(false);
                }
            }
        }

        private void frmMainV3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                DataTable s = GetDataTable("SELECT minimizeClose FROM settings");
                if (s.Rows[0].ItemArray[0].ToString() == "1")
                {
                    e.Cancel = true;
                    this.Hide();
                    notifyIcon1.Visible = true;
                }
                else
                    notifyIcon1.Dispose();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
                this.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            exit = true;
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //alright, lets add the series to favorites, and reload the side
            if (MessageBox.Show("Are you sure you want to add \"" + txtTitle.Text + "\" to your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnAdd.Enabled = false;
                DataTable a = GetDataTable("SELECT thetvdbUsername FROM settings");
                if (a.Rows.Count > 0)
                {
                    string j = getJSON(APIurl + "/user/favorites/" + currentSearchID, token, 2);
                    if (j == "404")
                        MessageBox.Show("An error has occured. Please try again, or contact miro@miroppb.com");
                    else
                    {
                        ExecuteNonQuery("INSERT INTO favorites VALUES(" + currentSearchID + ", \"" + txtTitle.Text + "\");");
                        DataTable b = GetDataTable("SELECT * FROM favorites ORDER BY name");
                        int c = 0;
                        while (c < b.Rows.Count && b.Rows[c].ItemArray[1].ToString() != txtTitle.Text)
                            c++;
                        //get last digit, determine which 0 or 5 is before it, and updateTop5
                        int cc = -1;
                        if (c < 10)
                            cc = c;
                        else
                            cc = Convert.ToInt16(c.ToString().Remove(0, 1));
                        int aa = 0;
                        while (cc != 0 && cc != 5)
                        {
                            cc--;
                            aa++;
                        }
                        changeCurrent5Series(c - aa);
                    }
                }
                else
                {
                    ExecuteNonQuery("INSERT INTO favorites VALUES(" + currentSearchID + ", \"" + txtTitle.Text + "\");");
                    DataTable b = GetDataTable("SELECT * FROM favorites ORDER BY name");
                    int c = 0;
                    while (c < b.Rows.Count && b.Rows[c].ItemArray[1].ToString() != txtTitle.Text)
                        c++;
                    //get last digit, determine which 0 or 5 is before it, and updateTop5
                    int cc = -1;
                    if (c < 10)
                        cc = c;
                    else
                        cc = Convert.ToInt16(c.ToString().Remove(0, 1));
                    int aa = 0;
                    while (cc != 0 && cc != 5)
                    {
                        cc--;
                        aa++;
                    }
                    changeCurrent5Series(c - aa);
                }
            }
        }

        private void timerMorning_Tick(object sender, EventArgs e)
        {
            DataTable a = GetDataTable("SELECT settings.updateEvery, settings.updateAt FROM settings WHERE settings.updateSeries = 1");
            DateTime u = DateTime.Now;
            string[] b = a.Rows[0].ItemArray[0].ToString().Split(',');
            string c = lblUpdated.Text.Replace("Last Updated: ", "");
            if (c!= "Last Updated:")
            {
                switch (Convert.ToInt16(b[1]))
                {
                    case 0:
                        u = DateTime.Parse(c).AddHours(Convert.ToInt16(b[0]));
                        break;
                    case 1:
                        u = DateTime.Parse(DateTime.Parse(c).AddDays(Convert.ToInt16(b[0])).ToShortDateString() + " " + a.Rows[0].ItemArray[1].ToString());
                        break;
                    case 2:
                        u = DateTime.Parse(DateTime.Parse(c).AddMonths(Convert.ToInt16(b[0])).Month.ToString() + "/" + a.Rows[0].ItemArray[1].ToString() + "/" + DateTime.Now.Year);
                        break;
                }
                if ((DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()) == (u.ToShortDateString() + " " + u.ToShortTimeString()))
                    forceUpdate(true);
            }
        }

        private void deleteSeries(string v)
        {
            //alright, this should be easy, right?
            DataTable r = GetDataTable("SELECT name FROM favorites WHERE id = " + v);
            if (MessageBox.Show("Are you sure you want to remove \"" + r.Rows[0].ItemArray[0].ToString() + "\" from your favorites?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable a = GetDataTable("SELECT thetvdbUsername FROM settings");
                if (a.Rows.Count > 0)
                {
                    string j = getJSON(APIurl + "/user/favorites/" + v, token, 3);
                    if (j == "404")
                        MessageBox.Show("An error has occured. Please try again, or contact miro@miroppb.com");
                    else
                    {
                        ExecuteNonQuery("DELETE FROM favorites WHERE id = " + v);
                        changeCurrent5Series(current5);
                    }
                }
                else
                {
                    ExecuteNonQuery("DELETE FROM favorites WHERE id = " + v);
                    changeCurrent5Series(current5);
                }
                if (txtTitle.Text == r.Rows[0].ItemArray[0].ToString())
                    btnAdd.Enabled = true;
            }
        }

        private void pcbxDel1_Click(object sender, EventArgs e)
        {
            if (pcbxDel1.Cursor == Cursors.Hand)
                deleteSeries(pcbxSeries1.Tag.ToString());
        }        

        private void pcbxDel2_Click(object sender, EventArgs e)
        {
            if (pcbxDel2.Cursor == Cursors.Hand)
                deleteSeries(pcbxSeries2.Tag.ToString());
        }

        private void pcbxDel3_Click(object sender, EventArgs e)
        {
            if (pcbxDel3.Cursor == Cursors.Hand)
                deleteSeries(pcbxSeries3.Tag.ToString());
        }

        private void pcbxDel4_Click(object sender, EventArgs e)
        {
            if (pcbxDel4.Cursor == Cursors.Hand)
                deleteSeries(pcbxSeries4.Tag.ToString());
        }

        private void pcbxDel5_Click(object sender, EventArgs e)
        {
            if (pcbxDel5.Cursor == Cursors.Hand)
                deleteSeries(pcbxSeries5.Tag.ToString());
        }

        private void btnSeenAll_Click(object sender, EventArgs e)
        {
            DataTable s = GetDataTable("SELECT watch.episodeID, series.name FROM episodes, series INNER JOIN watch ON watch.episodeID = episodes.episodeID"
                + " AND series.id = episodes.seriesID WHERE datetime(episodes.dateAired || \" \" || series.airsTime) < datetime('now','localtime') AND watch.seriesID = " + currentSearchID
                + " AND episodes.seasonNumber > 0 ORDER BY episodes.dateAired");
            if (MessageBox.Show("Are you sure you want to mark all previous sesaons (not specials) of \"" + s.Rows[0].ItemArray[1].ToString() + "\" as seen?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int a = 0; a < s.Rows.Count; a++)
                    ExecuteNonQuery("UPDATE watch SET seen = 1 WHERE episodeID = " + s.Rows[a].ItemArray[0].ToString());
                LoadInfoFromBanner(currentSearchID);
            }
        }

        private void forceUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to do a full update?\n\r(This will take a few minutes)", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ExecuteNonQuery("UPDATE series SET lastUpdated = NULL");
            forceUpdate(true);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            versionCheck(true);
        }

        private void versionCheck(bool popup)
        {
            if (internet)
            {
                checkAgain:;
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

        private async void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Miro TV Manager Database|*.mtvm";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dbConnection.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                await Task.Delay(1000);
                File.Copy(path + "database.sqlite", sfd.FileName, true);
                MessageBox.Show("Backup created: " + sfd.FileName);

                dbConnection = new SQLiteConnection("Data Source=" + path + "database.sqlite;Version=3;");
            }
        }

        private async void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The current database will be deleted. Are you sure you want to replace it?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Miro TV Manager Database|*.mtvm";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    
                    dbConnection.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    await Task.Delay(1000);
                    File.Delete(path + "database.sqlite");
                    File.Copy(ofd.FileName, path + "database.sqlite");

                    dbConnection = new SQLiteConnection("Data Source=" + path + "database.sqlite;Version=3;");

                    DataTable version;
                    string query = "SELECT settingsVersion FROM settings";
                    version = GetDataTable(query);
                    if (version.Rows[0].ItemArray[0].ToString() != settingsVersion)
                    {
                        //downloading updateDatabase file
                        WebClient wc = new WebClient();
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadFileAsync(new Uri("http://miroppb.com/TVManager/update/" + version.Rows[0].ItemArray[0].ToString().Replace(".", "") + "to" + settingsVersion.Replace(".", "") + ".txt"), path + "updateDatabase.sql");
                    }
                    forceUpdate(true);
                }
            }
        }

        private void CheckForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to check for any series updates?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                forceUpdate(true);
        }

        private void UpdateCurrentSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to force update \"" + txtTitle.Text + "\"?", "Miro TV Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExecuteNonQuery("UPDATE series SET lastUpdated = NULL WHERE id = " + currentSearchID);
                searchSeries(txtTitle.Text, true);
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Search...";
        }

        private void WhatShowEndedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkEndedSeries();
        }

        private void TimerPlex_Tick(object sender, EventArgs e)
        {
            if (plex != "")
            {
                List<string> z = new List<string>();
                //lets see what we can do with this info...
                dbConnection.Close();
                GC.Collect();
                dbConnection = new SQLiteConnection("Data Source=" + plex + ";Version=3");
                DataTable p = GetDataTable("SELECT * FROM metadata_item_views WHERE account_id = 1 AND viewed_at > '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:00") + "'");
                foreach (DataRow d in p.Rows)
                {
                    string se = d.ItemArray[5].ToString();
                    string s = d.ItemArray[6].ToString();
                    string ep = d.ItemArray[8].ToString();
                    z.Add(se + ";" + s + ";" + ep);
                }
                dbConnection.Close();
                GC.Collect();
                dbConnection = new SQLiteConnection("Data Source=" + path + "database.sqlite;Version=3;");
                foreach (string d in z)
                {
                    string[] a = d.Split(';');
                    DataTable q = GetDataTable("SELECT episodeID FROM episodes WHERE seriesID = (SELECT id FROM series WHERE name = '" + a[0] + "') AND seasonNumber = " + a[1] + " AND episodeNumber = " + a[2]);
                    if (q.Rows.Count > 0)
                    {
                        string ep = q.Rows[0].ItemArray[0].ToString();
                        ExecuteNonQuery("UPDATE watch SET seen = 1 WHERE episodeID = " + ep);
                    }
                }
            }
        }

        private bool refreshToken(bool popup)
        {
            DataTable settings;
            settings = GetDataTable("SELECT thetvdbUsername, thetvdbID FROM settings");
            bool linked = true;
            if (settings.Rows[0].ItemArray[0].ToString() == "")
            {
                if (popup)
                    MessageBox.Show("You haven't linked this application to your theTVDB.com account. Only your currently saved favorites will be updated.\n\rPlease link you account by going into Settings.");
                linked = false;
                return false;
            }
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", API);
            if (linked)
            {
                //data.Add("username", settings.Rows[0].ItemArray[0].ToString()); //V3.0 11.14.19
                data.Add("userkey", settings.Rows[0].ItemArray[1].ToString()); 
            }
            string url = APIurl + "/login";
            string json = thetvdbLogin(data, url);

            if (updateFailed || json == "failed")
            {
                updateFailed = false;
                return false;
            }

            RootObject_token t = JsonConvert.DeserializeObject<RootObject_token>(json);
            token = t.token;
            return true;
        }

        private void ReloadCurrentSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSearchID != "")
            {
                LoadInfoFromBanner(currentSearchID);
            }
        }
    }
}
