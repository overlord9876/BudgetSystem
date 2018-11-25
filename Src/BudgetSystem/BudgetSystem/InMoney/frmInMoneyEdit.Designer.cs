namespace BudgetSystem.InMoney
{
    partial class frmInMoneyEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ucInMoneyEdit1 = new BudgetSystem.InMoney.ucInMoneyEdit();
            this.btnCommit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lci_CommitButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_CommitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ucInMoneyEdit1);
            this.layoutControl1.Controls.Add(this.btnCommit);
            this.layoutControl1.Controls.Add(this.btnSure);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1278, 286, 480, 566);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1152, 937);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ucInMoneyEdit1
            // 
            this.ucInMoneyEdit1.Location = new System.Drawing.Point(12, 12);
            this.ucInMoneyEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucInMoneyEdit1.Name = "ucInMoneyEdit1";
            this.ucInMoneyEdit1.Size = new System.Drawing.Size(1128, 873);
            this.ucInMoneyEdit1.TabIndex = 41;
            this.ucInMoneyEdit1.WorkModel = BudgetSystem.EditFormWorkModels.Default;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(717, 889);
            this.btnCommit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(143, 36);
            this.btnCommit.StyleController = this.layoutControl1;
            this.btnCommit.TabIndex = 40;
            this.btnCommit.Text = "提交";
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(864, 889);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(136, 36);
            this.btnSure.StyleController = this.layoutControl1;
            this.btnSure.TabIndex = 22;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1004, 889);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 36);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.emptySpaceItem2,
            this.lci_CommitButton,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1152, 937);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btnCancel;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(992, 877);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(140, 40);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "layoutControlItem14";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextToControlDistance = 0;
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnSure;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(852, 877);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(140, 40);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(140, 40);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.Text = "layoutControlItem15";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 877);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(705, 40);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lci_CommitButton
            // 
            this.lci_CommitButton.Control = this.btnCommit;
            this.lci_CommitButton.CustomizationFormText = "layoutControlItem23";
            this.lci_CommitButton.Location = new System.Drawing.Point(705, 877);
            this.lci_CommitButton.MaxSize = new System.Drawing.Size(0, 40);
            this.lci_CommitButton.MinSize = new System.Drawing.Size(93, 40);
            this.lci_CommitButton.Name = "lci_CommitButton";
            this.lci_CommitButton.Size = new System.Drawing.Size(147, 40);
            this.lci_CommitButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lci_CommitButton.Text = "lci_CommitButton";
            this.lci_CommitButton.TextSize = new System.Drawing.Size(0, 0);
            this.lci_CommitButton.TextToControlDistance = 0;
            this.lci_CommitButton.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucInMoneyEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1132, 877);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.CustomizationFormText = "layoutControlItem22";
            this.layoutControlItem22.Location = new System.Drawing.Point(482, 100);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(482, 25);
            this.layoutControlItem22.Text = "layoutControlItem22";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem22.TextToControlDistance = 5;
            // 
            // frmInMoneyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 937);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmInMoneyEdit";
            this.Text = "收款单";
            this.Load += new System.EventHandler(this.frmInMemoryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_CommitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCommit;
        public DevExpress.XtraLayout.LayoutControlItem lci_CommitButton;
        private ucInMoneyEdit ucInMoneyEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}