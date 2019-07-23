﻿using System;
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
        BudgetManager bm = new BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        DeclarationformManager dm = new DeclarationformManager();
        public Declarationform CurrentDeclarationform { get; set; }

        public frmDeclarationformEdit()
        {
            InitializeComponent();
            txtExportDate.EditValue = DateTime.Now;
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

                this.textEdit5.EditValue = DateTime.Now;
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
            }
        }

        private void BindDeclarationform(int id)
        {
            CurrentDeclarationform = dm.GetDeclarationformByID(id);
            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            if (budgetList != null)
            {
                this.cboBudget.EditValue = budgetList.Find(o => o.ID== CurrentDeclarationform.BudgetID);
            }

            this.txtNO.EditValue = CurrentDeclarationform.NO;
            this.txtExportAmount.EditValue = CurrentDeclarationform.ExportAmount;
            this.txtExportDate.EditValue = CurrentDeclarationform.ExportDate;
            this.txtExchangeRate.EditValue = CurrentDeclarationform.ExchangeRate;
            this.textEdit5.EditValue = CurrentDeclarationform.CreateDate;
            this.textEdit6.EditValue = CurrentDeclarationform.CreateUser;
            this.cboCurrency.Text = CurrentDeclarationform.Currency;
        }

        private void CheckInputData()
        {
            if (string.IsNullOrEmpty(this.txtNO.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtNO, "请输入报关单号");
            }
            else if (dm.CheckNumber(this.txtNO.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtNO, "报关单号存在重复");
            }

            if (this.cboCurrency.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.cboCurrency, "请选择报关币种");
            }
            if (this.txtExportAmount.Value <= 0)
            {
                this.dxErrorProvider1.SetError(this.txtExportAmount, "请输入出口金额");
            }
            if (this.txtExchangeRate.Value <= 0)
            {
                this.dxErrorProvider1.SetError(this.txtExchangeRate, "请输入汇率");
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

            if (CurrentDeclarationform == null)
            {
                CurrentDeclarationform = new Declarationform();
            }
            this.CurrentDeclarationform.ContractNO = (this.cboBudget.EditValue as Budget).ContractNO;

            CurrentDeclarationform.NO = this.txtNO.Text;
            CurrentDeclarationform.ExportAmount = this.txtExportAmount.Value;
            CurrentDeclarationform.ExchangeRate = this.txtExchangeRate.FloatValue;
            CurrentDeclarationform.ExportDate = DateTime.Parse(this.txtExportDate.EditValue.ToString());
            CurrentDeclarationform.CreateDate = DateTime.Parse(this.textEdit5.EditValue.ToString());
            CurrentDeclarationform.CreateUser = this.textEdit6.Text;
            CurrentDeclarationform.Currency = this.cboCurrency.EditValue.ToString();
            CurrentDeclarationform.BudgetID = (this.cboBudget.EditValue as Budget).ID;


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