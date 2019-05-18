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
using WindowsFormsApp1;

namespace HDMagazine.Masters
{
    public partial class FrmExecutive : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmExecutive()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmExecutive_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            TxtID.Text = db.GetNewID("mas_executive", "executive_id").ToString();
            if (LblPK.Text.Trim().Length > 0)
            {
                TxtID.Text = LblPK.Text;
                DataSet ds = db.GetTableData("select * from mas_executive where executive_id=" + LblPK.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TxtName.Text = dr["executive_name"].ToString();
                        TxtRemarks.Text = dr["Remarks"].ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("mas_executive", "executive_id,executive_name", "Executive Master", "executive_id, executive_name");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Invalid Executive Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataSet ds;
            if (LblPK.Text.Trim().Length > 0)
                ds = db.GetTableData("select * from mas_executive where executive_name='" + TxtName.Text.Trim() + "' and executive_id<>" + LblPK.Text);
            else
                ds = db.GetTableData("select * from mas_executive where executive_name='" + TxtName.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("This Executive Name already Exists", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] res;
            if (LblPK.Text.Trim().Length > 0)
                res = db.ExecuteQueries("Update mas_executive set executive_name='" + TxtName.Text.Trim() + "', remarks='" + TxtRemarks.Text.Trim() + "', modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where executive_id=" + LblPK.Text).Split(',');
            else
                res = db.ExecuteQueries("Insert into mas_executive values (" + db.GetNewID("mas_executive", "executive_id") + ",'" + TxtName.Text.Trim() + "','" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');

            if (res[0].ToString() != "0")
            {
                MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtID.Text = db.GetNewID("mas_executive", "executive_id").ToString();
                TxtName.Text = "";
                TxtRemarks.Text = "";
                LblPK.Text = "";
            }
        }
    }
}
