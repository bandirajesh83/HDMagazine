using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Data;
using HDMagazine.Class;
using Microsoft.Office.Interop.Excel;

namespace HDMagazine
{
    class Class_DB
    {
        public OracleConnection Con;
        public OracleConnection MstCon;
        public OracleCommand cmd;
        public Class_DB()
        {
            try
            {
                Con = new OracleConnection("User Id = c##hdmagazine;Password=user123#;Data Source=orcl12c");
                MstCon = new OracleConnection("User Id= c##tekdev;Password=user123#;Data Source=orcl12c");
                Con.Open();
                MstCon.Open();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Distructor
        ~Class_DB()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
        }
        public string ExecuteQueries(string Qry)
        {
            try
            {
                cmd = new OracleCommand(Qry.ToUpper(), Con);
                cmd.ExecuteNonQuery();
                return "0";
            }
            catch (Exception ec)
            {
                return ec.Message.ToString();
            }
        }

        public string GetAccCode(string Prefix, string TlbName, string ColmName, DateTime TxDate)
        {
            string RTCode = "";
            if (Con.State == ConnectionState.Closed) Con.Open();
            OracleCommand cmd = new OracleCommand("SELECT   MAX (SUBSTR (" + ColmName + ", 1, INSTR (" + ColmName + ", '/', 1, 3))|| LPAD (SUBSTR (" + ColmName + ",INSTR (" + ColmName + ", '/', 1, 3) + 1)+ 1,5,'0')) ro_code,decode(action_type,'U','I',action_type) action_type FROM " + TlbName + " where substr(" + ColmName + ",1,2)='" + Prefix + "' and fnyr='" + GetFinYr(TxDate) + "' GROUP BY decode(action_type,'U','I',action_type)", Con);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                    RTCode = dr["ro_code"].ToString();
            }
            else
            {
                RTCode = Prefix + "/" + Class.GlobalClass.ShortName + "/" + GetFinYr(TxDate).Substring(0,2) + "-" + GetFinYr(TxDate).Substring(2,2) + "/00001";
            }
            return RTCode;
        }

        public Int32 GetNewID(string TlbName, string PKColumn)
        {
            Int32 id = 0;
            OracleCommand cmd;
            string sql = "select NVL(max(" + PKColumn + "),0) newid from " + TlbName;
            cmd = new OracleCommand(sql, Con);
            OracleDataReader NIdr = cmd.ExecuteReader();
            if (NIdr.Read())
            {
                id = Convert.ToInt32(NIdr[0].ToString());
                id = id + 1;
            }
            else
            {
                id = 1;
            }
            NIdr.Close();
            return id;
        }

        public DataSet GetTableData(string sql)
        {
            sql = "select * from (" + sql + ") where action_type not in ('D','C')";
            OracleDataAdapter da;
            da = new OracleDataAdapter(sql, Con);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            return ds;
        }

        public DataSet GetMasterData(string sql)
        {
            sql = "select * from (" + sql + ") where action_type not in ('D','C')";
            OracleDataAdapter da;
            da = new OracleDataAdapter(sql, MstCon);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            return ds;
        }

        public string ExtractCode(string itmtxt)
        {
            string[] itm = itmtxt.Split('(');
            string[] cod = itm[itm.Length - 1].Split(')');
            return cod[0].ToString();
        }

