namespace Contact_App.UserControls
{
    partial class ReportTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnOrderBy = new System.Windows.Forms.Button();
            this.btnGroupBy = new System.Windows.Forms.Button();
            this.btnWhere = new System.Windows.Forms.Button();
            this.wtrReportTitle = new Contact_App.WaterMarkTextBox();
            this.flpColumns = new System.Windows.Forms.FlowLayoutPanel();
            this.tvColumns = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.flpFilters);
            this.panel1.Controls.Add(this.gbFilters);
            this.panel1.Controls.Add(this.wtrReportTitle);
            this.panel1.Controls.Add(this.flpColumns);
            this.panel1.Controls.Add(this.tvColumns);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 595);
            this.panel1.TabIndex = 1;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.AutoSize = true;
            this.btnGenerateReport.Location = new System.Drawing.Point(210, 420);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(96, 23);
            this.btnGenerateReport.TabIndex = 6;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // flpFilters
            // 
            this.flpFilters.AutoSize = true;
            this.flpFilters.Location = new System.Drawing.Point(210, 224);
            this.flpFilters.Name = "flpFilters";
            this.flpFilters.Size = new System.Drawing.Size(239, 189);
            this.flpFilters.TabIndex = 5;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnOrderBy);
            this.gbFilters.Controls.Add(this.btnGroupBy);
            this.gbFilters.Controls.Add(this.btnWhere);
            this.gbFilters.Location = new System.Drawing.Point(204, 157);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(520, 61);
            this.gbFilters.TabIndex = 4;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filters/Clauses";
            // 
            // btnOrderBy
            // 
            this.btnOrderBy.Location = new System.Drawing.Point(170, 32);
            this.btnOrderBy.Name = "btnOrderBy";
            this.btnOrderBy.Size = new System.Drawing.Size(75, 23);
            this.btnOrderBy.TabIndex = 2;
            this.btnOrderBy.Text = "Order By";
            this.btnOrderBy.UseVisualStyleBackColor = true;
            this.btnOrderBy.Click += new System.EventHandler(this.btnOrderBy_Click);
            // 
            // btnGroupBy
            // 
            this.btnGroupBy.Location = new System.Drawing.Point(88, 32);
            this.btnGroupBy.Name = "btnGroupBy";
            this.btnGroupBy.Size = new System.Drawing.Size(75, 23);
            this.btnGroupBy.TabIndex = 1;
            this.btnGroupBy.Text = "Group By";
            this.btnGroupBy.UseVisualStyleBackColor = true;
            this.btnGroupBy.Click += new System.EventHandler(this.btnGroupBy_Click);
            // 
            // btnWhere
            // 
            this.btnWhere.Location = new System.Drawing.Point(6, 32);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(75, 23);
            this.btnWhere.TabIndex = 0;
            this.btnWhere.Text = "Where";
            this.btnWhere.UseVisualStyleBackColor = true;
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // wtrReportTitle
            // 
            this.wtrReportTitle.Location = new System.Drawing.Point(204, 15);
            this.wtrReportTitle.Name = "wtrReportTitle";
            this.wtrReportTitle.Password = false;
            this.wtrReportTitle.Size = new System.Drawing.Size(255, 20);
            this.wtrReportTitle.TabIndex = 3;
            this.wtrReportTitle.Tag = "Report Title";
            // 
            // flpColumns
            // 
            this.flpColumns.AllowDrop = true;
            this.flpColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpColumns.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpColumns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpColumns.Location = new System.Drawing.Point(203, 41);
            this.flpColumns.Name = "flpColumns";
            this.flpColumns.Size = new System.Drawing.Size(521, 109);
            this.flpColumns.TabIndex = 2;
            this.flpColumns.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpColumns_DragDrop);
            this.flpColumns.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpColumns_DragEnter);
            // 
            // tvColumns
            // 
            this.tvColumns.Location = new System.Drawing.Point(15, 15);
            this.tvColumns.Name = "tvColumns";
            this.tvColumns.Size = new System.Drawing.Size(182, 398);
            this.tvColumns.TabIndex = 1;
            this.tvColumns.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvColumns_ItemDrag);
            this.tvColumns.DoubleClick += new System.EventHandler(this.tvColumns_DoubleClick);
            // 
            // ReportTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ReportTab";
            this.Size = new System.Drawing.Size(739, 595);
            this.Load += new System.EventHandler(this.ReportTab_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvColumns;
        private System.Windows.Forms.FlowLayoutPanel flpColumns;
        private WaterMarkTextBox wtrReportTitle;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnOrderBy;
        private System.Windows.Forms.Button btnGroupBy;
        private System.Windows.Forms.Button btnWhere;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}
