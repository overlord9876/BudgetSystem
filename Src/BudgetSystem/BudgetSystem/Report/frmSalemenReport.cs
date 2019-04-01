using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BudgetSystem.Entity;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;

namespace BudgetSystem.Report
{
    public partial class frmSalemenReport : frmBudgetReport
    {
        public frmSalemenReport()
            : base()
        {
            this.Name = "frmSalemenReport";
            this.Text = "业务员管理";
            this.Module = BusinessModules.SalemenReport;
        }
    }
}
