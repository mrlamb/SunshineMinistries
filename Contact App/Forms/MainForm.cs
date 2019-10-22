using Transportation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using ModelLibrary;

namespace Contact_App
{
    public partial class MainForm : Form
    {
        private byte FormID = 20;
        public MainForm()
        {
            InitializeComponent();

        }

        //Handle incoming messages from the server
        private void MessageReceivedEventHandler(Socket socket , StringBuilder sb , List<Byte> lb)
        {
            MessageObj mo = new MessageObj();
            mo = Transport.DeconstructMessage(lb);
            if (mo.ReturnTo == FormID)
            {
                switch (mo.Protocol)
                {
                    //A list of contacts was sent
                    case TransportProtocol.BATCH_SEND_RECORD:
                        SetList(mo.Message);
                        break;
                    //A request for a message box was sent (for testing)
                    case TransportProtocol.MESSAGE_BOX:
                        MessageBox.Show(mo.Message);
                        break;
                    //A request to update the status bar was sent (for user feedback)
                    case TransportProtocol.STATUS_UPDATE:

                        break;
                    default:
                        break;
                }
            }

        }

        //Populate the list box with the contents of the message (a list of contacts)
        private void SetList(string message)
        {
            
            var result = JsonConvert.DeserializeObject<List<object>>(message);
            object tmpResult;
            for (int i = 0; i < result.Count; i++)
            {
                try
                {
                    tmpResult = JsonConvert.DeserializeObject<individual>(JsonConvert.SerializeObject(result[i]));
                    if ((tmpResult as individual).firstname == null)
                    {
                        throw new Exception("Not an individual");
                    }
                    result[i] = tmpResult;
                } catch (Exception e)
                {
                    try
                    {
                        result[i] = JsonConvert.DeserializeObject<organization>(JsonConvert.SerializeObject(result[i]));
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            

            lstRecordSelector.Invoke(new EventHandler(delegate { lstRecordSelector.DataSource = result; }));
        }


        private void MainForm_OnLoad(object sender , EventArgs e)
        {
            //Set our event handler for receiving messages
            Transport.messageReceivedEvent += MessageReceivedEventHandler;

            //Show Administrate if User Level Allows
            if ((Program.UserOptions & Program.UserAccessOptions.UserControl) == Program.UserAccessOptions.UserControl)
            {
                administrateToolStripMenuItem.Visible = true;
            }

        }

        //Really misnamed, currently just sends a request to the server for the whole contact list.
        private void btnSearch_Click(object sender , EventArgs e)
        {
            Program.stateObject.workSocket.Send(Transport.ConstructMessage(FormID , TransportProtocol.BATCH_SEND_RECORD));
        }

        //Generates an individual record form
        private void lstRecordSelector_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            int index = this.lstRecordSelector.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                RecordViewTabPage icp;
                if (lstRecordSelector.Items[index] is individual)
                {
                    icp = new RecordViewTabPage(new DataInputForms.IndividualForm()); 
                }
                else
                {
                    icp = new RecordViewTabPage(new DataInputForms.OrganizationForm());
                }


                icp.ID = Program.GetNextID();
                tabControl.TabPages.Add(icp);
                tabControl.SelectedTab = icp;

                if (lstRecordSelector.Items[index] is individual)
                {
                    Program.stateObject.workSocket.Send(Transport.ConstructMessage(icp.ID , TransportProtocol.SEND_INDIVIDUAL_RECORD ,
                                (lstRecordSelector.Items[index] as individual).id.ToString())); 
                }
                else
                {
                    Program.stateObject.workSocket.Send(Transport.ConstructMessage(icp.ID , TransportProtocol.SEND_ORG_RECORD ,
                                (lstRecordSelector.Items[index] as organization).orgid.ToString()));
                }
            }
        }

        private void usersToolStripMenuItem_Click(object sender , EventArgs e)
        {
            using (Form f = new UserAccessControl())
            {
                f.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender , EventArgs e)
        {


        }

        private void toolStripButton2_Click(object sender , EventArgs e)
        {
            if (tabControl.SelectedTab is RecordViewTabPage)
            {
                byte saveID = (tabControl.SelectedTab as RecordViewTabPage).ID;
                object r = (tabControl.SelectedTab as RecordViewTabPage).GetContactFromData();
                if (r is individual)
                {
                    Program.stateObject.workSocket.Send(Transport.ConstructMessage(saveID , TransportProtocol.UPDATE_INDIVIDUAL_RECORD ,
                        JsonConvert.SerializeObject(r as individual)));
                }
                else
                {
                    Program.stateObject.workSocket.Send(Transport.ConstructMessage(saveID , TransportProtocol.UPDATE_ORG_RECORD ,
                        JsonConvert.SerializeObject(r as organization)));
                }
            }
        }

        private void tabControl_DrawItem(object sender , DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x" , e.Font , Brushes.Black , e.Bounds.Right - 10 , e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl.TabPages[e.Index].Text , e.Font , Brushes.Black , e.Bounds.Left + 3 , e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl_MouseDown(object sender , MouseEventArgs e)
        {

            Rectangle r = tabControl.GetTabRect(this.tabControl.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 10, r.Top + 4, 9, 7);
            if (closeButton.Contains(e.Location))
            {
                this.tabControl.TabPages.Remove(this.tabControl.SelectedTab);
            }
        }

        private void individualToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RecordViewTabPage icp = new RecordViewTabPage(new DataInputForms.IndividualForm());
            icp.ID = Program.GetNextID();
            tabControl.TabPages.Add(icp);
            tabControl.SelectedTab = icp;
        }

        private void organizationToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RecordViewTabPage icp = new RecordViewTabPage(new DataInputForms.OrganizationForm());
            icp.ID = Program.GetNextID();
            tabControl.TabPages.Add(icp);
            tabControl.SelectedTab = icp;
        }

        private void toolStripButtonSearch_Click(object sender , EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(toolStripTextBox.Text))
            {
                Program.stateObject.workSocket.Send(Transport.ConstructMessage(
                    this.FormID , TransportProtocol.SEARCH_WITH_TERM , toolStripTextBox.Text));
            }
        }
    }
}
