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
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSalesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueTradeNature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAdvancePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfitLevel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfitLevel2 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gcState,
            this.gcFlowName,
            this.gcTradeMode,
            this.gcTotalAmount,
            this.gcSalesman,
            this.gcDepartmentDesc,
            this.gcCreateDate,
            this.gcSignDate,
            this.gcValidity,
            this.gcTradeNature,
            this.gcPort,
            this.gcAdvancePayment,
            this.gcProfit,
            this.gcProfitLevel1,
            this.gcProfitLevel2});
            this.gvBudget.GridControl = this.gridBudget;
            this.gvBudget.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvBudget.Name = "gvBudget";
            this.gvBudget.OptionsBehavior.Editable = false;
            this.gvBudget.OptionsView.ShowDetailButtons = false;
            this.gvBudget.OptionsView.ShowGroupPanel = false;
            this.gvBudget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvBudget_MouseDown);
            this.gvBudget.DoubleClick += new System.EventHandler(this.gvBudget_DoubleClick);
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 0;
            this.gcContractNO.Width = 84;
            // 
            // gcCustomerName
            // 
            this.gcCustomerName.Caption = "客户名称";
            this.gcCustomerName.FieldName = "CustomerName";
            this.gcCustomerName.Name = "gcCustomerName";
            this.gcCustomerName.Visible = true;
            this.gcCustomerName.VisibleIndex = 1;
            this.gcCustomerName.Width = 78;
            // 
            // gcState
            // 
            this.gcState.Caption = "审批状态";
            this.gcState.FieldName = "EnumFlowState";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 2;
            this.gcState.Width = 77;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "当前流程";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 3;
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "贸易方式";
            this.gcTradeMode.FieldName = "TradeModeDesc";
            this.gcTradeMode.Name = "gcTradeMode";
            this.gcTradeMode.Visible = true;
            this.gcTradeMode.VisibleIndex = 4;
            // 
            // gcTotalAmount
            // 
            this.gcTotalAmount.Caption = "合同金额";
            this.gcTotalAmount.FieldName = "TotalAmount";
            this.gcTotalAmount.Name = "gcTotalAmount";
            this.gcTotalAmount.Visible = true;
            this.gcTotalAmount.VisibleIndex = 5;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "SalesmanName";
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 6;
            this.gcSalesman.Width = 57;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 7;
            this.gcDepartmentDesc.Width = 73;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 8;
            this.gcCreateDate.Width = 55;
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.Name = "gcSignDate";
            this.gcSignDate.Visible = true;
            this.gcSignDate.VisibleIndex = 9;
            this.gcSignDate.Width = 54;
            // 
            // gcValidity
            // 
            this.gcValidity.Caption = "有效截止期";
            this.gcValidity.FieldName = "Validity";
            this.gcValidity.Name = "gcValidity";
            this.gcValidity.Visible = true;
            this.gcValidity.VisibleIndex = 10;
            this.gcValidity.Width = 45;
            // 
            // gcTradeNature
            // 
            this.gcTradeNature.Caption = "贸易性质";
            this.gcTradeNature.ColumnEdit = this.rilueTradeNature;
            this.gcTradeNature.FieldName = "TradeNature";
            this.gcTradeNature.Name = "gcTradeNature";
            this.gcTradeNature.Visible = true;
            this.gcTradeNature.VisibleIndex = 11;
            this.gcTradeNature.Width = 59;
            // 
            // rilueTradeNature
            // 
            this.rilueTradeNature.AutoHeight = false;
            this.rilueTradeNature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rilueTradeNature.Name = "rilueTradeNature";
            // 
            // gcPort
            // 
            this.gcPort.Caption = "目的港口";
            this.gcPort.FieldName = "Port";
            this.gcPort.Name = "gcPort";
            this.gcPort.Visible = true;
            this.gcPort.VisibleIndex = 12;
            this.gcPort.Width = 54;
            // 
            // gcAdvancePayment
            // 
            this.gcAdvancePayment.Caption = "预付金额";
            this.gcAdvancePayment.FieldName = "AdvancePayment";
            this.gcAdvancePayment.Name = "gcAdvancePayment";
            this.gcAdvancePayment.Visible = true;
            this.gcAdvancePayment.VisibleIndex = 13;
            this.gcAdvancePayment.Width = 52;
            // 
            // gcProfit
            // 
            this.gcProfit.Caption = "利润";
            this.gcProfit.FieldName = "Profit";
            this.gcProfit.Name = "gcProfit";
            this.gcProfit.Visible = true;
            this.gcProfit.VisibleIndex = 14;
            this.gcProfit.Width = 38;
            // 
            // gcProfitLevel1
            // 
            this.gcProfitLevel1.Caption = "盈利水平1";
            this.gcProfitLevel1.FieldName = "ProfitLevel1";
            this.gcProfitLevel1.Name = "gcProfitLevel1";
            this.gcProfitLevel1.Visible = true;
            this.gcProfitLevel1.VisibleIndex = 15;
            this.gcProfitLevel1.Width = 59;
            // 
            // gcProfitLevel2
            // 
            this.gcProfitLevel2.Caption = "盈利水平2";
            this.gcProfitLevel2.FieldName = "ProfitLevel2";
            this.gcProfitLevel2.Name = "gcProfitLevel2";
            this.gcProfitLevel2.Visible = true;
            this.gcProfitLevel2.VisibleIndex = 16;
            this.gcProfitLevel2.Width = 59;
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
        private DevExpress.XtraGrid.Columns.GridColumn gcProfitLevel1;
        private DevExpress.XtraGrid.Columns.GridColumn gcProfitLevel2;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
    }
}