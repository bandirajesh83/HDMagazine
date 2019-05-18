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
    public partial class FrmClient : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmClient()
        {
            InitializeComponent();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            db.TxtAutoFill(TxtName, "MAS_CLIENT", "CLIENT_NAME");
            TxtCode.Text = db.GetNewID("Mas_CLIENT", "CLIENT_Code").ToString();

            DataSet ds = db.GetTableData("Select state_code,state_name||'('||state_code||')' state_name, action_type from mas_gst_state");
            CmbState.DataSource = ds.Tables[0];
            CmbState.DisplayMember = "state_name";
            CmbState.ValueMember = "state_code";

            if (LblPK.Text.Trim().Length > 0)
            {
                ds = db.GetTableData("select * from mas_CLIENT where CLIENT_Code=" + LblPK.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TxtCode.Text = dr["CLIENT_Code"].ToString();
                        TxtName.Text = dr["CLIENT_Name"].ToString();
                        TxtComm.Text = dr["CLIENT_Commission"].ToString();
                        if (dr["active_flag"].ToString() == "Y")
                            ChkActive.Checked = true;
                        else
                            ChkActive.Checked = false;
                        DataSet ds1 = db.GetTableData("Select * from mas_gst_state where state_code=" + dr["state_code"].ToString());
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            CmbState.Text = dr1["State_name"].ToString() + "(" + dr1["State_Code"].ToString() + ")";
                        TxtGSTNo.Text = dr["Gst_No"].ToString();
                        TxtPANNo.Text = dr["PAN_No"].ToString();
                        TxtRemarks.Text = dr["Remarks"].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (TxtName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Client Name", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(db.ExtractCode(CmbState.Text)) <= 0)
            {
                MessageBox.Show("Invalid State Name", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LblPK.Text.Trim().Length > 0)
                ds = db.GetTableData("Select * from mas_client where client_name='" + TxtName.Text.Trim() + "' and client_code<>" + LblPK.Text);
            else
                ds = db.GetTableData("Select * from mas_client where client_name='" + TxtName.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("This Client Name already Exists", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] res;
            string act = "N";
            if (ChkActive.Checked)
                act = "Y";
            if (LblPK.Text.Trim().Length > 0)
                res = db.ExecuteQueries("Update mas_client set client_name='" + TxtName.Text.Trim() + "', client_Commission=" + TxtComm.Text.Trim() + ", active_flag='" + act + "',State_code='" + db.ExtractCode(CmbState.Text) + "',gst_no='" + TxtGSTNo.Text.Trim() + "', pan_no='" + TxtPANNo.Text.Trim() + "', Remarks='" + TxtRemarks.Text.Trim() + "', Modified_by='" + GlobalClass.UserName + "', Modified_date=sysdate where client_code=" + LblPK.Text).Split(',');
            else
                res = db.ExecuteQueries("Insert into mas_client values (" + db.GetNewID("mas_client", "client_Code") + ",'" + TxtName.Text.Trim() + "'," + TxtComm.Text.Trim() + ",null,'" + act + "','" + db.ExtractCode(CmbState.Text) + "','" + TxtGSTNo.Text.Trim() + "','" + TxtPANNo.Text.Trim() + "','" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "', sysdate, null, null, 'I')").Split(',');
            if (res[0].ToString() != "0")
            {
                MessageBox.Show("Updation Failure", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCode.Text = db.GetNewID("Mas_Client", "Client_Code").ToString();
                TxtName.Text = "";
                TxtGSTNo.Text = "";
                TxtPANNo.Text = "";
                TxtRemarks.Text = "";
                ChkActive.Checked = false;
                LblPK.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("mas_client", "client_Code,client_name,client_Commission,active_flag,state_code,gst_no,pan_no", "Client Master", "Client_Code,Client_name,Client_Commission,active_flag,state_code,gst_no,pan_no");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
