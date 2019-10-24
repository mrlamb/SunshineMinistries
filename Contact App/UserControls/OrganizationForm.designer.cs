namespace DataInputForms
{
    partial class OrganizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizationForm));
            this.rdoFinYes = new System.Windows.Forms.RadioButton();
            this.rdoFinNo = new System.Windows.Forms.RadioButton();
            this.groupFinancial = new System.Windows.Forms.GroupBox();
            this.groupBasic = new System.Windows.Forms.GroupBox();
            this.flpPhoneNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.groupPrimAddress = new System.Windows.Forms.GroupBox();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.btnRemAction = new System.Windows.Forms.Button();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.cmbState2 = new System.Windows.Forms.ComboBox();
            this.groupSecondAddress = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupSocial = new System.Windows.Forms.GroupBox();
            this.btnAddSM = new System.Windows.Forms.Button();
            this.flpSocial = new System.Windows.Forms.FlowLayoutPanel();
            this.groupNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.wtrZip2 = new Contact_App.WaterMarkTextBox();
            this.wtrStreetAddress2 = new Contact_App.WaterMarkTextBox();
            this.wtrCity2 = new Contact_App.WaterMarkTextBox();
            this.btnAddPhone = new Contact_App.RoundButton();
            this.wtrOrgName = new Contact_App.WaterMarkTextBox();
            this.wtrPhone = new Contact_App.WaterMarkTextBox();
            this.wtrID = new Contact_App.WaterMarkTextBox();
            this.wtrZip = new Contact_App.WaterMarkTextBox();
            this.wtrStreetAddress = new Contact_App.WaterMarkTextBox();
            this.wtrCity = new Contact_App.WaterMarkTextBox();
            this.groupFinancial.SuspendLayout();
            this.groupBasic.SuspendLayout();
            this.groupPrimAddress.SuspendLayout();
            this.groupActions.SuspendLayout();
            this.groupSecondAddress.SuspendLayout();
            this.groupSocial.SuspendLayout();
            this.groupNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoFinYes
            // 
            this.rdoFinYes.AutoSize = true;
            this.rdoFinYes.Location = new System.Drawing.Point(17, 26);
            this.rdoFinYes.Name = "rdoFinYes";
            this.rdoFinYes.Size = new System.Drawing.Size(42, 17);
            this.rdoFinYes.TabIndex = 13;
            this.rdoFinYes.TabStop = true;
            this.rdoFinYes.Text = "Yes";
            this.rdoFinYes.UseVisualStyleBackColor = true;
            // 
            // rdoFinNo
            // 
            this.rdoFinNo.AutoSize = true;
            this.rdoFinNo.Location = new System.Drawing.Point(80, 26);
            this.rdoFinNo.Name = "rdoFinNo";
            this.rdoFinNo.Size = new System.Drawing.Size(41, 17);
            this.rdoFinNo.TabIndex = 199;
            this.rdoFinNo.TabStop = true;
            this.rdoFinNo.Text = "No";
            this.rdoFinNo.UseVisualStyleBackColor = true;
            // 
            // groupFinancial
            // 
            this.groupFinancial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupFinancial.Controls.Add(this.rdoFinNo);
            this.groupFinancial.Controls.Add(this.rdoFinYes);
            this.groupFinancial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFinancial.Location = new System.Drawing.Point(767, 14);
            this.groupFinancial.Name = "groupFinancial";
            this.groupFinancial.Size = new System.Drawing.Size(131, 64);
            this.groupFinancial.TabIndex = 246;
            this.groupFinancial.TabStop = false;
            this.groupFinancial.Text = "Financial Support";
            // 
            // groupBasic
            // 
            this.groupBasic.Controls.Add(this.btnAddPhone);
            this.groupBasic.Controls.Add(this.flpPhoneNumbers);
            this.groupBasic.Controls.Add(this.wtrOrgName);
            this.groupBasic.Controls.Add(this.wtrPhone);
            this.groupBasic.Controls.Add(this.wtrID);
            this.groupBasic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBasic.Location = new System.Drawing.Point(12, 14);
            this.groupBasic.Name = "groupBasic";
            this.groupBasic.Size = new System.Drawing.Size(395, 221);
            this.groupBasic.TabIndex = 252;
            this.groupBasic.TabStop = false;
            this.groupBasic.Text = "Basic Information";
            // 
            // flpPhoneNumbers
            // 
            this.flpPhoneNumbers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPhoneNumbers.Location = new System.Drawing.Point(107, 77);
            this.flpPhoneNumbers.Name = "flpPhoneNumbers";
            this.flpPhoneNumbers.Size = new System.Drawing.Size(279, 127);
            this.flpPhoneNumbers.TabIndex = 241;
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(155, 43);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 21);
            this.cmbState.TabIndex = 242;
            // 
            // groupPrimAddress
            // 
            this.groupPrimAddress.Controls.Add(this.wtrZip);
            this.groupPrimAddress.Controls.Add(this.wtrStreetAddress);
            this.groupPrimAddress.Controls.Add(this.cmbState);
            this.groupPrimAddress.Controls.Add(this.wtrCity);
            this.groupPrimAddress.Location = new System.Drawing.Point(452, 14);
            this.groupPrimAddress.Name = "groupPrimAddress";
            this.groupPrimAddress.Size = new System.Drawing.Size(292, 106);
            this.groupPrimAddress.TabIndex = 250;
            this.groupPrimAddress.TabStop = false;
            this.groupPrimAddress.Text = "Primary Address";
            // 
            // lstActions
            // 
            this.lstActions.FormattingEnabled = true;
            this.lstActions.Location = new System.Drawing.Point(5, 16);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(869, 95);
            this.lstActions.TabIndex = 245;
            this.lstActions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstActions_MouseDoubleClick);
            // 
            // btnAddAction
            // 
            this.btnAddAction.Location = new System.Drawing.Point(8, 117);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(103, 23);
            this.btnAddAction.TabIndex = 246;
            this.btnAddAction.Text = "Add Action";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // btnRemAction
            // 
            this.btnRemAction.Location = new System.Drawing.Point(118, 117);
            this.btnRemAction.Name = "btnRemAction";
            this.btnRemAction.Size = new System.Drawing.Size(103, 23);
            this.btnRemAction.TabIndex = 247;
            this.btnRemAction.Text = "Remove Action";
            this.btnRemAction.UseVisualStyleBackColor = true;
            // 
            // groupActions
            // 
            this.groupActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupActions.Controls.Add(this.btnRemAction);
            this.groupActions.Controls.Add(this.btnAddAction);
            this.groupActions.Controls.Add(this.lstActions);
            this.groupActions.Location = new System.Drawing.Point(12, 511);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(886, 169);
            this.groupActions.TabIndex = 253;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Actions";
            // 
            // cmbState2
            // 
            this.cmbState2.FormattingEnabled = true;
            this.cmbState2.Location = new System.Drawing.Point(155, 43);
            this.cmbState2.Name = "cmbState2";
            this.cmbState2.Size = new System.Drawing.Size(121, 21);
            this.cmbState2.TabIndex = 242;
            // 
            // groupSecondAddress
            // 
            this.groupSecondAddress.Controls.Add(this.wtrZip2);
            this.groupSecondAddress.Controls.Add(this.wtrStreetAddress2);
            this.groupSecondAddress.Controls.Add(this.cmbState2);
            this.groupSecondAddress.Controls.Add(this.wtrCity2);
            this.groupSecondAddress.Location = new System.Drawing.Point(452, 129);
            this.groupSecondAddress.Name = "groupSecondAddress";
            this.groupSecondAddress.Size = new System.Drawing.Size(292, 106);
            this.groupSecondAddress.TabIndex = 251;
            this.groupSecondAddress.TabStop = false;
            this.groupSecondAddress.Text = "Secondary Address";
            // 
            // groupSocial
            // 
            this.groupSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupSocial.Controls.Add(this.btnAddSM);
            this.groupSocial.Controls.Add(this.flpSocial);
            this.groupSocial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSocial.ForeColor = System.Drawing.Color.Black;
            this.groupSocial.Location = new System.Drawing.Point(12, 253);
            this.groupSocial.Name = "groupSocial";
            this.groupSocial.Size = new System.Drawing.Size(395, 236);
            this.groupSocial.TabIndex = 248;
            this.groupSocial.TabStop = false;
            this.groupSocial.Text = "Social Media";
            // 
            // btnAddSM
            // 
            this.btnAddSM.Location = new System.Drawing.Point(9, 19);
            this.btnAddSM.Name = "btnAddSM";
            this.btnAddSM.Size = new System.Drawing.Size(75, 23);
            this.btnAddSM.TabIndex = 1;
            this.btnAddSM.Text = "Add New";
            this.btnAddSM.UseVisualStyleBackColor = true;
            this.btnAddSM.Click += new System.EventHandler(this.btnAddSM_Click);
            // 
            // flpSocial
            // 
            this.flpSocial.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSocial.Location = new System.Drawing.Point(9, 55);
            this.flpSocial.Name = "flpSocial";
            this.flpSocial.Size = new System.Drawing.Size(377, 172);
            this.flpSocial.TabIndex = 0;
            // 
            // groupNotes
            // 
            this.groupNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupNotes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupNotes.BackgroundImage")));
            this.groupNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupNotes.Controls.Add(this.txtNotes);
            this.groupNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNotes.Location = new System.Drawing.Point(767, 129);
            this.groupNotes.Name = "groupNotes";
            this.groupNotes.Size = new System.Drawing.Size(356, 312);
            this.groupNotes.TabIndex = 247;
            this.groupNotes.TabStop = false;
            this.groupNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Location = new System.Drawing.Point(4, 34);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(344, 251);
            this.txtNotes.TabIndex = 16;
            // 
            // wtrZip2
            // 
            this.wtrZip2.Location = new System.Drawing.Point(5, 69);
            this.wtrZip2.Name = "wtrZip2";
            this.wtrZip2.Password = false;
            this.wtrZip2.Size = new System.Drawing.Size(104, 20);
            this.wtrZip2.TabIndex = 244;
            this.wtrZip2.Tag = "Zip Code";
            // 
            // wtrStreetAddress2
            // 
            this.wtrStreetAddress2.Location = new System.Drawing.Point(5, 16);
            this.wtrStreetAddress2.Name = "wtrStreetAddress2";
            this.wtrStreetAddress2.Password = false;
            this.wtrStreetAddress2.Size = new System.Drawing.Size(272, 20);
            this.wtrStreetAddress2.TabIndex = 240;
            this.wtrStreetAddress2.Tag = "Street Address";
            // 
            // wtrCity2
            // 
            this.wtrCity2.Location = new System.Drawing.Point(5, 43);
            this.wtrCity2.Name = "wtrCity2";
            this.wtrCity2.Password = false;
            this.wtrCity2.Size = new System.Drawing.Size(144, 20);
            this.wtrCity2.TabIndex = 241;
            this.wtrCity2.Tag = "City";
            // 
            // btnAddPhone
            // 
            this.btnAddPhone.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPhone.BackgroundImage = global::Contact_App.Properties.Resources.PlusSign;
            this.btnAddPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddPhone.FlatAppearance.BorderSize = 0;
            this.btnAddPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPhone.Location = new System.Drawing.Point(354, 51);
            this.btnAddPhone.Name = "btnAddPhone";
            this.btnAddPhone.Size = new System.Drawing.Size(24, 24);
            this.btnAddPhone.TabIndex = 242;
            this.btnAddPhone.UseVisualStyleBackColor = false;
            this.btnAddPhone.Click += new System.EventHandler(this.btnAddPhone_Click);
            // 
            // wtrOrgName
            // 
            this.wtrOrgName.Location = new System.Drawing.Point(108, 24);
            this.wtrOrgName.Name = "wtrOrgName";
            this.wtrOrgName.Password = false;
            this.wtrOrgName.Size = new System.Drawing.Size(239, 20);
            this.wtrOrgName.TabIndex = 240;
            this.wtrOrgName.Tag = "Organization Name";
            // 
            // wtrPhone
            // 
            this.wtrPhone.Location = new System.Drawing.Point(109, 51);
            this.wtrPhone.Name = "wtrPhone";
            this.wtrPhone.Password = false;
            this.wtrPhone.Size = new System.Drawing.Size(165, 20);
            this.wtrPhone.TabIndex = 239;
            this.wtrPhone.Tag = "Primary Phone Number";
            // 
            // wtrID
            // 
            this.wtrID.Location = new System.Drawing.Point(8, 24);
            this.wtrID.Name = "wtrID";
            this.wtrID.Password = false;
            this.wtrID.Size = new System.Drawing.Size(90, 20);
            this.wtrID.TabIndex = 236;
            this.wtrID.Tag = "Sunshine ID";
            // 
            // wtrZip
            // 
            this.wtrZip.Location = new System.Drawing.Point(6, 70);
            this.wtrZip.Name = "wtrZip";
            this.wtrZip.Password = false;
            this.wtrZip.Size = new System.Drawing.Size(104, 20);
            this.wtrZip.TabIndex = 243;
            this.wtrZip.Tag = "Zip Code";
            // 
            // wtrStreetAddress
            // 
            this.wtrStreetAddress.Location = new System.Drawing.Point(5, 16);
            this.wtrStreetAddress.Name = "wtrStreetAddress";
            this.wtrStreetAddress.Password = false;
            this.wtrStreetAddress.Size = new System.Drawing.Size(272, 20);
            this.wtrStreetAddress.TabIndex = 240;
            this.wtrStreetAddress.Tag = "Street Address";
            // 
            // wtrCity
            // 
            this.wtrCity.Location = new System.Drawing.Point(5, 43);
            this.wtrCity.Name = "wtrCity";
            this.wtrCity.Password = false;
            this.wtrCity.Size = new System.Drawing.Size(144, 20);
            this.wtrCity.TabIndex = 241;
            this.wtrCity.Tag = "City";
            // 
            // OrganizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.groupSocial);
            this.Controls.Add(this.groupActions);
            this.Controls.Add(this.groupSecondAddress);
            this.Controls.Add(this.groupBasic);
            this.Controls.Add(this.groupPrimAddress);
            this.Controls.Add(this.groupNotes);
            this.Controls.Add(this.groupFinancial);
            this.Name = "OrganizationForm";
            this.Size = new System.Drawing.Size(1471, 1032);
            this.groupFinancial.ResumeLayout(false);
            this.groupFinancial.PerformLayout();
            this.groupBasic.ResumeLayout(false);
            this.groupPrimAddress.ResumeLayout(false);
            this.groupActions.ResumeLayout(false);
            this.groupSecondAddress.ResumeLayout(false);
            this.groupSocial.ResumeLayout(false);
            this.groupNotes.ResumeLayout(false);
            this.groupNotes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoFinYes;
        private System.Windows.Forms.RadioButton rdoFinNo;
        private System.Windows.Forms.GroupBox groupFinancial;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupNotes;
        private Contact_App.WaterMarkTextBox wtrID;
        private Contact_App.WaterMarkTextBox wtrPhone;
        private System.Windows.Forms.GroupBox groupBasic;
        private Contact_App.WaterMarkTextBox wtrOrgName;
        private Contact_App.WaterMarkTextBox wtrCity;
        private System.Windows.Forms.ComboBox cmbState;
        private Contact_App.WaterMarkTextBox wtrStreetAddress;
        private Contact_App.WaterMarkTextBox wtrZip;
        private System.Windows.Forms.GroupBox groupPrimAddress;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.Button btnRemAction;
        private System.Windows.Forms.GroupBox groupActions;
        private Contact_App.WaterMarkTextBox wtrCity2;
        private System.Windows.Forms.ComboBox cmbState2;
        private Contact_App.WaterMarkTextBox wtrStreetAddress2;
        private Contact_App.WaterMarkTextBox wtrZip2;
        private System.Windows.Forms.GroupBox groupSecondAddress;
        private System.Windows.Forms.FlowLayoutPanel flpPhoneNumbers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Contact_App.RoundButton btnAddPhone;
        private System.Windows.Forms.GroupBox groupSocial;
        private System.Windows.Forms.Button btnAddSM;
        private System.Windows.Forms.FlowLayoutPanel flpSocial;
    }
}
