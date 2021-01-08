namespace BudgetSystem
{
    partial class frmAccountAdjustmentQuery
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
            this.gridAccountAdjustment = new DevExpress.XtraGrid.GridControl();
            this.gvAccountAdjustment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnumRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSplitCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAlreadySplitCNYMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateRealUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountAdjustment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountAdjustment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAccountAdjustment
            // 
            this.gridAccountAdjustment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccountAdjustment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridAccountAdjustment.Location = new System.Drawing.Point(0, 0);
            this.gridAccountAdjustment.MainView = this.gvAccountAdjustment;
            this.gridAccountAdjustment.Margin = new System.Windows.Forms.Padding(2);
            this.gridAccountAdjustment.Name = "gridAccountAdjustment";
            this.gridAccountAdjustment.Size = new System.Drawing.Size(1236, 495);
            this.gridAccountAdjustment.TabIndex = 1;
            this.gridAccountAdjustment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccountAdjustment});
            // 
            // gvAccountAdjustment
            // 
            this.gvAccountAdjustment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcType,
            this.gcContractNO,
            this.gcName,
            this.gcEnumRole,
            this.gcFlowName,
            this.gcFlowState,
            this.gcVoucherNo,
            this.gcCNY,
            this.gcSplitCNY,
            this.gcAlreadySplitCNYMoney,
            this.gcCreateUser,
            this.gcCreateRealUserName,
            this.gcCreateDate,
            this.gcRemark});
            this.gvAccountAdjustment.GridControl = this.gridAccountAdjustment;
            this.gvAccountAdjustment.Name = "gvAccountAdjustment";
            this.gvAccountAdjustment.OptionsBehavior.Editable = false;
            this.gvAccountAdjustment.OptionsView.ShowDetailButtons = false;
            this.gvAccountAdjustment.OptionsView.ShowGroupPanel = false;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "编号";
            this.gcCode.FieldName = "Code";
            this.gcCode.Name = "gcCode";
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 0;
            // 
            // gcType
            // 
            this.gcType.Caption = "调账类型";
            this.gcType.FieldName = "Type";
            this.gcType.Name = "gcType";
            this.gcType.Visible = true;
            this.gcType.VisibleIndex = 1;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "关联合同";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 2;
            // 
            // gcName
            // 
            this.gcName.Caption = "关联客户/供应商";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 3;
            // 
            // gcEnumRole
            // 
            this.gcEnumRole.Caption = "调账类别";
            this.gcEnumRole.FieldName = "EnumRole";
            this.gcEnumRole.Name = "gcEnumRole";
            this.gcEnumRole.Visible = true;
            this.gcEnumRole.VisibleIndex = 4;
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "流程名称";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 5;
            // 
            // gcFlowState
            // 
            this.gcFlowState.Caption = "流程状态";
            this.gcFlowState.FieldName = "EnumFlowState";
            this.gcFlowState.Name = "gcFlowState";
            this.gcFlowState.Visible = true;
            this.gcFlowState.VisibleIndex = 6;
            // 
            // gcVoucherNo
            // 
            this.gcVoucherNo.Caption = "单号";
            this.gcVoucherNo.FieldName = "VoucherNo";
            this.gcVoucherNo.Name = "gcVoucherNo";
            this.gcVoucherNo.Visible = true;
            this.gcVoucherNo.VisibleIndex = 7;
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "金额";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 8;
            // 
            // gcSplitCNY
            // 
            this.gcSplitCNY.Caption = "调账原币金额";
            this.gcSplitCNY.FieldName = "AlreadySplitOriginalCoin";
            this.gcSplitCNY.Name = "gcSplitCNY";
            this.gcSplitCNY.Visible = true;
            this.gcSplitCNY.VisibleIndex = 9;
            // 
            // gcAlreadySplitCNYMoney
            // 
            this.gcAlreadySplitCNYMoney.Caption = "已调账人民币金额";
            this.gcAlreadySplitCNYMoney.FieldName = "AlreadySplitCNY";
            this.gcAlreadySplitCNYMoney.Name = "gcAlreadySplitCNYMoney";
            this.gcAlreadySplitCNYMoney.Visible = true;
            this.gcAlreadySplitCNYMoney.VisibleIndex = 10;
            // 
            // gcCreateRealUserName
            // 
            this.gcCreateRealUserName.Caption = "创建人姓名";
            this.gcCreateRealUserName.FieldName = "CreateRealUserName";
            this.gcCreateRealUserName.Name = "gcCreateRealUserName";
            this.gcCreateRealUserName.Visible = true;
            this.gcCreateRealUserName.VisibleIndex = 12;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "创建时间";
            this.gcCreateDate.DisplayFormat.FormatString = "g";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 13;
            // 
            // gcRemark
            // 
            this.gcRemark.Caption = "备注";
            this.gcRemark.FieldName = "Remark";
            this.gcRemark.Name = "gcRemark";
            this.gcRemark.Visible = true;
            this.gcRemark.VisibleIndex = 14;
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
            this.textEdit2.Location = new System.Drawing.Point(87, 37);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(186, 21);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 5;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(87, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(186, 21);
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
            this.layoutControlItem1.Size = new System.Drawing.Size(265, 25);
            this.layoutControlItem1.Text = "客户名称：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "国家或地区：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 418);
            this.layoutControlItem2.Text = "国家或地区：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "创建人";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 11;
            // 
            // frmAccountAdjustmentQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 495);
            this.Controls.Add(this.gridAccountAdjustment);
            this.Name = "frmAccountAdjustmentQuery";
            this.Text = "调账管理";
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountAdjustment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountAdjustment)).EndInit();
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

        private DevExpress.XtraGrid.GridControl gridAccountAdjustment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccountAdjustment;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateRealUserName;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcType;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
        private DevExpress.XtraGrid.Columns.GridColumn gcSplitCNY;
        private DevExpress.XtraGrid.Columns.GridColumn gcAlreadySplitCNYMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowState;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnumRole;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
    }
}