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
    public partial class FrmAddressBook : Form
    {
        Class_DB db = new Class_DB();
        Class_Style cs = new Class_Style();
        public FrmAddressBook()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddressBook_Load(object sender, EventArgs e)
        {
            cs.FrmStyle(this);

            DataSet ds = db.GetTableData("select region_id, region_name||'('|| region_ID ||')' Region_Name, Action_type from mas_region order by region_name");
            CmbRegion.DataSource = ds.Tables[0];
            CmbRegion.DisplayMember = "Region_Name";
            CmbRegion.ValueMember = "Region_ID";


        }

        private void CmbPartyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Agency
            //Client
            DataSet ds;
            if (CmbPartyType.Text == "Agency")
                ds = db.GetTableData("select Agency_Code PartyCode, Agency_name || '(' || Agency_Code ||')' PartyName, Action_type from mas_agency order by agency_name");
            else
                ds = db.GetTableData("select Client_Code PartyCode, Client_name || '(' || Client_COde ||')' PartyName, Action_type from mas_client order by client_name");

            CmbPartyName.DataSource = ds.Tables[0];
            CmbPartyName.DisplayMember = "PartyName";
            CmbPartyName.ValueMember = "PartyCode";
        }

        private void CmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ptype = "";
            if (CmbPartyType.Text == "Agency")
                ptype = "AG";
            else
                ptype = "CL";
            DataSet ds = db.GetTableData("Select * from mas_address_book where region_id=" + db.ExtractCode(CmbRegion.Text) + " and Party_type='" + ptype + "' and party_code=" + db.ExtractCode(CmbPartyName.Text));
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    LblPK.Text = dr["address_id"].ToString();
                    TxtAddress.Text = dr["Address"].ToString();
                    TxtCity.Text = dr["Town_City"].ToString();
                    TxtPIN.Text = dr["pincode"].ToString();
                    TxtTelPh.Text = dr["Telephone"].ToString();
                    TxtFax.Text = dr["Fax"].ToString();
                    TxtMobile.Text = dr["Mobile"].ToString();
                    TxtMail.Text = dr["email_id"].ToString();
                    TxtStateCode.Text = dr["State_Code"].ToString();
                    TxtGSTNo.Text = dr["GST_No"].ToString();
                    TxtPANNo.Text = dr["PAN_NO"].ToString();
                    TxtRemarks.Text = dr["Remarks"].ToString();
                }
            }
            else
            {
                LblPK.Text = "";
                TxtAddress.Text = "";
                TxtCity.Text = "";
                TxtPIN.Text = "";
                TxtTelPh.Text = "";
                TxtFax.Text = "";
                TxtMobile.Text = "";
                TxtMail.Text = "";
                TxtGSTNo.Text = "";
                TxtStateCode.Text = "";
                TxtPANNo.Text = "";
                TxtRemarks.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtAddress.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid Address", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(TxtCity.Text.Trim().Length<=0)
            {
                MessageBox.Show("Invalid City Name", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(TxtStateCode.Text.Trim().Length<=0)
            {
                MessageBox.Show("State Code Mandatory", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TxtPANNo.Text.Trim().Length > 0)
            {
                if (TxtPANNo.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Invalid PAN Number", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtGSTNo.Text.Trim().Length > 0)
                {
                    if (TxtPANNo.Text.Trim() != TxtGSTNo.Text.Trim().Substring(2, 10))
                    {
                        MessageBox.Show("Invalid PAN Number or GST Number", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (TxtGSTNo.Text.Trim().Length > 0)
            {
                if (TxtGSTNo.Text.Trim().Length != 15)
                {
                    MessageBox.Show("Invalid GST number", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtGSTNo.Text.Trim().Substring(0, 2) != TxtStateCode.Text.Trim())
                {
                    MessageBox.Show("Invalid GST Number or State Code", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string ptype = "";
            if (CmbPartyType.Text == "Agency")
                ptype = "AG";
            else
                ptype = "CL";
            string[] res;
            if (LblPK.Text.Trim().Length > 0)
                res = db.ExecuteQueries("Update mas_address_book set address='" + TxtAddress.Text.Trim() + "', Town_City='" + TxtCity.Text.Trim() + "', PINCOde='" + TxtPIN.Text.Trim() + "',Telephone='" + TxtTelPh.Text.Trim() + "',Fax='" + TxtFax.Text.Trim() + "',Mobile='" + TxtMobile.Text.Trim() + "',Email_ID='" + TxtMail.Text.Trim() + "', State_Code='" + TxtStateCode.Text.Trim() + "',GST_No='" + TxtGSTNo.Text.Trim() + "', PAN_No='" + TxtPANNo.Text.Trim() + "', Remarks='" + TxtRemarks.Text.Trim() + "', Modified_by='" + GlobalClass.UserName + "', Modified_date=sysdate where address_id=" + LblPK.Text).Split(',');
            else
                res = db.ExecuteQueries("Insert into mas_address_book values (" + db.GetNewID("Mas_Address_book", "Address_id") + "," + db.ExtractCode(CmbRegion.Text) + ",'" + ptype + "'," + db.ExtractCode(CmbPartyName.Text) + ",'" + TxtAddress.Text.Trim() + "','" + TxtCity.Text.Trim() + "','" + TxtPIN.Text + "','" + TxtTelPh.Text.Trim() + "','" + TxtFax.Text.Trim() + "','" + TxtMobile.Text.Trim() + "','" + TxtMail.Text.Trim() + "','" + TxtStateCode.Text.Trim() + "','" + TxtGSTNo.Text.Trim() + "','" + TxtPANNo.Text.Trim() + "','" + TxtRemarks.Text.Trim() + "','" + GlobalClass.UserName + "', sysdate, null, null, 'I')").Split(',');
            if(res[0].ToString() !="0")
            {
                MessageBox.Show("Insertion Failure..", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Successfully Saved", "HD Magazine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LblPK.Text = "";
                TxtAddress.Text = "";
                TxtCity.Text = "";
                TxtPIN.Text = "";
                TxtTelPh.Text = "";
                TxtFax.Text = "";
                TxtMobile.Text = "";
                TxtMail.Text = "";
                TxtRemarks.Text = "";
                TxtStateCode.Text = "";
                TxtGSTNo.Text = "";
                TxtPANNo.Text = "";
            }
        }
    }
}
