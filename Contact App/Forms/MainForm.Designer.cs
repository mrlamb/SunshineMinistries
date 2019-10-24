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
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.lstRecordSelector = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelSearch = new System.Windows.Forms.ToolStripLabel();
            this.socialMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMainForm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabDashboard.SuspendLayout();
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
            this.administrateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizationToolStripMenuItem,
            this.individualToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // organizationToolStripMenuItem
            // 
            this.organizationToolStripMenuItem.Name = "organizationToolStripMenuItem";
            this.organizationToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.organizationToolStripMenuItem.Text = "Organization";
            this.organizationToolStripMenuItem.Click += new System.EventHandler(this.organizationToolStripMenuItem_Click);
            // 
            // individualToolStripMenuItem
            // 
            this.individualToolStripMenuItem.Name = "individualToolStripMenuItem";
            this.individualToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.individualToolStripMenuItem.Text = "Individual";
            this.individualToolStripMenuItem.Click += new System.EventHandler(this.individualToolStripMenuItem_Click);
            // 
            // administrateToolStripMenuItem
            // 
            this.administrateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.socialMediaToolStripMenuItem});
            this.administrateToolStripMenuItem.Name = "administrateToolStripMenuItem";
            this.administrateToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.administrateToolStripMenuItem.Text = "Administrate";
            this.administrateToolStripMenuItem.Visible = false;
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // tabDashboard
            // 
            this.tabDashboard.AutoScroll = true;
            this.tabDashboard.Controls.Add(this.lstRecordSelector);
            this.tabDashboard.Controls.Add(this.btnSearch);
            this.tabDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(1256, 882);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // lstRecordSelector
            // 
            this.lstRecordSelector.FormattingEnabled = true;
            this.lstRecordSelector.Location = new System.Drawing.Point(6, 6);
            this.lstRecordSelector.Name = "lstRecordSelector";
            this.lstRecordSelector.Size = new System.Drawing.Size(354, 173);
            this.lstRecordSelector.TabIndex = 43;
            this.lstRecordSelector.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstRecordSelector_MouseDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(169)))), ((int)(((byte)(41)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(272, 185);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 33);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDashboard);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(0, 52);
            this.tabControl.MinimumSize = new System.Drawing.Size(200, 200);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(16, 3);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1264, 908);
            this.tabControl.TabIndex = 23;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButtonSearch,
            this.toolStripTextBox,
            this.toolStripLabelSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
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
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "toolStripButtonSearch";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripTextBox
            // 
            this.toolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox.Margin = new System.Windows.Forms.Padding(1, 0, 5, 0);
            this.toolStripTextBox.Name = "toolStripTextBox";
            this.toolStripTextBox.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripLabelSearch
            // 
            this.toolStripLabelSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelSearch.Name = "toolStripLabelSearch";
            this.toolStripLabelSearch.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.toolStripLabelSearch.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabelSearch.Text = "Search";
            // 
            // socialMediaToolStripMenuItem
            // 
            this.socialMediaToolStripMenuItem.Name = "socialMediaToolStripMenuItem";
            this.socialMediaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.socialMediaToolStripMenuItem.Text = "Social Media";
            this.socialMediaToolStripMenuItem.Click += new System.EventHandler(this.socialMediaToolStripMenuItem_Click);
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
            this.Text = "Contacts App";
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.statusMainForm.ResumeLayout(false);
            this.statusMainForm.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabDashboard.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox lstRecordSelector;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individualToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSearch;
        private System.Windows.Forms.ToolStripStatusLabel tsslMainForm;
        private System.Windows.Forms.ToolStripMenuItem socialMediaToolStripMenuItem;
    }
}

