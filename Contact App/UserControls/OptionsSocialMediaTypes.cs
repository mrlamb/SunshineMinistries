using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLibrary;

namespace Contact_App.UserControls
{
    public partial class OptionsSocialMediaTypes : OptionsView
    {
        public OptionsSocialMediaTypes()
        {
            InitializeComponent();
            lstSocialMediaTypes.DataSource = Program.Entities.sm_types.ToList();
            
        }

        private void btnAdd_Click(object sender , EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNew.Text))
            {
                if (!Program.Entities.sm_types.Any(a => a.sm_type_name.ToLower() == txtNew.Text.ToLower())) {
                    Program.Entities.sm_types.Add(new ModelLibrary.sm_types()
                    {
                        sm_type_name = txtNew.Text
                    });
                    Program.Entities.SaveChanges();
                    lstSocialMediaTypes.DataSource = Program.Entities.sm_types.ToList();
                    lblErrorMsg.Text = "Changes saved.";
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

        private void btnRemove_Click(object sender , EventArgs e)
        {
            if (null != lstSocialMediaTypes.SelectedItem)
            {
                try
                {
                    sm_types s = (sm_types) lstSocialMediaTypes.SelectedItem;
                    Program.Entities.sm_types.Remove(s);
                    Program.Entities.SaveChanges();

                }catch
                {
                    lblErrorMsg.Text = "Could not remove type. Type is in use on at least one record.";
                }
                finally
                {
                    lstSocialMediaTypes.DataSource = Program.Entities.sm_types.ToList();
                }
            }
        }
    }
}
