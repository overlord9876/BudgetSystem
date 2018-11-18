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
using Newtonsoft.Json;

namespace BudgetSystem.OutMoney
{
    public partial class frmOutMoneyEdit : frmBaseDialogForm
    {
        private decimal vatOption = 0;
        CommonManager cm = new CommonManager();
        BudgetManager bm = new BudgetManager();
        SupplierManager sm = new SupplierManager();
        UserManager um = new UserManager();
        PaymentNotesManager pnm = new PaymentNotesManager();
        ActualReceiptsManager arm = new ActualReceiptsManager();

        Bll.SystenConfigManager scm = new Bll.SystenConfigManager();

        public PaymentNotes CurrentPaymentNotes { get; set; }

        public frmOutMoneyEdit()
        {
            InitializeComponent();

            this.cboBudget.Properties.PopupFormSize = new Size(this.cboBudget.Width * 2, 300);
            this.cboSupplier.Properties.PopupFormSize = new Size(this.cboSupplier.Width * 2, 300);

        }

        private void frmOutMemoryEdit_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();

            BudgetStateValidationRule customValidationRule = new BudgetStateValidationRule();
            customValidationRule.ErrorText = "Please enter a valid person name";
            customValidationRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            dxValidationProvider1.SetValidationRule(cboBudget, customValidationRule);

            InitData();
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "新增付款信息";
                vatOption = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税.ToString());

