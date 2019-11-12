
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Contact_App;
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
    public partial class IndividualForm : UserControl, IRecordView//, IHasActionList
    {
        public event EventHandler FormNameUpdated;

        private string ID { get { return wtrID.Text; } set { wtrID.Text = value; } }
        private string FirstName { get { return wtrFirstName.Text; } set { wtrFirstName.Text = value; } }
        private string LastName { get { return wtrLastName.Text; } set { wtrLastName.Text = value; } }
        private string Phone { get { return wtrPhone.Text; } set { wtrPhone.Text = value; } }
        private string StreetPrimary { get { return wtrStreetAddress.Text; } set { wtrStreetAddress.Text = value; } }
        private string CityPrimary { get { return wtrCity.Text; } set { wtrCity.Text = value; } }
        private string StatePrimary { get { return cmbState.SelectedItem == null ? cmbState.Text : cmbState.Text; } set { cmbState.SelectedItem = value; } }
        private string ZipPrimary { get { return wtrZip.Text; } set { wtrZip.Text = value; } }
        private string StreetSecondary { get { return wtrStreetAddress2.Text; } set { wtrStreetAddress2.Text = value; } }
        private string CitySecondary { get { return wtrCity2.Text; } set { wtrCity2.Text = value; } }
        private string StateSecondary { get { return cmbState2.SelectedItem == null ? cmbState2.Text : cmbState2.Text; } set { cmbState2.SelectedItem = value; } }
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
        public individual savedRecord;
        private individual workingRecord;
        public int RecordID { get { return savedRecord.id; } }

        public IndividualForm()
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
            wtrFirstName.WtrTextChanged += TextChangedEventHandler;
            wtrLastName.WtrTextChanged += TextChangedEventHandler;

            actions = new List<actions_individual>();



        }

        public void SetData()
        {
            
            workingRecord = JsonConvert.DeserializeObject<individual>(JsonConvert.SerializeObject(savedRecord,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));


            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate { SetData(); }));
            }
            else
            {
                FirstName = savedRecord.firstname;
                LastName = savedRecord.lastname;
                Phone = savedRecord.phone;
                ID = savedRecord.sunshineid;
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
                    ICollection<actions_individual> items = new List<actions_individual>();
                    foreach (var item in savedRecord.actions_individual)
                    {
                        //items.Add(item);
                    }
                    InitializeActionList(items);
                }

                foreach (var x in savedRecord.addresses_individual)
                {
                    if ((bool)x.primary)
                    {
                        StreetPrimary = x.streetAddress;
                        CityPrimary = x.city;
                        cmbState.SelectedIndex = cmbState.FindStringExact(x.state);
                        cmbState.SelectedItem = cmbState.SelectedIndex;
                        ZipPrimary = x.zip;
                    }
                    else
                    {
                        StreetSecondary = x.streetAddress;
                        CitySecondary = x.city;
                        cmbState2.SelectedIndex = cmbState2.FindStringExact(x.state);
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
        private void TextChangedEventHandler(object sender , EventArgs e)
        {
            FormNameUpdated?.Invoke(sender , e);
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
        private void lstActions_MouseDoubleClick(object sender , MouseEventArgs e)
        {
            int index = this.lstActions.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //ActionDetail ad = new ActionDetail(lstActions.SelectedItem as actions_individual);
                //ad.form = this;
                //ad.ShowDialog();
            }
        }

        /// <summary>
        /// Initializes the ACTION listbox with the passed in collection of actions.
        /// </summary>
        /// <param name="actions">the passed in collection</param>
        public void InitializeActionList(ICollection<actions_individual> recordActions)
        {
            
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
        public void SaveActionToList(actions_individual a)
        {
            //This means it's been saved before
            if (a.ownerID != -1)
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
                (a).ownerID = savedRecord.id;
                actions.Add(a);
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
        private void btnAddAction_Click(object sender , EventArgs e)
        {
            ActionDetail ad = new ActionDetail();
            //ad.form = this;
            //ad.ShowDialog();
        }

        public object GetData()
        {
            if (null == savedRecord)
            {
                savedRecord = new individual();
            }
            savedRecord.firstname = FirstName;
            savedRecord.lastname = LastName;
            savedRecord.sunshineid = ID;
            savedRecord.phone = Phone;
            
            savedRecord.phonenumbers_individual.Clear();
            foreach (var item in flpPhoneNumbers.Controls)
            {
                if (item is PhoneAdd)
                {
                    savedRecord.phonenumbers_individual.Add(new phonenumbers_individual()
                    {
                        ownerID = savedRecord.id ,
                        phonenumber = (item as PhoneAdd).GetText()
                    });
                }
            }

            savedRecord.social_media_individual.Clear();
            foreach (var item in flpSocial.Controls)
            {
                if (item is SocialMediaLink)
                {
                    savedRecord.social_media_individual.Add(new social_media_individual()
                    {
                        sm_ind_id = savedRecord.id ,
                        sm_title = (item as SocialMediaLink).LinkTitle ,
                        sm_link = Encoding.ASCII.GetBytes((item as SocialMediaLink).LinkURL) ,
                        sm_type = (item as SocialMediaLink).SMType

                    });
                }
            }

            savedRecord.addresses_individual.Clear();
            if (null != GetPrimaryAddress())
            {
                savedRecord.addresses_individual.Add(GetPrimaryAddress());
            }
            if (null != GetSecondaryAddress())
            {
                savedRecord.addresses_individual.Add(GetSecondaryAddress());
            }
            

            savedRecord.actions_individual.Clear();
            foreach (var item in actions)
            {
                savedRecord.actions_individual.Add(item);
            }


            savedRecord.financialsupport = GetFinancialSupport();
            return savedRecord;
        }


        private addresses_individual GetSecondaryAddress()
        {
            if (StreetSecondary.Equals(string.Empty))
            {
                return null;
            }
            addresses_individual a = new addresses_individual();
            a.streetAddress = StreetSecondary;
            a.city = CitySecondary;
            a.state = StateSecondary;
            a.zip = ZipSecondary;
            a.contactid = savedRecord.id;
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
            if (StreetPrimary.Equals(string.Empty))
            {
                return null;
            }
            addresses_individual a = new addresses_individual();
            a.streetAddress = StreetPrimary;
            a.city = CityPrimary;
            a.state = StatePrimary;
            a.zip = ZipPrimary;
            a.contactid = savedRecord.id;
            a.primary = true;

            return a;

        }

        private void IndividualForm_Load(object sender , EventArgs e)
        {
            if (null != savedRecord)
            {
                SetData();
            }
        }
    }
}
