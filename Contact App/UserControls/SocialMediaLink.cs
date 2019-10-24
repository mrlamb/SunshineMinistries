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
    public partial class SocialMediaLink : UserControl
    {
        public int SMType { get; set; }
        public string LinkURL { get; set; }
        public string LinkTitle { get; set; }
        public SocialMediaLink(string text, string url)
        {
            InitializeComponent();

            LinkURL = url;
            LinkTitle = text;
            this.linkLabel.Text = text;
            this.linkLabel.Links.Add(0 , text.Length , url);
        }

        private void btnRemove_Click(object sender , EventArgs e)
        {
            switch(MessageBox.Show("Are you sure you want to remove this link?", "Confirm Removal.", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    return;
            }
            this.Dispose();
        }

        private void linkLabel_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
