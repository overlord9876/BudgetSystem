using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmDeclarationformEdit : frmBaseDialogForm
    {
        private CommonManager cm = new CommonManager();
        private DateTime datetimeNow = DateTime.MinValue;
        BudgetManager bm = new BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        DeclarationformManager dm = new DeclarationformManager();
        public Declarationform CurrentDeclarationform { get; set; }

        public frmDeclarationformEdit()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
            txtExportDate.EditValue = datetimeNow;
        }

        private void frmDeclarationformEdit_Load(object sender, EventArgs e)
        {

            SetLayoutControlStyle();
            InitData();
            this.txtCreateDate.Properties.ReadOnly = true;
            this.txtCreateUser.Properties.ReadOnly = true;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "新增报关单信息";

                this.txtCreateDate.EditValue = datetimeNow;
                this.txtCreateUser.Text = RunInfo.Instance.CurrentUser.UserName;
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑报关单信息";
                BindDeclarationform(this.CurrentDeclarationform.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看报关单信息";
                BindDeclarationform(this.CurrentDeclarationform.ID);
                SetReadOnly();
            }
        }

        private void BindDeclarationform(int id)
        {
            CurrentDeclarationform = dm.GetDeclarationformByID(id);
            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            if (budgetList != null)
            {
                this.cboBudget.EditValue = budgetList.Find(o => o.ID == CurrentDeclarationform.BudgetID);
            }

            this.txtNO.EditValue = CurrentDeclarationform.NO;
            this.txtExportDate.EditValue = CurrentDeclarationform.ExportDate;
            this.txtOverseas.EditValue = CurrentDeclarationform.Overseas;
            this.txtTradeMode.EditValue = CurrentDeclarationform.TradeMode;
            this.txtPort.EditValue = CurrentDeclarationform.Port;
            this.cboCurrency.EditValue = CurrentDeclarationform.Currency;
            this.txtPriceClause.EditValue = CurrentDeclarationform.PriceClause;
            this.txtCountry.EditValue = CurrentDeclarationform.Country;
            this.txtProdNumber.EditValue = CurrentDeclarationform.ProdNumber;
            this.txtProdName.EditValue = CurrentDeclarationform.ProdName;
            this.txtModel.EditValue = CurrentDeclarationform.Model;
            this.txtDealCount.EditValue = CurrentDeclarationform.DealCount;
            this.txtDealUnit.EditValue = CurrentDeclarationform.DealUnit;
            this.txtPrice.EditValue = CurrentDeclarationform.Price;
            this.txtTotalPrice.EditValue = CurrentDeclarationform.TotalPrice;
            this.txtFinalCountry.EditValue = CurrentDeclarationform.FinalCountry;
            this.txtDomesticSource.EditValue = CurrentDeclarationform.DomesticSource;
            this.txtOffshoreTotalPrice.EditValue = CurrentDeclarationform.OffshoreTotalPrice;
            this.txtUSDOffshoreTotalPrice.EditValue = CurrentDeclarationform.USDOffshoreTotalPrice;
            this.txtCNYOffshoreTotalPrice.EditValue = CurrentDeclarationform.CNYOffshoreTotalPrice;
            this.txtUpdateUser.EditValue = CurrentDeclarationform.UpdateUserRealName;
            this.txtUpdateDate.EditValue = CurrentDeclarationform.UpdateDate;
            this.txtCreateDate.EditValue = CurrentDeclarationform.CreateDate;
            this.txtCreateUser.EditValue = CurrentDeclarationform.CreateUserRealName;
            this.cboCurrency.EditValue = CurrentDeclarationform.Currency;
        }

        private void CheckInputData()
        {
            if (string.IsNullOrEmpty(this.txtNO.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtNO, "请输入报关单号");
            }
            else if (dm.CheckNumber(this.txtNO.Text.Trim(), (double)this.txtDealCount.Value, this.txtTotalPrice.Value))
            {
                this.dxErrorProvider1.SetError(this.txtNO, "报关单号存在重复");
            }

            if (this.cboCurrency.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.cboCurrency, "请选择报关币种");
            }
            if (this.txtOffshoreTotalPrice.Value <= 0)
            {
                this.dxErrorProvider1.SetError(this.txtOffshoreTotalPrice, "请输入出口金额");
            }
            if (!(this.cboBudget.EditValue is Budget))
            {
                this.dxErrorProvider1.SetError(this.cboBudget, "请选择合同号");
            }
            else
            {
                if (dm.CheckContractNO((this.cboBudget.EditValue as Budget).ContractNO) < 0)
                {
                    this.dxErrorProvider1.SetError(this.cboBudget, "合同号不存在");
                }
            }
        }

        private void FillData()
        {

            if (this.CurrentDeclarationform == null)
            {
                this.CurrentDeclarationform = new Declarationform();
                this.CurrentDeclarationform.CreateDate = datetimeNow;
                this.CurrentDeclarationform.CreateUser = RunInfo.Instance.CurrentUser.UserName;
                this.CurrentDeclarationform.CreateUserRealName = RunInfo.Instance.CurrentUser.RealName;
            }
            this.CurrentDeclarationform.ContractNO = (this.cboBudget.EditValue as Budget).ContractNO;
            this.CurrentDeclarationform.NO = this.txtNO.Text;
            this.CurrentDeclarationform.BudgetID = (this.cboBudget.EditValue as Budget).ID;
            this.CurrentDeclarationform.ExportDate = DateTime.Parse(this.txtExportDate.EditValue.ToString());
            this.CurrentDeclarationform.Overseas = this.txtOverseas.Text;
            this.CurrentDeclarationform.TradeMode = this.txtTradeMode.Text;
            this.CurrentDeclarationform.Port = this.txtPort.Text;
            this.CurrentDeclarationform.Currency = this.cboCurrency.EditValue.ToString();
            this.CurrentDeclarationform.PriceClause = this.txtPriceClause.Text;
            this.CurrentDeclarationform.Country = this.txtCountry.Text;
            this.CurrentDeclarationform.ProdNumber = this.txtProdNumber.Text;
            this.CurrentDeclarationform.ProdName = this.txtProdName.Text;
            this.CurrentDeclarationform.Model = this.txtModel.Text;
            this.CurrentDeclarationform.DealCount = (double)this.txtDealCount.Value;
            this.CurrentDeclarationform.DealUnit = this.txtDealUnit.Text;
            this.CurrentDeclarationform.Price = this.txtPrice.Value;
            this.CurrentDeclarationform.TotalPrice = this.txtTotalPrice.Value;
            this.CurrentDeclarationform.FinalCountry = this.txtFinalCountry.Text;
            this.CurrentDeclarationform.DomesticSource = this.txtDomesticSource.Text;
            this.CurrentDeclarationform.OffshoreTotalPrice = this.txtOffshoreTotalPrice.Value;
            this.CurrentDeclarationform.USDOffshoreTotalPrice = this.txtUSDOffshoreTotalPrice.Value;
            this.CurrentDeclarationform.CNYOffshoreTotalPrice = this.txtCNYOffshoreTotalPrice.Value;
            this.CurrentDeclarationform.UpdateDate = datetimeNow;
            this.CurrentDeclarationform.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
            this.CurrentDeclarationform.UpdateUserRealName = RunInfo.Instance.CurrentUser.RealName;

        }

        private void InitData()
        {
            this.cboBudget.Properties.DataSource = bm.GetAllBudget();

            List<MoneyType> mtList = scm.GetSystemConfigValue<List<MoneyType>>(EnumSystemConfigNames.币种.ToString());
            if (mtList != null)
            {
                foreach (var mt in mtList)
                {
                    cboCurrency.Properties.Items.Add(mt.Name);
                }
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

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }
            FillData();
            this.CurrentDeclarationform.ID = dm.AddDeclarationform(this.CurrentDeclarationform);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }
            FillData();
            dm.ModifyDeclarationform(this.CurrentDeclarationform);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}