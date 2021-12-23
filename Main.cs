using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            BHVRSeession.OnTokenReceived += Initiate;
        }
        public static void Initiate(string bhvrSession)
        {
            if (Grabbing)
            {
                BHVRSeession.Stop();
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToUpper().Contains("DAYLIGHT"))
                    {
                        process.Kill();
                    }
                }
                if (Host == "steam")
                {
                    Utils.Resurrect(Utils.GetModulePath());
                }
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Successfully Grabbed cookie, Navigate to Injector section to use it");
                Grabbing = false;
            }
            Initiated = true;
            owo = true;
            bhvrSession.Replace(" ", string.Empty      );
            BHVRSession = bhvrSession.Replace("bhvrSession=", string.Empty);
            
        }
        public static bool Initiated = false;
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public static string Host;
        public static string Kraken;
        public static string UserAgent;
        public static string BHVRSession;
        public static bool Grabbing;
        public static bool owo = false;
        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
         //   Ismail.Backdrop.Show(new Settings(), this);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (!owo)
            {
                MessageBox.Show("Please grab your cookie first");
                siticoneButton2.PerformClick();
                return;
            }
            FormsMakeMeHorny123.Controls.Clear();
            Injector.Inject bhvrisgay = new Injector.Inject();
            bhvrisgay.TopLevel = false;
            bhvrisgay.AutoScroll = true;
            FormsMakeMeHorny123.Controls.Add(bhvrisgay);
            bhvrisgay.Show();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            FormsMakeMeHorny123.Controls.Clear();
            BHVRSession bhvrisgay = new BHVRSession();
            bhvrisgay.TopLevel = false;
            bhvrisgay.AutoScroll = true;
            FormsMakeMeHorny123.Controls.Add(bhvrisgay);
            bhvrisgay.Show();
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            FormsMakeMeHorny123.Controls.Clear();
            Spoofer.Spoofer bhvrisgay = new Spoofer.Spoofer();
            bhvrisgay.TopLevel = false;
            bhvrisgay.AutoScroll = true;
            FormsMakeMeHorny123.Controls.Add(bhvrisgay);
            bhvrisgay.Show();
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            FormsMakeMeHorny123.Controls.Clear();
            Unlocker bhvrisgay = new Unlocker();
            bhvrisgay.TopLevel = false;
            bhvrisgay.AutoScroll = true;
            FormsMakeMeHorny123.Controls.Add(bhvrisgay);
            bhvrisgay.Show();
        }
    }
}
