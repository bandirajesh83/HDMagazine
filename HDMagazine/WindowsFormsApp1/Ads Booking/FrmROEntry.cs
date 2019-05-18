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
    public partial class FrmROEntry : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        bool IsNewRo = true;
        public FrmROEntry()
        {
            InitializeComponent();
        }

        private string GetFnYr()
        {
            DateTime DtSysDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            int Dts = Convert.ToInt32(DtSysDate.Month.ToString() + DtSysDate.ToString("dd"));
            string DtMon = DtSysDate.ToString("MM");
            string FY = "";
            if (Dts >= 101 && Dts <= 331)
                FY = DtSysDate.AddYears(-1).ToString("yy") + "-" + DtSysDate.ToString("yy");
            else FY = DtSysDate.ToString("yy") + "-" + DtSysDate.AddYears(1).ToString("yy");
            return FY;
        }

        private string GetROCode()
        {
            string RONo = "";
            DataSet ds = db.GetTableData("select max(substr(ro_header_code,1,Instr(ro_header_code,'/',1,3))||to_char(sysdate,'MM')||'/'||lpad(substr(ro_header_code,instr(ro_header_code,'/',1,4)+1)+1,4,'0')) ro_code, decode(action_type,'U','I',action_type) action_type from hdr_ro where substr(ro_header_code, instr(ro_header_code,'/',1,3)+1,2) = to_char(sysdate,'MM') and substr(ro_header_code,8,2)||substr(ro_header_code,11,2)='" + GetFnYr().Replace("-", "") + "' group by decode(action_type,'U','I',action_type)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    RONo = dr["Ro_code"].ToString();
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
                RONo = "RO/HMZ/" + FY + "/" + DtMon + "/0001";
            }
            return RONo;
        }
        private void FrmROEntry_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            IsNewRo = true;
            DataSet ds;

            //ds = db.GetMasterData("Select agency_code, agency_name || '('|| agency_code ||')' Agency_name, action_type from mas_agency");
            //CmbAgency.DataSource = ds.Tables[0];
            //CmbAgency.DisplayMember = "Agency_name";
            //CmbAgency.ValueMember = "Agency_Code";

            //ds = db.GetMasterData("select client_code, client_name ||'('|| client_code ||')' client_name, action_type from mas_client");
            //CmbClient.DataSource = ds.Tables[0];
            //CmbClient.DisplayMember = "Client_Name";
            //CmbClient.ValueMember = "Client_code";

            ds = db.GetMasterData("Select region_code, region_name || '('|| region_code ||')' region_name, action_type from mas_region");
            CmbRegion.DataSource = ds.Tables[0];
            CmbRegion.DisplayMember = "REgion_name";
            CmbRegion.ValueMember = "Region_code";

            ds = db.GetTableData("select ad_category_code, ad_category_name ||'('|| ad_category_code ||')' ad_category_name, action_type from mas_ad_category");
            CmbADCategory.DataSource = ds.Tables[0];
            CmbADCategory.DisplayMember = "ad_category_name";
            CmbADCategory.ValueMember = "AD_category_Code";

            ds = db.GetMasterData("select emp_code, emp_name ||'('|| emp_code ||')' emp_name, action_type from mas_employee");
            CmbExecutive.DataSource = ds.Tables[0];
            CmbExecutive.DisplayMember = "emp_name";
            CmbExecutive.ValueMember = "emp_Code";

            ds = db.GetMasterData("Select spot_code,spot_details ||'('|| spot_code ||')' Spot_Details, action_type from mas_spot_category");
            CmbSpotCategory.DataSource = ds.Tables[0];
            CmbSpotCategory.DisplayMember = "spot_details";
            CmbSpotCategory.ValueMember = "spot_code";

            TxtROCode.Text = GetROCode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IsCombo = "N";
            if (TxtBrand.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Invalid Brand Name", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtCaption.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Invalid Caption Details", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtCaption.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Invalid AD Size", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(TxtNoofAds.Text) <= 0)
            {
                MessageBox.Show("Please Enter No. of Ads", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkBox1.Checked)
            {
                if(TxtActualRate.Text.Trim().Length<=0)
                {
                    MessageBox.Show("Please enter Actual Rate", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(Convert.ToDouble(TxtActualRate.Text)<=0)
                {
                    MessageBox.Show("Invalid Actual Rate", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IsCombo = "Y";
            }

            string[] res;

            if (IsNewRo)
            {
                TxtROCode.Text = GetROCode();
                res = db.ExecuteQueries("Insert into hdr_ro values ('" + TxtROCode.Text.Trim() + "','" + DtpRoDt.Value.ToString("dd-MMM-yy") + "'," + db.ExtractCode(CmbAgency.Text) + "," + db.ExtractCode(CmbClient.Text) + "," + db.ExtractCode(CmbExecutive.Text) + "," + db.ExtractCode(CmbRegion.Text) + "," + db.ExtractCode(CmbADCategory.Text) + ",null,'" + TxtClientRefNo.Text.Trim() + "','" + DtpRefDt.Value.ToString("dd-MMM-yy") + "','" + CmbBillingMode.Text.Trim() + "',null,'" + IsCombo + "',null,'" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
                if (res[0].ToString() != "0")
                {
                    MessageBox.Show("Insertion Failure in RO Header", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DateTime dtfrm = Convert.ToDateTime("01-" + DtpMnthFrm.Value.ToString("MMM-yy"));
            DateTime dtto = Convert.ToDateTime("01-" + DtpMnthTo.Value.ToString("MMM-yy"));
            DataSet ds = db.GetTableData("select max(sr_no) srno, decode(action_type,'U','I','D','I',action_type) Action_type from dtl_ro where ro_header_code='" + TxtROCode.Text.ToString() + "' group by decode(action_type,'U','I','D','I',action_type)");
            int i = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    i = Convert.ToInt32(dr["srno"].ToString());
            }

            for (DateTime dt = dtfrm; dt <= dtto; dt = dt.AddMonths(1))
            {
                for (int r = 1; r <= Convert.ToInt32(TxtNoofAds.Text); r++)
                {
                    i++;
                    res = db.ExecuteQueries("Insert into dtl_ro values (" + db.GetNewID("dtl_ro", "ro_detail_code") + "," + db.ExtractCode(CmbSpotCategory.Text) + ",'" + dt.ToString("dd-MMM-yy") + "'," + TxtNoofAds.Text.Trim() + "," + TxtReateCard.Text.Trim() + "," + TxtActualRate.Text.Trim() + ",'" + TxtBrand.Text.Trim() + "','" + TxtCaption.Text.Trim() + "','" + TxtSize.Text.Trim() + "','B','" + TxtROCode.Text.Trim() + "'," + i.ToString() + ",null,null,null,'" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
                    if (res[0].ToString() != "0")
                    {
                        MessageBox.Show("Insertioin Failure in RO Detail Code", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.ExecuteQueries("Delete from hdr_ro where ro_header_code='" + TxtROCode.Text + "'");
                        db.ExecuteQueries("Delete from dtl_ro where ro_header_code='" + TxtROCode.Text + "'");
                        TxtROCode.Text = GetROCode();
                        return;
                    }
                }
            }
            if (MessageBox.Show("Successfully Saved. Do you want to Continuee with same RO..?", "HD Magazine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                groupBox1.Enabled = false;
                IsNewRo = false;
                TxtReateCard.Text = "";
                TxtActualRate.Text = "";
                TxtBrand.Text = "";
                TxtCaption.Text = "";
                TxtSize.Text = "";
                TxtNoofAds.Text = "";
                DataSet ds1 = db.GetTableData("select * from dtl_ro where ro_header_code='" + TxtROCode.Text.Trim() + "' order by sr_no");
                dataGridView1.DataSource = ds1.Tables[0];
            }
            else
            {
                TxtROCode.Text = GetROCode();
                IsNewRo = true;
                groupBox1.Enabled = true;
                TxtReateCard.Text = "";
                TxtActualRate.Text = "";
                TxtBrand.Text = "";
                TxtCaption.Text = "";
                TxtSize.Text = "";
                TxtNoofAds.Text = "";
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
        }

        private void CmbSpotCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.ExtractCode(CmbSpotCategory.Text) == "2")
            {
                TxtReateCard.Text = "0";
                TxtReateCard.ReadOnly = true;
            }
            else
            {
                TxtReateCard.Text = "";
                TxtReateCard.ReadOnly = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = db.GetMasterData("select mab.reference_code Agency_code, ma.agency_name ||'('|| mab.reference_code||')' agency_name, mab.channel_code channel_code, mab.action_type action_type from mas_address_book mab, 	 mas_agency ma where MA.ACTIVE_FLAG='Y' AND mab.ADDRESS_TYPE='AG' and	  ma.agency_code = mab.reference_code and mab.region=" + db.ExtractCode(CmbRegion.Text) + " union (select agency_code, agency_name||'('|| agency_code||')' agency_name, channel_code, action_type from mas_agency where agency_code=0) order by agency_name");
            CmbAgency.DataSource = ds.Tables[0];
            CmbAgency.DisplayMember = "Agency_Name";
            CmbAgency.ValueMember = "Agency_Code";
        }

        private void CmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds;
            try
            {
                if (CmbAgency.Text.ToUpper().ToString() == "(None)".ToUpper())
                {
                    ds = db.GetMasterData("select mab.reference_code client_code, ma.client_name ||'('|| mab.reference_code||')' client_name, mab.channel_code channel_code, mab.action_type action_type from mas_address_book mab, 	 mas_client ma where MA.ACTIVE_FLAG='Y' AND mab.ADDRESS_TYPE='CL' and	  ma.client_code = mab.reference_code and mab.region=" + db.ExtractCode(CmbRegion.Text) + " order by client_name");
                    CmbClient.DataSource = ds.Tables[0];
                    CmbClient.DisplayMember = "client_name";
                    CmbClient.ValueMember = "client_code";
                }
                else
                {
                    ds = db.GetMasterData("select a.client_code client_code,b.client_name ||'('|| a.client_code ||')' client_name,a.channel_code channel_code,a.action_type action_type from dtl_client a, mas_client b where B.ACTIVE_FLAG='Y' AND b.client_code = a.client_code and	  a.agency_code= " + db.ExtractCode(CmbAgency.Text) + " order by b.client_name");
                    CmbClient.DataSource = ds.Tables[0];
                    CmbClient.DisplayMember = "client_name";
                    CmbClient.ValueMember = "client_code";
                }
            }
            catch { }
        }

        private void TxtReateCard_TextChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                TxtActualRate.Text = TxtReateCard.Text;
            else
                TxtActualRate.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                TxtActualRate.ReadOnly = false;
            else
                TxtActualRate.ReadOnly = true;
        }

        private void CmbADCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = db.GetTableData("select * from mas_ad_category where ad_category_code='" + db.ExtractCode(CmbADCategory.Text) + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToDouble(dr["Size_Width"].ToString()) > 0 && Convert.ToDouble(dr["Size_Height"].ToString()) > 0)
                    {
                        TxtSize.ReadOnly = true;
                        TxtSize.Text = dr["Size_Width"].ToString() + " W X " + dr["Size_Height"].ToString() + " H";
                    }
                    else
                    {
                        TxtSize.ReadOnly = false;
                        TxtSize.Text = "";
                    }
                }
            }
            else
            {
                TxtSize.ReadOnly = false;
                TxtSize.Text = "";
            }
        }
    }
}
