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
    public partial class FrmSubIssueAbt : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmSubIssueAbt()
        {
            InitializeComponent();
        }

        private void FrmSubIssueAbt_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnd = "{VEW_MNTHLY_SUB_ABT.ISSUE_MONTH} in DateTime (" + DtpMnthFrm.Value.Year + "," + DtpMnthFrm.Value.Month + ",01, 00, 00, 00) to DateTime (" + DtpMnthTo.Value.Year + ", " + DtpMnthTo.Value.Month + ",01, 00, 00, 00)";
            cs.ShowRpt("Month_Sub_Abt.rpt", cnd, "Subscriptions Abstract", null);
        }
    }
}
