namespace BudgetSystem.InMoney
{
    partial class frmInMoneyQuery
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
            this.gcInMoney = new DevExpress.XtraGrid.GridControl();
            this.gvInMoney = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemitter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnumFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradingPostscript = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInMoney
            // 
            this.gcInMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInMoney.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcInMoney.Location = new System.Drawing.Point(0, 0);
            this.gcInMoney.MainView = this.gvInMoney;
            this.gcInMoney.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcInMoney.Name = "gcInMoney";
            this.gcInMoney.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gcInMoney.Size = new System.Drawing.Size(1115, 768);
            this.gcInMoney.TabIndex = 1;
            this.gcInMoney.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInMoney});
            // 
            // gvInMoney
            // 
            this.gvInMoney.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcVoucherNo,
            this.gcState,
            this.gcBankName,
            this.gcRemitter,
            this.gcCurrency,
            this.gcEnumFlowState,
            this.gcOriginalCoin,
            this.gcExchangeRate,
            this.gcCNY,
            this.gcTradingPostscript,
            this.gcExportName,
            this.gcPaymentMethod,
            this.gcReceiptDate,
            this.gcCreateUser,
            this.gcCreateTimestamp,
            this.gcDescription});
            this.gvInMoney.GridControl = this.gcInMoney;
            this.gvInMoney.Name = "gvInMoney";
            this.gvInMoney.OptionsBehavior.Editable = false;
            this.gvInMoney.OptionsView.ShowDetailButtons = false;
            this.gvInMoney.OptionsView.ShowGroupPanel = false;
            // 
            // gcVoucherNo
            // 
            this.gcVoucherNo.Caption = "银行凭证号";
            this.gcVoucherNo.FieldName = "VoucherNo";
            this.gcVoucherNo.Name = "gcVoucherNo";
            this.gcVoucherNo.Visible = true;
            this.gcVoucherNo.VisibleIndex = 0;
            // 
            // gcState
            // 
            this.gcState.Caption = "入账状态";
            this.gcState.FieldName = "ReceiptState";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 1;
            // 
            // gcBankName
            // 
            this.gcBankName.Caption = "银行";
            this.gcBankName.FieldName = "BankName";
            this.gcBankName.Name = "gcBankName";
            this.gcBankName.Visible = true;
            this.gcBankName.VisibleIndex = 2;
            // 
            // gcRemitter
            // 
            this.gcRemitter.Caption = "客户名称";
            this.gcRemitter.FieldName = "Remitter";
            this.gcRemitter.Name = "gcRemitter";
            this.gcRemitter.Visible = true;
            this.gcRemitter.VisibleIndex = 3;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币种";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 4;
            // 
            // gcEnumFlowState
            // 
            this.gcEnumFlowState.Caption = "审批状态";
            this.gcEnumFlowState.FieldName = "EnumFlowStateDisplayValue";
            this.gcEnumFlowState.Name = "gcEnumFlowState";
            this.gcEnumFlowState.Visible = true;
            this.gcEnumFlowState.VisibleIndex = 5;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "实收原币金额";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 6;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 7;
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "实收人民币金额";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 8;
            // 
            // gcTradingPostscript
            // 
            this.gcTradingPostscript.Caption = "交易附言";
            this.gcTradingPostscript.FieldName = "TradingPostscript";
            this.gcTradingPostscript.Name = "gcTradingPostscript";
            this.gcTradingPostscript.Visible = true;
            this.gcTradingPostscript.VisibleIndex = 9;
            // 
            // gcExportName
            // 
            this.gcExportName.Caption = "出口名称";
            this.gcExportName.FieldName = "ExportName";
            this.gcExportName.Name = "gcExportName";
            this.gcExportName.Visible = true;
            this.gcExportName.VisibleIndex = 10;
            // 
            // gcPaymentMethod
            // 
            this.gcPaymentMethod.Caption = "支付方式";
            this.gcPaymentMethod.FieldName = "PaymentMethod";
            this.gcPaymentMethod.Name = "gcPaymentMethod";
            this.gcPaymentMethod.Visible = true;
            this.gcPaymentMethod.VisibleIndex = 11;
            // 
            // gcReceiptDate
            // 
            this.gcReceiptDate.Caption = "收汇日期";
            this.gcReceiptDate.FieldName = "ReceiptDate";
            this.gcReceiptDate.Name = "gcReceiptDate";
            this.gcReceiptDate.Visible = true;
            this.gcReceiptDate.VisibleIndex = 12;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "创建人";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 13;
            // 
            // gcCreateTimestamp
            // 
            this.gcCreateTimestamp.Caption = "创建时间";
            this.gcCreateTimestamp.FieldName = "CreateTimestamp";
            this.gcCreateTimestamp.Name = "gcCreateTimestamp";
            this.gcCreateTimestamp.Visible = true;
            this.gcCreateTimestamp.VisibleIndex = 14;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 15;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // frmInMoneyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 768);
            this.Controls.Add(this.gcInMoney);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmInMoneyQuery";
            this.Text = "收款管理";
            ((System.ComponentModel.ISupportInitialize)(this.gcInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcInMoney;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemitter;
        private DevExpress.XtraGrid.Columns.GridColumn gcVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradingPostscript;
        private DevExpress.XtraGrid.Columns.GridColumn gcExportName;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnumFlowState;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}