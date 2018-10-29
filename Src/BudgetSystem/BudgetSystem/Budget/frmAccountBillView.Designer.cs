﻿namespace BudgetSystem
{
    partial class frmAccountBillView
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
            this.components = new System.ComponentModel.Container();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblBudgetNO = new DevExpress.XtraEditors.LabelControl();
            this.gcAccountBill = new DevExpress.XtraGrid.GridControl();
            this.gvAccountBill = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBudgetNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaymentMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRecieptMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCNY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneyUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccountBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lblBudgetNO);
            this.layoutControl1.Controls.Add(this.gcAccountBill);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(711, 489, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1209, 664);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblBudgetNO
            // 
            this.lblBudgetNO.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBudgetNO.Location = new System.Drawing.Point(1161, 12);
            this.lblBudgetNO.Name = "lblBudgetNO";
            this.lblBudgetNO.Size = new System.Drawing.Size(36, 14);
            this.lblBudgetNO.StyleController = this.layoutControl1;
            this.lblBudgetNO.TabIndex = 7;
            this.lblBudgetNO.Text = "合同号";
            // 
            // gcAccountBill
            // 
            this.gcAccountBill.Location = new System.Drawing.Point(12, 43);
            this.gcAccountBill.MainView = this.gvAccountBill;
            this.gcAccountBill.Name = "gcAccountBill";
            this.gcAccountBill.Size = new System.Drawing.Size(1185, 609);
            this.gcAccountBill.TabIndex = 6;
            this.gcAccountBill.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccountBill});
            // 
            // gvAccountBill
            // 
            this.gvAccountBill.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCreateDate,
            this.gcBudgetNO,
            this.gcPaymentMoney,
            this.gcRecieptMoney,
            this.gcCNY,
            this.gcCurrency,
            this.gcCompany,
            this.gcVoucherNo,
            this.gcMoneyUsed});
            this.gvAccountBill.GridControl = this.gcAccountBill;
            this.gvAccountBill.Name = "gvAccountBill";
            this.gvAccountBill.OptionsBehavior.Editable = false;
            this.gvAccountBill.OptionsView.ShowGroupPanel = false;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "日期";
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 0;
            // 
            // gcBudgetNO
            // 
            this.gcBudgetNO.Caption = "合同编号";
            this.gcBudgetNO.FieldName = "BudgetNO";
            this.gcBudgetNO.Name = "gcBudgetNO";
            this.gcBudgetNO.Visible = true;
            this.gcBudgetNO.VisibleIndex = 1;
            // 
            // gcPaymentMoney
            // 
            this.gcPaymentMoney.Caption = "申请用款金额";
            this.gcPaymentMoney.FieldName = "PaymentMoney";
            this.gcPaymentMoney.Name = "gcPaymentMoney";
            this.gcPaymentMoney.Visible = true;
            this.gcPaymentMoney.VisibleIndex = 2;
            // 
            // gcRecieptMoney
            // 
            this.gcRecieptMoney.Caption = "收款金额";
            this.gcRecieptMoney.FieldName = "RecieptMoney";
            this.gcRecieptMoney.Name = "gcRecieptMoney";
            this.gcRecieptMoney.Visible = true;
            this.gcRecieptMoney.VisibleIndex = 3;
            // 
            // gcCNY
            // 
            this.gcCNY.Caption = "折合人民币";
            this.gcCNY.FieldName = "CNY";
            this.gcCNY.Name = "gcCNY";
            this.gcCNY.Visible = true;
            this.gcCNY.VisibleIndex = 4;
            // 
            // gcCurrency
            // 
            this.gcCurrency.Caption = "币制";
            this.gcCurrency.FieldName = "Currency";
            this.gcCurrency.Name = "gcCurrency";
            this.gcCurrency.Visible = true;
            this.gcCurrency.VisibleIndex = 5;
            // 
            // gcCompany
            // 
            this.gcCompany.Caption = "单位名称";
            this.gcCompany.FieldName = "Company";
            this.gcCompany.Name = "gcCompany";
            this.gcCompany.Visible = true;
            this.gcCompany.VisibleIndex = 6;
            // 
            // gcVoucherNo
            // 
            this.gcVoucherNo.Caption = "凭证号";
            this.gcVoucherNo.FieldName = "VoucherNo";
            this.gcVoucherNo.Name = "gcVoucherNo";
            this.gcVoucherNo.Visible = true;
            this.gcVoucherNo.VisibleIndex = 7;
            // 
            // gcMoneyUsed
            // 
            this.gcMoneyUsed.Caption = "用途分类";
            this.gcMoneyUsed.FieldName = "MoneyUsed";
            this.gcMoneyUsed.Name = "gcMoneyUsed";
            this.gcMoneyUsed.Visible = true;
            this.gcMoneyUsed.VisibleIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(230, 27);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "按合同号查询收付情况";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1209, 664);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(234, 31);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(234, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(915, 31);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcAccountBill;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1189, 613);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lblBudgetNO;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(1149, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(40, 31);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Bottom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmAccountBillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 664);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAccountBillView";
            this.Text = "按合同号查询收付情况";
            this.Load += new System.EventHandler(this.frmAccountBillView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAccountBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl lblBudgetNO;
        private DevExpress.XtraGrid.GridControl gcAccountBill;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccountBill;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcBudgetNO;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaymentMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcRecieptMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gcCNY;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompany;
        private DevExpress.XtraGrid.Columns.GridColumn gcVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneyUsed;
    }
}