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
using Newtonsoft.Json;

namespace Contact_App
{
    public partial class MainForm : Form
    {
        private contact FormContact;
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
                case TransportProtocol.SEND_RECORD:
                    SetFields(mo.Message);
                    break;
                case TransportProtocol.BATCH_SEND_RECORD:
                    SetList(mo.Message);
                    break;
                case TransportProtocol.MESSAGE_BOX:
                    MessageBox.Show(mo.Message);
                    break;
                default:
                    break;
            }

        }

        private void SetFields(string message)
        {
            if (this.InvokeRequired)
            {
                Invoke(new EventHandler(delegate { SetFields(message); }));
            }
            else
            {
                FormContact = JsonConvert.DeserializeObject<contact>(message);
                txtFirstName.Text = FormContact.firstname;
                txtLastName.Text = FormContact.lastname;
            }
        }

        private void SetList(string message)
        {
            var result = JsonConvert.DeserializeObject<List<contact>>(message);
            
            lstRecordSelector.Invoke(new EventHandler(delegate { lstRecordSelector.DataSource = result; }));
        }

        private void MainForm_OnLoad(object sender, EventArgs e) {
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Program.stateObject.workSocket.Send(Transport.ConstructMessage(TransportProtocol.BATCH_SEND_RECORD));
        }

        

        private void button1_Click(object sender, EventArgs e)

        {
            this.Hide();
            Form2 f2 = new Contact_App.Form2();
            f2.ShowDialog();


        }

        private void lstRecordSelector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstRecordSelector.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Program.stateObject.workSocket.Send(Transport.ConstructMessage(TransportProtocol.SEND_RECORD, 
                    (lstRecordSelector.Items[index] as contact).id.ToString()));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormContact.firstname = txtFirstName.Text;
            FormContact.lastname = txtLastName.Text;
            Program.stateObject.workSocket.Send(Transport.ConstructMessage(TransportProtocol.UPDATE_RECORD,
                JsonConvert.SerializeObject(FormContact)));

           // btnSearch_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            FormContact = new Contact_App.contact();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mbr = MessageBox.Show("Are you sure you want to delete this record?", "Really Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (mbr)
            {
                
                case DialogResult.Yes:
                    Program.stateObject.workSocket.Send(Transport.ConstructMessage(TransportProtocol.DELETE_RECORD,
                JsonConvert.SerializeObject(FormContact)));
                    btnNew_Click(sender, e);
                    //btnSearch_Click(sender, e);
                    break;
                default:
                    break;
            }

            
        }
    }
}
