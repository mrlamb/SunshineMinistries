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
    public partial class PhoneAdd : UserControl
    {
        public PhoneAdd()
        {
            InitializeComponent();
        }

        public void SetText(string v)
        {
            wtrPN.Text = v;
        }

        public string GetText()
        {
            return wtrPN.Text;
        }

        private void btnRemove_Click(object sender , EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(wtrPN.Text))
            {
                switch(MessageBox.Show("Are you sure you want to delete this phone number?", "Confirm Deletion", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        return;
                }
            }
            this.Dispose();
        }
    }
}
