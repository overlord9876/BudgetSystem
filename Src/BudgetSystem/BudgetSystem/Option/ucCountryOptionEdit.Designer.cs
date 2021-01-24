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
            this.gcEnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsBR = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridCountry.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridCountry.Location = new System.Drawing.Point(0, 0);
            this.gridCountry.MainView = this.gvCountry;
            this.gridCountry.Margin = new System.Windows.Forms.Padding(2);
            this.gridCountry.Name = "gridCountry";
            this.gridCountry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riHyperLinkEditDelete});
            this.gridCountry.Size = new System.Drawing.Size(784, 439);
            this.gridCountry.TabIndex = 6;
            this.gridCountry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCountry});
            // 
            // gvCountry
            // 
            this.gvCountry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcEnName,
            this.gcName,
            this.gcIsBR,
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
            this.gcCode.AppearanceCell.Options.UseTextOptions = true;
            this.gcCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            // gcEnName
            // 
            this.gcEnName.AppearanceCell.Options.UseTextOptions = true;
            this.gcEnName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcEnName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcEnName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            // gcName
            // 
            this.gcName.AppearanceCell.Options.UseTextOptions = true;
            this.gcName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.Caption = "名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcName.OptionsColumn.AllowMove = false;
            this.gcName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcName.OptionsColumn.ShowInCustomizationForm = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 2;
            // 
            // gcIsBR
            // 
            this.gcIsBR.AppearanceCell.Options.UseTextOptions = true;
            this.gcIsBR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIsBR.AppearanceHeader.Options.UseTextOptions = true;
            this.gcIsBR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIsBR.Caption = "一带一路";
            this.gcIsBR.FieldName = "IsBR";
            this.gcIsBR.MaxWidth = 75;
            this.gcIsBR.MinWidth = 50;
            this.gcIsBR.Name = "gcIsBR";
            this.gcIsBR.Visible = true;
            this.gcIsBR.VisibleIndex = 3;
            // 
            // gcDelete
            // 
            this.gcDelete.AppearanceCell.Options.UseTextOptions = true;
            this.gcDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.gcDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDelete.Caption = " ";
            this.gcDelete.ColumnEdit = this.riHyperLinkEditDelete;
            this.gcDelete.MaxWidth = 80;
            this.gcDelete.MinWidth = 80;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.OptionsColumn.AllowMove = false;
            this.gcDelete.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcDelete.OptionsColumn.ShowInCustomizationForm = false;
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 4;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCountry);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucCountryOptionEdit";
            this.Size = new System.Drawing.Size(784, 439);
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
        private DevExpress.XtraGrid.Columns.GridColumn gcIsBR;
    }
}
