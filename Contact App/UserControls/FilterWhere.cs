using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contact_App.Interfaces;

namespace Contact_App.UserControls
{
    public partial class FilterWhere : FilterBase, IFilter
    {
        private FlowLayoutPanel flp;
        public FilterWhere(FlowLayoutPanel flp)
        {
            InitializeComponent();
            this.flp = flp;
            flp.ControlAdded += new ControlEventHandler(SetComboColumns);
            flp.ControlRemoved += new ControlEventHandler(SetComboColumns);
        }

        

        public string SQLSnippet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private void btn_Click(object sender , EventArgs e)
        {
            this.Dispose();
        }

        private void FilterWhere_Load(object sender , EventArgs e)
        {
            SetComboColumns();
        }

        private void SetComboColumns()
        {
            cmbColumns.Items.Clear();
            foreach (var item in flp.Controls)
            {
                if (item is Button)
                {
                    cmbColumns.Items.Add((item as Button).Text);
                }
            }
        }

        private void SetComboColumns(object sender , ControlEventArgs e)
        {
            cmbColumns.Items.Clear();
            foreach (var item in flp.Controls)
            {
                if (item is Button)
                {
                    cmbColumns.Items.Add((item as Button).Text);
                }
            }
        }
    }
}
