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
    public partial class FrmBankLedger : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmBankLedger()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBankLedger_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double OBDr = 0.0, OBCr = 0.0;
            DataSet ds = db.GetTableData("select sum(credit_amount) cr, sum(debit_amount) dr, action_type from VEW_BANK_LEDGER where recon_date<'" + DtpFrm.Value.ToString("dd-MMM-yy") + "' group by action_type");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    double Cr = Convert.ToDouble(dr["Cr"].ToString());
                    double Dr = Convert.ToDouble(dr["Dr"].ToString());
                    if (Cr > Dr)
                    {
                        OBCr = Cr - Dr;
                        OBDr = 0;
                    }
                    if (Dr > Cr)
                    {
                        OBDr = Dr - Cr;
                        OBCr = 0;
                    }
                }
            }

            cs.ShowRpt("Bank_Ledger.rpt", "{VEW_BANK_LEDGER.RECON_DATE} in DateTime (" + DtpFrm.Value.Year + ", " + DtpFrm.Value.Month + ", " + DtpFrm.Value.Day + ", 00, 00, 00) to DateTime (" + DtpTo.Value.Year + ", " + DtpTo.Value.Month + ", " + DtpTo.Value.Day + ", 00, 00, 00)", "Party Ledger", "FrmDt~" + DtpFrm.Value.ToString("dd-MMM-yyyy") + "@ToDt~" + DtpTo.Value.ToString("dd-MMM-yyyy") + "@OBDr~" + OBDr + "@OBCr~" + OBCr);

        }
    }
}
