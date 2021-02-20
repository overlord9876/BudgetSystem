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
    public partial class frmDeclarationformReport : Base.frmBaseCommonReportForm
    {
        private DeclarationformManager dfm = new DeclarationformManager();
        //private BudgetManager bm = new BudgetManager();

        public frmDeclarationformReport()
            : base()
        {
            InitializeComponent();

            this.Module = BusinessModules.DeclarationformReport;
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
            this.Text = "报关单管理";
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
            VoucherNotesQueryCondition queryCondition = new VoucherNotesQueryCondition();
            queryCondition.ExportBeginDate = condition.BeginTimestamp;
            queryCondition.ExportEndDate = condition.EndTimestamp;
            queryCondition = RunInfo.Instance.GetConditionByCurrentUser(queryCondition) as VoucherNotesQueryCondition;
            var lst = dfm.GetAllDeclarationform(queryCondition);
            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
            base.gridView.BestFitColumns();
        }

        private void InitCustomerReportGrid()
        {
            base.ClearColumns();
            base.CreateGridColumn("部门", "DepartmentDesc", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DepartmentDesc", "合计：{0:d}"));
            base.CreateGridColumn("业务员", "Salesman", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Salesman", "合计：{0:d}"));
            base.CreateGridColumn("合同编号", "ContractNO", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ContractNO", "合计：{0:d}"));
            base.CreateGridColumn("总价", "TotalPrice", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("离岸价", "OffshoreTotalPrice", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("美元离岸价($）", "USDOffshoreTotalPrice", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));
            base.CreateGridColumn("人民币离岸价(￥）", "CNYOffshoreTotalPrice", summaryItem: new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum));

            base.CreatePivotGridField("部门", "DepartmentDesc");
            base.CreatePivotGridField("业务员", "Salesman");
            base.CreatePivotGridField("合同编号", "ContractNO");
            base.CreatePivotGridField("总价", "TotalPrice", valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
            base.CreatePivotGridField("离岸价", "OffshoreTotalPrice", valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
            base.CreatePivotGridField("美元离岸价($）", "USDOffshoreTotalPrice", valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
            base.CreatePivotGridField("人民币离岸价(￥）", "CNYOffshoreTotalPrice", valueFormatType: FormatType.Custom, formatProvider: new MyCNYFormat());
            base.CreatePivotGridDefaultRowField();
        }
    }
}
