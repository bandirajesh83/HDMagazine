namespace HDMagazine.Transactions
{
    partial class FrmGenerateMnthlySubscriptions
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
            this.DtpMnth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDspchDt = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSub = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(84, 20);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(157, 13);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Generate Monthly Subscriptions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Month";
            // 
            // DtpMnth
            // 
            this.DtpMnth.CustomFormat = "MMMMM-yyyy";
            this.DtpMnth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMnth.Location = new System.Drawing.Point(203, 65);
            this.DtpMnth.Name = "DtpMnth";
            this.DtpMnth.Size = new System.Drawing.Size(200, 20);
            this.DtpMnth.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dispatch Date";
            // 
            // DtpDspchDt
            // 
            this.DtpDspchDt.CustomFormat = "MMMMM-yyyy";
            this.DtpDspchDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDspchDt.Location = new System.Drawing.Point(203, 103);
            this.DtpDspchDt.Name = "DtpDspchDt";
            this.DtpDspchDt.Size = new System.Drawing.Size(200, 20);
            this.DtpDspchDt.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "No. of Subscriptions Generated";
            // 
            // TxtSub
            // 
            this.TxtSub.Location = new System.Drawing.Point(203, 146);
            this.TxtSub.Name = "TxtSub";
            this.TxtSub.ReadOnly = true;
            this.TxtSub.Size = new System.Drawing.Size(200, 20);
            this.TxtSub.TabIndex = 8;
            // 
            // FrmGenerateMnthlySubscriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 255);
            this.Controls.Add(this.TxtSub);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DtpDspchDt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpMnth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGenerateMnthlySubscriptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Monthly Subscriptions";
            this.Load += new System.EventHandler(this.FrmGenerateMnthlySubscriptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpMnth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDspchDt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSub;
    }
}