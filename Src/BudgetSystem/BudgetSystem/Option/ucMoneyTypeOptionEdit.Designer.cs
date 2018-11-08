namespace BudgetSystem
{
    partial class ucMoneyTypeOptionEdit
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
            this.gridMoneyType = new DevExpress.XtraGrid.GridControl();
            this.gvMoneyType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riHyperLinkEditDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMoneyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoneyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMoneyType
            // 
            this.gridMoneyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMoneyType.Location = new System.Drawing.Point(0, 0);
            this.gridMoneyType.MainView = this.gvMoneyType;
            this.gridMoneyType.Name = "gridMoneyType";
            this.gridMoneyType.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riHyperLinkEditDelete});
            this.gridMoneyType.Size = new System.Drawing.Size(908, 549);
            this.gridMoneyType.TabIndex = 6;
            this.gridMoneyType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMoneyType});
            // 
            // gvMoneyType
            // 
            this.gvMoneyType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEnName,
            this.gcDelete});
            this.gvMoneyType.GridControl = this.gridMoneyType;
            this.gvMoneyType.Name = "gvMoneyType";
            this.gvMoneyType.NewItemRowText = "单击此处添加";
            this.gvMoneyType.OptionsDetail.EnableMasterViewMode = false;
            this.gvMoneyType.OptionsDetail.ShowDetailTabs = false;
            this.gvMoneyType.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvMoneyType.OptionsView.ShowGroupPanel = false;
            // 
            // gcEnName
            // 
            this.gcEnName.Caption = "名称";
            this.gcEnName.FieldName = "Name";
            this.gcEnName.MaxWidth = 300;
            this.gcEnName.Name = "gcEnName";
            this.gcEnName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcEnName.OptionsColumn.AllowMove = false;
            this.gcEnName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcEnName.OptionsColumn.ShowInCustomizationForm = false;
            this.gcEnName.Visible = true;
            this.gcEnName.VisibleIndex = 0;
            this.gcEnName.Width = 300;
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
            this.Controls.Add(this.gridMoneyType);
            this.Name = "ucMoneyTypeOptionEdit";
            this.Size = new System.Drawing.Size(908, 549);
            ((System.ComponentModel.ISupportInitialize)(this.gridMoneyType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoneyType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridMoneyType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMoneyType;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riHyperLinkEditDelete;
    }
}
