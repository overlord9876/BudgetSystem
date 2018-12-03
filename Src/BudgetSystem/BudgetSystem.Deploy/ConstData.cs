using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem.Deploy
{
    public class ConstData
    {

        public static string BudgetSystemExecuteFileName
        {
            get
            {
                return System.IO.Path.Combine(BudgetSystemRootPath, @"BudgetSystem.exe");
            }
        }

        public static string BudgetSystemRootPath
        {
            get
            {
                string str= System.IO.Path.Combine(Application.StartupPath, @"Bin");

                if (!System.IO.Directory.Exists(str))
                {
                    System.IO.Directory.CreateDirectory(str);
                }

                return str;
            }
        }

    }
}
