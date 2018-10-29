using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmPaymentCalcEdit : frmBaseDialogForm
    {
        /// <summary>
        /// 选择的合同
        /// </summary>
        public Budget SelectedBudget
        {
            get;
            set;
        }

        public decimal ReceiptAmount { get; set; }

        public frmPaymentCalcEdit()
        {
            InitializeComponent();
        }

        private void frmPaymentCalcEdit_Load(object sender, EventArgs e)
        {
            this.txtReceiptAmount.EditValue = ReceiptAmount;
            this.txtBudgetNo.EditValue = SelectedBudget.ContractNO;
            this.txtCustomer.Text = SelectedBudget.CustomerList.ToNameString();
            this.txtSupplier.Text = SelectedBudget.SupplierList.ToNameString();
            this.txtAdvancePayment.EditValue = SelectedBudget.AdvancePayment;
            this.txtApprovalState.EditValue = SelectedBudget.State;
            this.txtFeedMoney.EditValue = SelectedBudget.FeedMoney;
            //this.txtProfit.EditValue=SelectedBudget.
            //this.txtProfitLevel.EditValue=SelectedBudget.pro

        }


    }
}