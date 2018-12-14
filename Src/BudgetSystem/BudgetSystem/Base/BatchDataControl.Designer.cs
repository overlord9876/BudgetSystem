namespace BudgetSystem
{
    partial class BatchDataControl
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
            this.gdBatchApproveData = new DevExpress.XtraGrid.GridControl();
            this.gvBatchApproveData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gdBatchApproveData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBatchApproveData)).BeginInit();
            this.SuspendLayout();
            // 
            // gdBatchApproveData
            // 
            this.gdBatchApproveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdBatchApproveData.Location = new System.Drawing.Point(0, 0);
            this.gdBatchApproveData.MainView = this.gvBatchApproveData;
            this.gdBatchApproveData.Name = "gdBatchApproveData";
            this.gdBatchApproveData.Size = new System.Drawing.Size(951, 346);
            this.gdBatchApproveData.TabIndex = 0;
            this.gdBatchApproveData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBatchApproveData});
            // 
            // gvBatchApproveData
            // 
            this.gvBatchApproveData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcText,
            this.gcMoney,
            this.gcDescription});
            this.gvBatchApproveData.GridControl = this.gdBatchApproveData;
            this.gvBatchApproveData.Name = "gvBatchApproveData";
            this.gvBatchApproveData.OptionsBehavior.Editable = false;
            this.gvBatchApproveData.OptionsView.ShowFooter = true;
            this.gvBatchApproveData.OptionsView.ShowGroupPanel = false;
            // 
            // gcText
            // 
            this.gcText.Caption = "审批项";
            this.gcText.FieldName = "DataText";
            this.gcText.Name = "gcText";
            this.gcText.Visible = true;
            this.gcText.VisibleIndex = 0;
            this.gcText.Width = 152;
            // 
            // gcMoney
            // 
            this.gcMoney.Caption = "金额";
            this.gcMoney.FieldName = "Money";
            this.gcMoney.Name = "gcMoney";
            this.gcMoney.Visible = true;
            this.gcMoney.VisibleIndex = 1;
            this.gcMoney.Width = 169;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "审批项描述";
            this.gcDescription.FieldName = "DataDesc";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 2;
            this.gcDescription.Width = 612;
            // 
            // BatchDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdBatchApproveData);
            this.Name = "BatchDataControl";
            this.Size = new System.Drawing.Size(951, 346);
            ((System.ComponentModel.ISupportInitialize)(this.gdBatchApproveData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBatchApproveData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdBatchApproveData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBatchApproveData;
        private DevExpress.XtraGrid.Columns.GridColumn gcText;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoney;
    }
}
