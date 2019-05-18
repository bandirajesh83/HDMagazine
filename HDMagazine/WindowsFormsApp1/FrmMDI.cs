using HDMagazine;
using HDMagazine.Accounts;
using HDMagazine.Admin;
using HDMagazine.Class;
using HDMagazine.Masters;
using HDMagazine.Reports;
using HDMagazine.Transactions;
using HDMagazine.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            Class_DB db = new Class_DB();
            toolStripStatusLabel2.Text = GlobalClass.UserName;
        }

        private void FrmShow(Form Frm)
        {
            if (IsFrmActive("FrmMDI")) CloseChildFrms();
            Frm.MdiParent = this;
            Frm.BringToFront();
            Frm.Show();
        }
        private void CloseChildFrms()
        {
            foreach (Form childForm in MdiChildren)
                childForm.Close();
        }
        private Boolean IsFrmActive(string Name)
        {
            Boolean tt = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == Name)
                    tt = true;
            }
            return tt;
        }

        private void subscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stateMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmState());
        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel5.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            toolStripStatusLabel8.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void subscriptionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmSubscription());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmAgency());
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmClient());
        }

        private void addressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmAddressBook());
        }

        private void rOEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmROEntry());
        }

        private void capsullingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmMontring());
        }

        private void invoiceGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmInvoicePrint());
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmAppSettings());
        }

        private void generateMonthlySubscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmGenerateMnthlySubscriptions());
        }

        private void labelPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmLabelPrint());
        }

        private void monthlySubscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmMnthlySubscriptions());
        }

        private void districtWiseMonthlyIssuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmMnthlyAbt());
        }

        private void billRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmBillRegister());
        }

        private void subsciptionsAbstractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmSubIssueAbt());
        }

        private void executiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmExecutive());
        }

        private void rOEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmROEntry());
        }

        private void capsullingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmMontring());
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmCreateUser());
        }

        private void invoiceGenerationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmInvoiceGeneration());
        }

        private void invoiceGenerationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmInvoiceGeneration());
        }

        private void subscriptionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmSubType());
        }

        private void districtMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void magazinePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmChangePassword());
        }

        private void distributorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmDistributor());
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmReceipt());
        }

        private void billOfSupplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void billOfSupplyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void partyLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmPartyLedger());
        }

        private void bankLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmBankLedger());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmShow(new FrmSubBOS());
        }
    }
}
