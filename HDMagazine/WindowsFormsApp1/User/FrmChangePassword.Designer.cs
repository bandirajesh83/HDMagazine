namespace HDMagazine.User
{
    partial class FrmChangePassword
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
            this.LblHdng = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.TxtOPwd = new System.Windows.Forms.TextBox();
            this.TxtNPwd = new System.Windows.Forms.TextBox();
            this.TxtCPwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(130, 9);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(93, 13);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Change Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Confirm Password";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(179, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 32);
            this.button3.TabIndex = 7;
            this.button3.Text = "&Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(133, 47);
            this.TxtUserName.MaxLength = 10;
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.ReadOnly = true;
            this.TxtUserName.Size = new System.Drawing.Size(214, 20);
            this.TxtUserName.TabIndex = 8;
            // 
            // TxtOPwd
            // 
            this.TxtOPwd.Location = new System.Drawing.Point(133, 81);
            this.TxtOPwd.MaxLength = 10;
            this.TxtOPwd.Name = "TxtOPwd";
            this.TxtOPwd.PasswordChar = '*';
            this.TxtOPwd.Size = new System.Drawing.Size(214, 20);
            this.TxtOPwd.TabIndex = 9;
            // 
            // TxtNPwd
            // 
            this.TxtNPwd.Location = new System.Drawing.Point(133, 114);
            this.TxtNPwd.MaxLength = 10;
            this.TxtNPwd.Name = "TxtNPwd";
            this.TxtNPwd.PasswordChar = '*';
            this.TxtNPwd.Size = new System.Drawing.Size(214, 20);
            this.TxtNPwd.TabIndex = 10;
            // 
            // TxtCPwd
            // 
            this.TxtCPwd.Location = new System.Drawing.Point(133, 150);
            this.TxtCPwd.MaxLength = 10;
            this.TxtCPwd.Name = "TxtCPwd";
            this.TxtCPwd.PasswordChar = '*';
            this.TxtCPwd.Size = new System.Drawing.Size(214, 20);
            this.TxtCPwd.TabIndex = 11;
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 250);
            this.Controls.Add(this.TxtCPwd);
            this.Controls.Add(this.TxtNPwd);
            this.Controls.Add(this.TxtOPwd);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.TextBox TxtOPwd;
        private System.Windows.Forms.TextBox TxtNPwd;
        private System.Windows.Forms.TextBox TxtCPwd;
    }
}