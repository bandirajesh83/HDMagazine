using HDMagazine.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using Excel = Microsoft.Office.Interop.Excel;

namespace HDMagazine.Masters
{
    public partial class FrmSubscription : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmSubscription()
        {
            InitializeComponent();
        }

        private string vouchernumber()
        {
            string res = "1";
            DataSet ds = db.GetTableData("Select max(voucher_no) vno, decode(spd.action_type,'U','I',spd.Action_type) Action_type from mas_sub_pay_details spd, mas_subscriptions ms where ms.sub_id (+)= spd.sub_id and state_id=" + db.ExtractCode(CmbState.Text) + " and district_id=" + db.ExtractCode(CmbDistrict.Text) + "  group by decode(spd.action_type,'U','I',spd.Action_type)");
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        int tt = Convert.ToInt32(dr["vno"].ToString());
                        tt++;
                        res = tt.ToString();
                    }
                    catch { }
                }
            }
            return res;
        }

        private void FrmSubscription_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            DataSet ds = db.GetTableData("select sub_type_id, sub_type_name || '(' || sub_type_id || ')' sub_type_name, Action_type from mas_sub_type order by sub_type_name");
            CmbSubType.DataSource = ds.Tables[0];
            CmbSubType.ValueMember = "sub_type_id";
            CmbSubType.DisplayMember = "sub_type_name";
            

            ds = db.GetTableData("select state_id, state_name || '(' || state_id || ')' State_Name, Action_type from mas_state order by state_name");
            CmbState.DataSource = ds.Tables[0];
            CmbState.ValueMember = "State_ID";
            CmbState.DisplayMember = "State_Name";

            ds = db.GetTableData("select region_id, region_name || '('||region_id||')' region_name, action_type from mas_region order by region_name");
            CmbRegion.DataSource = ds.Tables[0];
            CmbRegion.DisplayMember = "Region_name";
            CmbRegion.ValueMember = "Region_id";

            ds = db.GetTableData("Select executive_id, executive_name || '('||executive_id||')' executive_name, action_type from mas_executive order by executive_name");
            CmbExecutive.DataSource = ds.Tables[0];
            CmbExecutive.DisplayMember = "executive_name";
            CmbExecutive.ValueMember = "executive_id";

            ds = db.GetTableData("select Sponsor_id, Sponsor_name || ',' || sponsor_address ||'(' || sponsor_id || ')' sponsor_name, action_type from mas_sponsor order by sponsor_name");
            CmbSponsor.DataSource = ds.Tables[0];
            CmbSponsor.DisplayMember = "sponsor_name";
            CmbSponsor.ValueMember = "sponsor_id";

            TxtVNo.Text = vouchernumber();
            db.TxtAutoFill(TxtCity, "mas_subscriptions", "city_name");
            db.TxtAutoFill(TxtPIN, "mas_subscriptions", "PIN_CODE");
            db.TxtAutoFill(TxtOldVNo, "mas_sub_pay_details", "voucher_no");


            if (LblPK.Text.Length>0)
            {
                ds = db.GetTableData("select * from mas_sub_issues where pay_id=" + LblPK.Text.Trim() + " and invoice_code is not null");
                if(ds.Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("Invoice already generated for this subscriptions", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ds = db.GetTableData("select * from vew_mas_subscriptions ms where sub_id=" + LblPK.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        LblPK.Text = dr["sub_id"].ToString();
                        DataSet ds1 = db.GetTableData("select * from mas_state where state_id=" + dr["state_id"].ToString());
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            CmbState.Text = dr1["State_Name"].ToString() + "(" + dr1["State_ID"].ToString() + ")";

                        ds1 = db.GetTableData("select * from mas_district where district_id=" + dr["District_ID"].ToString());
                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            CmbDistrict.Text = dr2["District_Name"].ToString() + "(" + dr2["District_ID"].ToString() + ")";

                        ds1 = db.GetTableData("select * from MAS_SUB_TYPE where sub_type_id=" + dr["sub_type"].ToString());
                        foreach (DataRow dr3 in ds1.Tables[0].Rows)
                            CmbSubType.Text = dr3["sub_type_name"].ToString() + "(" + dr3["sub_type_id"].ToString() + ")";

                        ds1 = db.GetTableData("select * from mas_region where region_id=" + dr["Region_ID"].ToString());
                        foreach (DataRow dr4 in ds1.Tables[0].Rows)
                            CmbRegion.Text = dr4["region_name"].ToString() + "(" + dr4["Region_ID"].ToString() + ")";

                        ds1 = db.GetTableData("Select * from mas_executive where executive_id=" + dr["executive_id"].ToString());
                        foreach (DataRow dr5 in ds1.Tables[0].Rows)
                            CmbExecutive.Text = dr5["executive_name"].ToString() + "(" + dr5["executive_id"].ToString() + ")";

                        
                        DtpMnthFrm.Value = Convert.ToDateTime(dr["Period_frm"].ToString());
                        DtpMnthTo.Value = Convert.ToDateTime(dr["Period_to"].ToString());
                        TxtAdd.Text = dr["Address"].ToString();
                        TxtCity.Text = dr["City_Name"].ToString();
                        TxtEMail.Text = dr["Email_ID"].ToString();
                        TxtName.Text = dr["sub_name"].ToString();
                        TxtPhone.Text = dr["Contact_no"].ToString();
                        TxtPIN.Text = dr["PIN_Code"].ToString();
                        TxtRemarks.Text = dr["Remarks"].ToString();
                        TxtVNo.Text = dr["Voucher_No"].ToString();
                        TxtOldVNo.Text = dr["prev_voucher_no"].ToString();
                        CmbSponsor.Text = dr["sponsor_name"].ToString() + "," + dr["sponsor_address"].ToString() + "(" + dr["sponsor_id"].ToString() + ")";

                        ds1 = db.GetTableData("select * from mas_sub_issues where sub_id=" + dr["sub_id"].ToString());
                        if (ds1.Tables[0].Rows.Count > 0)
                            DtpMnthFrm.Enabled = false;
                        else
                            DtpMnthFrm.Enabled = true;
                    }
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (TxtVNo.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Voucher Number", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtVNo.Focus();
                return;
            }
            if (TxtName.Text.Trim().Length <= 2)
            {
                MessageBox.Show("Invalid Subcriber Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtName.Focus();
                return;
            }

            if (TxtAdd.Text.Trim().Length <= 5)
            {
                MessageBox.Show("Invalid Subscriber Address", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAdd.Focus();
                return;
            }

            if (TxtPIN.Text.Trim().Length > 0)
            {
                if (TxtPIN.Text.Trim().Length != 6)
                {
                    MessageBox.Show("Invalid PIN Code", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPIN.Focus();
                    return;
                }
            }

            if (Convert.ToInt32(db.ExtractCode(CmbExecutive.Text)) <= 0)
            {
                MessageBox.Show("Invalid Executive Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbExecutive.Focus();
                return;
            }
            
            if(Convert.ToInt16(TxtQty.Text)<=0)
            {
                MessageBox.Show("Invalid Quantity", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQty.Focus();
                return;
            }

            DataSet ds;
            ds = db.GetTableData("Select * from mas_sub_pay_details where voucher_no='" + TxtOldVNo.Text.Trim() + "' and '01-" + DtpMnthFrm.Value.ToString("MMM-yy") + "' between period_frm and period_to");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Invalid Previous Subscription Voucher Number", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (TxtPhone.Text.Trim().Length < 10)
            //{
            //    MessageBox.Show("Invalid Mobile Number", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    TxtAdd.Focus();
            //    return;
            //}

            int issues = 0;
            ds = db.GetTableData("Select * from MAS_SUB_TYPE where sub_type_id=" + db.ExtractCode(CmbSubType.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    issues = Convert.ToInt32(dr["issues"].ToString());
            }
            string[] res;
            if (LblPK.Text.Trim().Length > 0)
            {
                res = db.ExecuteQueries("Update mas_subscriptions set state_id=" + db.ExtractCode(CmbState.Text) + ", district_id=" + db.ExtractCode(CmbDistrict.Text) + ", region_id=" + db.ExtractCode(CmbRegion.Text) + ",  sub_name='" + TxtName.Text + "',address='" + TxtAdd.Text + "',city_name='" + TxtCity.Text + "',pin_code='" + TxtPIN.Text + "',email_id='" + TxtEMail.Text + "',contact_no='" + TxtPhone.Text + "',remarks='" + TxtRemarks.Text + "',modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where sub_id=" + LblPK.Text).Split(',');
                if (res[0].ToString() != "0")
                {
                    MessageBox.Show("Updation Failure..\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = db.ExecuteQueries("Update MAS_SUB_PAY_DETAILS set executive_id=" + db.ExtractCode(CmbExecutive.Text) + ", voucher_no='" + TxtVNo.Text.Trim() + "', prev_voucher_no='" + TxtOldVNo.Text.Trim() + "', period_frm='01-" + DtpMnthFrm.Value.ToString("MMM-yyyy") + "', period_to='01-" + DtpMnthTo.Value.ToString("MMM-yyyy") + "', sub_type=" + db.ExtractCode(CmbSubType.Text) + ", Amount=" + TxtAmt.Text + ", sponsor_id=" + db.ExtractCode(CmbSponsor.Text) + ", Quantity=" + TxtQty.Text + ", Modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where sub_id=" + LblPK.Text.Trim() + " and voucher_no='" + TxtVNo.Text.Trim() + "'").Split(',');
                if (res[0].ToString() != "0")
                {
                    MessageBox.Show("Updation Failure..\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                int sid = db.GetNewID("mas_subscriptions", "sub_id");
                res = db.ExecuteQueries("Insert into mas_subscriptions values (" + sid.ToString() + "," + db.ExtractCode(CmbState.Text) + "," + db.ExtractCode(CmbDistrict.Text) + "," + db.ExtractCode(CmbRegion.Text) + ",'" + TxtName.Text + "','" + TxtAdd.Text + "','" + TxtCity.Text + "','" + TxtPIN.Text + "','" + TxtEMail.Text + "','" + TxtPhone.Text + "','" + TxtRemarks.Text + "','" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
                if (res[0].ToString() != "0")
                {
                    MessageBox.Show("Insertion Failure..\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                res = db.ExecuteQueries("Insert into mas_sub_pay_details values (" + db.GetNewID("mas_sub_pay_details","pay_id") + "," + sid.ToString() + "," + db.ExtractCode(CmbExecutive.Text) + ", '" + TxtVNo.Text.Trim() + "','" + TxtOldVNo.Text.Trim() + "','01-" + DtpMnthFrm.Value.ToString("MMM-yyyy") + "','01-" + DtpMnthTo.Value.ToString("MMM-yyyy") + "'," + db.ExtractCode(CmbSubType.Text) + "," + TxtAmt.Text + "," + db.ExtractCode(CmbSponsor.Text) + "," + TxtQty.Text + ",null,'" + GlobalClass.UserName + "', sysdate, null, null, 'I')").Split(',');
                if (res[0].ToString() != "0")
                {
                    MessageBox.Show("Insertion Failure..\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.ExecuteQueries("Delete from mas_subscriptions where sub_id=" + sid.ToString());
                    return;
                }
            }

            MessageBox.Show("Successfully Saved", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtName.Text = "";
            TxtAdd.Text = "";
            TxtCity.Text = "";
            TxtEMail.Text = "";
            TxtPhone.Text = "";
            TxtPIN.Text = "";
            TxtRemarks.Text = "";
            TxtVNo.Text = vouchernumber();
            TxtVNo.Focus();
            TxtOldVNo.Text = "";
            LblPK.Text = "";
            DtpMnthFrm.Enabled = true;
            CmbSponsor.SelectedIndex = 0;
            DtpMnthFrm.MinDate = Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
            DtpMnthFrm.Value = Convert.ToDateTime( "01-" + DateTime.Now.ToString("MMM-yyyy"));
            TxtQty.Text = "1";
            db.TxtAutoFill(TxtCity, "mas_subscriptions", "city_name");
            db.TxtAutoFill(TxtPIN, "mas_subscriptions", "PIN_CODE");
            db.TxtAutoFill(TxtOldVNo, "mas_sub_pay_details", "voucher_no");

        }

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = db.GetTableData("select District_id, District_name || '(' || District_id || ')' District_Name, Action_type from mas_District where state_id=" + db.ExtractCode(CmbState.Text) + " order by District_Name");
            CmbDistrict.DataSource = ds.Tables[0];
            CmbDistrict.ValueMember = "District_ID";
            CmbDistrict.DisplayMember = "District_Name";
        }

        private void TxtVNo_Leave(object sender, EventArgs e)
        {
            int subid = 0;
            DataSet ds, ds1;
            ds = db.GetTableData("select * from mas_sub_pay_details where voucher_no='" + TxtVNo.Text.Trim() + "'");
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                { 
                    subid = Convert.ToInt32(dr["sub_id"].ToString());

                    ds1 = db.GetTableData("select * from MAS_SUB_TYPE where sub_type_id=" + dr["sub_type"].ToString());
                    foreach (DataRow dr3 in ds1.Tables[0].Rows)
                        CmbSubType.Text = dr3["sub_type_name"].ToString() + "(" + dr3["sub_type_id"].ToString() + ")";

                    ds1 = db.GetTableData("select * from mas_executive where executive_id=" + dr["executive_id"].ToString());
                    foreach (DataRow dr5 in ds1.Tables[0].Rows)
                        CmbExecutive.Text = dr5["executive_name"].ToString() + "(" + dr5["executive_id"].ToString() + ")";

                    DtpMnthFrm.MinDate = Convert.ToDateTime(dr["Period_frm"].ToString());
                    DtpMnthFrm.Value = Convert.ToDateTime(dr["Period_frm"].ToString());
                    DtpMnthTo.Value = Convert.ToDateTime(dr["Period_to"].ToString());

                    TxtVNo.Text = dr["Voucher_No"].ToString();
                    TxtQty.Text = dr["Quantity"].ToString();
                    TxtOldVNo.Text = dr["prev_voucher_no"].ToString();

                    ds1 = db.GetTableData("select * from mas_sponsor where sponsor_id=" + dr["sponsor_id"].ToString());
                    foreach (DataRow dr6 in ds1.Tables[0].Rows)
                        CmbSponsor.Text = dr6["sponsor_name"].ToString() + "," + dr6["sponsor_address"].ToString() + "(" + dr6["sponsor_id"].ToString() + ")";

                    ds1 = db.GetTableData("select * from mas_sub_issues where sub_id=" + dr["sub_id"].ToString());
                    if (ds1.Tables[0].Rows.Count > 0)
                        DtpMnthFrm.Enabled = false;
                    else
                        DtpMnthFrm.Enabled = true;

                    SubPeriod();
                }
            }

            ds = db.GetTableData("select * from mas_subscriptions where sub_id=" + subid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    LblPK.Text = dr["sub_id"].ToString();
                    ds1 = db.GetTableData("select * from mas_state where state_id=" + dr["state_id"].ToString());
                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        CmbState.Text = dr1["State_Name"].ToString() + "(" + dr1["State_ID"].ToString() + ")";

                    ds1 = db.GetTableData("select * from mas_district where district_id=" + dr["District_ID"].ToString());
                    foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        CmbDistrict.Text = dr2["District_Name"].ToString() + "(" + dr2["District_ID"].ToString() + ")";

                    ds1 = db.GetTableData("select * from mas_region where region_id=" + dr["Region_ID"].ToString());
                    foreach (DataRow dr4 in ds1.Tables[0].Rows)
                        CmbRegion.Text = dr4["region_name"].ToString() + "(" + dr4["Region_id"].ToString() + ")";

                    
                    TxtAdd.Text = dr["Address"].ToString();
                    TxtCity.Text = dr["City_Name"].ToString();
                    TxtEMail.Text = dr["Email_ID"].ToString();
                    TxtName.Text = dr["sub_name"].ToString();
                    TxtPhone.Text = dr["Contact_no"].ToString();
                    TxtPIN.Text = dr["PIN_Code"].ToString();
                    TxtRemarks.Text = dr["Remarks"].ToString();
                }
            }
            else
            {
                TxtName.Text = "";
                TxtAdd.Text = "";
                TxtCity.Text = "";
                TxtEMail.Text = "";
                TxtPhone.Text = "";
                TxtPIN.Text = "";
                TxtRemarks.Text = "";
                LblPK.Text = "";
                CmbSubType.Enabled = true;
                DtpMnthFrm.MinDate =Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
                DtpMnthFrm.Value = Convert.ToDateTime("01-" +  DateTime.Now.ToString("MMM-yyyy"));
                TxtOldVNo.Text = "";
                DtpMnthFrm.Enabled = true;
                db.TxtAutoFill(TxtCity, "mas_subscriptions", "city_name");
                db.TxtAutoFill(TxtPIN, "mas_subscriptions", "PIN_CODE");
                db.TxtAutoFill(TxtOldVNo, "mas_sub_pay_details", "voucher_no");
            }
        }

        private void TxtAdd_Leave(object sender, EventArgs e)
        {
            //string[] vlg = TxtAdd.Text.Split(',');
            //string exp = "";
            //for(int i=0; i<vlg.Length;i++)
            //{
            //    exp = exp + "*" + vlg[i] + "*|";
            //}
            //exp = exp.TrimEnd('|');
            //DataSet ds = db.GetTableData("Select * from mas_subscriptions where regexp_like(address,'" + exp + "') order by sub_id desc");
            //if(ds.Tables[0].Rows.Count>0)
            //{
            //    foreach(DataRow dr in ds.Tables[0].Rows)
            //    {
            //        TxtPIN.Text = dr["PIN_CODE"].ToString();
            //        break;
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrmView vw = new FrmView("mas_subscriptions", "sub_id,voucher_no,sub_name,address,city_name,pin_code,email_id,contact_no", "Subscription Details", "sub_id,voucher_no,sub_name,address,city_name,pin_code,email_id,contact_no");
            //vw.MdiParent = FrmMDI.ActiveForm;
            //vw.Show();
            //this.Close();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Excel.Application xlApp = new Excel.Application();
        //    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\Book2.xlsx");
        //    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        //    Excel.Range xlRange = xlWorksheet.UsedRange;

        //    int rowCount = xlRange.Rows.Count;
        //    int colCount = xlRange.Columns.Count;

        //    int cnt = 0;
            
        //    for (int i = 1; i <= rowCount; i++)
        //    {
        //        string rcpt = "", subtype = "", subname = "", mobile = "";
        //        if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
        //            rcpt = xlRange.Cells[i, 1].Value2.ToString();
        //        if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null)
        //            subtype = xlRange.Cells[i, 2].Value2.ToString();
        //        if (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null)
        //            subname = xlRange.Cells[i, 4].Value2.ToString();
        //        if (xlRange.Cells[i, 5] != null && xlRange.Cells[i, 5].Value2 != null)
        //            mobile = xlRange.Cells[i, 5].Value2.ToString();

        //        i++;
        //        string address = "";
        //        string Pin = "";
        //        string email = "";
        //        while(xlRange.Cells[i,1]==null || xlRange.Cells[i,1].Value2 ==null)
        //        {
        //            if (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null)
        //            {
        //                string cv = xlRange.Cells[i, 4].Value2.ToString();
        //                if (cv.ToUpper().IndexOf("PIN") >= 0)
        //                {
        //                    string[] tt = cv.Split(':');
        //                    Pin = tt[tt.Length - 1].ToString();
        //                }
        //                else if (cv.ToUpper().IndexOf("PH") >= 0)
        //                {
        //                }
        //                else if (cv.ToUpper().IndexOf("MAIL") >= 0)
        //                {
        //                    string[] kk = cv.Split(':');
        //                    email = kk[kk.Length - 1].ToString();
        //                }
        //                else
        //                {
        //                    address = address + xlRange.Cells[i, 4].Value2.ToString();
        //                }
        //            }
        //            i++;
        //        }
                
        //        //MessageBox.Show(address);
        //        //MessageBox.Show(Pin);
        //        int cat_type = 0;
        //        if (subtype == "1")
        //            cat_type = 1;
        //        else if (subtype == "3")
        //            cat_type = 2;
        //        else if (subtype == "5")
        //            cat_type = 3;
        //        int issues = 0;
        //        DataSet ds = db.GetTableData("Select * from MAS_SUB_TYPE where sub_type_id=" + db.ExtractCode(CmbSubType.Text));
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //                issues = Convert.ToInt32(dr["issues"].ToString());
        //        }
        //        string sql = "Insert into mas_subscriptions values (" + db.GetNewID("mas_subscriptions", "sub_id") + ",1,6,'" + rcpt.Trim() + "'," + cat_type.ToString() + ",'01-" + DateTime.Now.AddMonths(1).ToString("MMM-yy") + "','01-" + DateTime.Now.AddMonths(issues).ToString("MMM-yy") + "','" + subname.Trim() + "','" + address.Trim() + "','VIJAYAWADA','" + Pin.Trim() + "','" + email.Trim() + "','" + mobile.Trim() + "',null,'ADMIN',sysdate, null, null, 'I')";
        //        db.ExecuteQueries(sql.ToUpper());
        //        cnt++;
        //        label12.Text = cnt.ToString();
        //        Application.DoEvents();
        //        i--;

        //        //write the value to the console
        //        //if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
        //        //    MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
        //    }
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();

        //    Marshal.ReleaseComObject(xlRange);
        //    Marshal.ReleaseComObject(xlWorksheet);

        //    xlWorkbook.Close();
        //    Marshal.ReleaseComObject(xlWorkbook);

        //    xlApp.Quit();
        //    Marshal.ReleaseComObject(xlApp);

        //    MessageBox.Show("ok");

        //}
        private void SubPeriod()
        {
            DataSet ds = db.GetTableData("Select * from mas_sub_pay_details where voucher_no='" + TxtVNo.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    
                    DtpMnthFrm.Value = Convert.ToDateTime(dr["Period_frm"].ToString());
                    DtpMnthTo.Value = Convert.ToDateTime(dr["Period_To"].ToString());
                    DataSet ds1 = db.GetTableData("Select * from mas_sub_issues where sub_id=" + dr["sub_id"].ToString());
                    if(ds1.Tables[0].Rows.Count>0)
                    {
                        CmbSubType.Enabled = false;
                        DtpMnthFrm.Enabled = false;
                    }
                    else
                    {
                        DataSet ds2 = db.GetTableData("select decode(action_type,'U','I',action_type) Action_type, max(issue_month) mnth from mas_sub_issues WHERE SUB_ID=" +  dr["sub_id"].ToString() + " group by decode(action_type,'U','I',action_type)");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in ds2.Tables[0].Rows)
                            {
                                DtpMnthFrm.MinDate = Convert.ToDateTime(dr1["mnth"].ToString());
                                DtpMnthFrm.Enabled = false;
                            }
                        }
                        else
                        {
                            CmbSubType.Enabled = true;
                            DtpMnthFrm.Enabled = true;
                            DtpMnthFrm.Value = Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
                        }
                    }
                }
            }
            else
            {
                CmbSubType.Enabled = true;
                DtpMnthFrm.Value =Convert.ToDateTime("01-" + DateTime.Now.ToString("MMM-yyyy"));
                DtpMnthFrm.Enabled = true;
                int issues = 0;
                ds = db.GetTableData("Select * from MAS_SUB_TYPE where sub_type_id=" + db.ExtractCode(CmbSubType.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        issues = Convert.ToInt32(dr["issues"].ToString());
                    }
                }
                DtpMnthTo.Value = DtpMnthFrm.Value.AddMonths(issues-1);

                ds = db.GetTableData("select * from mas_magazine_price where sub_type=" + db.ExtractCode(CmbSubType.Text) + " and '01-" + DtpMnthFrm.Value.ToString("MMM-yyyy") + "' BETWEEN WITH_EFFECTIVE_DATE AND NVL(END_DATE,'01-" + DtpMnthTo.Value.ToString("MMM-yyyy") + "')");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        TxtAmt.Text = dr["Amount"].ToString();
                }
            }
        }

        private void SetEndPeriod()
        {
            int issues = 0;
            DataSet ds = db.GetTableData("Select * from MAS_SUB_TYPE where sub_type_id=" + db.ExtractCode(CmbSubType.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    issues = Convert.ToInt32(dr["issues"].ToString());
                }
            }
            if (issues > 0)
            {
                DtpMnthTo.Value = DtpMnthFrm.Value.AddMonths(issues - 1);
                DtpMnthTo.Enabled = false;
            }
            else
            {
                DtpMnthTo.Value = DtpMnthFrm.Value;
                DtpMnthTo.Enabled = true;
            }
            ds = db.GetTableData("select * from mas_magazine_price where sub_type=" + db.ExtractCode(CmbSubType.Text) + " and '01-" + DtpMnthFrm.Value.ToString("MMM-yyyy") + "' BETWEEN WITH_EFFECTIVE_DATE AND NVL(END_DATE,'01-" + DtpMnthTo.Value.ToString("MMM-yyyy") + "')");
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    TxtAmt.Text = Convert.ToString(Convert.ToDouble(dr["Amount"].ToString())*Convert.ToInt16(TxtQty.Text));
            }
        }

        private void CmbSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEndPeriod();
        }

        private void DtpMnthFrm_ValueChanged(object sender, EventArgs e)
        {
            SetEndPeriod();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("vew_mas_subscriptions", "sub_id,voucher_no,sub_name,address,city_name,pin_code,email_id,contact_no,prev_voucher_no,state_name,district_name,region_name,executive_name", "Subscription Details", "sub_id,voucher_no,sub_name,address,city_name,pin_code,email_id,contact_no,prev_voucher_no,state_name,district_name,region_name,executive_name");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void CmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            TxtAmt.Text = Convert.ToString(Convert.ToDouble(TxtAmt.Text) * Convert.ToInt16(TxtQty.Text));
        }
    }
}
