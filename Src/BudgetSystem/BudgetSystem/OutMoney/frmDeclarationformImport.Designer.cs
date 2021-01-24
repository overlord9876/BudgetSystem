namespace BudgetSystem.InMoney
{
    partial class frmDeclarationformImport
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcDeclarationform = new DevExpress.XtraGrid.GridControl();
            this.gvDeclarationform = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riLinkDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ritxtOriginalCoin = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkIgnore = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtOriginalCoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIgnore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnExport);
            this.layoutControl1.Controls.Add(this.chkIgnore);
            this.layoutControl1.Controls.Add(this.gcDeclarationform);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnSure);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(745, 134, 458, 563);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1466, 550);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcDeclarationform
            // 
            this.gcDeclarationform.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeclarationform.Location = new System.Drawing.Point(12, 12);
            this.gcDeclarationform.MainView = this.gvDeclarationform;
            this.gcDeclarationform.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeclarationform.Name = "gcDeclarationform";
            this.gcDeclarationform.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riLinkDelete});
            this.gcDeclarationform.Size = new System.Drawing.Size(1442, 486);
            this.gcDeclarationform.TabIndex = 2;
            this.gcDeclarationform.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeclarationform});
            // 
            // gvDeclarationform
            // 
            this.gvDeclarationform.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMessage,
            this.gcNO,
            this.gridColumn1,
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
            this.gcUpdateDate,
            this.gcDelete});
            this.gvDeclarationform.GridControl = this.gcDeclarationform;
            this.gvDeclarationform.Name = "gvDeclarationform";
            this.gvDeclarationform.OptionsDetail.EnableMasterViewMode = false;
            this.gvDeclarationform.OptionsDetail.ShowDetailTabs = false;
            this.gvDeclarationform.OptionsView.ColumnAutoWidth = false;
            this.gvDeclarationform.OptionsView.ShowFooter = true;
            this.gvDeclarationform.OptionsView.ShowGroupPanel = false;
            // 
            // gcMessage
            // 
            this.gcMessage.Caption = "验证消息";
            this.gcMessage.FieldName = "Message";
            this.gcMessage.Name = "gcMessage";
            this.gcMessage.OptionsColumn.AllowEdit = false;
            this.gcMessage.Visible = true;
            this.gcMessage.VisibleIndex = 0;
            // 
            // gcNO
            // 
            this.gcNO.Caption = "海关编号";
            this.gcNO.FieldName = "NO";
            this.gcNO.Name = "gcNO";
            this.gcNO.Visible = true;
            this.gcNO.VisibleIndex = 1;
            this.gcNO.Width = 121;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "合同号";
            this.gridColumn1.FieldName = "ContractNO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 62;
            // 
            // gcExportDate
            // 
            this.gcExportDate.Caption = "出口日期";
            this.gcExportDate.DisplayFormat.FormatString = "d";
            this.gcExportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcExportDate.FieldName = "ExportDate";
            this.gcExportDate.Name = "gcExportDate";
            this.gcExportDate.Visible = true;
            this.gcExportDate.VisibleIndex = 3;
            this.gcExportDate.Width = 62;
            // 
            // gcOverseas
            // 
            this.gcOverseas.Caption = "境外收发货人企业名称英文";
            this.gcOverseas.FieldName = "Overseas";
            this.gcOverseas.Name = "gcOverseas";
            this.gcOverseas.Visible = true;
            this.gcOverseas.VisibleIndex = 4;
            this.gcOverseas.Width = 62;
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "监管方式";
            this.gcTradeMode.FieldName = "TradeMode";
            this.gcTradeMode.Name = "gcTradeMode";
            this.gcTradeMode.Visible = true;
            this.gcTradeMode.VisibleIndex = 5;
            this.gcTradeMode.Width = 62;
            // 
            // gcPort
            // 
            this.gcPort.Caption = "指运港";
            this.gcPort.FieldName = "Port";
            this.gcPort.Name = "gcPort";
            this.gcPort.Visible = true;
            this.gcPort.VisibleIndex = 6;
            this.gcPort.Width = 62;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币制";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 7;
            this.gcCurrency.Width = 62;
            // 
            // gcPriceClause
            // 
            this.gcPriceClause.Caption = "成交方式";
            this.gcPriceClause.FieldName = "PriceClause";
            this.gcPriceClause.Name = "gcPriceClause";
            this.gcPriceClause.Visible = true;
            this.gcPriceClause.VisibleIndex = 8;
            this.gcPriceClause.Width = 62;
            // 
            // gcCountry
            // 
            this.gcCountry.Caption = "贸易国别地区";
            this.gcCountry.FieldName = "Country";
            this.gcCountry.Name = "gcCountry";
            this.gcCountry.Visible = true;
            this.gcCountry.VisibleIndex = 9;
            this.gcCountry.Width = 101;
            // 
            // gcProdNumber
            // 
            this.gcProdNumber.Caption = "商品编号";
            this.gcProdNumber.FieldName = "ProdNumber";
            this.gcProdNumber.Name = "gcProdNumber";
            this.gcProdNumber.Visible = true;
            this.gcProdNumber.VisibleIndex = 10;
            this.gcProdNumber.Width = 62;
            // 
            // gcProdName
            // 
            this.gcProdName.Caption = "商品名称";
            this.gcProdName.FieldName = "ProdName";
            this.gcProdName.Name = "gcProdName";
            this.gcProdName.Visible = true;
            this.gcProdName.VisibleIndex = 11;
            this.gcProdName.Width = 62;
            // 
            // gcModel
            // 
            this.gcModel.Caption = "规格型号";
            this.gcModel.FieldName = "Model";
            this.gcModel.Name = "gcModel";
            this.gcModel.Visible = true;
            this.gcModel.VisibleIndex = 12;
            this.gcModel.Width = 62;
            // 
            // gcDealCount
            // 
            this.gcDealCount.Caption = "成交数量";
            this.gcDealCount.FieldName = "DealCount";
            this.gcDealCount.Name = "gcDealCount";
            this.gcDealCount.Visible = true;
            this.gcDealCount.VisibleIndex = 13;
            this.gcDealCount.Width = 62;
            // 
            // gcDealUnit
            // 
            this.gcDealUnit.Caption = "成交计量单位";
            this.gcDealUnit.FieldName = "DealUnit";
            this.gcDealUnit.Name = "gcDealUnit";
            this.gcDealUnit.Visible = true;
            this.gcDealUnit.VisibleIndex = 14;
            this.gcDealUnit.Width = 62;
            // 
            // gcPrice
            // 
            this.gcPrice.Caption = "单价";
            this.gcPrice.FieldName = "Price";
            this.gcPrice.Name = "gcPrice";
            this.gcPrice.Visible = true;
            this.gcPrice.VisibleIndex = 15;
            this.gcPrice.Width = 62;
            // 
            // gcTotalPrice
            // 
            this.gcTotalPrice.Caption = "总价";
            this.gcTotalPrice.FieldName = "TotalPrice";
            this.gcTotalPrice.Name = "gcTotalPrice";
            this.gcTotalPrice.Visible = true;
            this.gcTotalPrice.VisibleIndex = 16;
            this.gcTotalPrice.Width = 62;
            // 
            // gcFinalCountry
            // 
            this.gcFinalCountry.Caption = "最终目的国地区";
            this.gcFinalCountry.FieldName = "FinalCountry";
            this.gcFinalCountry.Name = "gcFinalCountry";
            this.gcFinalCountry.Visible = true;
            this.gcFinalCountry.VisibleIndex = 17;
            this.gcFinalCountry.Width = 62;
            // 
            // gcDomesticSource
            // 
            this.gcDomesticSource.Caption = "境内货源地";
            this.gcDomesticSource.FieldName = "DomesticSource";
            this.gcDomesticSource.Name = "gcDomesticSource";
            this.gcDomesticSource.Visible = true;
            this.gcDomesticSource.VisibleIndex = 18;
            this.gcDomesticSource.Width = 62;
            // 
            // gcOffshoreTotalPrice
            // 
            this.gcOffshoreTotalPrice.Caption = "离岸价";
            this.gcOffshoreTotalPrice.FieldName = "OffshoreTotalPrice";
            this.gcOffshoreTotalPrice.Name = "gcOffshoreTotalPrice";
            this.gcOffshoreTotalPrice.Visible = true;
            this.gcOffshoreTotalPrice.VisibleIndex = 19;
            this.gcOffshoreTotalPrice.Width = 62;
            // 
            // gcUSDOffshoreTotalPrice
            // 
            this.gcUSDOffshoreTotalPrice.Caption = "美元离岸价";
            this.gcUSDOffshoreTotalPrice.FieldName = "USDOffshoreTotalPrice";
            this.gcUSDOffshoreTotalPrice.Name = "gcUSDOffshoreTotalPrice";
            this.gcUSDOffshoreTotalPrice.Visible = true;
            this.gcUSDOffshoreTotalPrice.VisibleIndex = 20;
            this.gcUSDOffshoreTotalPrice.Width = 62;
            // 
            // gcCNYOffshoreTotalPrice
            // 
            this.gcCNYOffshoreTotalPrice.Caption = "人民币离岸价";
            this.gcCNYOffshoreTotalPrice.FieldName = "CNYOffshoreTotalPrice";
            this.gcCNYOffshoreTotalPrice.Name = "gcCNYOffshoreTotalPrice";
            this.gcCNYOffshoreTotalPrice.Visible = true;
            this.gcCNYOffshoreTotalPrice.VisibleIndex = 21;
            this.gcCNYOffshoreTotalPrice.Width = 62;
            // 
            // gcCreateUserRealName
            // 
            this.gcCreateUserRealName.Caption = "录入人";
            this.gcCreateUserRealName.FieldName = "CreateUserRealName";
            this.gcCreateUserRealName.Name = "gcCreateUserRealName";
            this.gcCreateUserRealName.Width = 62;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.DisplayFormat.FormatString = "d";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
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
            // gcDelete
            // 
            this.gcDelete.Caption = "操作";
            this.gcDelete.ColumnEdit = this.riLinkDelete;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.OptionsColumn.AllowEdit = false;
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 22;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.riLinkDelete.AutoHeight = false;
            this.riLinkDelete.Name = "repositoryItemHyperLinkEdit1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1318, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 36);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取消";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(1178, 502);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(136, 36);
            this.btnSure.StyleController = this.layoutControl1;
            this.btnSure.TabIndex = 26;
            this.btnSure.Text = "确定";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem18,
            this.layoutControlItem19,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1466, 550);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 490);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(583, 40);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.btnSure;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new System.Drawing.Point(1166, 490);
            this.layoutControlItem18.MaxSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(140, 40);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.Text = "layoutControlItem18";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextToControlDistance = 0;
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.btnCancel;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new System.Drawing.Point(1306, 490);
            this.layoutControlItem19.MaxSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(140, 40);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "layoutControlItem19";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextToControlDistance = 0;
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcDeclarationform;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1446, 490);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem32";
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 158);
            this.layoutControlItem32.MaxSize = new System.Drawing.Size(0, 180);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(104, 120);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(1292, 120);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "layoutControlItem32";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextToControlDistance = 0;
            this.layoutControlItem32.TextVisible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel|*.xlsx;*.xls";
            // 
            // ritxtOriginalCoin
            // 
            this.ritxtOriginalCoin.AutoHeight = false;
            this.ritxtOriginalCoin.Name = "ritxtOriginalCoin";
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 1;
            this.gcContractNO.Width = 85;
            // 
            // chkIgnore
            // 
            this.chkIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIgnore.EditValue = true;
            this.chkIgnore.Location = new System.Drawing.Point(595, 502);
            this.chkIgnore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Properties.Caption = "忽略不合规数据";
            this.chkIgnore.Size = new System.Drawing.Size(421, 23);
            this.chkIgnore.StyleController = this.layoutControl1;
            this.chkIgnore.TabIndex = 66;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem3.Control = this.chkIgnore;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(583, 490);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(132, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(425, 40);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1020, 502);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(154, 36);
            this.btnExport.StyleController = this.layoutControl1;
            this.btnExport.TabIndex = 67;
            this.btnExport.Text = "导出";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnExport;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(1008, 490);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(45, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(158, 40);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Excel2003|*.xls\"";
            // 
            // frmDeclarationformImport
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1466, 550);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmDeclarationformImport";
            this.Text = "导入报关单信息";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtOriginalCoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIgnore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.GridControl gcDeclarationform;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDeclarationform;
        private DevExpress.XtraGrid.Columns.GridColumn gcNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcExportDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcOverseas;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeMode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPort;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcPriceClause;
        private DevExpress.XtraGrid.Columns.GridColumn gcCountry;
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
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcMessage;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riLinkDelete;
        private DevExpress.XtraEditors.CheckEdit chkIgnore;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}