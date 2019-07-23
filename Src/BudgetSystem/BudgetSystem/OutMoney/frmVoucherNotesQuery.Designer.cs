namespace BudgetSystem
{
    partial class frmVoucherNotesQuery
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
            this.gcDeclarationform = new DevExpress.XtraGrid.GridControl();
            this.gvDeclarationform = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDeclarationform
            // 
            this.gcDeclarationform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDeclarationform.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeclarationform.Location = new System.Drawing.Point(0, 0);
            this.gcDeclarationform.MainView = this.gvDeclarationform;
            this.gcDeclarationform.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeclarationform.Name = "gcDeclarationform";
            this.gcDeclarationform.Size = new System.Drawing.Size(1147, 723);
            this.gcDeclarationform.TabIndex = 1;
            this.gcDeclarationform.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeclarationform});
            // 
            // gvDeclarationform
            // 
            this.gvDeclarationform.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn6});
            this.gvDeclarationform.GridControl = this.gcDeclarationform;
            this.gvDeclarationform.Name = "gvDeclarationform";
            this.gvDeclarationform.OptionsBehavior.Editable = false;
            this.gvDeclarationform.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "合同号";
            this.gridColumn3.FieldName = "ContractNO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "报关单号";
            this.gridColumn1.FieldName = "NO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "报关币种";
            this.gridColumn4.FieldName = "Currency";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "出口金额";
            this.gridColumn5.FieldName = "ExportAmount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "汇率";
            this.gridColumn10.FieldName = "ExchangeRate";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "出口日期";
            this.gridColumn7.FieldName = "ExportDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "合同号";
            this.gridColumn8.FieldName = "ContractNO";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "录入人";
            this.gridColumn2.FieldName = "CreateUserRealName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "录入时间";
            this.gridColumn6.DisplayFormat.FormatString = "g";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "CreateDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 120;
            // 
            // frmVoucherNotesQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 723);
            this.Controls.Add(this.gcDeclarationform);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmVoucherNotesQuery";
            this.Text = "报关单管理";
            ((System.ComponentModel.ISupportInitialize)(this.gcDeclarationform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeclarationform)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDeclarationform;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDeclarationform;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}