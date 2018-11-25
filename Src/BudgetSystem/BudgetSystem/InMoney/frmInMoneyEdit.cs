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
        private ReceiptMgmtManager arm = new ReceiptMgmtManager();
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private SystemConfigManager scm = new SystemConfigManager();
        private UserManager um = new UserManager();

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
            CurrentBankSlip.BSID = arm.AddBankSlip(CurrentBankSlip);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            ucInMoneyEdit1.FillData();

            if (!ucInMoneyEdit1.CheckUIInput())
            {
                return;
            }
            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;

            arm.ModifyBankSlip(CurrentBankSlip);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitConstData()
        {
            base.SubmitSplitConstData();
            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;

            arm.SplitAmountOfBankSlip(CurrentBankSlip, ucInMoneyEdit1.SpliDetail);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitSplitToBudgetData()
        {
            base.SubmitSplitToBudgetData();

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
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.CurrentBankSlip = ucInMoneyEdit1.CurrentBankSlip;
            if (this.ucInMoneyEdit1.SpliDetail != null)
            {
                arm.SplitAmountOfBankSlip(CurrentBankSlip, ucInMoneyEdit1.SpliDetail);
            }
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