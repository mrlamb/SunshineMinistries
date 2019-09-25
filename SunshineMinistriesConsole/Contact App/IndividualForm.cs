using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contact_App;

namespace DataInputForms
{
    public partial class IndividualForm : UserControl, IActionListUpdatable
    {
        public event EventHandler FormNameUpdated;
        
        public Color dynamicDTPCalendarMonthBackgournd { get; private set;}
        public string ID { get { return wtrID.Text; } set { wtrID.Text = value; } }
        public string FirstName { get { return wtrFirstName.Text; } set { wtrFirstName.Text = value; } }
        public string LastName { get { return wtrLastName.Text; } set { wtrLastName.Text = value; } }
        public string Phone { get { return wtrPhone.Text; } set { wtrPhone.Text = value; } }
//        public object Actions { get { return lstActions.DataSource; } set { lstActions.DataSource = value; } }
        public string StreetPrimary { get { return wtrStreetAddress.Text; } set { wtrStreetAddress.Text = value; } }
        public string CityPrimary { get { return wtrCity.Text; } set { wtrCity.Text = value; } }
        public string StatePrimary { get { return cmbState.SelectedItem == null ? cmbState.Text : cmbState.SelectedText; } set { cmbState.SelectedItem = value; } }
        public string ZipPrimary { get { return wtrZip.Text; } set { wtrZip.Text = value; } }
        public string StreetSecondary { get { return wtrStreetAddress2.Text; } set { wtrStreetAddress2.Text = value; } }
        public string CitySecondary { get { return wtrCity2.Text; } set { wtrCity2.Text = value; } }
        public string StateSecondary { get { return cmbState2.SelectedItem == null ? cmbState2.Text : cmbState2.SelectedText; } set { cmbState2.SelectedItem = value; } }
        public string ZipSecondary { get { return wtrZip2.Text; } set { wtrZip2.Text = value; } }
        private string[] states = {"Alabama","Alaska","Arizona","Arkansas","California","Colorado","Conneticut","Delaware","Florida",
            "Georgia","Hawaii","Idaho","Illinois","Indiana","Kansas","Kentucky","Louisiana","Maine","Maryland","Massachusetts",
            "Michigan","Minnesota","Missouri","Montanna","Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","North Carolina",
            "North Dakota","Ohio","Okalahoma","Oregon","Pennsylvania","Rhode Island","South Carolina","South Dakota","Tennessee",
            "Texas","Utah","Vermont","Virginia","Washington","West Virgina","Wisconsin","Wyoming"};

        private string[] states2;

        public IndividualForm()
        {
            InitializeComponent();
            cmbState.DataSource = states;
            states2 = new string[states.Length];
            states.CopyTo(states2, 0);
            cmbState2.DataSource = states2;
            wtrFirstName.WtrTextChanged += TextChangedEventHandler;
            wtrLastName.WtrTextChanged += TextChangedEventHandler;
            

        }

        private void TextChangedEventHandler(object sender, EventArgs e)
        {
            FormNameUpdated?.Invoke(sender, e);
        }

        public void SetFinancialSupport(bool state)
        {
            rdoFinYes.Checked = state;
            rdoFinNo.Checked = !state;          
        }

        public bool GetFinancialSupport()
        {
            return rdoFinYes.Checked;
        }

        private void lstActions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstActions.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ActionDetail ad = new ActionDetail(lstActions.SelectedItem as action);
                ad.form = this;
                ad.ShowDialog();
            }
        }

        public void AddActionToList(action a)
        {
            //This means it's been saved before
            if (a.ownerID != 0)
            {
                //Check it against existing actions
            }
            lstActions.Items.Add(a);
        }

        public IEnumerable<action> GetActionFromList()
        {
            foreach (action a in lstActions.Items)
            {
                yield return a;
            }
        }

        public ICollection<action> GetActionList()
        {
            return lstActions.Items.Cast<action>().ToList();
        }

        public int GetActionCount()
        {
            return lstActions.Items.Count;
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            ActionDetail ad = new ActionDetail();
            ad.form = this;
            ad.ShowDialog();
        }
    }
}
