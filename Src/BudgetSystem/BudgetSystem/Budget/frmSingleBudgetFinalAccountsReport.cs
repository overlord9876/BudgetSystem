using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using DevExpress.XtraGrid;

namespace BudgetSystem
{
    public partial class frmSingleBudgetFinalAccountsReport : frmBaseQueryForm
    {
        private SingleBudgetReportHelper reportHelper;
        public Budget CurrentBudget { get; set; }
        public frmSingleBudgetFinalAccountsReport()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSingleBudgetFinalAccountsReport_Load);
            this.advBandedGridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(bgvReport_CustomDrawCell);
            this.advBandedGridView.RowCellStyle += AdvBandedGridView_RowCellStyle;
            reportHelper = new SingleBudgetReportHelper();
        }

        void frmSingleBudgetFinalAccountsReport_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void bgvReport_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gcIndex)
            {
                //序号列
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void AdvBandedGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRowView row = advBandedGridView.GetRow(e.RowHandle) as DataRowView;
            if (row != null)
            {
                int adjustmentType = GetInt(row.Row, "AdjustmentType");
                if (adjustmentType == 0)
                {

                }
                else if (adjustmentType == ((int)AdjustmentType.付款 + 1) || adjustmentType == ((int)AdjustmentType.收款 + 1) || adjustmentType == ((int)AdjustmentType.交单 + 1))
                {
                    e.Appearance.ForeColor = Color.Red;//改变字体颜色
                }
                else
                {
                    e.Appearance.ForeColor = Color.Blue;//改变字体颜色
                }
            }
        }

        public override void LoadData()
        {
            if (this.CurrentBudget == null)
            {
                return;
            }
            Budget budget = new BudgetManager().GetBudget(this.CurrentBudget.ID);
            if (budget != null)
            {
                this.txtContractNO.Text = budget.ContractNO;
                this.txtDepartmentName.Text = budget.DepartmentName;
                this.txtSalesmanName.Text = budget.SalesmanName;
                this.txtTotalAmount.EditValue = budget.TotalAmount;
                this.txtTotalCost.EditValue = budget.TotalCost;
                this.txtProfit.EditValue = budget.Profit;
                this.txtAdvancePayment.EditValue = budget.AdvancePayment;
                //报关单表
                gridBand29.Caption = budget.Premium.ToString();// 预算运杂费
                gridBand32.Caption = budget.Commission.ToString();// 预算佣金
                reportHelper.LoadData(budget);
                gbReceivableOriginalCoin.Caption = reportHelper.ReceivableOriginalCoin.ToString();//应收原币
                gbReceivableCNY.Caption = reportHelper.ReceivableCNY.ToString();//应收人民币
                gbBalancePayable.Caption = reportHelper.BalancePayable.ToString(); //应付余额=已收供方发票-已付供方货款
                gbProfitMargin.Caption = reportHelper.ProfitMargin.ToString();//"利润差值"实际利润-销售利润(Profit-SalesProfit)

                this.gcReport.DataSource = reportHelper.DataTable;
            }
        }

        private decimal GetDecimal(DataRow row, string column, decimal defaultValue = 0)
        {
            if (row.IsNull(column))
            {
                return defaultValue;
            }
            else
            {
                return (decimal)row[column];
            }
        }

        private int GetInt(DataRow row, string column, int defaultValue = 0)
        {
            if (row.IsNull(column))
            {
                return defaultValue;
            }
            else
            {
                return (int)row[column];
            }
        }

        private void advBandedGridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridSummaryItem gridSummaryItem = e.Item as GridSummaryItem;
            if (gridSummaryItem != null && "Balance".Equals(gridSummaryItem.FieldName) && e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                DataTable dt = this.gcReport.DataSource as DataTable;
                decimal balance = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    int dtCount = dt.Rows.Count;
                    balance = GetDecimal(dt.Rows[dtCount - 1], "Balance", 0);
                }
                e.TotalValue = balance;
            }
        }

    }
}