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
    public partial class frmSalemenReport : Base.frmBaseCommonReportForm
    {
        public frmSalemenReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.SalemenReport;
            InitSalemenReportGrid();
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

        private void frmSalemenReport_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        protected override void LoadDataByCondition(DateTime beginDate, DateTime endDate)
        {
            Bll.ReportManager um = new Bll.ReportManager();
            var lst = um.GetBudgetReportList(beginDate, endDate);

            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
        }

        private void InitSalemenReportGrid()
        {
            ClearColumns();

            base.CreateGridColumn("合同号", "ContractNO");
            base.CreateGridColumn("客户名称", "CustomerName");
            base.CreateGridColumn("贸易方式", "TradeMode");
            base.CreateGridColumn("审批状态", "EnumFlowState");
            base.CreateGridColumn("合同金额", "TotalAmount");
            base.CreateGridColumn("合同金额(美元)", "USDTotalAmount");
            base.CreateGridColumn("业务员", "SalesmanName");
            base.CreateGridColumn("业务员所在部门", "DepartmentDesc");
            base.CreateGridColumn("录入时间", "CreateDate");
            base.CreateGridColumn("订约日期", "SignDate");
            base.CreateGridColumn("有效截止期", "Validity");
            base.CreateGridColumn("贸易性质", "TradeNature");
            base.CreateGridColumn("目的港口", "Port");
            base.CreateGridColumn("预付金额", "AdvancePayment");
            base.CreateGridColumn("利润", "Profit");
            base.CreateGridColumn("交单金额", "Amount");
            base.CreateGridColumn("直接费用", "DirectCosts");
            base.CreateGridColumn("盈利水平", "ProfitLevel2");
            base.CreatePivotGridField("合同号", "ContractNO");
            base.CreatePivotGridField("客户名称", "CustomerName");
            base.CreatePivotGridField("贸易方式", "TradeMode");
            base.CreatePivotGridField("审批状态", "EnumFlowState");
            base.CreatePivotGridField("合同金额(美元)", "USDTotalAmount");
            base.CreatePivotGridField("合同金额", "TotalAmount");
            base.CreatePivotGridField("业务员", "SalesmanName");
            base.CreatePivotGridField("业务员所在部门", "DepartmentDesc");
            base.CreatePivotGridField("录入时间", "CreateDate", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("订约日期", "SignDate", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("有效截止期", "Validity", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridField("贸易性质", "TradeNature");
            base.CreatePivotGridField("目的港口", "Port");
            base.CreatePivotGridField("预付金额", "AdvancePayment");
            base.CreatePivotGridField("利润", "Profit");
            base.CreatePivotGridField("交单金额", "Amount");
            base.CreatePivotGridField("直接费用", "DirectCosts");
            base.CreatePivotGridField("盈利水平", "ProfitLevel2");
            base.CreatePivotGridField("收款金额", "TotalBudgetBill");
            base.CreatePivotGridField("付款金额", "TotalPayement");
            base.CreatePivotGridField("发票金额", "TotalInvoice");
            base.CreatePivotGridField("报关金额", "TotalDeclarationform");
            base.CreatePivotGridDefaultRowField();
        }
    }
}
