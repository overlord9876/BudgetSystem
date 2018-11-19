using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;

namespace BudgetSystem.InMoney
{
    public partial class frmInvoiceEdit : frmBaseDialogForm
    {
        public frmInvoiceEdit()
        {
            InitializeComponent();
        }

        
        public Invoice CurrentInvoice
        {
            get;
            set;
        }

        private Bll.InvoiceManager im=new Bll.InvoiceManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private void frmInvoiceEdit_Load(object sender, EventArgs e)
        { 
            if (this.WorkModel == EditFormWorkModels.New)
            {
                SetLayoutControlStyle(EditFormWorkModels.New);
                this.Text = "创建开票信息";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                SetLayoutControlStyle(EditFormWorkModels.Modify);
                this.Text = "编辑开票信息";
                BindInvoice(CurrentInvoice.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetLayoutControlStyle(EditFormWorkModels.View);
                this.txtCode.Properties.ReadOnly=true;
                this.txtCommission.Properties.ReadOnly=true; 
                this.txtContractNO.Properties.ReadOnly=true;
                this.txtCustomsDeclaration.Properties.ReadOnly=true; 
                this.txtExchangeRate.Properties.ReadOnly=true;
                this.txtFeedMoney.Properties.ReadOnly=true;
                this.txtFinanceImportDate.Properties.ReadOnly=true;
                this.txtFinanceImportUser.Properties.ReadOnly=true;
                this.txtImportDate.Properties.ReadOnly=true;
                this.txtImportUser.Properties.ReadOnly=true;
                this.txtNumber.Properties.ReadOnly=true;
                this.txtOriginalCoin.Properties.ReadOnly=true; 
                this.txtPayment.Properties.ReadOnly=true;
                this.txtSupplierName.Properties.ReadOnly=true;
                this.txtTaxAmount.Properties.ReadOnly=true;
                this.txtTaxpayerID.Properties.ReadOnly=true;
                this.txtTaxRebateRate.Properties.ReadOnly=true;
                this.Text = "查看开票信息";
                BindInvoice(CurrentInvoice.ID);;
            }

        }


        private void BindInvoice(int id)
        {
            Invoice invoice = im.GetInvoice(id);
            if (invoice != null)
            {
                this.txtCode.EditValue = invoice.Code;
                this.txtCommission.EditValue = invoice.Commission;
                this.txtContractNO.EditValue = invoice.ContractNO;
                this.txtCustomsDeclaration.EditValue = invoice.CustomsDeclaration;
                this.txtExchangeRate.EditValue = invoice.ExchangeRate;
                this.txtFeedMoney.EditValue = invoice.FeedMoney;
                this.txtFinanceImportDate.EditValue = invoice.FinanceImportDate;
                this.txtFinanceImportUser.EditValue = invoice.FinanceImportUserName;
                this.txtImportDate.EditValue = invoice.ImportDate;
                this.txtImportUser.EditValue = invoice.ImportUserName;
                this.txtNumber.EditValue = invoice.Number;
                this.txtOriginalCoin.EditValue = invoice.OriginalCoin;
                this.txtPayment.EditValue = invoice.Payment;
                this.txtSupplierName.EditValue = invoice.SupplierName;
                this.txtTaxAmount.EditValue = invoice.TaxAmount;
                this.txtTaxpayerID.EditValue = invoice.TaxpayerID;
                this.txtTaxRebateRate.EditValue = invoice.TaxRebateRate;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void CheckNewInput()
        {
            if (string.IsNullOrEmpty(this.txtContractNO.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "请输入合同号");
            }
            else
            {
                bool result = bm.CheckContractNO(this.CurrentInvoice==null?0:this.CurrentInvoice.ID, txtContractNO.Text.Trim());
                if (result == false)
                {
                    this.dxErrorProvider1.SetError(this.txtContractNO, "合同号不存在");
                }
            }
            if (string.IsNullOrEmpty(this.txtNumber.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtNumber, "请输入发票号");
            }
            else
            {
                bool result = im.CheckNumber(this.CurrentInvoice == null ? 0 : this.CurrentInvoice.ID, txtNumber.Text.Trim());
                if (result == true)
                {
                    this.dxErrorProvider1.SetError(this.txtNumber, "发票号已存在");
                }                
            }
            if (txtExchangeRate.Value <= 0)
            {
                this.dxErrorProvider1.SetError(this.txtExchangeRate, "汇率应大于0");
            }
            if (string.IsNullOrEmpty( txtCustomsDeclaration.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtCustomsDeclaration, "请输入报关单");
            }
        }

        private void CheckModifyInput()
        {
            this.CheckNewInput();
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtCode, "请输入发票代码");
            }
            if (string.IsNullOrEmpty(this.txtTaxpayerID.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtTaxpayerID, "请输入销方税号");
            }
            if (string.IsNullOrEmpty(this.txtSupplierName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtSupplierName, "请输入销方名称");
            }
            if (this.txtPayment.Value <= 0)
            {
                this.dxErrorProvider1.SetError(this.txtPayment, "金额应大于0");
            }
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            this.dxErrorProvider1.ClearErrors();
            CheckNewInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            Invoice invoice = new Invoice();
            invoice.ContractNO = this.txtContractNO.Text.Trim();
            invoice.Number = this.txtNumber.Text.Trim();
            invoice.OriginalCoin = this.txtOriginalCoin.Value;
            invoice.ExchangeRate = this.txtExchangeRate.FloatValue;
            invoice.CustomsDeclaration = this.txtCustomsDeclaration.Text.Trim();
            invoice.TaxRebateRate = this.txtTaxRebateRate.FloatValue;
            invoice.Commission = this.txtCommission.Value;
            invoice.FeedMoney = this.txtFeedMoney.Value;
            invoice.ImportUser = RunInfo.Instance.CurrentUser.UserName;
            invoice.ImportDate = DateTime.Now;
            im.AddInvoice(invoice);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();
            this.CheckModifyInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            CurrentInvoice.ContractNO = this.txtContractNO.Text.Trim();
            CurrentInvoice.Number = this.txtNumber.Text.Trim();
            CurrentInvoice.OriginalCoin = this.txtOriginalCoin.Value;
            CurrentInvoice.ExchangeRate = this.txtExchangeRate.FloatValue;
            CurrentInvoice.CustomsDeclaration = this.txtCustomsDeclaration.Text.Trim();
            CurrentInvoice.TaxRebateRate = this.txtTaxRebateRate.FloatValue;
            CurrentInvoice.Commission = this.txtCommission.Value;
            CurrentInvoice.FeedMoney = this.txtFeedMoney.Value;
            CurrentInvoice.FinanceImportUser = RunInfo.Instance.CurrentUser.UserName;
            CurrentInvoice.FinanceImportDate = DateTime.Now;
            CurrentInvoice.Code = this.txtCode.Text.Trim();
            CurrentInvoice.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            CurrentInvoice.SupplierName = this.txtSupplierName.Text.Trim();
            CurrentInvoice.Payment = this.txtPayment.Value;
            CurrentInvoice.TaxAmount = this.txtPayment.Value;
            im.ModifyInvoice(CurrentInvoice);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
         


    }
}