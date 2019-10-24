using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ModelLibrary;
using static Contact_App.Program;

namespace Contact_App
{
    public partial class UserAccessControl : Form
    { 

        public UserAccessControl()
        {
            InitializeComponent();
        }

        private void UserAccessControl_Load(object sender, EventArgs e)
        {
            lstUsers.DataSource = Program.Entities.users.ToList();
        }

        
        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUser = (user)lstUsers.SelectedItem;
            wtrUserName.Text = selectedUser.username;
            wtrPassword.Text = selectedUser.password;
            Program.UserAccessOptions uac = (Program.UserAccessOptions)selectedUser.accessflags;

            chkEditRecords.Checked = ((uac & Program.UserAccessOptions.Edit) == Program.UserAccessOptions.Edit);

            chkView.Checked = ((uac & Program.UserAccessOptions.View) == Program.UserAccessOptions.View);

            chkAdmin.Checked = ((uac & Program.UserAccessOptions.UserControl) == Program.UserAccessOptions.UserControl);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
            if (!ValidateData())
            {
                return;
            }

            user u = CollectSettings();
            if (u.username.Equals(Program.user.username)){
                UserAccessOptions uac = (UserAccessOptions)u.accessflags;
                if (!((uac & UserAccessOptions.UserControl) == UserAccessOptions.UserControl))
                {
                    toolStripStatusLabel.Text = "Cannot remove Administrative options from self.";
                    chkAdmin.Checked = true;
                    return;
                }
            }


            try
            {
                user record = Program.Entities.users.First(a => a.id == u.id);
                record.username = u.username;
                record.email = u.email;
                record.accessflags = u.accessflags;
                record.password = u.password;
                toolStripStatusLabel.Text = $"User: {u.username} updated.";
            }
            catch (InvalidOperationException)
            {
                toolStripStatusLabel.Text = $"User: {u.username} added.";
                Program.Entities.users.Add(u);   
            }
            catch (Exception)
            {
                toolStripStatusLabel.Text = "Unknown error happened.";
            }
            finally
            {
                try
                {
                    Program.Entities.SaveChanges();
                }catch
                {
                    toolStripStatusLabel.Text = "Error saving changes to database.";
                }
            }
            
        }

        private user CollectSettings()
        {
            user u = (user)lstUsers.SelectedItem;
            u.username = wtrUserName.Text;
            u.email = wtrPassword.Text;
            Program.UserAccessOptions uao = new Program.UserAccessOptions();
            if (chkAdmin.Checked)
            {
                uao |= Program.UserAccessOptions.UserControl;
            }
            if (chkEditRecords.Checked)
            {
                uao |= Program.UserAccessOptions.Edit;
            }
            if (chkView.Checked)
            {
                uao |= Program.UserAccessOptions.View;
            }
            u.accessflags = (byte)uao;

            return u;

        }

        private bool ValidateData()
        {
            var regexName = new Regex(@"\W");
            StringBuilder errorMessage = new StringBuilder();
            if (wtrUserName.Text == string.Empty)
            {
                errorMessage.Append("User name cannot be blank. ");
            }
            else if (wtrUserName.Text.Contains(" "))
            {
                errorMessage.Append("User name cannot contain spaces. ");
            }
            else if (regexName.IsMatch(wtrUserName.Text))
            {
                errorMessage.Append("User name contains invalid characters. ");
            }
            if (wtrPassword.Text.Equals(string.Empty))
            {
                errorMessage.Append("Password cannot be empty. ");
            }

            if (errorMessage.Length > 0)
            {
                toolStripStatusLabel.Text = errorMessage.ToString();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender , EventArgs e)
        {
            wtrPassword.Text = string.Empty;
            wtrUserName.Text = string.Empty;
            foreach (var item in this.Controls)
            {
                if (item is CheckBox)
                {
                    (item as CheckBox).Checked = false;
                }

            }
        }

        private void btnRemove_Click(object sender , EventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                if ((lstUsers.SelectedItem as user).Equals(Program.user))
                {
                    toolStripStatusLabel.Text = "Cannot remove own user.";
                }
            }
        }
    }
}
