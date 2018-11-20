namespace BudgetSystem
{
    partial class ucCountryOptionEdit
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
            this.gridCountry = new DevExpress.XtraGrid.GridControl();
            this.gvCountry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riHyperLinkEditDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCountry
            // 
            this.gridCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCountry.Location = new System.Drawing.Point(0, 0);
            this.gridCountry.MainView = this.gvCountry;
            this.gridCountry.Name = "gridCountry";
            this.gridCountry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riHyperLinkEditDelete});
            this.gridCountry.Size = new System.Drawing.Size(1046, 549);
            this.gridCountry.TabIndex = 6;
            this.gridCountry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCountry});
            // 
            // gvCountry
            // 
            this.gvCountry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcName,
            this.gcEnName,
            this.gcDelete});
            this.gvCountry.GridControl = this.gridCountry;
            this.gvCountry.Name = "gvCountry";
            this.gvCountry.NewItemRowText = "单击此处添加";
            this.gvCountry.OptionsDetail.EnableMasterViewMode = false;
            this.gvCountry.OptionsDetail.ShowDetailTabs = false;
            this.gvCountry.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvCountry.OptionsView.ShowGroupPanel = false;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "编码";
            this.gcCode.FieldName = "Code";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcCode.OptionsColumn.AllowMove = false;
            this.gcCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcCode.OptionsColumn.ShowInCustomizationForm = false;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 0;
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
            this.gcName.VisibleIndex = 1;
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
            this.gcEnName.VisibleIndex = 2;
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
            this.gcDelete.VisibleIndex = 3;
            this.gcDelete.Width = 80;
            // 
            // riHyperLinkEditDelete
            // 
            this.riHyperLinkEditDelete.AutoHeight = false;
            this.riHyperLinkEditDelete.Caption = "删除";
            this.riHyperLinkEditDelete.Name = "riHyperLinkEditDelete";
            this.riHyperLinkEditDelete.SingleClick = true;
            // 
            // ucCountryOptionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCountry);
            this.Name = "ucCountryOptionEdit";
            this.Size = new System.Drawing.Size(1046, 549);
            ((System.ComponentModel.ISupportInitialize)(this.gridCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHyperLinkEditDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridCountry;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit riHyperLinkEditDelete;
    }
}
