namespace Contact_App
{
    partial class LoginBox
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.wtrPassword = new Contact_App.WaterMarkTextBox();
            this.wtrUserName = new Contact_App.WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(35, 87);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Location = new System.Drawing.Point(32, 113);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(0, 13);
            this.lblLoginStatus.TabIndex = 3;
            // 
            // wtrPassword
            // 
            this.wtrPassword.BackColor = System.Drawing.SystemColors.Window;
            this.wtrPassword.Location = new System.Drawing.Point(35, 61);
            this.wtrPassword.Name = "wtrPassword";
            this.wtrPassword.Size = new System.Drawing.Size(150, 20);
            this.wtrPassword.TabIndex = 1;
            this.wtrPassword.Tag = "Password";
            // 
            // wtrUserName
            // 
            this.wtrUserName.BackColor = System.Drawing.SystemColors.Window;
            this.wtrUserName.Location = new System.Drawing.Point(35, 35);
            this.wtrUserName.Name = "wtrUserName";
            this.wtrUserName.Size = new System.Drawing.Size(150, 20);
            this.wtrUserName.TabIndex = 0;
            this.wtrUserName.Tag = "Username";
            // 
            // LoginBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 180);
            this.Controls.Add(this.lblLoginStatus);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.wtrPassword);
            this.Controls.Add(this.wtrUserName);
            this.Name = "LoginBox";
            this.Text = "Contact App - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WaterMarkTextBox wtrUserName;
        private WaterMarkTextBox wtrPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginStatus;
    }
}