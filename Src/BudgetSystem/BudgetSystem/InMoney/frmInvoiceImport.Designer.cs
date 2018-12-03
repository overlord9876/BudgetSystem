namespace BudgetSystem.InMoney
{
    partial class frmInvoiceImport
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
            this.gridInvoice = new DevExpress.XtraGrid.GridControl();
            this.gvInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtContractNO = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtOriginalCoin = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtExchangeRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcCustomsDeclaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtCustomsDeclaration = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtCode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcTaxRebateRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtTaxRebateRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtCommission = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcFeedMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtFeedMoney = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcTaxpayerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtTaxpayerID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtSupplierName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtPayment = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcTaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtTaxAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtContractNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtOriginalCoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCustomsDeclaration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxRebateRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtFeedMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxpayerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtSupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridInvoice);
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
            // gridInvoice
            // 
            this.gridInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridInvoice.Location = new System.Drawing.Point(12, 12);
            this.gridInvoice.MainView = this.gvInvoice;
            this.gridInvoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ritxtContractNO,
            this.ritxtOriginalCoin,
            this.ritxtExchangeRate,
            this.ritxtCustomsDeclaration,
            this.ritxtNumber,
            this.ritxtTaxRebateRate,
            this.ritxtCommission,
            this.ritxtFeedMoney,
            this.ritxtCode,
            this.ritxtTaxpayerID,
            this.ritxtSupplierName,
            this.ritxtPayment,
            this.ritxtTaxAmount,
            this.riLinkDelete});
            this.gridInvoice.Size = new System.Drawing.Size(1442, 486);
            this.gridInvoice.TabIndex = 28;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoice});
            // 
            // gvInvoice
            // 
            this.gvInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMessage,
            this.gcContractNO,
            this.gcOriginalCoin,
            this.gcExchangeRate,
            this.gcCustomsDeclaration,
            this.gcCode,
            this.gcNumber,
            this.gcTaxRebateRate,
            this.gcCommission,
            this.gcFeedMoney,
            this.gcTaxpayerID,
            this.gcSupplierName,
            this.gcPayment,
            this.gcTaxAmount,
            this.gcDelete});
            this.gvInvoice.GridControl = this.gridInvoice;
            this.gvInvoice.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Number", null, "")});
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.OptionsDetail.EnableMasterViewMode = false;
            this.gvInvoice.OptionsDetail.ShowDetailTabs = false;
            this.gvInvoice.OptionsView.ShowFooter = true;
            this.gvInvoice.OptionsView.ShowGroupPanel = false;
            this.gvInvoice.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvInvoice_InvalidRowException);
            this.gvInvoice.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvInvoice_ValidateRow);
            // 
            // gcMessage
            // 
            this.gcMessage.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gcMessage.AppearanceCell.Options.UseForeColor = true;
            this.gcMessage.Caption = "验证信息";
            this.gcMessage.FieldName = "Message";
            this.gcMessage.Name = "gcMessage";
            this.gcMessage.OptionsColumn.AllowEdit = false;
            this.gcMessage.Visible = true;
            this.gcMessage.VisibleIndex = 0;
            this.gcMessage.Width = 217;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.ColumnEdit = this.ritxtContractNO;
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 1;
            this.gcContractNO.Width = 85;
            // 
            // ritxtContractNO
            // 
            this.ritxtContractNO.AutoHeight = false;
            this.ritxtContractNO.MaxLength = 30;
            this.ritxtContractNO.Name = "ritxtContractNO";
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "原币";
            this.gcOriginalCoin.ColumnEdit = this.ritxtOriginalCoin;
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 2;
            this.gcOriginalCoin.Width = 85;
            // 
            // ritxtOriginalCoin
            // 
            this.ritxtOriginalCoin.AutoHeight = false;
            this.ritxtOriginalCoin.Name = "ritxtOriginalCoin";
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.ColumnEdit = this.ritxtExchangeRate;
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 3;
            this.gcExchangeRate.Width = 85;
            // 
            // ritxtExchangeRate
            // 
            this.ritxtExchangeRate.AutoHeight = false;
            this.ritxtExchangeRate.Name = "ritxtExchangeRate";
            // 
            // gcCustomsDeclaration
            // 
            this.gcCustomsDeclaration.Caption = "报关单";
            this.gcCustomsDeclaration.ColumnEdit = this.ritxtCustomsDeclaration;
            this.gcCustomsDeclaration.FieldName = "CustomsDeclaration";
            this.gcCustomsDeclaration.Name = "gcCustomsDeclaration";
            this.gcCustomsDeclaration.Visible = true;
            this.gcCustomsDeclaration.VisibleIndex = 4;
            this.gcCustomsDeclaration.Width = 85;
            // 
            // ritxtCustomsDeclaration
            // 
            this.ritxtCustomsDeclaration.AutoHeight = false;
            this.ritxtCustomsDeclaration.Name = "ritxtCustomsDeclaration";
            // 
            // gcCode
            // 
            this.gcCode.Caption = "发票代码";
            this.gcCode.ColumnEdit = this.ritxtCode;
            this.gcCode.FieldName = "Code";
            this.gcCode.Name = "gcCode";
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 5;
            this.gcCode.Width = 85;
            // 
            // ritxtCode
            // 
            this.ritxtCode.AutoHeight = false;
            this.ritxtCode.Name = "ritxtCode";
            // 
            // gcNumber
            // 
            this.gcNumber.Caption = "发票号";
            this.gcNumber.ColumnEdit = this.ritxtNumber;
            this.gcNumber.FieldName = "Number";
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 6;
            this.gcNumber.Width = 85;
            // 
            // ritxtNumber
            // 
            this.ritxtNumber.AutoHeight = false;
            this.ritxtNumber.Name = "ritxtNumber";
            // 
            // gcTaxRebateRate
            // 
            this.gcTaxRebateRate.Caption = "退税率";
            this.gcTaxRebateRate.ColumnEdit = this.ritxtTaxRebateRate;
            this.gcTaxRebateRate.FieldName = "TaxRebateRate";
            this.gcTaxRebateRate.Name = "gcTaxRebateRate";
            this.gcTaxRebateRate.Visible = true;
            this.gcTaxRebateRate.VisibleIndex = 7;
            this.gcTaxRebateRate.Width = 85;
            // 
            // ritxtTaxRebateRate
            // 
            this.ritxtTaxRebateRate.AutoHeight = false;
            this.ritxtTaxRebateRate.Name = "ritxtTaxRebateRate";
            // 
            // gcCommission
            // 
            this.gcCommission.Caption = "佣金";
            this.gcCommission.ColumnEdit = this.ritxtCommission;
            this.gcCommission.FieldName = "Commission";
            this.gcCommission.Name = "gcCommission";
            this.gcCommission.Visible = true;
            this.gcCommission.VisibleIndex = 8;
            this.gcCommission.Width = 85;
            // 
            // ritxtCommission
            // 
            this.ritxtCommission.AutoHeight = false;
            this.ritxtCommission.Name = "ritxtCommission";
            // 
            // gcFeedMoney
            // 
            this.gcFeedMoney.Caption = "进料款";
            this.gcFeedMoney.ColumnEdit = this.ritxtFeedMoney;
            this.gcFeedMoney.FieldName = "FeedMoney";
            this.gcFeedMoney.Name = "gcFeedMoney";
            this.gcFeedMoney.Visible = true;
            this.gcFeedMoney.VisibleIndex = 9;
            this.gcFeedMoney.Width = 85;
            // 
            // ritxtFeedMoney
            // 
            this.ritxtFeedMoney.AutoHeight = false;
            this.ritxtFeedMoney.Name = "ritxtFeedMoney";
            // 
            // gcTaxpayerID
            // 
            this.gcTaxpayerID.Caption = "销方税号";
            this.gcTaxpayerID.ColumnEdit = this.ritxtTaxpayerID;
            this.gcTaxpayerID.FieldName = "TaxpayerID";
            this.gcTaxpayerID.Name = "gcTaxpayerID";
            this.gcTaxpayerID.Visible = true;
            this.gcTaxpayerID.VisibleIndex = 10;
            this.gcTaxpayerID.Width = 85;
            // 
            // ritxtTaxpayerID
            // 
            this.ritxtTaxpayerID.AutoHeight = false;
            this.ritxtTaxpayerID.Name = "ritxtTaxpayerID";
            // 
            // gcSupplierName
            // 
            this.gcSupplierName.Caption = "销方名称";
            this.gcSupplierName.ColumnEdit = this.ritxtSupplierName;
            this.gcSupplierName.FieldName = "SupplierName";
            this.gcSupplierName.Name = "gcSupplierName";
            this.gcSupplierName.Visible = true;
            this.gcSupplierName.VisibleIndex = 11;
            this.gcSupplierName.Width = 85;
            // 
            // ritxtSupplierName
            // 
            this.ritxtSupplierName.AutoHeight = false;
            this.ritxtSupplierName.Name = "ritxtSupplierName";
            // 
            // gcPayment
            // 
            this.gcPayment.Caption = "金额";
            this.gcPayment.ColumnEdit = this.ritxtPayment;
            this.gcPayment.FieldName = "Payment";
            this.gcPayment.Name = "gcPayment";
            this.gcPayment.Visible = true;
            this.gcPayment.VisibleIndex = 12;
            this.gcPayment.Width = 85;
            // 
            // ritxtPayment
            // 
            this.ritxtPayment.AutoHeight = false;
            this.ritxtPayment.Name = "ritxtPayment";
            // 
            // gcTaxAmount
            // 
            this.gcTaxAmount.Caption = "税额";
            this.gcTaxAmount.ColumnEdit = this.ritxtTaxAmount;
            this.gcTaxAmount.FieldName = "TaxAmount";
            this.gcTaxAmount.Name = "gcTaxAmount";
            this.gcTaxAmount.Visible = true;
            this.gcTaxAmount.VisibleIndex = 13;
            this.gcTaxAmount.Width = 85;
            // 
            // ritxtTaxAmount
            // 
            this.ritxtTaxAmount.AutoHeight = false;
            this.ritxtTaxAmount.Name = "ritxtTaxAmount";
            // 
            // gcDelete
            // 
            this.gcDelete.Caption = " ";
            this.gcDelete.ColumnEdit = this.riLinkDelete;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 14;
            this.gcDelete.Width = 102;
            // 
            // riLinkDelete
            // 
            this.riLinkDelete.AutoHeight = false;
            this.riLinkDelete.Name = "riLinkDelete";
            this.riLinkDelete.NullText = "删除";
            this.riLinkDelete.SingleClick = true;
            this.riLinkDelete.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.riLinkDelete_CustomDisplayText);
            this.riLinkDelete.Click += new System.EventHandler(this.riLinkDelete_Click);
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
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
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
            this.layoutControlItem1});
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
            this.emptySpaceItem2.Size = new System.Drawing.Size(1166, 40);
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
            this.layoutControlItem1.Control = this.gridInvoice;
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
            // frmInvoiceImport
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1466, 550);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmInvoiceImport";
            this.Text = "导入交单信息";
            this.Load += new System.EventHandler(this.frmInvoiceImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtContractNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtOriginalCoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCustomsDeclaration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxRebateRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtFeedMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxpayerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtSupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtTaxAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInvoice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomsDeclaration;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtCustomsDeclaration;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxRebateRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtTaxRebateRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCommission;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtCommission;
        private DevExpress.XtraGrid.Columns.GridColumn gcFeedMoney;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtFeedMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxpayerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtTaxpayerID;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplierName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn gcPayment;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtPayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtTaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riLinkDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gcMessage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}