namespace Contact_App
{
    partial class OrganizationRecord
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
            this.wtrOrgName = new WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // wtrOrgName
            // 
            this.wtrOrgName.Location = new System.Drawing.Point(0, 0);
            this.wtrOrgName.Name = "wtrOrgName";
            this.wtrOrgName.Password = false;
            this.wtrOrgName.Size = new System.Drawing.Size(280, 20);
            this.wtrOrgName.TabIndex = 0;
            this.wtrOrgName.Tag = "Organization Name";
            // 
            // OrganizationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.wtrOrgName);
            this.Name = "OrganizationRecord";
            this.Size = new System.Drawing.Size(292, 276);
            this.ResumeLayout(false);

        }

        #endregion

        private WaterMarkTextBox wtrOrgName;
    }
}
