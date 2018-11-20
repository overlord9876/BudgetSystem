﻿using System;
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
        private ActualReceiptsManager arm = new ActualReceiptsManager();
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private SystenConfigManager scm = new SystenConfigManager();
        private UserManager um = new UserManager();
        private List<User> allSalesmanList;
        const string SaleRoleCode = "Sales";

        public frmInMoneyEdit()
        {
            InitializeComponent();
        }

        public ActualReceipts CurrentActualReceipts
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
            CurrentActualReceipts = new ActualReceipts();
            CurrentActualReceipts.BankName = this.txtBankName.Text.Trim();
            CurrentActualReceipts.Description = this.txtDescription.Text.Trim();
            CurrentActualReceipts.ExchangeRate = float.Parse(this.txtExchangeRate.Text);
            CurrentActualReceipts.OriginalCoin = decimal.Parse(this.txtOriginalCoin.Text);
            CurrentActualReceipts.PaymentMethod = this.txtPaymentMethod.SelectedItem.ToString();
            CurrentActualReceipts.Remitter = (cboCustomer.EditValue as Customer).Name;
            CurrentActualReceipts.CNY = this.txtCNY.Value;
            CurrentActualReceipts.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentActualReceipts.CreateUser = this.txtCreateUser.Text.Trim();
            CurrentActualReceipts.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;
            CurrentActualReceipts.Currency = this.cboCurrency.EditValue.ToString();
            CurrentActualReceipts.CreateTimestamp = (DateTime)this.deCreateTimestamp.EditValue;
            CurrentActualReceipts.TradingPostscript = this.txtTradingPostscript.Text.Trim();
            CurrentActualReceipts.Operator = RunInfo.Instance.CurrentUser.UserName;
            CurrentActualReceipts.OperateTimestamp = DateTime.Now;
            CurrentActualReceipts.State = (int)ReceiptState.入账;
            CurrentActualReceipts.ReceiptType = 0;
            GetSalesmanValues();

            CurrentActualReceipts.ID = arm.CreateActualReceipts(CurrentActualReceipts);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            this.dxErrorProvider1.ClearErrors();

            CheckUIInput();

            if (this.dxErrorProvider1.HasErrors) { return; }

            CurrentActualReceipts.BankName = this.txtBankName.Text.Trim();
            CurrentActualReceipts.Description = this.txtDescription.Text.Trim();
            CurrentActualReceipts.ExchangeRate = float.Parse(this.txtExchangeRate.Text);
            CurrentActualReceipts.OriginalCoin = decimal.Parse(this.txtOriginalCoin.Text);
            CurrentActualReceipts.PaymentMethod = this.txtPaymentMethod.SelectedItem.ToString();
            CurrentActualReceipts.Remitter = (cboCustomer.EditValue as Customer).Name;
            CurrentActualReceipts.Currency = this.cboCurrency.EditValue.ToString();
            CurrentActualReceipts.CNY = decimal.Parse(this.txtCNY.Text);
            CurrentActualReceipts.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentActualReceipts.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;
            CurrentActualReceipts.TradingPostscript = this.txtTradingPostscript.Text.Trim();
            CurrentActualReceipts.Operator = RunInfo.Instance.CurrentUser.UserName;
            CurrentActualReceipts.OperateTimestamp = DateTime.Now;
            GetSalesmanValues();

            arm.ModifyActualReceipts(CurrentActualReceipts);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitConstData()
        {
            base.SubmitSplitConstData();

            this.dxErrorProvider1.ClearErrors();

            CheckSplitMoney();

            if (this.dxErrorProvider1.HasErrors) { return; }

            this.CurrentActualReceipts.OriginalCoin2 = txtAlreadySplitOriginalCoinMoney.Value;
            this.CurrentActualReceipts.CNY2 = txtAlreadySplitCNYMoney.Value;
            this.CurrentActualReceipts.State = (int)ReceiptState.已拆分;
            this.CurrentActualReceipts.Operator = RunInfo.Instance.CurrentUser.UserName;
            this.CurrentActualReceipts.OperateTimestamp = DateTime.Now;

            arm.SplitActualReceipts(this.CurrentActualReceipts, GetActualReceiptList());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitToBudgetData()
        {
            base.SubmitSplitToBudgetData();

            this.dxErrorProvider1.ClearErrors();

            CheckSplitMoney();

            var dataSource = (IEnumerable<ActualReceipts>)this.gcConstSplit.DataSource;
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
                            decimal rate = totalAmountOriginal - originalMoney / originalMoney;
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

            this.CurrentActualReceipts.OriginalCoin2 = txtAlreadySplitOriginalCoinMoney.Value;
            this.CurrentActualReceipts.CNY2 = txtAlreadySplitCNYMoney.Value;
            this.CurrentActualReceipts.State = (int)ReceiptState.关联合同;
            this.CurrentActualReceipts.Operator = RunInfo.Instance.CurrentUser.UserName;
            this.CurrentActualReceipts.OperateTimestamp = DateTime.Now;

            arm.RelationActualReceiptToBudget(this.CurrentActualReceipts, GetActualReceiptList());
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
                BindActualReceipts(this.CurrentActualReceipts.ID);

            }
            else if (this.WorkModel == EditFormWorkModels.SplitConst || this.WorkModel == EditFormWorkModels.SplitToBudget)
            {
                if (this.WorkModel == EditFormWorkModels.SplitConst)
                {
                    this.Text = "入账金额分拆";
                    this.lcgTitle.Text = "金额分拆设置";
                    this.bgcBudget.Visible = false;
                    this.gbBudget.Visible = false;
                    BindActualReceipts(this.CurrentActualReceipts.ID);
                }
                else
                {
                    BindBudgetList();

                    this.bgcSales.Visible = false;
                    this.gbSalesman.Visible = false;
                    this.lcgTitle.Text = "金额分拆设置";
                    this.Text = "金额分拆入合同";

                    ricSalesman.Items.AddRange(allSalesmanList.ToArray());

                    BindActualReceipts(this.CurrentActualReceipts.ID);
                }

                gcConstSplit.DataSource = new BindingList<ActualReceipts>();
                gvConstSplit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvConstSplit_ValidateRow);
                gvConstSplit.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvConstSplit_CellValueChanged);
                gvConstSplit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvConstSplit_InvalidRowException);
                gvConstSplit.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvConstSplit_InitNewRow);

                this.txtNotSplitOriginalCoinMoney.EditValue = this.txtOriginalCoin.Value;
                this.txtNotSplitCNYMoney.EditValue = this.txtCNY.Value;

                SetReadOnly();
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看入账信息";
                BindActualReceipts(this.CurrentActualReceipts.ID);
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

        private List<ActualReceipts> GetActualReceiptList()
        {
            var splitList = ((IEnumerable<ActualReceipts>)this.gvConstSplit.DataSource).ToList();
            if (splitList.Count > 0)
            {
                splitList.ForEach(o =>
                {
                    o.BankName = this.CurrentActualReceipts.BankName;
                    o.CreateTimestamp = DateTime.Now;
                    o.CreateUser = RunInfo.Instance.CurrentUser.UserName;
                    o.Currency = this.CurrentActualReceipts.Currency;
                    o.DepartmentCode = this.CurrentActualReceipts.DepartmentCode;
                    o.PaymentMethod = this.CurrentActualReceipts.PaymentMethod;
                    o.ReceiptDate = this.CurrentActualReceipts.ReceiptDate;
                    o.Remitter = this.CurrentActualReceipts.Remitter;
                    o.VoucherNo = this.CurrentActualReceipts.VoucherNo;
                    o.State = this.WorkModel == EditFormWorkModels.SplitConst ? 2 : 3;
                    o.TradingPostscript = this.CurrentActualReceipts.TradingPostscript;
                });
                return splitList;
            }
            else { return new List<ActualReceipts>(); }
        }

        private void SetReadOnly()
        {
            this.txtBankName.Properties.ReadOnly = true;
            this.txtDescription.Properties.ReadOnly = true;
            this.txtExchangeRate.Properties.ReadOnly = true;
            this.txtOriginalCoin.Properties.ReadOnly = true;
            this.txtPaymentMethod.Properties.ReadOnly = true;
            this.cboCustomer.Properties.ReadOnly = true;
            this.txtCNY.Properties.ReadOnly = true;
            this.txtVoucherNo.Properties.ReadOnly = true;
            this.txtTradingPostscript.Properties.ReadOnly = true;
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
            if (txtNotSplitOriginalCoinMoney.Value != 0)
            {
                dxErrorProvider1.SetError(txtNotSplitOriginalCoinMoney, "分拆原币余额必须为0。");
            }

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
            CurrentActualReceipts = arm.GetActualReceiptById(id);
            this.txtBankName.Text = CurrentActualReceipts.BankName;
            this.txtDescription.Text = CurrentActualReceipts.Description;
            this.txtExchangeRate.Text = CurrentActualReceipts.ExchangeRate.ToString();
            this.txtOriginalCoin.Text = CurrentActualReceipts.OriginalCoin.ToString();
            this.txtPaymentMethod.SelectedItem = CurrentActualReceipts.PaymentMethod;
            this.cboCurrency.EditValue = CurrentActualReceipts.Currency;
            SalemanValue(um.GetActualReceiptSalesmanList(id));

            foreach (Customer customer in this.cboCustomer.Properties.DataSource as List<Customer>)
            {
                if (customer.Name == CurrentActualReceipts.Remitter)
                {
                    this.cboCustomer.EditValue = customer;
                    break;
                }
            }

            this.txtCNY.Text = CurrentActualReceipts.CNY.ToString();
            this.txtVoucherNo.Text = CurrentActualReceipts.VoucherNo;
            this.txtCreateUser.Text = CurrentActualReceipts.CreateUser;
            this.deReceiptDate.EditValue = CurrentActualReceipts.ReceiptDate;
            this.deCreateTimestamp.EditValue = CurrentActualReceipts.CreateTimestamp;
        }

        private void CalcCNYValue()
        {
            txtCNY.EditValue = Math.Round(txtOriginalCoin.Value * txtExchangeRate.Value, 2);
        }

        private void GetSalesmanValues()
        {
            if (CurrentActualReceipts.Sales == null)
            {
                CurrentActualReceipts.Sales = new List<User>();
            }
            string[] arrayList = cboSales.EditValue.ToString().Split(new char[] { ',' });
            foreach (string array in arrayList)
            {
                User u = allSalesmanList.Find(o => o.ToString().Equals(array));
                if (u != null)
                {
                    CurrentActualReceipts.Sales.Add(u);
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
            var dataSource = (IEnumerable<ActualReceipts>)gvConstSplit.DataSource;
            if (dataSource != null)
            {
                decimal splitOriginalCoin = dataSource.Sum(o => o.OriginalCoin);
                decimal splitCNY = dataSource.Sum(o => o.OriginalCoin);
                if (splitOriginalCoin > txtOriginalCoin.Value)
                {
                    return "拆分原币金额不允许大于入帐单总额";
                }
                if (splitCNY > txtCNY.Value)
                {
                    return "拆分人民币金额不允许大于入帐单总额";
                }

                txtAlreadySplitOriginalCoinMoney.EditValue = dataSource.Sum(o => o.OriginalCoin);
                txtAlreadySplitCNYMoney.EditValue = dataSource.Sum(o => o.CNY);

                txtNotSplitOriginalCoinMoney.EditValue = txtOriginalCoin.Value - txtAlreadySplitOriginalCoinMoney.Value;
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
            ActualReceipts item = this.gvConstSplit.GetRow(e.RowHandle) as ActualReceipts;
            item.ExchangeRate = (float)txtExchangeRate.Value;
            item.OriginalCoin = txtNotSplitOriginalCoinMoney.Value / 2;
            item.CNY = item.OriginalCoin * (decimal)item.ExchangeRate / 2;
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