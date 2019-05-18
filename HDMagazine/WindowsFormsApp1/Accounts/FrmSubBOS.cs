using HDMagazine.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMagazine.Accounts
{
    public partial class FrmSubBOS : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmSubBOS()
        {
            InitializeComponent();
        }

        private void FrmSubBOS_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            DataSet ds = db.GetTableData("select max(invoice_date) Invoice_Date, action_type from HDR_ACC_BS_INVOICE group by action_type");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    DtpInvDt.MinDate = Convert.ToDateTime(dr["Invoice_Date"].ToString());
            }

            ds = db.GetTableData("Select max(invoice_code) Invoice_Code, action_type from hdr_acc_bs_invoice group by action_type");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    TxtLastInvoiceNo.Text = dr["Invoice_code"].ToString();
            }
            else
            {
                DateTime DtSysDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                int Dts = Convert.ToInt32(DtSysDate.Month.ToString() + DtSysDate.ToString("dd"));
                string DtMon = DtSysDate.ToString("MM");
                string FY = "";
                if (Dts >= 101 && Dts <= 331)
                    FY = DtSysDate.AddYears(-1).ToString("yy") + "-" + DtSysDate.ToString("yy");
                else FY = DtSysDate.ToString("yy") + "-" + DtSysDate.AddYears(1).ToString("yy");
                TxtLastInvoiceNo.Text = "IN/HBS/" + FY + "/00001";
            }
        }

        private void Btn_Go_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            DataSet ds = db.GetTableData("select to_char(issue_month,'MON-yyyy') Month,Gst_State_Code,State_name,Yr1_P, Yr1_amt,Yr3_P,Yr3_amt,Yr5_p, Yr5_Amt,Compl,Paid_No Total_Paid,Amount Total_Amount,Action_Type From vew_SUB_BOS where issue_month between '01-" + DtpMnthFrm.Value.ToString("MMM-yy") + "' and '01-" + DtpMnthTo.Value.ToString("MMM-yy") + "'");
            LVInvoices.Columns.Clear();
            LVInvoices.Items.Clear();
            LVInvoices.View = View.Details;

            for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
            {
                LVInvoices.Columns.Add(ds.Tables[0].Columns[c].ColumnName.ToString());
                if (c >= 3 && c <= 11)
                    LVInvoices.Columns[c].TextAlign = HorizontalAlignment.Right;
            }

            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem(drow["Month"].ToString());
                for (int j = 1; j < ds.Tables[0].Columns.Count; j++)
                    lvi.SubItems.Add(drow[j].ToString());
                LVInvoices.Items.Add(lvi);
            }

            for (int k = 0; k < LVInvoices.Columns.Count; k++)
                LVInvoices.Columns[k].Width = -2;

            for (int l = 12; l < LVInvoices.Columns.Count; l++)
                LVInvoices.Columns[l].Width = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < LVInvoices.Items.Count; i++)
                    LVInvoices.Items[i].Checked = true;
            }
            else
            {
                for (int i = 0; i < LVInvoices.Items.Count; i++)
                    LVInvoices.Items[i].Checked = false;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            if (LVInvoices.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Please select the items for generating Invoices", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure, Do you want  to Generate Invoice(s)..?", "HD Magazine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < LVInvoices.Items.Count; i++)
                {
                    if (LVInvoices.Items[i].Checked == true)
                    {
                        string invcode = db.GetAccCode("IN", "hdr_acc_BS_invoice", "Invoice_Code", DtpInvDt.Value);

                        string[] res = db.ExecuteQueries("Insert into mas_acc_bs_invoice values ('" + invcode + "','" + DtpInvDt.Value.ToString("dd-MMM-yy") + "','" + db.GetFinYr(DtpInvDt.Value) + "',1,0," + LVInvoices.Items[i].SubItems[1].Text.ToString() + ",'01-" + LVInvoices.Items[i].Text.ToString() + "','01-" + LVInvoices.Items[i].Text.ToString() + "',"+ LVInvoices.Items[i].SubItems[11].Text.ToString() + ",null,null,null,null,null,null,"+ GlobalClass.UserName + "',sysdate,null,null,'I')").Split(',');
                        if (res[0].ToString() != "0")
                        {
                            MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        res = db.ExecuteQueries("Update mas_capsulling set invoice_code='" + invcode + "' where ro_header_code='" + LVInvoices.Items[i].Text.ToString() + "' and tx_month between '01-" + DtpMnthFrm.Value.ToString("MMM-yy") + "' and '01-" + DtpMnthTo.Value.ToString("MMM-yy") + "'").Split(',');
                        if (res[0].ToString() != "0")
                        {
                            MessageBox.Show("Updation Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                MessageBox.Show("Successfully Generated", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoices();
            }
        }
    }
}
