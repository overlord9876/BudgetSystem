﻿namespace BudgetSystem
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
            this.gridSupplier = new DevExpress.XtraGrid.GridControl();
            this.gvSupplier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcv纳税人识别号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplierType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueSupplierType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueSupplierType)).BeginInit();
            this.SuspendLayout();
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
            this.gcv纳税人识别号,
            this.gcSupplierType,
            this.gcFlowState,
            this.gcCreateDate,
            this.gcCreateUser,
            this.gcDescription});
            this.gvSupplier.GridControl = this.gridSupplier;
            this.gvSupplier.Name = "gvSupplier";
            this.gvSupplier.OptionsBehavior.Editable = false;
            this.gvSupplier.OptionsView.ShowGroupPanel = false;
            this.gvSupplier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvSupplier_MouseDown);
            this.gvSupplier.DoubleClick += new System.EventHandler(this.gvSupplier_DoubleClick);
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
            this.gcv纳税人识别号.Caption = "纳税人识别号";
            this.gcv纳税人识别号.FieldName = "TaxpayerID";
            this.gcv纳税人识别号.Name = "gcv纳税人识别号";
            this.gcv纳税人识别号.Visible = true;
            this.gcv纳税人识别号.VisibleIndex = 1;
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
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "创建时间";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 4;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "创建人";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 5;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 6;
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
        private DevExpress.XtraGrid.Columns.GridColumn gcv纳税人识别号;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplierType;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilueSupplierType;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlowState;


    }
}