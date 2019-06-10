namespace BudgetSystem
{
    partial class frmSupplierReviewHistory
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
            this.gridSupplier = new DevExpress.XtraGrid.GridControl();
            this.gvSupplier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRegistrationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBusinessEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgreementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcResultDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPassedBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejectedBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRectificationBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRectificationPassedBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRectificationResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDiscredited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSalesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartmentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLeader = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSupplier
            // 
            this.gridSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSupplier.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSupplier.Location = new System.Drawing.Point(0, 0);
            this.gridSupplier.MainView = this.gvSupplier;
            this.gridSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSupplier.Name = "gridSupplier";
            this.gridSupplier.Size = new System.Drawing.Size(1095, 653);
            this.gridSupplier.TabIndex = 3;
            this.gridSupplier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSupplier});
            // 
            // gvSupplier
            // 
            this.gvSupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRegistrationDate,
            this.gcBusinessEffectiveDate,
            this.gcAgreementDate,
            this.gcResultDate,
            this.gcTotalBatch,
            this.gcPassedBatch,
            this.gcRejectedBatch,
            this.gcRectificationBatch,
            this.gcRectificationPassedBatch,
            this.gcRectificationResult,
            this.gcDiscredited,
            this.gcSalesman,
            this.gcDepartmentDesc,
            this.gcManager,
            this.gcSignDate,
            this.gcLeader});
            this.gvSupplier.GridControl = this.gridSupplier;
            this.gvSupplier.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvSupplier.Name = "gvSupplier";
            this.gvSupplier.OptionsBehavior.Editable = false;
            this.gvSupplier.OptionsCustomization.AllowSort = false;
            this.gvSupplier.OptionsDetail.SmartDetailExpand = false;
            this.gvSupplier.OptionsView.ShowGroupPanel = false;
            // 
            // gcRegistrationDate
            // 
            this.gcRegistrationDate.Caption = "工商登记日期";
            this.gcRegistrationDate.FieldName = "RegistrationDate";
            this.gcRegistrationDate.Name = "gcRegistrationDate";
            this.gcRegistrationDate.Visible = true;
            this.gcRegistrationDate.VisibleIndex = 0;
            this.gcRegistrationDate.Width = 85;
            // 
            // gcBusinessEffectiveDate
            // 
            this.gcBusinessEffectiveDate.Caption = "截止经营日期";
            this.gcBusinessEffectiveDate.FieldName = "BusinessEffectiveDate";
            this.gcBusinessEffectiveDate.Name = "gcBusinessEffectiveDate";
            this.gcBusinessEffectiveDate.Visible = true;
            this.gcBusinessEffectiveDate.VisibleIndex = 1;
            this.gcBusinessEffectiveDate.Width = 115;
            // 
            // gcAgreementDate
            // 
            this.gcAgreementDate.Caption = "代理有效期";
            this.gcAgreementDate.FieldName = "AgreementDate";
            this.gcAgreementDate.Name = "gcAgreementDate";
            this.gcAgreementDate.Visible = true;
            this.gcAgreementDate.VisibleIndex = 2;
            this.gcAgreementDate.Width = 73;
            // 
            // gcResultDate
            // 
            this.gcResultDate.Caption = "复评结论日期";
            this.gcResultDate.FieldName = "ResultDate";
            this.gcResultDate.Name = "gcResultDate";
            this.gcResultDate.Visible = true;
            this.gcResultDate.VisibleIndex = 3;
            this.gcResultDate.Width = 70;
            // 
            // gcTotalBatch
            // 
            this.gcTotalBatch.Caption = "总批次";
            this.gcTotalBatch.FieldName = "TotalBatch";
            this.gcTotalBatch.Name = "gcTotalBatch";
            this.gcTotalBatch.Visible = true;
            this.gcTotalBatch.VisibleIndex = 4;
            this.gcTotalBatch.Width = 74;
            // 
            // gcPassedBatch
            // 
            this.gcPassedBatch.Caption = "合格批次";
            this.gcPassedBatch.FieldName = "PassedBatch";
            this.gcPassedBatch.Name = "gcPassedBatch";
            this.gcPassedBatch.Visible = true;
            this.gcPassedBatch.VisibleIndex = 5;
            this.gcPassedBatch.Width = 82;
            // 
            // gcRejectedBatch
            // 
            this.gcRejectedBatch.Caption = "不合格批次";
            this.gcRejectedBatch.FieldName = "RejectedBatch";
            this.gcRejectedBatch.Name = "gcRejectedBatch";
            this.gcRejectedBatch.Visible = true;
            this.gcRejectedBatch.VisibleIndex = 6;
            this.gcRejectedBatch.Width = 79;
            // 
            // gcRectificationBatch
            // 
            this.gcRectificationBatch.Caption = "整改批次";
            this.gcRectificationBatch.FieldName = "RectificationBatch";
            this.gcRectificationBatch.Name = "gcRectificationBatch";
            this.gcRectificationBatch.Visible = true;
            this.gcRectificationBatch.VisibleIndex = 7;
            this.gcRectificationBatch.Width = 78;
            // 
            // gcRectificationPassedBatch
            // 
            this.gcRectificationPassedBatch.Caption = "整改合格批次";
            this.gcRectificationPassedBatch.FieldName = "RectificationPassedBatch";
            this.gcRectificationPassedBatch.Name = "gcRectificationPassedBatch";
            this.gcRectificationPassedBatch.Visible = true;
            this.gcRectificationPassedBatch.VisibleIndex = 8;
            this.gcRectificationPassedBatch.Width = 62;
            // 
            // gcRectificationResult
            // 
            this.gcRectificationResult.Caption = "整改结果";
            this.gcRectificationResult.FieldName = "RectificationResult";
            this.gcRectificationResult.Name = "gcRectificationResult";
            this.gcRectificationResult.Visible = true;
            this.gcRectificationResult.VisibleIndex = 9;
            this.gcRectificationResult.Width = 108;
            // 
            // gcDiscredited
            // 
            this.gcDiscredited.Caption = "失信企业";
            this.gcDiscredited.FieldName = "Discredited";
            this.gcDiscredited.Name = "gcDiscredited";
            this.gcDiscredited.Visible = true;
            this.gcDiscredited.VisibleIndex = 10;
            this.gcDiscredited.Width = 44;
            // 
            // gcSalesman
            // 
            this.gcSalesman.Caption = "业务员";
            this.gcSalesman.FieldName = "Salesman";
            this.gcSalesman.Name = "gcSalesman";
            this.gcSalesman.Visible = true;
            this.gcSalesman.VisibleIndex = 11;
            this.gcSalesman.Width = 34;
            // 
            // gcDepartmentDesc
            // 
            this.gcDepartmentDesc.Caption = "业务员所在部门";
            this.gcDepartmentDesc.FieldName = "DepartmentDesc";
            this.gcDepartmentDesc.Name = "gcDepartmentDesc";
            this.gcDepartmentDesc.Visible = true;
            this.gcDepartmentDesc.VisibleIndex = 12;
            this.gcDepartmentDesc.Width = 44;
            // 
            // gcManager
            // 
            this.gcManager.Caption = "部门经理";
            this.gcManager.FieldName = "Manager";
            this.gcManager.Name = "gcManager";
            this.gcManager.Visible = true;
            this.gcManager.VisibleIndex = 15;
            this.gcManager.Width = 72;
            // 
            // gcSignDate
            // 
            this.gcSignDate.Caption = "订约日期";
            this.gcSignDate.FieldName = "SignDate";
            this.gcSignDate.Name = "gcSignDate";
            this.gcSignDate.Visible = true;
            this.gcSignDate.VisibleIndex = 13;
            this.gcSignDate.Width = 31;
            // 
            // gcLeader
            // 
            this.gcLeader.Caption = "评审组长";
            this.gcLeader.FieldName = "Leader";
            this.gcLeader.Name = "gcLeader";
            this.gcLeader.Visible = true;
            this.gcLeader.VisibleIndex = 14;
            this.gcLeader.Width = 26;
            // 
            // frmSupplierReviewHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 653);
            this.Controls.Add(this.gridSupplier);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmSupplierReviewHistory";
            this.Text = "供应商复审记录";
            this.Load += new System.EventHandler(this.frmSupplierReviewHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridSupplier;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gcRegistrationDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcBusinessEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgreementDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcResultDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gcPassedBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejectedBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gcRectificationBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gcRectificationPassedBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gcRectificationResult;
        private DevExpress.XtraGrid.Columns.GridColumn gcDiscredited;
        private DevExpress.XtraGrid.Columns.GridColumn gcSalesman;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartmentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcManager;
        private DevExpress.XtraGrid.Columns.GridColumn gcSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcLeader;

    }
}