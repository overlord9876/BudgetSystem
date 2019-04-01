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
    public partial class frmDepartmentReport : frmBudgetReport
    {
        public frmDepartmentReport()
            : base()
        {
            this.Name = "frmDepartmentReport";
            this.Text = "部门管理";
            this.Module = BusinessModules.DepartmentReport;
        }

    }
}
