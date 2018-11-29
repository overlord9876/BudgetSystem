namespace BudgetSystem.InMoney
{
    partial class frmInMoneyQuery
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
            this.gcInMoney = new DevExpress.XtraGrid.GridControl();
            this.gvInMoney = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemitter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnumFlowState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTradingPostscript = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcInMoney);
            this.splitContainerControl1.Size = new System.Drawing.Size(976, 597);
            // 
            // panCondition
            // 
            this.panCondition.Controls.Add(this.layoutControl1);
            this.panCondition.Size = new System.Drawing.Size(285, 463);
            // 
            // gcInMoney
            // 
            this.gcInMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInMoney.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcInMoney.Location = new System.Drawing.Point(0, 0);
            this.gcInMoney.MainView = this.gvInMoney;
            this.gcInMoney.Margin = new System.Windows.Forms.Padding(2);
            this.gcInMoney.Name = "gcInMoney";
            this.gcInMoney.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gcInMoney.Size = new System.Drawing.Size(678, 597);
            this.gcInMoney.TabIndex = 1;
            this.gcInMoney.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInMoney});
            // 
            // gvInMoney
            // 
            this.gvInMoney.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcVoucherNo,
            this.gcBankName,
            this.gcRemitter,
            this.gcCurrency,
            this.gcEnumFlowState,
            this.gcOriginalCoin,
            this.gcExchangeRate,
            this.gcCNY,
            this.gcTradingPostscript,
            this.gcExportName,
            this.gcPaymentMethod,
            this.gcReceiptDate,
            this.gcCreateUser,
            this.gcState,
            this.gcCreateTimestamp,
            this.gcDescription});
            this.gvInMoney.GridControl = this.gcInMoney;
            this.gvInMoney.Name = "gvInMoney";
            this.gvInMoney.OptionsBehavior.Editable = false;
            this.gvInMoney.OptionsView.ShowDetailButtons = false;
            this.gvInMoney.OptionsView.ShowGroupPanel = false;
            // 
            // gcVoucherNo
            // 
            this.gcVoucherNo.Caption = "银行凭证号";
            this.gcVoucherNo.FieldName = "VoucherNo";
            this.gcVoucherNo.Name = "gcVoucherNo";
            this.gcVoucherNo.Visible = true;
            this.gcVoucherNo.VisibleIndex = 0;
            // 
            // gcBankName
            // 
            this.gcBankName.Caption = "银行";
            this.gcBankName.FieldName = "BankName";
            this.gcBankName.Name = "gcBankName";
            this.gcBankName.Visible = true;
            this.gcBankName.VisibleIndex = 1;
            // 
            // gcRemitter
            // 
            this.gcRemitter.Caption = "客户名称";
            this.gcRemitter.FieldName = "Remitter";
            this.gcRemitter.Name = "gcRemitter";
            this.gcRemitter.Visible = true;
            this.gcRemitter.VisibleIndex = 2;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币种";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 3;
            // 
            // gcEnumFlowState
            // 
            this.gcEnumFlowState.Caption = "审批状态";
            this.gcEnumFlowState.FieldName = "EnumFlowState";
            this.gcEnumFlowState.Name = "gcEnumFlowState";
            this.gcEnumFlowState.Visible = true;
            this.gcEnumFlowState.VisibleIndex = 4;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "实收原币金额";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 5;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 6;
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "实收人民币金额";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 7;
            // 
            // gcTradingPostscript
            // 
            this.gcTradingPostscript.Caption = "交易附言";
            this.gcTradingPostscript.FieldName = "TradingPostscript";
            this.gcTradingPostscript.Name = "gcTradingPostscript";
            this.gcTradingPostscript.Visible = true;
            this.gcTradingPostscript.VisibleIndex = 8;
            // 
            // gcExportName
            // 
            this.gcExportName.Caption = "出口名称";
            this.gcExportName.FieldName = "ExportName";
            this.gcExportName.Name = "gcExportName";
            this.gcExportName.Visible = true;
            this.gcExportName.VisibleIndex = 9;
            // 
            // gcPaymentMethod
            // 
            this.gcPaymentMethod.Caption = "支付方式";
            this.gcPaymentMethod.FieldName = "PaymentMethod";
            this.gcPaymentMethod.Name = "gcPaymentMethod";
            this.gcPaymentMethod.Visible = true;
            this.gcPaymentMethod.VisibleIndex = 10;
            // 
            // gcReceiptDate
            // 
            this.gcReceiptDate.Caption = "收汇日期";
            this.gcReceiptDate.FieldName = "ReceiptDate";
            this.gcReceiptDate.Name = "gcReceiptDate";
            this.gcReceiptDate.Visible = true;
            this.gcReceiptDate.VisibleIndex = 11;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.Caption = "创建人";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 12;
            // 
            // gcState
            // 
            this.gcState.Caption = "是否已拆分";
            this.gcState.FieldName = "State";
            this.gcState.Name = "gcState";
            this.gcState.Visible = true;
            this.gcState.VisibleIndex = 13;
            // 
            // gcCreateTimestamp
            // 
            this.gcCreateTimestamp.Caption = "创建时间";
            this.gcCreateTimestamp.FieldName = "CreateTimestamp";
            this.gcCreateTimestamp.Name = "gcCreateTimestamp";
            this.gcCreateTimestamp.Visible = true;
            this.gcCreateTimestamp.VisibleIndex = 14;
            // 
            // gcDescription
            // 
            this.gcDescription.Caption = "备注";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 15;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dateEdit2);
            this.layoutControl1.Controls.Add(this.dateEdit1);
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
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(87, 87);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(186, 21);
            this.dateEdit2.StyleController = this.layoutControl1;
            this.dateEdit2.TabIndex = 7;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(87, 62);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(186, 21);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 6;
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
            this.layoutControlItem3,
            this.layoutControlItem4});
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
            this.layoutControlItem2.CustomizationFormText = "银行凭证码：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 25);
            this.layoutControlItem2.Text = "银行凭证码：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEdit1;
            this.layoutControlItem3.CustomizationFormText = "收汇日期：";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(265, 25);
            this.layoutControlItem3.Text = "收汇日期：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateEdit2;
            this.layoutControlItem4.CustomizationFormText = "录入日期：";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(265, 368);
            this.layoutControlItem4.Text = "录入日期：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // frmInMoneyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 597);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmInMoneyQuery";
            this.Text = "收支管理";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcInMoney;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInMoney;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemitter;
        private DevExpress.XtraGrid.Columns.GridColumn gcVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn gcTradingPostscript;
        private DevExpress.XtraGrid.Columns.GridColumn gcExportName;
        private DevExpress.XtraGrid.Columns.GridColumn gcState;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnumFlowState;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}