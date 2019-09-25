using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transportation;

namespace Contact_App
{
    public partial class UserAccessControl : Form
    {
        private byte formID = 19;
        private List<user> users;

        public UserAccessControl()
        {
            InitializeComponent();
        }

        private void UserAccessControl_Load(object sender, EventArgs e)
        {
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
            Program.stateObject.workSocket.Send(Transport.ConstructMessage(formID, TransportProtocol.SEND_ALL_USERS));
        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {
            MessageObj message = Transport.DeconstructMessage(lb);

            switch (message.Protocol)
            {
                case TransportProtocol.SEND_ALL_USERS:
                    users = JsonConvert.DeserializeObject<List<user>>(message.Message);
                    lstUsers.Invoke(new EventHandler(delegate{ lstUsers.DataSource = users; }));
                    break;
                default:
                    break;
            }
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUser = (user)lstUsers.SelectedItem;
            wtrUserName.Text = selectedUser.username;
            wtrEmail.Text = selectedUser.email;
            Program.UserAccessOptions uac = (Program.UserAccessOptions)selectedUser.accessflags;
            if((uac & Program.UserAccessOptions.Edit) == Program.UserAccessOptions.Edit)
            {
                chkEditRecords.Checked = true;
            }
            else
            {
                chkEditRecords.Checked = false;
            }
            if ((uac & Program.UserAccessOptions.View) == Program.UserAccessOptions.View)
            {
                chkView.Checked = true;
            }
            else
            {
                chkView.Checked = false;
            }
            if ((uac & Program.UserAccessOptions.UserControl) == Program.UserAccessOptions.UserControl)
            {
                chkAdmin.Checked = true;
            }
            else
            {
                chkAdmin.Checked = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
            if (!ValidateData())
            {
                return;
            }
            user record = CollectSettings();
            Program.stateObject.workSocket.Send(Transport.ConstructMessage(formID, TransportProtocol.UPDATE_USER,
                JsonConvert.SerializeObject(record)));
        }

        private user CollectSettings()
        {
            user u = (user)lstUsers.SelectedItem;
            u.username = wtrUserName.Text;
            u.email = wtrEmail.Text;
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
            

            if (errorMessage.Length > 0)
            {
                toolStripStatusLabel.Text = errorMessage.ToString();
                return false;
            }
            return true;
        }
    }
}
