namespace Contact_App.UserControls
{
    partial class PhoneAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneAdd));
            this.wtrPN = new Contact_App.WaterMarkTextBox();
            this.btnRemove = new Contact_App.RoundButton();
            this.SuspendLayout();
            // 
            // wtrPN
            // 
            this.wtrPN.Location = new System.Drawing.Point(0, 2);
            this.wtrPN.Name = "wtrPN";
            this.wtrPN.Password = false;
            this.wtrPN.Size = new System.Drawing.Size(165, 20);
            this.wtrPN.TabIndex = 0;
            this.wtrPN.Tag = "Phone number";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(244, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 24);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // PhoneAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.wtrPN);
            this.Name = "PhoneAdd";
            this.Size = new System.Drawing.Size(270, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private WaterMarkTextBox wtrPN;
        private RoundButton btnRemove;
    }
}
