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
    public partial class FrmBillRegister : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmBillRegister()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBillRegister_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs.ShowRpt("Bill_Register.rpt", "{VEW_BILL_REGISTER.INVOICE_DATE} in DateTime (" + DtpFrm.Value.Year.ToString() + ", " + DtpFrm.Value.Month.ToString() + ", " + DtpFrm.Value.Day.ToString() + ", 00, 00, 00) to DateTime (" + DtpTo.Value.Year.ToString() + ", " + DtpTo.Value.Month.ToString() + ", " + DtpTo.Value.Day.ToString() + ", 00, 00, 00)", "Bill Register", "FrmDt~" + DtpFrm.Value.ToString("dd-MMM-yyyy") + "@ToDt~" + DtpTo.Value.ToString("dd-MMM-yyyy"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = db.GetTableData("select * from VEW_BILL_REGISTER where invoice_date between '" + DtpFrm.Value.ToString("dd-MMM-yy") + "' and '" + DtpTo.Value.ToString("dd-MMM-yy") + "'");
            dataGridView1.DataSource = ds.Tables[0];
            db.ExportToExcel(dataGridView1);
        }
    }
}
