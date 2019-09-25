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
                    case TransportProtocol.STATUS_UPDATE:

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

            //Show Administrate if User Level Allows
            if ((Program.UserOptions & Program.UserAccessOptions.UserControl) == Program.UserAccessOptions.UserControl)
            {
                administrateToolStripMenuItem.Visible = true;
            }

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
                IndividualContactTabPage icp = new IndividualContactTabPage(new DataInputForms.IndividualForm());
                icp.ID = Program.GetNextID();
                tabControl.TabPages.Add(icp);

                Program.stateObject.workSocket.Send(Transport.ConstructMessage(icp.ID, TransportProtocol.SEND_INDIVIDUAL_RECORD,
                    (lstRecordSelector.Items[index] as contact).id.ToString()));
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form f = new UserAccessControl())
            {
                f.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IndividualContactTabPage icp = new IndividualContactTabPage(new DataInputForms.IndividualForm());
            icp.ID = Program.GetNextID();
            tabControl.TabPages.Add(icp);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab is IndividualContactTabPage)
            {
                byte saveID = (tabControl.SelectedTab as IndividualContactTabPage).ID;
                contact c = (tabControl.SelectedTab as IndividualContactTabPage).GetContactFromData();
                Program.stateObject.workSocket.Send(Transport.ConstructMessage(FormID, TransportProtocol.UPDATE_RECORD,
                    JsonConvert.SerializeObject(c)));
            }
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 10, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            
            Rectangle r = tabControl.GetTabRect(this.tabControl.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 10, r.Top + 4, 9, 7);
            if (closeButton.Contains(e.Location))
            {
                this.tabControl.TabPages.Remove(this.tabControl.SelectedTab);
            }
        }
    
    }
}
