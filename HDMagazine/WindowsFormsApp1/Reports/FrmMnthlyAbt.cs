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
    public partial class FrmMnthlyAbt : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmMnthlyAbt()
        {
            InitializeComponent();
        }

        private void FrmMnthlyAbt_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs.ShowRpt("Abstract.rpt", "{VEW_DISTRCT_ISSUED_ABT.ISSUE_MONTH} = DateTime (" + DtpMnth.Value.Year.ToString() + ", " + DtpMnth.Value.Month.ToString() + ", 01, 00, 00, 00)", "Abstract", null);
        }
    }
}