                this.txtPaymentDate.EditValue = DateTime.Now;
                this.txtApprover.Text = RunInfo.Instance.CurrentUser.UserName;
                this.txtApproveTime.Text = DateTime.Now.ToString();
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑付款信息";
                BandPaymentNotes(this.CurrentPaymentNotes.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看付款信息";
                BandPaymentNotes(this.CurrentPaymentNotes.ID);
            }
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }

            this.CurrentPaymentNotes = new PaymentNotes();
            FillEditData();
            pnm.AddPaymentNote(this.CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }

            FillEditData();
            pnm.ModifyPaymentNote(this.CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CheckInputData()
        {
            if (cboSupplier.EditValue as Supplier == null)
            {
                this.dxErrorProvider1.SetError(cboSupplier, "请选择供应商。");
                this.cboSupplier.Focus();
                return;
            }
            Budget selectedBudget = cboBudget.EditValue as Budget;
            if (selectedBudget == null)
            {
                this.dxErrorProvider1.SetError(cboBudget, "请选择合同信息。");
                this.cboBudget.Focus();
                return;
            }

            if (!selectedBudget.State.Equals("审批结束"))
            {
                this.dxErrorProvider1.SetError(cboBudget, "合同还未审批结束，不允许付款。");
                this.cboBudget.Focus();
                return;
            }

            if (cboPaymentMethod.EditValue == null || string.IsNullOrEmpty(cboPaymentMethod.EditValue.ToString()))
            {
                this.dxErrorProvider1.SetError(cboPaymentMethod, "请选择付款方式。");
                this.cboPaymentMethod.Focus();
                return;
            }
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue == null || !decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate))
            {
                this.dxErrorProvider1.SetError(txtTaxRebateRate, "请选择退税率。");
                this.txtTaxRebateRate.Focus();
                return;
            }
            if (txtOriginalCoin.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtOriginalCoin, "请输入付款金额（原币）。");
                this.txtOriginalCoin.Focus();
                return;
            }
            if (txtExchangeRate.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtExchangeRate, "请输入汇率。");
                this.txtExchangeRate.Focus();
                return;
            }
            if (txtCNY.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtCNY, "请输入付款金额（人民币）。");
                this.txtCNY.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtVoucherNo.Text))
            {
                this.dxErrorProvider1.SetError(txtVoucherNo, "请输入凭证号。");
                this.txtVoucherNo.Focus();
                return;
            }

            if (cboMoneyUsed.EditValue == null || string.IsNullOrEmpty(cboMoneyUsed.EditValue.ToString()))
            {
                this.dxErrorProvider1.SetError(cboMoneyUsed, "请输入用款类型。");
                cboMoneyUsed.Focus();
                return;
            }

            if (cboApplicant.EditValue as User == null)
            {
                this.dxErrorProvider1.SetError(cboApplicant, "请选择申请人。");
                this.cboApplicant.Focus();
                return;
            }
        }

        private void InitData()
        {

            this.cboBudget.Properties.DataSource = bm.GetAllBudget();

            this.cboSupplier.Properties.DataSource = sm.GetAllSupplier();

            this.cboApplicant.Properties.Items.AddRange(um.GetAllUser());
        }

        private void CalcCNY()
        {
            this.txtCNY.EditValue = this.txtExchangeRate.Value * this.txtOriginalCoin.Value;
        }

        private void BandPaymentNotes(int id)
        {
            PaymentNotes payment = pnm.GetPaymentNoteById(id);

            this.vatOption = payment.VatOption;
            this.txtApprover.Text = payment.Approver;
            this.txtApproveTime.EditValue = payment.ApproveTime;
            this.txtDescription.Text = payment.Description;
            this.txtExchangeRate.EditValue = payment.ExchangeRate;
            this.txtOriginalCoin.EditValue = payment.OriginalCoin;
            this.cboCurrency.SelectedItem = payment.Currency;
            this.txtCNY.EditValue = payment.CNY;
            this.txtPaymentDate.EditValue = payment.PaymentDate;
            this.txtTaxRebateRate.EditValue = payment.TaxRebateRate;
            this.txtVoucherNo.Text = payment.VoucherNo;
            foreach (User u in this.cboApplicant.Properties.Items)
            {
                if (u.UserName == payment.Applicant)
                {
                    this.cboApplicant.SelectedItem = u;
                    this.cboDepartment.Text = u.Department;
                    break;
                }
            }
            this.cboMoneyUsed.SelectedText = payment.MoneyUsed;
            List<Supplier> supplierList = (List<Supplier>)this.cboSupplier.Properties.DataSource;
            if (supplierList != null)
            {
                this.cboSupplier.EditValue = supplierList.Find(o => o.ID == payment.SupplierID);
            }
            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            if (budgetList != null)
            {
                this.cboBudget.EditValue = budgetList.Find(o => o.ID == payment.BudgetID);
            }
            txtDescription.Text = payment.Description;
            chkHasInvoice.EditValue = payment.HasInvoice;
            chkIsDrawback.EditValue = payment.IsDrawback;
        }

        private void InitTaxRebateRateList(string inProductDetail)
        {
            txtTaxRebateRate.Properties.Items.Clear();
            List<InProductDetail> inProductDetailList = null;
            if (!string.IsNullOrEmpty(inProductDetail))
            {
                try
                {
                    inProductDetailList = JsonConvert.DeserializeObject<List<InProductDetail>>(inProductDetail);
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

        private void FillEditData()
        {
            this.CurrentPaymentNotes.Approver = this.txtApprover.Text.Trim();
            this.CurrentPaymentNotes.ApproveTime = DateTime.Parse(this.txtApproveTime.EditValue.ToString());
            this.CurrentPaymentNotes.Description = this.txtDescription.Text.Trim();
            this.CurrentPaymentNotes.CNY = this.txtCNY.Value;
            this.CurrentPaymentNotes.PaymentDate = DateTime.Parse(this.txtPaymentDate.EditValue.ToString());
            this.CurrentPaymentNotes.TaxRebateRate = (float)(decimal)this.txtTaxRebateRate.EditValue;
            this.CurrentPaymentNotes.VoucherNo = this.txtVoucherNo.Text;
            this.CurrentPaymentNotes.Applicant = this.cboApplicant.SelectedItem.ToString();
            this.CurrentPaymentNotes.MoneyUsed = this.cboMoneyUsed.SelectedText;

            this.CurrentPaymentNotes.SupplierID = (this.cboSupplier.EditValue as Supplier).ID;
            this.CurrentPaymentNotes.BudgetID = (this.cboBudget.EditValue as Budget).ID;

            this.CurrentPaymentNotes.ExchangeRate = (float)(decimal)this.txtExchangeRate.EditValue;
            this.CurrentPaymentNotes.OriginalCoin = this.txtOriginalCoin.Value;
            this.CurrentPaymentNotes.Currency = this.cboCurrency.SelectedItem.ToString();
            this.CurrentPaymentNotes.Description = txtDescription.Text.Trim();
            this.CurrentPaymentNotes.HasInvoice = (bool)chkHasInvoice.EditValue;
            this.CurrentPaymentNotes.IsDrawback = (bool)chkIsDrawback.EditValue;
            this.CurrentPaymentNotes.VatOption = this.vatOption;
        }

        private List<PaymentNotes> paymentNotes;

        private void cboBudget_EditValueChanged(object sender, EventArgs e)
        {
            Budget currentBudget = cboBudget.EditValue as Budget;
            if (currentBudget != null)
            {
                currentBudget = bm.GetBudget(currentBudget.ID);

                InitTaxRebateRateList(currentBudget.InProductDetail);
                //总收款金额
                txtReceiptAmount.EditValue = arm.GetTotalAmountCNYByBudgetId(currentBudget.ID);
                IEnumerable<PaymentNotes> pnList = pnm.GetTotalAmountPaymentMoneyByBudgetId(currentBudget.ID);
                if (pnList == null)
                {
                    pnList = new System.Collections.ObjectModel.Collection<PaymentNotes>();
                }
                //总付款金额
                txtAmountPaymentMoney.EditValue = pnList.Sum(o => o.CNY);

                //退税总金额
                this.txtAmountTaxRebate.EditValue = pnList.Sum(o => o.AmountOfTaxRebate());

                //decimal taxRebateCNY = pnList.Where(o => o.IsDrawback).Sum(o => o.CNY);

                //decimal originalCoin = pnList.Where(o => o.IsDrawback).Sum(o => o.OriginalCoin);
                //预付款赋值
                txtAdvancePayment.EditValue = currentBudget.AdvancePayment;
                decimal amount = arm.GetTotalAmountOriginalCoinByBudgetId(currentBudget.ID);

                //应留利润计算
                txtActualRetention.EditValue = currentBudget.Profit / currentBudget.TotalAmount * amount;

                //生成付款单号
                this.txtVoucherNo.Text = string.Format("{0}-{1}", currentBudget.ContractNO, cm.GetNewCode(CodeType.PayementCode).ToString().PadLeft(4, '0'));
            }
            else
            {
                txtReceiptAmount.EditValue = 0;
            }
        }

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            Supplier editValue = (Supplier)cboSupplier.EditValue;
            if (editValue != null)
            {
                this.txtBankName.Text = editValue.BankName;
                this.txtBankNO.Text = editValue.BankNO;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSearchMoney_Click(object sender, EventArgs e)
        {
            Budget selectedBudget = this.cboBudget.EditValue as Budget;
            if (selectedBudget != null)
            {
                txtReceiptAmount.EditValue = arm.GetTotalAmountCNYByBudgetId(selectedBudget.ID);
                //  paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(selectedBudget.ID);

                frmPaymentCalcEdit form = new frmPaymentCalcEdit();
                form.SelectedBudget = bm.GetBudget(selectedBudget.ID);
                form.ReceiptAmount = txtReceiptAmount.Value;
                form.PaymentNotes = paymentNotes;
                form.PaymentMoney = txtCNY.Value;
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("请选择合同");
            }
        }

        private void cboApplicant_SelectedValueChanged(object sender, EventArgs e)
        {
            User selectedUser = cboApplicant.EditValue as User;
            if (selectedUser != null)
            {
                cboDepartment.Text = selectedUser.DepartmentName;
            }
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcCNY();
        }

        private void txtOriginalCoin_EditValueChanged(object sender, EventArgs e)
        {
            CalcCNY();
        }
    }
}