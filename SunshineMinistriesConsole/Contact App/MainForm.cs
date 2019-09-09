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
        public StateObject stateObject { get; set; }
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<Byte> lb)
        {
            MessageObj mo = new MessageObj();
            mo = Transport.DeconstructMessage(lb);

            switch (mo.Protocol)
            {
                case TransportProtocol.SEND_GUID:
                    break;
                case TransportProtocol.SEND_USER:
                    break;
                case TransportProtocol.MESSAGE_BOX:
                    MessageBox.Show(mo.Message);
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

        private void MainForm_OnLoad(object sender, EventArgs e) {
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
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

      
    }
}
