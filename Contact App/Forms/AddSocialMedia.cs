using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contact_App.UserControls;
using ModelLibrary;

namespace Contact_App.Forms
{
    public partial class AddSocialMedia : Form
    {
        public FlowLayoutPanel Panel { get; set; }
        private ErrorProvider ep = new ErrorProvider();

        public AddSocialMedia()
        {
            InitializeComponent();

            cmbSMTypes.DataSource = UtilityData.SocialMediaTypes;
        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            bool errorType, errorLink;
            string errormsg = "";
            //Validate data exists
            errorType = ValidateType(cmbSMTypes , out errormsg);
            ep.SetError(cmbSMTypes , errormsg);

            errorLink = ValidateLink(txtLink.Text , out errormsg);
            ep.SetError(txtLink , errormsg);
            
            if (!errorType || !errorLink)
            {
                return;
            }

            SocialMediaLink sml = new SocialMediaLink(txtName.Text.Length != 0 ?
               txtName.Text : cmbSMTypes.SelectedItem.ToString() , txtLink.Text)
            {
                SMType = (cmbSMTypes.SelectedItem as sm_types).sm_type_id
            };
            Panel.Controls.Add(sml);

            this.Dispose();

        }

        private bool ValidateType(ComboBox cmbSMTypes , out string errormsg)
        {
            if (!UtilityData.SocialMediaTypes.Any(a => a.sm_type_name == cmbSMTypes.Text))
            {
                errormsg = "Value must exist in the list.";
                return false;
            }
            errormsg = "";
            return true;
        }

        private bool ValidateLink(string text , out string errormsg)
        {
            if (text.Length == 0)
            {
                errormsg = "Link empty.";
                return false;
            }
            if (!text.Contains("http"))
            {
                errormsg = "Protocol missing, add full url (e.g. http://www.google.com";
                return false;
            }
            errormsg = "";
            return true;
        }

        private void btnCancel_Click(object sender , EventArgs e)
        {
            this.Dispose();
        }
    }
}
