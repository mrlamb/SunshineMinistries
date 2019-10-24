using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using ModelLibrary;

namespace Contact_App
{
    public partial class LoginBox : Form
    {
        public bool Authentication_Success = false;
        private bool bypassLogin = true;

        public LoginBox()
        {
            InitializeComponent();
            this.ActiveControl = wtrUserName;
            
            wtrPassword.Password = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!bypassLogin)
            {
                if (wtrUserName.Text.Equals(string.Empty))
                {
                    lblLoginStatus.Text = "Username cannot be blank.";
                    return;
                }
            }
            else
            {
                lblLoginStatus.Text = string.Empty;
                user u = Program.Entities.users.FirstOrDefault(a => a.username.ToLower().Equals(wtrUserName.Text.ToLower()));
                if (null != u)
                {
                    if (u.password.Equals(wtrPassword.Text))
                    {
                        lblLoginStatus.Text = "User authenticated.";
                        Authentication_Success = true;
                        Program.user = u;
                        Program.UserOptions = (Program.UserAccessOptions)u.accessflags;
                        Close();
                    }
                    else
                    {
                        lblLoginStatus.Text = "Password failed.";
                    }
                }
                else
                {
                    lblLoginStatus.Text = "User not found.";
                }
            }

        }
    }
}
