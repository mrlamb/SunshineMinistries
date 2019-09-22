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
        private byte FormID = 20;
        public MainForm()
        {
            InitializeComponent();

        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<Byte> lb)
        {
            MessageObj mo = new MessageObj();
            mo = Transport.DeconstructMessage(lb);
            if (mo.ReturnTo == FormID)
            {
                switch (mo.Protocol)
                {
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

        }

        private void SetList(string message)
        {
            var result = JsonConvert.DeserializeObject<List<contact>>(message);

            lstRecordSelector.Invoke(new EventHandler(delegate { lstRecordSelector.DataSource = result; }));
        }

        private void MainForm_OnLoad(object sender, EventArgs e)
        {
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Program.stateObject.workSocket.Send(Transport.ConstructMessage(FormID, TransportProtocol.BATCH_SEND_RECORD));
        }

        private void lstRecordSelector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstRecordSelector.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                IndividualContactTabPage icp = new IndividualContactTabPage(new OrganizationRecord());
                icp.ID = Program.GetNextID();
                tabControl.TabPages.Add(icp);

                Program.stateObject.workSocket.Send(Transport.ConstructMessage(icp.ID, TransportProtocol.SEND_INDIVIDUAL_RECORD,
                    (lstRecordSelector.Items[index] as contact).id.ToString()));
            }
        }

       
    }
}
