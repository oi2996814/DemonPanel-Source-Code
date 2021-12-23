using Fiddler;
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
    public partial class Unlocker : Form
    {
        public Unlocker()
        {
            InitializeComponent();
        }

   

        private void Unlocker_Load(object sender, EventArgs e)
        {
            Variable.Market = Encoding.UTF8.GetString(Login.KeyAuthApp.download("625130"));
            Variable.Savefile = Eclipsed_Panel.SaveFile.EncryptSavefile(Encoding.UTF8.GetString(Login.KeyAuthApp.download("130875")));
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
         
            DBDExploit.Bypass.PatchBefore(Variable.UseSteam);
            UnlockerImplement.Start();

              
            
        }

        private void siticoneRoundedButton3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox1.Checked)
            {
                Variable.Unlocker = true;
            }
            else
            {
                Variable.Unlocker= false;
            }
        }

        private void siticoneCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox2.Checked)
            {
                Variable.Devotion = true;
            }
            else
            {
                Variable.Devotion= false;
            }
        }

        private void siticoneCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox3.Checked)
            {
                Variable.CurrencySpoof = true;
            }
            else
            {
                Variable.CurrencySpoof = false;
            }
        }

        private void siticoneCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox5.Checked)
            {
                Variable.FreeBloodweb = true;
            }
            else
            {
                Variable.FreeBloodweb= false;
            }
        }

        private void siticoneCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox4.Checked)
            {
                Variable.AntiBotMatch = true;
            }
            else
            {
                Variable.AntiBotMatch= false;
            }
        }

        private void siticoneCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox9.Checked)
            {
                Variable.KillerRevealer = true;
            }
            else
            {
                Variable.KillerRevealer= false;
            }
        }

        private void siticoneCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox8.Checked)
            {
                Variable.NameSpoof = true;
            }
            else
            {
                Variable.NameSpoof= false;
            }
        }

        private void siticoneCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox10.Checked)
            {
                Variable.RemoveProxy = true;
            }
            else
            {
                Variable.RemoveProxy = false;
            }
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            Variable.Bloodpoints = siticoneTextBox1.Text;
        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
        {
            Variable.Shards = siticoneTextBox2.Text;
        }

        private void siticoneTextBox3_TextChanged(object sender, EventArgs e)
        {
            Variable.Aurics = siticoneTextBox3.Text;
        }

        private void siticoneTextBox5_TextChanged(object sender, EventArgs e)
        {
            Variable.Level = siticoneTextBox5.Text;
        }

        private void siticoneLabel4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox4_TextChanged(object sender, EventArgs e)
        {
            Variable.Devotionn = siticoneTextBox4.Text;
        }

        private void siticoneTextBox6_TextChanged(object sender, EventArgs e)
        {
            Variable.Playername = siticoneTextBox6.Text;
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox6.Checked)
            {
                Variable.UseSteam = true;
            }
            else
            {
                Variable.UseSteam = false;
            }
        }

        private void siticoneCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox7.Checked)
            {
                DBDExploit.Bypass.use_fov = true;
            }
            else
            {
                DBDExploit.Bypass.use_fov= false;
            }
        }
    }
}
