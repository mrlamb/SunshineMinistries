namespace DataInputForms
{
    partial class ActionDetail
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
            this.txtHow = new System.Windows.Forms.TextBox();
            this.cmbWho = new System.Windows.Forms.ComboBox();
            this.cmbWhat = new System.Windows.Forms.ComboBox();
            this.dtpWhen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHow
            // 
            this.txtHow.Location = new System.Drawing.Point(49, 44);
            this.txtHow.Multiline = true;
            this.txtHow.Name = "txtHow";
            this.txtHow.Size = new System.Drawing.Size(639, 95);
            this.txtHow.TabIndex = 0;
            // 
            // cmbWho
            // 
            this.cmbWho.FormattingEnabled = true;
            this.cmbWho.Location = new System.Drawing.Point(49, 17);
            this.cmbWho.Name = "cmbWho";
            this.cmbWho.Size = new System.Drawing.Size(121, 21);
            this.cmbWho.TabIndex = 1;
            // 
            // cmbWhat
            // 
            this.cmbWhat.FormattingEnabled = true;
            this.cmbWhat.Location = new System.Drawing.Point(286, 17);
            this.cmbWhat.Name = "cmbWhat";
            this.cmbWhat.Size = new System.Drawing.Size(121, 21);
            this.cmbWhat.TabIndex = 2;
            // 
            // dtpWhen
            // 
            this.dtpWhen.Location = new System.Drawing.Point(488, 17);
            this.dtpWhen.Name = "dtpWhen";
            this.dtpWhen.Size = new System.Drawing.Size(200, 20);
            this.dtpWhen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "performed the action";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "on or about";
            // 
            // button1
            // 
            this.btnSave.Location = new System.Drawing.Point(49, 146);
            this.btnSave.Name = "button1";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(612, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 209);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpWhen);
            this.Controls.Add(this.cmbWhat);
            this.Controls.Add(this.cmbWho);
            this.Controls.Add(this.txtHow);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Action Detail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHow;
        private System.Windows.Forms.ComboBox cmbWho;
        private System.Windows.Forms.ComboBox cmbWhat;
        private System.Windows.Forms.DateTimePicker dtpWhen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
    }
}