using Contact_App.Interfaces;
using Contact_App.Model;
using System;
using System.Text;
using System.Windows.Forms;

namespace DataInputForms
{
    public partial class ActionDetail : Form
    {
        public action myAction { get; set; }
        public IHasActionList form { get; set; }
        public ActionDetail()
        {
            InitializeComponent();

        }

        public ActionDetail(action a)
        {
            InitializeComponent();
            
            myAction = a;
            cmbWho.Text = myAction.completedBy;
            cmbWhat.Text = myAction.actionType;
            dtpWhen.Value = myAction.date;
            txtHow.Text = Encoding.ASCII.GetString(myAction.Notes);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (null == myAction)
            {
                myAction = new action();

            }
            
                myAction.completedBy = cmbWho.Text;
                myAction.actionType = cmbWhat.Text;
                myAction.date = dtpWhen.Value;
                myAction.Notes = Encoding.ASCII.GetBytes(txtHow.Text);

            form.SaveActionToList(myAction);

        }
    }
}
