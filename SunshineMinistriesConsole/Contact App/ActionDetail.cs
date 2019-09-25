using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataInputForms
{
    public partial class ActionDetail : Form
    {
        public Contact_App.action myAction { get; set; }
        public IActionListUpdatable form { get; set; }
        public ActionDetail()
        {
            InitializeComponent();

        }

        public ActionDetail(Contact_App.action a)
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
                myAction = new Contact_App.action();

            }
            
                myAction.completedBy = cmbWho.Text;
                myAction.actionType = cmbWhat.Text;
                myAction.date = dtpWhen.Value;
                myAction.Notes = Encoding.ASCII.GetBytes(txtHow.Text);

            form.AddActionToList(myAction);

        }
    }
}
