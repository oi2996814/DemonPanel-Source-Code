using KeyAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string name = "DemonPanel"; // application name. right above the blurred text aka the secret on the licenses tab among other tabs
        static string ownerid = "**********************************"; // ownerid, found in account settings. click your profile picture on top right of dashboard and then account settings.
        static string secret = "*************"; // app secret, the blurred text on licenses tab and other tabs
        static string version = "1.0"; // leave alone unless you've changed version on website

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        public static void Init()
        {
            KeyAuthApp.init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart eauthinit = new ThreadStart(Init);
            Thread keyauthoinito = new Thread(eauthinit);
            keyauthoinito.Start();
            siticonePanel2.Hide();
            siticonePanel3.Hide();
            siticoneTransition1.Show(siticonePanel2);
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            if (KeyAuthApp.login(user_login.Text, pass_login.Text))
            {
                Hide();
                new Main().Show();
            }

        }

        private void user_login_Enter(object sender, EventArgs e)
        {
            if (user_login.Text == "Username")
            {
                user_login.Text = "";
            }
        }

        private void user_login_Leave(object sender, EventArgs e)
        {
            if (user_login.Text == "")
            {
                user_login.Text = "Username";
            }
        }

        private void pass_login_Enter(object sender, EventArgs e)
        {
            if (pass_login.Text == "Password")
            {
                pass_login.PasswordChar = '●';
                pass_login.Text = "";
            }
        }

        private void pass_login_Leave(object sender, EventArgs e)
        {
            if (pass_login.Text == "")
            {
                pass_login.PasswordChar = '\0';
                pass_login.Text = "Password";
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            siticoneTransition1.Hide(siticonePanel2);
            siticoneTransition1.Show(siticonePanel3);
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            siticoneTransition1.Hide(siticonePanel3);
            siticoneTransition1.Show(siticonePanel2);
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            if (KeyAuthApp.register(User_Register.Text, Pass_Register.Text, KeyAuthApp.webhook("MlRjcHFWOm", "")))
            {
                KeyAuthApp.setvar("TotalInjects", "0");
                KeyAuthApp.setvar("TotalBPGenerated", "0");
                Hide();
                new Main().Show();
            }
        }

        private void user_register_Enter(object sender, EventArgs e)
        {
            if (User_Register.Text == "Username")
            {
                User_Register.Text = "";
            }
        }

        private void user_register_Leave(object sender, EventArgs e)
        {
            if (User_Register.Text == "")
            {
                User_Register.Text = "Username";
            }
        }

        private void pass_register_enter(object sender, EventArgs e)
        {
            if (Pass_Register.Text == "Password")
            {
                Pass_Register.PasswordChar = '●';
                Pass_Register.Text = "";
            }
        }

        private void pass_register_leave(object sender, EventArgs e)
        {
            if (Pass_Register.Text == "")
            {
                Pass_Register.PasswordChar = '\0';
                Pass_Register.Text = "Password";
            }
        }
    }
}
