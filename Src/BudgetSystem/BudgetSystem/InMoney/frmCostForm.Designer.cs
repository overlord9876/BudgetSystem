namespace BudgetSystem.InMoney
{
    partial class frmCostForm
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
            this.gridInvoice = new DevExpress.XtraGrid.GridControl();
            this.gvInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxRebate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxRebateRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrossProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFeedMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAccountsPayable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInvoice
            // 
            this.gridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridInvoice.Location = new System.Drawing.Point(0, 0);
            this.gridInvoice.MainView = this.gvInvoice;
            this.gridInvoice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Size = new System.Drawing.Size(1695, 723);
            this.gridInvoice.TabIndex = 1;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoice});
            // 
            // gvInvoice
            // 
            this.gvInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDepartmentCode,
            this.gcContractNO,
            this.gcCustomer,
            this.gcOriginalCoin,
            this.gcCNY,
            this.gcPayment,
            this.gcTaxAmount,
            this.gcFeedMoney,
            this.gcTaxRebate,
            this.gcNumber,
            this.gcAccountsPayable,
            this.gcSupplierName,
            this.gcTotalCost,
            this.gcGrossProfit,
            this.gcTaxRebateRate});
            this.gvInvoice.GridControl = this.gridInvoice;
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.OptionsBehavior.Editable = false;
            this.gvInvoice.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gvInvoice.OptionsView.ShowFooter = true;
            this.gvInvoice.OptionsView.ShowGroupPanel = false;
            // 
            // gcDepartmentCode
            // 
            this.gcDepartmentCode.Caption = "部门";
            this.gcDepartmentCode.FieldName = "DepartmentCode";
            this.gcDepartmentCode.Name = "gcDepartmentCode";
            this.gcDepartmentCode.OptionsColumn.AllowEdit = false;
            this.gcDepartmentCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DepartmentCode", "合计：{0:d}")});
            this.gcDepartmentCode.Visible = true;
            this.gcDepartmentCode.VisibleIndex = 0;
            this.gcDepartmentCode.Width = 96;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.OptionsColumn.AllowEdit = false;
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 1;
            this.gcContractNO.Width = 159;
            // 
            // gcCustomer
            // 
            this.gcCustomer.Caption = "客户";
            this.gcCustomer.FieldName = "CustomerName";
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Visible = true;
            this.gcCustomer.VisibleIndex = 2;
            this.gcCustomer.Width = 156;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "原币";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.OptionsColumn.AllowEdit = false;
            this.gcOriginalCoin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 3;
            this.gcOriginalCoin.Width = 101;
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "人民币销售";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 4;
            this.gcCNY.Width = 113;
            // 
            // gcTaxRebate
            // 
            this.gcTaxRebate.Caption = "出口退税";
            this.gcTaxRebate.FieldName = "TaxRebate";
            this.gcTaxRebate.Name = "gcTaxRebate";
            this.gcTaxRebate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcTaxRebate.Visible = true;
            this.gcTaxRebate.VisibleIndex = 8;
            this.gcTaxRebate.Width = 100;
            // 
            // gcNumber
            // 
            this.gcNumber.Caption = "进项转出";
            this.gcNumber.FieldName = "IncomeExits";
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 9;
            this.gcNumber.Width = 100;
            // 
            // gcPayment
            // 
            this.gcPayment.Caption = "金额";
            this.gcPayment.FieldName = "Payment";
            this.gcPayment.Name = "gcPayment";
            this.gcPayment.OptionsColumn.AllowEdit = false;
            this.gcPayment.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcPayment.Visible = true;
            this.gcPayment.VisibleIndex = 5;
            this.gcPayment.Width = 100;
            // 
            // gcTaxAmount
            // 
            this.gcTaxAmount.Caption = "税金";
            this.gcTaxAmount.FieldName = "TaxAmount";
            this.gcTaxAmount.Name = "gcTaxAmount";
            this.gcTaxAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcTaxAmount.Visible = true;
            this.gcTaxAmount.VisibleIndex = 6;
            this.gcTaxAmount.Width = 100;
            // 
            // gcTaxRebateRate
            // 
            this.gcTaxRebateRate.Caption = "退税率";
            this.gcTaxRebateRate.FieldName = "TaxRebateRate";
            this.gcTaxRebateRate.Name = "gcTaxRebateRate";
            this.gcTaxRebateRate.Visible = true;
            this.gcTaxRebateRate.VisibleIndex = 14;
            this.gcTaxRebateRate.Width = 92;
            // 
            // gcGrossProfit
            // 
            this.gcGrossProfit.Caption = "销售毛利润";
            this.gcGrossProfit.FieldName = "GrossProfit";
            this.gcGrossProfit.Name = "gcGrossProfit";
            this.gcGrossProfit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcGrossProfit.Visible = true;
            this.gcGrossProfit.VisibleIndex = 13;
            this.gcGrossProfit.Width = 124;
            // 
            // gcFeedMoney
            // 
            this.gcFeedMoney.Caption = "进料款";
            this.gcFeedMoney.FieldName = "FeedMoney";
            this.gcFeedMoney.Name = "gcFeedMoney";
            this.gcFeedMoney.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcFeedMoney.Visible = true;
            this.gcFeedMoney.VisibleIndex = 7;
            this.gcFeedMoney.Width = 100;
            // 
            // gcTotalCost
            // 
            this.gcTotalCost.Caption = "成本";
            this.gcTotalCost.FieldName = "TotalCost";
            this.gcTotalCost.Name = "gcTotalCost";
            this.gcTotalCost.OptionsColumn.AllowEdit = false;
            this.gcTotalCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcTotalCost.Visible = true;
            this.gcTotalCost.VisibleIndex = 12;
            this.gcTotalCost.Width = 118;
            // 
            // gcSupplierName
            // 
            this.gcSupplierName.Caption = "销方名称";
            this.gcSupplierName.FieldName = "SupplierName";
            this.gcSupplierName.Name = "gcSupplierName";
            this.gcSupplierName.Visible = true;
            this.gcSupplierName.VisibleIndex = 11;
            this.gcSupplierName.Width = 118;
            // 
            // gcAccountsPayable
            // 
            this.gcAccountsPayable.Caption = "应付账款";
            this.gcAccountsPayable.FieldName = "AccountsPayable";
            this.gcAccountsPayable.Name = "gcAccountsPayable";
            this.gcAccountsPayable.OptionsColumn.AllowEdit = false;
            this.gcAccountsPayable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcAccountsPayable.Visible = true;
            this.gcAccountsPayable.VisibleIndex = 10;
            this.gcAccountsPayable.Width = 100;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel|*.xlsx;*.xls";
            this.openFileDialog1.Title = "选择导入数据文件";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xlsx|Excel2003|*.xls";
            this.saveFileDialog1.Title = "保存";
            // 
            // frmCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1695, 723);
            this.Controls.Add(this.gridInvoice);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmCostForm";
            this.Text = "打印成本销售表";
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcPayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcAccountsPayable;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxRebate;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxRebateRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrossProfit;
        private DevExpress.XtraGrid.Columns.GridColumn gcFeedMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplierName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
    }
}