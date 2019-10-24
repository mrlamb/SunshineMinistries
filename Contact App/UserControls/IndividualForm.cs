
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Contact_App.Forms;
using Contact_App.Interfaces;
using Contact_App.UserControls;
using ModelLibrary;
using Newtonsoft.Json;

/// <summary>
/// Class used to display an individual contact form. Takes a contact
/// </summary>



namespace DataInputForms
{
    public partial class IndividualForm : UserControl, IHasActionList, IRecordView
    {
        public event EventHandler FormNameUpdated;

        public Color dynamicDTPCalendarMonthBackgournd { get; private set; }
        private string ID { get { return wtrID.Text; } set { wtrID.Text = value; } }
        private string FirstName { get { return wtrFirstName.Text; } set { wtrFirstName.Text = value; } }
        private string LastName { get { return wtrLastName.Text; } set { wtrLastName.Text = value; } }
        private string Phone { get { return wtrPhone.Text; } set { wtrPhone.Text = value; } }
        private string StreetPrimary { get { return wtrStreetAddress.Text; } set { wtrStreetAddress.Text = value; } }
        private string CityPrimary { get { return wtrCity.Text; } set { wtrCity.Text = value; } }
        private string StatePrimary { get { return cmbState.SelectedItem == null ? cmbState.Text : cmbState.SelectedText; } set { cmbState.SelectedItem = value; } }
        private string ZipPrimary { get { return wtrZip.Text; } set { wtrZip.Text = value; } }
        private string StreetSecondary { get { return wtrStreetAddress2.Text; } set { wtrStreetAddress2.Text = value; } }
        private string CitySecondary { get { return wtrCity2.Text; } set { wtrCity2.Text = value; } }
        private string StateSecondary { get { return cmbState2.SelectedItem == null ? cmbState2.Text : cmbState2.SelectedText; } set { cmbState2.SelectedItem = value; } }
        private string ZipSecondary { get { return wtrZip2.Text; } set { wtrZip2.Text = value; } }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        private string[] states = {"Alabama","Alaska","Arizona","Arkansas","California","Colorado","Conneticut","Delaware","Florida",
            "Georgia","Hawaii","Idaho","Illinois","Indiana","Kansas","Kentucky","Louisiana","Maine","Maryland","Massachusetts",
            "Michigan","Minnesota","Missouri","Montanna","Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","North Carolina",
            "North Dakota","Ohio","Okalahoma","Oregon","Pennsylvania","Rhode Island","South Carolina","South Dakota","Tennessee",
            "Texas","Utah","Vermont","Virginia","Washington","West Virgina","Wisconsin","Wyoming"};

        private string[] states2;
        private List<actions_individual> actions;
        private individual savedRecord, workingRecord;
        public int RecordID { get { return savedRecord.id; } }

        public IndividualForm()
        {
            InitializeComponent();
            //Set first combo box
            cmbState.DataSource = states;
            //Copy array to second array for combo 2
            states2 = new string[states.Length];
            states.CopyTo(states2, 0);
            //Set second combo box
            cmbState2.DataSource = states2;
            //Set event handler for WtrmarkTextBox.WtrTextChanged 
            //Passed on to main form to update tab control title
            wtrFirstName.WtrTextChanged += TextChangedEventHandler;
            wtrLastName.WtrTextChanged += TextChangedEventHandler;

            
            

        }

