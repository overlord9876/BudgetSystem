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
        private decimal vatOption = 0;
        private Bll.SystemConfigManager scm = new Bll.SystemConfigManager();

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
            vatOption = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税税率.ToString());

            //所有收款金额
            this.txtApplyMoney.EditValue = PaymentNotes.Sum(o => o.CNY);
            //所有付款金额
            this.txtReceiptAmount.EditValue = ReceiptAmount;
            //已收汇人民币
            this.txtReceiptAmount2.EditValue = ReceiptAmount;
            //合同计划款
            this.txtTotalAmount.EditValue = SelectedBudget.TotalAmount;

            InitTaxRebateRateList(SelectedBudget.InProductDetail);

            //包含预付款
            if (SelectedBudget.HasAdvancePayment)
            {
                this.CustomWorkModel = "HasAdvancePayment";
                this.txtTaxPayment.EditValue = PaymentNotes.Where(o => o.IsDrawback).Sum(o => o.CNY);
                this.txtTaxRefund.EditValue = PaymentNotes.Sum(o => o.AmountOfTaxRebate());
            }
            else//没有预付款
            {
                this.CustomWorkModel = "NotHasAdvancePayment";

                txtTaxPaymentA.EditValue = txtApplyMoney.Value;
                txtTaxRefundA.EditValue = PaymentNotes.Sum(o => o.AmountOfTaxRebate());
            }

            SetLayoutControlStyle(EditFormWorkModels.Custom);

            this.txtCommitDate.EditValue = SelectedBudget.CreateDate;
            this.txtBudgetNo.EditValue = SelectedBudget.ContractNO;
            this.txtCustomer.Text = SelectedBudget.CustomerList.ToNameString();
            this.txtSupplier.Text = SelectedBudget.SupplierList.ToNameString();
            this.txtAdvancePayment.EditValue = SelectedBudget.AdvancePayment;
            this.txtApprovalState.EditValue = SelectedBudget.State;
            this.txtFeedMoney.EditValue = SelectedBudget.FeedMoney;

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

        private void InitTaxRebateRateList(string inProductDetail)
        {
            txtTaxRebateRate.Properties.Items.Clear();
            List<InProductDetail> inProductDetailList = null;
            if (!string.IsNullOrEmpty(inProductDetail))
            {
                try
                {
                    inProductDetailList = inProductDetail.ToObjectList<List<InProductDetail>>();
                }
                catch { }
            }
            else
            {
                inProductDetailList = new List<InProductDetail>();
            }
            if (inProductDetailList != null)
            {
                foreach (var v in inProductDetailList)
                {
                    if (!txtTaxRebateRate.Properties.Items.Contains(v.TaxRebateRate))
                    {
                        txtTaxRebateRate.Properties.Items.Add(v.TaxRebateRate);
                    }
                }
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

        private void textEdit_Number4_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit_Number4.Value <= 0)
            {
                dxErrorProvider1.SetError(textEdit_Number4, "支付余额不允许小于0。");
            }
        }

        private void textEdit_Number20_EditValueChanged(object sender, EventArgs e)
        {
            CalcTaxRebate();
        }

        private void textEdit_Number24_EditValueChanged(object sender, EventArgs e)
        {

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
                this.txtSuperPaymentScheme.EditValue = (Math.Round((this.txtReceiptAmount2.Value - txtTotalAmount.Value) / txtTotalAmount.Value, 2)) * 100 - 100;
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

            textEdit_Number19.EditValue = textEdit_Number20.Value / (1 + vatOption) * taxRebateRate;

            this.txtTaxRefund_Total.EditValue = this.textEdit_Number19.Value + this.txtTaxRefund.Value;
            textEdit_Number23.EditValue = txtAccountBalance.Value + txtTaxRefund_Total.Value - textEdit_Number20.Value;

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


    }
}