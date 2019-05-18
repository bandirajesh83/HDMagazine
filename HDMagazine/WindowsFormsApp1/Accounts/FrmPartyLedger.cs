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
    public partial class FrmPartyLedger : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmPartyLedger()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPartyLedger_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            DataSet ds = db.GetTableData("select party_type_id, party_type_name || '(' || party_type_id || ')' party_type_name, action_type from MAS_PARTY_TYPE");
            CmbPType.DataSource = ds.Tables[0];
            CmbPType.DisplayMember = "party_type_name";
            CmbPType.ValueMember = "party_type_id";

        }

        private void CmbPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = null;
            if (Convert.ToInt32(db.ExtractCode(CmbPType.Text)) == 1)
                ds = db.GetTableData("select executive_id Party_id, executive_name || '('|| executive_id ||')' Party_name, action_type from mas_executive");
            else if(Convert.ToInt32(db.ExtractCode(CmbPType.Text)) == 2)
                ds = db.GetTableData("select distributor_code Party_id, distributor_name || '(' || distributor_code ||')' party_name, action_type from mas_distributor");

            if (ds !=null)
            {
                CmbParty.DataSource = ds.Tables[0];
                CmbParty.DisplayMember = "party_name";
                CmbParty.ValueMember = "party_id";
            }
            else
            {
                CmbParty.DataSource = null;
                CmbParty.Items.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double OBDr = 0.0, OBCr = 0.0;
            DataSet ds = db.GetTableData("select sum(credit_amount) cr, sum(debit_amount) dr, action_type from VEW_PARTY_LEDGER where party_type=" + db.ExtractCode(CmbPType.Text) + " and party_code=" +  db.ExtractCode(CmbParty.Text) + " and recon_date<'" + DtpFrm.Value.ToString("dd-MMM-yy") + "' group by action_type");
            if(ds.Tables[0].Rows.Count>0)
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

            cs.ShowRpt("Party_Ledger.rpt", "{VEW_PARTY_LEDGER.RECON_DATE} in DateTime (" + DtpFrm.Value.Year + ", " + DtpFrm.Value.Month + ", " + DtpFrm.Value.Day + ", 00, 00, 00) to DateTime (" + DtpTo.Value.Year + ", " + DtpTo.Value.Month + ", " + DtpTo.Value.Day + ", 00, 00, 00) and {VEW_PARTY_LEDGER.PARTY_TYPE} = " + db.ExtractCode(CmbPType.Text) + " and { VEW_PARTY_LEDGER.PARTY_CODE} = " + db.ExtractCode(CmbParty.Text), "Party Ledger", "FrmDt~" + DtpFrm.Value.ToString("dd-MMM-yyyy") + "@ToDt~" + DtpTo.Value.ToString("dd-MMM-yyyy") + "@OBDr~" + OBDr + "@OBCr~" + OBCr);

        }
    }
}
