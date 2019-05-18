using HDMagazine.Class;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMagazine
{
    public partial class FrmAppSettings : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmAppSettings()
        {
            InitializeComponent();
        }

        private void FrmAppSettings_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);
            comboBox1.SelectedIndex = 0;
            pictureBox1.Image = null;
            pictureBox1.Refresh();
            button1.Enabled = true;
            OfDlg.FileName = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OfDlg.Filter = "JPEG|*.jpg;*.jpeg|PNG|*.png|GIF|*.gif|BMP|*.bmp";
                if (OfDlg.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image = Image.FromFile(OfDlg.FileName.ToString());
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "Delete")
                {
                    if (MessageBox.Show("Are you sure, Do you want to Delete this Parameter...?", "MCube", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.ExecuteQueries("Delete from mas_settings where setting_id=" + label8.Text.ToString());
                        MessageBox.Show("Successfully Deleted", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Text = "Save";
                        TxtDesc.Text = "";
                        TxtRef.Text = "";
                        TxtRemarks.Text = "";
                        TxtValue.Text = "";
                        pictureBox1.DataBindings.Clear();
                        pictureBox1.Image = null;
                        return;
                    }
                }

                int id = db.GetNewID("Mas_Settings", "Setting_ID");

                string sql = "";
                if (OfDlg.FileName.ToString() != "")
                {
                    FileStream fs = new FileStream(OfDlg.FileName.ToString(), FileMode.Open, FileAccess.Read);
                    byte[] ImageData = new byte[fs.Length];
                    fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();

                    sql = "Insert into mas_Settings values (" + id + ",'" + comboBox1.Text.ToString() + "','" + TxtRef.Text.ToString() + "','" + TxtDesc.Text.ToString() + "','" + TxtValue.Text.ToString() + "',:Image,'" + TxtRemarks.Text.ToString() + "','" + GlobalClass.UserName.ToString() + "',sysdate,null,null,'I')";

                    OracleParameter Img = new OracleParameter();
                    Img.OracleDbType = OracleDbType.Blob;
                    Img.ParameterName = "Image";
                    Img.Value = ImageData;

                    OracleCommand cmd = new OracleCommand(sql, db.Con);
                    cmd.Parameters.Add(Img);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    sql = "Insert into mas_Settings values (" + id + ",'" + comboBox1.Text.ToString() + "','" + TxtRef.Text.ToString() + "','" + TxtDesc.Text.ToString() + "','" + TxtValue.Text.ToString() + "',null,'" + TxtRemarks.Text.ToString() + "','" + GlobalClass.UserName.ToString() + "',sysdate,null,null,'I')";
                    db.ExecuteQueries(sql);
                }

                OfDlg.FileName = "";
                pictureBox1.Image = null;
                pictureBox1.Refresh();
                MessageBox.Show("Successfully Saved", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = db.GetTableData("select * from mas_settings where Parameter='" + comboBox1.Text.ToString() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    label8.Text = dr["setting_id"].ToString();
                    TxtRef.Text = dr["Ref_id"].ToString();
                    TxtDesc.Text = dr["Description"].ToString();
                    TxtValue.Text = dr["Value"].ToString();
                    if (dr["Image"].ToString() != null)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("select * from mas_settings where Parameter='" + comboBox1.Text.ToString() + "'", db.Con);
                        DataTable tb = new DataTable();
                        da.Fill(tb);
                        pictureBox1.DataBindings.Clear();
                        pictureBox1.DataBindings.Add("Image", tb, "Image", true);
                        Application.DoEvents();
                    }
                    TxtRemarks.Text = dr["Remarks"].ToString();
                    button1.Text = "Delete";
                }
            }
            else
            {
                label8.Text = "";
                TxtRef.Text = "";
                TxtDesc.Text = "";
                TxtValue.Text = "";
                pictureBox1.DataBindings.Clear();
                pictureBox1.Image = null;
                TxtRemarks.Text = "";
                button1.Text = "Save";
            }
        }
    }
}
