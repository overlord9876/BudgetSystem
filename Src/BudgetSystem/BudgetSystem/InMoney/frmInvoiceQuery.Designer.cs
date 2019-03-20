﻿namespace BudgetSystem.InMoney
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
            this.gridInvoice = new DevExpress.XtraGrid.GridControl();
            this.gvInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxRebateRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFeedMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomsDeclaration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxpayerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImportUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInvoice
            // 
            this.gridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridInvoice.Location = new System.Drawing.Point(0, 0);
            this.gridInvoice.MainView = this.gvInvoice;
            this.gridInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Size = new System.Drawing.Size(1004, 562);
            this.gridInvoice.TabIndex = 1;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoice});
            // 
            // gvInvoice
            // 
            this.gvInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDepartmentCode,
            this.gcContractNO,
            this.gcCode,
            this.gcNumber,
            this.gcOriginalCoin,
            this.gcPayment,
            this.gcTaxAmount,
            this.gcExchangeRate,
            this.gcTaxRebateRate,
            this.gcCommission,
            this.gcFeedMoney,
            this.gcTotalCost,
            this.gcCustomsDeclaration,
            this.gcTaxpayerID,
            this.gcSupplierName,
            this.gcImportUserName,
            this.gcImportDate});
            this.gvInvoice.GridControl = this.gridInvoice;
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.OptionsBehavior.Editable = false;
            this.gvInvoice.OptionsView.ShowGroupPanel = false;
            // 
            // gcDepartmentCode
            // 
            this.gcDepartmentCode.Caption = "部门";
            this.gcDepartmentCode.FieldName = "DepartmentCode";
            this.gcDepartmentCode.Name = "gcDepartmentCode";
            this.gcDepartmentCode.OptionsColumn.AllowEdit = false;
            this.gcDepartmentCode.Visible = true;
            this.gcDepartmentCode.VisibleIndex = 0;
            this.gcDepartmentCode.Width = 58;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.OptionsColumn.AllowEdit = false;
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 1;
            this.gcContractNO.Width = 58;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "发票代码";
            this.gcCode.FieldName = "Code";
            this.gcCode.Name = "gcCode";
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 2;
            this.gcCode.Width = 58;
            // 
            // gcNumber
            // 
            this.gcNumber.Caption = "发票号";
            this.gcNumber.FieldName = "Number";
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 3;
            this.gcNumber.Width = 58;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "原币";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.OptionsColumn.AllowEdit = false;
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 4;
            this.gcOriginalCoin.Width = 58;
            // 
            // gcPayment
            // 
            this.gcPayment.Caption = "金额";
            this.gcPayment.FieldName = "Payment";
            this.gcPayment.Name = "gcPayment";
            this.gcPayment.OptionsColumn.AllowEdit = false;
            this.gcPayment.Visible = true;
            this.gcPayment.VisibleIndex = 5;
            this.gcPayment.Width = 58;
            // 
            // gcTaxAmount
            // 
            this.gcTaxAmount.Caption = "税额";
            this.gcTaxAmount.FieldName = "TaxAmount";
            this.gcTaxAmount.Name = "gcTaxAmount";
            this.gcTaxAmount.Visible = true;
            this.gcTaxAmount.VisibleIndex = 6;
            this.gcTaxAmount.Width = 58;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 7;
            this.gcExchangeRate.Width = 58;
            // 
            // gcTaxRebateRate
            // 
            this.gcTaxRebateRate.Caption = "退税率";
            this.gcTaxRebateRate.FieldName = "TaxRebateRate";
            this.gcTaxRebateRate.Name = "gcTaxRebateRate";
            this.gcTaxRebateRate.Visible = true;
            this.gcTaxRebateRate.VisibleIndex = 8;
            this.gcTaxRebateRate.Width = 58;
            // 
            // gcCommission
            // 
            this.gcCommission.Caption = "佣金";
            this.gcCommission.FieldName = "Commission";
            this.gcCommission.Name = "gcCommission";
            this.gcCommission.Visible = true;
            this.gcCommission.VisibleIndex = 9;
            this.gcCommission.Width = 58;
            // 
            // gcFeedMoney
            // 
            this.gcFeedMoney.Caption = "进料款";
            this.gcFeedMoney.FieldName = "FeedMoney";
            this.gcFeedMoney.Name = "gcFeedMoney";
            this.gcFeedMoney.Visible = true;
            this.gcFeedMoney.VisibleIndex = 10;
            this.gcFeedMoney.Width = 58;
            // 
            // gcTotalCost
            // 
            this.gcTotalCost.Caption = "成本";
            this.gcTotalCost.FieldName = "TotalCost";
            this.gcTotalCost.Name = "gcTotalCost";
            this.gcTotalCost.OptionsColumn.AllowEdit = false;
            this.gcTotalCost.Visible = true;
            this.gcTotalCost.VisibleIndex = 11;
            this.gcTotalCost.Width = 58;
            // 
            // gcCustomsDeclaration
            // 
            this.gcCustomsDeclaration.Caption = "报关单";
            this.gcCustomsDeclaration.FieldName = "CustomsDeclaration";
            this.gcCustomsDeclaration.Name = "gcCustomsDeclaration";
            this.gcCustomsDeclaration.Visible = true;
            this.gcCustomsDeclaration.VisibleIndex = 12;
            this.gcCustomsDeclaration.Width = 58;
            // 
            // gcTaxpayerID
            // 
            this.gcTaxpayerID.Caption = "销方税号";
            this.gcTaxpayerID.FieldName = "TaxpayerID";
            this.gcTaxpayerID.Name = "gcTaxpayerID";
            this.gcTaxpayerID.Visible = true;
            this.gcTaxpayerID.VisibleIndex = 13;
            this.gcTaxpayerID.Width = 58;
            // 
            // gcSupplierName
            // 
            this.gcSupplierName.Caption = "销方名称";
            this.gcSupplierName.FieldName = "SupplierName";
            this.gcSupplierName.Name = "gcSupplierName";
            this.gcSupplierName.Visible = true;
            this.gcSupplierName.VisibleIndex = 14;
            this.gcSupplierName.Width = 58;
            // 
            // gcImportUserName
            // 
            this.gcImportUserName.Caption = "创建人";
            this.gcImportUserName.FieldName = "ImportUserName";
            this.gcImportUserName.Name = "gcImportUserName";
            this.gcImportUserName.OptionsColumn.AllowEdit = false;
            this.gcImportUserName.Visible = true;
            this.gcImportUserName.VisibleIndex = 15;
            this.gcImportUserName.Width = 58;
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
            this.gcImportDate.VisibleIndex = 16;
            this.gcImportDate.Width = 120;
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
            // frmInvoiceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 562);
            this.Controls.Add(this.gridInvoice);
            this.Name = "frmInvoiceQuery";
            this.Text = "交单管理";
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
    }
}