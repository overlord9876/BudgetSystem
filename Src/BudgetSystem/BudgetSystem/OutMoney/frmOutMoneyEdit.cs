﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using Newtonsoft.Json;

namespace BudgetSystem.OutMoney
{
    public partial class frmOutMoneyEdit : frmBaseDialogForm
    {
        PaymentNotesManager pnm = new PaymentNotesManager();

        public PaymentNotes CurrentPaymentNotes { get; set; }

        public frmOutMoneyEdit()
        {
            InitializeComponent();
        }

        private void frmOutMemoryEdit_Load(object sender, EventArgs e)
        {
            if (IsDesignMode)
            {
                return;
            }
            this.ucOutMoneyEdit1.WorkModel = this.WorkModel;
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "新增付款信息";
            }
            else
            {
                this.ucOutMoneyEdit1.BandPaymentNotes(CurrentPaymentNotes);
            }

            if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑付款信息";
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看付款信息";
                this.emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciCommit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (this.WorkModel == EditFormWorkModels.Custom)
            {
                this.Text = "借条归还确认";
                this.btnSure.Text = "保存并打印";
                this.lciCommit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            if (this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;
            this.CurrentPaymentNotes.ID = pnm.AddPaymentNote(this.CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            if (this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;

            this.CurrentPaymentNotes.UpdateTimestamp = pnm.ModifyPaymentNote(this.CurrentPaymentNotes);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();

            if (this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;

            //CurrentPaymentNotes.RepayLoan = true;

            CurrentPaymentNotes.UpdateTimestamp = pnm.ModifyPaymentNote(CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            if (!RunInfo.Instance.CurrentUser.UserName.Equals(this.ucOutMoneyEdit1.CurrentPaymentNotes.Applicant))
            {
                XtraMessageBox.Show(string.Format("当前付款单由{0}创建，不允许由{1}提交流程。", this.ucOutMoneyEdit1.CurrentPaymentNotes.ApplicantRealName, RunInfo.Instance.CurrentUser.RealName));
                return;
            }
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;

            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.CurrentPaymentNotes.ID = pnm.AddPaymentNote(this.CurrentPaymentNotes);
            }
            else
            {
                this.CurrentPaymentNotes.UpdateTimestamp = pnm.ModifyPaymentNote(this.CurrentPaymentNotes);
            }
            string message = pnm.StartFlow(this.CurrentPaymentNotes.ID, RunInfo.Instance.CurrentUser.UserName);
            if (string.IsNullOrEmpty(message))
            {
                XtraMessageBox.Show("提交流程成功。");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(message);
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

        public override void PrintData()
        {
            this.Height -= 50;
            PrinterHelper.PrintControl(true, this.layoutControl1, Size.Empty);
        }
    }
}