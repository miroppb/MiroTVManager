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
    public partial class frmMainV3 : Form
    {
        //common variables
        public const string API = "B6A934518784BE16";
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Miro TV Manager\";
        public string settingsVersion = "3.0.0.0";
        public string accountID = "";
        public bool favoritesExist = false;
        public bool internet = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        string currentSearchID = "";

        public frmMainV3()
        {
            InitializeComponent();
        }
    }
}
