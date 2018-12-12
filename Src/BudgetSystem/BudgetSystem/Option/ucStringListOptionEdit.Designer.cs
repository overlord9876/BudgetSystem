namespace BudgetSystem
{
    partial class ucStringListOptionEdit
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
            this.gridStringList = new DevExpress.XtraGrid.GridControl();
            this.gvStringList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riHyperLinkEditDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStringList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStringList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMoneyType
            // 
            this.gridStringList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStringList.Location = new System.Drawing.Point(0, 0);
            this.gridStringList.MainView = this.gvStringList;
            this.gridStringList.Name = "gridMoneyType";
            this.gridStringList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riHyperLinkEditDelete});
            this.gridStringList.Size = new System.Drawing.Size(908, 549);
            this.gridStringList.TabIndex = 6;
            this.gridStringList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStringList});
            // 
            // gvMoneyType
            // 
            this.gvStringList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcDelete});
            this.gvStringList.GridControl = this.gridStringList;
            this.gvStringList.Name = "gvMoneyType";
            this.gvStringList.NewItemRowText = "单击此处添加";
            this.gvStringList.OptionsDetail.EnableMasterViewMode = false;
            this.gvStringList.OptionsDetail.ShowDetailTabs = false;
            this.gvStringList.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvStringList.OptionsView.ShowGroupPanel = false;
            // 
            // gcEnName
            // 
            this.gcName.Caption = "名称";
            this.gcName.FieldName = "Name";
            this.gcName.MaxWidth = 300;
            this.gcName.Name = "gcEnName";
            this.gcName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcName.OptionsColumn.AllowMove = false;
            this.gcName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcName.OptionsColumn.ShowInCustomizationForm = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            this.gcName.Width = 300;
            // 
            // gcDelete
            // 
            this.gcDelete.Caption = " ";
            this.gcDelete.ColumnEdit = this.riHyperLinkEditDelete;
            this.gcDelete.MaxWidth = 80;
            this.gcDelete.MinWidth = 80;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.OptionsColumn.AllowMove = false;
            this.gcDelete.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcDelete.OptionsColumn.ShowInCustomizationForm = false;
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 1;
            this.gcDelete.Width = 80;
            // 
            // riHyperLinkEditDelete
            // 
            this.riHyperLinkEditDelete.AutoHeight = false;
            this.riHyperLinkEditDelete.Caption = "删除";
            this.riHyperLinkEditDelete.Name = "riHyperLinkEditDelete";
            this.riHyperLinkEditDelete.SingleClick = true;
            // 
            // ucMoneyTypeOptionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridStringList);
            this.Name = "ucMoneyTypeOptionEdit";
            this.Size = new System.Drawing.Size(908, 549);
            ((System.ComponentModel.ISupportInitialize)(this.gridStringList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStringList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridStringList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStringList;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riHyperLinkEditDelete;
    }
}
