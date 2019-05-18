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
    public partial class FrmSubType : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmSubType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtType.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid Subscription Type", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TxtIssues.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid No. of Subscriptions", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds;
            if(LblPK.Text.Trim().Length>0)
            {
                ds = db.GetTableData("select * from mas_sub_type where sub_type_id<>" + LblPK.Text.Trim() + " and sub_type_name='" + TxtType.Text.Trim() + "'");
                if(ds.Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("This Subscription Type already exists", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                ds = db.GetTableData("select * from mas_sub_type where sub_type_name='" + TxtType.Text.Trim() + "'");
                if(ds.Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("This Subscription Type already Exists", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string[] res;
            if (LblPK.Text.Trim().Length > 0)
                res = db.ExecuteQueries("Update mas_sub_type set sub_type_name='" + TxtType.Text.Trim() + "', issues=" + TxtIssues.Text.Trim() + ", Remarks='" + TxtRemarks.Text.Trim() + "', modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where sub_type_id=" + LblPK.Text.Trim()).Split(',');
            else
                res = db.ExecuteQueries("Insert into mas_sub_type values (" + db.GetNewID("mas_sub_type", "sub_type_id") + ",'" + TxtType.Text.Trim() + "'," + TxtIssues.Text.Trim() + ",'" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');

            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Insertion / Updation Failure..", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtIssues.Text = "";
                TxtRemarks.Text = "";
                TxtType.Text = "";
                LblPK.Text = "";
                TxtType.Focus();
            }
        }

        private void FrmSubType_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            if(LblPK.Text.Trim().Length>0)
            {
                DataSet ds = db.GetTableData("select * from mas_sub_type where sub_type_id=" + LblPK.Text.Trim());
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        TxtType.Text = dr["sub_type_name"].ToString();
                        TxtIssues.Text = dr["issues"].ToString();
                        TxtRemarks.Text = dr["remarks"].ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("mas_sub_type", "sub_type_id,sub_type_name, issues", "Subscription Type", "sub_type_id,sub_type_name, issues");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }
    }
}
