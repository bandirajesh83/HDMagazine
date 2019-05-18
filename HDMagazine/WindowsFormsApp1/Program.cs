using HDMagazine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmLogin());
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), "Hinudharmam Magazine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
