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
using System.Data.Entity;
using System.Reflection;
using System.Collections;

namespace Contact_App.UserControls
{
    public partial class ReportTab : UserControl
    {
        class DraggableTreeNode : TreeNode
        {
            public PropertyInfo PInfo { get; set; }
            
        }
        public ReportTab()
        {
            InitializeComponent();
        }

        private void ReportTab_Load(object sender , EventArgs e)
        {
            TreeNode nodeRoot = new TreeNode()
            {
                Text = "Individual"
            };

            tvColumns.Nodes.Add(nodeRoot);
            foreach (PropertyInfo item in new individual().GetType().GetProperties())
            {
                TreeNode nodeChild = new DraggableTreeNode()
                {
                    PInfo = item,
                    Text = item.Name,
                    Tag = item.PropertyType
                    
                };

                nodeRoot.Nodes.Add(nodeChild);
            }

            TreeNode nodeRoot2 = new TreeNode()
            {
                Text = "Organization"
            };
            tvColumns.Nodes.Add(nodeRoot2);
            foreach (PropertyInfo item in new organization().GetType().GetProperties())
            {
                TreeNode nodeChild = new DraggableTreeNode()
                {
                    PInfo = item,
                    Text = item.Name,
                    Tag = item.PropertyType
                };
                nodeRoot2.Nodes.Add(nodeChild);
            }

        }
        

        private void AddRecursive(object obj , TreeNode nodeParent)

        {

            foreach (PropertyInfo propInfo in obj.GetType().GetProperties())

            {

                TreeNode nodeChild = new TreeNode()
                {
                    Text = propInfo.Name
                };

                object obInner;

                try

                {

                    obInner = propInfo.GetValue(obj , null);

                }

                catch

                {

                    continue;

                }

                if (obInner == null)
                {
                
                    obInner="";
                }

                nodeParent.Nodes.Add(nodeChild);



                nodeChild.Text = $"{nodeChild.Text} = {obInner.ToString()}";

                if (!propInfo.PropertyType.IsPrimitive)
                {

                    AddRecursive(obInner , nodeChild);
                }
                IList list = obInner as IList;

                if (list != null)

                    foreach (object obChild in list)

                    {

                        TreeNode nodeChildInner = new TreeNode();

                        nodeChild.Nodes.Add(nodeChildInner);

                        AddRecursive(obChild , nodeChildInner);

                    }

            }

        }

        private void tvColumns_ItemDrag(object sender , ItemDragEventArgs e)
        {
            if (e.Item is DraggableTreeNode)
            {
                DoDragDrop(e.Item , DragDropEffects.Copy);
            }
        }

        private void flpColumns_DragDrop(object sender , DragEventArgs e)
        {
            DraggableTreeNode dtn = (DraggableTreeNode)e.Data.GetData(typeof(DraggableTreeNode));
            Button btn = new Button()
            {
                AutoSize = true,
                Text = $"{dtn.PInfo.ReflectedType.Name}.{dtn.PInfo.Name}"
            };
            btn.Click += new EventHandler(delegate { btn.Dispose(); });
            flpColumns.Controls.Add(btn);
        }

        private void flpColumns_DragEnter(object sender , DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void btnWhere_Click(object sender , EventArgs e)
        {
            FilterWhere ft = new FilterWhere(flpColumns);
            flpFilters.Controls.Add(ft);
        }

        private void btnGroupBy_Click(object sender , EventArgs e)
        {

        }

        private void btnOrderBy_Click(object sender , EventArgs e)
        {

        }
    }
}
