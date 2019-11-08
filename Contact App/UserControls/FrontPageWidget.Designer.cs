namespace Contact_App.UserControls
{
    partial class FrontPageWidget
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
            this.gboWidgetBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gboWidgetBox
            // 
            this.gboWidgetBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.gboWidgetBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboWidgetBox.Location = new System.Drawing.Point(0, 0);
            this.gboWidgetBox.Name = "gboWidgetBox";
            this.gboWidgetBox.Size = new System.Drawing.Size(389, 248);
            this.gboWidgetBox.TabIndex = 47;
            this.gboWidgetBox.TabStop = false;
            this.gboWidgetBox.Text = "Title";
            // 
            // FrontPageWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.gboWidgetBox);
            this.Name = "FrontPageWidget";
            this.Size = new System.Drawing.Size(392, 251);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gboWidgetBox;
    }
}
