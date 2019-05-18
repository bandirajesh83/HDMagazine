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
    public partial class FrmReceipt : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();

        public FrmReceipt()
        {
            InitializeComponent();
        }

        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            DataSet ds;
            ds = db.GetTableData("Select pay_mode_id, pay_mode || '(' || pay_mode_id || ')' pay_mode, action_type from MAS_PAY_MODE");
            CmbPayMode.DataSource = ds.Tables[0];
            CmbPayMode.DisplayMember = "pay_mode";
            CmbPayMode.ValueMember = "pay_mode_id";

            ds = db.GetTableData("select region_id, region_name || '(' || region_id || ')' region_name, action_type from mas_region");
            CmbRegion.DataSource = ds.Tables[0];
            CmbRegion.DisplayMember = "region_Name";
            CmbRegion.ValueMember = "region_id";

            ds = db.GetTableData("select pay_mode_id, pay_mode || '('|| pay_mode_id || ')' Pay_mode, action_type from mas_pay_mode");
            CmbPayMode.DataSource = ds.Tables[0];
            CmbPayMode.DisplayMember = "pay_mode";
            CmbPayMode.ValueMember = "pay_mode_id";

            ds = db.GetTableData("Select bank_id, bank_name || '(' || bank_id ||')' Bank_name, action_type from mas_bank");
            CmbBank.DataSource = ds.Tables[0];
            CmbBank.DisplayMember = "Bank_Name";
            CmbBank.ValueMember = "bank_id";

            ds = db.GetTableData("select party_type_id, party_type_name || '(' || party_type_id || ')' party_type_name, action_type from MAS_PARTY_TYPE");
            CmbPartyType.DataSource = ds.Tables[0];
            CmbPartyType.DisplayMember = "party_type_name";
            CmbPartyType.ValueMember = "party_type_id";


            TxtRcptCode.Text = db.GetAccCode("RC", "mas_acc_receipt", "Receipt_code", DtpRcptDt.Value);

        }

        private void CmbPartyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds=null;
            if(db.ExtractCode(CmbPartyType.Text)=="1")
                ds = db.GetTableData("select executive_id Party_Code, executive_name || '(' || executive_id || ')' Party_name, action_type from mas_executive");
            else if (db.ExtractCode(CmbPartyType.Text) == "2")
                ds = db.GetTableData("select distributor_code Party_Code, distributor_name || '(' || distributor_code || ')' Party_name, action_type from mas_distributor where region_id=" + db.ExtractCode(CmbRegion.Text));

            if (ds != null)
            {
                CmbParty.DataSource = ds.Tables[0];
                CmbParty.DisplayMember = "Party_name";
                CmbParty.ValueMember = "Party_Code";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CmbRegion.Items.Count<=0 || Convert.ToInt32(db.ExtractCode(CmbRegion.Text)) <= 0)
            {
                MessageBox.Show("Invalid Region Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbRegion.Focus();
                return;
            }

            if(CmbParty.Items.Count<=0 || Convert.ToInt32(db.ExtractCode(CmbParty.Text)) <= 0)
            {
                MessageBox.Show("Invalid Party Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbParty.Focus();
                return;
            }

            if(CmbPayMode.Items.Count<=0 || Convert.ToInt32(db.ExtractCode(CmbPayMode.Text))<=0)
            {
                MessageBox.Show("Invalid Payment Mode", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbPayMode.Focus();
                return;
            }

            if (CmbBank.Items.Count <= 0 || Convert.ToInt32(db.ExtractCode(CmbBank.Text)) <= 0)
            {
                MessageBox.Show("Invalid Bank Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbBank.Focus();
                return;
            }

            if(TxtAmount.Text.Length<=0)
            {
                MessageBox.Show("Invalid Receipt Amount", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAmount.Focus();
                return;
            }

            if(Convert.ToDouble(TxtAmount.Text)<=0)
            {
                MessageBox.Show("Invalid Receipt Amount", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAmount.Focus();
                return;
            }

            string rcptno = db.GetAccCode("RC", "mas_acc_receipt", "Receipt_code", DtpRcptDt.Value);

            string[] res = db.ExecuteQueries("Insert into mas_acc_receipt values ('" + rcptno + "','" + DtpRcptDt.Value.ToString("dd-MMM-yyyy") + "','" + db.GetFinYr(DtpRcptDt.Value) + "'," + db.ExtractCode(CmbPartyType.Text) + "," + db.ExtractCode(CmbRegion.Text) + "," + db.ExtractCode(CmbParty.Text) + "," + TxtAmount.Text.Trim() + "," + db.ExtractCode(CmbPayMode.Text) + ",'" + TxtRefNo.Text.Trim() + "','" + DtpRefDt.Value.ToString("dd-MMM-yyyy") + "'," + db.ExtractCode(CmbBank.Text) + ",'" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Insertion Failure..\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            res = db.ExecuteQueries("Insert into mas_acc_reconcillation values (" + db.GetNewID("mas_acc_reconcillation", "recon_code") + ",'" + DtpRcptDt.Value.ToString("dd-MMM-yyyy") + "','" + db.GetFinYr(DtpRcptDt.Value) + "'," + db.ExtractCode(CmbPartyType.Text) + "," + db.ExtractCode(CmbParty.Text) + "," + db.ExtractCode(CmbRegion.Text) + ",'" + rcptno + "','" + DtpRcptDt.Value.ToString("dd-MMM-yyyy") + "','R'," + TxtAmount.Text.Trim() + ",null,null,'" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Insertion Failure..\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.ExecuteQueries("Delete from mas_acc_receipt where receipt_code='" + rcptno + "'");
                return;
            }

            MessageBox.Show("Successfully Saved with Receipt No. " + rcptno, "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtAmount.Text = "";
            TxtRcptCode.Text = db.GetAccCode("RC", "mas_acc_receipt", "Receipt_code", DtpRcptDt.Value);
            TxtRefNo.Text = "";
            TxtRemarks.Text = "";
        }

        private void DtpRcptDt_ValueChanged(object sender, EventArgs e)
        {
            TxtRcptCode.Text = db.GetAccCode("RC", "mas_acc_receipt", "Receipt_code", DtpRcptDt.Value);
        }
    }
}
