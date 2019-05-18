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

namespace HDMagazine
{
    public partial class FrmLogin : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = db.GetTableData("select * from mas_adm_user where user_name='" + TxtUserName.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["pwd"].ToString() == TxtPwd.Text)
                    {
                        GlobalClass.User = TxtUserName.Text;
                        GlobalClass.ShrtName = "HMZ";

                        this.Hide();

                        FrmMDI frm = new FrmMDI();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.IsMdiContainer = true;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password", "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid User Name", "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
