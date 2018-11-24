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
    public partial class frmInMoneyEdit : frmBaseDialogForm
    {
        private ReceiptMgmtManager arm = new ReceiptMgmtManager();
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        private UserManager um = new UserManager();
        private List<User> allSalesmanList;
        internal const string SaleRoleCode = "YWY";

        public frmInMoneyEdit()
        {
            InitializeComponent();
        }

        public BankSlip CurrentBankSlip
        {
            get;
            set;
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            this.dxErrorProvider1.ClearErrors();
            CheckUIInput();

            if (this.dxErrorProvider1.HasErrors) { return; }
            FillData();

            CurrentBankSlip.BSID = arm.AddBankSlip(CurrentBankSlip);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            this.dxErrorProvider1.ClearErrors();

            CheckUIInput();

            if (this.dxErrorProvider1.HasErrors) { return; }
            FillData();

            arm.ModifyBankSlip(CurrentBankSlip);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitConstData()
        {
            base.SubmitSplitConstData();

            this.dxErrorProvider1.ClearErrors();

            CheckSplitMoney();

            var dataSource = (IEnumerable<BudgetBill>)this.gcConstSplit.DataSource;
            if (dataSource == null || dataSource.Count() < 2)
            {
                XtraMessageBox.Show("金额分拆必须多余2项分拆才有意义。");
            }

            if (this.dxErrorProvider1.HasErrors) { return; }

            //this.CurrentBankSlip.OriginalCoin2 = txtAlreadySplitOriginalCoinMoney.Value;
            //this.CurrentBankSlip.CNY2 = txtAlreadySplitCNYMoney.Value;
            //this.CurrentBankSlip.State = (int)ReceiptState.已拆分;
            //this.CurrentBankSlip.Operator = RunInfo.Instance.CurrentUser.UserName;
            //this.CurrentBankSlip.OperateTimestamp = DateTime.Now;

            //arm.SplitActualReceipts(this.CurrentBankSlip, GetActualReceiptList());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitToBudgetData()
        {
            base.SubmitSplitToBudgetData();

            this.dxErrorProvider1.ClearErrors();

            CheckSplitMoney();

            var dataSource = (IEnumerable<BudgetBill>)this.gcConstSplit.DataSource;
            if (dataSource != null)
            {
                int index = dataSource.ToList().FindIndex(o => o.RelationBudget == null);
                if (index >= 0)
                {
                    this.dxErrorProvider1.SetError(this.gcConstSplit, string.Format("请将第{0}项分拆金额关联合同", index + 1));
                }
                //增加合同超收提示。
                for (index = 0; index < dataSource.Count(); index++)
                {
                    var ar = dataSource.ToList()[index];
                    var budget = bm.GetBudget(ar.RelationBudget.ID);
                    decimal totalAmountOriginal = arm.GetTotalAmountOriginalCoinByBudgetId(ar.RelationBudget.ID);
                    decimal originalMoney = 0;
                    try
                    {
                        List<OutProductDetail> outProductDetailList = JsonConvert.DeserializeObject<List<OutProductDetail>>(budget.OutProductDetail);

                        if (outProductDetailList != null)
                        {
                            originalMoney = outProductDetailList.Sum(o => o.OriginalCurrencyMoney);
                            decimal rate = (totalAmountOriginal - originalMoney) / originalMoney;
                            if (rate > (decimal)0.3)
                            {
                                this.dxErrorProvider1.SetError(this.gcConstSplit, string.Format("合同【{0}】，实际收汇超计划收汇30%以上！请调整合同计划数！原预算单如有“预付款”计划，调整计划，必须同时报批“预付款”新计划！", budget.ContractNO));
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                        //TODO:记录日志
                    }
                }
            }
            if (this.dxErrorProvider1.HasErrors) { return; }

            //this.CurrentBankSlip.OriginalCoin2 = txtAlreadySplitOriginalCoinMoney.Value;
            //this.CurrentBankSlip.CNY2 = txtAlreadySplitCNYMoney.Value;
            //this.CurrentBankSlip.State = (int)ReceiptState.关联合同;
            //this.CurrentBankSlip.Operator = RunInfo.Instance.CurrentUser.UserName;
            //this.CurrentBankSlip.OperateTimestamp = DateTime.Now;

            ////合同拆分必须一次
            //arm.RelationActualReceiptToBudget(this.CurrentBankSlip, GetActualReceiptList());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();
        }

        private void frmInMemoryEdit_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();

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

            this.cboTradeNature.Properties.Items.AddRange(Enum.GetNames(typeof(BankSlipTradeNature)));

            this.txtCreateUser.Properties.ReadOnly = true;
            this.deCreateTimestamp.Properties.ReadOnly = true;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "新增入账信息";
                this.txtCreateUser.Text = RunInfo.Instance.CurrentUser.UserName;
                this.deReceiptDate.EditValue = DateTime.Now;
                this.deCreateTimestamp.EditValue = DateTime.Now;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑入账信息";
                if (RunInfo.Instance.CurrentUser.Role == frmInMoneyEdit.SaleRoleCode)
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

                BindActualReceipts(this.CurrentBankSlip.BSID);

            }
            else if (this.WorkModel == EditFormWorkModels.SplitConst || this.WorkModel == EditFormWorkModels.SplitToBudget)
            {
                if (this.WorkModel == EditFormWorkModels.SplitConst)
                {
                    this.Text = "入账金额分拆";
                    this.lcgTitle.Text = "金额分拆设置";
                    this.bgcBudget.Visible = false;
                    this.gbBudget.Visible = false;
                    BindActualReceipts(this.CurrentBankSlip.BSID);
                }
                else
                {
                    BindBudgetList();

                    this.gbSalesman.Visible = false;
                    this.lcgTitle.Text = "金额分拆设置";
                    this.Text = "金额分拆入合同";

                    ricSalesman.Items.AddRange(allSalesmanList.ToArray());

                    BindActualReceipts(this.CurrentBankSlip.BSID);
                }

                gcConstSplit.DataSource = new BindingList<BudgetBill>();
                gvConstSplit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvConstSplit_ValidateRow);
                gvConstSplit.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvConstSplit_CellValueChanged);
                gvConstSplit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvConstSplit_InvalidRowException);
                gvConstSplit.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvConstSplit_InitNewRow);

                this.txtNotSplitCNYMoney.EditValue = this.txtCNY.Value;

                SetReadOnly();
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看入账信息";
                BindActualReceipts(this.CurrentBankSlip.BSID);
                SetReadOnly();
            }
            else if (this.WorkModel == EditFormWorkModels.Custom)
            {
                this.Text = "分拆入账";
            }
        }

        private void BindBudgetList()
        {
            this.gridBudget.DataSource = bm.GetAllBudget();
        }

        private List<BudgetBill> GetActualReceiptList()
        {
            var splitList = ((IEnumerable<BudgetBill>)this.gvConstSplit.DataSource).ToList();
            if (splitList.Count > 0)
            {
                //if (splitList.Count == 1)
                //{
                //    this.CurrentBankSlip.RelationBudget = splitList[0].RelationBudget;
                //}
                //splitList.ForEach(o =>
                //{
                //    o.BankName = this.CurrentBankSlip.BankName;
                //    o.CreateTimestamp = DateTime.Now;
                //    o.CreateUser = RunInfo.Instance.CurrentUser.UserName;
                //    o.Currency = this.CurrentBankSlip.Currency;
                //    o.DepartmentCode = this.CurrentBankSlip.DepartmentCode;
                //    o.PaymentMethod = this.CurrentBankSlip.PaymentMethod;
                //    o.ReceiptDate = this.CurrentBankSlip.ReceiptDate;
                //    o.Remitter = this.CurrentBankSlip.Remitter;
                //    o.VoucherNo = this.CurrentBankSlip.VoucherNo;
                //    o.State = this.WorkModel == EditFormWorkModels.SplitConst ? 2 : 3;
                //    o.TradingPostscript = this.CurrentBankSlip.TradingPostscript;
                //});
                return splitList;
            }
            else { return new List<BudgetBill>(); }
        }

        private void SetReadOnly()
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
            this.txtCreateUser.Properties.ReadOnly = true;
            this.deCreateTimestamp.Properties.ReadOnly = true;
            this.cboTradeNature.Properties.ReadOnly = true;
            this.txtExportName.Properties.ReadOnly = true;

            this.txtTradingPostscript.Properties.ReadOnly = true;
            this.txtDescription.Properties.ReadOnly = true;

            this.gvConstSplit.OptionsBehavior.Editable = false;

        }

        private void FillData()
        {
            if (CurrentBankSlip == null)
            {
                CurrentBankSlip = new BankSlip();
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
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CheckSplitMoney()
        {

            if (txtNotSplitCNYMoney.Value != 0)
            {
                dxErrorProvider1.SetError(txtNotSplitCNYMoney, "分拆人民币余额必须为0。");
            }
        }

        private void CheckUIInput()
        {
            if ((cboCustomer.EditValue as Customer) == null)
            {
                dxErrorProvider1.SetError(cboCustomer, "请输入客户信息");
                cboCustomer.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtVoucherNo.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtVoucherNo, "请输入银行凭证号信息");
                txtVoucherNo.Focus();
                return;
            }

            if (txtOriginalCoin.Value <= 0)
            {
                dxErrorProvider1.SetError(txtOriginalCoin, "请输入原币金额");
                txtOriginalCoin.Focus();
                return;
            }
            if (cboCurrency.EditValue == null)
            {
                dxErrorProvider1.SetError(cboCurrency, "请选择币种");
                cboCurrency.Focus();
                return;
            }
            if (txtExchangeRate.Value <= 0)
            {
                dxErrorProvider1.SetError(txtExchangeRate, "请输入汇率信息");
                txtExchangeRate.Focus();
                return;
            }

            if (txtCNY.Value <= 0)
            {
                dxErrorProvider1.SetError(txtCNY, "请输入人民币金额");
                txtCNY.Focus();
                return;
            }
            if (txtPaymentMethod.SelectedItem == null || string.IsNullOrEmpty(txtPaymentMethod.SelectedItem.ToString()))
            {
                dxErrorProvider1.SetError(txtPaymentMethod, "请选择支付方式");
                txtPaymentMethod.Focus();
                return;
            }
        }

        private void BindActualReceipts(int id)
        {
            CurrentBankSlip = arm.GetAllActualReceipts(id);
            this.txtBankName.Text = CurrentBankSlip.BankName;
            this.txtDescription.Text = CurrentBankSlip.Description;
            this.txtExchangeRate.Text = CurrentBankSlip.ExchangeRate.ToString();
            this.txtOriginalCoin.Text = CurrentBankSlip.OriginalCoin.ToString();
            this.txtPaymentMethod.SelectedItem = CurrentBankSlip.PaymentMethod;
            this.cboCurrency.EditValue = CurrentBankSlip.Currency;
            SalemanValue(um.GetBankSlipSalesmanList(id));

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
            string[] arrayList = cboSales.EditValue.ToString().Split(new char[] { ',' });
            foreach (string array in arrayList)
            {
                User u = allSalesmanList.Find(o => o.ToString().Equals(array));
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
                decimal splitCNY = dataSource.Sum(o => o.OriginalCoin);
         
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

                    float exchangeRate = (float)this.gvConstSplit.GetRowCellValue(e.RowHandle, bgcConstExchangeRate);

                    decimal CNY = originalCoin * (decimal)exchangeRate;

                    this.gvConstSplit.SetRowCellValue(e.RowHandle, bgcConstCNY, CNY);
                }
            }
            else if (e.Column == bgcConstCNY)
            {
                CalcSplitMoney();
            }
        }

        private void gvConstSplit_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
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
            }
        }
    }
}