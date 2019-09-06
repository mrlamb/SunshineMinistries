using Transportation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Contact_App
{
    public partial class MainForm : Form
    {


        Socket mySocket;
        Guid id;
        public MainForm()
        {
            InitializeComponent();
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
            mySocket = Transport.ConnectSocket();

        }

        private void MessageReceivedEventHandler(StringBuilder sb, List<Byte> lb)
        {
            TransportProtocol tp = new TransportProtocol();

            byte[] message = new byte[lb.Count - 1];

            tp = (TransportProtocol)lb.First();
            lb.RemoveAt(0);
            lb.CopyTo(message);

            switch (tp)
            {
                case TransportProtocol.SEND_GUID:
                    id = new Guid(message);
                    ThreadSafeControl.SetTextStatusLabel(this, statusLabel, "Connected with session id: " + id.ToString());
                    break;
                case TransportProtocol.SEND_LOGIN:
                    break;
                default:
                    break;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }

        }


        private void FillDataGridView()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvContacts_DoubleClick(object sender, EventArgs e)
        {

        }

        void Reset()
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }


        private void TxtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgvContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAddress_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DgvContacts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {

        }

        private void Fax_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            this.Hide();
            Form2 f2 = new Contact_App.Form2();
            f2.ShowDialog();


        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals(string.Empty))
            {
                lblLoginHelp.Text = "Username cannot be blank.";
            }
            else
            {
                lblLoginHelp.Text = string.Empty;
                byte[] message = new byte[1 + txtUserName.Text.Length];
                message[0] = (byte)TransportProtocol.SEND_LOGIN;
                Encoding.ASCII.GetBytes(txtUserName.Text).CopyTo(message, 1);

                mySocket.Send(message);
            }
        }
    }
}
