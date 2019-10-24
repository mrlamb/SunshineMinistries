namespace Contact_App
{
    partial class WaterMarkTextBox
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
            this.wtrTextBox = new System.Windows.Forms.TextBox();
            this.wtrLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wtrTextBox
            // 
            this.wtrTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wtrTextBox.Location = new System.Drawing.Point(0, 0);
            this.wtrTextBox.Name = "wtrTextBox";
            this.wtrTextBox.Size = new System.Drawing.Size(255, 20);
            this.wtrTextBox.TabIndex = 0;
            this.wtrTextBox.TextChanged += new System.EventHandler(this.wtrTextBox_TextChanged);
            this.wtrTextBox.Enter += new System.EventHandler(this.wtrTextBox_Enter);
            this.wtrTextBox.Leave += new System.EventHandler(this.wtrTextBox_Leave);
            // 
            // wtrLabel
            // 
            this.wtrLabel.AutoSize = true;
            this.wtrLabel.BackColor = System.Drawing.SystemColors.Window;
            this.wtrLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wtrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wtrLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.wtrLabel.Location = new System.Drawing.Point(3, 3);
            this.wtrLabel.Name = "wtrLabel";
            this.wtrLabel.Size = new System.Drawing.Size(41, 13);
            this.wtrLabel.TabIndex = 1;
            this.wtrLabel.Text = "label1";
            this.wtrLabel.Click += new System.EventHandler(this.wtrLabel_Click);
            this.wtrLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.wtrLabel_Paint);
            // 
            // WaterMarkTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wtrLabel);
            this.Controls.Add(this.wtrTextBox);
            this.Name = "WaterMarkTextBox";
            this.Size = new System.Drawing.Size(255, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wtrTextBox;
        private System.Windows.Forms.Label wtrLabel;
    }
}