        public void SetData(object o)
        {
            savedRecord = (individual) o;
            workingRecord = JsonConvert.DeserializeObject<individual>(JsonConvert.SerializeObject(savedRecord));


            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate { SetData(savedRecord); }));
            }
            else
            {
                FirstName = savedRecord.firstname;
                LastName = savedRecord.lastname;
                Phone = savedRecord.phone;
                if (null != savedRecord.phonenumbers_individual)
                {
                    foreach (var item in savedRecord.phonenumbers_individual)
                    {
                        PhoneAdd pa = new PhoneAdd();
                        pa.SetText(item.phonenumber);
                        flpPhoneNumbers.Controls.Add(pa);
                    }
                }

                SetFinancialSupport(savedRecord.financialsupport);
                if (null != savedRecord.actions_individual)
                {
                    ICollection<IAction> items = new List<IAction>();
                    foreach (var item in savedRecord.actions_individual)
                    {
                        items.Add(item);
                    }
                    InitializeActionList(items);
                }

                foreach (var x in savedRecord.addresses_individual)
                {
                    if (x.primary)
                    {
                        StreetPrimary = x.streetAddress;
                        CityPrimary = x.city;
                        StatePrimary = x.state;
                        ZipPrimary = x.zip;
                    }
                    else
                    {
                        StreetSecondary = x.streetAddress;
                        CitySecondary = x.city;
                        StateSecondary = x.state;
                        ZipSecondary = x.zip;
                    }
                }

                foreach (var item in savedRecord.social_media_individual)
                {
                    flpSocial.Controls.Add(
                        new SocialMediaLink(item.sm_title , Encoding.ASCII.GetString(item.sm_link))
                        {
                            SMType = item.sm_type
                        });
                }



            }
        }

        /// <summary>
        /// Passing the TextChangedEvent up the chain.
        /// Used in updating the tab controls title with the contents of the WaterMarkTextBoxes for
        /// first name and last name.
        /// </summary>
        private void TextChangedEventHandler(object sender, EventArgs e)
        {
            FormNameUpdated?.Invoke(sender, e);
        }

        /// <summary>
        /// Set's the radio button for financial support
        /// </summary>
        /// <param name="state">Yes = true, No = false</param>
        public void SetFinancialSupport(bool state)
        {
            rdoFinYes.Checked = state;
            rdoFinNo.Checked = !state;          
        }

        public bool GetFinancialSupport()
        {
            return rdoFinYes.Checked;
        }


        /// <summary>
        /// Creates a new instance of ActionDetail and passes in the action located at the selected index.
        /// </summary>
        private void lstActions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstActions.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ActionDetail ad = new ActionDetail(lstActions.SelectedItem as actions_individual);
                ad.form = this;
                ad.ShowDialog();
            }
        }

        /// <summary>
        /// Initializes the ACTION listbox with the passed in collection of actions.
        /// </summary>
        /// <param name="actions">the passed in collection</param>
        public void InitializeActionList(ICollection<IAction> recordActions)
        {
            actions = new List<actions_individual>();
            foreach (actions_individual a in recordActions)
            {
                actions.Add(a);
            }
            lstActions.DataSource = actions;
        }

        /// <summary>
        /// Checks if an action already exists in the list, if not it adds it.
        /// </summary>
        /// <param name="a">the action to save or add</param>
        public void SaveActionToList(IAction a)
        {
            //This means it's been saved before
            if (a.ownerID != 0)
            {
                foreach (actions_individual action in actions)
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
                actions.Add(a as actions_individual);
            }
            CurrencyManager cm = (CurrencyManager)BindingContext[actions];

            cm.Refresh();
        }

        /// <summary>
        /// Unused?
        /// </summary>
        /// <returns></returns>
        public ICollection<actions_individual> GetActionList()
        {
            return actions;
        }


        /// <summary>
        /// Unused?
        /// </summary>
        /// <returns></returns>
        public int GetActionCount()
        {
            return lstActions.Items.Count;
        }

        /// <summary>
        /// Opens a new form of ActionDetail for entry.
        /// </summary>
        private void btnAddAction_Click(object sender, EventArgs e)
        {
            ActionDetail ad = new ActionDetail();
            ad.form = this;
            ad.ShowDialog();
        }

        public object GetData()
        {
            if (null == workingRecord)
            {
                workingRecord = new individual();
            }
            workingRecord.firstname = FirstName;
            workingRecord.lastname = LastName;
            workingRecord.sunshineid = ID;
            workingRecord.phone = Phone;

            workingRecord.phonenumbers_individual.Clear();
            foreach (var item in flpPhoneNumbers.Controls)
            {
                if (item is PhoneAdd)
                {
                    workingRecord.phonenumbers_individual.Add(new phonenumbers_individual()
                    {
                        ownerID = workingRecord.id ,
                        phonenumber = (item as PhoneAdd).GetText()
                    });
                }
            }

            workingRecord.social_media_individual.Clear();
            foreach (var item in flpSocial.Controls)
            {
                if (item is SocialMediaLink)
                {
                    workingRecord.social_media_individual.Add(new social_media_individual()
                    {
                        sm_ind_id = workingRecord.id ,
                        sm_title = (item as SocialMediaLink).LinkTitle ,
                        sm_link = Encoding.ASCII.GetBytes((item as SocialMediaLink).LinkURL) ,
                        sm_type = (item as SocialMediaLink).SMType

                    });
                }
            }

            workingRecord.addresses_individual.Clear();
            AddAddressToRecord(workingRecord.addresses_individual , GetPrimaryAddress());
            AddAddressToRecord(workingRecord.addresses_individual , GetSecondaryAddress());

            workingRecord.actions_individual.Clear();
            workingRecord.actions_individual = actions;


            workingRecord.financialsupport = GetFinancialSupport();
            return workingRecord;
        }

        private void AddAddressToRecord(ICollection<addresses_individual> addresses , addresses_individual v)
        {
            addresses.Add(v);
        }

        private addresses_individual GetSecondaryAddress()
        {
            addresses_individual a = new addresses_individual();
            a.streetAddress = StreetSecondary;
            a.city = CitySecondary;
            a.state = StateSecondary;
            a.zip = ZipSecondary;
            a.contactid = workingRecord.id;
            a.primary = false;

            return a;
        }

        private void btnAddPhone_Click(object sender , EventArgs e)
        {
            PhoneAdd pa = new PhoneAdd();
            flpPhoneNumbers.Controls.Add(pa);
        }

        private void btnAddSM_Click(object sender , EventArgs e)
        {
            AddSocialMedia asm = new AddSocialMedia()
            {
                Panel = flpSocial
            };
            asm.ShowDialog();
        }

        private addresses_individual GetPrimaryAddress()
        {
            addresses_individual a = new addresses_individual();
            a.streetAddress = StreetPrimary;
            a.city = CityPrimary;
            a.state = StatePrimary;
            a.zip = ZipPrimary;
            a.contactid = workingRecord.id;
            a.primary = true;

            return a;
            
        }
    }
}
