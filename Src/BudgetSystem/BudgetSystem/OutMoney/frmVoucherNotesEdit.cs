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
    public partial class frmVoucherNotesEdit : frmBaseDialogForm
    {
        private DateTime datetimeNow = DateTime.MinValue;
        private CommonManager cm = new CommonManager();
        BudgetManager bm = new BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        DeclarationformManager dm = new DeclarationformManager();
        public Declarationform CurrentDeclarationform { get; set; }

        public frmVoucherNotesEdit()
        {
            InitializeComponent();
            datetimeNow = cm.GetDateTimeNow();
        }

        private void frmDeclarationformEdit_Load(object sender, EventArgs e)
        {

            SetLayoutControlStyle();
            InitData();
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit6.Properties.ReadOnly = true;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "新增报关单信息";

                this.textEdit5.EditValue = datetimeNow;
                this.textEdit6.Text = RunInfo.Instance.CurrentUser.UserName;
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
                this.cboBudget.Properties.ReadOnly = true;

                this.txtNO.Properties.ReadOnly = true;
                this.txtExportAmount.Properties.ReadOnly = true;
                this.txtExportDate.Properties.ReadOnly = true;
                this.cboCurrency.Properties.ReadOnly = true;
                this.chkIsReport.Properties.ReadOnly = true;
            }
        }

        private void BindDeclarationform(int id)
        {
            CurrentDeclarationform = dm.GetDeclarationformByID(id);
            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            if (budgetList != null)
            {
                this.cboBudget.EditValue = budgetList.Find(o => o.ContractNO == CurrentDeclarationform.ContractNO);
            }

            this.txtNO.EditValue = CurrentDeclarationform.NO;
            this.txtExportAmount.EditValue = CurrentDeclarationform.ExportAmount;
            this.txtExportDate.EditValue = CurrentDeclarationform.ExportDate;
            this.textEdit5.EditValue = CurrentDeclarationform.CreateDate;
            this.textEdit6.EditValue = CurrentDeclarationform.CreateUser;
            this.cboCurrency.EditValue = CurrentDeclarationform.Currency;
            this.chkIsReport.EditValue = CurrentDeclarationform.IsReport;

        }

        private void CheckInputData()
        {
            if (string.IsNullOrEmpty(this.txtNO.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtNO, "请输入报关单号");
            }
            if (this.cboCurrency.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.cboCurrency, "请选择报关币种");
            }
            if (this.txtExportAmount.Value <= 0)
            {
                this.dxErrorProvider1.SetError(this.txtExportAmount, "请输入出口金额");
            }
            if (!(this.cboBudget.EditValue is Budget))
            {
                this.dxErrorProvider1.SetError(this.cboBudget, "请选择合同号");
            }
        }

        private void FillData()
        {

            if (CurrentDeclarationform == null)
            {
                CurrentDeclarationform = new Declarationform();
            }
            this.CurrentDeclarationform.ContractNO = (this.cboBudget.EditValue as Budget).ContractNO;

            CurrentDeclarationform.NO = this.txtNO.Text;
            CurrentDeclarationform.ExportAmount = this.txtExportAmount.Value;
            CurrentDeclarationform.ExportDate = DateTime.Parse(this.txtExportDate.EditValue.ToString());
            CurrentDeclarationform.CreateDate = DateTime.Parse(this.textEdit5.EditValue.ToString());
            CurrentDeclarationform.CreateUser = this.textEdit6.Text;
            CurrentDeclarationform.Currency = this.cboCurrency.EditValue.ToString();
            CurrentDeclarationform.IsReport = this.chkIsReport.Checked;


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

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }
            FillData();
            dm.ModifyDeclarationform(this.CurrentDeclarationform);
        }
    }
}