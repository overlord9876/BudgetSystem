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
            this.gcCheckMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtContractNO = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtNO = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExportAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtExportAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcExportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ritxtExchangeRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtContractNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExportAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtOriginalCoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExchangeRate)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
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
            this.gcDeclarationform.Location = new System.Drawing.Point(12, 12);
            this.gcDeclarationform.MainView = this.gvDeclarationform;
            this.gcDeclarationform.Name = "gcDeclarationform";
            this.gcDeclarationform.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ritxtContractNO,
            this.ritxtNO,
            this.ritxtExportAmount,
            this.riLinkDelete,
            this.ritxtExchangeRate});
            this.gcDeclarationform.Size = new System.Drawing.Size(1442, 486);
            this.gcDeclarationform.TabIndex = 29;
            this.gcDeclarationform.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeclarationform});
            // 
            // gvDeclarationform
            // 
            this.gvDeclarationform.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCheckMessage,
            this.gridColumnContractNO,
            this.gcNO,
            this.gcCurrency,
            this.gcExportAmount,
            this.gcExportDate,
            this.gcIsReport,
            this.gcExchangeRate,
            this.gcCreateUser,
            this.gcCreateDate,
            this.gcDelete});
            this.gvDeclarationform.GridControl = this.gcDeclarationform;
            this.gvDeclarationform.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Number", null, "")});
            this.gvDeclarationform.Name = "gvDeclarationform";
            this.gvDeclarationform.OptionsDetail.EnableMasterViewMode = false;
            this.gvDeclarationform.OptionsDetail.ShowDetailTabs = false;
            this.gvDeclarationform.OptionsView.ShowFooter = true;
            this.gvDeclarationform.OptionsView.ShowGroupPanel = false;
            // 
            // gcCheckMessage
            // 
            this.gcCheckMessage.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gcCheckMessage.AppearanceCell.Options.UseForeColor = true;
            this.gcCheckMessage.Caption = "验证消息";
            this.gcCheckMessage.FieldName = "Message";
            this.gcCheckMessage.Name = "gcCheckMessage";
            this.gcCheckMessage.Visible = true;
            this.gcCheckMessage.VisibleIndex = 0;
            // 
            // gridColumnContractNO
            // 
            this.gridColumnContractNO.Caption = "合同号";
            this.gridColumnContractNO.ColumnEdit = this.ritxtContractNO;
            this.gridColumnContractNO.FieldName = "ContractNO";
            this.gridColumnContractNO.Name = "gridColumnContractNO";
            this.gridColumnContractNO.Visible = true;
            this.gridColumnContractNO.VisibleIndex = 1;
            this.gridColumnContractNO.Width = 85;
            // 
            // ritxtContractNO
            // 
            this.ritxtContractNO.AutoHeight = false;
            this.ritxtContractNO.MaxLength = 30;
            this.ritxtContractNO.Name = "ritxtContractNO";
            // 
            // gcNO
            // 
            this.gcNO.Caption = "报关单号";
            this.gcNO.ColumnEdit = this.ritxtNO;
            this.gcNO.FieldName = "NO";
            this.gcNO.Name = "gcNO";
            this.gcNO.Visible = true;
            this.gcNO.VisibleIndex = 2;
            this.gcNO.Width = 85;
            // 
            // ritxtNO
            // 
            this.ritxtNO.AutoHeight = false;
            this.ritxtNO.Name = "ritxtNO";
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "报关币种";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 3;
            this.gcCurrency.Width = 85;
            // 
            // gcExportAmount
            // 
            this.gcExportAmount.Caption = "出口金额";
            this.gcExportAmount.ColumnEdit = this.ritxtExportAmount;
            this.gcExportAmount.FieldName = "ExportAmount";
            this.gcExportAmount.Name = "gcExportAmount";
            this.gcExportAmount.Visible = true;
            this.gcExportAmount.VisibleIndex = 4;
            this.gcExportAmount.Width = 85;
            // 
            // ritxtExportAmount
            // 
            this.ritxtExportAmount.AutoHeight = false;
            this.ritxtExportAmount.Name = "ritxtExportAmount";
            // 
            // gcExportDate
            // 
            this.gcExportDate.Caption = "出口日期";
            this.gcExportDate.FieldName = "ExportDate";
            this.gcExportDate.Name = "gcExportDate";
            this.gcExportDate.Visible = true;
            this.gcExportDate.VisibleIndex = 5;
            this.gcExportDate.Width = 85;
            // 
            // gcIsReport
            // 
            this.gcIsReport.Caption = "是否已报告延期收款";
            this.gcIsReport.FieldName = "IsReport";
            this.gcIsReport.Name = "gcIsReport";
            this.gcIsReport.Visible = true;
            this.gcIsReport.VisibleIndex = 6;
            this.gcIsReport.Width = 85;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "录入人";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 8;
            this.gcCreateUser.Width = 85;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 9;
            this.gcCreateDate.Width = 85;
            // 
            // gcDelete
            // 
            this.gcDelete.Caption = " ";
            this.gcDelete.ColumnEdit = this.riLinkDelete;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 10;
            this.gcDelete.Width = 102;
            // 
            // riLinkDelete
            // 
            this.riLinkDelete.AutoHeight = false;
            this.riLinkDelete.Name = "riLinkDelete";
            this.riLinkDelete.NullText = "删除";
            this.riLinkDelete.SingleClick = true;
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
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.ColumnEdit = this.ritxtExchangeRate;
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 7;
            // 
            // ritxtExchangeRate
            // 
            this.ritxtExchangeRate.AutoHeight = false;
            this.ritxtExchangeRate.Name = "ritxtExchangeRate";
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
            this.Text = "导入交单信息";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtContractNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExportAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLinkDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtOriginalCoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ritxtExchangeRate)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnContractNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcExportAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtExportAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcExportDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsReport;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riLinkDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCheckMessage;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtExchangeRate;

    }
}