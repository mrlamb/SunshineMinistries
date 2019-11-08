using Contact_App.Interfaces;
using System;
using System.Text;
using System.Windows.Forms;
using ModelLibrary;

namespace DataInputForms
{
    public partial class ActionDetail : Form
    {
        public IAction myAction { get; set; }
        public IHasActionList form { get; set; }
        public ActionDetail()
        {
            InitializeComponent();

        }

        public ActionDetail(IAction a)
        {
            InitializeComponent();

            myAction = a;
            cmbWho.Text = myAction.completedBy;
            cmbWhat.Text = myAction.actionType;
            dtpWhen.Value = myAction.date;
            txtHow.Text = Encoding.ASCII.GetString(myAction.Notes);
        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            if (null == myAction)
            {
                myAction = new actions_individual();
                myAction.ownerID = -1;

            }
             myAction.ownerID = myAction.ownerID >= 0 ? myAction.ownerID : -1;
            myAction.completedBy = cmbWho.Text;
            myAction.actionType = cmbWhat.Text;
            myAction.date = dtpWhen.Value;
            myAction.Notes = Encoding.ASCII.GetBytes(txtHow.Text);

            form.SaveActionToList(myAction);
            this.Close();
        }
    }
}
