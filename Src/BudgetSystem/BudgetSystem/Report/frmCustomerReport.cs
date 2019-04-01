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
    public partial class frmCustomerReport : Base.frmBaseCommonReportForm
    {
        public frmCustomerReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.CustomerReport;
            InitCustomerReportGrid();
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();
        }

        protected override void InitModelOperate()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;
        }
        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
        }

        private void frmTestReport1_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        protected override void LoadDataByCondition(DateTime beginDate, DateTime endDate)
        {
            Bll.ReportManager um = new Bll.ReportManager();
            var lst = um.GetCustomerReportList(beginDate, endDate);

            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
        }

        private void InitCustomerReportGrid()
        {
            base.CreateGridColumn("客户名称", "Name");
            base.CreateGridColumn("已收原币金额", "OriginalCoin");
            base.CreateGridColumn("人民币", "CNY");
            base.CreateGridColumn("汇率", "ExchangeRate");
            base.CreateGridColumn("报关金额", "DeclarationformTotal");
            base.CreatePivotGridField("客户名称", "Name");
            base.CreatePivotGridField("已收原币金额", "OriginalCoin", valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
            base.CreatePivotGridField("人民币", "CNY");
            base.CreatePivotGridField("汇率", "ExchangeRate", valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
            base.CreatePivotGridField("报关金额", "DeclarationformTotal", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridDefaultRowField();
        }
    }
}
