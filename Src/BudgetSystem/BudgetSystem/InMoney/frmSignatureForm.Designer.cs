namespace BudgetSystem.InMoney
{
    partial class frmSignatureForm
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
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomsDeclaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxRebateRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFeedMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInvoice
            // 
            this.gridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridInvoice.Location = new System.Drawing.Point(0, 0);
            this.gridInvoice.MainView = this.gvInvoice;
            this.gridInvoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Size = new System.Drawing.Size(1166, 562);
            this.gridInvoice.TabIndex = 1;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoice});
            // 
            // gvInvoice
            // 
            this.gvInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDepartmentCode,
            this.gcContractNO,
            this.gcOriginalCoin,
            this.gcExchangeRate,
            this.gcCustomsDeclaration,
            this.gcNumber,
            this.gcTaxRebateRate,
            this.gcFeedMoney,
            this.gcCommission,
            this.gcCode});
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
            this.gcDepartmentCode.Width = 83;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.OptionsColumn.AllowEdit = false;
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 1;
            this.gcContractNO.Width = 171;
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
            this.gcOriginalCoin.VisibleIndex = 2;
            this.gcOriginalCoin.Width = 131;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 3;
            this.gcExchangeRate.Width = 78;
            // 
            // gcCustomsDeclaration
            // 
            this.gcCustomsDeclaration.Caption = "报关单号";
            this.gcCustomsDeclaration.FieldName = "CustomsDeclaration";
            this.gcCustomsDeclaration.Name = "gcCustomsDeclaration";
            this.gcCustomsDeclaration.Visible = true;
            this.gcCustomsDeclaration.VisibleIndex = 4;
            this.gcCustomsDeclaration.Width = 194;
            // 
            // gcNumber
            // 
            this.gcNumber.Caption = "发票号";
            this.gcNumber.FieldName = "Number";
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 5;
            this.gcNumber.Width = 157;
            // 
            // gcTaxRebateRate
            // 
            this.gcTaxRebateRate.Caption = "退税率";
            this.gcTaxRebateRate.FieldName = "TaxRebateRate";
            this.gcTaxRebateRate.Name = "gcTaxRebateRate";
            this.gcTaxRebateRate.Visible = true;
            this.gcTaxRebateRate.VisibleIndex = 6;
            this.gcTaxRebateRate.Width = 120;
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
            this.gcFeedMoney.Width = 120;
            // 
            // gcCommission
            // 
            this.gcCommission.Caption = "佣金";
            this.gcCommission.FieldName = "Commission";
            this.gcCommission.Name = "gcCommission";
            this.gcCommission.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gcCommission.Visible = true;
            this.gcCommission.VisibleIndex = 8;
            this.gcCommission.Width = 120;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "签收";
            this.gcCode.Name = "gcCode";
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 9;
            this.gcCode.Width = 141;
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
            // frmSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 562);
            this.Controls.Add(this.gridInvoice);
            this.Name = "frmSignatureForm";
            this.Text = "打印签收单";
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxRebateRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCommission;
        private DevExpress.XtraGrid.Columns.GridColumn gcFeedMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomsDeclaration;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentCode;
    }
}