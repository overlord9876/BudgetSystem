using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Resources;
using System.Reflection;
using System.IO;
using DevExpress.XtraPrinting;

namespace BudgetSystem
{
    public partial class frmBaseForm : DevExpress.XtraEditors.XtraForm
    {
        public frmBaseForm()
        {
            InitializeComponent();
        }


        public virtual void LoadData()
        {

        }

        public static bool IsDesignMode
        {
            get
            {
#if DEBUG
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                    return true;

                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV"))
                    return true;
#endif
                return false;
            }
        }

    }
}