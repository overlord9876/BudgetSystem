namespace BudgetSystem.WorkSpace
{
    partial class frmMyFlowListQuery
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gdFlow = new DevExpress.XtraGrid.GridControl();
            this.gvFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDateItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateItemText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowVersionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUserRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcNextUserRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApproveResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCloseReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCloseDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(285, 463);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(105, 41);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(168, 25);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 5;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(105, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(168, 25);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(285, 463);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.CustomizationFormText = "客户名称：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(265, 29);
            this.layoutControlItem1.Text = "客户名称：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(90, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "国家或地区：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 414);
            this.layoutControlItem2.Text = "国家或地区：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(90, 18);
            // 
            // gdFlow
            // 
            this.gdFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdFlow.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gdFlow.Location = new System.Drawing.Point(0, 0);
            this.gdFlow.MainView = this.gvFlow;
            this.gdFlow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gdFlow.Name = "gdFlow";
            this.gdFlow.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemImageComboBox1});
            this.gdFlow.Size = new System.Drawing.Size(1006, 564);
            this.gdFlow.TabIndex = 2;
            this.gdFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFlow});
            // 
            // gvFlow
            // 
            this.gvFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDateItemID,
            this.gcDateItemText,
            this.gcFlowName,
            this.gcFlowVersionNumber,
            this.gcCreateUserRealName,
            this.gcCreateDate,
            this.gcIsClosed,
            this.gcNextUserRealName,
            this.gcApproveResult,
            this.gcCloseReason,
            this.gcCloseDateTime,
            this.gcID});
            this.gvFlow.GridControl = this.gdFlow;
            this.gvFlow.Name = "gvFlow";
            this.gvFlow.OptionsBehavior.Editable = false;
            this.gvFlow.OptionsView.ShowGroupPanel = false;
            this.gvFlow.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcApproveResult, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCreateDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gcDateItemID
            // 
            this.gcDateItemID.Caption = "审批项编号";
            this.gcDateItemID.FieldName = "DateItemID";
            this.gcDateItemID.Name = "gcDateItemID";
            // 
            // gcDateItemText
            // 
            this.gcDateItemText.Caption = "审批项";
            this.gcDateItemText.FieldName = "DateItemText";
            this.gcDateItemText.Name = "gcDateItemText";
            this.gcDateItemText.Visible = true;
            this.gcDateItemText.VisibleIndex = 1;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "审批流程";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 0;
            // 
            // gcFlowVersionNumber
            // 
            this.gcFlowVersionNumber.Caption = "流程版本号";
            this.gcFlowVersionNumber.FieldName = "FlowVersionNumber";
            this.gcFlowVersionNumber.Name = "gcFlowVersionNumber";
            // 
            // gcCreateUserRealName
            // 
            this.gcCreateUserRealName.Caption = "流程发起人";
            this.gcCreateUserRealName.FieldName = "CreateUserRealName";
            this.gcCreateUserRealName.Name = "gcCreateUserRealName";
            this.gcCreateUserRealName.Visible = true;
            this.gcCreateUserRealName.VisibleIndex = 2;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "流程发起时间";
            this.gcCreateDate.DisplayFormat.FormatString = "g";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 3;
            // 
            // gcIsClosed
            // 
            this.gcIsClosed.Caption = "流程审批状态";
            this.gcIsClosed.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gcIsClosed.FieldName = "IsClosed";
            this.gcIsClosed.Name = "gcIsClosed";
            this.gcIsClosed.Visible = true;
            this.gcIsClosed.VisibleIndex = 4;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("已完成", true, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("进行中", false, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gcNextUserRealName
            // 
            this.gcNextUserRealName.Caption = "下一步审批人";
            this.gcNextUserRealName.FieldName = "NextUserRealName";
            this.gcNextUserRealName.Name = "gcNextUserRealName";
            this.gcNextUserRealName.Visible = true;
            this.gcNextUserRealName.VisibleIndex = 5;
            // 
            // gcApproveResult
            // 
            this.gcApproveResult.Caption = "审批结果";
            this.gcApproveResult.FieldName = "InstanceStateWithEmptyState";
            this.gcApproveResult.Name = "gcApproveResult";
            this.gcApproveResult.Visible = true;
            this.gcApproveResult.VisibleIndex = 6;
            // 
            // gcCloseReason
            // 
            this.gcCloseReason.Caption = "结束原因";
            this.gcCloseReason.FieldName = "CloseReason";
            this.gcCloseReason.Name = "gcCloseReason";
            this.gcCloseReason.Visible = true;
            this.gcCloseReason.VisibleIndex = 7;
            // 
            // gcCloseDateTime
            // 
            this.gcCloseDateTime.Caption = "审批完成时间";
            this.gcCloseDateTime.ColumnEdit = this.repositoryItemDateEdit1;
            this.gcCloseDateTime.DisplayFormat.FormatString = "g";
            this.gcCloseDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCloseDateTime.FieldName = "CloseDateTime";
            this.gcCloseDateTime.Name = "gcCloseDateTime";
            this.gcCloseDateTime.Visible = true;
            this.gcCloseDateTime.VisibleIndex = 8;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.NullDate = new System.DateTime(((long)(0)));
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gcID
            // 
            this.gcID.Caption = "流程编号";
            this.gcID.FieldName = "ID";
            this.gcID.Name = "gcID";
            // 
            // frmMyFlowListQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 564);
            this.Controls.Add(this.gdFlow);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmMyFlowListQuery";
            this.Text = "我提交的流程";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gdFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFlow;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateItemID;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowVersionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUserRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsClosed;
        private DevExpress.XtraGrid.Columns.GridColumn gcApproveResult;
        private DevExpress.XtraGrid.Columns.GridColumn gcCloseDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateItemText;
        private DevExpress.XtraGrid.Columns.GridColumn gcNextUserRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCloseReason;
    }
}