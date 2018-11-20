namespace BudgetSystem
{
    partial class ucCustomerSelected
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCustomer
            // 
            this.gridCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCustomer.Location = new System.Drawing.Point(0, 0);
            this.gridCustomer.MainView = this.gvCustomer;
            this.gridCustomer.Name = "gridCustomer";
            this.gridCustomer.Size = new System.Drawing.Size(808, 515);
            this.gridCustomer.TabIndex = 0;
            this.gridCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIsSelected,
            this.gcName,
            this.gcCountry,
            this.gcState});
            this.gvCustomer.GridControl = this.gridCustomer;
            this.gvCustomer.GroupCount = 1;
            this.gvCustomer.GroupFormat = " {2}";
            this.gvCustomer.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "IsSelected", null, "")});
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvCustomer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvCustomer.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvCustomer.OptionsDetail.EnableMasterViewMode = false;
            this.gvCustomer.OptionsDetail.ShowDetailTabs = false;
            this.gvCustomer.OptionsDetail.SmartDetailExpand = false;
            this.gvCustomer.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvCustomer.OptionsFind.AlwaysVisible = true;
            this.gvCustomer.OptionsView.ShowGroupedColumns = true;
            this.gvCustomer.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvCustomer.OptionsView.ShowGroupPanel = false;
            this.gvCustomer.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIsSelected, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvCustomer.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvCustomer_CustomDrawGroupRow);
            this.gvCustomer.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvCustomer_CellValueChanging);
            // 
            // gcIsSelected
            // 
            this.gcIsSelected.Caption = " ";
            this.gcIsSelected.FieldName = "IsSelected";
            this.gcIsSelected.Name = "gcIsSelected";
            this.gcIsSelected.Visible = true;
            this.gcIsSelected.VisibleIndex = 0;
            this.gcIsSelected.Width = 66;
            // 
            // gcName
            // 
            this.gcName.Caption = "名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            // 
            // gcCountry
            // 
            this.gcCountry.Caption = "国家/地区";
            this.gcCountry.FieldName = "Country";
            this.gcCountry.Name = "gcCountry";
            this.gcCountry.OptionsColumn.AllowEdit = false;
            this.gcCountry.Visible = true;
            this.gcCountry.VisibleIndex = 2;
            // 
            // gcState
            // 
            this.gcState.Caption = "可用状态";
            this.gcState.FieldName = "State";
            this.gcState.Name = "gcState";
            this.gcState.OptionsColumn.AllowEdit = false;
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 3;
            // 
            // ucCustomerSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCustomer);
            this.Name = "ucCustomerSelected";
            this.Size = new System.Drawing.Size(808, 515);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private DevExpress.XtraGrid.GridControl gridCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
    }
}
