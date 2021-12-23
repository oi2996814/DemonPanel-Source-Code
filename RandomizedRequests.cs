using Eclipsed_Panel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel.Injector.Random
{
    public partial class RandomizedItems : Form
    {
        public RandomizedItems()
        {
            InitializeComponent();
        }

        private void RandomizedItems_Load(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            if (Legacy.Checked == true)
            {
                string input2 = System.Text.Encoding.UTF8.GetString(Login.KeyAuthApp.download("706258"));
                int mini = Convert.ToInt32(MinValue.Value);
                int maxx2 = Convert.ToInt32(MaxValue.Value);
                System.Random rand = new System.Random();
                string content2 = Regex.Replace(input2, Regex.Escape(",600\""), (Match m) => $",{rand.Next(mini, maxx2)}\"");
                if ((InjectorRequestsDADDY.Injector.Dump_FullProfile() != null) & InjectorRequestsDADDY.Injector.Inject_FullProfile(SaveFile.EncryptSavefile(content2)))
                {
                    Login.KeyAuthApp.UpdateInjects();
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    MessageBox.Show("ERROR: failed to inject FullProfile.txt");
                }
            }
            else
            {
                string input2 = System.Text.Encoding.UTF8.GetString(Login.KeyAuthApp.download("130875"));
                int mini = Convert.ToInt32(MinValue.Value);
                int maxx2 = Convert.ToInt32(MaxValue.Value);
                System.Random rand = new System.Random();
                string content2 = Regex.Replace(input2, Regex.Escape(",600\""), (Match m) => $",{rand.Next(mini, maxx2)}\"");
                if ((InjectorRequestsDADDY.Injector.Dump_FullProfile() != null) & InjectorRequestsDADDY.Injector.Inject_FullProfile(SaveFile.EncryptSavefile(content2)))
                {
                    Login.KeyAuthApp.UpdateInjects();
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    MessageBox.Show("ERROR: failed to inject FullProfile.txt");
                }
            }
        }
    }
}