        public string GetFinYr(DateTime dt)
        {
            DateTime DtSysDate = dt;
            int Dts = Convert.ToInt32(DtSysDate.Month.ToString() + DtSysDate.ToString("dd"));
            string DtMon = DtSysDate.ToString("MM");
            string FY = "";
            if (Dts >= 101 && Dts <= 331)
                FY = DtSysDate.AddYears(-1).ToString("yy") + DtSysDate.ToString("yy");
            else FY = DtSysDate.ToString("yy") + DtSysDate.AddYears(1).ToString("yy");
            return FY;
        }
        public string LedZero(Int32 Num, Int32 len)
        {
            if (Num.ToString().Trim().Length >= len)
                return Num.ToString().Trim();
            else
            {
                string RetVal = "";
                for (int i = 0; i < (len - Num.ToString().Trim().Length); i++)
                    RetVal = RetVal + "0";
                RetVal = RetVal + Num.ToString().Trim();
                return RetVal;
            }
        }
        public void TxtAutoFill(System.Windows.Forms.TextBox txtbox, string TlbName, string fieldName)
        {
            AutoCompleteStringCollection namescollection = new AutoCompleteStringCollection();
            DataSet ds = GetTableData("select * from " + TlbName + " order by " + fieldName + " asc");
            System.Data.DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
                namescollection.Add(dr[fieldName].ToString());
            txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbox.AutoCompleteCustomSource = namescollection;
        }
        public void ExportToExcel(DataGridView DATASETNAME)
        {
            try
            {
                if (DATASETNAME.Rows.Count > 0)
                {
                    ApplicationClass excel = new ApplicationClass();

                    excel.Application.Workbooks.Add(true);
                    Int32 Cell = 0;
                    for (int i = 0; i < DATASETNAME.Columns.Count; i++)
                    {
                        Class.GlobalClass.Prg_Value = ((i * 100) / DATASETNAME.Columns.Count);
                        if (DATASETNAME.Columns[i].Visible == true)
                        {
                            excel.Cells[1, Cell + 1] = DATASETNAME.Columns[i].Name.ToString();
                            Cell++;
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    int rows = 0;
                    for (int j = 1; j <= DATASETNAME.Rows.Count; j++)
                    {
                        Class.GlobalClass.Prg_Value = ((j * 100) / DATASETNAME.Rows.Count);
                        Cell = 0;
                        for (int k = 0; k < DATASETNAME.Columns.Count; k++)
                        {

                            if (DATASETNAME.Rows[j - 1].Cells[k].Visible == true)
                            {
                                string ttrr = DATASETNAME.Columns[k].ValueType.Name.ToString();
                                if (ttrr.ToUpper() == "DATETIME")
                                {
                                    if (DATASETNAME.Rows[j - 1].Cells[k].Value == null)
                                        excel.Cells[j + 1, Cell + 1] = "";
                                    else if (DATASETNAME.Rows[j - 1].Cells[k].Value.ToString() != "")
                                        excel.Cells[j + 1, Cell + 1] = Convert.ToDateTime(DATASETNAME.Rows[j - 1].Cells[k].Value.ToString()).ToString("dd-MMM-yy");
                                    else
                                        excel.Cells[j + 1, Cell + 1] = DATASETNAME.Rows[j - 1].Cells[k].Value.ToString();
                                }
                                else
                                {
                                    if (DATASETNAME.Rows[j - 1].Cells[k].Value == null)
                                        excel.Cells[j + 1, Cell + 1] = "";
                                    else if (DATASETNAME.Rows[j - 1].Cells[k].Value.ToString() != "")
                                        excel.Cells[j + 1, Cell + 1] = DATASETNAME.Rows[j - 1].Cells[k].Value.ToString();
                                    else
                                        excel.Cells[j + 1, Cell + 1] = "";
                                }
                                Cell++;
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                        rows = rows + 1;
                    }
                    Class.GlobalClass.Prg_Value = 0;
                    excel.get_Range(excel.Cells[1, 1], excel.Cells[rows + 1, Cell]).Borders.Weight = 2d;
                    excel.get_Range(excel.Cells[1, 1], excel.Cells[rows + 1, Cell]).Columns.AutoFit();

                    if (DATASETNAME.Name == "ESIDB")
                    {
                        excel.get_Range(excel.Cells[1, 3], excel.Cells[rows + 1, 3]).TextToColumns(Type.Missing, Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited, Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierNone, true, Type.Missing, Type.Missing, false, true, Type.Missing, " ", Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }

                    excel.Visible = true;
                    Worksheet worksheet = (Worksheet)excel.ActiveSheet;
                    //worksheet.Activate();
                }
                else
                {
                    MessageBox.Show("There is no Data to Export", "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), "MCube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
