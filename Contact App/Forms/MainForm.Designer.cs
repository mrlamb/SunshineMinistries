namespace Contact_App
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusMainForm = new System.Windows.Forms.StatusStrip();
            this.tsslMainForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.socialMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.gboSearchResults = new System.Windows.Forms.GroupBox();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelSearch = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.gboReportView = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusMainForm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            this.gboSearchResults.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusMainForm
            // 
            this.statusMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMainForm});
            this.statusMainForm.Location = new System.Drawing.Point(0, 960);
            this.statusMainForm.Name = "statusMainForm";
            this.statusMainForm.Size = new System.Drawing.Size(1264, 22);
            this.statusMainForm.TabIndex = 21;
            this.statusMainForm.Text = "Waiting to connect...";
            // 
            // tsslMainForm
            // 
            this.tsslMainForm.Name = "tsslMainForm";
            this.tsslMainForm.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.administrateToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 29);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizationToolStripMenuItem,
            this.individualToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // organizationToolStripMenuItem
            // 
            this.organizationToolStripMenuItem.Name = "organizationToolStripMenuItem";
            this.organizationToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.organizationToolStripMenuItem.Text = "Organization";
            this.organizationToolStripMenuItem.Click += new System.EventHandler(this.organizationToolStripMenuItem_Click);
            // 
            // individualToolStripMenuItem
            // 
            this.individualToolStripMenuItem.Name = "individualToolStripMenuItem";
            this.individualToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.individualToolStripMenuItem.Text = "Individual";
            this.individualToolStripMenuItem.Click += new System.EventHandler(this.individualToolStripMenuItem_Click);
            // 
            // administrateToolStripMenuItem
            // 
            this.administrateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.socialMediaToolStripMenuItem});
            this.administrateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.administrateToolStripMenuItem.Name = "administrateToolStripMenuItem";
            this.administrateToolStripMenuItem.Size = new System.Drawing.Size(111, 25);
            this.administrateToolStripMenuItem.Text = "Administrate";
            this.administrateToolStripMenuItem.Visible = false;
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // socialMediaToolStripMenuItem
            // 
            this.socialMediaToolStripMenuItem.Name = "socialMediaToolStripMenuItem";
            this.socialMediaToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.socialMediaToolStripMenuItem.Text = "Social Media";
            this.socialMediaToolStripMenuItem.Click += new System.EventHandler(this.socialMediaToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // tabDashboard
            // 
            this.tabDashboard.AutoScroll = true;
            this.tabDashboard.BackColor = System.Drawing.Color.NavajoWhite;
            this.tabDashboard.Controls.Add(this.comboBox1);
            this.tabDashboard.Controls.Add(this.gboReportView);
            this.tabDashboard.Controls.Add(this.gboSearchResults);
            this.tabDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(1256, 867);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            // 
            // gboSearchResults
            // 
            this.gboSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboSearchResults.AutoSize = true;
            this.gboSearchResults.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gboSearchResults.Controls.Add(this.lstSearchResults);
            this.gboSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboSearchResults.Location = new System.Drawing.Point(30, 30);
            this.gboSearchResults.Name = "gboSearchResults";
            this.gboSearchResults.Size = new System.Drawing.Size(1201, 250);
            this.gboSearchResults.TabIndex = 44;
            this.gboSearchResults.TabStop = false;
            this.gboSearchResults.Text = "Search Results";
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 20;
            this.lstSearchResults.Location = new System.Drawing.Point(3, 22);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(1195, 225);
            this.lstSearchResults.TabIndex = 43;
            this.lstSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseDoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDashboard);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(0, 67);
            this.tabControl.MinimumSize = new System.Drawing.Size(200, 200);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(16, 3);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1264, 893);
            this.tabControl.TabIndex = 23;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButtonSearch,
            this.toolStripTextBox,
            this.toolStripLabelSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 35);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox
            // 
            this.toolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox.Margin = new System.Windows.Forms.Padding(1, 0, 5, 0);
            this.toolStripTextBox.Name = "toolStripTextBox";
            this.toolStripTextBox.Size = new System.Drawing.Size(150, 35);
            // 
            // toolStripLabelSearch
            // 
            this.toolStripLabelSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabelSearch.Name = "toolStripLabelSearch";
            this.toolStripLabelSearch.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.toolStripLabelSearch.Size = new System.Drawing.Size(87, 32);
            this.toolStripLabelSearch.Text = "Search";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 32);
            this.toolStripButtonSearch.Text = "toolStripButtonSearch";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // gboReportView
            // 
            this.gboReportView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboReportView.AutoSize = true;
            this.gboReportView.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gboReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboReportView.Location = new System.Drawing.Point(33, 341);
            this.gboReportView.Name = "gboReportView";
            this.gboReportView.Size = new System.Drawing.Size(1201, 250);
            this.gboReportView.TabIndex = 45;
            this.gboReportView.TabStop = false;
            this.gboReportView.Text = "Select a saved report to view below";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(926, 341);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(301, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.comboBox1_ControlAdded);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusMainForm);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.statusMainForm.ResumeLayout(false);
            this.statusMainForm.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabDashboard.ResumeLayout(false);
            this.tabDashboard.PerformLayout();
            this.gboSearchResults.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusMainForm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individualToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSearch;
        private System.Windows.Forms.ToolStripStatusLabel tsslMainForm;
        private System.Windows.Forms.ToolStripMenuItem socialMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.GroupBox gboSearchResults;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox gboReportView;
    }
}

