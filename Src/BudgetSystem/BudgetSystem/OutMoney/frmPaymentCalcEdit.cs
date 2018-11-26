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

namespace BudgetSystem.OutMoney
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

        public IEnumerable<PaymentNotes> PaymentNotes { get; set; }

        public frmPaymentCalcEdit()
        {
            InitializeComponent();
        }

        private void frmPaymentCalcEdit_Load(object sender, EventArgs e)
        {
            this.txtApplyMoney.EditValue = PaymentNotes.Sum(o => o.CNY);
            this.txtReceiptAmount.EditValue = ReceiptAmount;
            //this.txtTaxRebateRate.EditValue = SelectedBudget.TaxRebateRate;


            //包含预付款
            if (SelectedBudget.HasAdvancePayment)
            {
                this.CustomWorkModel = "HasAdvancePayment";
                this.txtTaxPayment.EditValue = PaymentNotes.Where(o => o.IsDrawback).Sum(o => o.CNY);
                this.txtTaxRefund.EditValue = Math.Round(this.txtTaxPayment.Value / (decimal)1.17 * txtTaxRebateRate.Value / 100, 2);
            }
            else//没有预付款
            {
                this.CustomWorkModel = "NotHasAdvancePayment";

                txtTaxPaymentA.EditValue = txtApplyMoney.Value;
                txtTaxRefundA.EditValue = txtTaxPaymentA.Value / (decimal)1.17 * this.txtTaxRebateRate.Value / 100;
            }

            SetLayoutControlStyle(EditFormWorkModels.Custom);

            this.txtCommitDate.EditValue = SelectedBudget.CreateDate;
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
            decimal interest = Math.Round(txtAdvancePayment.Value * (decimal)SelectedBudget.InterestRate * SelectedBudget.Days / 30 / 100, 2);
            decimal subTotal = SelectedBudget.Commission + SelectedBudget.Premium + SelectedBudget.BankCharges +/*直接费用*/0 + SelectedBudget.FeedMoney;

            //  净收入额=外贸合约人民币小计-内贸合约部分的利息-预算小计
            decimal netIncomeCNY = this.txtTotalAmount.Value - SelectedBudget.PurchasePrice - interest - subTotal;
            //总收金额（USD）=折合人名币/汇率

            this.txtNetIncome.EditValue = decimal.Round(netIncomeCNY / (decimal)SelectedBudget.ExchangeRate, 2);

            //出口退税额=总进价/1.17*出口退税率
            //decimal TaxRebateRateMoney = Math.Round(SelectedBudget.DirectCosts / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100, 2);
            //总成本=总进价-出口退税额
            decimal totalCost = SelectedBudget.PurchasePrice - (decimal)SelectedBudget.TaxRebate;

            //利润=折合人名币（净收入额）-总成本
            txtProfit.EditValue = netIncomeCNY - totalCost;

            //盈利水平=利润/净收入额
            this.txtProfitLevel.EditValue = txtProfit.Value / netIncomeCNY;

            this.txtNetIncome_Plan.EditValue = txtNetIncome.Value;
            this.txtRetainedProfit.EditValue = txtNetIncome_Plan.Value * txtReceiptAmount2.Value / txtTotalAmount.Value;

            this.textEdit_Number2.EditValue = txtTaxRefund.Value;

            this.textEdit_Number1.EditValue = PaymentMoney;
            this.textEdit_Number20.EditValue = PaymentMoney;
            this.textEdit_Number24.EditValue = PaymentMoney;

            //无预付款情况下，
            //textEdit_Number21.EditValue = textEdit_Number20.Value / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100;
            //this.txtTaxRefund_Total.EditValue = txtTaxRefund.Value;
            this.txtTaxRefund_Total.EditValue = this.txtTaxRefundA.Value + this.txtTaxRefund.Value;
            textEdit_Number23.EditValue = txtAccountBalance.Value + txtTaxRefund_Total.Value - textEdit_Number20.Value;

            //有预付款情况下，窗体显示计税货款大于收款金额测算栏目（如果计税货款大于收款金额，则付款动用了预付款，则只能称为暂计退税款）

            if (txtTaxPayment.Value > txtReceiptAmount.Value)
            {
                // textEdit_Number28.EditValue = txtAccountBalance.Value / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100;
            }
            this.textEdit_Number29.EditValue = this.txtAccountBalance.Value + this.textEdit_Number28.Value - this.textEdit_Number24.Value;
            this.textEdit_Number30.EditValue = this.textEdit_Number29.Value + this.txtAdvancePayment.Value;


            //有预付款情况下，窗体显示计税货款小于收款金额测算栏目
            textEdit_Number3.EditValue = txtAccountBalance.Value + textEdit_Number2.Value - textEdit_Number1.Value;
            textEdit_Number4.EditValue = textEdit_Number3.Value + txtAdvancePayment.Value;

            this.textEdit_Number27.EditValue = this.textEdit_Number3.Value - this.txtRetainedProfit.Value;

        }

        private void CalcThree()
        {

        }

        private void SetReadOnly()
        {
            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
        }

        private void textEdit_Number23_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit_Number23.Value <= 0)
            {
                dxErrorProvider1.SetError(textEdit_Number23, "支付余额不允许小于0。");
            }
        }

        private void textEdit_Number30_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit_Number30.Value <= 0)
            {
                dxErrorProvider1.SetError(textEdit_Number30, "支付余额不允许小于0。");
            }
        }

        private void textEdit_Number4_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit_Number4.Value <= 0)
            {
                dxErrorProvider1.SetError(textEdit_Number4, "支付余额不允许小于0。");
            }
        }

        private void textEdit_Number20_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_Number24_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_Number1_EditValueChanged(object sender, EventArgs e)
        {

        }



    }
}