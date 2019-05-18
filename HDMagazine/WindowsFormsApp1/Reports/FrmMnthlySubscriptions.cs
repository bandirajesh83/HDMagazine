using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMagazine.Reports
{
    public partial class FrmMnthlySubscriptions : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmMnthlySubscriptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            string cnd = " Where 1=1 ";
            if (checkBox1.Checked)
                cnd = cnd + " And issue_month='01-" + DtpMnth.Value.ToString("MMM-yyyy") + "'";
            if (checkBox2.Checked)
                cnd = cnd + " And Issue_date='" + DtpIssueDate.Value.ToString("dd-MMM-yyyy") + "'";
            if (TxtKeyword.Text.Trim().Length > 0)
                cnd = cnd + " And to_char(issue_id)||voucher_no||to_char(sub_id)||state_name||district_Name||sub_name||address||pin_code||email_id||contact_no||to_char(current_issue) like '%" + TxtKeyword.Text.Trim().ToUpper() + "%'";

            DataSet ds = db.GetTableData("select issue_id \"Book ID\", voucher_no \"Voucher No\", sub_id \"Subscription ID\", Sub_name \"Subcriber Name\", Address, State_name \"State\", District_name \"District\", Pin_Code \"PIN Code\",email_id \"E - Mail\", contact_no \"Contact No.\", to_char(issue_month,'MON-yy') \"Subscription Month\", to_char(issue_date,'dd-MON-yy') \"Dispatched Date\", current_issue \"Issued No\",SUB_TYPE_NAME \"Sub. Type\", EXECUTIVE_NAME \"Executive Name\", action_type from vew_labels " + cnd + " order by issue_id");
            DgvList.DataSource = ds.Tables[0];
            DgvList.Columns["action_type"].Visible = false;
            DgvList.Refresh();

            double qty = 0;
            ds = db.GetTableData("select nvl(sum(quantity),0) qty, decode(action_type,'U','I',action_type) Action_type from vew_labels " + cnd + " group by decode(action_type,'U','I',action_type)");
            foreach (DataRow dr in ds.Tables[0].Rows)
                qty = Convert.ToDouble(dr[0].ToString());

            label2.Text = "No. of Subscribers found : " + DgvList.Rows.Count.ToString() + " (No. of Books : " + qty.ToString() + ")";

            Cursor.Current = Cursors.Default;
            Application.DoEvents();
        }

        private void FrmMnthlySubscriptions_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            DataSet ds = db.GetTableData("select min(issue_month) mntfrm, max(issue_month) mntto, decode(action_type,'U','I',action_type) Action_Type from mas_sub_issues group by decode(action_type,'U','I',action_type)");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DtpMnth.MinDate = Convert.ToDateTime(dr["mntfrm"].ToString());
                DtpMnth.MaxDate = Convert.ToDateTime(dr["mntto"].ToString());
                DtpMnth.Value = Convert.ToDateTime(dr["mntto"].ToString()); 
            }
            ds = db.GetTableData("select min(issue_date) mntfrm, max(issue_date) mntto, decode(action_type,'U','I',action_type) Action_Type from mas_sub_issues group by decode(action_type,'U','I',action_type)");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DtpIssueDate.MinDate = Convert.ToDateTime(dr["mntfrm"].ToString());
                DtpIssueDate.MaxDate = Convert.ToDateTime(dr["mntto"].ToString());
                DtpIssueDate.Value = Convert.ToDateTime(dr["mntto"].ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DtpMnth.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DtpIssueDate.Enabled = checkBox2.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.ExportToExcel(DgvList);
        }
    }
}
