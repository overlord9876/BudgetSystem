using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using Newtonsoft.Json;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.InMoney
{
    public partial class ucAccountAdjustmentEdit : DataControl
    {
        private SingleBudgetReportHelper reportHelper;
        private decimal valueAddedTaxRate;
        private ReceiptMgmtManager arm = new ReceiptMgmtManager();
        private Bll.UserManager um = new UserManager();
        private InvoiceManager im = new InvoiceManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        private PaymentNotesManager pnm = new PaymentNotesManager();
        private CommonManager commonManager = new CommonManager();
        private AccountAdjustmentManager aamManager = new AccountAdjustmentManager();
        private AccountAdjustment _currentAdjustment;
        private List<AccountAdjustmentDetail> _adjustmentDetail;
        private List<InMoneyType> imTypeList;
        private List<UseMoneyType> useMoneyTypeList;

        public decimal NotSplitCNYMoney { get; private set; }
        private Budget currentBudget;
        private PaymentNotes currentPayment;
        private BudgetBill currentBudgetBill;
        private Invoice currentInvoice;
        private List<Budget> budgetList;
        private List<Budget> detailBudgetList;

        private EditFormWorkModels _workModel;

        public EditFormWorkModels WorkModel
        {
            get { return this._workModel; }
            set
            {
                this._workModel = value;
                InitControlState();
            }
        }

        public AdjustmentRole EnumRole { get; private set; } = AdjustmentRole.业务员调账;

        public AccountAdjustment Adjustment
        {
            get
            {
                return this._currentAdjustment;
            }
            private set { this._currentAdjustment = value; }
        }

        public List<AccountAdjustmentDetail> AdjustmentDetail
        {
            get
            {
                return this._adjustmentDetail;
            }
            private set { this._adjustmentDetail = value; }
        }

        public AdjustmentType AdjustmentType { get; set; }

        public ucAccountAdjustmentEdit()
        {
            InitializeComponent();
            if (!frmBaseForm.IsDesignMode)
            {
                cboType.Properties.Items.AddRange(Enum.GetNames(typeof(AdjustmentType)).Select(o => o.Trim()).ToArray());
                lblMessage.Text = "";
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                RegisterEventHandler();
                try
                {
                    this.cboType.SelectedIndex = 0;

                    reportHelper = new SingleBudgetReportHelper();
                    this.txtCreateUser.Text = RunInfo.Instance.CurrentUser.RealName;
                    deCreateTimestamp.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtCode.Text = DateTime.Now.ToString("yyyyMMddHHmmss");

                    useMoneyTypeList = this.scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());
                    imTypeList = this.scm.GetSystemConfigValue<List<InMoneyType>>(EnumSystemConfigNames.收款类型.ToString());
                }
                catch (Exception ex)
                {
                    RunInfo.Instance.Logger.LogError(ex);
                }
            }
        }

        private void RegisterEventHandler()
        {
            this.gvConstSplit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvConstSplit_ValidateRow);
            this.gvConstSplit.CellValueChanging += GvConstSplit_CellValueChanging;
            this.gvConstSplit.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvConstSplit_CellValueChanged);
            this.gvConstSplit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvConstSplit_InvalidRowException);
            this.gvConstSplit.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvConstSplit_InitNewRow);
            this.riLinkEditConstInDelete.Click += new EventHandler(riLinkEditConstInDelete_Click);
            this.riLinkEditConstInDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(riLinkEditConstInDelete_CustomDisplayText);
            this.budgetLink.Click += BudgetLink_Click;
            this.budgetLink.CustomDisplayText += BudgetLink_CustomDisplayText;
            this.gvConstSplit.ShowingEditor += new CancelEventHandler(gvConstSplit_ShowingEditor);
            this.gvConstSplit.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gvConstSplit_CustomSummaryCalculate);
            this.gvDetail.CustomDrawCell += gvDetail_CustomDrawCell;
            this.txtSplitOriginalCoin.EditValueChanged += TxtSplitOriginalCoin_EditValueChanged;
            this.txtSplitOriginalCoin.EditValueChanging += TxtSplitOriginalCoin_EditValueChanging;
            this.txtSplitCNY.EditValueChanged += TxtSplitCNY_EditValueChanged;
            this.cboBudget.QueryPopUp += CboBudget_QueryPopUp;
            this.cboBudget.EditValueChanging += CboBudget_EditValueChanging;
            this.cboInvoice.QueryPopUp += CboPayment_QueryPopUp;
            this.cboPayment.QueryPopUp += CboPayment_QueryPopUp;
            this.cboBudgetBill.QueryPopUp += CboPayment_QueryPopUp;
        }

        public void SetAdjustmentType(AdjustmentType atType)
        {
            this.AdjustmentType = atType;
            this.cboType.EditValue = atType.ToString();
        }

        public void SetAdjustmentRole(AdjustmentRole enumRole)
        {
            this.EnumRole = enumRole;
        }

        public void InitData(AccountAdjustment accountAdjustment)
        {
            this._currentAdjustment = accountAdjustment;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                if (RunInfo.Instance.GetAdjustmentRole() == AdjustmentRole.业务员调账)
                {
                    budgetList = bm.GetBudgetListBySaleman(RunInfo.Instance.CurrentUser.UserName);
                }
                else
                {
                    BudgetQueryCondition condition = new BudgetQueryCondition();
                    condition.IsGeneralManagerApproval = true;
                    condition.State = (int)EnumBudgetState.进行中;
                    budgetList = bm.GetAllBudget(condition);
                }
                if (budgetList == null)
                {
                    budgetList = new List<Budget>();
                }
                if (_currentAdjustment != null && !budgetList.Any(a => a.ID.Equals(_currentAdjustment.BudgetID)))
                {
                    var budget = bm.GetBudget(_currentAdjustment.BudgetID);
                    if (budget != null)
                    {
                        budgetList.Add(budget);
                    }
                }
            }
            else
            {
                this.EnumRole = this._currentAdjustment.EnumRole;
                budgetList = new List<Budget>();
                var budget = bm.GetBudget(_currentAdjustment.BudgetID);
                if (budget != null)
                {
                    budgetList.Add(budget);
                }
            }
            this.cboBudget.Properties.DataSource = budgetList;

            valueAddedTaxRate = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税税率.ToString());



            List<AccountAdjustmentDetail> details = null;
            if (accountAdjustment != null)
            {
                details = aamManager.GetAccountAdjustmentDetailByTypeId(accountAdjustment.ID, accountAdjustment.Type);
                if (this.WorkModel != EditFormWorkModels.New)
                {
                    if (accountAdjustment.Type == AdjustmentType.交单)
                    {
                        this.currentInvoice = im.GetInvoice(accountAdjustment.RelationID);
                    }
                    else if (accountAdjustment.Type == AdjustmentType.付款)
                    {
                        this.currentPayment = pnm.GetPaymentNoteById(accountAdjustment.RelationID);
                    }
                    else
                    {
                        this.currentBudgetBill = arm.GetBudgetBillBybbId(accountAdjustment.RelationID);
                    }
                }
                if (details != null)
                {
                    if (detailBudgetList == null)
                    {
                        detailBudgetList = new List<Budget>();
                    }
                    foreach (var detail in details)
                    {
                        var budget = bm.GetBudget(detail.BudgetID);
                        if (budget != null)
                        {
                            detailBudgetList.Add(budget);
                        }
                    }
                }
            }
            BindAccountAdjustment(accountAdjustment, details);
            //if (this.WorkModel == EditFormWorkModels.View || this.WorkModel == EditFormWorkModels.Print && accountAdjustment != null)
            //{
            //    var users = um.GetAllEnabledUser();
            //    var user = users?.FirstOrDefault(o => o.UserName == accountAdjustment.CreateUser);
            //    txtDescription.Text = frmAccountAdjustmentPrint.GeneraorMessage(accountAdjustment, details, user, true) + "\r\n" + accountAdjustment.Remark;
            //}
        }

        public void FillData()
        {
            if (Adjustment == null)
            {
                Adjustment = new AccountAdjustment();
                Adjustment.CreateDate = commonManager.GetDateTimeNow();
                Adjustment.CreateUser = RunInfo.Instance.CurrentUser.UserName;
            }
            Adjustment.Remark = this.txtDescription.Text.Trim();
            Adjustment.BudgetID = (this.cboBudget.EditValue as Budget).ID;
            this.Adjustment.ContractNO = (this.cboBudget.EditValue as Budget).ContractNO;
            Adjustment.Name = txtRelationName.Text.Trim();
            Adjustment.Type = (AdjustmentType)Enum.Parse(typeof(AdjustmentType), cboType.Text, true);
            if (Adjustment.Type == AdjustmentType.付款)
            {
                Adjustment.RelationID = (cboPayment.EditValue as PaymentNotes).ID;
            }
            else if (Adjustment.Type == AdjustmentType.收款)
            {
                Adjustment.RelationID = (cboBudgetBill.EditValue as BudgetBill).ID;
            }
            else
            {
                Adjustment.RelationID = (cboInvoice.EditValue as Invoice).ID;
            }

            this.Adjustment.SplitOriginalCoin = this.txtSplitOriginalCoin.Value;
            this.Adjustment.SplitCNY = this.txtSplitCNY.Value;
            this.Adjustment.ExchangeRate = this.txtExchangeRate.Value;
            this.Adjustment.Currency = this.txtCurrency.Text;
            this.Adjustment.AlreadySplitOriginalCoin = txtAlreadySplitOriginalCoin.Value;
            this.Adjustment.AlreadySplitCNY = txtAlreadySplitCNYMoney.Value;
            this.Adjustment.Code = txtCode.Text.Trim();
            this.Adjustment.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
            this.AdjustmentDetail = (this.gvConstSplit.DataSource as BindingList<AccountAdjustmentDetail>)?.ToList();
            if (this.txtAlreadySplitCNYMoney.Value == this.txtSplitCNY.Value)
            {
                this.Adjustment.State = AccountAdjustmentState.调账完成;
            }
            else
            {
                this.Adjustment.State = AccountAdjustmentState.调账中;
            }
            this.Adjustment.EnumRole = EnumRole;
        }

        public void BindAccountAdjustment(AccountAdjustment item, List<AccountAdjustmentDetail> details = null)
        {
            this.Adjustment = item;
            try
            {
                if (Adjustment != null)
                {
                    this.cboBudget.EditValue = (this.cboBudget.Properties.DataSource as List<Budget>)?.FirstOrDefault(o => o.ID == Adjustment.BudgetID);
                    this.cboType.EditValue = Adjustment.Type.ToString();
                    if (Adjustment.Type == AdjustmentType.付款)
                    {
                        this.cboPayment.EditValue = (this.cboPayment.Properties.DataSource as IEnumerable<PaymentNotes>)?.FirstOrDefault(o => o.ID == Adjustment.RelationID);
                    }
                    else if (Adjustment.Type == AdjustmentType.收款)
                    {
                        this.cboBudgetBill.EditValue = (this.cboBudgetBill.Properties.DataSource as List<BudgetBill>)?.FirstOrDefault(o => o.ID == Adjustment.RelationID);
                    }
                    else
                    {
                        this.cboInvoice.EditValue = (this.cboInvoice.Properties.DataSource as List<Invoice>)?.FirstOrDefault(o => o.ID == Adjustment.RelationID);
                    }
                    this.txtExchangeRate.EditValue = this.Adjustment.ExchangeRate;
                    this.txtSplitOriginalCoin.EditValue = this.Adjustment.SplitOriginalCoin;
                    this.txtSplitCNY.EditValue = this.Adjustment.SplitCNY;
                    this.txtCode.Text = this.Adjustment.Code;
                    this.deCreateTimestamp.EditValue = Adjustment.CreateDate;
                    this.txtCreateUser.Text = string.Format("[{0}]-[{1}]", Adjustment.CreateUser, Adjustment.CreateRealUserName);
                    if (this.WorkModel == EditFormWorkModels.Modify)
                    {
                        this.txtDescription.Text = Adjustment.Remark;
                    }
                    else
                    {
                        var users = um.GetAllEnabledUser();
                        var user = users?.FirstOrDefault(o => o.UserName == Adjustment.CreateUser);
                        this.txtDescription.Text = frmAccountAdjustmentPrint.GeneraorMessage2(Adjustment, details, user, true);
                        this.txtDescription.Text += Adjustment.Remark;
                    }
                    this.txtAlreadySplitOriginalCoin.EditValue = this.Adjustment.AlreadySplitOriginalCoin;
                    this.txtAlreadySplitCNYMoney.EditValue = this.Adjustment.AlreadySplitCNY;
                    this.AdjustmentDetail = details;
                    if (details == null)
                    {
                        this.gcConstSplit.DataSource = new BindingList<AccountAdjustmentDetail>();
                    }
                    else
                    {
                        var budgetList = this.gridBudget.DataSource as List<Budget>;
                        if (budgetList != null)
                        {
                            AdjustmentDetail.ForEach(o =>
                            {
                                o.RelationBudget = budgetList.FirstOrDefault(b => b.ID == o.BudgetID);
                                if (o.RelationBudget != null)
                                {
                                    string message = LoadCurrentDetail(o.RelationBudget, o);
                                    lblMessage.Text += message;
                                }
                            });
                        }
                        this.gcConstSplit.DataSource = new BindingList<AccountAdjustmentDetail>(AdjustmentDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                RunInfo.Instance.Logger.LogError(ex);
            }
        }

        public void ClearError()
        {
            this.gvConstSplit.ClearColumnErrors();
            this.gvConstSplit.CloseEditor();
            this.gvConstSplit.CancelUpdateCurrentRow();
        }

        public void BindAccountAdjustmentByID(int bsID)
        {
            this.Adjustment = aamManager.GetAccountAdjustment(bsID, AdjustmentType);

            this.InitData(Adjustment);
        }

        public override void BindingData(int dataID)
        {
            base.BindingData(dataID);
            BindAccountAdjustmentByID(dataID);
        }

        public bool CheckUIInput()
        {
            this.dxErrorProvider1.ClearErrors();

            if ((txtCode.EditValue as Customer) == null)
            {
                dxErrorProvider1.SetError(txtCode, "请输入调账编号");
            }
            if (string.IsNullOrEmpty(cboType.EditValue?.ToString()))
            {
                dxErrorProvider1.SetError(cboType, "请选择调账方式");
            }
            if (this.AdjustmentType == AdjustmentType.收款)
            {
                ValidationBalance();
            }
            if (this.WorkModel == EditFormWorkModels.Modify)
            {
                var dataSource = (BindingList<AccountAdjustmentDetail>)gcConstSplit.DataSource;
                decimal splitCNY = 0;
                decimal splitCoinMoney = 0;
                if (dataSource != null)
                {
                    splitCNY = Math.Round(dataSource.Where(o => !o.IsDelete).Sum(o => o.OriginalCoin * o.ExchangeRate), 2);

                    splitCoinMoney = dataSource.Where(o => !o.IsDelete).Sum(o => o.OriginalCoin);
                }
            }
            return !dxErrorProvider1.HasErrors;
        }

        private void InitControlState()
        {
            this.txtCreateUser.Properties.ReadOnly = true;
            this.deCreateTimestamp.Properties.ReadOnly = true;
            this.gcConstSplit.DataSource = new BindingList<AccountAdjustmentDetail>();
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.txtCreateUser.Text = string.Format("[{0}]-[{1}]", RunInfo.Instance.CurrentUser.UserName, RunInfo.Instance.CurrentUser.RealName);
                DateTime datetimeNow = commonManager.GetDateTimeNow();
                this.deCreateTimestamp.EditValue = datetimeNow;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.txtCode.Properties.ReadOnly = true;
                this.cboType.Properties.ReadOnly = true;
                this.cboBudget.Properties.ReadOnly = true;
                this.cboPayment.Properties.ReadOnly = true;
                this.cboBudgetBill.Properties.ReadOnly = true;
                this.cboPayment.Properties.ReadOnly = true;
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
            }
            else if (this.WorkModel == EditFormWorkModels.Print)
            {
                SetReadOnly();
            }

        }

        private void SetReadOnly()
        {
            layoutControl1.AutoScroll = true;
            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
            this.gvConstSplit.OptionsBehavior.Editable = false;
        }

        private string CalcSplitMoney()
        {
            string message = string.Empty;
            var dataSource = gcConstSplit.DataSource as BindingList<AccountAdjustmentDetail>;

            if (dataSource != null)
            {
                txtAlreadySplitCNYMoney.EditValue = dataSource.Where(o => !o.IsDelete).Sum(o => o.CNY);

                txtAlreadySplitOriginalCoin.EditValue = dataSource.Where(o => !o.IsDelete).Sum(o => o.OriginalCoin);
            }
            if (txtAlreadySplitCNYMoney.Value > txtSplitCNY.Value)
            {
                ErrorColumn = this.bgcConstCNY;
                return "调账人民币合计金额不允许大于调账金额总额";
            }

            //txtNotSplitCNY.EditValue = txtSplitCNY.Value - txtAlreadySplitCNYMoney.Value;
            return message;
        }

        private string LoadCurrentDetail(Budget relationBudget, AccountAdjustmentDetail currentDetail)
        {
            if (relationBudget == null || currentDetail == null)
            {
                return string.Empty;
            }
            BindingList<BudgetSingleReport> reportList = this.gcDetail.DataSource as BindingList<BudgetSingleReport>;
            if (reportList == null)
            {
                reportList = new BindingList<BudgetSingleReport>();
            }
            BudgetSingleReport report = reportList.FirstOrDefault(p => p.BudgetId == relationBudget.ID);

            this.reportHelper.LoadData(relationBudget, null, currentDetail);
            currentDetail.Balance = this.reportHelper.Balance - currentDetail.CNY;

            int index = reportList.IndexOf(report);
            if (index < 0)
            {
                reportList.Add(this.reportHelper.CurrentBudgetReport);
            }
            else
            {
                reportList.RemoveAt(index);
                reportList.Insert(index, this.reportHelper.CurrentBudgetReport);
            }
            this.gcDetail.DataSource = reportList;
            this.gvDetail.BestFitColumns();
            this.gvDetail.RefreshData();
            string message = string.Empty;
            if ((this.reportHelper.Balance - currentDetail.CNY) < 0)
            {
                message = $"合同[{relationBudget.ContractNO}]账上余额为{ this.reportHelper.Balance}，调入付款金额{currentDetail.CNY}后余额小于0；";
            }
            return message;
        }

        private void gvConstSplit_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            AccountAdjustmentDetail item = this.gvConstSplit.GetRow(e.RowHandle) as AccountAdjustmentDetail;
            item.OperatorModel = DataOperatorModel.Add;
            item.ExchangeRate = txtExchangeRate.Value;
            item.Operator = RunInfo.Instance.CurrentUser.UserName;
            item.OperatorRealName = RunInfo.Instance.CurrentUser.RealName;
            item.OperatorDate = commonManager.GetDateTimeNow();
            item.Type = this.AdjustmentType;
            item.VatOption = this.valueAddedTaxRate;
            if (item.Type == AdjustmentType.收款)
            {
                item.MoneyUsed = currentBudgetBill.NatureOfMoney;
                item.Name = currentBudgetBill.Customer;
                item.RelationID = currentBudgetBill.ID;
            }
            else if (item.Type == AdjustmentType.付款)
            {
                item.IsDrawback = currentPayment.IsDrawback;
                item.MoneyUsed = currentPayment.MoneyUsed;
                item.Name = currentPayment.SupplierName;
                item.RelationID = currentPayment.ID;
                item.TaxRebateRate = (decimal)currentPayment.TaxRebateRate;
            }
            else
            {
                item.Name = currentInvoice.SupplierName;
                item.RelationID = currentInvoice.ID;
                item.TaxRebateRate = (decimal)currentInvoice.TaxRebateRate;
            }
        }

        private DevExpress.XtraGrid.Columns.GridColumn ErrorColumn;
        private Budget oldSelectedBudget;
        private void gvConstSplit_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvConstSplit.SetColumnError(ErrorColumn, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void GvConstSplit_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == bgcBudget)
            {
                this.oldSelectedBudget = this.gvConstSplit.GetRowCellValue(e.RowHandle, bgcBudget) as Budget;
            }
        }

        private void gvConstSplit_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gvConstSplit.ClearColumnErrors();
            if (e.Column == bgcConstCNY)
            {
                string message = CalcSplitMoney();
                if (!string.IsNullOrEmpty(message))
                {
                    gvConstSplit.SetColumnError(gcCNY, message);
                    dxErrorProvider1.SetError(txtAlreadySplitCNYMoney, message);
                    XtraMessageBox.Show(message);
                    return;
                }
            }
            else if (e.Column == gcSplitConstOriginalCoin || e.Column == bgcConstExchangeRate)
            {
                decimal.TryParse(this.gvConstSplit.GetRowCellValue(e.RowHandle, gcSplitConstOriginalCoin)?.ToString() ?? "0", out decimal originalCoin);

                decimal.TryParse(this.gvConstSplit.GetRowCellValue(e.RowHandle, bgcConstExchangeRate)?.ToString() ?? "0", out decimal exchangeRate);

                decimal CNY = Math.Round(originalCoin * (decimal)exchangeRate, 2);

                this.gvConstSplit.SetRowCellValue(e.RowHandle, bgcConstCNY, CNY);

            }
            else if (e.Column == bgcBudget)
            {
                Budget budget = this.gvConstSplit.GetRowCellValue(e.RowHandle, bgcBudget) as Budget;
                int budgetId = budget?.ID ?? -1;
                if (this.oldSelectedBudget != null && this.oldSelectedBudget.ID != budgetId)
                {
                    BindingList<BudgetSingleReport> reportList = this.gcDetail.DataSource as BindingList<BudgetSingleReport>;
                    if (reportList != null)
                    {
                        this.gcDetail.DataSource = new BindingList<BudgetSingleReport>(reportList.Where(o => o.BudgetId != this.oldSelectedBudget.ID).ToList());

                        this.gvDetail.BestFitColumns();
                    }
                }
            }

            AccountAdjustmentDetail detail = this.gvConstSplit.GetRow(e.RowHandle) as AccountAdjustmentDetail;
            if (detail != null)
            {
                if (detail.OperatorModel != DataOperatorModel.Add)
                {
                    detail.OperatorDate = commonManager.GetDateTimeNow();
                    detail.OperatorModel = DataOperatorModel.Modify;
                }
                if (detail.RelationBudget != null)
                {
                    LoadCurrentDetail(detail.RelationBudget, detail);
                }
            }
        }

        private void gvConstSplit_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Budget budget = this.gvConstSplit.GetRowCellValue(e.RowHandle, this.bgcBudget) as Budget;
            AccountAdjustmentDetail detail = e.Row as AccountAdjustmentDetail;
            if (budget == null)
            {
                e.ErrorText = "请选择合同号";
                e.Valid = false;
                return;
            }
            if (detail == null)
            {
                e.ErrorText = "当前数据行错误";
                e.Valid = false;
                return;
            }

            if (detail.Type == AdjustmentType.付款)
            {
                Budget currentBudget = null;
                if (detail.BudgetID != 0)
                {
                    currentBudget = bm.GetBudget(detail.BudgetID);
                }
                else if (detail.RelationBudget != null)
                {
                    currentBudget = bm.GetBudget(detail.RelationBudget.ID);
                }

                //var paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(currentBudget.ID).ToList();

                //var receiptList = arm.GetBudgetBillListByBudgetId(currentBudget.ID);

                //var accountAdjustments = aamManager.GetBalanceAccountAdjustmentByBudgetId(currentBudget.ID);

                //var accountAdjustmentDetails = aamManager.GetBalanceAccountAdjustmentDetailByBudgetId(currentBudget.ID);

                //if (accountAdjustmentDetails == null)
                //{
                //    accountAdjustmentDetails = new List<AccountAdjustmentDetail>();
                //}
                //accountAdjustmentDetails = accountAdjustmentDetails.Where(o => o.ID != detail.ID).ToList();

                this.reportHelper.LoadData(currentBudget, null, detail);

                //提示合同余额小于0
                if (this.reportHelper.Balance - detail.CNY < 0)
                {
                    string message = $"合同[{currentBudget.ContractNO}]账上余额为{ this.reportHelper.Balance}，调入付款金额{detail.CNY}后余额小于0；";
                    lblMessage.Text += message;
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    //XtraMessageBox.Show(message);

                    //e.ErrorText = message;
                    //e.Valid = false;
                    //return;
                }
            }
            string messsage = CalcSplitMoney();
            if (!string.IsNullOrEmpty(messsage))
            {
                e.ErrorText = messsage;
                e.Valid = false;
                return;
            }
        }

        private void riLinkEditConstInDelete_Click(object sender, EventArgs e)
        {
            if (this.gvConstSplit.FocusedRowHandle < 0)
            {
                gvConstSplit.CloseEditor();
                gvConstSplit.CancelUpdateCurrentRow();
            }
            else
            {
                AccountAdjustmentDetail detail = gvConstSplit.GetRow(gvConstSplit.FocusedRowHandle) as AccountAdjustmentDetail;
                if (detail != null && detail.OperatorModel != DataOperatorModel.Add)
                {

                    if (detail.Type == AdjustmentType.收款)//只有付款调入，才考虑余额计算。
                    {
                        var currentBudget = bm.GetBudget(detail.BudgetID);
                        //var paymentNotes = pnm.GetTotalAmountPaymentMoneyByBudgetId(currentBudget.ID).ToList();

                        //var receiptList = arm.GetBudgetBillListByBudgetId(currentBudget.ID);
                        //var adjustmentList = aamManager.GetBalanceAccountAdjustmentByBudgetId(currentBudget.ID);
                        //var adjustmentDetailList = aamManager.GetBalanceAccountAdjustmentDetailByBudgetId(currentBudget.ID);
                        //if (this._currentAdjustment != null)
                        //{
                        //    adjustmentDetailList = adjustmentDetailList.Where(o => o.PID != this._currentAdjustment.ID).ToList();
                        //}
                        //List<AccountAdjustmentDetail> currentDetail = (this.gvConstSplit.DataSource as BindingList<AccountAdjustmentDetail>)?.ToList();
                        //if (currentDetail != null)
                        //{
                        //    adjustmentDetailList.AddRange(currentDetail.Where(o => o.ID != detail.ID));
                        //}
                        this.reportHelper.LoadData(currentBudget, null, detail);

                        ////OutMoneyCaculator caculator = new OutMoneyCaculator(currentBudget, paymentNotes, receiptList, valueAddedTaxRate, useMoneyTypeList, imTypeList, adjustmentList, adjustmentDetailList);
                        ////caculator.ApplyForPayment(detail.CNY, detail.TaxRebateRate, detail.IsDrawback);
                        ////TODO:暂时去掉限制。
                        if (this.reportHelper.Balance - detail.CNY < 0)
                        {
                            string message = $"合同[{currentBudget.ContractNO}]账上余额为{ this.reportHelper.Balance}，删除调账金额{detail.CNY}后余额小于0；";
                            lblMessage.Text += message;
                            layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            //XtraMessageBox.Show(message);
                            //gvConstSplit.CloseEditor();
                            //gvConstSplit.CancelUpdateCurrentRow();
                            //return;
                        }
                    }
                    LoadCurrentDetail(detail.RelationBudget, detail);
                    detail.IsDelete = true;
                    detail.OperatorModel = DataOperatorModel.Modify;
                }
                else
                {
                    gvConstSplit.DeleteRow(this.gvConstSplit.FocusedRowHandle);
                }
                this.gvConstSplit.RefreshData();
            }
            CalcSplitMoney();
        }

        private void riLinkEditConstInDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void BudgetLink_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = e.Value?.ToString() ?? "未关联合同";
        }

        private void BudgetLink_Click(object sender, EventArgs e)
        {
            if (this.gvDetail.FocusedRowHandle < 0)
            {
                return;
            }
            BudgetSingleReport report = gvDetail.GetRow(gvDetail.FocusedRowHandle) as BudgetSingleReport;
            if (report != null)
            {
                var budget = bm.GetBudget(report.BudgetId);
                if (budget == null)
                {
                    XtraMessageBox.Show("您选择查看项不存在，请刷新数据。");
                    return;
                }
                frmSingleBudgetFinalAccountsReport finalAccountReportForm = new frmSingleBudgetFinalAccountsReport();
                finalAccountReportForm.CurrentBudget = budget;
                finalAccountReportForm.ShowDialog();
            }
        }

        decimal totalOriginalCoin = 0;
        decimal totalCNY = 0;
        private void gvConstSplit_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item != null)
            {
                var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                string fieldName = (e.Item as GridSummaryItem).FieldName;
                if (gridView.Columns.ColumnByFieldName(fieldName) != null)
                {
                    GridSummaryItem gridSummaryItem = e.Item as GridSummaryItem;
                    switch (e.SummaryProcess)
                    {
                        //calculation entry point 
                        case CustomSummaryProcess.Start:
                            if (fieldName == this.gcSplitConstOriginalCoin.FieldName)
                            {
                                totalOriginalCoin = 0;
                            }
                            else if (fieldName == this.bgcConstCNY.FieldName)
                            {
                                totalCNY = 0;
                            }
                            break;
                        case CustomSummaryProcess.Calculate:
                            if (e.FieldValue != null && e.FieldValue != DBNull.Value)
                            {
                                AccountAdjustmentDetail bb = gridView.GetRow(e.RowHandle) as AccountAdjustmentDetail;
                                if (!bb.IsDelete)
                                {
                                    if (fieldName == this.gcSplitConstOriginalCoin.FieldName)
                                    {
                                        totalOriginalCoin += Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, gcSplitConstOriginalCoin));
                                    }
                                    else if (fieldName == this.bgcConstCNY.FieldName)
                                    {
                                        totalCNY += Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, bgcConstCNY));
                                    }
                                }
                            }
                            break;
                        case CustomSummaryProcess.Finalize:
                            if (fieldName == this.gcSplitConstOriginalCoin.FieldName)
                            {
                                e.TotalValue = totalOriginalCoin;
                            }
                            else if (fieldName == this.bgcConstCNY.FieldName)
                            {
                                e.TotalValue = totalCNY;
                            }
                            break;
                    }
                }
            }
        }

        private void gvDetail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bgcTitle || e.RowHandle < 0)
            {
                return;
            }
            if (e.Column.FieldName.EndsWith("After", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!e.CellValue.Equals(gvDetail.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("After", ""))))
                {
                    var oldVlue = (decimal)e.CellValue;
                    var newValue = (decimal)gvDetail.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("After", ""));

                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                    if (oldVlue > newValue)
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Blue;
                    }
                    e.Appearance.Options.UseFont = true;
                    e.Appearance.Options.UseForeColor = true;
                }
            }
        }

        private void gvConstSplit_ShowingEditor(object sender, CancelEventArgs e)
        {
            AccountAdjustmentDetail item = this.gvConstSplit.GetRow(this.gvConstSplit.FocusedRowHandle) as AccountAdjustmentDetail;
            if (item == null || string.IsNullOrEmpty(item.Operator))
            {
                e.Cancel = false;
                return;
            }
            if (item.IsDelete)
            {
                e.Cancel = true;
                return;
            }
            if (RunInfo.Instance.CurrentUser.UserName == item.Operator || RunInfo.Instance.CurrentUser.Role != StringUtil.SaleRoleCode)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cboType_EditValueChanged(object sender, EventArgs e)
        {
            AdjustmentType type = (AdjustmentType)Enum.Parse(typeof(AdjustmentType), this.cboType.Text, true);
            AdjustmentType = type;

            LoadDataByBudget();

            ShowItemByType(type);
        }

        private void CboBudget_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Budget oldBudget = e.OldValue as Budget;
            if (oldBudget != null)
            {
                BindingList<BudgetSingleReport> reportList = this.gcDetail.DataSource as BindingList<BudgetSingleReport>;
                if (reportList != null)
                {
                    for (int index = reportList.Count - 1; index >= 0; index--)
                    {
                        if (reportList[index].BudgetId == oldBudget.ID)
                        {
                            reportList.RemoveAt(index);
                            break;
                        }
                    }
                    this.gcDetail.DataSource = reportList;
                    this.gvDetail.BestFitColumns();
                }

                if (AdjustmentType == AdjustmentType.付款)
                {
                    this.cboPayment.EditValue = null;
                }
                else if (AdjustmentType == AdjustmentType.收款)
                {
                    this.cboBudgetBill.EditValue = null;
                }
                else
                {
                    var dataSource = im.GetAllInvoiceWithoutAdjustmentByBudgetID(this.currentBudget.ID);
                    if (this.currentInvoice != null)
                    {
                        dataSource.Add(this.currentInvoice);
                    }
                    this.cboBudgetBill.Properties.DataSource = null;
                    this.cboPayment.Properties.DataSource = null;
                    this.cboInvoice.Properties.DataSource = dataSource;
                    this.cboInvoice.Properties.View.ExpandAllGroups();
                }
            }
        }

        private void cboBudget_EditValueChanged(object sender, EventArgs e)
        {
            this.currentBudget = this.cboBudget.EditValue as Budget;
            LoadBudgetBalance();

            LoadDataByBudget();
        }

        private void cboPayment_EditValueChanged(object sender, EventArgs e)
        {
            this.currentPayment = cboPayment.EditValue as PaymentNotes;
            if (this.currentPayment != null)
            {
                this.txtCurrency.EditValue = this.currentPayment.Currency;
                this.txtExchangeRate.EditValue = this.currentPayment.ExchangeRate;
                this.txtOriginalCoin.EditValue = this.currentPayment.OriginalCoin;
                this.txtCNY.EditValue = this.currentPayment.CNY;
                this.txtRelationName.EditValue = this.currentPayment.SupplierName;
                this.txtRemainingCNY.EditValue = this.currentPayment.CNY;
            }
            else
            {
                this.txtCurrency.EditValue = "";
                this.txtExchangeRate.EditValue = 0;
                this.txtOriginalCoin.EditValue = 0;
                this.txtCNY.EditValue = 0;
                this.txtRelationName.EditValue = "";
                this.txtRemainingCNY.EditValue = 0;
                this.txtSplitCNY.EditValue = 0;
                this.txtSplitOriginalCoin.EditValueChanging -= TxtSplitOriginalCoin_EditValueChanging;
                this.txtSplitOriginalCoin.EditValue = 0;
                this.txtSplitOriginalCoin.EditValueChanging += TxtSplitOriginalCoin_EditValueChanging;
            }
            BindingSelectedBudget();
        }

        private void cboBudgetBill_EditValueChanged(object sender, EventArgs e)
        {
            this.currentBudgetBill = cboBudgetBill.EditValue as BudgetBill;
            if (this.currentBudgetBill != null)
            {
                this.txtCurrency.EditValue = this.currentBudgetBill.Currency;
                this.txtExchangeRate.EditValue = this.currentBudgetBill.ExchangeRate;
                this.txtOriginalCoin.EditValue = this.currentBudgetBill.OriginalCoin;
                this.txtCNY.EditValue = this.currentBudgetBill.CNY;
                this.txtRelationName.EditValue = this.currentBudgetBill.Customer;
            }
            else
            {
                this.txtCurrency.EditValue = "";
                this.txtExchangeRate.EditValue = 0;
                this.txtOriginalCoin.EditValue = 0;
                this.txtCNY.EditValue = 0;
                this.txtRelationName.EditValue = "";
                this.txtRemainingCNY.EditValue = 0;
                this.txtSplitCNY.EditValue = 0;
                this.txtSplitOriginalCoin.EditValueChanging -= TxtSplitOriginalCoin_EditValueChanging;
                this.txtSplitOriginalCoin.EditValue = 0;
                this.txtSplitOriginalCoin.EditValueChanging += TxtSplitOriginalCoin_EditValueChanging;
            }
            CalcBudgetBillBalance();

            BindingSelectedBudget();
        }

        private void cboInvoice_EditValueChanged(object sender, EventArgs e)
        {
            this.currentInvoice = cboInvoice.EditValue as Invoice;
            if (this.currentInvoice != null)
            {
                this.txtCurrency.EditValue = "美元";
                this.txtExchangeRate.EditValue = this.currentInvoice.ExchangeRate;
                this.txtOriginalCoin.EditValue = this.currentInvoice.OriginalCoin;
                this.txtCNY.EditValue = this.currentInvoice.CNY;
                this.txtRelationName.EditValue = this.currentInvoice.SupplierName;
                this.txtRemainingCNY.EditValue = this.currentInvoice.CNY;
            }
            else
            {
                this.txtCurrency.EditValue = "";
                this.txtExchangeRate.EditValue = 0;
                this.txtOriginalCoin.EditValue = 0;
                this.txtCNY.EditValue = 0;
                this.txtRelationName.EditValue = "";
                this.txtRemainingCNY.EditValue = 0;
                this.txtSplitCNY.EditValue = 0;
                this.txtSplitOriginalCoin.EditValueChanging -= TxtSplitOriginalCoin_EditValueChanging;
                this.txtSplitOriginalCoin.EditValue = 0;
                this.txtSplitOriginalCoin.EditValueChanging += TxtSplitOriginalCoin_EditValueChanging;
            }
            BindingSelectedBudget();
        }

        private void TxtSplitOriginalCoin_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (string.IsNullOrEmpty(cboType.Text))
            {
                XtraMessageBox.Show("请选择调账类型");
                e.Cancel = true;
                cboType.Focus();
                return;
            }
            if (AdjustmentType == AdjustmentType.交单 && !(cboInvoice.EditValue is Invoice))
            {
                XtraMessageBox.Show("请选择交单信息");
                e.Cancel = true;
                cboInvoice.Focus();
            }
            else if (AdjustmentType == AdjustmentType.付款 && !(cboPayment.EditValue is PaymentNotes))
            {
                XtraMessageBox.Show("请选择付款单");
                e.Cancel = true;
                cboPayment.Focus();
            }
            else if (AdjustmentType == AdjustmentType.收款 && !(cboBudgetBill.EditValue is BudgetBill))
            {
                XtraMessageBox.Show("请选择收款单");
                e.Cancel = true;
                cboBudgetBill.Focus();
            }
        }

        private void TxtSplitOriginalCoin_EditValueChanged(object sender, EventArgs e)
        {
            var SplitCNY = Math.Round(txtSplitOriginalCoin.Value * txtExchangeRate.Value, 2);

            this.txtSplitCNY.EditValue = SplitCNY;
        }

        private void TxtSplitCNY_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSplitCNY.Value > this.txtCNY.Value)
            {
                //this.dxErrorProvider1.SetError(txtSplitCNY, $"调账人民币不允许大于可调帐人民币金额");
                this.dxErrorProvider1.SetError(txtSplitCNY, $"调账人民币不允许大于{lciCNY.Text.Replace("：", "")}");
            }
            else
            {
                this.dxErrorProvider1.ClearErrors();
            }
            BindingList<BudgetSingleReport> reportList = this.gcDetail.DataSource as BindingList<BudgetSingleReport>;
            if (reportList == null)
            {
                reportList = new BindingList<BudgetSingleReport>();
            }
            if (this.currentBudget != null)
            {
                BudgetSingleReport report = reportList.FirstOrDefault(p => p.BudgetId == this.currentBudget.ID);

                SingleBudgetReportHelper helper = new SingleBudgetReportHelper(this.imTypeList, this.useMoneyTypeList);
                AccountAdjustment adjustment = new AccountAdjustment()
                {
                    AlreadySplitCNY = txtSplitCNY.Value,
                    AlreadySplitOriginalCoin = txtSplitOriginalCoin.Value,
                    BudgetID = this.currentBudget.ID,
                    ContractNO = this.currentBudget.ContractNO,
                    VatOption = this.valueAddedTaxRate,
                    Type = this.AdjustmentType,
                    ExchangeRate = this.txtExchangeRate.Value,
                };
                if (this.Adjustment != null)
                {
                    adjustment.ID = this.Adjustment.ID;
                }
                if (AdjustmentType == AdjustmentType.付款 && currentPayment != null)
                {
                    adjustment.TaxRebateRate = (decimal)this.currentPayment.TaxRebateRate;
                    adjustment.IsDrawback = this.currentPayment.IsDrawback;
                }
                helper.LoadData(this.currentBudget, accountAdjustment: adjustment);
                helper.CurrentBudgetReport.IsOut = true;
                int index = reportList.IndexOf(report);
                if (index < 0)
                {
                    reportList.Add(helper.CurrentBudgetReport);
                }
                else
                {
                    reportList.RemoveAt(index);
                    reportList.Insert(index, helper.CurrentBudgetReport);
                }
                if (AdjustmentType == AdjustmentType.收款 && (helper.Balance - adjustment.AlreadySplitCNY) < 0)
                {
                    string message = $"合同[{currentBudget.ContractNO}]账上余额为{helper.Balance}，调出收款金额{adjustment.AlreadySplitCNY}后余额小于0；";
                    lblMessage.Text = message;
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                this.gcDetail.DataSource = new BindingList<BudgetSingleReport>(reportList);
                this.gvDetail.BestFitColumns();
                this.gvDetail.RefreshData();
            }
        }

        private void CboBudget_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void CboPayment_QueryPopUp(object sender, CancelEventArgs e)
        {
            SearchLookUpEdit editor = (SearchLookUpEdit)sender;
            RepositoryItemSearchLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        private void LoadBudgetBalance()
        {
            if (this.currentBudget == null)
            {
                return;
            }

            SingleBudgetReportHelper helper = new SingleBudgetReportHelper(this.imTypeList, useMoneyTypeList);
            helper.LoadData(this.currentBudget, this.Adjustment, null);

            this.txtBudgetBalance.EditValue = helper.Balance;
            this.txtBudgetBalance.ToolTip = "账上收支余额";
            ValidationBalance();
        }

        private void ValidationBalance()
        {
            //TODO:暂时去掉限制。
            //if (this.txtBudgetBalance.Value < 0 && this.AdjustmentType == AdjustmentType.收款)
            //{
            //    this.dxErrorProvider1.SetError(txtBudgetBalance, $"{this.txtBudgetBalance.ToolTip}小于0");
            //}
        }

        private void LoadDataByBudget()
        {
            if (this.currentBudget == null || string.IsNullOrEmpty(this.cboType.Text.Trim()))
            {
                this.cboPayment.Properties.DataSource = null;
                this.cboPayment.EditValue = null;
                this.cboBudgetBill.Properties.DataSource = null;
                this.cboBudgetBill.EditValue = null;
                this.cboInvoice.Properties.DataSource = null;
                this.cboInvoice.EditValue = null;
                return;
            }

            if (AdjustmentType == AdjustmentType.付款)
            {
                var dataSource = pnm.GetApprovaledAmountPaymentWithOutAdjustmentByBudgetId(this.currentBudget.ID);
                if (this.currentPayment != null)
                {
                    dataSource.Add(this.currentPayment);
                }
                this.cboPayment.Properties.DataSource = dataSource;
                this.cboPayment.Properties.View.ExpandAllGroups();
                this.cboBudgetBill.Properties.DataSource = null;
                this.cboInvoice.Properties.DataSource = null;
            }
            else if (AdjustmentType == AdjustmentType.收款)
            {
                var dataSource = arm.GetBudgetBillListWithOutAdjustmentByBudgetId(this.currentBudget.ID);
                if (this.currentBudgetBill != null)
                {
                    dataSource.Add(this.currentBudgetBill);
                }
                this.cboPayment.Properties.DataSource = null;
                this.cboInvoice.Properties.DataSource = null;
                this.cboBudgetBill.Properties.DataSource = dataSource;
                this.cboBudgetBill.Properties.View.ExpandAllGroups();
            }
            else
            {
                var dataSource = im.GetAllInvoiceWithoutAdjustmentByBudgetID(this.currentBudget.ID);
                if (this.currentInvoice != null)
                {
                    dataSource.Add(this.currentInvoice);
                }
                this.cboBudgetBill.Properties.DataSource = null;
                this.cboPayment.Properties.DataSource = null;
                this.cboInvoice.Properties.DataSource = dataSource;
                this.cboInvoice.Properties.View.ExpandAllGroups();
            }

        }

        private void ShowItemByType(AdjustmentType type)
        {
            if (type == AdjustmentType.付款)
            {
                this.lciPayments.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lciBudgetBill.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciName.Text = "供应商名称：";
                this.lciCNY.Text = "付款人民币金额：";
                this.lciOriginalCoin.Text = "付款原币金额：";
            }
            else if (type == AdjustmentType.收款)
            {
                this.lciPayments.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciBudgetBill.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lciInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciName.Text = "客户名称：";
                this.lciCNY.Text = "收汇人民币金额：";
                this.lciOriginalCoin.Text = "收汇原币金额：";
            }
            else
            {
                this.lciPayments.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciBudgetBill.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lciName.Text = "销方名称：";
                this.lciCNY.Text = "发票人民币金额：";
                this.lciOriginalCoin.Text = "发票原币金额：";
            }
        }

        private void CalcBudgetBillBalance()
        {
            if (AdjustmentType == AdjustmentType.收款 && cboBudgetBill.EditValue is BudgetBill)
            {
                ValidationBalance();
                if (this.txtBudgetBalance.Value < 0)
                {
                    return;
                }
                BudgetBill budgetBill = cboBudgetBill.EditValue as BudgetBill;

                if (txtBudgetBalance.Value >= budgetBill.CNY)
                {
                    this.txtRemainingCNY.EditValue = budgetBill.CNY;
                }
                else
                {
                    this.txtRemainingCNY.EditValue = txtBudgetBalance.Value;
                }
            }
        }

        private void BindingSelectedBudget()
        {
            if (WorkModel == EditFormWorkModels.View || WorkModel == EditFormWorkModels.Print)
            {
                this.gridBudget.DataSource = detailBudgetList;
                return;
            }
            AdjustmentType type = (AdjustmentType)Enum.Parse(typeof(AdjustmentType), this.cboType.Text, true);
            if (type == AdjustmentType.付款)
            {
                PaymentNotes pn = cboPayment.EditValue as PaymentNotes;
                if (pn != null)
                {
                    var dataSource = bm.GetBudgetListBySupperId(pn.SupplierID).Where(o => o.ID != pn.BudgetID).ToList();
                    this.gridBudget.DataSource = dataSource;
                }
                else
                {
                    this.gridBudget.DataSource = null;
                }
            }
            else if (type == AdjustmentType.收款)
            {
                BudgetBill bb = cboBudgetBill.EditValue as BudgetBill;
                if (bb != null)
                {
                    string customerIds = $"{bb.Cus_ID}";
                    this.gridBudget.DataSource = bm.GetBudgetListByCustomerId(customerIds).Where(o => o.ID != bb.BudgetID).ToList();
                }
                else
                {
                    this.gridBudget.DataSource = null;
                }
            }
            else
            {
                Invoice invoice = cboInvoice.EditValue as Invoice;
                if (invoice != null)
                {
                    this.gridBudget.DataSource = bm.GetBudgetListBySupperName(invoice.SupplierName).Where(o => o.ID != invoice.BudgetID).ToList();
                }
                else
                {
                    this.gridBudget.DataSource = null;
                }
            }
        }

        private void btnSingleBudgetFinalAccount_Click(object sender, EventArgs e)
        {
            if (currentBudget == null)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }
            frmSingleBudgetFinalAccountsReport finalAccountReportForm = new frmSingleBudgetFinalAccountsReport();
            finalAccountReportForm.CurrentBudget = this.currentBudget;
            finalAccountReportForm.ShowDialog();
        }

        private void btnShowBudgetHistory_Click(object sender, EventArgs e)
        {
            if (currentBudget == null)
            {
                XtraMessageBox.Show("请选择合同");
                return;
            }

            frmAccountBillView form = new frmAccountBillView();
            form.CurrentBudget = this.currentBudget;
            form.ShowDialog(this);
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
    }
}