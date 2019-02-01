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
        private OperateTypes currentReprot = OperateTypes.BudgetReport;

        public frmBudgetReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.BudgetReport;
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();

            InitBudgetReportGrid();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.BudgetReport, "合同报表"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.CustomerReport, "客户报表"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SlipperReport, "供应商报表"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SalemenReport, "业务员报表"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.DepartmentReport, "部门报表"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.CompanyReport, "公司报表"));
        }

        protected override void InitModelOperate()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;
        }
        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);

            if (operate.Operate == OperateTypes.BudgetReport.ToString())
            {
                currentReprot = OperateTypes.BudgetReport;
                InitBudgetReportGrid();
            }
            else if (operate.Operate == OperateTypes.CustomerReport.ToString())
            {
                currentReprot = OperateTypes.CustomerReport;
                ClearColumns();
                base.CreateGridColumn("客户名称", "Name");
                base.CreateGridColumn("已收原币金额", "OriginalCoin");
                base.CreateGridColumn("人民币", "CNY");
                base.CreateGridColumn("汇率", "ExchangeRate");
                base.CreateGridColumn("报关金额", "DeclarationformTotal");
                base.CreatePivotGridField("客户名称", "Name");
                base.CreatePivotGridField("已收原币金额", "OriginalCoin");
                base.CreatePivotGridField("人民币", "CNY");
                base.CreatePivotGridField("汇率", "ExchangeRate");
                base.CreatePivotGridField("报关金额", "DeclarationformTotal");
                base.CreatePivotGridDefaultRowField();
            }
            else if (operate.Operate == OperateTypes.SlipperReport.ToString())
            {
                currentReprot = OperateTypes.SlipperReport;
                ClearColumns();
                base.CreateGridColumn("供应商名称", "Name");
                base.CreateGridColumn("已付原币金额", "OriginalCoin");
                base.CreateGridColumn("人民币", "TotalCNY");
                base.CreateGridColumn("汇率", "ExchangeRate");
                base.CreateGridColumn("已收发票金额", "InvoiceTotal");
                base.CreatePivotGridField("供应商名称", "Name");
                base.CreatePivotGridField("已付原币金额", "OriginalCoin");
                base.CreatePivotGridField("人民币", "TotalCNY");
                base.CreatePivotGridField("汇率", "ExchangeRate");
                base.CreatePivotGridField("已收发票金额", "InvoiceTotal");
                base.CreatePivotGridDefaultRowField();
            }
            else if (operate.Operate == OperateTypes.SalemenReport.ToString())
            {
                currentReprot = OperateTypes.SalemenReport;
                InitBudgetReportGrid();
            }
            else if (operate.Operate == OperateTypes.DepartmentReport.ToString())
            {
                currentReprot = OperateTypes.DepartmentReport;
                InitBudgetReportGrid();
            }
            else if (operate.Operate == OperateTypes.CompanyReport.ToString())
            {
                currentReprot = OperateTypes.CompanyReport;
                InitBudgetReportGrid();
            }
            LoadData();
        }

        private void frmTestReport1_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        public override void LoadData()
        {
            if (currentReprot == OperateTypes.BudgetReport)
            {
                BudgetReport();
            }
            else if (currentReprot == OperateTypes.CustomerReport)
            {
                CustomerReport();
            }
            else if (currentReprot == OperateTypes.SlipperReport)
            {
                SupplierReport();
            }
            else
            {
                BudgetReport();
            }
        }

        private void BudgetReport()
        {
            Bll.ReportManager um = new Bll.ReportManager();
            var lst = um.GetBudgetReportList(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));

            this.pivotGridControl.DataSource = lst;
        }

        private void SupplierReport()
        {
            Bll.ReportManager um = new Bll.ReportManager();
            var lst = um.GetSupplierReportList(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));

            this.pivotGridControl.DataSource = lst;
        }

        private void CustomerReport()
        {
            Bll.ReportManager um = new Bll.ReportManager();
            var lst = um.GetCustomerReportList(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));

            this.pivotGridControl.DataSource = lst;
        }

        private void InitBudgetReportGrid()
        {
            ClearColumns();
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
            base.CreatePivotGridField("收款金额", "TotalBudgetBill");
            base.CreatePivotGridField("付款金额", "TotalPayement");
            base.CreatePivotGridField("发票金额", "TotalInvoice");
            base.CreatePivotGridField("报关金额", "TotalDeclarationform");
            base.CreatePivotGridDefaultRowField();
        }
    }
}
