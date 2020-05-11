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
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Report
{
    public partial class frmBudgetReport : Base.frmBaseCommonReportForm
    {
        public frmBudgetReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.BudgetReport;
            InitBudgetReportGrid();
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

        private void frmBudgetReport_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            Bll.ReportManager um = new Bll.ReportManager();

            var lst = um.GetBudgetReportList(condition);

            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
        }

        private void InitBudgetReportGrid()
        {
            base.CreateGridColumn("合同号", "ContractNO");
            base.CreateGridColumn("合同金额（美元$）", "USDTotalAmount");
            base.CreateGridColumn("报关金额（美元$）", "TotalDeclarationform");
            base.CreateGridColumn("收汇金额（美元$）", "TotalUSDBudgetBill");
            base.CreateGridColumn("实际收汇金额（人民币￥）", "TotalBudgetBill");
            base.CreateGridColumn("销售金额（人民币￥）", "TotalInvoice");
            base.CreateGridColumn("付款金额（人民币￥）", "TotalPayement");
            base.CreateGridColumn("供方发票（人民币￥）", "SupplierInvoice");
            base.CreateGridColumn("销售成本（人民币￥）", "SellingCost");
            base.CreateGridColumn("运杂费（人民币￥）", "Premium");
            base.CreateGridColumn("运杂费成本（人民币￥）", "PremiumCost");
            base.CreateGridColumn("佣金（￥）", "Commission");
            base.CreateGridColumn("直接费用（￥）", "DirectCosts");
            base.CreateGridColumn("销售利润（￥）", "SalesProfit");
            base.CreateGridColumn("实际利润（￥）", "ActualProfit");

            base.CreateGridColumn("合同金额", "TotalAmount");
            base.CreateGridColumn("业务员", "SalesmanName");
            base.CreateGridColumn("业务员所在部门", "DepartmentDesc");
            base.CreateGridColumn("录入时间", "CreateDate");
            base.CreateGridColumn("订约日期", "SignDate");
            base.CreateGridColumn("有效截止期", "Validity");
            base.CreateGridColumn("预付金额", "AdvancePayment");
            base.CreateGridColumn("利润", "Profit");
            base.CreateGridColumn("盈利水平", "ProfitLevel2");

            base.CreatePivotGridField("合同号", "ContractNO");
            base.CreatePivotGridField("合同金额（美元$）", "USDTotalAmount", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("报关金额（美元$）", "TotalDeclarationform", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("收汇金额（美元$）", "TotalUSDBudgetBill", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("实际收汇金额（人民币￥）", "TotalBudgetBill");
            base.CreatePivotGridField("销售金额（人民币￥）", "TotalInvoice");
            base.CreatePivotGridField("付款金额（人民币￥）", "TotalPayement");
            base.CreatePivotGridField("供方发票（人民币￥）", "SupplierInvoice");
            base.CreatePivotGridField("销售成本（人民币￥）", "SellingCost");
            base.CreatePivotGridField("运杂费（人民币￥）", "Premium");
            base.CreatePivotGridField("运杂费成本（人民币￥）", "Premium");
            base.CreatePivotGridField("佣金（￥）", "Commission");
            base.CreatePivotGridField("直接费用（￥）", "DirectCosts");
            base.CreatePivotGridField("销售利润（￥）", "SalesProfit");
            base.CreatePivotGridField("实际利润（￥）", "ActualProfit");

            base.CreatePivotGridField("合同金额", "TotalAmount");
            base.CreatePivotGridField("业务员", "SalesmanName");
            base.CreatePivotGridField("业务员所在部门", "DepartmentDesc");
            base.CreatePivotGridField("录入时间", "CreateDate", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("订约日期", "SignDate", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("有效截止期", "Validity", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("预付金额", "AdvancePayment");
            base.CreatePivotGridField("利润", "Profit");
            base.CreatePivotGridField("盈利水平", "ProfitLevel2");
            base.CreatePivotGridDefaultRowField();
        }

    }
}
