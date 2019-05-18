using HDMagazine.Admin;
using HDMagazine.Masters;
using Oracle.DataAccess.Client;
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
    public partial class FrmView : Form
    {
        Class_DB db = new Class_DB();
        public string Tbl, SFld, Tbl_Clms;
        public Boolean Cnd = false;

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //** Testing
            if (txtSearch.Text == "")
            {
                Cnd = false;
                bind();
            }
            else
            {
                Cnd = true;
                bind();
            }
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            SelectFrom(true);
            this.Close();
        }

        public void bind()
        {
            string[] t = Tbl_Clms.Split(',');
            int r = t[0].IndexOf("as");
            string m = "";
            if (r <= 0)
                m = t[0].ToString();
            else
                m = t[0].Substring(0, r);
            OracleDataAdapter da;
            if (!Cnd)
                da = new OracleDataAdapter("Select " + Tbl_Clms + " from " + Tbl + " where NVL(Action_type,'I')<>'D'  and " + m.ToString() + ">0 order by " + SFld, db.Con);
            else
                da = new OracleDataAdapter("select " + Tbl_Clms + " from " + Tbl + " Where NVL(Action_type,'I')<>'D' and lower(" + SFld.Replace(",", "||") + ") Like lower('%" + txtSearch.Text + "%') and " + m.ToString() + ">0  order by " + SFld, db.Con);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != "0")
                btn_Apply_Click(sender, e);
            else
            {
                MessageBox.Show("You cont Modify this Record", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ShowPrntFrm(Form frm, Boolean var)
        {
            if (dataGridView1.RowCount > 0)
            {
                frm.MdiParent = FrmMDI.ActiveForm;
                if (var)
                    frm.Controls["LblPK"].Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.Show();
            }
            else
            {
                MessageBox.Show("There is no Records to Apply", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void SelectFrom(Boolean Aply)
        {
            switch (Tbl.ToLower())
            {
                case "vew_mas_subscriptions":
                    ShowPrntFrm(new FrmSubscription(), Aply);
                    break;
                case "mas_state":
                    ShowPrntFrm(new FrmState(), Aply);
                    break;
                case "mas_agency":
                    ShowPrntFrm(new FrmAgency(), Aply);
                    break;
                case "mas_client":
                    ShowPrntFrm(new FrmClient(), Aply);
                    break;
                case "mas_executive":
                    ShowPrntFrm(new FrmExecutive(), Aply);
                    break;
                case "mas_adm_user":
                    ShowPrntFrm(new FrmCreateUser(), Aply);
                    break;
                case "mas_sub_type":
                    ShowPrntFrm(new FrmSubType(), Aply);
                    break;
                case "mas_distributor":
                    ShowPrntFrm(new FrmDistributor(), Aply);
                    break;
            }
        }

        public FrmView(string Tlb_Name, string SrchField, string Title, string Tbl_Columns)
        {
            InitializeComponent();
            Tbl = Tlb_Name;
            SFld = SrchField;
            Tbl_Clms = Tbl_Columns;
            this.Text = Title;
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            Class_Style cs = new Class_Style();
            cs.FrmStyle(this);
            this.MdiParent = FrmMDI.ActiveForm;
            Cnd = false;
        }
    }
}
