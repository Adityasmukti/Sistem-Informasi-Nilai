using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS
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

            A.SetKoneksiString(Properties.Settings.Default.mysqlhost,
            Properties.Settings.Default.mysqluser,
            Properties.Settings.Default.mysqlpassword,
            Properties.Settings.Default.mysqldatabase,
            Properties.Settings.Default.mysqlport);

            if (A.CekstatusMysql())
                Application.Run(new Auth.FLogin());
            else
                Application.Run(new Settings.FSettingDb());
        }
    }
}
