namespace BudgetSystem
{
    partial class frmBudgetQuery
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
            this.gridBudget = new DevExpress.XtraGrid.GridControl();
            this.gvBudget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUSDTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfitLevel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAdvancePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueTradeNature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcTradeMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSalesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArchiveApplyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArchiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gcSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeNature)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBudget
            // 
            this.gridBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBudget.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridBudget.Location = new System.Drawing.Point(0, 0);
            this.gridBudget.MainView = this.gvBudget;
            this.gridBudget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridBudget.Name = "gridBudget";
            this.gridBudget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilueTradeNature});
            this.gridBudget.Size = new System.Drawing.Size(1205, 537);
            this.gridBudget.TabIndex = 0;
            this.gridBudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBudget});
            // 
            // gvBudget
            // 
            this.gvBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcContractNO,
            this.gcCustomerName,
            this.gcFlowName,
            this.gcFlowState,
            this.gcState,
            this.gcTotalAmount,
            this.gcUSDTotalAmount,
            this.gcTotalCost,
            this.gcProfit,
            this.gcProfitLevel2,
            this.gcAdvancePayment,
            this.gcTradeNature,
            this.gcTradeMode,
            this.gcSalesman,
            this.gcSupplier,
            this.gcDepartmentDesc,
            this.gcCreateDate,
            this.gcSignDate,
            this.gcValidity,
            this.gcPort,
            this.gcArchiveApplyDate,
            this.gcArchiveDate});
            this.gvBudget.GridControl = this.gridBudget;
            this.gvBudget.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvBudget.Name = "gvBudget";
            this.gvBudget.OptionsBehavior.Editable = false;
            this.gvBudget.OptionsView.ColumnAutoWidth = false;
            this.gvBudget.OptionsView.ShowDetailButtons = false;
            this.gvBudget.OptionsView.ShowGroupPanel = false;
            this.gvBudget.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcFlowState, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCreateDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcContractNO.MinWidth = 120;
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 0;
            this.gcContractNO.Width = 120;
            // 
            // gcCustomerName
            // 
            this.gcCustomerName.Caption = "主买方名称";
            this.gcCustomerName.FieldName = "CustomerNameEx";
            this.gcCustomerName.MinWidth = 120;
            this.gcCustomerName.Name = "gcCustomerName";
            this.gcCustomerName.Visible = true;
            this.gcCustomerName.VisibleIndex = 1;
            this.gcCustomerName.Width = 120;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "当前流程";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.MinWidth = 100;
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 2;
            this.gcFlowName.Width = 100;
            // 
            // gcFlowState
            // 
            this.gcFlowState.Caption = "审批状态";
            this.gcFlowState.FieldName = "EnumFlowState";
            this.gcFlowState.MinWidth = 80;
            this.gcFlowState.Name = "gcFlowState";
            this.gcFlowState.Visible = true;
            this.gcFlowState.VisibleIndex = 3;
            this.gcFlowState.Width = 80;
            // 
            // gcState
            // 
            this.gcState.Caption = "预算单状态";
            this.gcState.FieldName = "StringState";
            this.gcState.MinWidth = 75;
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 4;
            this.gcState.Width = 85;
            // 
            // gcTotalAmount
            // 
            this.gcTotalAmount.Caption = "合同金额";
            this.gcTotalAmount.FieldName = "TotalAmount";
            this.gcTotalAmount.MinWidth = 80;
            this.gcTotalAmount.Name = "gcTotalAmount";
            this.gcTotalAmount.Visible = true;
            this.gcTotalAmount.VisibleIndex = 5;
            this.gcTotalAmount.Width = 80;
            // 
            // gcUSDTotalAmount
            // 
            this.gcUSDTotalAmount.Caption = "美元合同金额";
            this.gcUSDTotalAmount.FieldName = "USDTotalAmount";
            this.gcUSDTotalAmount.MinWidth = 80;
            this.gcUSDTotalAmount.Name = "gcUSDTotalAmount";
            this.gcUSDTotalAmount.Visible = true;
            this.gcUSDTotalAmount.VisibleIndex = 6;
            this.gcUSDTotalAmount.Width = 80;
            // 
            // gcTotalCost
            // 
            this.gcTotalCost.Caption = "总成本";
            this.gcTotalCost.FieldName = "TotalCost";
            this.gcTotalCost.MinWidth = 80;
            this.gcTotalCost.Name = "gcTotalCost";
            this.gcTotalCost.Visible = true;
            this.gcTotalCost.VisibleIndex = 7;
            this.gcTotalCost.Width = 80;
            // 
            // gcProfit
            // 
            this.gcProfit.Caption = "利润";
            this.gcProfit.FieldName = "Profit";
            this.gcProfit.MinWidth = 80;
            this.gcProfit.Name = "gcProfit";
            this.gcProfit.Visible = true;
            this.gcProfit.VisibleIndex = 8;
            this.gcProfit.Width = 80;
            // 
            // gcProfitLevel2
            // 
            this.gcProfitLevel2.Caption = "盈利水平";
            this.gcProfitLevel2.FieldName = "ProfitLevel2";
            this.gcProfitLevel2.MinWidth = 80;
            this.gcProfitLevel2.Name = "gcProfitLevel2";
            this.gcProfitLevel2.Visible = true;
            this.gcProfitLevel2.VisibleIndex = 9;
            this.gcProfitLevel2.Width = 80;
            // 
            // gcAdvancePayment
            // 
            this.gcAdvancePayment.Caption = "预付金额";
            this.gcAdvancePayment.FieldName = "AdvancePayment";
            this.gcAdvancePayment.MinWidth = 80;
            this.gcAdvancePayment.Name = "gcAdvancePayment";
            this.gcAdvancePayment.Visible = true;
            this.gcAdvancePayment.VisibleIndex = 10;
            this.gcAdvancePayment.Width = 80;
            // 
            // gcTradeNature
            // 
            this.gcTradeNature.Caption = "贸易性质";
            this.gcTradeNature.ColumnEdit = this.rilueTradeNature;
            this.gcTradeNature.FieldName = "TradeNature";
            this.gcTradeNature.MinWidth = 80;
            this.gcTradeNature.Name = "gcTradeNature";
            this.gcTradeNature.Visible = true;
            this.gcTradeNature.VisibleIndex = 11;
            this.gcTradeNature.Width = 80;
            // 
            // rilueTradeNature
            // 
            this.rilueTradeNature.AutoHeight = false;
            this.rilueTradeNature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rilueTradeNature.Name = "rilueTradeNature";
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "贸易方式";
            this.gcTradeMode.FieldName = "TradeModeDesc";
            this.gcTradeMode.MinWidth = 80;
            this.gcTradeMode.Name = "gcTradeMode";
            this.gcTradeMode.Visible = true;
            this.gcTradeMode.VisibleIndex = 12;
            this.gcTradeMode.Width = 80;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "SalesmanName";
            this.gcSalesman.MinWidth = 80;
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 13;
            this.gcSalesman.Width = 80;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.MinWidth = 80;
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 15;
            this.gcDepartmentDesc.Width = 80;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.DisplayFormat.FormatString = "g";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.MinWidth = 80;
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 16;
            this.gcCreateDate.Width = 110;
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.MinWidth = 80;
            this.gcSignDate.Name = "gcSignDate";
            this.gcSignDate.Visible = true;
            this.gcSignDate.VisibleIndex = 17;
            this.gcSignDate.Width = 80;
            // 
            // gcValidity
            // 
            this.gcValidity.Caption = "有效截止期";
            this.gcValidity.FieldName = "Validity";
            this.gcValidity.MinWidth = 80;
            this.gcValidity.Name = "gcValidity";
            this.gcValidity.Visible = true;
            this.gcValidity.VisibleIndex = 18;
            this.gcValidity.Width = 80;
            // 
            // gcPort
            // 
            this.gcPort.Caption = "目的港口";
            this.gcPort.FieldName = "Port";
            this.gcPort.MinWidth = 80;
            this.gcPort.Name = "gcPort";
            this.gcPort.Visible = true;
            this.gcPort.VisibleIndex = 19;
            this.gcPort.Width = 80;
            // 
            // gcArchiveApplyDate
            // 
            this.gcArchiveApplyDate.Caption = "归档征求日期";
            this.gcArchiveApplyDate.FieldName = "ArchiveApplyDate";
            this.gcArchiveApplyDate.Name = "gcArchiveApplyDate";
            this.gcArchiveApplyDate.Visible = true;
            this.gcArchiveApplyDate.VisibleIndex = 20;
            this.gcArchiveApplyDate.Width = 85;
            // 
            // gcArchiveDate
            // 
            this.gcArchiveDate.Caption = "归档日期";
            this.gcArchiveDate.FieldName = "ArchiveDate";
            this.gcArchiveDate.Name = "gcArchiveDate";
            this.gcArchiveDate.Visible = true;
            this.gcArchiveDate.VisibleIndex = 21;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xlsx|Excel2003|*.xls";
            this.saveFileDialog1.Title = "保存";
            // 
            // gcSupplier
            // 
            this.gcSupplier.Caption = "合格供应商";
            this.gcSupplier.FieldName = "QualifiedSupplier";
            this.gcSupplier.Name = "gcSupplier";
            this.gcSupplier.Visible = true;
            this.gcSupplier.VisibleIndex = 14;
            // 
            // frmBudgetQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 537);
            this.Controls.Add(this.gridBudget);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "frmBudgetQuery";
            this.Text = "预算单查询";
            ((System.ComponentModel.ISupportInitialize)(this.gridBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeNature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudget;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowState;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcSalesman;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcValidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeMode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeNature;
        private DevExpress.XtraGrid.Columns.GridColumn gcPort;
        private DevExpress.XtraGrid.Columns.GridColumn gcAdvancePayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcProfit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilueTradeNature;
        private DevExpress.XtraGrid.Columns.GridColumn gcProfitLevel2;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUSDTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalCost;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
        private DevExpress.XtraGrid.Columns.GridColumn gcArchiveApplyDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcArchiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplier;
    }
}