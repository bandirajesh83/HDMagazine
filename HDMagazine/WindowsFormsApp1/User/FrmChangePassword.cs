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

namespace HDMagazine.User
{
    public partial class FrmChangePassword : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            TxtUserName.Text = GlobalClass.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtOPwd.Text.Trim().Length<=0 || TxtNPwd.Text.Trim().Length<=0||TxtCPwd.Text.Trim().Length<=0)
            {
                MessageBox.Show("All fields are mandatory", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string pwd = "";
            DataSet ds = db.GetTableData("select * From mas_adm_user where user_name='" + TxtUserName.Text.Trim() + "'");
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    pwd = dr["pwd"].ToString();
                }
            }

            if (pwd != TxtOPwd.Text.Trim())
            {
                MessageBox.Show("Invalid Old Password", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtCPwd.Text.Trim() != TxtNPwd.Text.Trim())
            {
                MessageBox.Show("New Password and Confirm Password does not matched", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtNPwd.Text.Trim() == TxtOPwd.Text.Trim())
            {
                MessageBox.Show("Old Password and New Password is same", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] res = db.ExecuteQueries("Update mas_adm_user set pwd='" + TxtNPwd.Text.Trim() + "', modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where user_name='" + TxtUserName.Text.Trim() + "'").Split(',');
            if(res[0].ToString()!="0")
            {
                MessageBox.Show("Updation Failure..", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "Hindudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCPwd.Text = "";
                TxtNPwd.Text = "";
                TxtOPwd.Text = "";
                TxtOPwd.Focus();
            }
        }
    }
}
