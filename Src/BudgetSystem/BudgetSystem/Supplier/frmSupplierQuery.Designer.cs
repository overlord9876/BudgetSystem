namespace BudgetSystem
{
    partial class frmSupplierQuery
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gcIsWarned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSupplier = new DevExpress.XtraGrid.GridControl();
            this.gvSupplier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaxpayerIdentificationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueSupplierType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsQualified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRegistrationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBusinessEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExistsAgentAgreement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgreementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueSupplierType)).BeginInit();
            this.SuspendLayout();
            // 
            // gcIsWarned
            // 
            this.gcIsWarned.Caption = "是否提醒";
            this.gcIsWarned.FieldName = "IsWarned";
            this.gcIsWarned.Name = "gcIsWarned";
            this.gcIsWarned.OptionsColumn.AllowMove = false;
            this.gcIsWarned.OptionsColumn.AllowShowHide = false;
            this.gcIsWarned.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridSupplier
            // 
            this.gridSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSupplier.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            gridLevelNode1.RelationName = "Level1";
            this.gridSupplier.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridSupplier.Location = new System.Drawing.Point(0, 0);
            this.gridSupplier.MainView = this.gvSupplier;
            this.gridSupplier.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridSupplier.Name = "gridSupplier";
            this.gridSupplier.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilueSupplierType});
            this.gridSupplier.Size = new System.Drawing.Size(1097, 672);
            this.gridSupplier.TabIndex = 2;
            this.gridSupplier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSupplier});
            // 
            // gvSupplier
            // 
            this.gvSupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcTaxpayerIdentificationNumber,
            this.gcSupplierType,
            this.gcFlowState,
            this.gcIsQualified,
            this.gcRegistrationDate,
            this.gcBusinessEffectiveDate,
            this.gcExistsAgentAgreement,
            this.gcAgreementDate,
            this.gcCreateDate,
            this.gcCreateUser,
            this.gcDescription,
            this.gcIsWarned});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gcIsWarned;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Expression = "True";
            styleFormatCondition1.Value1 = true;
            this.gvSupplier.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvSupplier.GridControl = this.gridSupplier;
            this.gvSupplier.Name = "gvSupplier";
            this.gvSupplier.OptionsBehavior.Editable = false;
            this.gvSupplier.OptionsView.ShowGroupPanel = false;
            // 
            // gcName
            // 
            this.gcName.Caption = "供应商名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // gcv纳税人识别号
            // 
            this.gcTaxpayerIdentificationNumber.Caption = "纳税人识别号";
            this.gcTaxpayerIdentificationNumber.FieldName = "TaxpayerID";
            this.gcTaxpayerIdentificationNumber.Name = "gcv纳税人识别号";
            this.gcTaxpayerIdentificationNumber.Visible = true;
            this.gcTaxpayerIdentificationNumber.VisibleIndex = 1;
            // 
            // gcSupplierType
            // 
            this.gcSupplierType.Caption = "供应商类型";
            this.gcSupplierType.ColumnEdit = this.rilueSupplierType;
            this.gcSupplierType.FieldName = "SupplierType";
            this.gcSupplierType.Name = "gcSupplierType";
            this.gcSupplierType.Visible = true;
            this.gcSupplierType.VisibleIndex = 2;
            // 
            // rilueSupplierType
            // 
            this.rilueSupplierType.AutoHeight = false;
            this.rilueSupplierType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rilueSupplierType.Name = "rilueSupplierType";
            // 
            // gcFlowState
            // 
            this.gcFlowState.Caption = "审批状态";
            this.gcFlowState.FieldName = "EnumFlowState";
            this.gcFlowState.Name = "gcFlowState";
            this.gcFlowState.Visible = true;
            this.gcFlowState.VisibleIndex = 3;
            // 
            // gcIsQualified
            // 
            this.gcIsQualified.Caption = "是否合格供应商";
            this.gcIsQualified.FieldName = "IsQualified";
            this.gcIsQualified.Name = "gcIsQualified";
            this.gcIsQualified.Visible = true;
            this.gcIsQualified.VisibleIndex = 4;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "创建时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 9;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "创建人";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 10;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 11;
            // 
            // gcRegistrationDate
            // 
            this.gcRegistrationDate.Caption = "工商登记日期";
            this.gcRegistrationDate.FieldName = "RegistrationDate";
            this.gcRegistrationDate.Name = "gcRegistrationDate";
            this.gcRegistrationDate.Visible = true;
            this.gcRegistrationDate.VisibleIndex = 5;
            // 
            // gcBusinessEffectiveDate
            // 
            this.gcBusinessEffectiveDate.Caption = "经营截至日期";
            this.gcBusinessEffectiveDate.FieldName = "BusinessEffectiveDate";
            this.gcBusinessEffectiveDate.Name = "gcBusinessEffectiveDate";
            this.gcBusinessEffectiveDate.Visible = true;
            this.gcBusinessEffectiveDate.VisibleIndex = 6;
            // 
            // gcExistsAgentAgreement
            // 
            this.gcExistsAgentAgreement.Caption = "存在合格供方代理协议";
            this.gcExistsAgentAgreement.FieldName = "ExistsAgentAgreement";
            this.gcExistsAgentAgreement.Name = "gcExistsAgentAgreement";
            this.gcExistsAgentAgreement.Visible = true;
            this.gcExistsAgentAgreement.VisibleIndex = 7;
            // 
            // gcAgreementDate
            // 
            this.gcAgreementDate.Caption = "代理协议有效期";
            this.gcAgreementDate.FieldName = "AgreementDate";
            this.gcAgreementDate.Name = "gcAgreementDate";
            this.gcAgreementDate.Visible = true;
            this.gcAgreementDate.VisibleIndex = 8;
            // 
            // frmSupplierQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 672);
            this.Controls.Add(this.gridSupplier);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "frmSupplierQuery";
            this.Text = "供应商管理";
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueSupplierType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridSupplier;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxpayerIdentificationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplierType;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilueSupplierType;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowState;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsQualified;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsWarned;
        private DevExpress.XtraGrid.Columns.GridColumn gcRegistrationDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcBusinessEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcExistsAgentAgreement;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgreementDate;


    }
}