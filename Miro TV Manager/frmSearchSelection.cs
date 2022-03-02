using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Miro_TV_Manager
{
    public partial class frmSearchSelection : Form
    {
        public int selected = -1;
        List<int> seriesID = new List<int>();
        List<string> ban = new List<string>();
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Miro TV Manager\";

        public frmSearchSelection()
        {
            InitializeComponent();
            this.BringToFront();
        }

        private void lstSeries_DoubleClick(object sender, EventArgs e)
        {
            selected = lstSeries.SelectedItems[0].Index;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //download image and show in pcbxSeries
            if (lstSeries.FocusedItem != null)
            {
                pcbxSeries.Image = null;
                System.IO.File.Delete(path + "banner.jpg");
                if (ban[lstSeries.FocusedItem.Index] == "")
                {
                    pcbxSeries.Image = Image.FromFile(path + "no_banner.png");
                }
                else
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileAsync(new Uri("http://thetvdb.com" + ban[lstSeries.FocusedItem.Index]), path + "banner.jpg");
                    while (wc.IsBusy) { }

                    System.IO.FileStream bmp = new System.IO.FileStream(path + "banner.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                    try
                    {
                        Image img = new Bitmap(bmp);
                        pcbxSeries.Image = img;
                    }
                    catch
                    {
                        pcbxSeries.Image = Image.FromFile(path + "no_banner.png");
                    }
                    bmp.Close();
                }
            }
        }

        internal void updateResults(List<int> id, List<string> series, List<string> overview, List<string> banners)
        {
            seriesID = id;
            ban = banners;
            for (int c = 0; c < series.Count; c++)
            {
                lstSeries.Items.Add(series[c]).SubItems.Add(overview[c]);
            }
        }
    }
}
