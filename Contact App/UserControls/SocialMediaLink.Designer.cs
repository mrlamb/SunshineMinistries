namespace Contact_App.UserControls
{
    partial class SocialMediaLink
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
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(4, 4);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(55, 13);
            this.linkLabel.TabIndex = 0;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "linkLabel1";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = global::Contact_App.Properties.Resources.RedX2;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Location = new System.Drawing.Point(286, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(20, 20);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // SocialMediaLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.linkLabel);
            this.Name = "SocialMediaLink";
            this.Size = new System.Drawing.Size(309, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Button btnRemove;
    }
}
