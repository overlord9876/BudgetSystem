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
    public partial class ucOutMoneyEdit : DataControl
    {
        private List<Budget> budgetList;
        private decimal valueAddedTaxRate;
        private OutMoneyCaculator caculator;
        Bll.FlowManager fm = new FlowManager();
        private decimal vatOption = 0;
        CommonManager cm = new CommonManager();
        BudgetManager bm = new BudgetManager();
        SupplierManager sm = new SupplierManager();
        UserManager um = new UserManager();
        PaymentNotesManager pnm = new PaymentNotesManager();
        ReceiptMgmtManager rm = new ReceiptMgmtManager();
        private EditFormWorkModels _workModel;
        private PaymentNotes _paymentNote;
        Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        const decimal temporarySupplierPaymenttotalAmountMaxValue = 10000;

        private List<Supplier> supplierList;

        public PaymentNotes CurrentPaymentNotes
        {
            get { return this._paymentNote; }
            private set { this._paymentNote = value; }
        }
        public EditFormWorkModels WorkModel
        {
            get { return this._workModel; }
            set
            {
                this._workModel = value;
                InitEditStyle();
            }
        }

        public ucOutMoneyEdit()
        {
            InitializeComponent();

            CommonControl.LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueSupplierType, typeof(EnumSupplierType));

            this.cboBudget.Properties.PopupFormSize = new Size(this.cboBudget.Width * 2, 300);
            this.cboSupplier.Properties.PopupFormSize = new Size(this.cboSupplier.Width * 2, 300);
            if (!frmBaseForm.IsDesignMode)
            {
                InitData();
            }
        }

        private void InitEditStyle()
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.deCommitTime.EditValue = DateTime.Now;
                this.txtExpectedReturnDate.EditValue = DateTime.Now;
                txtApplicant.EditValue = RunInfo.Instance.CurrentUser;

                cboDepartment.Text = RunInfo.Instance.CurrentUser.DepartmentName;
                cboDepartment.Tag = RunInfo.Instance.CurrentUser.Department;

            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.txtPaymentDate.EditValue = DateTime.Now;
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
            }
        }

        public override void BindingData(int dataID)
        {
            base.BindingData(dataID);
            BandPaymentNotes(dataID);
        }

        public void BandPaymentNotes(int id)
        {
            PaymentNotes payment = pnm.GetPaymentNoteById(id);
            BandPaymentNotes(payment);
        }

        public void BandPaymentNotes(PaymentNotes payment)
        {
            this.CurrentPaymentNotes = payment;
            chkIsDrawback.EditValue = payment.IsDrawback;
            this.vatOption = payment.VatOption;
            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            if (budgetList != null)
            {
                this.cboBudget.EditValue = budgetList.Find(o => o.ID == payment.BudgetID);
            }
            List<Supplier> supplierList = (List<Supplier>)this.cboSupplier.Properties.DataSource;
            if (supplierList != null)
            {
                this.cboSupplier.EditValue = supplierList.Find(o => o.ID == payment.SupplierID);
            }

            List<BankInfo> bankInfoList = txtBankName.Properties.DataSource as List<BankInfo>;

            if (bankInfoList != null)
            {
                foreach (BankInfo info in bankInfoList)
                {
                    if (info.Account.Equals(payment.BankNO))
                    {
                        this.txtBankName.EditValue = info;
                        this.txtBankNO.EditValue = info.Account;
                        break;
                    }
                }
            }


            this.txtExpectedReturnDate.EditValue = payment.ExpectedReturnDate;
            this.txtDescription.Text = payment.Description;
            this.txtExchangeRate.EditValue = payment.ExchangeRate;
            this.txtOriginalCoin.EditValue = payment.OriginalCoin;
            this.cboCurrency.SelectedItem = payment.Currency;
            this.txtCNY.EditValue = payment.CNY;
            this.txtPaymentDate.EditValue = payment.PaymentDate;
            this.txtTaxRebateRate.EditValue = payment.TaxRebateRate;
            this.cboPaymentMethod.EditValue = payment.PaymentMethod;
            this.txtVoucherNo.Text = payment.VoucherNo;
            this.deCommitTime.EditValue = payment.CommitTime;

            this.txtApplicant.EditValue = um.GetUser(payment.Applicant);

            this.cboDepartment.EditValue = payment.DepartmentName;
            this.cboDepartment.Tag = payment.DepartmentCode;

            foreach (UseMoneyType umt in this.cboMoneyUsed.Properties.Items)
            {
                if (umt.Name == payment.MoneyUsed)
                {
                    this.cboMoneyUsed.SelectedItem = umt;
                    break;
                }
            }
            txtDescription.Text = payment.Description;
            chkHasInvoice.EditValue = payment.HasInvoice;
            chkIsIOU.EditValue = payment.IsIOU;
            txtExpectedReturnDate.EditValue = payment.ExpectedReturnDate;
        }

        public bool CheckInputData()
        {
            this.dxErrorProvider1.ClearErrors();
            this.dxErrorProvider2.ClearErrors();
            Supplier currentSupplier = cboSupplier.EditValue as Supplier;
            if (cboSupplier.EditValue as Supplier == null)
            {
                this.dxErrorProvider1.SetError(cboSupplier, "请选择供应商。");
            }

            if (txtBankName.EditValue as BankInfo == null)
            {
                this.dxErrorProvider1.SetError(txtBankName, "请选择付款开户行。");
            }

            Budget selectedBudget = cboBudget.EditValue as Budget;
            if (selectedBudget == null)
            {
                this.dxErrorProvider1.SetError(cboBudget, "请选择合同信息。");
            }

            //if (!selectedBudget.EnumFlowState.Equals(EnumDataFlowState.审批通过))
            //{
            //    this.dxErrorProvider1.SetError(cboBudget, "合同还未审批结束，不允许付款。");
            //}

            if (cboPaymentMethod.EditValue == null || string.IsNullOrEmpty(cboPaymentMethod.EditValue.ToString()))
            {
                this.dxErrorProvider1.SetError(cboPaymentMethod, "请选择付款方式。");
            }
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue == null || !decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate))
            {
                this.dxErrorProvider1.SetError(txtTaxRebateRate, "请选择退税率。");
            }
            if (txtOriginalCoin.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtOriginalCoin, "请输入付款金额（原币）。");
            }
            if (txtExchangeRate.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtExchangeRate, "请输入汇率。");
            }
            if (txtCNY.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtCNY, "请输入付款金额（人民币）。");
            }
            if (string.IsNullOrEmpty(txtVoucherNo.Text))
            {
                this.dxErrorProvider1.SetError(txtVoucherNo, "请输入凭证号。");
            }

            if (!(cboMoneyUsed.EditValue is UseMoneyType))
            {
                this.dxErrorProvider1.SetError(cboMoneyUsed, "请选择用款类型。");
            }
            if (!currentSupplier.IsQualified)
            {
                decimal totalAmount = txtCNY.Value + temporarySupplierPaymenttotalAmount;
                if (totalAmount > temporarySupplierPaymenttotalAmountMaxValue)
                {
                    this.dxErrorProvider1.SetError(txtCNY, string.Format("当前临时供方已付款{0}，加上当前付款金额已超过最大限制。", temporarySupplierPaymenttotalAmount));
                }
            }
            CheckUsage();
            if (txtAfterPaymentBalance.Value < 0)
            {
                XtraMessageBox.Show("【警告】支付后余额小于0");
            }

            return dxErrorProvider1.HasErrors;
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

        private void InitData()
        {
            try
            {
                valueAddedTaxRate = vatOption = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税税率.ToString());

                List<UseMoneyType> umtList = scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());
                this.cboMoneyUsed.Properties.Items.Clear();
                this.cboMoneyUsed.Properties.Items.AddRange(umtList);

                if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
                {
                    budgetList = bm.GetBudgetListBySaleman(RunInfo.Instance.CurrentUser.UserName);
                }
                else
                {
                    budgetList = bm.GetAllBudget();
                }
                this.cboBudget.Properties.DataSource = budgetList;

                supplierList = sm.GetAllSupplier();
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogError(ex);
            }
        }

        private void CalcCNY()
        {
            this.txtCNY.EditValue = this.txtExchangeRate.Value * this.txtOriginalCoin.Value;
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

        public void FillEditData()
        {
            if (this.CurrentPaymentNotes == null)
            {
                this.CurrentPaymentNotes = new PaymentNotes();
            }

            this.CurrentPaymentNotes.Description = this.txtDescription.Text.Trim();
            this.CurrentPaymentNotes.CNY = this.txtCNY.Value;
            if (this.txtPaymentDate.EditValue != null)
            {
                this.CurrentPaymentNotes.PaymentDate = DateTime.Parse(this.txtPaymentDate.EditValue.ToString());
            }
            this.CurrentPaymentNotes.TaxRebateRate = float.Parse(this.txtTaxRebateRate.EditValue.ToString());
            this.CurrentPaymentNotes.CommitTime = DateTime.Parse(this.deCommitTime.EditValue.ToString());
            this.CurrentPaymentNotes.VoucherNo = this.txtVoucherNo.Text;
            this.CurrentPaymentNotes.MoneyUsed = (this.cboMoneyUsed.EditValue as UseMoneyType).Name;
            this.CurrentPaymentNotes.Applicant = (this.txtApplicant.EditValue as User).UserName;

            this.CurrentPaymentNotes.DepartmentName = this.cboDepartment.EditValue.ToString();
            this.CurrentPaymentNotes.DepartmentCode = this.cboDepartment.Tag.ToString();

            this.CurrentPaymentNotes.SupplierID = (this.cboSupplier.EditValue as Supplier).ID;
            this.CurrentPaymentNotes.BudgetID = (this.cboBudget.EditValue as Budget).ID;

            this.CurrentPaymentNotes.ExchangeRate = float.Parse(this.txtExchangeRate.EditValue.ToString());
            this.CurrentPaymentNotes.OriginalCoin = this.txtOriginalCoin.Value;
            this.CurrentPaymentNotes.Currency = this.cboCurrency.SelectedItem.ToString();
            this.CurrentPaymentNotes.PaymentMethod = this.cboPaymentMethod.EditValue.ToString();
            this.CurrentPaymentNotes.Description = txtDescription.Text.Trim();
            this.CurrentPaymentNotes.HasInvoice = (bool)chkHasInvoice.EditValue;
            this.CurrentPaymentNotes.IsDrawback = (bool)chkIsDrawback.EditValue;
            this.CurrentPaymentNotes.VatOption = this.vatOption;

            this.CurrentPaymentNotes.BankName = (this.txtBankName.EditValue as BankInfo).Name;
            this.CurrentPaymentNotes.BankNO = this.txtBankNO.Text;

            this.CurrentPaymentNotes.IsIOU = this.chkIsIOU.Checked;
            this.CurrentPaymentNotes.ExpectedReturnDate = DateTime.Parse(this.txtExpectedReturnDate.EditValue.ToString());
        }

        private List<string> CommissionUsageNameList = new List<string>() { "佣金", "咨询费", "服务费", "费用支付审批单" };

        private void CheckUsage()
        {
            UseMoneyType umt = cboMoneyUsed.EditValue as UseMoneyType;
            if (umt != null)
            {
                if (umt.Name == "辅料款")
                {
                    decimal price = this.currentBudget.InProductList.Sum(o => o.RawMaterials + o.SubsidiaryMaterials);
                    if (price == 0)
                    {
                        this.dxErrorProvider1.SetError(cboMoneyUsed, "预算单中没有体现原料、辅料价格");
                    }
                    return;
                }
                else if (umt.Name == "运杂费")
                {
                    if (this.currentBudget.Premium == 0)
                    {
                        this.dxErrorProvider1.SetError(cboMoneyUsed, "预算单中没有体现运杂费");
                        return;
                    }
                    decimal money = caculator.GetUsagePayMoney(umt.Name);
                    if (money + txtCNY.Value > this.currentBudget.Premium)
                    {
                        this.dxErrorProvider2.SetError(cboMoneyUsed, string.Format("预算单中运保费为[{0}]，加上当前付款金额即将超支预算金额", this.currentBudget.Premium, money), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                        return;
                    }
                }
                else if (umt.Name == "进料款")
                {
                    if (this.currentBudget.FeedMoney == 0)
                    {
                        this.dxErrorProvider1.SetError(cboMoneyUsed, "预算单中没有体现进料款");
                        return;
                    }
                    decimal money = caculator.GetUsagePayMoney(umt.Name);
                    if (money + txtCNY.Value > this.currentBudget.Premium)
                    {
                        this.dxErrorProvider2.SetError(cboMoneyUsed, string.Format("预算单中进料款为[{0}]，加上当前付款金额即将超支预算金额", this.currentBudget.Premium, money), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                        return;
                    }
                }
                else if (CommissionUsageNameList.Contains(umt.Name))
                {
                    if (this.currentBudget.Commission == 0)
                    {
                        this.dxErrorProvider1.SetError(cboMoneyUsed, "预算单中没有体现佣金");
                        return;
                    }
                    //decimal money = caculator.GetUsagePayMoney(umt.Name);
                    //if (money + txtCNY.Value > this.currentBudget.Premium)
                    //{
                    //    this.dxErrorProvider2.SetError(cboMoneyUsed, string.Format("预算单中佣金为[{0}]，加上当前付款金额即将超支预算金额", this.currentBudget.Premium, money), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    //    return;
                    //}
                }
            }
        }

        //private IEnumerable<PaymentNotes> paymentNotes;
        private Budget currentBudget;

        private void cboBudget_EditValueChanged(object sender, EventArgs e)
        {
            currentBudget = cboBudget.EditValue as Budget;
            if (currentBudget != null)
            {
                //if (currentBudget.FlowName != EnumFlowNames.预算单审批流程.ToString() || currentBudget.EnumFlowState != EnumDataFlowState.审批通过)
                //{
                //    XtraMessageBox.Show(string.Format("合同号【{0}】还未通过审批，暂不允许付款", currentBudget.ContractNO));
                //    currentBudget = null;
                //    return;
                //}
                var paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(currentBudget.ID);
                //过滤当前自己的单据
                if (CurrentPaymentNotes != null)
                {
                    paymentNotes = paymentNotes.Where(o => o.ID != CurrentPaymentNotes.ID);
                }
                var receiptList = rm.GetBudgetBillListByBudgetId(currentBudget.ID);
                currentBudget = bm.GetBudget(currentBudget.ID);

                List<Supplier> budgetSupplierList = sm.GetSupplierListByBudgetId(currentBudget.ID);
                budgetSupplierList.RemoveAll(o => !o.IsQualified);
                budgetSupplierList.AddRange(supplierList.Where(o => !o.IsQualified));
                this.cboSupplier.Properties.DataSource = budgetSupplierList;

                caculator = new OutMoneyCaculator(currentBudget, paymentNotes, receiptList, valueAddedTaxRate);

                InitTaxRebateRateList(currentBudget.InProductDetail);

                //生成付款单号
                this.txtVoucherNo.Text = string.Format("{0}-{1}", currentBudget.ContractNO, cm.GetNewCode(CodeType.PayementCode).ToString().PadLeft(4, '0'));

                if (currentBudget == null) { return; }

                //总收款金额
                txtReceiptAmount.EditValue = caculator.ReceiptMoneyAmount;

                //预付款赋值
                txtAdvancePayment.EditValue = currentBudget.AdvancePayment;

                //应留利润计算
                txtActualRetention.EditValue = caculator.ActualProfit;
                CalcPaymentTaxRebate();
            }
            else
            {
                txtReceiptAmount.EditValue = 0;
            }
        }


        private void CalcPaymentTaxRebate()
        {
            if (caculator == null) { return; }
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue != null)
            {
                decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
            }
            caculator.ApplyForPayment(this.txtCNY.Value, taxRebateRate, this.chkIsDrawback.Checked);

            //退税总金额=已付金额+当前付款退税金额
            this.txtAmountTaxRebate.EditValue = caculator.AllTaxes;

            //总付款金额=已付金额+当前付款金额
            txtAmountPaymentMoney.EditValue = caculator.PaymentMoneyAmount + this.txtCNY.Value;

            //支付后余额
            this.txtAfterPaymentBalance.EditValue = caculator.Balance;

        }

        private decimal temporarySupplierPaymenttotalAmount;

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            Supplier editValue = (Supplier)cboSupplier.EditValue;
            if (editValue != null)
            {
                txtBankName.Properties.DataSource = editValue.BankInfoDetail.ToObjectList<List<BankInfo>>();
                if (!editValue.IsQualified)
                {
                    temporarySupplierPaymenttotalAmount = pnm.GetTemporarySupplierPaymentByBudgetId(currentBudget.ID, editValue.ID);
                    if (temporarySupplierPaymenttotalAmount >= temporarySupplierPaymenttotalAmountMaxValue)
                    {
                        this.dxErrorProvider1.SetError(this.cboSupplier, string.Format("当前临时供方已付款{0}，已经没有付款额度。", temporarySupplierPaymenttotalAmount), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    }
                }
            }
        }

        private void btnSearchMoney_Click(object sender, EventArgs e)
        {
            if (caculator != null)
            {
                frmPaymentCalcEdit form = new frmPaymentCalcEdit();
                form.Caculator = caculator;
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("请选择合同");
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

        private void txtCNY_EditValueChanged(object sender, EventArgs e)
        {
            CalcPaymentTaxRebate();
        }
        
        private void txtTaxRebateRate_EditValueChanged_1(object sender, EventArgs e)
        {
            CalcPaymentTaxRebate();
        }

        private List<string> ignoreItems = new List<string>() { "货款", "面辅料" };

        private void cboMoneyUsed_EditValueChanged(object sender, EventArgs e)
        {
            UseMoneyType selectedItem = this.cboMoneyUsed.EditValue as UseMoneyType;
            if (selectedItem != null)
            {
                if (ignoreItems.Contains(selectedItem.Name))
                {
                    this.chkIsIOU.Properties.ReadOnly = true;
                    this.txtExpectedReturnDate.Properties.ReadOnly = true;
                }
                else
                {
                    this.chkIsIOU.Properties.ReadOnly = false;
                    this.txtExpectedReturnDate.Properties.ReadOnly = false;
                }
                chkHasInvoice.Checked = selectedItem.ProvideInvoice;
            }
            else
            {
                chkHasInvoice.Checked = false;
            }
        }

        private void txtBankName_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtBankName.EditValue is BankInfo)
            {
                this.txtBankNO.Text = (this.txtBankName.EditValue as BankInfo).Account;
            }
        }

        private void btnShowBudgetHistory_Click(object sender, EventArgs e)
        {
            if (currentBudget == null)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }

            frmAccountBillView form = new frmAccountBillView();
            form.CurrentBudget = currentBudget;
            form.ShowDialog(this);
        }

        private void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCurrency.EditValue != null && (cboCurrency.EditValue.ToString().Equals("CNY") || cboCurrency.EditValue.ToString().Equals("人民币")))
            {
                this.txtExchangeRate.EditValue = 1;
            }
        }

        private void txtAfterPaymentBalance_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtAfterPaymentBalance.Value >= 0)
            {
                txtAfterPaymentBalance.ForeColor = Color.Black;

            }
            else
            {
                txtAfterPaymentBalance.ForeColor = Color.Red;
            }
        }
    }
}