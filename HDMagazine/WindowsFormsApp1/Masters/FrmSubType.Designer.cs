namespace HDMagazine.Masters
{
    partial class FrmSubType
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtType = new System.Windows.Forms.TextBox();
            this.TxtIssues = new System.Windows.Forms.TextBox();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.LblPK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Location = new System.Drawing.Point(142, 9);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(92, 13);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Subscription Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subscription Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. of Magazines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Remarks";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 32);
            this.button3.TabIndex = 17;
            this.button3.Text = "&Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 32);
            this.button2.TabIndex = 16;
            this.button2.Text = "&Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtType
            // 
            this.TxtType.Location = new System.Drawing.Point(145, 74);
            this.TxtType.Name = "TxtType";
            this.TxtType.Size = new System.Drawing.Size(204, 20);
            this.TxtType.TabIndex = 18;
            // 
            // TxtIssues
            // 
            this.TxtIssues.Location = new System.Drawing.Point(145, 108);
            this.TxtIssues.Name = "TxtIssues";
            this.TxtIssues.Size = new System.Drawing.Size(204, 20);
            this.TxtIssues.TabIndex = 19;
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Location = new System.Drawing.Point(145, 145);
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(204, 20);
            this.TxtRemarks.TabIndex = 20;
            // 
            // LblPK
            // 
            this.LblPK.AutoSize = true;
            this.LblPK.Location = new System.Drawing.Point(23, 30);
            this.LblPK.Name = "LblPK";
            this.LblPK.Size = new System.Drawing.Size(0, 13);
            this.LblPK.TabIndex = 21;
            this.LblPK.Visible = false;
            // 
            // FrmSubType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 246);
            this.Controls.Add(this.LblPK);
            this.Controls.Add(this.TxtRemarks);
            this.Controls.Add(this.TxtIssues);
            this.Controls.Add(this.TxtType);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblHdng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSubType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subscription Type";
            this.Load += new System.EventHandler(this.FrmSubType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtType;
        private System.Windows.Forms.TextBox TxtIssues;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.Label LblPK;
    }
}