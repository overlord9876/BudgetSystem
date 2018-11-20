namespace BudgetSystem.InMoney
{
    partial class frmInvoiceQuery
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
            this.gridInvoice = new DevExpress.XtraGrid.GridControl();
            this.gvInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImportUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridInvoice);
            this.splitContainerControl1.Size = new System.Drawing.Size(1147, 723);
            // 
            // panCondition
            // 
            this.panCondition.Controls.Add(this.layoutControl1);
            this.panCondition.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panCondition.Size = new System.Drawing.Size(285, 463);
            // 
            // gridInvoice
            // 
            this.gridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridInvoice.Location = new System.Drawing.Point(0, 0);
            this.gridInvoice.MainView = this.gvInvoice;
            this.gridInvoice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Size = new System.Drawing.Size(849, 723);
            this.gridInvoice.TabIndex = 1;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoice});
            // 
            // gvInvoice
            // 
            this.gvInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcContractNO,
            this.gcNumber,
            this.gcOriginalCoin,
            this.gcPayment,
            this.gcImportUserName,
            this.gcImportDate});
            this.gvInvoice.GridControl = this.gridInvoice;
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.OptionsView.ShowGroupPanel = false;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.OptionsColumn.AllowEdit = false;
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 0;
            // 
            // gcNumber
            // 
            this.gcNumber.Caption = "发票号";
            this.gcNumber.FieldName = "Number";
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 1;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "原币";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.OptionsColumn.AllowEdit = false;
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 2;
            // 
            // gcPayment
            // 
            this.gcPayment.Caption = "金额";
            this.gcPayment.FieldName = "Payment";
            this.gcPayment.Name = "gcPayment";
            this.gcPayment.OptionsColumn.AllowEdit = false;
            this.gcPayment.Visible = true;
            this.gcPayment.VisibleIndex = 3;
            // 
            // gcImportUserName
            // 
            this.gcImportUserName.Caption = "创建人";
            this.gcImportUserName.FieldName = "ImportUser";
            this.gcImportUserName.Name = "gcImportUserName";
            this.gcImportUserName.OptionsColumn.AllowEdit = false;
            this.gcImportUserName.Visible = true;
            this.gcImportUserName.VisibleIndex = 4;
            // 
            // gcImportDate
            // 
            this.gcImportDate.Caption = "创建时间";
            this.gcImportDate.FieldName = "ImportDate";
            this.gcImportDate.Name = "gcImportDate";
            this.gcImportDate.OptionsColumn.AllowEdit = false;
            this.gcImportDate.Visible = true;
            this.gcImportDate.VisibleIndex = 5;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dateEdit2);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.textEdit3);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(285, 463);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(90, 128);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(183, 25);
            this.dateEdit2.StyleController = this.layoutControl1;
            this.dateEdit2.TabIndex = 8;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(90, 99);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(183, 25);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 7;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(90, 70);
            this.textEdit3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(183, 25);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 6;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(90, 41);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(183, 25);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 5;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(90, 12);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(183, 25);
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
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(285, 463);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.CustomizationFormText = "预算单号：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(265, 29);
            this.layoutControlItem1.Text = "预算单号：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "付款凭证号：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 29);
            this.layoutControlItem2.Text = "凭证号：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            this.layoutControlItem3.CustomizationFormText = "发票号：";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(265, 29);
            this.layoutControlItem3.Text = "发票号：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateEdit1;
            this.layoutControlItem4.CustomizationFormText = "开票日期：";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 87);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(265, 29);
            this.layoutControlItem4.Text = "开票日期：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dateEdit2;
            this.layoutControlItem5.CustomizationFormText = "录入时间：";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(265, 327);
            this.layoutControlItem5.Text = "录入时间：";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(75, 18);
            // 
            // frmInvoiceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 723);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmInvoiceQuery";
            this.Text = "开票管理";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInvoice;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcPayment;
        private DevExpress.XtraGrid.Columns.GridColumn gcImportUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gcImportDate;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}