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
    public partial class FrmFindSubscription : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmFindSubscription()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (TxtKeyword.Text.Trim().Length > 0)
                ds = db.GetTableData("select sub_id, voucher_no, sub_name, address, city_name, state_name, district_name, region_name, pin_code, email_id, contact_no, executive_name, sub_type_name, to_char(period_frm,'dd-MON-yy') period_Frm, to_char(period_to,'dd-MON-yy') period_to  from VEW_SUBSCRIPTIONS where voucher_no||sub_name||address||city_name||state_name||district_name||region_name||pin_code||email_id||contact_no||sub_Type_name||period_frm||period_to||executive_name like '%" + TxtKeyword.Text.Trim().ToUpper() + "%'");
            else
                ds = db.GetTableData("select sub_id, voucher_no, sub_name, address, city_name, state_name, district_name, region_name, pin_code, email_id, contact_no, executive_name, sub_type_name, to_char(period_frm,'dd-MON-yy') period_Frm, to_char(period_to,'dd-MON-yy') period_to  from VEW_SUBSCRIPTIONS");

            DgvList.DataSource = ds.Tables[0];
        }
    }
}
