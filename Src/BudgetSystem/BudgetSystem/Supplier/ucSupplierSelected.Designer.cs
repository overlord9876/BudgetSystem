namespace BudgetSystem
{
    partial class ucSupplierSelected
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
            this.gridSupplier = new DevExpress.XtraGrid.GridControl();
            this.gvSupplier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLegal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSupplier
            // 
            this.gridSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSupplier.Location = new System.Drawing.Point(0, 0);
            this.gridSupplier.MainView = this.gvSupplier;
            this.gridSupplier.Name = "gridSupplier";
            this.gridSupplier.Size = new System.Drawing.Size(808, 515);
            this.gridSupplier.TabIndex = 0;
            this.gridSupplier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSupplier});
            // 
            // gvSupplier
            // 
            this.gvSupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIsSelected,
            this.gcName,
            this.gcSupplierType,
            this.gcLegal,
            this.gcDepartment,
            this.gcDepartmentName});
            this.gvSupplier.GridControl = this.gridSupplier;
            this.gvSupplier.GroupCount = 1;
            this.gvSupplier.GroupFormat = " {2}";
            this.gvSupplier.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "IsSelected", null, "")});
            this.gvSupplier.Name = "gvSupplier";
            this.gvSupplier.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvSupplier.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvSupplier.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvSupplier.OptionsDetail.EnableMasterViewMode = false;
            this.gvSupplier.OptionsDetail.ShowDetailTabs = false;
            this.gvSupplier.OptionsDetail.SmartDetailExpand = false;
            this.gvSupplier.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvSupplier.OptionsFind.AlwaysVisible = true;
            this.gvSupplier.OptionsView.ShowGroupedColumns = true;
            this.gvSupplier.OptionsView.ShowGroupPanel = false;
            this.gvSupplier.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIsSelected, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvSupplier.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvSupplier_CustomDrawGroupRow);
            this.gvSupplier.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSupplier_CellValueChanging);
            // 
            // gcIsSelected
            // 
            this.gcIsSelected.Caption = " ";
            this.gcIsSelected.FieldName = "IsSelected";
            this.gcIsSelected.Name = "gcIsSelected";
            this.gcIsSelected.Visible = true;
            this.gcIsSelected.VisibleIndex = 0;
            this.gcIsSelected.Width = 61;
            // 
            // gcName
            // 
            this.gcName.Caption = "名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            this.gcName.Width = 241;
            // 
            // gcSupplierType
            // 
            this.gcSupplierType.Caption = "供应商类型";
            this.gcSupplierType.FieldName = "SupplierType";
            this.gcSupplierType.Name = "gcSupplierType";
            this.gcSupplierType.OptionsColumn.AllowEdit = false;
            this.gcSupplierType.Visible = true;
            this.gcSupplierType.VisibleIndex = 2;
            this.gcSupplierType.Width = 150;
            // 
            // gcLegal
            // 
            this.gcLegal.Caption = "法人代表";
            this.gcLegal.FieldName = "Legal";
            this.gcLegal.Name = "gcLegal";
            this.gcLegal.OptionsColumn.AllowEdit = false;
            this.gcLegal.Visible = true;
            this.gcLegal.VisibleIndex = 3;
            this.gcLegal.Width = 150;
            // 
            // gcDepartment
            // 
            this.gcDepartment.Caption = "部门编号";
            this.gcDepartment.FieldName = "DepartmentCode";
            this.gcDepartment.Name = "gcDepartment";
            this.gcDepartment.OptionsColumn.AllowEdit = false;
            this.gcDepartment.Visible = true;
            this.gcDepartment.VisibleIndex = 4;
            this.gcDepartment.Width = 100;
            // 
            // gcDepartmentName
            // 
            this.gcDepartmentName.Caption = "部门名称";
            this.gcDepartmentName.FieldName = "DepartmentName";
            this.gcDepartmentName.Name = "gcDepartmentName";
            this.gcDepartmentName.OptionsColumn.AllowEdit = false;
            this.gcDepartmentName.Visible = true;
            this.gcDepartmentName.VisibleIndex = 5;
            this.gcDepartmentName.Width = 100;
            // 
            // ucSupplierSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSupplier);
            this.Name = "ucSupplierSelected";
            this.Size = new System.Drawing.Size(808, 515);
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).EndInit();
            this.ResumeLayout(false);

        } 

        #endregion

        private DevExpress.XtraGrid.GridControl gridSupplier;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplierType;
        private DevExpress.XtraGrid.Columns.GridColumn gcLegal;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentName;
    }
}
