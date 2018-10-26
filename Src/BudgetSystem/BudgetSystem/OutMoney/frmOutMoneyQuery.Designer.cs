namespace BudgetSystem
{
    partial class frmOutMoneyQuery
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
            this.gcOutMoney = new DevExpress.XtraGrid.GridControl();
            this.gvOutMoney = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBudgetNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApplicant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommitTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApprover = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApproveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOverdue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneyUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsDrawback = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHasInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.splitContainerControl1.Panel2.Controls.Add(this.gcOutMoney);
            this.splitContainerControl1.Size = new System.Drawing.Size(1008, 729);
            // 
            // panCondition
            // 
            this.panCondition.Controls.Add(this.layoutControl1);
            this.panCondition.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.panCondition.Size = new System.Drawing.Size(285, 463);
            // 
            // gcOutMoney
            // 
            this.gcOutMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOutMoney.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.gcOutMoney.Location = new System.Drawing.Point(0, 0);
            this.gcOutMoney.MainView = this.gvOutMoney;
            this.gcOutMoney.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.gcOutMoney.Name = "gcOutMoney";
            this.gcOutMoney.Size = new System.Drawing.Size(710, 729);
            this.gcOutMoney.TabIndex = 1;
            this.gcOutMoney.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutMoney});
            // 
            // gvOutMoney
            // 
            this.gvOutMoney.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSupplier,
            this.gcBudgetNO,
            this.gcMoney,
            this.gcApplicant,
            this.gcCommitTime,
            this.gcApprover,
            this.gcApproveTime,
            this.gcPaymentDate,
            this.gcOverdue,
            this.gcDescription,
            this.gcDepartmentCode,
            this.gcMoneyUsed,
            this.gcIsDrawback,
            this.gcHasInvoice,
            this.gcPaymentMethod});
            this.gvOutMoney.GridControl = this.gcOutMoney;
            this.gvOutMoney.Name = "gvOutMoney";
            this.gvOutMoney.OptionsView.ShowGroupPanel = false;
            // 
            // gcSupplier
            // 
            this.gcSupplier.Caption = "供应商";
            this.gcSupplier.FieldName = "SupplierName";
            this.gcSupplier.Name = "gcSupplier";
            this.gcSupplier.Visible = true;
            this.gcSupplier.VisibleIndex = 0;
            // 
            // gcBudgetNO
            // 
            this.gcBudgetNO.Caption = "合同号";
            this.gcBudgetNO.FieldName = "ContractNO";
            this.gcBudgetNO.Name = "gcBudgetNO";
            this.gcBudgetNO.Visible = true;
            this.gcBudgetNO.VisibleIndex = 1;
            // 
            // gcMoney
            // 
            this.gcMoney.Caption = "付款金额";
            this.gcMoney.FieldName = "Money";
            this.gcMoney.Name = "gcMoney";
            this.gcMoney.Visible = true;
            this.gcMoney.VisibleIndex = 2;
            // 
            // gcApplicant
            // 
            this.gcApplicant.Caption = "付款申请人";
            this.gcApplicant.FieldName = "Applicant";
            this.gcApplicant.Name = "gcApplicant";
            this.gcApplicant.Visible = true;
            this.gcApplicant.VisibleIndex = 3;
            // 
            // gcCommitTime
            // 
            this.gcCommitTime.Caption = "提交时间";
            this.gcCommitTime.FieldName = "CommitTime";
            this.gcCommitTime.Name = "gcCommitTime";
            this.gcCommitTime.Visible = true;
            this.gcCommitTime.VisibleIndex = 4;
            // 
            // gcApprover
            // 
            this.gcApprover.Caption = "财务确认人";
            this.gcApprover.FieldName = "Approver";
            this.gcApprover.Name = "gcApprover";
            this.gcApprover.Visible = true;
            this.gcApprover.VisibleIndex = 5;
            // 
            // gcApproveTime
            // 
            this.gcApproveTime.Caption = "确认时间";
            this.gcApproveTime.FieldName = "ApproveTime";
            this.gcApproveTime.Name = "gcApproveTime";
            this.gcApproveTime.Visible = true;
            this.gcApproveTime.VisibleIndex = 6;
            // 
            // gcPaymentDate
            // 
            this.gcPaymentDate.Caption = "付款日期";
            this.gcPaymentDate.FieldName = "PaymentDate";
            this.gcPaymentDate.Name = "gcPaymentDate";
            // 
            // gcOverdue
            // 
            this.gcOverdue.Caption = "付款超期";
            this.gcOverdue.FieldName = "Overdue";
            this.gcOverdue.Name = "gcOverdue";
            this.gcOverdue.Visible = true;
            this.gcOverdue.VisibleIndex = 7;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            // 
            // gcDepartmentCode
            // 
            this.gcDepartmentCode.Caption = "所属部门";
            this.gcDepartmentCode.FieldName = "DepartmentName";
            this.gcDepartmentCode.Name = "gcDepartmentCode";
            this.gcDepartmentCode.Visible = true;
            this.gcDepartmentCode.VisibleIndex = 8;
            // 
            // gcMoneyUsed
            // 
            this.gcMoneyUsed.Caption = "用途";
            this.gcMoneyUsed.FieldName = "MoneyUsed";
            this.gcMoneyUsed.Name = "gcMoneyUsed";
            this.gcMoneyUsed.Visible = true;
            this.gcMoneyUsed.VisibleIndex = 9;
            // 
            // gcIsDrawback
            // 
            this.gcIsDrawback.Caption = "是否退税";
            this.gcIsDrawback.FieldName = "IsDrawback";
            this.gcIsDrawback.Name = "gcIsDrawback";
            // 
            // gcHasInvoice
            // 
            this.gcHasInvoice.Caption = "是否收到发票";
            this.gcHasInvoice.FieldName = "HasInvoice";
            this.gcHasInvoice.Name = "gcHasInvoice";
            // 
            // gcPaymentMethod
            // 
            this.gcPaymentMethod.Caption = "付款方式";
            this.gcPaymentMethod.FieldName = "PaymentMethod";
            this.gcPaymentMethod.Name = "gcPaymentMethod";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEdit3);
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
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(87, 62);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(186, 21);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 6;
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
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(285, 463);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.CustomizationFormText = "供应商：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(265, 25);
            this.layoutControlItem1.Text = "供应商：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "付款申请人：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 25);
            this.layoutControlItem2.Text = "付款申请人：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            this.layoutControlItem3.CustomizationFormText = "财务确认人：";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(265, 393);
            this.layoutControlItem3.Text = "财务确认人：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // frmOutMoneyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.Name = "frmOutMoneyQuery";
            this.Text = "付款管理";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOutMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcOutMoney;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcApplicant;
        private DevExpress.XtraGrid.Columns.GridColumn gcApprover;
        private DevExpress.XtraGrid.Columns.GridColumn gcApproveTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gcCommitTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcBudgetNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcOverdue;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneyUsed;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsDrawback;
        private DevExpress.XtraGrid.Columns.GridColumn gcHasInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentMethod;
    }
}