using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel
{
    public partial class BHVRSession : Form
    {
        public BHVRSession()
        {
            InitializeComponent();
        }

        private void BHVRSession_Load(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            Main.Grabbing = true;
            BHVRSeession.start();
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        { 
            Main.Grabbing = true;
            Main.Host = "steam";
            Main.Kraken = "host";
            BHVRSeession.start();
        }
    }
}
