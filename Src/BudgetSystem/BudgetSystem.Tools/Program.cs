using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace BudgetSystem.Tools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            Bll.BaseManager.SetConnectionString(connectionString, false);
            
            
            Application.Run(new frmTools());
        }
    }
}
