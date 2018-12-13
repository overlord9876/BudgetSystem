namespace BudgetSystem
{
    partial class frmOutMoneyQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcOutMoney = new DevExpress.XtraGrid.GridControl();
            this.gvOutMoney = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBudgetNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnumFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApplicant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommitTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExpectedReturnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneyUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRepayLoanText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsDrawback = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHasInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // gcOutMoney
            // 
            this.gcOutMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOutMoney.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.gcOutMoney.Location = new System.Drawing.Point(0, 0);
            this.gcOutMoney.MainView = this.gvOutMoney;
            this.gcOutMoney.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.gcOutMoney.Name = "gcOutMoney";
            this.gcOutMoney.Size = new System.Drawing.Size(1008, 729);
            this.gcOutMoney.TabIndex = 1;
            this.gcOutMoney.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutMoney});
            // 
            // gvOutMoney
            // 
            this.gvOutMoney.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSupplier,
            this.gcBudgetNO,
            this.gcVoucherNo,
            this.gcOriginalCoin,
            this.gcEnumFlowState,
            this.gcCurrency,
            this.gcExchangeRate,
            this.gcCNY,
            this.gcApplicant,
            this.gcCommitTime,
            this.gcPaymentDate,
            this.gcDescription,
            this.gcDepartmentCode,
            this.gcMoneyUsed,
            this.gcRepayLoanText,
            this.gcExpectedReturnDate,
            this.gcIsDrawback,
            this.gcHasInvoice,
            this.gcPaymentMethod});
            this.gvOutMoney.GridControl = this.gcOutMoney;
            this.gvOutMoney.Name = "gvOutMoney";
            this.gvOutMoney.OptionsBehavior.Editable = false;
            this.gvOutMoney.OptionsView.ShowGroupPanel = false;
            // 
            // gcSupplier
            // 
            this.gcSupplier.Caption = "供应商";
            this.gcSupplier.FieldName = "SupplierName";
            this.gcSupplier.Name = "gcSupplier";
            this.gcSupplier.Visible = true;
            this.gcSupplier.VisibleIndex = 0;
            // 
            // gcBudgetNO
            // 
            this.gcBudgetNO.Caption = "合同号";
            this.gcBudgetNO.FieldName = "ContractNO";
            this.gcBudgetNO.Name = "gcBudgetNO";
            this.gcBudgetNO.Visible = true;
            this.gcBudgetNO.VisibleIndex = 1;
            // 
            // gcVoucherNo
            // 
            this.gcVoucherNo.Caption = "付款单号";
            this.gcVoucherNo.FieldName = "VoucherNo";
            this.gcVoucherNo.Name = "gcVoucherNo";
            this.gcVoucherNo.Visible = true;
            this.gcVoucherNo.VisibleIndex = 2;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "付款原币金额";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 3;
            // 
            // gcEnumFlowState
            // 
            this.gcEnumFlowState.Caption = "审批状态";
            this.gcEnumFlowState.FieldName = "EnumFlowState";
            this.gcEnumFlowState.Name = "gcEnumFlowState";
            this.gcEnumFlowState.Visible = true;
            this.gcEnumFlowState.VisibleIndex = 4;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币种";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "付款人民币金额";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 5;
            // 
            // gcApplicant
            // 
            this.gcApplicant.Caption = "付款申请人";
            this.gcApplicant.FieldName = "Applicant";
            this.gcApplicant.Name = "gcApplicant";
            this.gcApplicant.Visible = true;
            this.gcApplicant.VisibleIndex = 6;
            // 
            // gcCommitTime
            // 
            this.gcCommitTime.Caption = "提交时间";
            this.gcCommitTime.FieldName = "CommitTime";
            this.gcCommitTime.Name = "gcCommitTime";
            this.gcCommitTime.Visible = true;
            this.gcCommitTime.VisibleIndex = 7;
            // 
            // gcExpectedReturnDate
            // 
            this.gcExpectedReturnDate.Caption = "预计归还时间";
            this.gcExpectedReturnDate.FieldName = "ExpectedReturnDate";
            this.gcExpectedReturnDate.Name = "gcExpectedReturnDate";
            this.gcExpectedReturnDate.Visible = true;
            this.gcExpectedReturnDate.VisibleIndex = 11;
            // 
            // gcPaymentDate
            // 
            this.gcPaymentDate.Caption = "付款日期";
            this.gcPaymentDate.FieldName = "PaymentDate";
            this.gcPaymentDate.Name = "gcPaymentDate";
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            // 
            // gcDepartmentCode
            // 
            this.gcDepartmentCode.Caption = "所属部门";
            this.gcDepartmentCode.FieldName = "DepartmentName";
            this.gcDepartmentCode.Name = "gcDepartmentCode";
            this.gcDepartmentCode.Visible = true;
            this.gcDepartmentCode.VisibleIndex = 9;
            // 
            // gcMoneyUsed
            // 
            this.gcMoneyUsed.Caption = "用途";
            this.gcMoneyUsed.FieldName = "MoneyUsedDesc";
            this.gcMoneyUsed.Name = "gcMoneyUsed";
            this.gcMoneyUsed.Visible = true;
            this.gcMoneyUsed.VisibleIndex = 10;
            // 
            // gcRepayLoanText
            // 
            this.gcRepayLoanText.Caption = "借款信息";
            this.gcRepayLoanText.FieldName = "RepayLoanText";
            this.gcRepayLoanText.Name = "gcRepayLoanText";
            this.gcRepayLoanText.Visible = true;
            this.gcRepayLoanText.VisibleIndex = 11;
            // 
            // gcIsDrawback
            // 
            this.gcIsDrawback.Caption = "是否退税";
            this.gcIsDrawback.FieldName = "IsDrawback";
            this.gcIsDrawback.Name = "gcIsDrawback";
            // 
            // gcHasInvoice
            // 
            this.gcHasInvoice.Caption = "收到货款发票";
            this.gcHasInvoice.FieldName = "HasInvoice";
            this.gcHasInvoice.Name = "gcHasInvoice";
            // 
            // gcPaymentMethod
            // 
            this.gcPaymentMethod.Caption = "付款方式";
            this.gcPaymentMethod.FieldName = "PaymentMethod";
            this.gcPaymentMethod.Name = "gcPaymentMethod";
            // 
            // frmOutMoneyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.gcOutMoney);
            this.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.Name = "frmOutMoneyQuery";
            this.Text = "付款管理";
            ((System.ComponentModel.ISupportInitialize)(this.gcOutMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutMoney)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcOutMoney;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
        private DevExpress.XtraGrid.Columns.GridColumn gcApplicant;
        private DevExpress.XtraGrid.Columns.GridColumn gcExpectedReturnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gcCommitTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcBudgetNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneyUsed;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsDrawback;
        private DevExpress.XtraGrid.Columns.GridColumn gcHasInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn gcVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnumFlowState;
        private DevExpress.XtraGrid.Columns.GridColumn gcRepayLoanText;
    }
}