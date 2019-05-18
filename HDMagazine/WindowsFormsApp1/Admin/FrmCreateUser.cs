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

namespace HDMagazine.Admin
{
    public partial class FrmCreateUser : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmCreateUser()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCreateUser_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            if(LblPK.Text.Trim().Length>0)
            {
                DataSet ds = db.GetTableData("select * from mas_adm_user where user_id=" + LblPK.Text.Trim());
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TxtUserName.Text = dr["user_name"].ToString();
                        TxtPwd.Text = dr["Pwd"].ToString();
                        if (dr["status"].ToString() == "U")
                            CmbStatus.Text = "Un-Lock";
                        else
                            CmbStatus.Text = "Lock";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtUserName.Text.Trim().Length < 4)
            {
                MessageBox.Show("Invalid User Name. User Name should be minimum 4 Characters", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUserName.Focus();
                return;
            }

            if (TxtPwd.Text.Trim().Length < 4)
            {
                MessageBox.Show("Invalid Password. Password should be minimum 4 characters", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPwd.Focus();
                return;
            }

            DataSet ds;
            if (LblPK.Text.Trim().Length <= 0)
                ds = db.GetTableData("select * from mas_adm_user where user_name='" + TxtUserName.Text.Trim() + "'");
            else
                ds = db.GetTableData("select * from mas_adm_user where user_name='" + TxtUserName.Text.Trim() + "' and user_id<>" + LblPK.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("This User Name already Exists", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUserName.Focus();
                return;
            }

            string[] res;
            if (LblPK.Text.Trim().Length <= 0)
                res = db.ExecuteQueries("Insert into mas_adm_user values (" + db.GetNewID("mas_adm_user", "user_id") + ",'" + TxtUserName.Text.Trim() + "','" + TxtPwd.Text.Trim() + "','" + CmbStatus.Text.Substring(0, 1) + "',null,'" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');
            else
                res = db.ExecuteQueries("Update mas_adm_user set user_name='" + TxtUserName.Text.Trim() + "', Pwd='" + TxtPwd.Text.Trim() + "', status='" + CmbStatus.Text.Substring(0, 1) + "', modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where user_id=" + LblPK.Text.Trim()).Split(',');

            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Failure...\n" + res[1].ToString(), "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPwd.Text = "";
                TxtUserName.Text = "";
                TxtUserName.Focus();
                LblPK.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmView vw = new FrmView("mas_adm_user", "user_id,user_name", "Create User", "User_id,user_name");
            vw.MdiParent = FrmMDI.ActiveForm;
            vw.Show();
            this.Close();
        }
    }
}
