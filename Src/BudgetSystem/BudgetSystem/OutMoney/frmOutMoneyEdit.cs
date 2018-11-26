using System;
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
        Bll.FlowManager fm = new FlowManager();
        PaymentNotesManager pnm = new PaymentNotesManager();

        public PaymentNotes CurrentPaymentNotes { get; set; }

        public frmOutMoneyEdit()
        {
            InitializeComponent();
        }

        private void frmOutMemoryEdit_Load(object sender, EventArgs e)
        {
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
                this.lciCommit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            if (!this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;
            this.CurrentPaymentNotes.ID = pnm.AddPaymentNote(this.CurrentPaymentNotes);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            if (!this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;

            pnm.ModifyPaymentNote(this.CurrentPaymentNotes);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();

            if (!this.ucOutMoneyEdit1.CheckInputData()) { return; }
            this.ucOutMoneyEdit1.FillEditData();
            this.CurrentPaymentNotes = ucOutMoneyEdit1.CurrentPaymentNotes;

            pnm.ModifyPaymentNote(this.CurrentPaymentNotes);

            fm.StartFlow(EnumFlowNames.付款审批流程.ToString(), CurrentPaymentNotes.ID, CurrentPaymentNotes.VoucherNo, EnumFlowDataType.付款单.ToString(), RunInfo.Instance.CurrentUser.UserName);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}