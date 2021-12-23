using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel.Injector
{
    public partial class Inject : Form
    {
        public Inject()
        {
            InitializeComponent();
        }

        private void BHVRSession_Load(object sender, EventArgs e)
        {
            guna2Button2.PerformClick();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadFormsForBigPP.Controls.Clear();
            Injectorrr inject = new Injectorrr();
            inject.TopLevel = false;
            inject.AutoScroll = true;
            LoadFormsForBigPP.Controls.Add(inject);
            inject.Show();
        }

        private void LoadFormsForBigPP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadFormsForBigPP.Controls.Clear();
            SimpleInjector inject = new SimpleInjector();
            inject.TopLevel = false;
            inject.AutoScroll = true;
            LoadFormsForBigPP.Controls.Add(inject);
            inject.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LoadFormsForBigPP.Controls.Clear();

            Random.RandomizedItems inject = new Random.RandomizedItems();
            inject.TopLevel = false;
            inject.AutoScroll = true;
            LoadFormsForBigPP.Controls.Add(inject);
            inject.Show();
        }
    }
}
