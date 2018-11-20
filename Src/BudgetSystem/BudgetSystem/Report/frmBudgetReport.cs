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
    public partial class frmBudgetReport : Base.frmBaseCommonReportForm
    {
        public frmBudgetReport()
        {
            InitializeComponent();
        }

        protected override void InitData()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;
        }


        private void frmTestReport1_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        public override void LoadData()
        {
            Bll.BudgetManager um = new Bll.BudgetManager();
            var lst = um.GetAllBudget();
            base.CreateGridColumn("合同号", "ContractNO");
            base.CreateGridColumn("客户名称", "CustomerName");
            base.CreateGridColumn("贸易方式", "TradeMode");
            base.CreateGridColumn("审批状态", "EnumFlowState");
            base.CreateGridColumn("合同金额", "TotalAmount");
            base.CreateGridColumn("业务员", "SalesmanName");
            base.CreateGridColumn("业务员所在部门", "DepartmentDesc");
            base.CreateGridColumn("录入时间", "CreateDate");
            base.CreateGridColumn("订约日期", "SignDate");
            base.CreateGridColumn("有效截止期", "Validity");
            base.CreateGridColumn("贸易性质", "TradeNature");
            base.CreateGridColumn("目的港口", "Port");
            base.CreateGridColumn("预付金额", "AdvancePayment");
            base.CreateGridColumn("利润", "Profit");
            base.CreateGridColumn("盈利水平1", "ProfitLevel1");
            base.CreateGridColumn("盈利水平2", "ProfitLevel2");
            base.gridControl.DataSource = lst; 
            base.CreatePivotGridField("合同号", "ContractNO");
            base.CreatePivotGridField("客户名称", "CustomerName");
            base.CreatePivotGridField("贸易方式", "TradeMode");
            base.CreatePivotGridField("审批状态", "EnumFlowState");
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
            base.CreatePivotGridField("盈利水平1", "ProfitLevel1");
            base.CreatePivotGridField("盈利水平2", "ProfitLevel2");
            base.CreatePivotGridDefaultRowField();

            this.pivotGridControl.DataSource = lst;
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();
        }
    }
}
