using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class FrmDispRpt : Form
    {
        string Rpt_Name, Cnd, Hdng, Prmtrs;
        Class_DB db = new Class_DB();
        OracleDataAdapter da;
        DataTable tb;
        FileStream fs;
        byte[] blob;
        DataSet ds;
        private void FrmDispRpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)Application.OpenForms["FrmMDI"];
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
            ms.Visible = true;

            if (File.Exists(Application.StartupPath.ToString() + "\\Logo.jpg"))
                File.Delete(Application.StartupPath.ToString() + "\\Logo.jpg");

            if (File.Exists(Application.StartupPath.ToString() + "\\LH_H.jpg"))
                File.Delete(Application.StartupPath.ToString() + "\\LH_H.jpg");

            if (File.Exists(Application.StartupPath.ToString() + "\\LH_F.jpg"))
                File.Delete(Application.StartupPath.ToString() + "\\LH_F.jpg");

            if (File.Exists(Application.StartupPath.ToString() + "\\Sig.jpg"))
                File.Delete(Application.StartupPath.ToString() + "\\Sig.jpg");
        }

        public FrmDispRpt(string RptName, string Cond, string RptHdng, string Parameters)
        {
            InitializeComponent();
            Rpt_Name = RptName;
            Cnd = Cond;
            Hdng = RptHdng;
            Prmtrs = Parameters;
        }
        private void FrmDispRpt_Load(object sender, EventArgs e)
        {
            Form frm = (Form)Application.OpenForms["FrmMDI"];
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
            ms.Visible = false;

            this.WindowState = FormWindowState.Maximized;
            Application.DoEvents();
            Application.EnableVisualStyles();
            this.Text = Hdng;

            ReportDocument rd = new ReportDocument();
            rd.Load(Application.StartupPath + "\\Reports\\" + Rpt_Name);
            foreach (Table Tbl in rd.Database.Tables)
            {
                TableLogOnInfo tt = new TableLogOnInfo();
                tt.ConnectionInfo.ServerName = "orcl12c";
                tt.ConnectionInfo.UserID = "c##hdmagazine";
                tt.ConnectionInfo.Password = "user123#";
                Tbl.ApplyLogOnInfo(tt);
            }

            string msg = GetReportParamsAsText(rd);
            string[] prms = msg.Split('@');
            for (int i = 0; i < prms.Length; i++)
            {
                switch (prms[i].ToUpper())
                {
                    case "LOGO":
                        da = new OracleDataAdapter("select * from mas_settings where Parameter='LOGO'", db.Con);
                        tb = new DataTable();
                        da.Fill(tb);
                        fs = new FileStream(Application.StartupPath.ToString() + "\\Logo.jpg", FileMode.Create);
                        blob = (byte[])tb.Rows[0]["Image"];
                        fs.Write(blob, 0, blob.Length);
                        fs.Close();
                        fs = null;
                        rd.SetParameterValue("Logo", Application.StartupPath.ToString() + "\\Logo.jpg");
                        break;
                    case "LH_H":
                        da = new OracleDataAdapter("select * from mas_settings where parameter='LH_HEAD'", db.Con);
                        tb = new DataTable();
                        da.Fill(tb);
                        fs = new FileStream(Application.StartupPath.ToString() + "\\LH_H.jpg", FileMode.Create);
                        blob = (byte[])tb.Rows[0]["Image"];
                        fs.Write(blob, 0, blob.Length);
                        fs.Close();
                        fs = null;
                        rd.SetParameterValue("LH_H", Application.StartupPath.ToString() + "\\LH_H.jpg");
                        break;
                    case "LH_F":
                        da = new OracleDataAdapter("select * from mas_settings where parameter='LH_FOOT'", db.Con);
                        tb = new DataTable();
                        da.Fill(tb);
                        fs = new FileStream(Application.StartupPath.ToString() + "\\LH_F.jpg", FileMode.Create);
                        blob = (byte[])tb.Rows[0]["Image"];
                        fs.Write(blob, 0, blob.Length);
                        fs.Close();
                        fs = null;
                        rd.SetParameterValue("LH_F", Application.StartupPath.ToString() + "\\LH_F.jpg");
                        break;
                    case "SIG_IMG":
                        da = new OracleDataAdapter("select * from mas_settings where parameter='SIG'", db.Con);
                        tb = new DataTable();
                        da.Fill(tb);
                        fs = new FileStream(Application.StartupPath.ToString() + "\\SIG.jpg", FileMode.Create);
                        blob = (byte[])tb.Rows[0]["Image"];
                        fs.Write(blob, 0, blob.Length);
                        fs.Close();
                        fs = null;
                        rd.SetParameterValue("Sig_Img", Application.StartupPath.ToString() + "\\SIG.jpg");
                        break;
                    case "PAN":
                        ds = db.GetTableData("select * from mas_settings where parameter='PAN'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("PAN", dr["Value"].ToString());
                        break;
                    case "ST":
                        ds = db.GetTableData("select * from mas_settings where Parameter='ST_NO'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("ST", dr["Value"].ToString());
                        break;
                    case "TAN":
                        ds = db.GetTableData("select * from mas_settings where parameter='TIN'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("TIN", dr["Value"].ToString());
                        break;
                    case "CIN":
                        ds = db.GetTableData("select * from mas_settings where parameter='CIN'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("CIN", dr["Value"].ToString());
                        break;
                    case "GSTIN":
                        ds = db.GetTableData("select * from mas_settings where parameter='GST NO'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("GSTIN", dr["Value"].ToString());
                        break;
                    case "STATECODE":
                        ds = db.GetTableData("select * from mas_settings where parameter='STATE CODE'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("STATECODE", dr["Value"].ToString());
                        break;
                    case "BANKNAME":
                        ds = db.GetTableData("select * from mas_settings where parameter='BANK NAME'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("BANKNAME", dr["Value"].ToString());
                        break;
                    case "BANKBRANCH":
                        ds = db.GetTableData("select * from mas_settings where parameter='BRANCH NAME'");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("BANKBRANCH", dr["Value"].ToString());
                        break;
                    case "BANKCITY":
                        ds = db.GetTableData("select * from mas_settings where parameter='BANK CITY'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("BANKCITY", dr["Value"].ToString());
                        break;
                    case "BANKSTATE":
                        ds = db.GetTableData("select * from mas_settings where parameter='BANK STATE'");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("BANKSTATE", dr["Value"].ToString());
                        break;
                    case "IFSC":
                        ds = db.GetTableData("select * from mas_settings where parameter='IFSC CODE'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("IFSC", dr["Value"].ToString());
                        break;
                    case "MICR":
                        ds = db.GetTableData("select * from mas_settings where parameter='MICR CODE'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("MICR", dr["Value"].ToString());
                        break;
                    case "ACNO":
                        ds = db.GetTableData("select * from mas_settings where parameter='CC ACNO'");
                        foreach(DataRow dr in ds.Tables[0].Rows)
                            rd.SetParameterValue("ACNO", dr["Value"].ToString());
                        break;
                }
            }

            rd.SetParameterValue("username", GlobalClass.UserName);
            rd.SetParameterValue("Company", "Shreya Broadcasting Pvt. Ltd.,");
            rd.SetParameterValue("Add1", "Plot No. 92, Road No. 1, Jubilee Hills, Hyderabad - 500 033");
            rd.SetParameterValue("Add2", "Tel: +91 40 2355 5555 Fax : 3061 6527 E-Mail: marketing@tv5news.in, www.hindudharmam.in");
            //parameter split by '@'
            //name and value split by '~'
            if (Prmtrs != null)
            {
                string[] p = Prmtrs.Split('@');
                for (int i = 1; i <= p.Length; i++)
                {
                    string[] k = p[i - 1].Split('~');
                    rd.SetParameterValue(k[0].ToString(), k[1].ToString());
                }
            }
            crystalReportViewer1.ReportSource = rd;

            if (Cnd != null)
                crystalReportViewer1.SelectionFormula = Cnd;

            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ShowCloseButton = true;
            crystalReportViewer1.ShowExportButton = true;
            crystalReportViewer1.ShowGotoPageButton = true;
            crystalReportViewer1.ShowPageNavigateButtons = true;
            crystalReportViewer1.ShowPrintButton = true;
            crystalReportViewer1.ShowRefreshButton = true;
            crystalReportViewer1.ShowTextSearchButton = true;
            crystalReportViewer1.ShowZoomButton = true;
            crystalReportViewer1.BringToFront();
            Application.DoEvents();

        }

        public string GetReportParamsAsText(ReportDocument reportDocument)
        {
            if (reportDocument == null) return "Report not specified";
            string result = "";
            foreach (ParameterFieldDefinition prm in reportDocument.DataDefinition.ParameterFields)
            {
                try
                {
                    result += prm.ParameterFieldName.ToString() + "@";
                }
                catch
                {
                    // Ignore any errors
                }
            }
            return result;
        }
    }
}
