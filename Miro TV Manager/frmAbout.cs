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

namespace Miro_TV_Manager
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            lblVersion.Text = "v. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                + Environment.NewLine + "© 2013-" + DateTime.Now.Year + " Miro";
        }

        private void pcbxLogo_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://miroppb.com");
        }

        private void lnkTHETVDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://thetvdb.com");
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"mailto:miro@miroppb.com");
        }

        private void pcbxTheTVDB_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://thetvdb.com");
        }

        private void pcbxTwitter_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://twitter.com/miroppb");
        }
    }
}
