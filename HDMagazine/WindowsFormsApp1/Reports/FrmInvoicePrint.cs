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
    public partial class FrmInvoicePrint : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmInvoicePrint()
        {
            InitializeComponent();
        }

        private void FrmInvoicePrint_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnd = "{VEW_ACC_INVOICE_REP.INVOICE_DATE} in DateTime (" + DtpFrm.Value.Year + "," + DtpFrm.Value.Month + "," + DtpFrm.Value.Day + ", 00, 00, 00) to DateTime (" + DtpTo.Value.Year + ", " + DtpTo.Value.Month + ", " + DtpTo.Value.Day + ", 00, 00, 00)";
            cs.ShowRpt("Invoice_Gst.rpt", cnd, "Invoice", "Annexure~false@sig~false@lh~false");
        }

        private void DtpFrm_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
