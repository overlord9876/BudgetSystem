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
using Newtonsoft.Json;

namespace BudgetSystem.InMoney
{
    public partial class frmInMoneyEdit : frmBaseDialogForm
    {
        private ReceiptMgmtManager rm = new ReceiptMgmtManager();

        public frmInMoneyEdit()
        {
            InitializeComponent();
            this.lci_CommitButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ucInMoneyEdit1.CanCommitEventHandler += new EventHandler<EventArgs>(ucInMoneyEdit1_CanCommitEventHandler);
        }

        public BankSlip CurrentBankSlip
        {
            get;
            set;
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();
            if (!ucInMoneyEdit1.CheckUIInput())
            {
                return;
            }
            ucInMoneyEdit1.FillData();
            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;
            CurrentBankSlip.BSID = rm.AddBankSlip(CurrentBankSlip);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            if (!ucInMoneyEdit1.CheckUIInput())
            {
                return;
            }
            ucInMoneyEdit1.FillData();

            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;

            rm.ModifyBankSlip(CurrentBankSlip);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitToBudgetData()
        {
            base.SubmitSplitToBudgetData();

            if (!ucInMoneyEdit1.CheckUIInput())
            {
                return;
            }
            ucInMoneyEdit1.FillData();

            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;
            if (this.ucInMoneyEdit1.SpliDetail != null)
            {
                CurrentBankSlip.ReceiptState = ReceiptState.已拆分;
                rm.SplitAmountOfBankSlip(CurrentBankSlip, ucInMoneyEdit1.SpliDetail, true);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SaveSplitToBudgetData()
        {
            if (!ucInMoneyEdit1.CheckUIInput())
            {
                return;
            }
            ucInMoneyEdit1.FillData();

            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;
            if (this.ucInMoneyEdit1.SpliDetail != null)
            {
                CurrentBankSlip.ReceiptState = ReceiptState.拆分中;
                rm.SplitAmountOfBankSlip(CurrentBankSlip, ucInMoneyEdit1.SpliDetail, false);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void ucInMoneyEdit1_CanCommitEventHandler(object sender, EventArgs e)
        {
            this.lci_CommitButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();
        }

        private void frmInMemoryEdit_Load(object sender, EventArgs e)
        {
            this.ucInMoneyEdit1.WorkModel = this.WorkModel;

            if (this.WorkModel != EditFormWorkModels.New)
            {
                this.ucInMoneyEdit1.BindBankSlip(this.CurrentBankSlip);
                if (this.WorkModel == EditFormWorkModels.Modify)
                {
                    lci_CommitButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
            if (this.WorkModel == EditFormWorkModels.View)
            {
                lci_CommitButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (RunInfo.Instance.CurrentUser.Role == StringUtil.SaleRoleCode)
            {
                this.btnSure.Text = "收汇确认";
            }
            else
            {
                this.btnSure.Text = "通知业务员";
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (WorkModel == EditFormWorkModels.SplitToBudget)
            {
                SaveSplitToBudgetData();
            }
            else
            {
                SubmitDataByWorkModel();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}