using Eclipsed_Panel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel
{
    public partial class Injectorrr : Form
    {
        public Injectorrr()
        {
            InitializeComponent();
        }

        private void siticoneRoundedButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "Save File backup.txt";
            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string text = InjectorRequests.Injector.Dump_FullProfile();
            File.WriteAllText(saveFileDialog.FileName, JsonHelper.FormatJson(SaveFile.DecryptSavefile(text)));
        }

        private void siticoneRoundedButton5_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(Path.GetTempPath() + "Editor.exe", Properties.Resources.DBD_Save_Editor_v2);
            File.WriteAllBytes(Path.GetTempPath() + "dbd.db", Properties.Resources.dbd);
            Process.Start(Path.GetTempPath() + "Editor.exe");
        }

        private void siticoneRoundedButton3_Click(object sender, EventArgs e)
        {
            string input = System.Text.Encoding.UTF8.GetString(Login.KeyAuthApp.download("706258"));
            string input2 = System.Text.Encoding.UTF8.GetString(Login.KeyAuthApp.download("130875"));
            File.WriteAllText("FullProfile No Legacy.txt", input2);
            File.WriteAllText("FullProfileLegacy.txt", input);

        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            string content = new WebClient().DownloadString("https://cdn.discordapp.com/attachments/891068941697441872/893884252997943386/Decrypted_Save_File_backup.txt");
            if ((InjectorRequests.Injector.Dump_FullProfile() != null) & InjectorRequests.Injector.Inject_FullProfile(SaveFile.EncryptSavefile(content)))
            {
                Login.KeyAuthApp.UpdateInjects();
                SystemSounds.Asterisk.Play();
            }
            else
            {
                MessageBox.Show("ERROR: failed to inject FullProfile.txt");
            }
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = "SaveFile";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((InjectorRequests.Injector.Dump_FullProfile() != null) & InjectorRequests.Injector.Inject_FullProfile(SaveFile.EncryptSavefile(File.ReadAllText(openFileDialog.FileName))))
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
