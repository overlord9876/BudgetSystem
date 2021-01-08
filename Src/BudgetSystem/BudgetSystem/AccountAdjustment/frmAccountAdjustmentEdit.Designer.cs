namespace BudgetSystem
{
    partial class frmAccountAdjustmentEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ucAccountAdjustmentEdit1 = new BudgetSystem.InMoney.ucAccountAdjustmentEdit();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcSure = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ucAccountAdjustmentEdit1);
            this.layoutControl1.Controls.Add(this.btnSure);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(911, 202, 516, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1554, 847);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ucAccountAdjustmentEdit1
            // 
            this.ucAccountAdjustmentEdit1.AdjustmentType = BudgetSystem.Entity.AdjustmentType.收款;
            this.ucAccountAdjustmentEdit1.Location = new System.Drawing.Point(2, 2);
            this.ucAccountAdjustmentEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucAccountAdjustmentEdit1.Name = "ucAccountAdjustmentEdit1";
            this.ucAccountAdjustmentEdit1.Size = new System.Drawing.Size(1550, 803);
            this.ucAccountAdjustmentEdit1.TabIndex = 8;
            this.ucAccountAdjustmentEdit1.WorkModel = BudgetSystem.EditFormWorkModels.Default;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(1300, 809);
            this.btnSure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(124, 36);
            this.btnSure.StyleController = this.layoutControl1;
            this.btnSure.TabIndex = 4;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1428, 809);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 36);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.lcCancel,
            this.lcSure,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1554, 847);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 711);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1287, 40);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcCancel
            // 
            this.lcCancel.Control = this.btnCancel;
            this.lcCancel.CustomizationFormText = "lcCancel";
            this.lcCancel.Location = new System.Drawing.Point(1426, 807);
            this.lcCancel.MaxSize = new System.Drawing.Size(128, 40);
            this.lcCancel.MinSize = new System.Drawing.Size(128, 40);
            this.lcCancel.Name = "lcCancel";
            this.lcCancel.Size = new System.Drawing.Size(128, 40);
            this.lcCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcCancel.Text = "lcCancel";
            this.lcCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lcCancel.TextToControlDistance = 0;
            this.lcCancel.TextVisible = false;
            // 
            // lcSure
            // 
            this.lcSure.Control = this.btnSure;
            this.lcSure.CustomizationFormText = "lcSure";
            this.lcSure.Location = new System.Drawing.Point(1298, 807);
            this.lcSure.MaxSize = new System.Drawing.Size(128, 40);
            this.lcSure.MinSize = new System.Drawing.Size(128, 40);
            this.lcSure.Name = "lcSure";
            this.lcSure.Size = new System.Drawing.Size(128, 40);
            this.lcSure.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcSure.Text = "lcSure";
            this.lcSure.TextSize = new System.Drawing.Size(0, 0);
            this.lcSure.TextToControlDistance = 0;
            this.lcSure.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucAccountAdjustmentEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1554, 807);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmAccountAdjustmentEdit
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1554, 847);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAccountAdjustmentEdit";
            this.Text = "调账信息编辑";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem lcCancel;
        private DevExpress.XtraLayout.LayoutControlItem lcSure;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private InMoney.ucAccountAdjustmentEdit ucAccountAdjustmentEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}