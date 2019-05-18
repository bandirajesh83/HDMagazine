namespace HDMagazine.Transactions
{
    partial class FrmInvoiceGeneration
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
            this.DtpMnthTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpMnthFrm = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpInvDt = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtLastInvoiceNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Go = new System.Windows.Forms.Button();
            this.LVInvoices = new System.Windows.Forms.ListView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Generate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(376, 17);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(97, 13);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Invoice Generation";
            // 
            // DtpMnthTo
            // 
            this.DtpMnthTo.CustomFormat = "dd-MMM-yy";
            this.DtpMnthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMnthTo.Location = new System.Drawing.Point(294, 80);
            this.DtpMnthTo.Name = "DtpMnthTo";
            this.DtpMnthTo.Size = new System.Drawing.Size(124, 20);
            this.DtpMnthTo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To Month";
            // 
            // DtpMnthFrm
            // 
            this.DtpMnthFrm.CustomFormat = "dd-MMM-yy";
            this.DtpMnthFrm.Enabled = false;
            this.DtpMnthFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMnthFrm.Location = new System.Drawing.Point(84, 80);
            this.DtpMnthFrm.Name = "DtpMnthFrm";
            this.DtpMnthFrm.Size = new System.Drawing.Size(124, 20);
            this.DtpMnthFrm.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "From Month";
            // 
            // DtpInvDt
            // 
            this.DtpInvDt.CustomFormat = "dd-MMM-yy";
            this.DtpInvDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpInvDt.Location = new System.Drawing.Point(603, 80);
            this.DtpInvDt.Name = "DtpInvDt";
            this.DtpInvDt.Size = new System.Drawing.Size(103, 20);
            this.DtpInvDt.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Invoice Date";
            // 
            // TxtLastInvoiceNo
            // 
            this.TxtLastInvoiceNo.Location = new System.Drawing.Point(102, 118);
            this.TxtLastInvoiceNo.Name = "TxtLastInvoiceNo";
            this.TxtLastInvoiceNo.Size = new System.Drawing.Size(184, 20);
            this.TxtLastInvoiceNo.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Last Invoice No";
            // 
            // Btn_Go
            // 
            this.Btn_Go.Location = new System.Drawing.Point(754, 113);
            this.Btn_Go.Name = "Btn_Go";
            this.Btn_Go.Size = new System.Drawing.Size(170, 23);
            this.Btn_Go.TabIndex = 28;
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
            this.LVInvoices.Location = new System.Drawing.Point(7, 162);
            this.LVInvoices.Name = "LVInvoices";
            this.LVInvoices.Size = new System.Drawing.Size(917, 276);
            this.LVInvoices.TabIndex = 29;
            this.LVInvoices.UseCompatibleStateImageBehavior = false;
            this.LVInvoices.View = System.Windows.Forms.View.Details;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 444);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Export to Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(487, 476);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(89, 23);
            this.Btn_Cancel.TabIndex = 32;
            this.Btn_Cancel.Text = "&Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Generate
            // 
            this.Btn_Generate.Location = new System.Drawing.Point(381, 476);
            this.Btn_Generate.Name = "Btn_Generate";
            this.Btn_Generate.Size = new System.Drawing.Size(100, 23);
            this.Btn_Generate.TabIndex = 31;
            this.Btn_Generate.Text = "&Generate";
            this.Btn_Generate.UseVisualStyleBackColor = true;
            this.Btn_Generate.Click += new System.EventHandler(this.Btn_Generate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1215, 457);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(821, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(103, 20);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(751, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Due Date";
            // 
            // FrmInvoiceGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 521);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Generate);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.LVInvoices);
            this.Controls.Add(this.Btn_Go);
            this.Controls.Add(this.TxtLastInvoiceNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtpInvDt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtpMnthTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpMnthFrm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmInvoiceGeneration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Generation";
            this.Load += new System.EventHandler(this.FrmInvoiceGeneration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.DateTimePicker DtpMnthTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpMnthFrm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpInvDt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtLastInvoiceNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Go;
        private System.Windows.Forms.ListView LVInvoices;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Generate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
    }
}