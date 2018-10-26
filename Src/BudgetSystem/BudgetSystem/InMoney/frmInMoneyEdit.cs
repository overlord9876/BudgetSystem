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

namespace BudgetSystem.InMoney
{
    public partial class frmInMoneyEdit : frmBaseDialogForm
    {
        private ActualReceiptsManager arm = new ActualReceiptsManager();
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();



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
            CurrentActualReceipts.PaymentMethod = this.txtPaymentMethod.Text.Trim();
            CurrentActualReceipts.Remitter = (cboCustomer.EditValue as Customer).Name;
            CurrentActualReceipts.RMB = decimal.Parse(this.txtRMB.Text);
            CurrentActualReceipts.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentActualReceipts.CreateUser = this.txtCreateUser.Text.Trim();
            CurrentActualReceipts.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;
            CurrentActualReceipts.CreateTimestamp = (DateTime)this.deCreateTimestamp.EditValue;

            arm.CreateActualReceipts(CurrentActualReceipts);

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
            CurrentActualReceipts.PaymentMethod = this.txtPaymentMethod.Text.Trim();
            CurrentActualReceipts.Remitter = (cboCustomer.EditValue as Customer).Name;
            CurrentActualReceipts.RMB = decimal.Parse(this.txtRMB.Text);
            CurrentActualReceipts.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentActualReceipts.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;

            arm.ModifyActualReceipts(CurrentActualReceipts);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitConstData()
        {
            base.SubmitSplitConstData();

            this.dxErrorProvider1.ClearErrors();

            CheckSplitMoney();

            if (this.dxErrorProvider1.HasErrors) { return; }

            arm.SplitActualReceipts(this.CurrentActualReceipts, GetActualReceiptList());
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
            }
            if (this.dxErrorProvider1.HasErrors) { return; }

            arm.RelationActualReceiptToBudget(this.CurrentActualReceipts, GetActualReceiptList());

        }

        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();
        }

        private void frmInMemoryEdit_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();

            //TODO:绑定币种配置。
            cboCurrency.Properties.Items.Add("CNY");
            cboCurrency.Properties.Items.Add("USD");
            cboCurrency.Properties.Items.Add("HKD");


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
                    this.lcgTitle.Text = "金额分拆设置";
                    this.Text = "金额分拆入合同";
                    BindActualReceipts(this.CurrentActualReceipts.ID);
                }

                gcConstSplit.DataSource = new BindingList<ActualReceipts>();
                gvConstSplit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvConstSplit_ValidateRow);
                gvConstSplit.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvConstSplit_CellValueChanged);
                gvConstSplit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gvConstSplit_InvalidRowException);
                gvConstSplit.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvConstSplit_InitNewRow);

                this.txtNotSplitOriginalCoinMoney.EditValue = this.txtOriginalCoin.Value;
                this.txtNotSplitCNYMoney.EditValue = this.txtRMB.Value;

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
            if (splitList.Count > 1)
            {
                this.CurrentActualReceipts.OriginalCoin = splitList[0].OriginalCoin;
                this.CurrentActualReceipts.RMB = splitList[0].RMB;
                this.CurrentActualReceipts.ExchangeRate = splitList[0].ExchangeRate;
                this.CurrentActualReceipts.RelationBudget = splitList[0].RelationBudget;
                splitList.RemoveAt(0);
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
                });
            }
            return splitList;
        }

        private void SetReadOnly()
        {


            this.txtBankName.Properties.ReadOnly = true;
            this.txtDescription.Properties.ReadOnly = true;
            this.txtExchangeRate.Properties.ReadOnly = true;
            this.txtOriginalCoin.Properties.ReadOnly = true;
            this.txtPaymentMethod.Properties.ReadOnly = true;
            this.cboCustomer.Properties.ReadOnly = true;
            this.txtRMB.Properties.ReadOnly = true;
            this.txtVoucherNo.Properties.ReadOnly = true;
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
                return;
            }
            if (string.IsNullOrEmpty(txtVoucherNo.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtVoucherNo, "请输入银行凭证号信息");
                return;
            }

            if (txtOriginalCoin.Value <= 0)
            {
                dxErrorProvider1.SetError(txtOriginalCoin, "请输入原币金额");
                return;
            }
            if (txtExchangeRate.Value <= 0)
            {
                dxErrorProvider1.SetError(txtExchangeRate, "请输入汇率信息");
                return;
            }

            if (txtRMB.Value <= 0)
            {
                dxErrorProvider1.SetError(txtRMB, "请输入人民币金额");
                return;
            }
            if (string.IsNullOrEmpty(txtPaymentMethod.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtPaymentMethod, "请输入支付方式");
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
            this.txtPaymentMethod.Text = CurrentActualReceipts.PaymentMethod;

            foreach (Customer customer in this.cboCustomer.Properties.DataSource as List<Customer>)
            {
                if (customer.Name == CurrentActualReceipts.Remitter)
                {
                    this.cboCustomer.EditValue = customer;
                    break;
                }
            }

            this.txtRMB.Text = CurrentActualReceipts.RMB.ToString();
            this.txtVoucherNo.Text = CurrentActualReceipts.VoucherNo;
            this.txtCreateUser.Text = CurrentActualReceipts.CreateUser;
            this.deReceiptDate.EditValue = CurrentActualReceipts.ReceiptDate;
            this.deCreateTimestamp.EditValue = CurrentActualReceipts.CreateTimestamp;
        }

        private void CalcRMBValue()
        {
            txtRMB.EditValue = Math.Round(txtOriginalCoin.Value * txtExchangeRate.Value, 2);
        }

        private void txtOriginalCoin_EditValueChanged(object sender, EventArgs e)
        {
            CalcRMBValue();
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcRMBValue();
        }

        void gvConstSplit_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ActualReceipts item = this.gvConstSplit.GetRow(e.RowHandle) as ActualReceipts;
            item.ExchangeRate = (float)txtExchangeRate.Value;
            item.OriginalCoin = txtNotSplitOriginalCoinMoney.Value / 2;
            item.RMB = item.OriginalCoin * (decimal)item.ExchangeRate / 2;
        }

        void gvConstSplit_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvConstSplit.SetColumnError(this.gvConstSplit.FocusedColumn, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void gvConstSplit_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
                if (splitCNY > txtRMB.Value)
                {
                    return "拆分人民币金额不允许大于入帐单总额";
                }

                txtAlreadySplitOriginalCoinMoney.EditValue = dataSource.Sum(o => o.OriginalCoin);
                txtAlreadySplitCNYMoney.EditValue = dataSource.Sum(o => o.RMB);

                txtNotSplitOriginalCoinMoney.EditValue = txtOriginalCoin.Value - txtAlreadySplitOriginalCoinMoney.Value;
                txtNotSplitCNYMoney.EditValue = txtRMB.Value - txtAlreadySplitCNYMoney.Value;
            }
            return message;
        }

        void gvConstSplit_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string messsage = CalcSplitMoney();

            if (!string.IsNullOrEmpty(messsage))
            {
                e.ErrorText = messsage;
                e.Valid = false;
                return;
            }
        }


    }
}