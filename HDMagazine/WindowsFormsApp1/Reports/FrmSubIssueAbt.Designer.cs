namespace HDMagazine.Reports
{
    partial class FrmSubIssueAbt
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DtpMnthTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpMnthFrm = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.LblHdng = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DtpMnthTo
            // 
            this.DtpMnthTo.CustomFormat = "MMM-yy";
            this.DtpMnthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMnthTo.Location = new System.Drawing.Point(311, 72);
            this.DtpMnthTo.Name = "DtpMnthTo";
            this.DtpMnthTo.Size = new System.Drawing.Size(122, 20);
            this.DtpMnthTo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "To";
            // 
            // DtpMnthFrm
            // 
            this.DtpMnthFrm.CustomFormat = "MMM-yy";
            this.DtpMnthFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMnthFrm.Location = new System.Drawing.Point(122, 73);
            this.DtpMnthFrm.Name = "DtpMnthFrm";
            this.DtpMnthFrm.Size = new System.Drawing.Size(122, 20);
            this.DtpMnthFrm.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period";
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(178, 19);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(112, 13);
            this.LblHdng.TabIndex = 7;
            this.LblHdng.Text = "Subscriptions Abstract";
            // 
            // FrmSubIssueAbt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 202);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DtpMnthTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpMnthFrm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSubIssueAbt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSubIssueAbt";
            this.Load += new System.EventHandler(this.FrmSubIssueAbt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker DtpMnthTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpMnthFrm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblHdng;
    }
}