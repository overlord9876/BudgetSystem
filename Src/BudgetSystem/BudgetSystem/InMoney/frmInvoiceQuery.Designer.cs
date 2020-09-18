namespace BudgetSystem.InMoney
{
    partial class frmInvoiceQuery
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
            this.components = new System.ComponentModel.Container();
            this.gridInvoice = new DevExpress.XtraGrid.GridControl();
            this.gvInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomsDeclaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxpayerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxRebateRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFeedMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrossProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImportUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFinanceImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pivotViewBar = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSelected = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSalesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomerNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSeaport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAdvancePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboSelectYear = new DevExpress.XtraBars.BarEditItem();
            this.cboYears = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnJanuary = new DevExpress.XtraBars.BarButtonItem();
            this.btnFebruary = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarch = new DevExpress.XtraBars.BarButtonItem();
            this.btnApril = new DevExpress.XtraBars.BarButtonItem();
            this.btnMay = new DevExpress.XtraBars.BarButtonItem();
            this.btnJune = new DevExpress.XtraBars.BarButtonItem();
            this.btnJuly = new DevExpress.XtraBars.BarButtonItem();
            this.btnAugust = new DevExpress.XtraBars.BarButtonItem();
            this.btnSeptember = new DevExpress.XtraBars.BarButtonItem();
            this.btnOctober = new DevExpress.XtraBars.BarButtonItem();
            this.btnNovember = new DevExpress.XtraBars.BarButtonItem();
            this.btnDecember = new DevExpress.XtraBars.BarButtonItem();
            this.deStartDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.deEndDate = new DevExpress.XtraBars.BarEditItem();
            this.barSelectedMode = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Print = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInvoice
            // 
            this.gridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridInvoice.Location = new System.Drawing.Point(0, 31);
            this.gridInvoice.MainView = this.gvInvoice;
            this.gridInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Size = new System.Drawing.Size(1286, 531);
            this.gridInvoice.TabIndex = 1;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoice});
            // 
            // gvInvoice
            // 
            this.gvInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcContractNO,
            this.gcCode,
            this.gcNumber,
            this.gcCustomsDeclaration,
            this.gcOriginalCoin,
            this.gcCNY,
            this.gcTaxpayerID,
            this.gcSupplierName,
            this.gcPayment,
            this.gcTaxAmount,
            this.gcExchangeRate,
            this.gcTaxRebateRate,
            this.gcCommission,
            this.gcFeedMoney,
            this.gcTotalCost,
            this.gcGrossProfit,
            this.gcDepartmentCode,
            this.gcImportUserName,
            this.gcImportDate,
            this.gcFinanceImportDate});
            this.gvInvoice.GridControl = this.gridInvoice;
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.OptionsBehavior.Editable = false;
            this.gvInvoice.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gvInvoice.OptionsView.ColumnAutoWidth = false;
            this.gvInvoice.OptionsView.ShowFooter = true;
            this.gvInvoice.OptionsView.ShowGroupPanel = false;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.MaxWidth = 100;
            this.gcContractNO.MinWidth = 100;
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.OptionsColumn.AllowEdit = false;
            this.gcContractNO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ContractNO", "合计：{0:d}")});
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 0;
            this.gcContractNO.Width = 100;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "发票代码";
            this.gcCode.FieldName = "Code";
            this.gcCode.MinWidth = 100;
            this.gcCode.Name = "gcCode";
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 1;
            this.gcCode.Width = 102;
            // 
            // gcNumber
            // 
            this.gcNumber.Caption = "发票号";
            this.gcNumber.FieldName = "Number";
            this.gcNumber.MinWidth = 100;
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 2;
            this.gcNumber.Width = 105;
            // 
            // gcCustomsDeclaration
            // 
            this.gcCustomsDeclaration.Caption = "报关单";
            this.gcCustomsDeclaration.FieldName = "CustomsDeclaration";
            this.gcCustomsDeclaration.MinWidth = 100;
            this.gcCustomsDeclaration.Name = "gcCustomsDeclaration";
            this.gcCustomsDeclaration.Visible = true;
            this.gcCustomsDeclaration.VisibleIndex = 3;
            this.gcCustomsDeclaration.Width = 108;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "原币";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.MinWidth = 60;
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.OptionsColumn.AllowEdit = false;
            this.gcOriginalCoin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 4;
            this.gcOriginalCoin.Width = 61;
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "交单金额（￥）";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 5;
            // 
            // gcTaxpayerID
            // 
            this.gcTaxpayerID.Caption = "销方税号";
            this.gcTaxpayerID.FieldName = "TaxpayerID";
            this.gcTaxpayerID.MinWidth = 60;
            this.gcTaxpayerID.Name = "gcTaxpayerID";
            this.gcTaxpayerID.Visible = true;
            this.gcTaxpayerID.VisibleIndex = 6;
            this.gcTaxpayerID.Width = 69;
            // 
            // gcSupplierName
            // 
            this.gcSupplierName.Caption = "销方名称";
            this.gcSupplierName.FieldName = "SupplierName";
            this.gcSupplierName.MinWidth = 60;
            this.gcSupplierName.Name = "gcSupplierName";
            this.gcSupplierName.Visible = true;
            this.gcSupplierName.VisibleIndex = 7;
            this.gcSupplierName.Width = 72;
            // 
            // gcPayment
            // 
            this.gcPayment.Caption = "金额";
            this.gcPayment.FieldName = "Payment";
            this.gcPayment.MinWidth = 85;
            this.gcPayment.Name = "gcPayment";
            this.gcPayment.OptionsColumn.AllowEdit = false;
            this.gcPayment.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcPayment.Visible = true;
            this.gcPayment.VisibleIndex = 8;
            this.gcPayment.Width = 85;
            // 
            // gcTaxAmount
            // 
            this.gcTaxAmount.Caption = "税额";
            this.gcTaxAmount.FieldName = "TaxAmount";
            this.gcTaxAmount.MinWidth = 70;
            this.gcTaxAmount.Name = "gcTaxAmount";
            this.gcTaxAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcTaxAmount.Visible = true;
            this.gcTaxAmount.VisibleIndex = 9;
            this.gcTaxAmount.Width = 70;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 10;
            this.gcExchangeRate.Width = 46;
            // 
            // gcTaxRebateRate
            // 
            this.gcTaxRebateRate.Caption = "退税率";
            this.gcTaxRebateRate.FieldName = "TaxRebateRate";
            this.gcTaxRebateRate.Name = "gcTaxRebateRate";
            this.gcTaxRebateRate.Visible = true;
            this.gcTaxRebateRate.VisibleIndex = 11;
            this.gcTaxRebateRate.Width = 65;
            // 
            // gcCommission
            // 
            this.gcCommission.Caption = "佣金";
            this.gcCommission.FieldName = "Commission";
            this.gcCommission.MinWidth = 60;
            this.gcCommission.Name = "gcCommission";
            this.gcCommission.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcCommission.Visible = true;
            this.gcCommission.VisibleIndex = 12;
            this.gcCommission.Width = 60;
            // 
            // gcFeedMoney
            // 
            this.gcFeedMoney.Caption = "进料款";
            this.gcFeedMoney.FieldName = "FeedMoney";
            this.gcFeedMoney.MinWidth = 50;
            this.gcFeedMoney.Name = "gcFeedMoney";
            this.gcFeedMoney.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcFeedMoney.Visible = true;
            this.gcFeedMoney.VisibleIndex = 13;
            this.gcFeedMoney.Width = 61;
            // 
            // gcTotalCost
            // 
            this.gcTotalCost.Caption = "销售成本";
            this.gcTotalCost.FieldName = "TotalCost";
            this.gcTotalCost.MinWidth = 80;
            this.gcTotalCost.Name = "gcTotalCost";
            this.gcTotalCost.OptionsColumn.AllowEdit = false;
            this.gcTotalCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcTotalCost.Visible = true;
            this.gcTotalCost.VisibleIndex = 14;
            this.gcTotalCost.Width = 80;
            // 
            // gcGrossProfit
            // 
            this.gcGrossProfit.Caption = "销售毛利润";
            this.gcGrossProfit.FieldName = "GrossProfit";
            this.gcGrossProfit.MinWidth = 75;
            this.gcGrossProfit.Name = "gcGrossProfit";
            this.gcGrossProfit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcGrossProfit.Visible = true;
            this.gcGrossProfit.VisibleIndex = 15;
            // 
            // gcDepartmentCode
            // 
            this.gcDepartmentCode.Caption = "部门";
            this.gcDepartmentCode.FieldName = "DepartmentCode";
            this.gcDepartmentCode.Name = "gcDepartmentCode";
            this.gcDepartmentCode.OptionsColumn.AllowEdit = false;
            this.gcDepartmentCode.Visible = true;
            this.gcDepartmentCode.VisibleIndex = 16;
            this.gcDepartmentCode.Width = 45;
            // 
            // gcImportUserName
            // 
            this.gcImportUserName.Caption = "创建人";
            this.gcImportUserName.DisplayFormat.FormatString = "g";
            this.gcImportUserName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcImportUserName.FieldName = "ImportUserName";
            this.gcImportUserName.Name = "gcImportUserName";
            this.gcImportUserName.OptionsColumn.AllowEdit = false;
            this.gcImportUserName.Visible = true;
            this.gcImportUserName.VisibleIndex = 17;
            this.gcImportUserName.Width = 81;
            // 
            // gcImportDate
            // 
            this.gcImportDate.Caption = "创建时间";
            this.gcImportDate.FieldName = "ImportDate";
            this.gcImportDate.GroupFormat.FormatString = "g";
            this.gcImportDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcImportDate.Name = "gcImportDate";
            this.gcImportDate.OptionsColumn.AllowEdit = false;
            this.gcImportDate.Visible = true;
            this.gcImportDate.VisibleIndex = 18;
            this.gcImportDate.Width = 71;
            // 
            // gcFinanceImportDate
            // 
            this.gcFinanceImportDate.Caption = "财务导入时间";
            this.gcFinanceImportDate.DisplayFormat.FormatString = "g";
            this.gcFinanceImportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFinanceImportDate.FieldName = "FinanceImportDate";
            this.gcFinanceImportDate.MinWidth = 75;
            this.gcFinanceImportDate.Name = "gcFinanceImportDate";
            this.gcFinanceImportDate.Visible = true;
            this.gcFinanceImportDate.VisibleIndex = 19;
            this.gcFinanceImportDate.Width = 96;
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
            // pivotViewBar
            // 
            this.pivotViewBar.BarName = "Custom 7";
            this.pivotViewBar.DockCol = 0;
            this.pivotViewBar.DockRow = 0;
            this.pivotViewBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.pivotViewBar.FloatSize = new System.Drawing.Size(1324, 34);
            this.pivotViewBar.OptionsBar.AllowQuickCustomization = false;
            this.pivotViewBar.OptionsBar.DisableCustomization = true;
            this.pivotViewBar.OptionsBar.DrawDragBorder = false;
            this.pivotViewBar.OptionsBar.UseWholeRow = true;
            this.pivotViewBar.Text = "Custom 7";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.deStartDate,
            this.deEndDate,
            this.cboSelectYear,
            this.btnJanuary,
            this.btnFebruary,
            this.btnMarch,
            this.btnApril,
            this.btnMay,
            this.btnJune,
            this.btnJuly,
            this.btnAugust,
            this.btnSeptember,
            this.btnOctober,
            this.btnNovember,
            this.btnDecember,
            this.btnSearch,
            this.btn_Print,
            this.btnExportExcel,
            this.barSelected,
            this.barCheckItem1,
            this.barSelectedMode});
            this.barManager1.MaxItemId = 25;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.cboYears,
            this.repositoryItemComboBox1,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemComboBox2});
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 7";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatSize = new System.Drawing.Size(1324, 34);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSelected, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cboSelectYear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnJanuary),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFebruary),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMarch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnApril),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMay),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnJune),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnJuly),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAugust),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSeptember),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOctober),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNovember),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDecember),
            new DevExpress.XtraBars.LinkPersistInfo(this.deStartDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.deEndDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSelectedMode),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Print),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportExcel)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 7";
            // 
            // barSelected
            // 
            this.barSelected.Caption = "选择合同：";
            this.barSelected.Edit = this.repositoryItemGridLookUpEdit1;
            this.barSelected.Id = 22;
            this.barSelected.Name = "barSelected";
            this.barSelected.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSelected.Width = 119;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gcState,
            this.gcTotalAmount,
            this.gcSalesman,
            this.gcDepartmentDesc,
            this.gcCreateDate,
            this.gcSignDate,
            this.gcValidity,
            this.gcCustomerNames,
            this.gcTradeMode,
            this.gcTradeNature,
            this.gcSeaport,
            this.gcAdvancePayment,
            this.gcProfit});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowDetailButtons = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "合同号";
            this.gridColumn1.FieldName = "ContractNO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gcState
            // 
            this.gcState.Caption = "审批状态";
            this.gcState.FieldName = "EnumFlowState";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 1;
            this.gcState.Width = 80;
            // 
            // gcTotalAmount
            // 
            this.gcTotalAmount.Caption = "合同金额";
            this.gcTotalAmount.FieldName = "TotalAmount";
            this.gcTotalAmount.Name = "gcTotalAmount";
            this.gcTotalAmount.Visible = true;
            this.gcTotalAmount.VisibleIndex = 2;
            this.gcTotalAmount.Width = 80;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "SalesmanName";
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 3;
            this.gcSalesman.Width = 34;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 4;
            this.gcDepartmentDesc.Width = 40;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.Name = "gcSignDate";
            // 
            // gcValidity
            // 
            this.gcValidity.Caption = "有效截止期";
            this.gcValidity.FieldName = "Validity";
            this.gcValidity.Name = "gcValidity";
            // 
            // gcCustomerNames
            // 
            this.gcCustomerNames.Caption = "客户名称";
            this.gcCustomerNames.FieldName = "CustomerNames";
            this.gcCustomerNames.Name = "gcCustomerNames";
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "贸易方式";
            this.gcTradeMode.FieldName = "TradeMode";
            this.gcTradeMode.Name = "gcTradeMode";
            // 
            // gcTradeNature
            // 
            this.gcTradeNature.Caption = "贸易性质";
            this.gcTradeNature.FieldName = "TradeNature";
            this.gcTradeNature.Name = "gcTradeNature";
            // 
            // gcSeaport
            // 
            this.gcSeaport.Caption = "交货口岸";
            this.gcSeaport.FieldName = "Seaport";
            this.gcSeaport.Name = "gcSeaport";
            // 
            // gcAdvancePayment
            // 
            this.gcAdvancePayment.Caption = "预付金额";
            this.gcAdvancePayment.FieldName = "AdvancePayment";
            this.gcAdvancePayment.Name = "gcAdvancePayment";
            // 
            // gcProfit
            // 
            this.gcProfit.Caption = "利润";
            this.gcProfit.FieldName = "Profit";
            this.gcProfit.Name = "gcProfit";
            // 
            // cboSelectYear
            // 
            this.cboSelectYear.Caption = "选择年份：";
            this.cboSelectYear.Edit = this.cboYears;
            this.cboSelectYear.Id = 6;
            this.cboSelectYear.Name = "cboSelectYear";
            this.cboSelectYear.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.cboSelectYear.Width = 75;
            // 
            // cboYears
            // 
            this.cboYears.AutoHeight = false;
            this.cboYears.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboYears.Name = "cboYears";
            this.cboYears.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnJanuary
            // 
            this.btnJanuary.Caption = "1月";
            this.btnJanuary.Id = 7;
            this.btnJanuary.Name = "btnJanuary";
            this.btnJanuary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJanuary_ItemClick);
            // 
            // btnFebruary
            // 
            this.btnFebruary.Caption = "2月";
            this.btnFebruary.Id = 8;
            this.btnFebruary.Name = "btnFebruary";
            this.btnFebruary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFebruary_ItemClick);
            // 
            // btnMarch
            // 
            this.btnMarch.Caption = "3月";
            this.btnMarch.Id = 9;
            this.btnMarch.Name = "btnMarch";
            this.btnMarch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMarch_ItemClick);
            // 
            // btnApril
            // 
            this.btnApril.Caption = "4月";
            this.btnApril.Id = 10;
            this.btnApril.Name = "btnApril";
            this.btnApril.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApril_ItemClick);
            // 
            // btnMay
            // 
            this.btnMay.Caption = "5月";
            this.btnMay.Id = 11;
            this.btnMay.Name = "btnMay";
            this.btnMay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMay_ItemClick);
            // 
            // btnJune
            // 
            this.btnJune.Caption = "6月";
            this.btnJune.Id = 12;
            this.btnJune.Name = "btnJune";
            this.btnJune.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJune_ItemClick);
            // 
            // btnJuly
            // 
            this.btnJuly.Caption = "7月";
            this.btnJuly.Id = 13;
            this.btnJuly.Name = "btnJuly";
            this.btnJuly.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJuly_ItemClick);
            // 
            // btnAugust
            // 
            this.btnAugust.Caption = "8月";
            this.btnAugust.Id = 14;
            this.btnAugust.Name = "btnAugust";
            this.btnAugust.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAugust_ItemClick);
            // 
            // btnSeptember
            // 
            this.btnSeptember.Caption = "9月";
            this.btnSeptember.Id = 15;
            this.btnSeptember.Name = "btnSeptember";
            this.btnSeptember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSeptember_ItemClick);
            // 
            // btnOctober
            // 
            this.btnOctober.Caption = "10月";
            this.btnOctober.Id = 16;
            this.btnOctober.Name = "btnOctober";
            this.btnOctober.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOctober_ItemClick);
            // 
            // btnNovember
            // 
            this.btnNovember.Caption = "11月";
            this.btnNovember.Id = 17;
            this.btnNovember.Name = "btnNovember";
            this.btnNovember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovember_ItemClick);
            // 
            // btnDecember
            // 
            this.btnDecember.Caption = "12月";
            this.btnDecember.Id = 18;
            this.btnDecember.Name = "btnDecember";
            this.btnDecember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDecember_ItemClick);
            // 
            // deStartDate
            // 
            this.deStartDate.Caption = "开始时间：";
            this.deStartDate.Edit = this.repositoryItemDateEdit1;
            this.deStartDate.Id = 3;
            this.deStartDate.Name = "deStartDate";
            this.deStartDate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.deStartDate.Width = 100;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // deEndDate
            // 
            this.deEndDate.Caption = "结束时间：";
            this.deEndDate.Edit = this.repositoryItemDateEdit1;
            this.deEndDate.Id = 5;
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.deEndDate.Width = 100;
            // 
            // barSelectedMode
            // 
            this.barSelectedMode.Caption = "bar";
            this.barSelectedMode.Edit = this.repositoryItemComboBox2;
            this.barSelectedMode.Id = 24;
            this.barSelectedMode.Name = "barSelectedMode";
            this.barSelectedMode.Width = 107;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "查询";
            this.btnSearch.Id = 19;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btn_Print
            // 
            this.btn_Print.Caption = "打印";
            this.btn_Print.Id = 20;
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Print_ItemClick);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "导出";
            this.btnExportExcel.Id = 21;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportExcel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1286, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1286, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 531);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1286, 31);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 531);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 23;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "",
            "T/T和L/C 收汇"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // frmInvoiceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 562);
            this.Controls.Add(this.gridInvoice);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmInvoiceQuery";
            this.Text = "交单管理";
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcPayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcImportUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gcImportDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxRebateRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCommission;
        private DevExpress.XtraGrid.Columns.GridColumn gcFeedMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomsDeclaration;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxpayerID;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplierName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn gcFinanceImportDate;
        protected DevExpress.XtraBars.Bar pivotViewBar;
        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarEditItem barSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem cboSelectYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboYears;
        private DevExpress.XtraBars.BarButtonItem btnJanuary;
        private DevExpress.XtraBars.BarButtonItem btnFebruary;
        private DevExpress.XtraBars.BarButtonItem btnMarch;
        private DevExpress.XtraBars.BarButtonItem btnApril;
        private DevExpress.XtraBars.BarButtonItem btnMay;
        private DevExpress.XtraBars.BarButtonItem btnJune;
        private DevExpress.XtraBars.BarButtonItem btnJuly;
        private DevExpress.XtraBars.BarButtonItem btnAugust;
        private DevExpress.XtraBars.BarButtonItem btnSeptember;
        private DevExpress.XtraBars.BarButtonItem btnOctober;
        private DevExpress.XtraBars.BarButtonItem btnNovember;
        private DevExpress.XtraBars.BarButtonItem btnDecember;
        private DevExpress.XtraBars.BarEditItem deStartDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem deEndDate;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        protected DevExpress.XtraBars.BarButtonItem btn_Print;
        private DevExpress.XtraBars.BarButtonItem btnExportExcel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcSalesman;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcValidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomerNames;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeMode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeNature;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeaport;
        private DevExpress.XtraGrid.Columns.GridColumn gcAdvancePayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcProfit;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrossProfit;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarEditItem barSelectedMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
    }
}