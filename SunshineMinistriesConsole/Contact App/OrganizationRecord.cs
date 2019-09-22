using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_App
{
    public partial class OrganizationRecord : UserControl
    {

        public string OrgName { get { return this.wtrOrgName.Text; } set { this.wtrOrgName.Text = value; } }
        public OrganizationRecord()
        {
            InitializeComponent();
        }
    }
}
