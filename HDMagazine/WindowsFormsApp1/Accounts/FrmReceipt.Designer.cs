namespace HDMagazine.Accounts
{
    partial class FrmReceipt
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbBank = new System.Windows.Forms.ComboBox();
            this.CmbPayMode = new System.Windows.Forms.ComboBox();
            this.DtpRefDt = new System.Windows.Forms.DateTimePicker();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.TxtRefNo = new System.Windows.Forms.TextBox();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtRcptCode = new System.Windows.Forms.TextBox();
            this.DtpRcptDt = new System.Windows.Forms.DateTimePicker();
            this.CmbPartyType = new System.Windows.Forms.ComboBox();
            this.CmbParty = new System.Windows.Forms.ComboBox();
            this.CmbRegion = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(300, 23);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(44, 13);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Receipt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Receipt Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Receipt Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Party Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Party Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbBank);
            this.groupBox1.Controls.Add(this.CmbPayMode);
            this.groupBox1.Controls.Add(this.DtpRefDt);
            this.groupBox1.Controls.Add(this.TxtRemarks);
            this.groupBox1.Controls.Add(this.TxtRefNo);
            this.groupBox1.Controls.Add(this.TxtAmount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 149);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Particulars";
            // 
            // CmbBank
            // 
            this.CmbBank.FormattingEnabled = true;
            this.CmbBank.Location = new System.Drawing.Point(114, 111);
            this.CmbBank.Name = "CmbBank";
            this.CmbBank.Size = new System.Drawing.Size(193, 21);
            this.CmbBank.TabIndex = 13;
            // 
            // CmbPayMode
            // 
            this.CmbPayMode.FormattingEnabled = true;
            this.CmbPayMode.Location = new System.Drawing.Point(395, 34);
            this.CmbPayMode.Name = "CmbPayMode";
            this.CmbPayMode.Size = new System.Drawing.Size(306, 21);
            this.CmbPayMode.TabIndex = 12;
            // 
            // DtpRefDt
            // 
            this.DtpRefDt.Location = new System.Drawing.Point(395, 72);
            this.DtpRefDt.Name = "DtpRefDt";
            this.DtpRefDt.Size = new System.Drawing.Size(306, 20);
            this.DtpRefDt.TabIndex = 10;
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Location = new System.Drawing.Point(395, 111);
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(306, 20);
            this.TxtRemarks.TabIndex = 11;
            // 
            // TxtRefNo
            // 
            this.TxtRefNo.Location = new System.Drawing.Point(114, 72);
            this.TxtRefNo.Name = "TxtRefNo";
            this.TxtRefNo.Size = new System.Drawing.Size(193, 20);
            this.TxtRefNo.TabIndex = 10;
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(114, 34);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(193, 20);
            this.TxtAmount.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Remarks";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Deposited In";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ref. Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ref.No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Payment Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Amount";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(361, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtRcptCode
            // 
            this.TxtRcptCode.Enabled = false;
            this.TxtRcptCode.Location = new System.Drawing.Point(126, 60);
            this.TxtRcptCode.Name = "TxtRcptCode";
            this.TxtRcptCode.ReadOnly = true;
            this.TxtRcptCode.Size = new System.Drawing.Size(193, 20);
            this.TxtRcptCode.TabIndex = 8;
            // 
            // DtpRcptDt
            // 
            this.DtpRcptDt.Location = new System.Drawing.Point(407, 60);
            this.DtpRcptDt.Name = "DtpRcptDt";
            this.DtpRcptDt.Size = new System.Drawing.Size(306, 20);
            this.DtpRcptDt.TabIndex = 9;
            this.DtpRcptDt.ValueChanged += new System.EventHandler(this.DtpRcptDt_ValueChanged);
            // 
            // CmbPartyType
            // 
            this.CmbPartyType.FormattingEnabled = true;
            this.CmbPartyType.Location = new System.Drawing.Point(126, 92);
            this.CmbPartyType.Name = "CmbPartyType";
            this.CmbPartyType.Size = new System.Drawing.Size(193, 21);
            this.CmbPartyType.TabIndex = 10;
            this.CmbPartyType.SelectedIndexChanged += new System.EventHandler(this.CmbPartyType_SelectedIndexChanged);
            // 
            // CmbParty
            // 
            this.CmbParty.FormattingEnabled = true;
            this.CmbParty.Location = new System.Drawing.Point(126, 124);
            this.CmbParty.Name = "CmbParty";
            this.CmbParty.Size = new System.Drawing.Size(587, 21);
            this.CmbParty.TabIndex = 11;
            // 
            // CmbRegion
            // 
            this.CmbRegion.FormattingEnabled = true;
            this.CmbRegion.Items.AddRange(new object[] {
            "Executive",
            "Distributor"});
            this.CmbRegion.Location = new System.Drawing.Point(407, 92);
            this.CmbRegion.Name = "CmbRegion";
            this.CmbRegion.Size = new System.Drawing.Size(306, 21);
            this.CmbRegion.TabIndex = 13;
            this.CmbRegion.SelectedIndexChanged += new System.EventHandler(this.CmbRegion_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(325, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Region";
            // 
            // FrmReceipt
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(731, 380);
            this.Controls.Add(this.CmbRegion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CmbParty);
            this.Controls.Add(this.CmbPartyType);
            this.Controls.Add(this.DtpRcptDt);
            this.Controls.Add(this.TxtRcptCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.FrmReceipt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.TextBox TxtRefNo;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.TextBox TxtRcptCode;
        private System.Windows.Forms.DateTimePicker DtpRefDt;
        private System.Windows.Forms.DateTimePicker DtpRcptDt;
        private System.Windows.Forms.ComboBox CmbPartyType;
        private System.Windows.Forms.ComboBox CmbParty;
        private System.Windows.Forms.ComboBox CmbBank;
        private System.Windows.Forms.ComboBox CmbPayMode;
        private System.Windows.Forms.ComboBox CmbRegion;
        private System.Windows.Forms.Label label11;
    }
}