namespace BudgetSystem
{
    partial class ucPortOptionEdit
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
            this.gridPort = new DevExpress.XtraGrid.GridControl();
            this.gvPort = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riHyperLinkEditDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPort
            // 
            this.gridPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPort.Location = new System.Drawing.Point(0, 0);
            this.gridPort.MainView = this.gvPort;
            this.gridPort.Name = "gridPort";
            this.gridPort.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riHyperLinkEditDelete});
            this.gridPort.Size = new System.Drawing.Size(1046, 549);
            this.gridPort.TabIndex = 6;
            this.gridPort.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPort});
            // 
            // gvPort
            // 
            this.gvPort.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcEnName,
            this.gcDelete});
            this.gvPort.GridControl = this.gridPort;
            this.gvPort.Name = "gvPort";
            this.gvPort.NewItemRowText = "单击此处添加";
            this.gvPort.OptionsDetail.EnableMasterViewMode = false;
            this.gvPort.OptionsDetail.ShowDetailTabs = false;
            this.gvPort.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvPort.OptionsView.ShowGroupPanel = false;
            // 
            // gcName
            // 
            this.gcName.Caption = "名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcName.OptionsColumn.AllowMove = false;
            this.gcName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcName.OptionsColumn.ShowInCustomizationForm = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // gcEnName
            // 
            this.gcEnName.Caption = "英文名称";
            this.gcEnName.FieldName = "EnName";
            this.gcEnName.Name = "gcEnName";
            this.gcEnName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcEnName.OptionsColumn.AllowMove = false;
            this.gcEnName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcEnName.OptionsColumn.ShowInCustomizationForm = false;
            this.gcEnName.Visible = true;
            this.gcEnName.VisibleIndex = 1;
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
            this.gcDelete.VisibleIndex = 2;
            this.gcDelete.Width = 80;
            // 
            // riHyperLinkEditDelete
            // 
            this.riHyperLinkEditDelete.AutoHeight = false;
            this.riHyperLinkEditDelete.Caption = "删除";
            this.riHyperLinkEditDelete.Name = "riHyperLinkEditDelete";
            this.riHyperLinkEditDelete.SingleClick = true;
            // 
            // ucPortOptionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPort);
            this.Name = "ucPortOptionEdit";
            this.Size = new System.Drawing.Size(1046, 549);
            ((System.ComponentModel.ISupportInitialize)(this.gridPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridPort;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPort;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riHyperLinkEditDelete;
    }
}
