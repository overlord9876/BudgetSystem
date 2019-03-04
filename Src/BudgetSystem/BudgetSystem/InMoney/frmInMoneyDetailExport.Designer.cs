namespace BudgetSystem.InMoney
{
    partial class frmInMoneyDetailExport
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
            this.gcReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOriginalCoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gcInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInMoney
            // 
            this.gcInMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInMoney.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcInMoney.Location = new System.Drawing.Point(0, 0);
            this.gcInMoney.MainView = this.gvInMoney;
            this.gcInMoney.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcInMoney.Name = "gcInMoney";
            this.gcInMoney.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gcInMoney.Size = new System.Drawing.Size(1115, 768);
            this.gcInMoney.TabIndex = 1;
            this.gcInMoney.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInMoney});
            // 
            // gvInMoney
            // 
            this.gvInMoney.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcReceiptDate,
            this.gcVoucherNo,
            this.gcDepartment,
            this.gcBankName,
            this.gcContractNO,
            this.gcOriginalCoin,
            this.gcCurrency,
            this.gcExchangeRate,
            this.gcPaymentMethod});
            this.gvInMoney.GridControl = this.gcInMoney;
            this.gvInMoney.Name = "gvInMoney";
            this.gvInMoney.OptionsBehavior.Editable = false;
            this.gvInMoney.OptionsView.ShowDetailButtons = false;
            this.gvInMoney.OptionsView.ShowGroupPanel = false;
            // 
            // gcReceiptDate
            // 
            this.gcReceiptDate.Caption = "收汇日期";
            this.gcReceiptDate.FieldName = "ReceiptDate";
            this.gcReceiptDate.Name = "gcReceiptDate";
            this.gcReceiptDate.Visible = true;
            this.gcReceiptDate.VisibleIndex = 0;
            this.gcReceiptDate.Width = 150;
            // 
            // gcVoucherNo
            // 
            this.gcVoucherNo.Caption = "银行凭证号";
            this.gcVoucherNo.FieldName = "VoucherNo";
            this.gcVoucherNo.Name = "gcVoucherNo";
            this.gcVoucherNo.Visible = true;
            this.gcVoucherNo.VisibleIndex = 1;
            this.gcVoucherNo.Width = 115;
            // 
            // gcDepartment
            // 
            this.gcDepartment.Caption = "部门";
            this.gcDepartment.FieldName = "DepartmentContent";
            this.gcDepartment.Name = "gcDepartment";
            this.gcDepartment.Visible = true;
            this.gcDepartment.VisibleIndex = 2;
            this.gcDepartment.Width = 97;
            // 
            // gcBankName
            // 
            this.gcBankName.Caption = "银行";
            this.gcBankName.FieldName = "BankName";
            this.gcBankName.Name = "gcBankName";
            this.gcBankName.Visible = true;
            this.gcBankName.VisibleIndex = 3;
            this.gcBankName.Width = 97;
            // 
            // gcContractNO
            // 
            this.gcContractNO.Caption = "合同编号";
            this.gcContractNO.FieldName = "ContractNO";
            this.gcContractNO.Name = "gcContractNO";
            this.gcContractNO.Visible = true;
            this.gcContractNO.VisibleIndex = 4;
            this.gcContractNO.Width = 144;
            // 
            // gcOriginalCoin
            // 
            this.gcOriginalCoin.Caption = "收款金额";
            this.gcOriginalCoin.FieldName = "OriginalCoin";
            this.gcOriginalCoin.Name = "gcOriginalCoin";
            this.gcOriginalCoin.Visible = true;
            this.gcOriginalCoin.VisibleIndex = 6;
            this.gcOriginalCoin.Width = 84;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币种";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 5;
            this.gcCurrency.Width = 84;
            // 
            // gcExchangeRate
            // 
            this.gcExchangeRate.Caption = "汇率";
            this.gcExchangeRate.FieldName = "ExchangeRate";
            this.gcExchangeRate.Name = "gcExchangeRate";
            this.gcExchangeRate.Visible = true;
            this.gcExchangeRate.VisibleIndex = 7;
            this.gcExchangeRate.Width = 84;
            // 
            // gcPaymentMethod
            // 
            this.gcPaymentMethod.Caption = "支付方式";
            this.gcPaymentMethod.FieldName = "PaymentMethod";
            this.gcPaymentMethod.Name = "gcPaymentMethod";
            this.gcPaymentMethod.Visible = true;
            this.gcPaymentMethod.VisibleIndex = 8;
            this.gcPaymentMethod.Width = 103;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Excel2003|*.xls\"";
            // 
            // frmInMoneyDetailExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 768);
            this.Controls.Add(this.gcInMoney);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmInMoneyDetailExport";
            this.Text = "收款管理";
            ((System.ComponentModel.ISupportInitialize)(this.gcInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcInMoney;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcOriginalCoin;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn gcDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}