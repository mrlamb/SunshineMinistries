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
    public partial class WaterMarkTextBox : UserControl
    {
        public override string Text { get { return wtrTextBox.Text; } set { wtrTextBox.Text = value; } }

        [Category("Appearance"), Description("Should we show the password character in this box.")]
        public bool Password { get { return wtrTextBox.UseSystemPasswordChar; } set { wtrTextBox.UseSystemPasswordChar = value; } }


        public WaterMarkTextBox()
        {
            InitializeComponent();

        }

        private void wtrLabel_Paint(object sender, PaintEventArgs e)
        {
            wtrLabel.BackColor = wtrTextBox.BackColor;
            if (!DesignMode)
            {
                if (wtrTextBox.Text != String.Empty)
                    wtrLabel.Hide();
                else
                    wtrLabel.Text = this.Tag.ToString();
            }

        }

        private void wtrTextBox_Enter(object sender, EventArgs e)
        {
            wtrLabel.Visible = false;

        }

        private void wtrTextBox_Leave(object sender, EventArgs e)
        {
            if (wtrTextBox.Text == string.Empty)
            {
                wtrLabel.Text = this.Tag.ToString();
                wtrLabel.Visible = true;
            }

        }

        private void wtrLabel_Click(object sender, EventArgs e)
        {
            wtrTextBox.Focus();
        }
    }
}
