namespace BudgetSystem.WorkSpace
{
    partial class frmApprovalListQuery
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
            this.gdPendingFlow = new DevExpress.XtraGrid.GridControl();
            this.gvPendingFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDateItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowVersionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUserRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gdPendingFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendingFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gdPendingFlow
            // 
            this.gdPendingFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdPendingFlow.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gdPendingFlow.Location = new System.Drawing.Point(0, 0);
            this.gdPendingFlow.MainView = this.gvPendingFlow;
            this.gdPendingFlow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gdPendingFlow.Name = "gdPendingFlow";
            this.gdPendingFlow.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gdPendingFlow.Size = new System.Drawing.Size(1006, 564);
            this.gdPendingFlow.TabIndex = 1;
            this.gdPendingFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPendingFlow});
            // 
            // gvPendingFlow
            // 
            this.gvPendingFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDateItemID,
            this.gcDateText,
            this.gcFlowName,
            this.gcFlowVersionNumber,
            this.gcCreateDate,
            this.gcCreateUserRealName,
            this.gcSate,
            this.gcID});
            this.gvPendingFlow.GridControl = this.gdPendingFlow;
            this.gvPendingFlow.GroupCount = 1;
            this.gvPendingFlow.Name = "gvPendingFlow";
            this.gvPendingFlow.OptionsBehavior.Editable = false;
            this.gvPendingFlow.OptionsSelection.MultiSelect = true;
            this.gvPendingFlow.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcFlowName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcDateItemID
            // 
            this.gcDateItemID.Caption = "待审核项编号";
            this.gcDateItemID.FieldName = "DateItemID";
            this.gcDateItemID.Name = "gcDateItemID";
            // 
            // gcDateText
            // 
            this.gcDateText.Caption = "待审批项";
            this.gcDateText.FieldName = "DateItemText";
            this.gcDateText.Name = "gcDateText";
            this.gcDateText.Visible = true;
            this.gcDateText.VisibleIndex = 0;
            this.gcDateText.Width = 215;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "审批流程";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.Name = "gcFlowName";
            // 
            // gcFlowVersionNumber
            // 
            this.gcFlowVersionNumber.Caption = "流程版本号";
            this.gcFlowVersionNumber.FieldName = "FlowVersionNumber";
            this.gcFlowVersionNumber.Name = "gcFlowVersionNumber";
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "流程发起时间";
            this.gcCreateDate.DisplayFormat.FormatString = "g";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 1;
            this.gcCreateDate.Width = 120;
            // 
            // gcCreateUserRealName
            // 
            this.gcCreateUserRealName.Caption = "流程发起人";
            this.gcCreateUserRealName.FieldName = "CreateUserRealName";
            this.gcCreateUserRealName.Name = "gcCreateUserRealName";
            this.gcCreateUserRealName.Visible = true;
            this.gcCreateUserRealName.VisibleIndex = 2;
            this.gcCreateUserRealName.Width = 262;
            // 
            // gcSate
            // 
            this.gcSate.Caption = "审批状态";
            this.gcSate.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gcSate.FieldName = "IsClosed";
            this.gcSate.Name = "gcSate";
            this.gcSate.Visible = true;
            this.gcSate.VisibleIndex = 3;
            this.gcSate.Width = 265;
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
            // gcID
            // 
            this.gcID.Caption = "流程编号";
            this.gcID.FieldName = "ID";
            this.gcID.Name = "gcID";
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
            // frmApprovalListQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 564);
            this.Controls.Add(this.gdPendingFlow);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmApprovalListQuery";
            this.Text = "待审流程";
            ((System.ComponentModel.ISupportInitialize)(this.gdPendingFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendingFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdPendingFlow;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateItemID;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowVersionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUserRealName;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPendingFlow;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateText;
        private DevExpress.XtraGrid.Columns.GridColumn gcSate;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    }
}