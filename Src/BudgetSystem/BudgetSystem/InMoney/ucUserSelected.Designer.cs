namespace BudgetSystem
{
    partial class ucUserSelected
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
            this.gridUsers = new DevExpress.XtraGrid.GridControl();
            this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUsers
            // 
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridUsers.Location = new System.Drawing.Point(0, 0);
            this.gridUsers.MainView = this.gvUsers;
            this.gridUsers.Margin = new System.Windows.Forms.Padding(2);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.Size = new System.Drawing.Size(606, 412);
            this.gridUsers.TabIndex = 0;
            this.gridUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsers});
            // 
            // gvUsers
            // 
            this.gvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIsSelected,
            this.gcUserName,
            this.gcRealName,
            this.gcDepartment,
            this.gcDepartmentName});
            this.gvUsers.GridControl = this.gridUsers;
            this.gvUsers.GroupCount = 1;
            this.gvUsers.GroupFormat = " {2}";
            this.gvUsers.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "IsSelected", null, "")});
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvUsers.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvUsers.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvUsers.OptionsDetail.EnableMasterViewMode = false;
            this.gvUsers.OptionsDetail.ShowDetailTabs = false;
            this.gvUsers.OptionsDetail.SmartDetailExpand = false;
            this.gvUsers.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvUsers.OptionsFind.AlwaysVisible = true;
            this.gvUsers.OptionsView.ShowGroupedColumns = true;
            this.gvUsers.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvUsers.OptionsView.ShowGroupPanel = false;
            this.gvUsers.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIsSelected, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvUsers.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvUser_CustomDrawGroupRow);
            this.gvUsers.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvUser_CellValueChanging);
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
            // gcUserName
            // 
            this.gcUserName.Caption = "用户名";
            this.gcUserName.FieldName = "UserName";
            this.gcUserName.Name = "gcUserName";
            this.gcUserName.OptionsColumn.AllowEdit = false;
            this.gcUserName.Visible = true;
            this.gcUserName.VisibleIndex = 1;
            // 
            // gcRealName
            // 
            this.gcRealName.Caption = "用户姓名";
            this.gcRealName.FieldName = "RealName";
            this.gcRealName.Name = "gcRealName";
            this.gcRealName.OptionsColumn.AllowEdit = false;
            this.gcRealName.Visible = true;
            this.gcRealName.VisibleIndex = 2;
            // 
            // gcDepartmentName
            // 
            this.gcDepartmentName.Caption = "所在部门";
            this.gcDepartmentName.FieldName = "DepartmentName";
            this.gcDepartmentName.Name = "gcDepartmentName";
            this.gcDepartmentName.OptionsColumn.AllowEdit = false;
            this.gcDepartmentName.Visible = true;
            this.gcDepartmentName.VisibleIndex = 4;
            // 
            // gcDepartment
            // 
            this.gcDepartment.Caption = "所在部门编号";
            this.gcDepartment.FieldName = "Department";
            this.gcDepartment.Name = "gcDepartment";
            this.gcDepartment.OptionsColumn.AllowEdit = false;
            this.gcDepartment.Visible = true;
            this.gcDepartment.VisibleIndex = 3;
            // 
            // ucUserSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridUsers);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucUserSelected";
            this.Size = new System.Drawing.Size(606, 412);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private DevExpress.XtraGrid.GridControl gridUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartment;
    }
}
