﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using System.Linq;
using BudgetSystem.Bll;
using BudgetSystem.CommonControl;

namespace BudgetSystem.OutMoney
{
    public partial class frmPaymentCalcEdit : frmBaseDialogForm
    {
        private BudgetManager bm = new BudgetManager();
        public OutMoneyCaculator Caculator { get; set; }
        public List<Budget> BudgetList { get; set; }

        public frmPaymentCalcEdit()
        {
            InitializeComponent();
        }

        private void frmPaymentCalcEdit_Load(object sender, EventArgs e)
        {
            if (BudgetList == null)
            {
                if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
                {
                    BudgetList = bm.GetBudgetListBySaleman(RunInfo.Instance.CurrentUser.UserName);
                }
                else
                {
                    BudgetList = bm.GetAllBudget();
                }
            }

            this.txtBudgetNo.Properties.DataSource = BudgetList;
            if (Caculator == null)
            {
                return;
            }

            this.txtBudgetNo.EditValue = BudgetList.Find(o => o.ID.Equals(Caculator.CurrentBudget.ID));
            this.txtBudgetNo.Properties.ReadOnly = true;
            InitBudgetMoneyDetail();
            //有预付款情况下，窗体显示计税货款小于收款金额测算栏目
            //textEdit_Number3.EditValue = txtAccountBalance.Value + textEdit_Number2.Value - textEdit_Number1.Value;
            //textEdit_Number4.EditValue = textEdit_Number3.Value + txtAdvancePayment.Value;

            //this.textEdit_Number27.EditValue = this.textEdit_Number3.Value - this.txtRetainedProfit.Value;

        }

        private void InitBudgetMoneyDetail()
        {
            this.txtCommitDate.EditValue = Caculator.CurrentBudget.CreateDate;
            Budget budget = bm.GetBudget(Caculator.CurrentBudget.ID);
            if (budget != null)
            {
                this.txtCustomer.Text = budget.CustomerList.ToNameAndCountryString();
                this.txtSupplier.Text = budget.SupplierList.ToNameString();
            }
            //预付款
            this.txtAdvancePayment.EditValue = Caculator.AdvancePayment;
            //压缩后预付款
            this.txtAdvancePayment2.EditValue = Caculator.CompressAdvancePayment;
            //申请用款金额
            this.txtApplyMoney.EditValue = Caculator.PaymentMoneyAmount;
            //所有收款金额
            this.txtReceiptAmount.EditValue = Caculator.ReceiptMoneyAmount;
            //已收汇人民币
            this.txtReceiptAmount2.EditValue = Caculator.ReceiptMoneyAmount;
            //合同计划款
            this.txtTotalAmount.EditValue = Caculator.TotalAmount;
            //预算款占总额%
            this.txtPercentage.EditValue = Caculator.Percentage;
            //收款超计划%
            this.txtSuperPaymentScheme.EditValue = Caculator.SuperPaymentScheme;
            //佣金比率
            this.txtCommissionRate.EditValue = Caculator.CommissionRate;


            this.txtApprovalState.EditValue = Caculator.CurrentBudget.State;
            this.txtFeedMoney.EditValue = Caculator.CurrentBudget.FeedMoney;
            this.txtCommission.EditValue = Caculator.CurrentBudget.Commission;
            this.txtPremium.EditValue = Caculator.CurrentBudget.Premium;

            this.txtSuperPaymentScheme.EditValue = Caculator.SuperPaymentScheme;
            this.txtAccountBalance.EditValue = this.txtReceiptAmount.Value - this.txtApplyMoney.Value;


            this.txtAdvancePayment.EditValue = Caculator.AdvancePayment;
            this.txtAdvancePayment2.EditValue = Caculator.CompressAdvancePayment;
            this.txtNetIncome.EditValue = Caculator.NetIncomeCNY;

            //利润=折合人名币（净收入额）-总成本
            txtProfit.EditValue = Caculator.PlannedProfit;

            //盈利水平=利润/净收入额
            this.txtProfitLevel.EditValue = Caculator.ProfitLevel;


            InitTaxRebateRateList();

            //包含预付款
            if (Caculator.AdvancePayment > 0)
            {
                txtApplyForPayment.EditValueChanged -= new EventHandler(ApplyForPayment_EditValueChanged);
                this.txtApplyForPayment.EditValue = Caculator.PaymentMoneyAmount;
                txtApplyForPayment.EditValueChanged += new EventHandler(ApplyForPayment_EditValueChanged);
                this.CustomWorkModel = "HasAdvancePayment";
                foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcg_NotHasAdvancePayment.Items)
                {
                    item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                lcg_NotHasAdvancePayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcg_HasAdvancePayment.Items)
                {
                    item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                lcg_HasAdvancePayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else//没有预付款
            {
                this.txtApplyForPayment2.EditValueChanged -= new EventHandler(ApplyForPayment2_EditValueChanged);
                this.txtApplyForPayment2.EditValue = Caculator.PaymentMoneyAmount;
                this.txtApplyForPayment2.EditValueChanged += new EventHandler(ApplyForPayment2_EditValueChanged);
                this.CustomWorkModel = "NotHasAdvancePayment";
                foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcg_HasAdvancePayment.Items)
                {
                    item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                lcg_HasAdvancePayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcg_NotHasAdvancePayment.Items)
                {
                    item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                lcg_NotHasAdvancePayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
            }
            ChangedUsageMoneyValue(Caculator.PaymentMoneyAmount, taxRebateRate);
        }

        private void ChangedUsageMoneyValue(decimal usageMoney, decimal taxRebateRate)
        {
            Caculator.ApplyForPayment(usageMoney, taxRebateRate);

            if (Caculator.AdvancePayment > 0)//有预付款的情况
            {
                if (Caculator.IsReceiptGreaterThanTaxPayment(usageMoney))
                {
                    this.lcg_HasAdvancePayment.Text = "有预付款情况下计算栏(所有可退税货款（辅料款）< 收款时)";
                    this.txtTaxPayment.EditValue = Caculator.TaxPayment;
                    this.txtTaxRefund.EditValue = Caculator.TaxRefund;
                    txtTaxPaymentA.EditValue = 0;
                    txtTaxRefundA.EditValue = 0;
                }
                else
                {
                    this.lcg_HasAdvancePayment.Text = "有预付款情况下计算栏(所有可退税货款（辅料款）> 收款时)";
                    this.txtTaxPayment.EditValue = 0;
                    this.txtTaxRefund.EditValue = 0;
                    txtTaxPaymentA.EditValue = Caculator.TaxPayment;
                    txtTaxRefundA.EditValue = Caculator.TaxRefund;
                }

                txtCurrentTaxes2.EditValue = Caculator.CurrentTaxes;
                this.txtAllTaxes2.EditValue = Caculator.AllTaxes;
                txtBalance2.EditValue = Caculator.Balance;
                txtEnablingAdvancePayment.EditValue = Caculator.EnablingAdvancePayment;
            }
            else
            {
                this.txtTaxPayment.EditValue = Caculator.TaxPayment;
                this.txtTaxRefund.EditValue = Caculator.TaxRefund;
                txtCurrentTaxes.EditValue = Caculator.CurrentTaxes;
                txtAllTaxes.EditValue = Caculator.AllTaxes;
                txtBalance.EditValue = Caculator.Balance;
            }
            this.txtPlannedProfit.EditValue = Caculator.PlannedProfit;
            this.txtActualProfit.EditValue = Caculator.ActualProfit;
            this.txtRetainedInterestBalance.EditValue = Caculator.RetainedInterestBalance;

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
                txtTaxRebateRate.EditValueChanged -= new EventHandler(txtTaxRebateRate_EditValueChanged);
                txtTaxRebateRate2.EditValueChanged -= new EventHandler(txtTaxRebateRate2_EditValueChanged);
                txtTaxRebateRate.SelectedIndex = 0;
                txtTaxRebateRate2.SelectedIndex = 0;
                txtTaxRebateRate.EditValueChanged += new EventHandler(txtTaxRebateRate_EditValueChanged);
                txtTaxRebateRate2.EditValueChanged += new EventHandler(txtTaxRebateRate2_EditValueChanged);
            }

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

        private void txtEnablingAdvancePayment_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtEnablingAdvancePayment.Value >= 0)
            {
                txtEnablingAdvancePayment.ForeColor = Color.Black;
            }
            else
            {
                txtEnablingAdvancePayment.ForeColor = Color.Red;
            }
        }


