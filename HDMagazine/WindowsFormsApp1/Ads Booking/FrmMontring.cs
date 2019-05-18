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

namespace HDMagazine.Masters
{
    public partial class FrmMontring : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();

        public FrmMontring()
        {
            InitializeComponent();
        }

        private void FrmMontring_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            DataSet ds = db.GetTableData("Select ad_category_code, ad_category_name || '('|| ad_Category_code || ')' ADCategoryName, Action_type from mas_ad_Category");
            CmbADCategory.DataSource = ds.Tables[0];
            CmbADCategory.DisplayMember = "ADCategoryName";
            CmbADCategory.ValueMember = "AD_Category_Code";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (Convert.ToInt16(db.ExtractCode(CmbADCategory.Text)) > 0)
                ds = db.GetTableData("select dr.ro_detail_code, dr.ro_header_code, publish_month,  brand, caption,rate_card_amount, published_page page_no, mc.Remarks, dr.action_type from dtl_ro dr, hdr_ro hr,mas_capsulling mc where hr.ro_header_code (+)= dr.ro_header_code and mc.ro_header_code (+)= dr.ro_header_code and mc.ro_detail_code (+)= dr.ro_detail_code and ro_status='B' and publish_month='01-" + DtpMnth.Value.ToString("MMM-yy") + "' and ad_category_code=" + db.ExtractCode(CmbADCategory.Text) + " order by ro_detail_code");
            else
                ds = db.GetTableData("select dr.ro_detail_code, dr.ro_header_code, publish_month,  brand, caption,rate_card_amount, published_page page_no, mc.Remarks, dr.action_type from dtl_ro dr, hdr_ro hr,mas_capsulling mc where hr.ro_header_code (+)= dr.ro_header_code and mc.ro_header_code (+)= dr.ro_header_code and mc.ro_detail_code (+)= dr.ro_detail_code and ro_status='B' and publish_month='01-" + DtpMnth.Value.ToString("MMM-yy") + "' order by ro_detail_code");
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "RO Header Code";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Brand";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].HeaderText = "Caption";
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].HeaderText = "Amount";
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].HeaderText = "Page No";
            dataGridView1.Columns[6].ReadOnly = false;
            dataGridView1.Columns[7].HeaderText = "Reamrks";
            dataGridView1.Columns[7].ReadOnly = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure, Do you want to Save..?","HD Magazine", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                for(int i = 0; i<dataGridView1.Rows.Count;i++)
                {
                    string[] res;
                    if (dataGridView1.Rows[i].Cells["Page_NO"].Value.ToString().Trim().Length > 0 || dataGridView1.Rows[i].Cells["Remarks"].Value.ToString().Trim().Length > 0)
                    {
                        DataSet ds = db.GetTableData("Select * from mas_capsulling where ro_detail_code=" + dataGridView1.Rows[i].Cells["RO_Detail_Code"].Value.ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                            res = db.ExecuteQueries("Update mas_capsulling set published_page='" + dataGridView1.Rows[i].Cells["Page_NO"].Value.ToString() + "',Remarks='" + dataGridView1.Rows[i].Cells["Remarks"].Value.ToString() + "', Modified_by='" + GlobalClass.UserName + "', modified_date=sysdate where ro_detail_code=" + dataGridView1.Rows[i].Cells["RO_Detail_Code"].Value.ToString()).Split(',');
                        else
                            res = db.ExecuteQueries("Insert into mas_capsulling values (" + db.GetNewID("Mas_Capsulling", "Tx_Code") + ",'01-" + DtpMnth.Value.ToString("MMM-yy") + "','" + dataGridView1.Rows[i].Cells["RO_Header_Code"].Value.ToString() + "'," + dataGridView1.Rows[i].Cells["RO_Detail_Code"].Value.ToString() + ",'" + dataGridView1.Rows[i].Cells["Page_NO"].Value.ToString() + "',null,'" + dataGridView1.Rows[i].Cells["Remarks"].Value.ToString() + "','" + GlobalClass.UserName + "',sysdate, null, null, 'I')").Split(',');

                        if (res[0].ToString() != "0")
                        {
                            MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                MessageBox.Show("Successfully Saved", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtpMnth_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }
    }
}
