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
using BudgetSystem.Entity.QueryCondition;

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
        private List<UseMoneyType> umtList;
        private List<InMoneyType> imtList;
        Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        const decimal temporarySupplierPaymenttotalAmountMaxValue = 10000;

        private bool isApprovalView = false;
        private List<Supplier> supplierList = new List<Supplier>();

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

            if (frmBaseForm.IsDesignMode)
            {
                return;
            }
            CommonControl.LookUpEditHelper.FillRepositoryItemLookUpEditByEnum_IntValue(this.rilueSupplierType, typeof(EnumSupplierType));
            this.riLinkDelete.Click += new EventHandler(riLinkDelete_Click);
            this.riLinkDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(riLinkDelete_CustomDisplayText);
            this.btnSingleBudgetFinalAccount.Click += btnSingleBudgetFinalAccount_Click;
            this.btnShowBudgetHistory.Click += btnShowBudgetHistory_Click;
            this.btn_budgetView.Click += btn_budgetView_Click;
            this.cboBudget.Properties.PopupFormSize = new Size(this.Width / 2, 300);
            this.cboSupplier.Properties.PopupFormSize = new Size(this.Width / 2, 300);
            this.txtApplicant.EditValue = RunInfo.Instance.CurrentUser;

            InitData();
        }

        private void InitEditStyle()
        {
            lciPayingBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciInvoiceNumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciMessage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            txtPaymentDate.Properties.ReadOnly = true;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                DateTime datetimeNow = cm.GetDateTimeNow();
                this.deCommitTime.EditValue = datetimeNow;
                this.txtExpectedReturnDate.EditValue = datetimeNow;
                txtApplicant.EditValue = RunInfo.Instance.CurrentUser;

                cboDepartment.Text = RunInfo.Instance.CurrentUser.DepartmentName;
                cboDepartment.Tag = RunInfo.Instance.CurrentUser.DeptID;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
            }
            else if (this.WorkModel == EditFormWorkModels.Custom)
            {
                foreach (var control in this.layoutControl1.Controls)
                {
                    if (control == chkIsDrawback || control == chkHasInvoice || control == chkIsIOU || control == chkRepayLoan)//如果是出纳，这几个修改项允许放开。
                    {
                        continue;
                    }
                    if (control is BaseEdit)
                    {
                        (control as BaseEdit).Properties.ReadOnly = true;
                    }
                }
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
                gvInvoiceNumber.OptionsBehavior.Editable = false;
                lciPayingBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        public override void BindingData(int dataID)
        {
            isApprovalView = true;
            lciMessage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
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
            if (payment == null)
            {
                XtraMessageBox.Show("单据已经不存在。");
                return;
            }
            if (this.WorkModel == EditFormWorkModels.View || this.WorkModel == EditFormWorkModels.Print || this.WorkModel == EditFormWorkModels.Custom)
            {
                if (budgetList == null)
                {
                    budgetList = new List<Budget>();
                }
                var budget = bm.GetBudget(payment.BudgetID);
                if (budget != null)
                {
                    budgetList.Add(budget);
                }
                this.cboBudget.Properties.DataSource = budgetList;
            }

            this.CurrentPaymentNotes = payment;
            chkIsDrawback.EditValue = payment.IsDrawback;
            this.vatOption = payment.VatOption;
            Supplier supplier = sm.GetSupplier(payment.SupplierID);
            if (supplier != null)
            {
                this.supplierList.Add(supplier);
            }

            Budget findedItem = SelectedBudgetById(payment.BudgetID);
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
                    if (info.Name.Equals(payment.BankName))
                    {
                        this.txtBankName.EditValue = info;
                        break;
                    }
                }
            }

            foreach (UseMoneyType umt in this.cboMoneyUsed.Properties.Items)
            {
                if (umt.Name == payment.MoneyUsed)
                {
                    this.cboMoneyUsed.SelectedItem = umt;
                    break;
                }
            }

            this.txtBankNO.EditValue = payment.BankNO;

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
            this.cboPayingBank.EditValue = payment.PayingBank;
            this.txtApplicant.EditValue = um.GetUser(payment.Applicant);

            this.cboDepartment.EditValue = payment.DepartmentName;
            this.cboDepartment.Tag = payment.DeptID;

            txtDescription.Text = payment.Description;
            chkHasInvoice.EditValue = payment.HasInvoice;
            BindingBankInfoDetail(payment.InvoiceNumber);
            chkIsIOU.EditValue = payment.IsIOU;
            chkRepayLoan.EditValue = payment.RepayLoan;
            txtExpectedReturnDate.EditValue = payment.ExpectedReturnDate;
            if (isApprovalView)
            {
                lblMessage.Text = string.Empty;
                //if (findedItem != null && findedItem.EnumFlowState != EnumDataFlowState.审批通过)
                //{
                //    lblMessage.Text = "预算单还未审批通过";
                //}
                if (txtAfterPaymentBalance.Value < 0)
                {
                    if (!string.IsNullOrEmpty(lblMessage.Text))
                    {
                        lblMessage.Text += "\r\n";
                    }
                    if (this.caculator.AdvancePayment > 0)
                    {
                        lblMessage.Text += "【警告】启用压缩后预付款支付后余额小于0";
                    }
                    else
                    {
                        lblMessage.Text += "【警告】支付后余额小于0";
                    }
                }
            }
        }

        public Budget SelectedBudgetById(int budgetId)
        {


            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            Budget findedItem = null;
            if (budgetList != null)
            {
                findedItem = budgetList.Find(o => o.ID == budgetId);
            }
            this.cboBudget.EditValue = findedItem;
            return findedItem;
        }

        public void SetBudgetEditable(bool editable = false)
        {
            this.cboBudget.Properties.ReadOnly = !editable;
        }

        private void BindingBankInfoDetail(string detail)
        {
            List<InvoiceInfo> invoiceInfoList;
            if (!string.IsNullOrEmpty(detail))
            {
                invoiceInfoList = detail.ToObjectList<List<InvoiceInfo>>();
            }
            else
            {
                invoiceInfoList = new List<InvoiceInfo>();
            }

            this.gridInvoiceNumber.DataSource = new BindingList<InvoiceInfo>(invoiceInfoList);
            this.gvInvoiceNumber.RefreshData();
        }

        private string GetInvoiceNumberDetailString()
        {
            this.gvInvoiceNumber.CloseEditor();
            var dataSource = (IEnumerable<InvoiceInfo>)gridInvoiceNumber.DataSource;
            if (dataSource != null)
            {
                return dataSource.ToJson<IEnumerable<InvoiceInfo>>();
            }
            else
            {
                return "";
            }
        }

        public bool CheckInputData()
        {
            this.dxErrorProvider1.ClearErrors();
            Supplier currentSupplier = cboSupplier.EditValue as Supplier;
            if (cboSupplier.EditValue as Supplier == null)
            {
                this.dxErrorProvider1.SetError(cboSupplier, "请选择供应商。");
            }

            //if (txtBankName.EditValue as BankInfo == null)
            //{
            //    this.dxErrorProvider1.SetError(txtBankName, "请选择付款开户行。");
            //}

            Budget selectedBudget = cboBudget.EditValue as Budget;
            if (selectedBudget == null)
            {
                this.dxErrorProvider1.SetError(cboBudget, "请选择合同信息。");
            }
            else if (EnumFlowNames.预算单审批流程.ToString().Equals(selectedBudget.FlowName) && !selectedBudget.EnumFlowState.Equals(EnumDataFlowState.审批通过))
            {
                this.dxErrorProvider1.SetError(cboBudget, string.Format("{0}还未审批结束，不允许付款。", EnumFlowNames.预算单审批流程));
            }
            else if (EnumFlowNames.预算单修改流程.ToString().Equals(selectedBudget.FlowName) && !selectedBudget.EnumFlowState.Equals(EnumDataFlowState.审批不通过))
            {
                this.dxErrorProvider1.SetError(cboBudget, string.Format("{0}还未审批结束，不允许付款。", EnumFlowNames.预算单修改流程));
            }
            else if (EnumFlowNames.预算单删除流程.ToString().Equals(selectedBudget.FlowName) && !selectedBudget.EnumFlowState.Equals(EnumDataFlowState.审批不通过))
            {
                this.dxErrorProvider1.SetError(cboBudget, string.Format("{0}还未审批结束，不允许付款。", EnumFlowNames.预算单删除流程));
            }

            if (cboPaymentMethod.EditValue == null || string.IsNullOrEmpty(cboPaymentMethod.EditValue.ToString()))
            {
                this.dxErrorProvider1.SetError(cboPaymentMethod, "请选择付款方式。");
            }
            decimal taxRebateRate = 0;
            if (txtTaxRebateRate.EditValue == null || !decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate))
            {
                this.dxErrorProvider1.SetError(txtTaxRebateRate, "请选择退税率。");
            }
            if (txtOriginalCoin.Value == 0)
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
            //if (cboPayingBank.SelectedItem == null || string.IsNullOrEmpty(cboPayingBank.SelectedItem.ToString()))
            //{
            //    this.dxErrorProvider1.SetError(cboPayingBank, "请输入付款银行。");
            //}
            if (currentSupplier != null && currentSupplier.SupplierType == (int)EnumSupplierType.临时供方)
            {
                decimal totalAmount = txtCNY.Value + temporarySupplierPaymenttotalAmount;
                if (totalAmount > temporarySupplierPaymenttotalAmountMaxValue)
                {
                    this.dxErrorProvider1.SetError(txtCNY, string.Format("当前临时供方已付款{0}，加上当前付款金额已超过最大限制。", temporarySupplierPaymenttotalAmount));
                }
            }
            UseMoneyType umt = cboMoneyUsed.EditValue as UseMoneyType;
            if (umt == null || string.IsNullOrEmpty(umt.Name.Trim()))
            {
                this.dxErrorProvider1.SetError(cboMoneyUsed, "请选择用款类型。");
            }
            else
            {
                CheckUsage(umt.Name);
                var ignoreUmtList = umtList.Where(ut => ut.Type == PaymentType.运杂费 || ut.Type == PaymentType.佣金 || ut.Type == PaymentType.暂付款);
                if (!ignoreUmtList.Any(o => o.Name.Equals(umt.Name)) && !dxErrorProvider1.HasErrors)
                {
                    if (txtAfterPaymentBalance.Value < 0)
                    {
                        string message = WarningMessage2;
                        if (this.caculator.AdvancePayment > 0)
                        {
                            message = WarningMessage3;
                        }
                        XtraMessageBox.Show(message);
                        this.dxErrorProvider1.SetError(txtAfterPaymentBalance, message);
                    }
                    //else if (txtAfterPaymentBalance.Value < 0 && txtAdvancePayment.Value - txtIgnoreTransportationExpensesPaymentMoneyAmount.Value < 0)
                    //{
                    //    XtraMessageBox.Show(WarningMessage);
                    //    this.dxErrorProvider1.SetError(txtIgnoreTransportationExpensesPaymentMoneyAmount, WarningMessage);
                    //    this.dxErrorProvider1.SetError(txtAdvancePayment, WarningMessage);
                    //}
                }
            }
            return dxErrorProvider1.HasErrors;
        }

        const string WarningMessage2 = "不能支付，付款后的支付后余额小于0";
        const string WarningMessage3 = "不能支付，付款后的启用压缩后预付款支付后余额小于0";
        const string WarningMessage = "不能支付，支付后余额小于0，且累计支付金额（不含运杂费）大于预付款";

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

                umtList = scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());
                imtList = scm.GetSystemConfigValue<List<InMoneyType>>(EnumSystemConfigNames.收款类型.ToString());
                this.cboMoneyUsed.Properties.Items.Clear();
                if (umtList != null)
                {
                    this.cboMoneyUsed.Properties.Items.AddRange(umtList);
                }

                List<string> bankNameList = scm.GetSystemConfigValue<List<string>>(EnumSystemConfigNames.银行名称.ToString());
                if (bankNameList != null)
                {
                    foreach (var bankName in bankNameList)
                    {
                        cboPayingBank.Properties.Items.Add(bankName);
                    }
                }
                budgetList = bm.GetBudgetListBySaleman(RunInfo.Instance.CurrentUser.UserName);

                this.cboBudget.Properties.DataSource = budgetList;
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
            if (inProductDetailList != null && inProductDetailList.Count > 0)
            {
                foreach (var v in inProductDetailList)
                {
                    if (!txtTaxRebateRate.Properties.Items.Contains(v.TaxRebateRate))
                    {
                        txtTaxRebateRate.Properties.Items.Add(v.TaxRebateRate);
                    }
                }

                txtTaxRebateRate.SelectedIndex = 0;
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
            this.CurrentPaymentNotes.DeptID = int.Parse(this.cboDepartment.Tag.ToString());

            this.CurrentPaymentNotes.SupplierID = (this.cboSupplier.EditValue as Supplier).ID;
            Budget budget = this.cboBudget.EditValue as Budget;
            this.CurrentPaymentNotes.BudgetID = budget.ID;
            this.CurrentPaymentNotes.ContractNO = budget.ContractNO;
            if (cboPayingBank.SelectedItem != null)
            {
                this.CurrentPaymentNotes.PayingBank = this.cboPayingBank.SelectedItem.ToString();
            }
            this.CurrentPaymentNotes.ExchangeRate = float.Parse(this.txtExchangeRate.EditValue.ToString());
            this.CurrentPaymentNotes.OriginalCoin = this.txtOriginalCoin.Value;
            this.CurrentPaymentNotes.Currency = this.cboCurrency.SelectedItem.ToString();
            this.CurrentPaymentNotes.PaymentMethod = this.cboPaymentMethod.EditValue.ToString();
            this.CurrentPaymentNotes.Description = txtDescription.Text.Trim();
            this.CurrentPaymentNotes.HasInvoice = (bool)chkHasInvoice.EditValue;
            this.CurrentPaymentNotes.IsDrawback = (bool)chkIsDrawback.EditValue;
            this.CurrentPaymentNotes.VatOption = this.vatOption;
            BankInfo bankInfo = this.txtBankName.EditValue as BankInfo;
            if (bankInfo != null)
            {
                this.CurrentPaymentNotes.BankName = bankInfo.Name;
            }
            this.CurrentPaymentNotes.BankNO = this.txtBankNO.Text;

            this.CurrentPaymentNotes.IsIOU = this.chkIsIOU.Checked;
            this.CurrentPaymentNotes.RepayLoan = this.chkRepayLoan.Checked;

            this.CurrentPaymentNotes.InvoiceNumber = GetInvoiceNumberDetailString();
            this.CurrentPaymentNotes.ExpectedReturnDate = DateTime.Parse(this.txtExpectedReturnDate.EditValue.ToString());
        }

        private void CheckUsage(string usageName)
        {
            string message = string.Empty;
            if (usageName == "辅料款")
            {
                decimal price = this.currentBudget.InProductList.Sum(o => o.RawMaterials + o.SubsidiaryMaterials);
                if (price == 0)
                {
                    message = "不能支付，预算单中没有体现原料、辅料价格，如需付款请修改预算单。";
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                }
                return;
            }
            else if (umtList.Where(o => o.Type == PaymentType.运杂费).Any(t => t.Name == usageName))
            {
                if (this.currentBudget.Premium == 0)
                {
                    message = "不能支付，预算单中没有体现运杂费，如需付款请修改预算单。";
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                    return;
                }
                decimal money = caculator.GetUsagePayMoney(usageName);
                if (money + txtCNY.Value > this.currentBudget.Premium)
                {
                    message = string.Format("不能支付，预算单中运杂费为[{0}]，加上当前付款金额即将超支预算金额，如需付款请修改预算单。", this.currentBudget.Premium, money);
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                    return;
                }
            }
            else if (usageName == "进料款")
            {
                if (this.currentBudget.FeedMoney == 0)
                {
                    message = "不能支付，预算单中没有体现进料款，如需付款请修改预算单。";
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                    return;
                }
                decimal money = caculator.GetUsagePayMoney(usageName);
                if (money + txtCNY.Value > this.currentBudget.FeedMoney)
                {
                    message = string.Format("不能支付，预算单中进料款为[{0}]，加上当前付款金额即将超支预算金额，如需付款请修改预算单。", this.currentBudget.FeedMoney, money);
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                    return;
                }
            }
            else if (umtList.Where(o => o.Type == PaymentType.佣金).Any(o => o.Name == usageName))
            {
                if (this.currentBudget.Commission == 0)
                {
                    message = "不能支付，预算单中没有体现佣金，如需付款请修改预算单。";
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                    return;
                }
                //暂时先放开佣金付款超额
                decimal money = caculator.GetUsagePayMoney(umtList.Where(o => o.Type == PaymentType.佣金).Select(o => o.Name).ToList());
                if (money + txtCNY.Value > this.currentBudget.Commission)
                {
                    message = string.Format("不能支付，预算单中佣金为[{0}]，加上当前付款金额即将超支预算金额，如需付款请修改预算单。", this.currentBudget.Commission, money);
                    this.dxErrorProvider1.SetError(cboMoneyUsed, message);
                    XtraMessageBox.Show(message);
                    return;
                }
            }
        }

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
                var paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(currentBudget.ID).ToList();
                dteValidity.EditValue = currentBudget.Validity.Value;
                //过滤当前自己的单据
                if (CurrentPaymentNotes != null)
                {
                    paymentNotes = paymentNotes.Where(o => !(o.ID.Equals(CurrentPaymentNotes.ID))).ToList<PaymentNotes>();
                }
                var receiptList = rm.GetBudgetBillListByBudgetId(currentBudget.ID);
                currentBudget = bm.GetBudget(currentBudget.ID);

                List<Supplier> budgetSupplierList = sm.GetSupplierListByBudgetId(currentBudget.ID);
                //budgetSupplierList.RemoveAll(o => !o.IsQualified);
                budgetSupplierList.AddRange(supplierList.Where(o => !budgetSupplierList.Exists(bs => o.ID.Equals(bs.ID))));
                this.cboSupplier.Properties.DataSource = budgetSupplierList;

                caculator = new OutMoneyCaculator(currentBudget, paymentNotes, receiptList, valueAddedTaxRate, umtList, imtList);

                InitTaxRebateRateList(currentBudget.InProductDetail);

                //生成付款单号
                this.txtVoucherNo.Text = string.Format("{0}-{1}", currentBudget.ContractNO.Trim(), cm.GetNewCode(CodeType.PayementCode).ToString().PadLeft(4, '0'));

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
            if (txtTaxRebateRate.EditValue != null && chkIsDrawback.Checked)
            {
                decimal.TryParse(txtTaxRebateRate.EditValue.ToString(), out taxRebateRate);
            }
            if (this.txtCNY.Value >= 0)//(this.txtCNY.Value != 0)如果为0需要还原计算处理。
            {
                caculator.ApplyForPayment(this.txtCNY.Value, taxRebateRate, this.chkIsDrawback.Checked);
            }
            //退税总金额=已付金额+当前付款退税金额
            this.txtAmountTaxRebate.EditValue = caculator.AllTaxes;

            //总付款金额=已付金额+当前付款金额
            txtAmountPaymentMoney.EditValue = caculator.PaymentMoneyAmount + this.txtCNY.Value;

            //支付后余额（2020-03-17改为启用预付款支付后余额）
            if (caculator.AdvancePayment > 0)
            {
                this.txtAfterPaymentBalance.EditValue = caculator.EnablingAdvancePayment;//caculator.Balance;
                lciPaymentBalance.Text = "启用预付款支付后余额";
            }
            else
            {
                this.txtAfterPaymentBalance.EditValue = caculator.Balance;
                lciPaymentBalance.Text = "支付后余额";
            }
            //支付后留利余额
            this.txtRetainedInterestBalance.EditValue = caculator.RetainedInterestBalance;

            UseMoneyType umt = cboMoneyUsed.EditValue as UseMoneyType;

            if (umt == null || string.IsNullOrEmpty(umt.Name) || umtList.Where(o => o.Type == PaymentType.运杂费).Any(t => t.Name == umt.Name))
            {
                //不含运费付款金额。
                txtIgnoreTransportationExpensesPaymentMoneyAmount.EditValue = caculator.IgnoreTransportationExpensesPaymentMoneyAmount;
            }
            else
            {
                //不含运费付款金额。
                txtIgnoreTransportationExpensesPaymentMoneyAmount.EditValue = caculator.IgnoreTransportationExpensesPaymentMoneyAmount + this.txtCNY.Value;
            }
        }

        private decimal temporarySupplierPaymenttotalAmount;

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            Supplier editValue = (Supplier)cboSupplier.EditValue;
            if (editValue != null)
            {
                txtBankName.Properties.DataSource = editValue.BankInfoDetail.ToObjectList<List<BankInfo>>();
                if (editValue.SupplierType == (int)EnumSupplierType.临时供方)
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

        private void btn_budgetView_Click(object sender, EventArgs e)
        {
            if (currentBudget == null)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }
            var budget = bm.GetBudget(currentBudget.ID);
            if (budget == null)
            {
                XtraMessageBox.Show("您选择查看详情的项不存在，请刷新数据。");
                return;
            }
            frmBudgetDatail form = new frmBudgetDatail();
            form.WorkModel = EditFormWorkModels.View;
            form.CurrentBudget = budget;
            form.ShowDialog(this);
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

        private void txtTaxRebateRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcPaymentTaxRebate();
        }

        private void chkIsDrawback_CheckedChanged(object sender, EventArgs e)
        {
            CalcPaymentTaxRebate();
        }

        private List<string> ignoreItems = new List<string>() { "货款", "面辅料" };

        private List<string> ignoreMessageUsageNameList = new List<string>() { "货款", "辅料款", "预付货款", "预付辅料款" };

        private void cboMoneyUsed_EditValueChanged(object sender, EventArgs e)
        {
            UseMoneyType selectedItem = this.cboMoneyUsed.EditValue as UseMoneyType;
            if (selectedItem != null)
            {
                if (!isApprovalView)
                {
                    if (!ignoreMessageUsageNameList.Contains(selectedItem.Name))
                    {
                        lciMessage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }
                    else
                    {
                        lciMessage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                }
                if (selectedItem.ProvideInvoice)
                {
                    gridInvoiceNumber.DataSource = new BindingList<InvoiceInfo>();
                    lciInvoiceNumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    gridInvoiceNumber.DataSource = new BindingList<InvoiceInfo>();
                    lciInvoiceNumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (ignoreItems.Contains(selectedItem.Name))
                {
                    this.chkIsIOU.Properties.ReadOnly = true;
                    this.txtExpectedReturnDate.Properties.ReadOnly = true;
                }
                else if (this.WorkModel != EditFormWorkModels.View)
                {
                    //this.chkIsIOU.Properties.ReadOnly = false;
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

        private void btnSingleBudgetFinalAccount_Click(object sender, EventArgs e)
        {
            if (currentBudget == null)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }
            frmSingleBudgetFinalAccountsReport finalAccountReportForm = new frmSingleBudgetFinalAccountsReport();
            finalAccountReportForm.CurrentBudget = currentBudget;
            finalAccountReportForm.ShowDialog();
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

        private void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvInvoiceNumber.FocusedRowHandle < 0)
            {
                gvInvoiceNumber.CloseEditor();
                gvInvoiceNumber.CancelUpdateCurrentRow();
            }
            else
            {
                gvInvoiceNumber.DeleteRow(gvInvoiceNumber.FocusedRowHandle);
            }
            gvInvoiceNumber.ClearColumnErrors();
        }

        private void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void chkIsIOU_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.chkIsIOU.Checked)
            //{
            //    lciRepayLoan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}
            //else
            //{
            //    lciRepayLoan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}
        }

    }
}