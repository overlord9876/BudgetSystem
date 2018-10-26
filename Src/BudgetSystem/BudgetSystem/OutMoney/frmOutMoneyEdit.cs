﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;

namespace BudgetSystem.OutMoney
{
    public partial class frmOutMoneyEdit : frmBaseDialogForm
    {
        BudgetManager bm = new BudgetManager();
        SupplierManager sm = new SupplierManager();
        UserManager um = new UserManager();
        PaymentNotesManager pnm = new PaymentNotesManager();

        public PaymentNotes CurrentPaymentNotes { get; set; }

        public frmOutMoneyEdit()
        {
            InitializeComponent();
        }

        private void frmOutMemoryEdit_Load(object sender, EventArgs e)
        {
            SetLayoutControlStyle();

            InitData();
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "新增付款信息";
                this.txtPaymentDate.EditValue = DateTime.Now;
                this.txtApprover.Text = RunInfo.Instance.CurrentUser.UserName;
                this.txtApproveTime.Text = DateTime.Now.ToString();
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑付款信息";
                BandPaymentNotes(this.CurrentPaymentNotes.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看付款信息";
                BandPaymentNotes(this.CurrentPaymentNotes.ID);
            }
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }

            this.CurrentPaymentNotes = new PaymentNotes();
            FillEditData();
            pnm.AddPaymentNote(this.CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();

            CheckInputData();

            if (dxErrorProvider1.HasErrors) { return; }

            FillEditData();
            pnm.ModifyPaymentNote(this.CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CheckInputData()
        {
            if (cboSupplier.EditValue as Supplier == null)
            {
                this.dxErrorProvider1.SetError(cboSupplier, "请选择供应商。");
                return;
            }
            if (cboBudget.EditValue as Budget == null)
            {
                this.dxErrorProvider1.SetError(cboBudget, "请选择合同信息。");
                return;
            }
            if (cboPaymentMethod.EditValue == null || string.IsNullOrEmpty(cboPaymentMethod.EditValue.ToString()))
            {
                this.dxErrorProvider1.SetError(cboPaymentMethod, "请选择付款方式。");
                return;
            }
            if (txtTaxRebateRate.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtTaxRebateRate, "请输入退税率。");
                return;
            }
            if (txtMoney.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtMoney, "请输入用款金额。");
                return;
            }
            if (string.IsNullOrEmpty(txtVoucherNo.Text))
            {
                this.dxErrorProvider1.SetError(txtVoucherNo, "请输入凭证号。");
                return;
            }

            if (cboMoneyUsed.EditValue == null || string.IsNullOrEmpty(cboMoneyUsed.EditValue.ToString()))
            {
                this.dxErrorProvider1.SetError(txtVoucherNo, "请输入用款类型。");
                return;
            }

            if (cboApplicant.EditValue as User == null)
            {
                this.dxErrorProvider1.SetError(txtVoucherNo, "请选择申请人。");
                return;
            }
        }

        private void InitData()
        {

            this.cboBudget.Properties.DataSource = bm.GetAllBudget();

            this.cboSupplier.Properties.DataSource = sm.GetAllSupplier();

            this.cboApplicant.Properties.Items.AddRange(um.GetAllUser());
        }

        private void BandPaymentNotes(int id)
        {
            PaymentNotes payment = pnm.GetPaymentNoteById(id);

            this.txtApprover.Text = payment.Approver;
            this.txtApproveTime.EditValue = payment.ApproveTime;
            this.txtDescription.Text = payment.Description;
            this.txtMoney.EditValue = payment.Money;
            this.txtOverdue.EditValue = payment.Overdue;
            this.txtPaymentDate.EditValue = payment.PaymentDate;
            this.txtTaxRebateRate.EditValue = payment.TaxRebateRate;
            this.txtVoucherNo.Text = payment.VoucherNo;
            foreach (User u in this.cboApplicant.Properties.Items)
            {
                if (u.UserName == payment.Applicant)
                {
                    this.cboApplicant.SelectedItem = u;
                    this.cboDepartment.Text = u.Department;
                    break;
                }
            }
            this.cboMoneyUsed.SelectedText = payment.MoneyUsed;
            List<Supplier> supplierList = (List<Supplier>)this.cboSupplier.Properties.DataSource;
            if (supplierList != null)
            {
                this.cboSupplier.EditValue = supplierList.Find(o => o.ID == payment.SupplierID);
            }
            List<Budget> budgetList = (List<Budget>)this.cboBudget.Properties.DataSource;
            if (budgetList != null)
            {
                this.cboBudget.EditValue = budgetList.Find(o => o.ID == payment.BudgetID);
            }
            txtDescription.Text = payment.Description;
            chkHasInvoice.EditValue = payment.HasInvoice;
            chkIsDrawback.EditValue = payment.IsDrawback;
        }

        private void FillEditData()
        {
            this.CurrentPaymentNotes.Approver = this.txtApprover.Text.Trim();
            this.CurrentPaymentNotes.ApproveTime = DateTime.Parse(this.txtApproveTime.EditValue.ToString());
            this.CurrentPaymentNotes.Description = this.txtDescription.Text.Trim();
            this.CurrentPaymentNotes.Money = this.txtMoney.Value;
            this.CurrentPaymentNotes.Overdue = (int)this.txtOverdue.Value;
            this.CurrentPaymentNotes.PaymentDate = DateTime.Parse(this.txtPaymentDate.EditValue.ToString());
            this.CurrentPaymentNotes.TaxRebateRate = (float)this.txtTaxRebateRate.Value;
            this.CurrentPaymentNotes.VoucherNo = this.txtVoucherNo.Text;
            this.CurrentPaymentNotes.Applicant = this.cboApplicant.SelectedItem.ToString();
            this.CurrentPaymentNotes.MoneyUsed = this.cboMoneyUsed.SelectedText;

            this.CurrentPaymentNotes.SupplierID = (this.cboSupplier.EditValue as Supplier).ID;
            this.CurrentPaymentNotes.BudgetID = (this.cboBudget.EditValue as Budget).ID;

            this.CurrentPaymentNotes.Description = txtDescription.Text.Trim();
            this.CurrentPaymentNotes.HasInvoice = (bool)chkHasInvoice.EditValue;
            this.CurrentPaymentNotes.IsDrawback = (bool)chkIsDrawback.EditValue;
        }

        private void cboApplicant_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboBudget_EditValueChanged(object sender, EventArgs e)
        {
            //获取供应商
        }

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            Supplier editValue = (Supplier)cboSupplier.EditValue;
            if (editValue != null)
            {
                this.txtBankAccountName.Text = editValue.BankAccountName;
                this.txtBankName.Text = editValue.BankName;
                this.txtBankNO.Text = editValue.BankNO;
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

        private void btnSearchMoney_Click(object sender, EventArgs e)
        {

        }

    }
}