        private void txtTaxRebateRate_EditValueChanged(object sender, EventArgs e)
        {
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
            }

            ChangedUsageMoneyValue(txtApplyForPayment.Value, taxRebateRate);
        }

        private void txtTaxRebateRate2_EditValueChanged(object sender, EventArgs e)
        {
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate2.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate2.EditValue.ToString(), out taxRebateRate);
            }

            ChangedUsageMoneyValue(txtApplyForPayment2.Value, taxRebateRate);
        }

        private void ApplyForPayment_EditValueChanged(object sender, EventArgs e)
        {
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
            }

            ChangedUsageMoneyValue(txtApplyForPayment.Value, taxRebateRate);
        }

        private void ApplyForPayment2_EditValueChanged(object sender, EventArgs e)
        {
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate2.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate2.EditValue.ToString(), out taxRebateRate);
            }

            ChangedUsageMoneyValue(txtApplyForPayment2.Value, taxRebateRate);
        }

        private void txtBudgetNo_EditValueChanged(object sender, EventArgs e)
        {
            Budget selectedBudget = this.txtBudgetNo.EditValue as Budget;
            if (selectedBudget != null)
            {
                SystemConfigManager scm = new SystemConfigManager();
                PaymentNotesManager pnm = new PaymentNotesManager();
                ReceiptMgmtManager rm = new ReceiptMgmtManager();
                decimal valueAddedTaxRate = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税税率.ToString());
                var paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(selectedBudget.ID);
                var receiptList = rm.GetBudgetBillListByBudgetId(selectedBudget.ID);
                Caculator = new OutMoneyCaculator(selectedBudget, paymentNotes, receiptList, valueAddedTaxRate);

                InitBudgetMoneyDetail();
            }
        }

        private void txtBalance2_EditValueChanged(object sender, EventArgs e)
        {
            IsHightLightControl(this.txtBalance2);
        }

        private void txtBalance_EditValueChanged(object sender, EventArgs e)
        {
            IsHightLightControl(this.txtBalance);
        }

        private void IsHightLightControl(TextEdit_Number control, decimal MaxValue = 0)
        {
            if (control.Value > MaxValue)
            {
                control.ForeColor = Color.Black;

            }
            else
            {
                control.ForeColor = Color.Red;
            }
        }

        private void txtSuperPaymentScheme_EditValueChanged(object sender, EventArgs e)
        {
            IsHightLightControl(txtSuperPaymentScheme, 30);
        }

        private void txtCommissionRate_EditValueChanged(object sender, EventArgs e)
        {
            IsHightLightControl(txtSuperPaymentScheme, (decimal)19.99);
        }

    }
}