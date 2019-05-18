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

namespace HDMagazine.Transactions
{
    public partial class FrmGenerateMnthlySubscriptions : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmGenerateMnthlySubscriptions()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGenerateMnthlySubscriptions_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            DataSet ds = db.GetTableData("select max(issue_month) mnth, action_type from mas_sub_issues group by action_type");
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                DtpMnth.Value = Convert.ToDateTime("01-" + Convert.ToDateTime(dr["mnth"].ToString()).ToString("MMM-yy"));
                DtpMnth.MinDate = Convert.ToDateTime("01-" + Convert.ToDateTime(dr["mnth"].ToString()).ToString("MMM-yy"));
            }
            DtpDspchDt.Value = DateTime.Now;
            DtpDspchDt.MinDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure, Do you want to Generate...?","HD Magazine", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                int gensubs = 0;
                DataSet ds = db.GetTableData("select * from mas_sub_pay_details where ('01-" + DtpMnth.Value.ToString("MMM-yy") + "' between period_frm and period_to) and sub_id not in (select sub_id from mas_sub_issues where issue_month='01-" + DtpMnth.Value.ToString("MMM-yy") + "')");
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    int issue = 1;
                    DataSet ds1 = db.GetTableData("select action_type, max(current_sub_no) issue from mas_sub_issues where sub_id=" + dr["sub_id"].ToString() + " group by action_type");
                    if(ds1.Tables[0].Rows.Count>0)
                    {
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            issue = Convert.ToInt32(dr1["issue"].ToString()) + 1;
                    }
                    double id = db.GetNewID("mas_sub_issues", "issue_id");
                    string[] res = db.ExecuteQueries("Insert into mas_sub_issues values (" + id + "," + dr["sub_id"].ToString() + "," + dr["pay_id"].ToString() + ",'01-" + DtpMnth.Value.ToString("MMM-yy") + "','" + DtpDspchDt.Value.ToString("dd-MMM-yy") + "'," + issue + "," + dr["Quantity"].ToString() + ",null,null,'" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
                    if(res[0].ToString()!="0")
                    {
                        MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    gensubs++;
                    TxtSub.Text = gensubs.ToString();
                    Application.DoEvents();
                }

                MessageBox.Show("Successfully Generated", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
