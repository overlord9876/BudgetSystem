namespace BudgetSystem.Report
{
    partial class frmSlipperReport
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
            this.beiContractNO = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSalesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomerNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradeNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSeaport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAdvancePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPivote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGridBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcStatBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(829, 657, 552, 529);
            this.layoutControl1.Size = new System.Drawing.Size(1759, 811);
            this.layoutControl1.Controls.SetChildIndex(this.listBox, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(1759, 811);
            // 
            // lcgPivote
            // 
            this.lcgPivote.Size = new System.Drawing.Size(1715, 742);
            // 
            // listBox
            // 
            this.listBox.Size = new System.Drawing.Size(327, 708);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1739, 791);
            // 
            // lcgGrid
            // 
            this.lcgGrid.Size = new System.Drawing.Size(1715, 742);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(1715, 712);
            // 
            // lcGridBar
            // 
            this.lcGridBar.Size = new System.Drawing.Size(1715, 30);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Location = new System.Drawing.Point(336, 30);
            this.layoutControlItem3.Size = new System.Drawing.Size(1379, 712);
            // 
            // lcStatBar
            // 
            this.lcStatBar.Size = new System.Drawing.Size(1715, 30);
            // 
            // splitterItem
            // 
            this.splitterItem.Location = new System.Drawing.Point(331, 30);
            this.splitterItem.Size = new System.Drawing.Size(5, 712);
            // 
            // lcList
            // 
            this.lcList.Size = new System.Drawing.Size(331, 712);
            // 
            // beiContractNO
            // 
            this.beiContractNO.Caption = "选择合同：";
            this.beiContractNO.Edit = this.repositoryItemGridLookUpEdit1;
            this.beiContractNO.EditValue = "";
            this.beiContractNO.Id = 20;
            this.beiContractNO.Name = "beiContractNO";
            this.beiContractNO.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.beiContractNO.Width = 150;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.ActionButtonIndex = 1;
            this.repositoryItemGridLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcContractNO,
            this.gcState,
            this.gcTotalAmount,
            this.gcSalesman,
            this.gcDepartmentDesc,
            this.gcCreateDate,
            this.gcSignDate,
            this.gcValidity,
            this.gcCustomerNames,
            this.gcTradeMode,
            this.gcTradeNature,
            this.gcSeaport,
            this.gcAdvancePayment,
            this.gcProfit});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowDetailButtons = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 0;
            this.gcContractNO.Width = 150;
            // 
            // gcState
            // 
            this.gcState.Caption = "审批状态";
            this.gcState.FieldName = "EnumFlowState";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 1;
            this.gcState.Width = 80;
            // 
            // gcTotalAmount
            // 
            this.gcTotalAmount.Caption = "合同金额";
            this.gcTotalAmount.FieldName = "TotalAmount";
            this.gcTotalAmount.Name = "gcTotalAmount";
            this.gcTotalAmount.Visible = true;
            this.gcTotalAmount.VisibleIndex = 2;
            this.gcTotalAmount.Width = 80;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "SalesmanName";
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 3;
            this.gcSalesman.Width = 34;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 4;
            this.gcDepartmentDesc.Width = 40;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "录入时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.Name = "gcSignDate";
            // 
            // gcValidity
            // 
            this.gcValidity.Caption = "有效截止期";
            this.gcValidity.FieldName = "Validity";
            this.gcValidity.Name = "gcValidity";
            // 
            // gcCustomerNames
            // 
            this.gcCustomerNames.Caption = "客户名称";
            this.gcCustomerNames.FieldName = "CustomerNames";
            this.gcCustomerNames.Name = "gcCustomerNames";
            // 
            // gcTradeMode
            // 
            this.gcTradeMode.Caption = "贸易方式";
            this.gcTradeMode.FieldName = "TradeMode";
            this.gcTradeMode.Name = "gcTradeMode";
            // 
            // gcTradeNature
            // 
            this.gcTradeNature.Caption = "贸易性质";
            this.gcTradeNature.FieldName = "TradeNature";
            this.gcTradeNature.Name = "gcTradeNature";
            // 
            // gcSeaport
            // 
            this.gcSeaport.Caption = "交货口岸";
            this.gcSeaport.FieldName = "Seaport";
            this.gcSeaport.Name = "gcSeaport";
            // 
            // gcAdvancePayment
            // 
            this.gcAdvancePayment.Caption = "预付金额";
            this.gcAdvancePayment.FieldName = "AdvancePayment";
            this.gcAdvancePayment.Name = "gcAdvancePayment";
            // 
            // gcProfit
            // 
            this.gcProfit.Caption = "利润";
            this.gcProfit.FieldName = "Profit";
            this.gcProfit.Name = "gcProfit";
            // 
            // frmSlipperReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1759, 811);
            this.Name = "frmSlipperReport";
            this.Text = "供应商管理";
            this.Load += new System.EventHandler(this.frmSlipperReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPivote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGridBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcStatBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarEditItem beiContractNO; 
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gcSalesman;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcValidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomerNames;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeMode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradeNature;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeaport;
        private DevExpress.XtraGrid.Columns.GridColumn gcAdvancePayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcProfit;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
    }
}