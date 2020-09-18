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

            base.gridView.BestFitColumns();
        }

        private void InitBudgetReportGrid()
        {
            base.CreateGridColumn("合同号", "ContractNO", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ContractNO", "合计：{0:d}"));
            base.CreateGridColumn("合同金额（$）", "USDTotalAmount", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("报关金额（$）", "TotalDeclarationform", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("收汇金额（$）", "TotalUSDBudgetBill", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("实际收汇金额（￥）", "TotalBudgetBill", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("销售金额（￥）", "TotalInvoice", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("销售成本(交￥）", "InvoiceSellingCost", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("付款金额（￥）", "TotalPayement", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("付款不含税成本（￥）", "SellingCost", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("进料款(交￥)", "IFeedMoney", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("进料款(付￥)", "PFeedMoney", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("佣金(交￥)", "ICommission", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("佣金(付￥)", "PCommission", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("运杂费（￥）", "Premium", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("运杂费成本（￥）", "PremiumCost", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("直接费用（￥）", "DirectCosts", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("未交单直接费用（￥）", "UnInvoiceDirectCosts", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("销售毛利润（￥）", "GrossProfit", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("销售利润（￥）", "SalesProfit", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("实际利润（￥）", "ActualProfit", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("汇兑损益（￥）", "ExchangeGains", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("调整后销售利润（￥）", "AdjustedSalesProfit", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("暂收款（￥）", "ProvisionalReceipt", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("暂付款（￥）", "ProvisionalPayment", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("暂收付款差额（￥）", "ProvisionalImbalance", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("业务员", "SalesmanName");

            base.CreateGridColumn("合同金额", "TotalAmount", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("业务员所在部门", "DepartmentDesc");
            base.CreateGridColumn("录入时间", "CreateDate");
            base.CreateGridColumn("订约日期", "SignDate");
            base.CreateGridColumn("有效截止期", "Validity");
            base.CreateGridColumn("预付金额", "AdvancePayment", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("利润", "Profit", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("盈利水平", "ProfitLevel2");

            base.CreatePivotGridField("合同号", "ContractNO");
            base.CreatePivotGridField("合同金额（$）", "USDTotalAmount", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("报关金额（$）", "TotalDeclarationform", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("收汇金额（$）", "TotalUSDBudgetBill", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("实际收汇金额（￥）", "TotalBudgetBill");
            base.CreatePivotGridField("销售金额（￥）", "TotalInvoice");
            base.CreatePivotGridField("销售成本(交￥）", "InvoiceSellingCost");
            base.CreatePivotGridField("付款金额（￥）", "TotalPayement");
            base.CreatePivotGridField("付款不含税成本（￥）", "SellingCost");
            base.CreatePivotGridField("进料款(交￥)", "IFeedMoney");
            base.CreatePivotGridField("进料款(付￥)", "PFeedMoney");
            base.CreatePivotGridField("佣金(交￥)", "ICommission");
            base.CreatePivotGridField("佣金(付￥)", "PCommission");
            base.CreatePivotGridField("运杂费（￥）", "Premium");
            base.CreatePivotGridField("运杂费成本（￥）", "Premium");

            base.CreatePivotGridField("直接费用（￥）", "DirectCosts");
            base.CreatePivotGridField("未交单直接费用（￥）", "UnInvoiceDirectCosts");
            base.CreatePivotGridField("销售毛利润（￥）", "GrossProfit");
            base.CreatePivotGridField("销售利润（￥）", "SalesProfit");
            base.CreatePivotGridField("实际利润（￥）", "ActualProfit");
            base.CreatePivotGridField("汇兑损益（￥）", "ExchangeGains");
            base.CreatePivotGridField("调整后销售利润（￥）", "AdjustedSalesProfit");
            base.CreatePivotGridField("暂收款（￥）", "ProvisionalReceipt");
            base.CreatePivotGridField("暂付款（￥）", "ProvisionalPayment");
            base.CreatePivotGridField("暂收付款差额（￥）", "ProvisionalImbalance");
            base.CreatePivotGridField("业务员", "SalesmanName");

            base.CreatePivotGridField("合同金额", "TotalAmount");
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
