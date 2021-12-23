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

namespace Demon_Panel
{
    public partial class SimpleInjector : Form
    {
        public SimpleInjector()
        {
            InitializeComponent();
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            if (Legacy.Checked == true)
            {
                string input = System.Text.Encoding.UTF8.GetString(Login.KeyAuthApp.download("706258"));
                new Random();
                string content = Regex.Replace(input, Regex.Escape(",600\""), (Match m) => $",{siticoneRoundedNumericUpDown1.Value}\"");
                if ((InjectorRequestsDADDY.Injector.Dump_FullProfile() != null) & InjectorRequestsDADDY.Injector.Inject_FullProfile(SaveFile.EncryptSavefile(content)))
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
                new Random();
                string content2 = Regex.Replace(input2, Regex.Escape(",600\""), (Match m) => $",{siticoneRoundedNumericUpDown1.Value}\"");
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
