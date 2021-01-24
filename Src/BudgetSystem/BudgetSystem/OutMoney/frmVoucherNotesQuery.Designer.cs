namespace BudgetSystem
{
    partial class frmVoucherNotesQuery
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
            this.gcDeclarationform = new DevExpress.XtraGrid.GridControl();
            this.gvDeclarationform = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOverseas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPriceClause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProdNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDealCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDealUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFinalCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDomesticSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOffshoreTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUSDOffshoreTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNYOffshoreTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUserRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdateUserRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDeclarationform
            // 
            this.gcDeclarationform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDeclarationform.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeclarationform.Location = new System.Drawing.Point(0, 0);
            this.gcDeclarationform.MainView = this.gvDeclarationform;
            this.gcDeclarationform.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeclarationform.Name = "gcDeclarationform";
            this.gcDeclarationform.Size = new System.Drawing.Size(1704, 805);
            this.gcDeclarationform.TabIndex = 1;
            this.gcDeclarationform.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeclarationform});
            // 
            // gvDeclarationform
            // 
            this.gvDeclarationform.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcNO,
            this.gcContractNO,
            this.gcExportDate,
            this.gcOverseas,
            this.gcTradeMode,
            this.gcPort,
            this.gcCurrency,
            this.gcPriceClause,
            this.gcCountry,
            this.gcProdNumber,
            this.gcProdName,
            this.gcModel,
            this.gcDealCount,
            this.gcDealUnit,
            this.gcPrice,
            this.gcTotalPrice,
            this.gcFinalCountry,
            this.gcDomesticSource,
            this.gcOffshoreTotalPrice,
            this.gcUSDOffshoreTotalPrice,
            this.gcCNYOffshoreTotalPrice,
            this.gcCreateUserRealName,
            this.gcCreateDate,
            this.gcUpdateUserRealName,
            this.gcUpdateDate});
            this.gvDeclarationform.GridControl = this.gcDeclarationform;
            this.gvDeclarationform.Name = "gvDeclarationform";
            this.gvDeclarationform.OptionsBehavior.Editable = false;
            this.gvDeclarationform.OptionsView.ColumnAutoWidth = false;
            this.gvDeclarationform.OptionsView.ShowFooter = true;
            this.gvDeclarationform.OptionsView.ShowGroupPanel = false;
            // 
            // gcNO
            // 
            this.gcNO.Caption = "海关编号";
            this.gcNO.FieldName = "NO";
            this.gcNO.Name = "gcNO";
            this.gcNO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "NO", "合计：{0:d}")});
            this.gcNO.Visible = true;
            this.gcNO.VisibleIndex = 0;
            this.gcNO.Width = 121;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 1;
            this.gcContractNO.Width = 62;
            // 
            // gcExportDate
            // 
            this.gcExportDate.Caption = "出口日期";
            this.gcExportDate.DisplayFormat.FormatString = "d";
            this.gcExportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcExportDate.FieldName = "ExportDate";
            this.gcExportDate.Name = "gcExportDate";
            this.gcExportDate.Visible = true;
            this.gcExportDate.VisibleIndex = 2;
            this.gcExportDate.Width = 62;
            // 
            // gcOverseas
            // 
            this.gcOverseas.Caption = "境外收发货人企业名称英文";
            this.gcOverseas.FieldName = "Overseas";
            this.gcOverseas.Name = "gcOverseas";
            this.gcOverseas.Visible = true;
            this.gcOverseas.VisibleIndex = 3;
            this.gcOverseas.Width = 62;
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "监管方式";
            this.gcTradeMode.FieldName = "TradeMode";
            this.gcTradeMode.Name = "gcTradeMode";
            this.gcTradeMode.Visible = true;
            this.gcTradeMode.VisibleIndex = 4;
            this.gcTradeMode.Width = 62;
            // 
            // gcPort
            // 
            this.gcPort.Caption = "指运港";
            this.gcPort.FieldName = "Port";
            this.gcPort.Name = "gcPort";
            this.gcPort.Visible = true;
            this.gcPort.VisibleIndex = 5;
            this.gcPort.Width = 62;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币制";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 6;
            this.gcCurrency.Width = 62;
            // 
            // gcPriceClause
            // 
            this.gcPriceClause.Caption = "成交方式";
            this.gcPriceClause.FieldName = "PriceClause";
            this.gcPriceClause.Name = "gcPriceClause";
            this.gcPriceClause.Visible = true;
            this.gcPriceClause.VisibleIndex = 7;
            this.gcPriceClause.Width = 62;
            // 
            // gcCountry
            // 
            this.gcCountry.Caption = "贸易国别地区";
            this.gcCountry.FieldName = "Country";
            this.gcCountry.Name = "gcCountry";
            this.gcCountry.Visible = true;
            this.gcCountry.VisibleIndex = 8;
            this.gcCountry.Width = 101;
            // 
            // gcProdNumber
            // 
            this.gcProdNumber.Caption = "商品编号";
            this.gcProdNumber.FieldName = "ProdNumber";
            this.gcProdNumber.Name = "gcProdNumber";
            this.gcProdNumber.Visible = true;
            this.gcProdNumber.VisibleIndex = 9;
            this.gcProdNumber.Width = 62;
            // 
            // gcProdName
            // 
            this.gcProdName.Caption = "商品名称";
            this.gcProdName.FieldName = "ProdName";
            this.gcProdName.Name = "gcProdName";
            this.gcProdName.Visible = true;
            this.gcProdName.VisibleIndex = 10;
            this.gcProdName.Width = 62;
            // 
            // gcModel
            // 
            this.gcModel.Caption = "规格型号";
            this.gcModel.FieldName = "Model";
            this.gcModel.Name = "gcModel";
            this.gcModel.Visible = true;
            this.gcModel.VisibleIndex = 11;
            this.gcModel.Width = 62;
            // 
            // gcDealCount
            // 
            this.gcDealCount.Caption = "成交数量";
            this.gcDealCount.FieldName = "DealCount";
            this.gcDealCount.Name = "gcDealCount";
            this.gcDealCount.Visible = true;
            this.gcDealCount.VisibleIndex = 12;
            this.gcDealCount.Width = 62;
            // 
            // gcDealUnit
            // 
            this.gcDealUnit.Caption = "成交计量单位";
            this.gcDealUnit.FieldName = "DealUnit";
            this.gcDealUnit.Name = "gcDealUnit";
            this.gcDealUnit.Visible = true;
            this.gcDealUnit.VisibleIndex = 13;
            this.gcDealUnit.Width = 62;
            // 
            // gcPrice
            // 
            this.gcPrice.Caption = "单价";
            this.gcPrice.FieldName = "Price";
            this.gcPrice.Name = "gcPrice";
            this.gcPrice.Visible = true;
            this.gcPrice.VisibleIndex = 14;
            this.gcPrice.Width = 62;
            // 
            // gcTotalPrice
            // 
            this.gcTotalPrice.Caption = "总价";
            this.gcTotalPrice.FieldName = "TotalPrice";
            this.gcTotalPrice.Name = "gcTotalPrice";
            this.gcTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcTotalPrice.Visible = true;
            this.gcTotalPrice.VisibleIndex = 15;
            this.gcTotalPrice.Width = 62;
            // 
            // gcFinalCountry
            // 
            this.gcFinalCountry.Caption = "最终目的国地区";
            this.gcFinalCountry.FieldName = "FinalCountry";
            this.gcFinalCountry.Name = "gcFinalCountry";
            this.gcFinalCountry.Visible = true;
            this.gcFinalCountry.VisibleIndex = 16;
            this.gcFinalCountry.Width = 62;
            // 
            // gcDomesticSource
            // 
            this.gcDomesticSource.Caption = "境内货源地";
            this.gcDomesticSource.FieldName = "DomesticSource";
            this.gcDomesticSource.Name = "gcDomesticSource";
            this.gcDomesticSource.Visible = true;
            this.gcDomesticSource.VisibleIndex = 17;
            this.gcDomesticSource.Width = 62;
            // 
            // gcOffshoreTotalPrice
            // 
            this.gcOffshoreTotalPrice.Caption = "离岸价";
            this.gcOffshoreTotalPrice.FieldName = "OffshoreTotalPrice";
            this.gcOffshoreTotalPrice.Name = "gcOffshoreTotalPrice";
            this.gcOffshoreTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcOffshoreTotalPrice.Visible = true;
            this.gcOffshoreTotalPrice.VisibleIndex = 18;
            this.gcOffshoreTotalPrice.Width = 62;
            // 
            // gcUSDOffshoreTotalPrice
            // 
            this.gcUSDOffshoreTotalPrice.Caption = "美元离岸价";
            this.gcUSDOffshoreTotalPrice.FieldName = "USDOffshoreTotalPrice";
            this.gcUSDOffshoreTotalPrice.Name = "gcUSDOffshoreTotalPrice";
            this.gcUSDOffshoreTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcUSDOffshoreTotalPrice.Visible = true;
            this.gcUSDOffshoreTotalPrice.VisibleIndex = 19;
            this.gcUSDOffshoreTotalPrice.Width = 62;
            // 
            // gcCNYOffshoreTotalPrice
            // 
            this.gcCNYOffshoreTotalPrice.Caption = "人民币离岸价";
            this.gcCNYOffshoreTotalPrice.FieldName = "CNYOffshoreTotalPrice";
            this.gcCNYOffshoreTotalPrice.Name = "gcCNYOffshoreTotalPrice";
            this.gcCNYOffshoreTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcCNYOffshoreTotalPrice.Visible = true;
            this.gcCNYOffshoreTotalPrice.VisibleIndex = 20;
            this.gcCNYOffshoreTotalPrice.Width = 62;
            // 
            // gcCreateUserRealName
            // 
            this.gcCreateUserRealName.Caption = "录入人";
            this.gcCreateUserRealName.FieldName = "CreateUserRealName";
            this.gcCreateUserRealName.Name = "gcCreateUserRealName";
            this.gcCreateUserRealName.Visible = true;
            this.gcCreateUserRealName.VisibleIndex = 21;
            this.gcCreateUserRealName.Width = 62;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.DisplayFormat.FormatString = "d";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 22;
            this.gcCreateDate.Width = 62;
            // 
            // gcUpdateUserRealName
            // 
            this.gcUpdateUserRealName.Caption = "修改人";
            this.gcUpdateUserRealName.FieldName = "UpdateUserRealName";
            this.gcUpdateUserRealName.Name = "gcUpdateUserRealName";
            this.gcUpdateUserRealName.Width = 62;
            // 
            // gcUpdateDate
            // 
            this.gcUpdateDate.Caption = "修改时间";
            this.gcUpdateDate.FieldName = "UpdateDate";
            this.gcUpdateDate.Name = "gcUpdateDate";
            this.gcUpdateDate.Width = 100;
            // 
            // frmVoucherNotesQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 805);
            this.Controls.Add(this.gcDeclarationform);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmVoucherNotesQuery";
            this.Text = "报关单管理";
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDeclarationform;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDeclarationform;
        private DevExpress.XtraGrid.Columns.GridColumn gcNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcExportDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcOverseas;
        private DevExpress.XtraGrid.Columns.GridColumn gcPort;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcPriceClause;
        private DevExpress.XtraGrid.Columns.GridColumn gcCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeMode;
        private DevExpress.XtraGrid.Columns.GridColumn gcProdNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcProdName;
        private DevExpress.XtraGrid.Columns.GridColumn gcModel;
        private DevExpress.XtraGrid.Columns.GridColumn gcDealCount;
        private DevExpress.XtraGrid.Columns.GridColumn gcDealUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gcFinalCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gcDomesticSource;
        private DevExpress.XtraGrid.Columns.GridColumn gcOffshoreTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gcUSDOffshoreTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNYOffshoreTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUserRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdateUserRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdateDate;
    }
}