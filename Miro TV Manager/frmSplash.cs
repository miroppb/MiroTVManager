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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(2000);
            frmMainV3 frm = new frmMainV3();
            frm.Show();
            this.Hide();
        }
    }
}
