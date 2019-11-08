using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Contact_App.UserControls
{
    public partial class WidgetReportReturn : FrontPageWidget
    {
        public ObjectListView ObjectListView { get { return OLVReportReturn; } }
        public List<dynamic> ListContent { get; set; }

        public WidgetReportReturn()
        {
            InitializeComponent();
        }
    }
}
