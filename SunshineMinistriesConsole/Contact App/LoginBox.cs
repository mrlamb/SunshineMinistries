using System;
using Transportation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Contact_App
{
    public partial class LoginBox : Form
    {
        public bool Authentication_Success = false;
        private bool bypassLogin = true;

        public LoginBox()
        {
            InitializeComponent();
            this.ActiveControl = lblLoginStatus;
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
            wtrPassword.Password = true;
        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {
            MessageObj message = Transport.DeconstructMessage(lb);

            switch (message.Protocol)
            {
                case TransportProtocol.USER_NOT_FOUND:
                    ThreadSafeControl.SetText(this, lblLoginStatus, "User not found.");
                    break;
                case TransportProtocol.SEND_PASSWORD:
                    socket.Send(Transport.ConstructMessage(TransportProtocol.SEND_PASSWORD, wtrPassword.Text));
                    break;
                case TransportProtocol.AUTHENTICATED:
                    ThreadSafeControl.SetText(this, lblLoginStatus, "User authenticated.");
                    Transport.messageReceivedEvent -= MessageReceivedEventHandler;
                    Authentication_Success = true;
                    Invoke(new EventHandler (delegate { Close(); }));
                    
                    break;
                case TransportProtocol.PASS_FAILED:
                    ThreadSafeControl.SetText(this, lblLoginStatus, "Password failed.");
                    break;
                default:
                    break;
            }
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
                if (Program.stateObject.workSocket == null)
                    Program.stateObject.workSocket = Transport.ConnectSocket();
                Program.stateObject.workSocket.Send(Transport.ConstructMessage(TransportProtocol.SEND_USER, wtrUserName.Text));
            }

        }
    }
}
