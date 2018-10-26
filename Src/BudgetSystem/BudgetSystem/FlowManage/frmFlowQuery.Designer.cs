namespace BudgetSystem.FlowManage
{
    partial class frmFlowQuery
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
            this.gdFlow = new DevExpress.XtraGrid.GridControl();
            this.gvFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLastEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnabledState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gdFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // gdFlow
            // 
            this.gdFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdFlow.Location = new System.Drawing.Point(0, 0);
            this.gdFlow.MainView = this.gvFlow;
            this.gdFlow.Name = "gdFlow";
            this.gdFlow.Size = new System.Drawing.Size(916, 812);
            this.gdFlow.TabIndex = 0;
            this.gdFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFlow});
            // 
            // gvFlow
            // 
            this.gvFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcFlowName,
            this.gcEditor,
            this.gcLastEditTime,
            this.gcVersion,
            this.gcDesc,
            this.gcEnabledState});
            this.gvFlow.GridControl = this.gdFlow;
            this.gvFlow.Name = "gvFlow";
            this.gvFlow.OptionsBehavior.Editable = false;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "流程名称";
            this.gcFlowName.FieldName = "Name";
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.OptionsColumn.FixedWidth = true;
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 0;
            this.gcFlowName.Width = 117;
            // 
            // gcEditor
            // 
            this.gcEditor.Caption = "创建人";
            this.gcEditor.FieldName = "CreateUser";
            this.gcEditor.Name = "gcEditor";
            this.gcEditor.OptionsColumn.FixedWidth = true;
            this.gcEditor.Visible = true;
            this.gcEditor.VisibleIndex = 3;
            this.gcEditor.Width = 120;
            // 
            // gcLastEditTime
            // 
            this.gcLastEditTime.Caption = "修改时间";
            this.gcLastEditTime.FieldName = "UpdateDate";
            this.gcLastEditTime.Name = "gcLastEditTime";
            this.gcLastEditTime.OptionsColumn.FixedWidth = true;
            this.gcLastEditTime.Visible = true;
            this.gcLastEditTime.VisibleIndex = 4;
            this.gcLastEditTime.Width = 153;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "描述";
            this.gcDesc.FieldName = "Remark";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 2;
            this.gcDesc.Width = 508;
            // 
            // gcVersion
            // 
            this.gcVersion.Caption = "版本";
            this.gcVersion.FieldName = "VersionNumber";
            this.gcVersion.Name = "gcVersion";
            this.gcVersion.Visible = true;
            this.gcVersion.VisibleIndex = 1;
            // 
            // gcEnabledState
            // 
            this.gcEnabledState.Caption = "状态";
            this.gcEnabledState.FieldName = "IsEnabled";
            this.gcEnabledState.Name = "gcEnabledState";
            this.gcEnabledState.Visible = true;
            this.gcEnabledState.VisibleIndex = 5;
            // 
            // frmFlowQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 812);
            this.Controls.Add(this.gdFlow);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFlowQuery";
            this.Text = "流程配置";
            ((System.ComponentModel.ISupportInitialize)(this.gdFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFlow;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcEditor;
        private DevExpress.XtraGrid.Columns.GridColumn gcLastEditTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcVersion;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnabledState;
    }
}