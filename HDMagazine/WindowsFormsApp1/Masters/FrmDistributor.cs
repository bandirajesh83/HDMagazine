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
    public partial class FrmDistributor : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmDistributor()
        {
            InitializeComponent();
        }

        private void FrmDistributor_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            DataSet ds = db.GetTableData("select region_id, region_name || '(' || region_id || ')' region_name, action_type from mas_region");
            CmbRegion.DataSource = ds.Tables[0];
            CmbRegion.DisplayMember = "region_name";
            CmbRegion.ValueMember = "region_id";

            if(LblPK.Text.Trim().Length>0)
            {
                DataSet ds1 = db.GetTableData("select * from mas_distributor where distributor_code=" + LblPK.Text);
                if(ds1.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dr in ds1.Tables[0].Rows)
                    {
                        TxtName.Text = dr["distributor_name"].ToString();
                        TxtAddress.Text = dr["Distributor_address"].ToString();
                        TxtRemarks.Text = dr["Remarks"].ToString();
                        DataSet ds2 = db.GetTableData("Select * from mas_region where region_id=" + dr["region_id"].ToString());
                        if(ds2.Tables[0].Rows.Count>0)
                        {
                            foreach (DataRow dr1 in ds2.Tables[0].Rows)
                                CmbRegion.Text = dr1["region_name"].ToString() + "(" + dr1["region_id"].ToString() + ")";
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("mas_distributor", "distributor_code, distributor_name, distributor_address", "Distributor Details", "distributor_code, distributor_name, distributor_address");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtName.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid Distributor Name", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(TxtAddress.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid Distributor Address", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataSet ds;
            if (LblPK.Text.Trim().Length > 0)
                ds = db.GetTableData("select * from mas_distributor where distributor_name='" + TxtName.Text.Trim() + "' and region_id=" + db.ExtractCode(CmbRegion.Text) + " and distributor_code<>" + LblPK.Text);
            else
                ds = db.GetTableData("select * from mas_distributor where distributor_name='" + TxtName.Text.Trim() + "' AND region_ID=" + db.ExtractCode(CmbRegion.Text));

            if(ds.Tables[0].Rows.Count>0)
            {
                MessageBox.Show("This Distributor Name already Exists", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] res;
            if (LblPK.Text.Trim().Length > 0)
                res = db.ExecuteQueries("Update mas_distributor set distributor_name='" + TxtName.Text.Trim() + "', region_id=" + db.ExtractCode(CmbRegion.Text) + ", distributor_address='" + TxtAddress.Text.Trim() + "', remarks='" + TxtRemarks.Text.Trim() + "', modified_by='" + GlobalClass.UserName + "', MODIFIED_DATE=SYSDATE WHERE DISTRIBUTOR_CODE=" + LblPK.Text.Trim()).Split(',');
            else
                res = db.ExecuteQueries("INSERT INTO MAS_DISTRIBUTOR VALUES (" + db.GetNewID("mas_distributor", "distributor_code") + ",'" + TxtName.Text.Trim() + "'," + db.ExtractCode(CmbRegion.Text) + ",'" + TxtAddress.Text.Trim() + "','" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "', sysdate, null, null, 'I')").Split(',');
            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Updation Failure..", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAddress.Text = "";
                TxtName.Text = "";
                TxtRemarks.Text = "";
                LblPK.Text = "";
                TxtName.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
