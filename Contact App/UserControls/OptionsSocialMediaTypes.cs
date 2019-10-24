using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_App.UserControls
{
    public partial class OptionsSocialMediaTypes : OptionsView
    {
        public OptionsSocialMediaTypes()
        {
            InitializeComponent();
            lstSocialMediaTypes.DataSource = UtilityData.SocialMediaTypes;
            
        }

        private void btnAdd_Click(object sender , EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNew.Text))
            {
                if (!UtilityData.SocialMediaTypes.Any(a => a.sm_type_name.ToLower() == txtNew.Text.ToLower())) {
                    UtilityData.SocialMediaTypes.Add(new ModelLibrary.sm_types()
                    {
                        sm_type_name = txtNew.Text
                    });
                    CurrencyManager cm = (CurrencyManager)BindingContext[UtilityData.SocialMediaTypes];

                    cm.Refresh();
                    lblErrorMsg.Text = "";
                }
                else
                {
                    lblErrorMsg.Text = $"Type not valid. Already exists in collection.";
                }

            }
            else
            {
                lblErrorMsg.Text = $"Type not valid. Text field empty.";
                return;
            }
        }
    }
}
