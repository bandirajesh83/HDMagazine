using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FrmInvoiceGeneration : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmInvoiceGeneration()
        {
            InitializeComponent();
        }

        private void FrmInvoiceGeneration_Load(object sender, EventArgs e)
        {
           

            cs.FrmStyle(this);
            DataSet ds = db.GetTableData("select max(invoice_date) Invoice_Date, action_type from mas_acc_invoice group by action_type");
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    DtpInvDt.MinDate = Convert.ToDateTime(dr["Invoice_Date"].ToString());
            }
            ds = db.GetTableData("Select max(invoice_code) Invoice_Code, action_type from mas_acc_invoice group by action_type");
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
                TxtLastInvoiceNo.Text = "IN/HMZ/" + FY + "/00001";
            }

            ds = db.GetTableData("Select min(tx_month) frmmnth, max(tx_month) tomnth, decode(MC.action_type,'U','I',MC.action_type) Action_type from mas_capsulling MC, DTL_RO DR where DR.RO_HEADER_CODE (+)= MC.RO_HEADER_CODE AND DR.RO_DETAIL_CODE (+)= MC.RO_DETAIL_CODE AND SPOT_CATEGORY_CODE=1 AND invoice_code is null group by decode(MC.action_type,'U','I',MC.action_type)");
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    DtpMnthFrm.Value = Convert.ToDateTime(dr["frmmnth"].ToString());
                    DtpMnthTo.Value = Convert.ToDateTime(dr["tomnth"].ToString());
                    DtpMnthTo.MaxDate = Convert.ToDateTime(dr["tomnth"].ToString());
                }
            }
            else
            {
                DtpMnthFrm.Value = Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
                DtpMnthTo.Value = Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
                DtpMnthTo.MaxDate = Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
            }
        }

        private void LoadInvoices()
        {
            DataSet ds = db.GetTableData("select ro_header_code, region_name, agency_name, client_name, sum(gross) gross, sum(discount) discount, sum(netamt) netamt, sum(sgst_tax) sgst, sum(cgst_tax) cgst, sum(igst_tax) igst, sum(amount) amount, region_code, agency_code, client_code,action_type   From vew_acc_invoice_show where publish_month between '01-" + DtpMnthFrm.Value.ToString("MMM-yy") + "' and '01-" + DtpMnthTo.Value.ToString("MMM-yy") + "' group by ro_header_code, region_name,agency_name, client_name,region_code, agency_code, client_code, action_type order by ro_header_code");
            LVInvoices.Columns.Clear();
            LVInvoices.Items.Clear();
            LVInvoices.View = View.Details;

            for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
            {
                LVInvoices.Columns.Add(ds.Tables[0].Columns[c].ColumnName.ToString());
                if (c >= 4 && c <= 10)
                    LVInvoices.Columns[c].TextAlign = HorizontalAlignment.Right;
            }

            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem(drow["ro_header_code"].ToString());
                for (int j = 1; j < ds.Tables[0].Columns.Count; j++)
                    lvi.SubItems.Add(drow[j].ToString());
                LVInvoices.Items.Add(lvi);
            }

            for (int k = 0; k < LVInvoices.Columns.Count; k++)
                LVInvoices.Columns[k].Width = -2;

            for (int l = 11; l < LVInvoices.Columns.Count; l++)
                LVInvoices.Columns[l].Width = 0;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Btn_Go_Click(object sender, EventArgs e)
        {
            LoadInvoices();
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

        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            if(LVInvoices.CheckedItems.Count<=0)
            {
                MessageBox.Show("No RO(s) selected for generating Invoices", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("Are you sure, Do you want  to Generate Invoice(s)..?", "HD Magazine", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                for(int i = 0; i<LVInvoices.Items.Count;i++)
                {
                    if(LVInvoices.Items[i].Checked== true)
                    {
                        string invcode = db.GetAccCode("IN", "Mas_acc_invoice", "Invoice_Code", DtpInvDt.Value);

                        string[] res = db.ExecuteQueries("Insert into mas_acc_invoice values ('" + invcode + "','" + DtpInvDt.Value.ToString("dd-MMM-yy") + "','" + db.GetFinYr(DtpInvDt.Value) + "'," + LVInvoices.Items[i].SubItems[12].Text.ToString() + "," + LVInvoices.Items[i].SubItems[13].Text.ToString() + "," + LVInvoices.Items[i].SubItems[11].Text.ToString() + ",'01-" + DtpMnthFrm.Value.ToString("MMM-yy") + "','01-" + DtpMnthTo.Value.ToString("MMM-yy") + "','" + LVInvoices.Items[i].Text.ToString() + "'," + LVInvoices.Items[i].SubItems[4].Text.ToString() + "," + LVInvoices.Items[i].SubItems[5].Text.ToString() + ",null," + LVInvoices.Items[i].SubItems[6].Text.ToString() + ",null," + LVInvoices.Items[i].SubItems[7].Text.ToString() + ",null," + LVInvoices.Items[i].SubItems[8].Text.ToString() + ",null," + LVInvoices.Items[i].SubItems[9].Text.ToString() + "," + LVInvoices.Items[i].SubItems[10].Text.ToString() + ",'" + DtpInvDt.Value.ToString("dd-MMM-yy") + "', null,null,null,null,'" + GlobalClass.UserName + "',sysdate,null,null,'I')").Split(',');
                        if(res[0].ToString()!="0")
                        {
                            MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        res = db.ExecuteQueries("Update mas_capsulling set invoice_code='" + invcode + "' where invoice_code is null and ro_header_code='" + LVInvoices.Items[i].Text.ToString() + "' and tx_month between '01-" + DtpMnthFrm.Value.ToString("MMM-yy") + "' and '01-" + DtpMnthTo.Value.ToString("MMM-yy") + "'").Split(',');
                        if (res[0].ToString() != "0")
                        {
                            MessageBox.Show("Updation Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                db.ExecuteQueries("update mas_acc_invoice mai set billing_frm=(select min(tx_month) from mas_capsulling where invoice_code=mai.invoice_code), billing_to=(select max(tx_month) from mas_capsulling where invoice_code=mai.invoice_code) where invoice_date = '" + DtpInvDt.Value.ToString("dd-MMM-yyyy") + "'");

                db.ExecuteQueries("insert into c##tekdev.mas_acc_reconcillation (SELECT(SELECT MAX(RECON_CODE) FROM C##TEKDEV.MAS_ACC_RECONCILLATION)+ROWNUM RECON_CODE, INVOICE_DATE RECON_DATE, FNYR, 0 GROUP_CODE, mai.AGENCY_CODE,mai.CLIENT_CODE,  hr.REGION_CODE, invoice_code REFERENCE_CODE, invoice_date REFERENCE_DATE, 'D' TRANS_TYPE, 'I' TRANS_SUB_TYPE, null BANK_NAME, null CHEQUE_NO, null CHQ_TRX_DATE, null CREDIT_AMOUNT, amount DEBIT_AMOUNT, mai.REMARKS, 6 CHANNEL_CODE, mai.CREATED_BY, mai.CREATED_DATE, mai.modified_by, mai.modified_date, mai.ACTION_TYPE FROM MAS_ACC_INVOICE Mai, hdr_ro hr where hr.ro_header_code(+) = mai.ro_header_code and invoice_code > (SELECT MAX(INVOICE_CODE) FROM C##TEKDEV.MAS_ACC_INVOICE WHERE CHANNEL_CODE=6))");

                db.ExecuteQueries("INSERT INTO C##TEKDEV.MAS_ACC_INVOICE (select Invoice_code, invoice_date, fnyr, 0 group_code, agency_code, client_code, billing_frm, billing_to, null tx_code, null tx_date, ro_header_code, null ro_detail_code, null actual_telecast_time, gross_amount, null service_tax, null swatch_cess_tax, null kk_cess_tax, null ec_tax, null hec_tax, sgst_tax_amt sgst_tax, cgst_tax_amt cgst_tax, igst_tax_amt igst_tax, discount, misc_amount, amount, receipt_amt receipt_amount, due_date, cn_amount, dn_amount, null duration, null sector4, null invoice_status, null last_posted_date, remarks, 6 channel_code, created_by, created_date, modified_by, modified_date, action_type from mas_acc_invoice where invoice_code > (SELECT MAX(INVOICE_CODE) FROM C##TEKDEV.MAS_ACC_INVOICE WHERE CHANNEL_CODE=6))");

                db.ExecuteQueries("INSERT INTO C##TEKDEV.HDR_RO (SELECT RO_HEADER_CODE, RO_DATE, 0 GROUP_CODE, AGENCY_CODE, CLIENT_CODE, SALES_PERSON_CODE, REGION_CODE, 0 CITY_CODE, NULL DEAL_CODE, NULL PROPOSAL_CODE, NULL TYPE_OF_RO, AD_CATEGORY_CODE, NULL RATE_CARD_CATEGORY, NULL GOVT_GEN_FLAG, CLIENT_REFERENCE_CODE, CLIENT_REFERENCE_DATE, BILLING_MODE, 'N' AUDIT_STATUS, 0 EVENT_ID, IS_INCLUDE_TAX, IS_COMBO, REMARKS, 6 CHANNEL_CODE, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE, ACTION_TYPE  FROM HDR_RO WHERE RO_HEADER_CODE NOT IN(SELECT RO_HEADER_CODE FROM C##TEKDEV.HDR_RO WHERE CHANNEL_CODE=6))");

                MessageBox.Show("Successfully Generated", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoices();
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cs.ExportToExcel(dataGridView1);
        }
    }
}
