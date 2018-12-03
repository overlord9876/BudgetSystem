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

        public OutMoneyCaculator Caculator { get; set; }

        public frmPaymentCalcEdit()
        {
            InitializeComponent();
        }

        private void frmPaymentCalcEdit_Load(object sender, EventArgs e)
        {
            //所有付款金额
            this.txtApplyMoney.EditValue = Caculator.PaymentMoneyAmount;
            //所有收款金额
            this.txtReceiptAmount.EditValue = Caculator.ReceiptMoneyAmount;
            //已收汇人民币
            this.txtReceiptAmount2.EditValue = Caculator.ReceiptMoneyAmount;
            //合同计划款
            this.txtTotalAmount.EditValue = Caculator.TotalAmount;

            InitTaxRebateRateList();

            //包含预付款
            if (Caculator.AdvancePayment > 0)
            {
                this.CustomWorkModel = "HasAdvancePayment";
                foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcg_NotHasAdvancePayment.Items)
                {
                    item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                lcg_NotHasAdvancePayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            }
            else//没有预付款
            {
                this.CustomWorkModel = "NotHasAdvancePayment";
                foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcg_HasAdvancePayment.Items)
                {
                    item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                lcg_HasAdvancePayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if (Caculator.IsReceiptGreaterThanTaxPayment(0))
            {
                this.lcg_HasAdvancePayment.Text = "有预付款情况下计算栏(所有可退税货款（辅料款）< 收款时)";
                this.txtTaxPayment.EditValue = Caculator.TaxPayment;
                this.txtTaxRefund.EditValue = Caculator.TaxRefund;
            }
            else
            {
                this.lcg_HasAdvancePayment.Text = "有预付款情况下计算栏(所有可退税货款（辅料款）> 收款时)";
                txtTaxPaymentA.EditValue = Caculator.TaxPayment;
                decimal taxRebateRate = 0;
                if (txtTaxRebateRate.EditValue != null)
                {
                    decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
                }

                txtTaxRefundA.EditValue = txtTaxPaymentA.Value / (1 + Caculator.ValueAddedTaxRate) * taxRebateRate;
            }

            //SetLayoutControlStyle(EditFormWorkModels.Custom);

            this.txtCommitDate.EditValue = Caculator.CurrentBudget.CreateDate;
            this.txtBudgetNo.EditValue = Caculator.CurrentBudget.ContractNO;
            this.txtCustomer.Text = Caculator.CurrentBudget.CustomerList.ToNameString();
            this.txtSupplier.Text = Caculator.CurrentBudget.SupplierList.ToNameString();
            this.txtAdvancePayment.EditValue = Caculator.CurrentBudget.AdvancePayment;
            this.txtApprovalState.EditValue = Caculator.CurrentBudget.State;
            this.txtFeedMoney.EditValue = Caculator.CurrentBudget.FeedMoney + Caculator.CurrentBudget.Commission + Caculator.CurrentBudget.Premium;

            decimal interest = Math.Round(txtAdvancePayment.Value * (decimal)Caculator.CurrentBudget.InterestRate * Caculator.CurrentBudget.Days / 30 / 100, 2);
            decimal subTotal = Caculator.CurrentBudget.Commission + Caculator.CurrentBudget.Premium + Caculator.CurrentBudget.BankCharges +/*直接费用*/0 + Caculator.CurrentBudget.FeedMoney;

            //  净收入额=外贸合约人民币小计-内贸合约部分的利息-预算小计
            decimal netIncomeCNY = this.txtTotalAmount.Value - Caculator.CurrentBudget.PurchasePrice - interest - subTotal;
            //总收金额（USD）=折合人名币/汇率

            this.txtNetIncome.EditValue = decimal.Round(netIncomeCNY / (decimal)Caculator.CurrentBudget.ExchangeRate, 2);

            //出口退税额=总进价/1.17*出口退税率
            //decimal TaxRebateRateMoney = Math.Round(SelectedBudget.DirectCosts / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100, 2);
            //总成本=总进价-出口退税额
            decimal totalCost = Caculator.CurrentBudget.PurchasePrice - (decimal)Caculator.CurrentBudget.TaxRebate;

            //利润=折合人名币（净收入额）-总成本
            txtProfit.EditValue = netIncomeCNY - totalCost;

            //盈利水平=利润/净收入额
            this.txtProfitLevel.EditValue = txtProfit.Value / netIncomeCNY;

            this.txtNetIncome_Plan.EditValue = txtNetIncome.Value;
            this.txtRetainedProfit.EditValue = txtNetIncome_Plan.Value * txtReceiptAmount2.Value / txtTotalAmount.Value;

            //this.textEdit_Number2.EditValue = txtTaxRefund.Value;

            //this.textEdit_Number1.EditValue = PaymentMoney;
            this.textEdit_Number20.EditValue = Caculator.PaymentMoneyAmount;
            this.textEdit_Number24.EditValue = Caculator.PaymentMoneyAmount;

            //无预付款情况下，
            //textEdit_Number21.EditValue = textEdit_Number20.Value / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100;
            //this.txtTaxRefund_Total.EditValue = txtTaxRefund.Value;

            //有预付款情况下，窗体显示计税货款大于收款金额测算栏目（如果计税货款大于收款金额，则付款动用了预付款，则只能称为暂计退税款）

            if (txtTaxPayment.Value > txtReceiptAmount.Value)
            {
                // textEdit_Number28.EditValue = txtAccountBalance.Value / (decimal)1.17 * (decimal)SelectedBudget.TaxRebateRate / 100;
            }
            this.textEdit_Number29.EditValue = this.txtAccountBalance.Value + this.textEdit_Number28.Value - this.textEdit_Number24.Value;
            this.textEdit_Number30.EditValue = this.textEdit_Number29.Value + this.txtAdvancePayment.Value;


            //有预付款情况下，窗体显示计税货款小于收款金额测算栏目
            //textEdit_Number3.EditValue = txtAccountBalance.Value + textEdit_Number2.Value - textEdit_Number1.Value;
            //textEdit_Number4.EditValue = textEdit_Number3.Value + txtAdvancePayment.Value;

            //this.textEdit_Number27.EditValue = this.textEdit_Number3.Value - this.txtRetainedProfit.Value;

        }

        private void InitTaxRebateRateList()
        {
            txtTaxRebateRate.Properties.Items.Clear();
            txtTaxRebateRate2.Properties.Items.Clear();

            if (Caculator.TaxRebateRateList != null && Caculator.TaxRebateRateList.Count > 0)
            {
                foreach (decimal taxRebateRate in Caculator.TaxRebateRateList)
                {
                    txtTaxRebateRate.Properties.Items.Add(taxRebateRate);
                    txtTaxRebateRate2.Properties.Items.Add(taxRebateRate);
                }
                txtTaxRebateRate.SelectedIndex = 0;
                txtTaxRebateRate2.SelectedIndex = 0;
            }

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

        private void textEdit_Number20_EditValueChanged(object sender, EventArgs e)
        {
            CalcTaxRebate();
        }

        private void textEdit_Number1_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 计算所有收款金额
        /// </summary>
        private void CalcAccountBalance()
        {
            //账上余额=收款金额（所有）-申请用款金额（所有）
            this.txtAccountBalance.EditValue = this.txtReceiptAmount.Value - this.txtApplyMoney.Value;
        }

        /// <summary>
        /// 完成进度
        /// </summary>
        private void CalcSuperPaymentScheme()
        {
            //收汇超计划%=（已收汇人民币-合同计划款）/合同计划款*100%
            if (this.txtTotalAmount.Value != 0)
            {
                this.txtSuperPaymentScheme.EditValue = (Math.Round((this.txtReceiptAmount2.Value - txtTotalAmount.Value) / txtTotalAmount.Value, 2)) * 100;
            }
            else
            {
                this.txtSuperPaymentScheme.EditValue = 0;
            }
        }

        /// <summary>
        /// 预算款占总额%：=预付款/合同金额
        /// </summary>
        private void CalcPercentage()
        {
            if (txtTotalAmount.Value != 0)
            {
                this.txtPercentage.EditValue = Math.Round(txtAdvancePayment.Value / txtTotalAmount.Value * 100, 2);
            }
            else
            {
                this.txtPercentage.EditValue = 0;
            }
        }

        /// <summary>
        /// 可计退税款=现申请用款/营业税率*出口退税%
        /// </summary>
        private void CalcTaxRebate()
        {
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
            }

            Caculator.GetAllTaxes(textEdit_Number20.Value, taxRebateRate);
            textEdit_Number19.EditValue = Caculator.CurrentTaxes;

            this.txtTaxRefund_Total.EditValue = Caculator.AllTaxes;
            textEdit_Number23.EditValue = Caculator.Balance;

        }

        /// <summary>
        /// 可计退税款=现申请用款/营业税率*出口退税%
        /// </summary>
        private void CalcTaxRebate2()
        {
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate2.EditValue.ToString(), out taxRebateRate);
            }

            Caculator.GetAllTaxes(textEdit_Number20.Value, taxRebateRate);

            textEdit_Number28.EditValue = textEdit_Number24.Value / (1 + Caculator.ValueAddedTaxRate) * taxRebateRate;

            this.textEdit_Number1.EditValue = Caculator.AllTaxes;
            textEdit_Number29.EditValue = Caculator.Balance;
            textEdit_Number30.EditValue = Caculator.RetainedInterestBalance;

        }

        private void txtReceiptAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalcAccountBalance();
        }

        private void txtApplyMoney_EditValueChanged(object sender, EventArgs e)
        {
            CalcAccountBalance();
        }

        private void txtTotalAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalcSuperPaymentScheme();
            CalcPercentage();
        }

        private void txtReceiptAmount2_EditValueChanged(object sender, EventArgs e)
        {
            CalcSuperPaymentScheme();
        }

        private void txtAdvancePayment_EditValueChanged(object sender, EventArgs e)
        {
            CalcPercentage();
        }

        private void txtTaxRebateRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcTaxRebate();
        }

        private void txtTaxRebateRate2_EditValueChanged(object sender, EventArgs e)
        {
            CalcTaxRebate2();
        }

        private void textEdit_Number24_EditValueChanged(object sender, EventArgs e)
        {
            CalcTaxRebate2();
        }

        private void textEdit_Number28_EditValueChanged(object sender, EventArgs e)
        {
            textEdit_Number1.EditValue = txtTaxRefundA.Value + textEdit_Number28.Value;
        }


    }
}