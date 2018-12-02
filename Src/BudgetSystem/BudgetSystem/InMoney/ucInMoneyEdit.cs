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

namespace BudgetSystem.InMoney
{
    public partial class ucInMoneyEdit : DataControl
    {
        private ReceiptMgmtManager arm = new ReceiptMgmtManager();
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        private UserManager um = new UserManager();
        private List<User> allSalesmanList;
        internal const string SaleRoleCode = "YWY";
        private BankSlip _currentBankSlip;

        public event EventHandler<EventArgs> CanCommitEventHandler;

        public ucInMoneyEdit()
        {
            InitializeComponent();
            if (!frmBaseForm.IsDesignMode)
            {
                RegisterEventHandler();
                try
                {
                    InitData();
                }
                catch (Exception ex)
                {
                    RunInfo.Instance.Logger.LogError(ex);
                }
            }
        }

        private void RegisterEventHandler()
        {
            gvConstSplit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvConstSplit_ValidateRow);
            gvConstSplit.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvConstSplit_CellValueChanged);
            gvConstSplit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvConstSplit_InvalidRowException);
            gvConstSplit.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvConstSplit_InitNewRow);
            this.riLinkEditConstInDelete.Click += new EventHandler(riLinkEditConstInDelete_Click);
            this.riLinkEditConstInDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(riLinkEditConstInDelete_CustomDisplayText);
            this.gvConstSplit.ShowingEditor += new CancelEventHandler(gvConstSplit_ShowingEditor);
        }

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

        public BankSlip CurrentBankSlip
        {
            get
            {
                return this._currentBankSlip;
            }
            private set { this._currentBankSlip = value; }
        }

        public List<BudgetBill> SpliDetail
        {
            get;
            private set;
        }

        public void InitData()
        {
            List<MoneyType> mtList = scm.GetSystemConfigValue<List<MoneyType>>(EnumSystemConfigNames.币种.ToString());
            if (mtList != null)
            {
                foreach (var mt in mtList)
                {
                    cboCurrency.Properties.Items.Add(mt.Name);
                }
            }

            allSalesmanList = um.GetRoleUsers(SaleRoleCode);

            cboSales.Properties.Items.Clear();

            cboSales.Properties.Items.AddRange(allSalesmanList.ToArray());

            List<Customer> customerList = cm.GetAllCustomer();
            this.cboCustomer.Properties.DataSource = customerList;

            this.gcConstSplit.DataSource = new BindingList<BudgetBill>();

            this.cboTradeNature.Properties.Items.AddRange(Enum.GetNames(typeof(BankSlipTradeNature)));

        }

        public void FillData()
        {
            if (CurrentBankSlip == null)
            {
                CurrentBankSlip = new BankSlip();
                CurrentBankSlip.UpdateTimestamp = DateTime.Now;
            }
            CurrentBankSlip.BankName = this.txtBankName.Text.Trim();
            CurrentBankSlip.Description = this.txtDescription.Text.Trim();
            CurrentBankSlip.ExchangeRate = float.Parse(this.txtExchangeRate.Text);
            CurrentBankSlip.OriginalCoin = decimal.Parse(this.txtOriginalCoin.Text);
            CurrentBankSlip.PaymentMethod = this.txtPaymentMethod.SelectedItem.ToString();
            CurrentBankSlip.Remitter = (cboCustomer.EditValue as Customer).Name;
            CurrentBankSlip.CNY = this.txtCNY.Value;
            CurrentBankSlip.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentBankSlip.CreateUser = this.txtCreateUser.Text.Trim();
            CurrentBankSlip.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;
            CurrentBankSlip.Currency = this.cboCurrency.EditValue.ToString();
            CurrentBankSlip.CreateTimestamp = (DateTime)this.deCreateTimestamp.EditValue;
            CurrentBankSlip.TradingPostscript = this.txtTradingPostscript.Text.Trim();
            if (this.cboTradeNature.EditValue != null)
            {
                CurrentBankSlip.TradeNature = (int)(BankSlipTradeNature)Enum.Parse(typeof(BankSlipTradeNature), this.cboTradeNature.EditValue.ToString());
            }
            CurrentBankSlip.ExportName = this.txtExportName.Text.Trim();

            CurrentBankSlip.State = (int)ReceiptState.入账;

            GetSalesmanValues();
            this.SpliDetail = (this.gvConstSplit.DataSource as BindingList<BudgetBill>).ToList();
            this.CurrentBankSlip.CNY2 = txtNotSplitCNYMoney.Value;
        }

        public void BindBankSlip(BankSlip item)
        {
            this.CurrentBankSlip = item;
            this.txtBankName.Text = CurrentBankSlip.BankName;
            this.txtDescription.Text = CurrentBankSlip.Description;
            this.txtExchangeRate.Text = CurrentBankSlip.ExchangeRate.ToString();
            this.txtOriginalCoin.Text = CurrentBankSlip.OriginalCoin.ToString();
            this.txtPaymentMethod.SelectedItem = CurrentBankSlip.PaymentMethod;
            this.cboCurrency.EditValue = CurrentBankSlip.Currency;
            SalemanValue(um.GetBankSlipSalesmanList(item.BSID));

            foreach (Customer customer in this.cboCustomer.Properties.DataSource as List<Customer>)
            {
                if (customer.Name == CurrentBankSlip.Remitter)
                {
                    this.cboCustomer.EditValue = customer;
                    break;
                }
            }

            this.txtCNY.Text = CurrentBankSlip.CNY.ToString();
            this.txtVoucherNo.Text = CurrentBankSlip.VoucherNo;
            this.txtCreateUser.Text = CurrentBankSlip.CreateUser;
            this.deReceiptDate.EditValue = CurrentBankSlip.ReceiptDate;
            this.deCreateTimestamp.EditValue = CurrentBankSlip.CreateTimestamp;
            this.cboTradeNature.EditValue = (BankSlipTradeNature)CurrentBankSlip.TradeNature;
            this.txtExportName.EditValue = CurrentBankSlip.ExportName;
            var source = arm.GetBudgetBillListByBankSlipID(item.BSID);
            if (source == null)
            {
                this.gcConstSplit.DataSource = new BindingList<BudgetBill>();
            }
            source.ForEach(o =>
            {
                o.ExchangeRate = txtExchangeRate.Value;
                o.RelationBudget = budgetList != null ? budgetList.Find(bl => bl.ID.Equals(o.BudgetID)) : null;
            });
            this.gcConstSplit.DataSource = new BindingList<BudgetBill>(source);
            CalcSplitMoney();

        }

        public void BindBankSlipByID(int bsID)
        {
            BankSlip item = arm.GetBankSlipByBSID(bsID);
            BindBankSlip(item);
        }

        public override void BindingData(int dataID)
        {
            base.BindingData(dataID);
            BindBankSlipByID(dataID);
        }

        public bool CheckUIInput()
        {
            this.dxErrorProvider1.ClearErrors();

            if ((cboCustomer.EditValue as Customer) == null)
            {
                dxErrorProvider1.SetError(cboCustomer, "请输入客户信息");
            }
            if (string.IsNullOrEmpty(txtVoucherNo.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtVoucherNo, "请输入银行凭证号信息");
            }

            if (txtOriginalCoin.Value <= 0)
            {
                dxErrorProvider1.SetError(txtOriginalCoin, "请输入原币金额");
            }
            if (cboCurrency.EditValue == null)
            {
                dxErrorProvider1.SetError(cboCurrency, "请选择币种");
            }
            if (txtExchangeRate.Value <= 0)
            {
                dxErrorProvider1.SetError(txtExchangeRate, "请输入汇率信息");
            }

            if (txtCNY.Value <= 0)
            {
                dxErrorProvider1.SetError(txtCNY, "请输入人民币金额");
            }
            if (txtPaymentMethod.SelectedItem == null || string.IsNullOrEmpty(txtPaymentMethod.SelectedItem.ToString()))
            {
                dxErrorProvider1.SetError(txtPaymentMethod, "请选择支付方式");
            }
            return !dxErrorProvider1.HasErrors;
        }

        private void InitControlState()
        {
            this.txtCreateUser.Properties.ReadOnly = true;
            this.deCreateTimestamp.Properties.ReadOnly = true;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.txtCreateUser.Text = RunInfo.Instance.CurrentUser.UserName;
                this.deReceiptDate.EditValue = DateTime.Now;
                this.deCreateTimestamp.EditValue = DateTime.Now;
                this.lcgConstSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciConstSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciTradeNature.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciExportName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                if (RunInfo.Instance.CurrentUser.Role == ucInMoneyEdit.SaleRoleCode)
                {
                    this.cboCustomer.Properties.ReadOnly = true;
                    this.txtVoucherNo.Properties.ReadOnly = true;
                    this.txtOriginalCoin.Properties.ReadOnly = true;
                    this.txtBankName.Properties.ReadOnly = true;
                    this.txtExchangeRate.Properties.ReadOnly = true;
                    this.txtCNY.Properties.ReadOnly = true;
                    this.txtPaymentMethod.Properties.ReadOnly = true;
                    this.deReceiptDate.Properties.ReadOnly = true;
                    this.cboSales.Properties.ReadOnly = true;
                    this.txtTradingPostscript.Properties.ReadOnly = true;
                    this.txtDescription.Properties.ReadOnly = true;
                }
                else
                {
                    this.lcgConstSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.lciConstSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.lciTradeNature.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.lciExportName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                this.txtNotSplitCNYMoney.EditValue = this.txtCNY.Value;

            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
            }

        }

        private List<Budget> budgetList;

        private void BindBudgetList()
        {
            Customer c = (this.cboCustomer.EditValue as Customer);
            if (c != null)
            {
                budgetList = bm.GetBudgetListByCustomerId(RunInfo.Instance.CurrentUser.UserName, c.ID);
                this.gridBudget.DataSource = budgetList;
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

        private void CheckSplitMoney()
        {

            if (txtNotSplitCNYMoney.Value != 0)
            {
                dxErrorProvider1.SetError(txtNotSplitCNYMoney, "分拆人民币余额必须为0。");
            }
        }

        private void CalcCNYValue()
        {
            txtCNY.EditValue = Math.Round(txtOriginalCoin.Value * txtExchangeRate.Value, 2);
        }

        private void GetSalesmanValues()
        {
            if (CurrentBankSlip.Sales == null)
            {
                CurrentBankSlip.Sales = new List<User>();
            }
            CurrentBankSlip.Sales.Clear();
            string[] arrayList = cboSales.EditValue.ToString().Split(new char[] { ',' });
            foreach (string array in arrayList)
            {
                User u = allSalesmanList.Find(o => o.ToString().Equals(array.Trim()));
                if (u != null)
                {
                    CurrentBankSlip.Sales.Add(u);
                }
            }
        }

        private void SalemanValue(List<User> userList)
        {
            string salesman = string.Empty;
            foreach (var user in userList)
            {
                salesman += user.ToString() + ",";
            }

            this.cboSales.SetEditValue(salesman);
        }

        private string CalcSplitMoney()
        {
            string message = string.Empty;
            var dataSource = (IEnumerable<BudgetBill>)gvConstSplit.DataSource;
            if (dataSource != null)
            {
                decimal splitCNY = dataSource.Where(o => !o.IsDelete).Sum(o => o.OriginalCoin);

                if (splitCNY > txtCNY.Value)
                {
                    return "拆分人民币金额不允许大于入帐单总额";
                }

                txtAlreadySplitCNYMoney.EditValue = dataSource.Sum(o => o.CNY);

                txtNotSplitCNYMoney.EditValue = txtCNY.Value - txtAlreadySplitCNYMoney.Value;
            }
            return message;
        }

        private void txtOriginalCoin_EditValueChanged(object sender, EventArgs e)
        {
            CalcCNYValue();
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcCNYValue();
        }

        private void gvConstSplit_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            BudgetBill item = this.gvConstSplit.GetRow(e.RowHandle) as BudgetBill;
            item.ExchangeRate = txtExchangeRate.Value;
            item.OperatorModel = DataOperatorModel.Add;
            item.Operator = RunInfo.Instance.CurrentUser.UserName;
            item.DepartmentCode = RunInfo.Instance.CurrentUser.Department;
        }

        private void gvConstSplit_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvConstSplit.SetColumnError(this.gvConstSplit.FocusedColumn, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvConstSplit_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gvConstSplit.ClearColumnErrors();
            if (e.Column == gcSplitConstOriginalCoin
              || e.Column == bgcConstExchangeRate)
            {
                if (string.IsNullOrEmpty(CalcSplitMoney()))
                {
                    decimal originalCoin = (decimal)this.gvConstSplit.GetRowCellValue(e.RowHandle, gcSplitConstOriginalCoin);

                    decimal exchangeRate = (decimal)this.gvConstSplit.GetRowCellValue(e.RowHandle, bgcConstExchangeRate);

                    decimal CNY = originalCoin * (decimal)exchangeRate;

                    this.gvConstSplit.SetRowCellValue(e.RowHandle, bgcConstCNY, CNY);
                }
            }
            else if (e.Column == bgcConstCNY)
            {
                CalcSplitMoney();
            }
            BudgetBill budget = this.gvConstSplit.GetRow(e.RowHandle) as BudgetBill;
            if (budget != null)
            {
                if (budget.OperatorModel != DataOperatorModel.Add)
                {
                    budget.OperatorModel = DataOperatorModel.Modify;
                }
            }
        }

        private void gvConstSplit_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Budget budget = this.gvConstSplit.GetRowCellValue(e.RowHandle, this.bgcBudget) as Budget;

            if (budget == null)
            {
                e.ErrorText = "请选择合同号";
                e.Valid = false;
                return;
            }

            string messsage = CalcSplitMoney();
            if (!string.IsNullOrEmpty(messsage))
            {
                e.ErrorText = messsage;
                e.Valid = false;
                return;
            }
        }

        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {
            Customer c = this.cboCustomer.EditValue as Customer;
            if (c != null)
            {
                List<User> salesmanList = um.GetCustomerSalesmanList(c.ID);

                SalemanValue(salesmanList);

                BindBudgetList();
            }
        }

        private void riLinkEditConstInDelete_Click(object sender, EventArgs e)
        {
            if (this.gvConstSplit.FocusedRowHandle < 0)
            {
                gvConstSplit.CancelUpdateCurrentRow();
            }
            else
            {
                BudgetBill budgetBill = gvConstSplit.GetRow(gvConstSplit.FocusedRowHandle) as BudgetBill;
                if (budgetBill != null && budgetBill.OperatorModel != DataOperatorModel.Add)
                {
                    budgetBill.OriginalCoin = 0;
                    budgetBill.CNY = 0;
                    budgetBill.IsDelete = true;
                    budgetBill.OperatorModel = DataOperatorModel.Modify;
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

        void gvConstSplit_ShowingEditor(object sender, CancelEventArgs e)
        {
            BudgetBill item = this.gvConstSplit.GetRow(this.gvConstSplit.FocusedRowHandle) as BudgetBill;

            if (item != null)
            {
                e.Cancel = item.IsDelete;
            }
        }

        private void txtNotSplitCNYMoney_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtNotSplitCNYMoney.Value == 0)
            {
                if (CanCommitEventHandler != null)
                {
                    CanCommitEventHandler(this, e); ;
                }
            }
        }

        private void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCurrency.EditValue != null && (cboCurrency.EditValue.ToString().Equals("CNY") || cboCurrency.EditValue.ToString().Equals("人民币")))
            {
                this.txtExchangeRate.EditValue = 1;
            }
        }

    }
}