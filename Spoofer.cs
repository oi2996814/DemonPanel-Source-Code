using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel.Spoofer
{
    public partial class Spoofer : Form
    {
        public Spoofer()
        {
            InitializeComponent();
        }

		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes("CumSex123NobodyIsReadingThis12321321312313.sys", Login.KeyAuthApp.download("768451"));
            File.WriteAllBytes("UWU.exe", Login.KeyAuthApp.download("197692"));
            Process.Start("UWU.exe", "CumSex123NobodyIsReadingThis12321321312313.sys");
            Thread.Sleep(500);
            new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/894219859750170685/923523083548098580/mac.bat", "C:\\Windows\\Mac.bat");
            Process.Start("C:\\Windows\\Mac.bat");
           File.Delete("CumSex123NobodyIsReadingThis12321321312313.sys");
        }

        private void Spoofer_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher moSearcher = new
ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            string ee = "e";
            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
               
                ee= wmi_HD["SerialNumber"].ToString(); 

            }
            String firstMacAddress = NetworkInterface
    .GetAllNetworkInterfaces()
    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    .Select(nic => nic.GetPhysicalAddress().ToString())
    .FirstOrDefault();
            siticoneLabel1.Text = $"Disk: {ee} MAC: {firstMacAddress}";
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher moSearcher = new
ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            string ee = "e";
            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {

                ee= wmi_HD["SerialNumber"].ToString();

            }
            String firstMacAddress = NetworkInterface
    .GetAllNetworkInterfaces()
    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    .Select(nic => nic.GetPhysicalAddress().ToString())
    .FirstOrDefault();
            siticoneLabel1.Text = $"Disk: {ee} MAC: {firstMacAddress}";
        }
    }
}
