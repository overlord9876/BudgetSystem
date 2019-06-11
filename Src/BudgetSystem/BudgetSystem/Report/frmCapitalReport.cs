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
using System.IO;

namespace BudgetSystem.Report
{
    public partial class frmCapitalReport : Base.frmBaseCommonReportForm
    {
        public frmCapitalReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.RecieptCapital;
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

        const string DepartmentCaption = "部门";
        private Dictionary<string, string> dic = new Dictionary<string, string>();

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            Bll.ReportManager um = new Bll.ReportManager();

            base.ClearColumns();

            var lst = um.GetRecieptCapital();

            var usdLst = lst.FindAll(o => o.Currency.ToUpper().Equals("USD"));
            decimal exchangeRate = 0;
            if (usdLst.Count > 0)
            {
                decimal allExchangeRate = 0;
                usdLst.ForEach(o => { allExchangeRate += (decimal)o.ExchangeRate; });
                exchangeRate = allExchangeRate / usdLst.Count;
            }

            DataTable dt = new DataTable();
            if (!dic.ContainsKey(DepartmentCaption))
            {
                dic.Add(DepartmentCaption, "departmentCode");
            }
            dt.Columns.Add(dic[DepartmentCaption], typeof(string));

            base.CreateGridColumn(DepartmentCaption, dic[DepartmentCaption]);
            base.CreatePivotGridField(DepartmentCaption, dic[DepartmentCaption]);
            for (int index = 0; index < lst.Count; index++)
            {
                RecieptCapital rc = lst[index];

                rc.OriginalCoin = Math.Round(rc.CNY / exchangeRate, 2);
                if (!dic.ContainsKey(rc.BankCode))
                {
                    dic.Add(rc.BankCode, string.Format("code{0}", index));
                }

                if (!dt.Columns.Contains(dic[rc.BankCode]))
                {
                    base.CreateGridColumn(rc.BankCode, dic[rc.BankCode]);
                    base.CreatePivotGridField(rc.BankCode, dic[rc.BankCode], valueFormatType: FormatType.Custom, formatProvider: new MyDollarFormat());
                    dt.Columns.Add(dic[rc.BankCode], typeof(decimal));
                }
            }

            base.CreatePivotGridDefaultRowField();

            foreach (RecieptCapital rc in lst)
            {
                DataRow[] rows = dt.Select(string.Format("{0}='{1}'", dic[DepartmentCaption], rc.Department));
                if (rows != null && rows.Length > 0)
                {
                    decimal money = 0;
                    if (!(rows[0][dic[rc.BankCode]] is System.DBNull))
                    {
                        money = (decimal)rows[0][dic[rc.BankCode]];
                    }
                    rows[0][dic[rc.BankCode]] = money + rc.OriginalCoin;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow[dic[DepartmentCaption]] = rc.Department;
                    newRow[dic[rc.BankCode]] = rc.OriginalCoin;
                    dt.Rows.Add(newRow);
                }
            }
            string defaultFileName = base.GetDefaultLayoutXmlFile();
            if (File.Exists(defaultFileName))
            {
                this.pivotGridControl.RestoreLayoutFromXml(defaultFileName);
            }

            this.pivotGridControl.DataSource = dt;
            this.gridControl.DataSource = dt;
        }

        private void InitBudgetReportGrid()
        {
            base.ClearColumns();
            base.CreateGridColumn("合同号", "ContractNO");
            base.CreateGridColumn("合同金额（美元$）", "USDTotalAmount");
            base.CreateGridColumn("报关金额（美元$）", "TotalDeclarationform");
            base.CreateGridColumn("收汇金额（美元$）", "TotalUSDBudgetBill");
            base.CreateGridColumn("实际收汇金额（人民币￥）", "TotalBudgetBill");
            base.CreateGridColumn("销售金额（人民币￥）", "TotalInvoice");
            base.CreateGridColumn("付款金额（人民币￥）", "TotalPayement");
            base.CreateGridColumn("供方发票（人民币￥）", "SupplierInvoice");
            base.CreateGridColumn("销售成本（人民币￥）", "SellingCost");
            base.CreateGridColumn("运保费（人民币￥）", "Premium");
            base.CreateGridColumn("运保费成本（人民币￥）", "PremiumCost");
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
            base.CreatePivotGridField("运保费（人民币￥）", "Premium");
            base.CreatePivotGridField("运保费成本（人民币￥）", "Premium");
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
