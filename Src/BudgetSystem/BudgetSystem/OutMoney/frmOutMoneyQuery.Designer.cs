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
            this.gcType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApplicant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommitTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneyUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRepayLoanText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExpectedReturnDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gcOutMoney.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.gcOutMoney.Location = new System.Drawing.Point(0, 0);
            this.gcOutMoney.MainView = this.gvOutMoney;
            this.gcOutMoney.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.gcOutMoney.Name = "gcOutMoney";
            this.gcOutMoney.Size = new System.Drawing.Size(1152, 937);
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
            this.gcType,
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
            this.gvOutMoney.GroupCount = 1;
            this.gvOutMoney.Name = "gvOutMoney";
            this.gvOutMoney.OptionsBehavior.Editable = false;
            this.gvOutMoney.OptionsView.ShowFooter = true;
            this.gvOutMoney.OptionsView.ShowGroupPanel = false;
            this.gvOutMoney.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcEnumFlowState, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcRepayLoanText, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcPaymentDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gcSupplier
            // 
            this.gcSupplier.Caption = "供应商";
            this.gcSupplier.FieldName = "SupplierName";
            this.gcSupplier.GroupFormat.FormatString = "g";
            this.gcSupplier.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcSupplier.Name = "gcSupplier";
            this.gcSupplier.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SupplierName", "合计：{0:d}")});
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
            this.gcOriginalCoin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 3;
            // 
            // gcEnumFlowState
            // 
            this.gcEnumFlowState.Caption = "付款单审批状态";
            this.gcEnumFlowState.FieldName = "EnumFlowState";
            this.gcEnumFlowState.Name = "gcEnumFlowState";
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
            this.gcCNY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 4;
            // 
            // gcType
            // 
            this.gcType.Caption = "付款类型";
            this.gcType.FieldName = "PaymentType";
            this.gcType.Name = "gcType";
            this.gcType.Visible = true;
            this.gcType.VisibleIndex = 8;
            // 
            // gcApplicant
            // 
            this.gcApplicant.Caption = "付款申请人";
            this.gcApplicant.FieldName = "ApplicantRealName";
            this.gcApplicant.Name = "gcApplicant";
            this.gcApplicant.Visible = true;
            this.gcApplicant.VisibleIndex = 5;
            // 
            // gcCommitTime
            // 
            this.gcCommitTime.Caption = "提交时间";
            this.gcCommitTime.DisplayFormat.FormatString = "g";
            this.gcCommitTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCommitTime.FieldName = "CommitTime";
            this.gcCommitTime.Name = "gcCommitTime";
            this.gcCommitTime.Visible = true;
            this.gcCommitTime.VisibleIndex = 6;
            this.gcCommitTime.Width = 120;
            // 
            // gcPaymentDate
            // 
            this.gcPaymentDate.Caption = "付款日期";
            this.gcPaymentDate.DisplayFormat.FormatString = "g";
            this.gcPaymentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcPaymentDate.FieldName = "PaymentDate";
            this.gcPaymentDate.Name = "gcPaymentDate";
            this.gcPaymentDate.Visible = true;
            this.gcPaymentDate.VisibleIndex = 7;
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
            this.gcRepayLoanText.Caption = "借条信息";
            this.gcRepayLoanText.FieldName = "RepayLoanText";
            this.gcRepayLoanText.Name = "gcRepayLoanText";
            this.gcRepayLoanText.Visible = true;
            this.gcRepayLoanText.VisibleIndex = 11;
            // 
            // gcExpectedReturnDate
            // 
            this.gcExpectedReturnDate.Caption = "预计归还时间";
            this.gcExpectedReturnDate.FieldName = "ExpectedReturnDate";
            this.gcExpectedReturnDate.Name = "gcExpectedReturnDate";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 937);
            this.Controls.Add(this.gcOutMoney);
            this.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
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
        private DevExpress.XtraGrid.Columns.GridColumn gcType;
    }
}