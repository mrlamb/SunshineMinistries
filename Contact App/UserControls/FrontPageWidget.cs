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
    public partial class FrontPageWidget : UserControl
    {
        public string Title { get { return gboWidgetBox.Text; } set { gboWidgetBox.Text = value; } }
        public FrontPageWidget()
        {
            InitializeComponent();
        }
    }
}
