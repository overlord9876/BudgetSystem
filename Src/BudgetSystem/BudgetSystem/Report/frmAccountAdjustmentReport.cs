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
using BudgetSystem.Bll;

namespace BudgetSystem.Report
{
    /// <summary>
    /// 调账报表共用窗体。
    /// </summary>
    public partial class frmAccountAdjustmentReport : Base.frmBaseCommonReportForm
    {
        private AccountAdjustmentManager aam = new AccountAdjustmentManager();
        //private BudgetManager bm = new BudgetManager();

        public frmAccountAdjustmentReport()
            : base()
        {
            InitializeComponent();

            this.Module = BusinessModules.AccountAdjustmentReport;
            //这两行代码在Designer中时，修改窗体后容易自动删除
            //this.barManager1.Items.Add(this.beiContractNO);
            //this.pivotViewBar.LinksPersistInfo.Insert(3, new DevExpress.XtraBars.LinkPersistInfo(this.beiContractNO));
            //this.repositoryItemGridLookUpEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rilueContractNO_ButtonClick);
        }

        //void rilueContractNO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
        //    {
        //        this.beiContractNO.EditValue = null;
        //    }
        //}

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

        private void frmAccountAdjustmentReport_Load(object sender, EventArgs e)
        {
            this.Text = "调账管理";
            InitCustomerReportGrid();

            InitShowStyle();
            //try
            //{
            //    BudgetQueryCondition condition = new BudgetQueryCondition();
            //    condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;
            //    List<Budget> budgetList = bm.GetAllBudget(condition);
            //    this.repositoryItemGridLookUpEdit1.DataSource = budgetList;
            //}
            //catch (Exception ex)
            //{
            //    RunInfo.Instance.Logger.LogError(ex);
            //}
        }

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            //if (this.beiContractNO.EditValue != null)
            //{
            //    Budget budget = this.beiContractNO.EditValue as Budget;
            //    condition.ID = budget != null ? budget.ID : 0;
            //}
            var lst = aam.GetAccountAdjustmentReportList(condition);
            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
            base.gridView.BestFitColumns();
        }

        private void InitCustomerReportGrid()
        {
            base.ClearColumns();
            base.CreateGridColumn("部门", "DeptCode", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ContractNO", "合计：{0:d}"));
            base.CreateGridColumn("合同编号", "ContractNO", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ContractNO", "合计：{0:d}"));
            base.CreateGridColumn("付款调出(￥）", "PaymentCNYOut", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("付款调入(￥）", "PaymentCNYIn", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("收汇调出(￥）", "BillCNYOut", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("收汇调入(￥）", "BillCNYIn", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("交单调出(￥）", "InvoiceCNYOut", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("交单调入(￥）", "InvoiceCNYIn", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("审批结束时间", "Date");

            base.CreatePivotGridField("部门", "DeptCode");
            base.CreatePivotGridField("合同编号", "ContractNO");
            base.CreatePivotGridField("付款调出(￥）", "PaymentCNYOut", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridField("付款调入(￥）", "PaymentCNYIn", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridField("收汇调出(￥）", "BillCNYOut", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridField("收汇调入(￥）", "BillCNYIn", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridField("交单调出(￥）", "InvoiceCNYOut", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridField("交单调入(￥）", "InvoiceCNYIn", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridField("审批结束时间", "Date", valueFormatType: FormatType.DateTime, valueFormatString: "D");
            base.CreatePivotGridDefaultRowField();
        }
    }
}
