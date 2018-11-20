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
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSalesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueTradeMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcTradeNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueTradeNature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAdvancePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeNature)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridBudget);
            this.splitContainerControl1.Size = new System.Drawing.Size(1205, 537);
            // 
            // panCondition
            // 
            this.panCondition.Controls.Add(this.tableLayoutPanel1);
            this.panCondition.Margin = new System.Windows.Forms.Padding(3);
            this.panCondition.Size = new System.Drawing.Size(285, 463);
            // 
            // gridBudget
            // 
            this.gridBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBudget.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridBudget.Location = new System.Drawing.Point(0, 0);
            this.gridBudget.MainView = this.gvBudget;
            this.gridBudget.Margin = new System.Windows.Forms.Padding(2);
            this.gridBudget.Name = "gridBudget";
            this.gridBudget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilueTradeMode,
            this.rilueTradeNature});
            this.gridBudget.Size = new System.Drawing.Size(907, 537);
            this.gridBudget.TabIndex = 0;
            this.gridBudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBudget});
            // 
            // gvBudget
            // 
            this.gvBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcContractNO,
            this.gcState,
            this.gcTotalAmount,
            this.gcSalesman,
            this.gcDepartmentDesc,
            this.gcCreateDate,
            this.gcSignDate,
            this.gcValidity,
            this.gcCustomerName,
            this.gcTradeMode,
            this.gcTradeNature,
            this.gcPort,
            this.gcAdvancePayment,
            this.gcProfit});
            this.gvBudget.GridControl = this.gridBudget;
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
            // 
            // gcState
            // 
            this.gcState.Caption = "审批状态";
            this.gcState.FieldName = "EnumFlowState";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 3;
            // 
            // gcTotalAmount
            // 
            this.gcTotalAmount.Caption = "合同金额";
            this.gcTotalAmount.FieldName = "TotalAmount";
            this.gcTotalAmount.Name = "gcTotalAmount";
            this.gcTotalAmount.Visible = true;
            this.gcTotalAmount.VisibleIndex = 4;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "SalesmanName";
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 5;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 6;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 7;
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.Name = "gcSignDate";
            this.gcSignDate.Visible = true;
            this.gcSignDate.VisibleIndex = 8;
            // 
            // gcValidity
            // 
            this.gcValidity.Caption = "有效截止期";
            this.gcValidity.FieldName = "Validity";
            this.gcValidity.Name = "gcValidity";
            this.gcValidity.Visible = true;
            this.gcValidity.VisibleIndex = 9;
            // 
            // gcCustomerName
            // 
            this.gcCustomerName.Caption = "客户名称";
            this.gcCustomerName.FieldName = "CustomerName";
            this.gcCustomerName.Name = "gcCustomerName";
            this.gcCustomerName.Visible = true;
            this.gcCustomerName.VisibleIndex = 1;
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "贸易方式";
            this.gcTradeMode.ColumnEdit = this.rilueTradeMode;
            this.gcTradeMode.FieldName = "TradeMode";
            this.gcTradeMode.Name = "gcTradeMode";
            this.gcTradeMode.Visible = true;
            this.gcTradeMode.VisibleIndex = 2;
            // 
            // rilueTradeMode
            // 
            this.rilueTradeMode.AutoHeight = false;
            this.rilueTradeMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rilueTradeMode.Name = "rilueTradeMode";
            // 
            // gcTradeNature
            // 
            this.gcTradeNature.Caption = "贸易性质";
            this.gcTradeNature.ColumnEdit = this.rilueTradeNature;
            this.gcTradeNature.FieldName = "TradeNature";
            this.gcTradeNature.Name = "gcTradeNature";
            this.gcTradeNature.Visible = true;
            this.gcTradeNature.VisibleIndex = 10;
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
            this.gcPort.VisibleIndex = 11;
            // 
            // gcAdvancePayment
            // 
            this.gcAdvancePayment.Caption = "预付金额";
            this.gcAdvancePayment.FieldName = "AdvancePayment";
            this.gcAdvancePayment.Name = "gcAdvancePayment";
            this.gcAdvancePayment.Visible = true;
            this.gcAdvancePayment.VisibleIndex = 12;
            // 
            // gcProfit
            // 
            this.gcProfit.Caption = "利润";
            this.gcProfit.FieldName = "Profit";
            this.gcProfit.Name = "gcProfit";
            this.gcProfit.Visible = true;
            this.gcProfit.VisibleIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textEdit1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textEdit2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 463);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textEdit1
            // 
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit1.Location = new System.Drawing.Point(72, 2);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(211, 21);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "预算单号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(2, 21);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 15);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "合同号：";
            // 
            // textEdit2
            // 
            this.textEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit2.Location = new System.Drawing.Point(72, 21);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(2);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(211, 21);
            this.textEdit2.TabIndex = 1;
            // 
            // frmBudgetQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 537);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmBudgetQuery";
            this.Text = "预算单查询";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueTradeNature)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudget;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit2;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilueTradeMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilueTradeNature;
    }
}