using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seagull.BarTender.Print;
using Oracle.DataAccess.Client;


namespace HDMagazine.Reports
{
    public partial class FrmLabelPrint : Form
    {
        public FrmLabelPrint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Engine lblengine = new Engine(true))
            {
                LabelFormatDocument lblfor = lblengine.Documents.Open(Application.ExecutablePath + "\\Reports\\Labels.btw");
                lblfor.PrintSetup.PrinterName = "";
                Messages messages;
                Result result = lblfor.Print("Label Print", 1000, out messages);
                string messageString = "\n\nMessages:";
                foreach (Seagull.BarTender.Print.Message message in messages)
                {
                    messageString += "\n\n" + message.Text;
                }
                if (result == Result.Failure)
                    MessageBox.Show(this, "Print Failed" + messageString, "Label Print");
                else
                    MessageBox.Show(this, "Label was successfully sent to printer." + messageString, "Label Print");
            }
        }

        private void FrmLabelPrint_Load(object sender, EventArgs e)
        {
            Class_Style cs = new Class_Style();
            cs.FrmStyle(this);
        }
    }
}
