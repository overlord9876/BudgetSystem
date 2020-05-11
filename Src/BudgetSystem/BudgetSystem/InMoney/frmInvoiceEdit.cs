using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Bll;

namespace BudgetSystem.InMoney
{
    public partial class frmInvoiceEdit : frmBaseDialogForm
    {
        private CommonManager cm = new CommonManager();
        private DateTime datetimeNow = DateTime.MinValue;

        public frmInvoiceEdit()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
        }


        public Invoice CurrentInvoice
        {
            get;
            set;
        }

        private Bll.InvoiceManager im = new Bll.InvoiceManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private void frmInvoiceEdit_Load(object sender, EventArgs e)
        {
            BudgetQueryCondition condition = new BudgetQueryCondition();
            condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;
            List<Budget> budgetList = bm.GetAllBudget(condition);

            cboBudget.Properties.DataSource = budgetList;

            if (this.WorkModel == EditFormWorkModels.New)
            {
                SetLayoutControlStyle(EditFormWorkModels.New);
                this.Text = "创建交单信息";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                SetLayoutControlStyle(EditFormWorkModels.Modify);
                this.Text = "编辑交单信息";
                BindInvoice(CurrentInvoice.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetLayoutControlStyle(EditFormWorkModels.View);
                this.txtCode.Properties.ReadOnly = true;
                this.txtCommission.Properties.ReadOnly = true;
                this.cboBudget.Properties.ReadOnly = true;
                this.txtCustomsDeclaration.Properties.ReadOnly = true;
                this.txtExchangeRate.Properties.ReadOnly = true;
                this.txtFeedMoney.Properties.ReadOnly = true;
                this.txtFinanceImportDate.Properties.ReadOnly = true;
                this.txtFinanceImportUser.Properties.ReadOnly = true;
                this.txtImportDate.Properties.ReadOnly = true;
                this.txtImportUser.Properties.ReadOnly = true;
                this.txtNumber.Properties.ReadOnly = true;
                this.txtOriginalCoin.Properties.ReadOnly = true;
                this.txtPayment.Properties.ReadOnly = true;
                this.txtSupplierName.Properties.ReadOnly = true;
                this.txtTaxAmount.Properties.ReadOnly = true;
                this.txtTaxpayerID.Properties.ReadOnly = true;
                this.txtTaxRebateRate.Properties.ReadOnly = true;
                this.Text = "查看交单信息";
                BindInvoice(CurrentInvoice.ID); ;
            }

        }


        private void BindInvoice(int id)
        {
            Invoice invoice = im.GetInvoice(id);
            if (invoice != null)
            {
                this.txtCode.EditValue = invoice.Code;
                this.txtCommission.EditValue = invoice.Commission;
                List<Budget> budgetList = cboBudget.Properties.DataSource as List<Budget>;
                if (budgetList != null)
                {
                    this.cboBudget.EditValue = budgetList.Find(o => o.ID == invoice.BudgetID);
                }
                this.txtCustomsDeclaration.EditValue = invoice.CustomsDeclaration;
                this.txtExchangeRate.EditValue = invoice.ExchangeRate;
                this.txtFeedMoney.EditValue = invoice.FeedMoney;
                this.txtFinanceImportDate.EditValue = invoice.FinanceImportDate;

                this.txtFinanceImportUser.EditValue = new User() { UserName = invoice.FinanceImportUser, RealName = invoice.FinanceImportUserName };
                this.txtImportDate.EditValue = invoice.ImportDate;

                this.txtImportUser.EditValue = new User() { UserName = invoice.ImportUser, RealName = invoice.ImportUserName };
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
            Budget budget = cboBudget.EditValue as Budget;
            if (budget == null)
            {
                this.dxErrorProvider1.SetError(this.cboBudget, "请选择合同号");
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
            if (string.IsNullOrEmpty(txtCustomsDeclaration.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtCustomsDeclaration, "请输入报关单");
            }
        }

        private void CheckModifyInput()
        {
            this.CheckNewInput();
            //if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            //{
            //    this.dxErrorProvider1.SetError(this.txtCode, "请输入发票代码");
            //}
            //if (string.IsNullOrEmpty(this.txtTaxpayerID.Text.Trim()))
            //{
            //    this.dxErrorProvider1.SetError(this.txtTaxpayerID, "请输入销方税号");
            //}
            //if (string.IsNullOrEmpty(this.txtSupplierName.Text.Trim()))
            //{
            //    this.dxErrorProvider1.SetError(this.txtSupplierName, "请输入销方名称");
            //}
            //if (this.txtPayment.Value <= 0)
            //{
            //    this.dxErrorProvider1.SetError(this.txtPayment, "金额应大于0");
            //}
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
            InputData();
            im.AddInvoice(CurrentInvoice);
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
            InputData();
            im.ModifyInvoice(CurrentInvoice);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void InputData()
        {
            if (CurrentInvoice == null)
            {
                CurrentInvoice = new Invoice();
                CurrentInvoice.ImportDate = datetimeNow;
            }

            Budget budget = (Budget)this.cboBudget.EditValue;
            CurrentInvoice.ContractNO = budget.ContractNO;
            CurrentInvoice.BudgetID = budget.ID;
            CurrentInvoice.Code = txtCode.Text.Trim();
            CurrentInvoice.Number = this.txtNumber.Text.Trim();
            CurrentInvoice.OriginalCoin = this.txtOriginalCoin.Value;
            CurrentInvoice.ExchangeRate = this.txtExchangeRate.Value;
            CurrentInvoice.CustomsDeclaration = this.txtCustomsDeclaration.Text.Trim();
            CurrentInvoice.TaxRebateRate = this.txtTaxRebateRate.FloatValue;
            CurrentInvoice.Commission = this.txtCommission.Value;
            CurrentInvoice.FeedMoney = this.txtFeedMoney.Value;
            CurrentInvoice.SupplierName = this.txtSupplierName.Text.Trim();
            CurrentInvoice.TaxpayerID = this.txtTaxpayerID.Text.Trim();
            CurrentInvoice.Payment = this.txtPayment.Value;
            User importUser = (User)this.txtImportUser.EditValue;
            CurrentInvoice.ImportUser = importUser != null ? importUser.UserName : RunInfo.Instance.CurrentUser.UserName;

            CurrentInvoice.FinanceImportUser = RunInfo.Instance.CurrentUser.UserName;
            CurrentInvoice.TaxAmount = this.txtTaxAmount.Value;
            CurrentInvoice.FinanceImportDate = datetimeNow;
        }

        public override void PrintData()
        {
            this.Height -= 50;
            PrinterHelper.PrintControl(true, this.layoutControl1);
        }
    }
}