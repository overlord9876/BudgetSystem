using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;

namespace BudgetSystem.InMoney
{
    public partial class frmInMoneyEdit : frmBaseDialogForm
    {
        ActualReceiptsManager manager = new ActualReceiptsManager();

        BudgetManager budgetManager = new BudgetManager();

        public frmInMoneyEdit()
        {
            InitializeComponent();
        }

        public ActualReceipts CurrentActualReceipts
        {
            get;
            set;
        }

        public ActualReceipts SplitCostActualReceipts
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
            CurrentActualReceipts.Remitter = this.txtRemitter.Text.Trim();
            CurrentActualReceipts.RMB = decimal.Parse(this.txtRMB.Text);
            CurrentActualReceipts.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentActualReceipts.CreateUser = this.txtCreateUser.Text.Trim();
            CurrentActualReceipts.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;
            CurrentActualReceipts.CreateTimestamp = (DateTime)this.deCreateTimestamp.EditValue;

            manager.CreateActualReceipts(CurrentActualReceipts);

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
            CurrentActualReceipts.Remitter = this.txtRemitter.Text.Trim();
            CurrentActualReceipts.RMB = decimal.Parse(this.txtRMB.Text);
            CurrentActualReceipts.VoucherNo = this.txtVoucherNo.Text.Trim();
            CurrentActualReceipts.ReceiptDate = (DateTime)this.deReceiptDate.EditValue;

            manager.ModifyActualReceipts(CurrentActualReceipts);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();
        }

        private void frmInMemoryEdit_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();

            //TODO:绑定币种配置。
            cboCurrency.Properties.Items.Add("RMB");
            cboCurrency.Properties.Items.Add("USD");
            cboCurrency.Properties.Items.Add("HKD");

            //budgetManager.GetAllBudget();



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
            else if (this.WorkModel == EditFormWorkModels.SplitConst)
            {
                this.Text = "入账金额分拆";
                BindActualReceipts(this.CurrentActualReceipts.ID);

                DataTable dt = new DataTable();
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Money", typeof(decimal));
                gcSplitToBudget.DataSource = dt;

                SetReadOnly();
            }
            else if (this.WorkModel == EditFormWorkModels.SplitToBudget)
            {
                this.Text = "金额分拆入合同";
                BindActualReceipts(this.CurrentActualReceipts.ID);
                DataTable dt = new DataTable();
                dt.Columns.Add("BudgetNo", typeof(string));
                dt.Columns.Add("Money", typeof(decimal));
                gcSplitToBudget.DataSource = dt;

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

        private void SetReadOnly()
        {


            this.txtBankName.Properties.ReadOnly = true;
            this.txtDescription.Properties.ReadOnly = true;
            this.txtExchangeRate.Properties.ReadOnly = true;
            this.txtOriginalCoin.Properties.ReadOnly = true;
            this.txtPaymentMethod.Properties.ReadOnly = true;
            this.txtRemitter.Properties.ReadOnly = true;
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

        private void CheckUIInput()
        {
            if (string.IsNullOrEmpty(txtRemitter.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtRemitter, "请输入客户信息");
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
            CurrentActualReceipts = manager.GetActualReceiptById(id);
            this.txtBankName.Text = CurrentActualReceipts.BankName;
            this.txtDescription.Text = CurrentActualReceipts.Description;
            this.txtExchangeRate.Text = CurrentActualReceipts.ExchangeRate.ToString();
            this.txtOriginalCoin.Text = CurrentActualReceipts.OriginalCoin.ToString();
            this.txtPaymentMethod.Text = CurrentActualReceipts.PaymentMethod;
            this.txtRemitter.Text = CurrentActualReceipts.Remitter;
            this.txtRMB.Text = CurrentActualReceipts.RMB.ToString();
            this.txtVoucherNo.Text = CurrentActualReceipts.VoucherNo;
            this.txtCreateUser.Text = CurrentActualReceipts.CreateUser;
            this.deReceiptDate.EditValue = CurrentActualReceipts.ReceiptDate;
            this.deCreateTimestamp.EditValue = CurrentActualReceipts.CreateTimestamp;
        }

        private void txtOriginalCoin_EditValueChanged(object sender, EventArgs e)
        {
            CalcRMBValue();
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcRMBValue();
        }

        private void CalcRMBValue()
        {
            txtRMB.EditValue = Math.Round(txtOriginalCoin.Value * txtExchangeRate.Value, 2);
        }

    }
}