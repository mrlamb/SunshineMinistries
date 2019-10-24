namespace Contact_App.UserControls
{
    partial class OptionsSocialMediaTypes
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
            this.lstSocialMediaTypes = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstSocialMediaTypes
            // 
            this.lstSocialMediaTypes.FormattingEnabled = true;
            this.lstSocialMediaTypes.Location = new System.Drawing.Point(16, 67);
            this.lstSocialMediaTypes.Name = "lstSocialMediaTypes";
            this.lstSocialMediaTypes.Size = new System.Drawing.Size(113, 160);
            this.lstSocialMediaTypes.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(16, 233);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 38);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(16, 41);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(113, 20);
            this.txtNew.TabIndex = 3;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.Location = new System.Drawing.Point(16, 311);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMsg.TabIndex = 4;
            // 
            // OptionsSocialMediaTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSocialMediaTypes);
            this.Name = "OptionsSocialMediaTypes";
            this.Size = new System.Drawing.Size(329, 425);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSocialMediaTypes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblErrorMsg;
    }
}
