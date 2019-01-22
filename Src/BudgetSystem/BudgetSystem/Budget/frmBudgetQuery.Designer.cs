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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeNature)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBudget
            // 
            this.gridBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBudget.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridBudget.Location = new System.Drawing.Point(0, 0);
            this.gridBudget.MainView = this.gvBudget;
            this.gridBudget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridBudget.Name = "gridBudget";
            this.gridBudget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilueTradeNature});
            this.gridBudget.Size = new System.Drawing.Size(1377, 690);
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
            this.gcDepartmentDesc,
            this.gcCreateDate,
            this.gcSignDate,
            this.gcValidity,
            this.gcPort});
            this.gvBudget.GridControl = this.gridBudget;
            this.gvBudget.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvBudget.Name = "gvBudget";
            this.gvBudget.OptionsBehavior.Editable = false;
            this.gvBudget.OptionsView.ShowDetailButtons = false;
            this.gvBudget.OptionsView.ShowGroupPanel = false;
            this.gvBudget.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcContractNO, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.MinWidth = 80;
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 0;
            this.gcContractNO.Width = 100;
            // 
            // gcCustomerName
            // 
            this.gcCustomerName.Caption = "主买方名称";
            this.gcCustomerName.FieldName = "CustomerNameEx";
            this.gcCustomerName.MinWidth = 80;
            this.gcCustomerName.Name = "gcCustomerName";
            this.gcCustomerName.Visible = true;
            this.gcCustomerName.VisibleIndex = 1;
            this.gcCustomerName.Width = 80;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "当前流程";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.MinWidth = 80;
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 2;
            this.gcFlowName.Width = 80;
            // 
            // gcState
            // 
            this.gcState.Caption = "审批状态";
            this.gcState.FieldName = "EnumFlowState";
            this.gcState.MinWidth = 80;
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 3;
            this.gcState.Width = 80;
            // 
            // gcTotalAmount
            // 
            this.gcTotalAmount.Caption = "合同金额";
            this.gcTotalAmount.FieldName = "TotalAmount";
            this.gcTotalAmount.MinWidth = 80;
            this.gcTotalAmount.Name = "gcTotalAmount";
            this.gcTotalAmount.Visible = true;
            this.gcTotalAmount.VisibleIndex = 4;
            this.gcTotalAmount.Width = 80;
            // 
            // gcUSDTotalAmount
            // 
            this.gcUSDTotalAmount.Caption = "美元合同金额";
            this.gcUSDTotalAmount.FieldName = "USDTotalAmount";
            this.gcUSDTotalAmount.MinWidth = 80;
            this.gcUSDTotalAmount.Name = "gcUSDTotalAmount";
            this.gcUSDTotalAmount.Visible = true;
            this.gcUSDTotalAmount.VisibleIndex = 5;
            this.gcUSDTotalAmount.Width = 80;
            // 
            // gcTotalCost
            // 
            this.gcTotalCost.Caption = "总成本";
            this.gcTotalCost.FieldName = "TotalCost";
            this.gcTotalCost.MinWidth = 80;
            this.gcTotalCost.Name = "gcTotalCost";
            this.gcTotalCost.Visible = true;
            this.gcTotalCost.VisibleIndex = 6;
            this.gcTotalCost.Width = 80;
            // 
            // gcProfit
            // 
            this.gcProfit.Caption = "利润";
            this.gcProfit.FieldName = "Profit";
            this.gcProfit.MinWidth = 80;
            this.gcProfit.Name = "gcProfit";
            this.gcProfit.Visible = true;
            this.gcProfit.VisibleIndex = 7;
            this.gcProfit.Width = 80;
            // 
            // gcProfitLevel2
            // 
            this.gcProfitLevel2.Caption = "盈利水平";
            this.gcProfitLevel2.FieldName = "ProfitLevel2";
            this.gcProfitLevel2.MinWidth = 80;
            this.gcProfitLevel2.Name = "gcProfitLevel2";
            this.gcProfitLevel2.Visible = true;
            this.gcProfitLevel2.VisibleIndex = 8;
            this.gcProfitLevel2.Width = 80;
            // 
            // gcAdvancePayment
            // 
            this.gcAdvancePayment.Caption = "预付金额";
            this.gcAdvancePayment.FieldName = "AdvancePayment";
            this.gcAdvancePayment.MinWidth = 80;
            this.gcAdvancePayment.Name = "gcAdvancePayment";
            this.gcAdvancePayment.Visible = true;
            this.gcAdvancePayment.VisibleIndex = 9;
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
            this.gcTradeNature.VisibleIndex = 10;
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
            this.gcTradeMode.VisibleIndex = 11;
            this.gcTradeMode.Width = 80;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "SalesmanName";
            this.gcSalesman.MinWidth = 80;
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 12;
            this.gcSalesman.Width = 80;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.MinWidth = 80;
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 13;
            this.gcDepartmentDesc.Width = 80;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.MinWidth = 80;
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 14;
            this.gcCreateDate.Width = 80;
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.MinWidth = 80;
            this.gcSignDate.Name = "gcSignDate";
            this.gcSignDate.Visible = true;
            this.gcSignDate.VisibleIndex = 15;
            this.gcSignDate.Width = 80;
            // 
            // gcValidity
            // 
            this.gcValidity.Caption = "有效截止期";
            this.gcValidity.FieldName = "Validity";
            this.gcValidity.MinWidth = 80;
            this.gcValidity.Name = "gcValidity";
            this.gcValidity.Visible = true;
            this.gcValidity.VisibleIndex = 16;
            this.gcValidity.Width = 80;
            // 
            // gcPort
            // 
            this.gcPort.Caption = "目的港口";
            this.gcPort.FieldName = "Port";
            this.gcPort.MinWidth = 80;
            this.gcPort.Name = "gcPort";
            this.gcPort.Visible = true;
            this.gcPort.VisibleIndex = 17;
            this.gcPort.Width = 80;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xlsx|Excel2003|*.xls";
            this.saveFileDialog1.Title = "保存";
            // 
            // frmBudgetQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 690);
            this.Controls.Add(this.gridBudget);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
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
    }
}