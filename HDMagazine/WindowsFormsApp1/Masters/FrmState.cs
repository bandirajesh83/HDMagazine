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
    public partial class FrmState : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmState()
        {
            InitializeComponent();
        }

        private void FrmState_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            TxtID.Text = db.GetNewID("mas_state", "state_id").ToString();
            if(LblPK.Text.Trim().Length>0)
            {
                TxtID.Text = LblPK.Text;
                DataSet ds = db.GetTableData("select * from mas_state where state_id=" + LblPK.Text);
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        TxtName.Text = dr["state_name"].ToString();
                        TxtStateCode.Text = dr["gst_state_code"].ToString();
                        TxtRemarks.Text = dr["Remarks"].ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (TxtName.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid State Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(TxtStateCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("Invalid State Code", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtStateName.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid State Code", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LblPK.Text.Trim().Length > 0)
                ds = db.GetTableData("select * from mas_state where state_name='" + TxtName.Text.Trim() + "' and state_id<>" + LblPK.Text);
            else
                ds = db.GetTableData("select * from mas_state where state_name='" + TxtName.Text.Trim() + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("This State Name already Exists", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] res;
            if (LblPK.Text.Trim().Length > 0)
                res = db.ExecuteQueries("Update mas_state set state_name='" + TxtName.Text.Trim() + "', gst_state_code='" + TxtStateCode.Text.Trim() + "', remarks='" + TxtRemarks.Text.Trim() + "', modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where state_id=" + LblPK.Text).Split(',');
            else
                res = db.ExecuteQueries("Insert into mas_state values (" + db.GetNewID("mas_state", "state_id") + ",'" + TxtName.Text.Trim() + "','" + TxtStateCode.Text.Trim() + "','" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtID.Text = db.GetNewID("mas_state", "state_id").ToString();
                TxtName.Text = "";
                TxtStateCode.Text = "";
                TxtStateName.Text = "";
                TxtRemarks.Text = "";
                LblPK.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("mas_state", "state_id,state_name", "State Master", "State_id, State_Name");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }

        private void TxtStateCode_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = db.GetTableData("select * from mas_gst_state where state_code='" + TxtStateCode.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    TxtStateName.Text = dr["state_name"].ToString();
            }
            else
                TxtStateName.Text = "";
        }
    }
}
