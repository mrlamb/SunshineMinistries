using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using ModelLibrary;
using Contact_App.UserControls;
using System.Linq;
using Contact_App.Controller;

namespace Contact_App
{
    public partial class MainForm : Form
    {
        private sunshinedataEntities Entities = new sunshinedataEntities();
        public MainForm()
        {
            InitializeComponent();

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
                        try
                        {
                            result[i] = JsonConvert.DeserializeObject<organization>(JsonConvert.SerializeObject(result[i]));
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }else
                    {
                        result[i] = tmpResult;
                    }
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            lstSearchResults.Invoke(new EventHandler(delegate { lstSearchResults.DataSource = result; }));
        }


        private void MainForm_OnLoad(object sender , EventArgs e)
        {
            //Set our event handler for receiving messages


            //Populate Utility Data

            //Show Administrate if User Level Allows
            if ((Program.UserOptions & Program.UserAccessOptions.UserControl) == Program.UserAccessOptions.UserControl)
            {
                administrateToolStripMenuItem.Visible = true;
            }

        }

        //Really misnamed, currently just sends a request to the server for the whole contact list.
        private void btnSearch_Click(object sender , EventArgs e)
        {
            
            lstSearchResults.DataSource = Entities.individuals.ToList();
        }

        //Generates an individual record form
        private void lstSearchResults_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            int index = this.lstSearchResults.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                RecordViewTabPage icp;
                if (lstSearchResults.Items[index] is individual)
                {
                    foreach (TabPage item in tabControl.TabPages)
                    {
                        if (item is RecordViewTabPage)
                        {
                            if ((item as RecordViewTabPage).RecordID == (lstSearchResults.Items[index] as individual).id)
                            {
                                tabControl.SelectedTab = item;
                                return;
                            }
                        }
                    }
                    icp = new RecordViewTabPage(new DataInputForms.IndividualForm()
                    {
                        savedRecord = ( individual ) lstSearchResults.Items[index]
                    });
                }
                else
                {
                    foreach (TabPage item in tabControl.TabPages)
                    {
                        if (item is RecordViewTabPage)
                        {
                            if ((item as RecordViewTabPage).RecordID == (lstSearchResults.Items[index] as organization).orgid)
                            {
                                tabControl.SelectedTab = item;
                                return;
                            }
                        }
                    }
                    icp = new RecordViewTabPage(new DataInputForms.OrganizationForm()
                    {
                        savedRecord = ( organization ) lstSearchResults.Items[index]
                    });
                }

                tabControl.TabPages.Add(icp);
                tabControl.SelectedTab = icp;

            
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

            //Old Add New Button
        }

        //Save button
        private void toolStripButton2_Click(object sender , EventArgs e)
        {
            if (tabControl.SelectedTab is RecordViewTabPage)
            {
                byte saveID = (tabControl.SelectedTab as RecordViewTabPage).ID;
                object r = (tabControl.SelectedTab as RecordViewTabPage).GetContactFromData();
                if (r is individual)
                {
                    //Replace with UpdateIndividualRecord
                    individual c = (individual)r;
                    try
                    {
                        individual record = Entities.individuals.First(a => a.id == c.id);
                        record.firstname = c.firstname;
                        record.lastname = c.lastname;
                        record.addresses_individual = c.addresses_individual;
                        record.phone = c.phone;
                        record.phonenumbers_individual = c.phonenumbers_individual;
                        record.financialsupport = c.financialsupport;
                        record.actions_individual = c.actions_individual;
                        record.social_media_individual = c.social_media_individual;
                        record.sunshineid = c.sunshineid;
                        record.source = c.source;


                    }
                    catch (InvalidOperationException)
                    {
                        Entities.individuals.Add(c);

                    }
                    finally
                    {
                        Entities.SaveChanges();
                        tsslMainForm.Text = $"{c.ToString()} has been saved.";
                    }
                }
                else
                {
                    //Replace with UpdateOrgRecord
                    organization o = (organization)r;
                    try
                    {
                        organization record = Entities.organizations.First(a => a.orgid == o.orgid);
                        record.name = o.name;
                        record.addresses_organization = o.addresses_organization;
                        record.phonenumbers_organization = o.phonenumbers_organization;
                        record.phone = o.phone;
                        record.financialsupport = o.financialsupport;
                        record.actions_organization = o.actions_organization;
                        record.social_media_organization = o.social_media_organization;
                        record.orgsunshineid = o.orgsunshineid;
                    }
                    catch (InvalidOperationException)
                    {
                        Entities.organizations.Add(o);
                    }
                    finally
                    {
                        Entities.SaveChanges();
                        tsslMainForm.Text = $"{o.name} has been saved.";
                    }
                }
            }
        }

        private void tabControl_DrawItem(object sender , DrawItemEventArgs e)
        {
            if (e.Index == 0)
            {
                e.Graphics.DrawString(this.tabControl.TabPages[e.Index].Text , e.Font , Brushes.Black , e.Bounds.Left + 3 , e.Bounds.Top + 4);
                return;
            }
            e.Graphics.DrawString("x" , e.Font , Brushes.Black , e.Bounds.Right - 16 , e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl.TabPages[e.Index].Text , e.Font , Brushes.Black , e.Bounds.Left + 3 , e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl_MouseDown(object sender , MouseEventArgs e)
        {

            Rectangle r = tabControl.GetTabRect(this.tabControl.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 16, r.Top + 4, 9, 7);
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
                QueryBuilder.SearchWithKeywords(lstSearchResults , toolStripTextBox.Text);
            }
        }

        private void socialMediaToolStripMenuItem_Click(object sender , EventArgs e)
        {
            TabPage t = new TabPage();
            t.Text = "Social Media Types";
            t.Controls.Add(new OptionsSocialMediaTypes());
            tabControl.TabPages.Add(t);
            tabControl.SelectedTab = t;

        }

        private void reportsToolStripMenuItem_Click(object sender , EventArgs e)
        {
            TabPage t = new TabPage();
            t.Text = "Reports";
            t.Controls.Add(new ReportTab());
            tabControl.TabPages.Add(t);
            tabControl.SelectedTab = t;
        }
    }
}
