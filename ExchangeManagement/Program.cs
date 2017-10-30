using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fLogin = new frmLogin();
            fLogin.ShowDialog();
            if (fLogin.UserID > 0)
            {
                frmMain fMain = new frmMain();
                fMain.UserID = fLogin.UserID;
                Application.Run(fMain);
            }
        }
    }
}
