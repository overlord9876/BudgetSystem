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
    public partial class frmCompanyReport : frmBudgetReport
    {
        public frmCompanyReport()
            : base()
        {
            this.Name = "frmCompanyReport";
            this.Text = "公司管理";
            this.Module = BusinessModules.CompanyReport;
        }
    }
}
