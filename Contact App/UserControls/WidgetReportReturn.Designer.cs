namespace Contact_App.UserControls
{
    partial class WidgetReportReturn
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
            this.OLVReportReturn = new BrightIdeasSoftware.ObjectListView();
            this.gboWidgetBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OLVReportReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // gboWidgetBox
            // 
            this.gboWidgetBox.Controls.Add(this.OLVReportReturn);
            // 
            // OLVReportReturn
            // 
            this.OLVReportReturn.CellEditUseWholeCell = false;
            this.OLVReportReturn.Cursor = System.Windows.Forms.Cursors.Default;
            this.OLVReportReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OLVReportReturn.Location = new System.Drawing.Point(3, 22);
            this.OLVReportReturn.Name = "OLVReportReturn";
            this.OLVReportReturn.Size = new System.Drawing.Size(383, 223);
            this.OLVReportReturn.TabIndex = 0;
            this.OLVReportReturn.UseCompatibleStateImageBehavior = false;
            this.OLVReportReturn.View = System.Windows.Forms.View.Details;
            // 
            // WidgetReportReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WidgetReportReturn";
            this.gboWidgetBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OLVReportReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView OLVReportReturn;
    }
}
