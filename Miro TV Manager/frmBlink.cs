using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miro_TV_Manager
{
    public partial class frmBlink : Form
    {
        int c = 0;
        public frmBlink()
        {
            InitializeComponent();
            c = 0;
        }

        private void frmBlink_Load(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            timer1.Start();
            timer1.Enabled = true;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (c < 1) { c++; } else { timer1.Stop(); timer1.Enabled = false; this.Hide(); }
        }
    }
}
