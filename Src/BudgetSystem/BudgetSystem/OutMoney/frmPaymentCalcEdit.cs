using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using System.Linq;

namespace BudgetSystem
{
    public partial class frmPaymentCalcEdit : frmBaseDialogForm
    {
        /// <summary>
        /// 选择的合同
        /// </summary>
        public Budget SelectedBudget
        {
            get;
            set;
        }

        public decimal PaymentMoney { get; set; }

        public decimal ReceiptAmount { get; set; }

        public List<PaymentNotes> PaymentNotes { get; set; }

        public frmPaymentCalcEdit()
        {
            InitializeComponent();
        }

        private void frmPaymentCalcEdit_Load(object sender, EventArgs e)
        {
            this.txtReceiptAmount.EditValue = ReceiptAmount;
            this.txtApplyMoney.EditValue = PaymentNotes.Sum(o => o.Money);

            this.txtTaxPayment.EditValue = PaymentNotes.Where(o => o.IsDrawback).Sum(o => o.Money);
            this.txtTaxRefund.EditValue = this.txtTaxPayment.Value / (decimal)1.17 * txtTaxRebateRate.Value;

            this.txtAccountBalance.EditValue = this.txtReceiptAmount.Value - this.txtApplyMoney.Value;
            this.txtReceiptAmount2.EditValue = ReceiptAmount;
            this.txtBudgetNo.EditValue = SelectedBudget.ContractNO;
            this.txtCustomer.Text = SelectedBudget.CustomerList.ToNameString();
            this.txtSupplier.Text = SelectedBudget.SupplierList.ToNameString();
            this.txtAdvancePayment.EditValue = SelectedBudget.AdvancePayment;
            this.txtApprovalState.EditValue = SelectedBudget.State;
            this.txtFeedMoney.EditValue = SelectedBudget.FeedMoney;
            this.txtTotalAmount.EditValue = SelectedBudget.TotalAmount;
            this.txtPercentage.EditValue = Math.Round(txtAdvancePayment.Value / SelectedBudget.TotalAmount * 100, 2);
            this.txtSuperPaymentScheme.EditValue = (Math.Round(this.txtReceiptAmount2.Value / txtTotalAmount.Value, 2)) * 100 - 100;
            this.txtTaxRebateRate.EditValue = SelectedBudget.TaxRebateRate;
            decimal interest = Math.Round(txtAdvancePayment.Value * (decimal)SelectedBudget.InterestRate * SelectedBudget.Days / 30 / 100, 2);
            decimal subTotal = SelectedBudget.Quota + SelectedBudget.Commission + SelectedBudget.Premium + SelectedBudget.BankCharges +/*直接费用*/0 + SelectedBudget.FeedMoney;

            //  净收入额=外贸合约人民币小计-内贸合约部分的利息-预算小计
            decimal netIncomeCNY = this.txtTotalAmount.Value - SelectedBudget.DirectCosts - interest - subTotal;
            //总收金额（USD）=折合人名币/汇率

            this.txtNetIncome.EditValue = decimal.Round(netIncomeCNY / (decimal)SelectedBudget.ExchangeRate, 2);

            //出口退税额=总进价/1.17*出口退税率
            decimal TaxRebateRateMoney = Math.Round(SelectedBudget.DirectCosts / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100, 2);
            //总成本=总进价-出口退税额
            decimal totalCost = SelectedBudget.DirectCosts - TaxRebateRateMoney;

            //利润=折合人名币（净收入额）-总成本
            txtProfit.EditValue = netIncomeCNY - totalCost;

            //盈利水平=利润/净收入额
            this.txtProfitLevel.EditValue = txtProfit.Value / netIncomeCNY;

            this.txtNetIncome_Plan.EditValue = txtNetIncome.Value;
            this.txtRetainedProfit.EditValue = txtNetIncome_Plan.Value * txtReceiptAmount2.Value / txtTotalAmount.Value;
            this.txtTaxRefund_Total.EditValue = txtTaxRefund.Value;
            this.textEdit_Number2.EditValue = txtTaxRefund.Value;


            //有预付款情况下，窗体显示计税货款小于收款金额测算栏目
            textEdit_Number3.EditValue = txtAccountBalance.Value + textEdit_Number2.Value - textEdit_Number1.Value;
            textEdit_Number4.EditValue = textEdit_Number3.Value + txtAdvancePayment.Value;
        }


    }
}