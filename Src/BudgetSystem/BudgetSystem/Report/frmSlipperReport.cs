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
    public partial class frmSlipperReport : Base.frmBaseCommonReportForm
    {
        public frmSlipperReport():base()
        {
            InitializeComponent();
            this.Module = BusinessModules.SlipperReport;
            //这两行代码在Designer中时，修改窗体后容易自动删除
            this.barManager1.Items.Add(this.beiContractNO);
            this.pivotViewBar.LinksPersistInfo.Insert(3, new DevExpress.XtraBars.LinkPersistInfo(this.beiContractNO));
            this.repositoryItemGridLookUpEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rilueContractNO_ButtonClick);
            InitSlipperReportGrid();
        }

        void rilueContractNO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                this.beiContractNO.EditValue = null;
            }
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

            try
            {
                BudgetManager bm = new BudgetManager();
                BudgetQueryCondition condition = new BudgetQueryCondition();
                condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;
                List<Budget> budgetList = bm.GetAllBudget(condition);
                this.repositoryItemGridLookUpEdit1.DataSource = budgetList;
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogError(ex);
            }
        }

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            Bll.ReportManager um = new Bll.ReportManager();
            if ( this.beiContractNO.EditValue != null)
            {
                Budget budget = this.beiContractNO.EditValue as Budget;
                condition.ID = budget!=null?budget.ID:0;                
            }
            var lst = um.GetSupplierReportList(condition);
           
            this.pivotGridControl.DataSource = lst;
            this.gridControl.DataSource = lst;
        }

        private void InitSlipperReportGrid()
        {
            base.CreateGridColumn("供应商名称", "Name");
            base.CreateGridColumn("已付原币金额", "TotalOriginalCoin");
            base.CreateGridColumn("己付人民币金额", "TotalCNY");
            base.CreateGridColumn("汇率", "ExchangeRate");
            base.CreateGridColumn("已收发票金额", "InvoiceTotal");
            base.CreateGridColumn("应付人民币余额", "BalanceDue");

            base.CreatePivotGridField("供应商名称", "Name");
            base.CreatePivotGridField("已付原币金额", "TotalOriginalCoin", valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
            base.CreatePivotGridField("己付人民币金额", "TotalCNY");
            base.CreatePivotGridField("汇率", "ExchangeRate");
            base.CreatePivotGridField("已收发票金额", "InvoiceTotal");
            base.CreatePivotGridField("应付人民币余额", "BalanceDue");
            base.CreatePivotGridDefaultRowField();
        }
    }
}
