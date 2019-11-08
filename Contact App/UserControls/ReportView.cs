using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace Contact_App.UserControls
{
    public partial class ReportView : UserControl
    {
        private TableLayoutPanel tlp;
        public ReportView()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }

        public void CreateRows(List<dynamic> items)
        {
            

            tlp = GenerateShellTableLayoutPanel();
            if (items.Count == 0)
            {
                tlp.Controls.Add(new Label()
                {
                    Text = "No records."
                }, 0,0);
                Controls.Add(tlp);
                return;
            }
            int colnum = 0;
            var tlpHeader = GenerateHeaderRow(items);
            
            tlp.Controls.Add(tlpHeader , 0 , tlp.RowCount - 1);
            
            tlp.RowCount++;
            foreach (var item in items)
            {
                //Create the row
                var tlpRow = new TableLayoutPanel();
                if (tlp.RowCount % 2 == 0)
                {
                    tlpRow.BackColor = Color.NavajoWhite;
                }
                else
                {
                    tlpRow.BackColor = Color.LightSkyBlue;
                }
                tlpRow.AutoSize = true;
                tlpRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tlpRow.Margin = new Padding(0);
                tlpRow.RowCount++;
                tlpRow.MouseEnter += TableLayoutPanelMouseEnter;
                tlpRow.MouseLeave += TableLayoutPanelMouseLeave;
                //End Create the row

                //Start logic to fill columns
                foreach (PropertyInfo pinfo in item.GetType().GetProperties())
                {
                    

                    //This Label should only happen if the type is primitive or a string
                    if (pinfo.PropertyType.IsPrimitive || pinfo.PropertyType == typeof(string))
                    {
                        string text = (null != pinfo.GetValue(item)) ? pinfo.GetValue(item).ToString() : "";
                        
                        tlpRow.Controls.Add(GenerateLabel(tlpRow, text) , colnum++ , 0);
                    }
                    else if (pinfo.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
                    {
                        IEnumerable set = (IEnumerable) pinfo.GetValue(item);
                        Label lbl = GenerateLabel(tlpRow, "");
                        foreach (var setPiece in set)
                        {
                            lbl.Text += $"{setPiece.ToString()}\n";
                        }
                        tlpRow.Controls.Add(lbl , colnum++ , 0);
                        
                        
                    }
                    

                }
                colnum = 0;
                tlp.Controls.Add(tlpRow , 0 , tlp.RowCount - 1);
                tlp.RowCount++;
            }

            Controls.Add(tlp);
        }

        
        /// <summary>
        /// Generates a label to go on a TableLayoutPanel
        /// </summary>
        /// <param name="tlpRow">The Panel to go on</param>
        /// <param name="text">Text for the label</param>
        /// <returns></returns>
        private Label GenerateLabel(TableLayoutPanel tlpRow , string text)
        {
            Label lbl = new Label()
            {

                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = text,
                

            };
            
            lbl.MouseEnter += TableLayoutPanelMouseEnter;
            lbl.MouseLeave += TableLayoutPanelMouseLeave;
            lbl.Parent = tlpRow;
            return lbl;
        }

        private TableLayoutPanel GenerateHeaderRow(List<dynamic> items)
        {
            if (items.Count == 0)
            {
                return null;
            }
            var tlpHeader = new TableLayoutPanel();
            int colnum = 0;
            tlpHeader.AutoSize = true;
            tlpHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpHeader.RowCount = 1;
            foreach (PropertyInfo item in items[0].GetType().GetProperties())
            {
                tlpHeader.ColumnCount += 1;

                tlpHeader.Controls.Add(new Label()
                {
                    Text = item.Name
                } , colnum++ , 0);

            }
            return tlpHeader;
        }

        private TableLayoutPanel GenerateShellTableLayoutPanel()
        {
            tlp = new TableLayoutPanel();
            tlp.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            tlp.AutoScroll = true;
            tlp.AutoSize = true;
            tlp.Margin = new Padding(0);
            tlp.Padding = new Padding(0);
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tlp.BackColor = Color.Transparent;
            tlp.Location = new Point(0 , 30);
            tlp.BackColor = Color.White;
            tlp.Size = new Size(this.Width , this.Height);
            tlp.RowCount = 1;
            tlp.ColumnCount = 1;

            return tlp;
        }

        private void TableLayoutPanelMouseLeave(object sender , EventArgs e)
        {
            if (sender is Label)
            {
                (sender as Label).Parent.BackColor = (Color)(sender as Label).Parent.Tag;
            }
            if (sender is TableLayoutPanel)
            {
                (sender as TableLayoutPanel).BackColor = (Color)(sender as TableLayoutPanel).Tag;
            }
        }

        private void TableLayoutPanelMouseEnter(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                (sender as Label).Parent.Tag = (sender as Label).Parent.BackColor;
                (sender as Label).Parent.BackColor = Color.AliceBlue;
            }
            if (sender is TableLayoutPanel)
            {
                (sender as TableLayoutPanel).Tag = (sender as TableLayoutPanel).BackColor;
                (sender as TableLayoutPanel).BackColor = Color.AliceBlue;
            }
        }

        private void ReportView_Load(object sender , EventArgs e)
        {
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.None;
            lblTitle.Left = 10;
            lblTitle.Width = this.Width - 10;
            //this.Size = Parent.Size;
        }
    }
}
