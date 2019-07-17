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

            A.SetHost(Properties.Settings.Default.mysqlhost);
            A.SetUid(Properties.Settings.Default.mysqluser);
            A.SetPwd(Properties.Settings.Default.mysqlpassword);
            A.SetDb(Properties.Settings.Default.mysqldatabase);
            A.SetPort(Properties.Settings.Default.mysqlport);

            ModulData DM = new ModulData();
            if (DM.Cekstatus())
                Application.Run(new Auth.FLogin());
            else
                Application.Run(new Settings.FSettingDb());
        }
    }
}
