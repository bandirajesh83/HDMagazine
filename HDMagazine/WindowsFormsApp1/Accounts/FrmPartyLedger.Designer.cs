namespace HDMagazine.Accounts
{
    partial class FrmPartyLedger
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CmbPType = new System.Windows.Forms.ComboBox();
            this.CmbParty = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFrm = new System.Windows.Forms.DateTimePicker();
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(243, 9);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(67, 13);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Party Ledger";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Party Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Party";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(283, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CmbPType
            // 
            this.CmbPType.FormattingEnabled = true;
            this.CmbPType.Location = new System.Drawing.Point(120, 83);
            this.CmbPType.Name = "CmbPType";
            this.CmbPType.Size = new System.Drawing.Size(396, 21);
            this.CmbPType.TabIndex = 5;
            this.CmbPType.SelectedIndexChanged += new System.EventHandler(this.CmbPType_SelectedIndexChanged);
            // 
            // CmbParty
            // 
            this.CmbParty.FormattingEnabled = true;
            this.CmbParty.Location = new System.Drawing.Point(120, 122);
            this.CmbParty.Name = "CmbParty";
            this.CmbParty.Size = new System.Drawing.Size(396, 21);
            this.CmbParty.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Period";
            // 
            // DtpFrm
            // 
            this.DtpFrm.CustomFormat = "dd - MMM - yyyy";
            this.DtpFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFrm.Location = new System.Drawing.Point(120, 161);
            this.DtpFrm.Name = "DtpFrm";
            this.DtpFrm.Size = new System.Drawing.Size(132, 20);
            this.DtpFrm.TabIndex = 8;
            // 
            // DtpTo
            // 
            this.DtpTo.CustomFormat = "dd - MMM - yyyy";
            this.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpTo.Location = new System.Drawing.Point(384, 161);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(132, 20);
            this.DtpTo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "To";
            // 
            // FrmPartyLedger
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(562, 285);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtpTo);
            this.Controls.Add(this.DtpFrm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbParty);
            this.Controls.Add(this.CmbPType);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPartyLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Party Ledger";
            this.Load += new System.EventHandler(this.FrmPartyLedger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox CmbPType;
        private System.Windows.Forms.ComboBox CmbParty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFrm;
        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.Label label4;
    }
}