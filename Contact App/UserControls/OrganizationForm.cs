using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contact_App.Interfaces;
using ModelLibrary;
using Newtonsoft.Json;

namespace DataInputForms
{
    public partial class OrganizationForm : UserControl, IRecordView, IHasActionList
    {

        private List<actions_organization> actions;
        private organization savedRecord, workingRecord;

        //Hate this need a workaround
        private string[] states = {"Alabama","Alaska","Arizona","Arkansas","California","Colorado","Conneticut","Delaware","Florida",
            "Georgia","Hawaii","Idaho","Illinois","Indiana","Kansas","Kentucky","Louisiana","Maine","Maryland","Massachusetts",
            "Michigan","Minnesota","Missouri","Montanna","Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","North Carolina",
            "North Dakota","Ohio","Okalahoma","Oregon","Pennsylvania","Rhode Island","South Carolina","South Dakota","Tennessee",
            "Texas","Utah","Vermont","Virginia","Washington","West Virgina","Wisconsin","Wyoming"};

        private string[] states2;


        public OrganizationForm()
        {
            InitializeComponent();
            //Set first combo box
            cmbState.DataSource = states;
            //Copy array to second array for combo 2
            states2 = new string[states.Length];
            states.CopyTo(states2 , 0);
            //Set second combo box
            cmbState2.DataSource = states2;
            //Set event handler for WtrmarkTextBox.WtrTextChanged 
            //Passed on to main form to update tab control title
            wtrOrgName.WtrTextChanged += TextChangedEventHandler;
        }

        public string FullName
        {
            get
            {
                return wtrOrgName.Text;
            }
        }

        public event EventHandler FormNameUpdated;
        /// <summary>
        /// Passing the TextChangedEvent up the chain.
        /// Used in updating the tab controls title with the contents of the WaterMarkTextBoxes for
        /// first name and last name.
        /// </summary>
        private void TextChangedEventHandler(object sender , EventArgs e)
        {
            FormNameUpdated?.Invoke(sender , e);
        }

        public void InitializeActionList(ICollection<IAction> recordActions)
        {
            actions = new List<actions_organization>();
            foreach (actions_organization a in recordActions)
            {
                actions.Add(a);
            }
            lstActions.DataSource = actions;
        }

        public void SaveActionToList(IAction a)
        {
            //This means it's been saved before
            if (a.ownerID != 0)
            {
                foreach (actions_organization action in actions)
                {
                    if (action.ownerID == a.ownerID)
                    {
                        action.Notes = a.Notes;
                        action.completedBy = a.completedBy;
                        action.actionType = a.actionType;

                    }
                }
            }
            else
            {
                a.ownerID = savedRecord.orgid;
                actions_organization tmp = new actions_organization(a.ownerID, a.actionType, a.completedBy, a.Notes, a.date);
                actions.Add(tmp);
            }
            CurrencyManager cm = (CurrencyManager)BindingContext[actions];

            cm.Refresh();
        }

        private void btnAddAction_Click(object sender , EventArgs e)
        {
            ActionDetail ad = new ActionDetail();
            ad.form = this;
            ad.ShowDialog();
        }

        public void SetData(object o)
        {
            savedRecord = ( organization ) o;
            workingRecord = JsonConvert.DeserializeObject<organization>(JsonConvert.SerializeObject(savedRecord));


            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate { SetData(savedRecord); }));
            }
            else
            {
                wtrOrgName.Text = savedRecord.name;
                wtrPhone.Text = savedRecord.phone;
                SetFinancialSupport(savedRecord.financialsupport);
                if (null != savedRecord.actions_organization)
                {
                    ICollection<IAction> items = new List<IAction>();
                    foreach (var item in savedRecord.actions_organization)
                    {
                        items.Add(item);
                    }
                    InitializeActionList(items);
                }

                foreach (var x in savedRecord.addresses_organization)
                {
                    if (x.primary)
                    {
                        wtrStreetAddress.Text = x.streetAddress;
                        wtrCity.Text = x.city;
                        cmbState2.SelectedItem = x.state;
                        wtrZip.Text = x.zip;
                    }
                    else
                    {
                        wtrStreetAddress2.Text = x.streetAddress;
                        wtrCity.Text = x.city;
                        cmbState2.SelectedItem = x.state;
                        wtrZip.Text = x.zip;
                    }
                }



            }
        }

        private void SetFinancialSupport(bool? state)
        {
            rdoFinYes.Checked = (bool) state;
            rdoFinNo.Checked = (bool) !state;
        }

        private void lstActions_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            int index = this.lstActions.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ActionDetail ad = new ActionDetail(lstActions.SelectedItem as actions_organization);
                ad.form = this;
                ad.ShowDialog();
            }
        }

        public bool GetFinancialSupport()
        {
            return rdoFinYes.Checked;
        }
        public object GetData()
        {
            if (null == workingRecord)
            {
                workingRecord = new organization();
            }
            workingRecord.name = wtrOrgName.Text;
            workingRecord.orgsunshineid = wtrID.Text;
            workingRecord.phone = wtrPhone.Text;
            workingRecord.addresses_organization.Clear();
            AddAddressToRecord(workingRecord.addresses_organization , GetPrimaryAddress());
            AddAddressToRecord(workingRecord.addresses_organization , GetSecondaryAddress());

            if (null != workingRecord.actions_organization)
            {
                workingRecord.actions_organization.Clear();
            }
            workingRecord.actions_organization = actions;


            workingRecord.financialsupport = GetFinancialSupport();
            return workingRecord;
        }

        private void AddAddressToRecord(ICollection<addresses_organization> addresses , addresses_organization v)
        {
            addresses.Add(v);
        }

        private addresses_organization GetSecondaryAddress()
        {
            addresses_organization a = new addresses_organization();
            a.streetAddress = wtrStreetAddress.Text;
            a.city = wtrCity.Text;
            a.state = cmbState2.SelectedItem == null ? cmbState2.Text : cmbState2.SelectedText;
            a.zip = wtrZip.Text;
            a.orgid = workingRecord.orgid;
            a.primary = false;

            return a;
        }

        private addresses_organization GetPrimaryAddress()
        {
            addresses_organization a = new addresses_organization();
            a.streetAddress = wtrStreetAddress2.Text;
            a.city = wtrCity2.Text;
            a.state = cmbState2.SelectedItem == null ? cmbState2.Text : cmbState2.SelectedText;
            a.zip = wtrZip2.Text;
            a.orgid = workingRecord.orgid;
            a.primary = true;

            return a;

        }
    }
}
