namespace HDMagazine.Accounts
{
    partial class FrmSubBOS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpMnthFrm = new System.Windows.Forms.DateTimePicker();
            this.DtpMnthTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpInvDt = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtLastInvoiceNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Go = new System.Windows.Forms.Button();
            this.LVInvoices = new System.Windows.Forms.ListView();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Generate = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill of Supply (Subscribers)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Period";
            // 
            // DtpMnthFrm
            // 
            this.DtpMnthFrm.Location = new System.Drawing.Point(126, 65);
            this.DtpMnthFrm.Name = "DtpMnthFrm";
            this.DtpMnthFrm.Size = new System.Drawing.Size(130, 20);
            this.DtpMnthFrm.TabIndex = 2;
            // 
            // DtpMnthTo
            // 
            this.DtpMnthTo.Location = new System.Drawing.Point(306, 65);
            this.DtpMnthTo.Name = "DtpMnthTo";
            this.DtpMnthTo.Size = new System.Drawing.Size(130, 20);
            this.DtpMnthTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "dd-MMM-yy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(890, 65);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(103, 20);
            this.dateTimePicker3.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(820, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Due Date";
            // 
            // DtpInvDt
            // 
            this.DtpInvDt.CustomFormat = "dd-MMM-yy";
            this.DtpInvDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpInvDt.Location = new System.Drawing.Point(672, 65);
            this.DtpInvDt.Name = "DtpInvDt";
            this.DtpInvDt.Size = new System.Drawing.Size(103, 20);
            this.DtpInvDt.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Invoice Date";
            // 
            // TxtLastInvoiceNo
            // 
            this.TxtLastInvoiceNo.Location = new System.Drawing.Point(124, 101);
            this.TxtLastInvoiceNo.Name = "TxtLastInvoiceNo";
            this.TxtLastInvoiceNo.Size = new System.Drawing.Size(312, 20);
            this.TxtLastInvoiceNo.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Last Invoice No";
            // 
            // Btn_Go
            // 
            this.Btn_Go.Location = new System.Drawing.Point(823, 101);
            this.Btn_Go.Name = "Btn_Go";
            this.Btn_Go.Size = new System.Drawing.Size(170, 23);
            this.Btn_Go.TabIndex = 43;
            this.Btn_Go.Text = "&Show";
            this.Btn_Go.UseVisualStyleBackColor = true;
            this.Btn_Go.Click += new System.EventHandler(this.Btn_Go_Click);
            // 
            // LVInvoices
            // 
            this.LVInvoices.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.LVInvoices.CheckBoxes = true;
            this.LVInvoices.FullRowSelect = true;
            this.LVInvoices.GridLines = true;
            this.LVInvoices.Location = new System.Drawing.Point(32, 136);
            this.LVInvoices.Name = "LVInvoices";
            this.LVInvoices.Size = new System.Drawing.Size(961, 320);
            this.LVInvoices.TabIndex = 44;
            this.LVInvoices.UseCompatibleStateImageBehavior = false;
            this.LVInvoices.View = System.Windows.Forms.View.Details;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(528, 481);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(89, 23);
            this.Btn_Cancel.TabIndex = 46;
            this.Btn_Cancel.Text = "&Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Generate
            // 
            this.Btn_Generate.Location = new System.Drawing.Point(422, 481);
            this.Btn_Generate.Name = "Btn_Generate";
            this.Btn_Generate.Size = new System.Drawing.Size(100, 23);
            this.Btn_Generate.TabIndex = 45;
            this.Btn_Generate.Text = "&Generate";
            this.Btn_Generate.UseVisualStyleBackColor = true;
            this.Btn_Generate.Click += new System.EventHandler(this.Btn_Generate_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 462);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmSubBOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 522);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Generate);
            this.Controls.Add(this.LVInvoices);
            this.Controls.Add(this.Btn_Go);
            this.Controls.Add(this.TxtLastInvoiceNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtpInvDt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpMnthTo);
            this.Controls.Add(this.DtpMnthFrm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSubBOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill of Supply (Subscribers)";
            this.Load += new System.EventHandler(this.FrmSubBOS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpMnthFrm;
        private System.Windows.Forms.DateTimePicker DtpMnthTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpInvDt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtLastInvoiceNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Go;
        private System.Windows.Forms.ListView LVInvoices;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Generate;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}