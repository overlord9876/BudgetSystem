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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gcIsWarned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsExpires = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSupplier = new DevExpress.XtraGrid.GridControl();
            this.gvSupplier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcv纳税人识别号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueSupplierType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcFlowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsQualified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRegistrationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBusinessEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReviewDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgreementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDiscredited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
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
            // gcIsExpires
            // 
            this.gcIsExpires.Caption = "审批信息是否已过期";
            this.gcIsExpires.FieldName = "IsExpires";
            this.gcIsExpires.Name = "gcIsExpires";
            // 
            // gridSupplier
            // 
            this.gridSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSupplier.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridSupplier.Location = new System.Drawing.Point(0, 0);
            this.gridSupplier.MainView = this.gvSupplier;
            this.gridSupplier.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridSupplier.Name = "gridSupplier";
            this.gridSupplier.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilueSupplierType});
            this.gridSupplier.Size = new System.Drawing.Size(1353, 672);
            this.gridSupplier.TabIndex = 2;
            this.gridSupplier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSupplier});
            // 
            // gvSupplier
            // 
            this.gvSupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcv纳税人识别号,
            this.gcSupplierType,
            this.gcFlowName,
            this.gcFlowState,
            this.gcIsQualified,
            this.gcRegistrationDate,
            this.gcBusinessEffectiveDate,
            this.gcReviewDate,
            this.gcAgentType,
            this.gcAgreementDate,
            this.gcDiscredited,
            this.gcCreateDate,
            this.gcCreateUser,
            this.gcDescription,
            this.gcIsWarned,
            this.gcIsExpires});
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
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.gcIsExpires;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Expression = "True";
            styleFormatCondition2.Value1 = true;
            this.gvSupplier.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gvSupplier.GridControl = this.gridSupplier;
            this.gvSupplier.Name = "gvSupplier";
            this.gvSupplier.OptionsBehavior.Editable = false;
            this.gvSupplier.OptionsView.ColumnAutoWidth = false;
            this.gvSupplier.OptionsView.ShowGroupPanel = false;
            this.gvSupplier.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCreateDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gcName
            // 
            this.gcName.Caption = "供应商名称";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            this.gcName.Width = 183;
            // 
            // gcv纳税人识别号
            // 
            this.gcv纳税人识别号.Caption = "纳税人识别号";
            this.gcv纳税人识别号.FieldName = "TaxpayerID";
            this.gcv纳税人识别号.Name = "gcv纳税人识别号";
            this.gcv纳税人识别号.Visible = true;
            this.gcv纳税人识别号.VisibleIndex = 1;
            this.gcv纳税人识别号.Width = 159;
            // 
            // gcSupplierType
            // 
            this.gcSupplierType.Caption = "供应商类型";
            this.gcSupplierType.ColumnEdit = this.rilueSupplierType;
            this.gcSupplierType.FieldName = "SupplierType";
            this.gcSupplierType.Name = "gcSupplierType";
            this.gcSupplierType.Visible = true;
            this.gcSupplierType.VisibleIndex = 2;
            this.gcSupplierType.Width = 92;
            // 
            // rilueSupplierType
            // 
            this.rilueSupplierType.AutoHeight = false;
            this.rilueSupplierType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rilueSupplierType.Name = "rilueSupplierType";
            // 
            // gcFlowName
            // 
            this.gcFlowName.Caption = "当前流程";
            this.gcFlowName.FieldName = "FlowName";
            this.gcFlowName.Name = "gcFlowName";
            this.gcFlowName.Visible = true;
            this.gcFlowName.VisibleIndex = 3;
            this.gcFlowName.Width = 120;
            // 
            // gcFlowState
            // 
            this.gcFlowState.Caption = "审批状态";
            this.gcFlowState.FieldName = "EnumFlowState";
            this.gcFlowState.Name = "gcFlowState";
            this.gcFlowState.Visible = true;
            this.gcFlowState.VisibleIndex = 4;
            this.gcFlowState.Width = 87;
            // 
            // gcIsQualified
            // 
            this.gcIsQualified.Caption = "是否合格供应商";
            this.gcIsQualified.FieldName = "IsQualified";
            this.gcIsQualified.Name = "gcIsQualified";
            this.gcIsQualified.Visible = true;
            this.gcIsQualified.VisibleIndex = 5;
            this.gcIsQualified.Width = 114;
            // 
            // gcRegistrationDate
            // 
            this.gcRegistrationDate.Caption = "工商登记日期";
            this.gcRegistrationDate.FieldName = "RegistrationDate";
            this.gcRegistrationDate.Name = "gcRegistrationDate";
            this.gcRegistrationDate.Visible = true;
            this.gcRegistrationDate.VisibleIndex = 6;
            this.gcRegistrationDate.Width = 106;
            // 
            // gcBusinessEffectiveDate
            // 
            this.gcBusinessEffectiveDate.Caption = "经营截至日期";
            this.gcBusinessEffectiveDate.FieldName = "BusinessEffectiveDate";
            this.gcBusinessEffectiveDate.Name = "gcBusinessEffectiveDate";
            this.gcBusinessEffectiveDate.Visible = true;
            this.gcBusinessEffectiveDate.VisibleIndex = 7;
            this.gcBusinessEffectiveDate.Width = 101;
            // 
            // gcReviewDate
            // 
            this.gcReviewDate.Caption = "年审日期";
            this.gcReviewDate.FieldName = "ReviewDate";
            this.gcReviewDate.Name = "gcReviewDate";
            this.gcReviewDate.Visible = true;
            this.gcReviewDate.VisibleIndex = 8;
            this.gcReviewDate.Width = 85;
            // 
            // gcAgentType
            // 
            this.gcAgentType.Caption = "代理类型";
            this.gcAgentType.FieldName = "EnumAgentType";
            this.gcAgentType.Name = "gcAgentType";
            this.gcAgentType.Visible = true;
            this.gcAgentType.VisibleIndex = 9;
            this.gcAgentType.Width = 76;
            // 
            // gcAgreementDate
            // 
            this.gcAgreementDate.Caption = "代理协议有效期";
            this.gcAgreementDate.FieldName = "AgreementDate";
            this.gcAgreementDate.Name = "gcAgreementDate";
            this.gcAgreementDate.Visible = true;
            this.gcAgreementDate.VisibleIndex = 10;
            this.gcAgreementDate.Width = 109;
            // 
            // gcDiscredited
            // 
            this.gcDiscredited.Caption = "是否失信企业";
            this.gcDiscredited.FieldName = "Discredited";
            this.gcDiscredited.Name = "gcDiscredited";
            this.gcDiscredited.Visible = true;
            this.gcDiscredited.VisibleIndex = 11;
            this.gcDiscredited.Width = 107;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "创建时间";
            this.gcCreateDate.DisplayFormat.FormatString = "g";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 12;
            this.gcCreateDate.Width = 80;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "创建人";
            this.gcCreateUser.FieldName = "CreateUserName";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 13;
            this.gcCreateUser.Width = 80;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 14;
            this.gcDescription.Width = 80;
            // 
            // frmSupplierQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 672);
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
        private DevExpress.XtraGrid.Columns.GridColumn gcAgentType;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgreementDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaxpayerIdentificationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcDiscredited;
        private DevExpress.XtraGrid.Columns.GridColumn gcv纳税人识别号;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowName;
        private DevExpress.XtraGrid.Columns.GridColumn gcReviewDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsExpires;


    }
}