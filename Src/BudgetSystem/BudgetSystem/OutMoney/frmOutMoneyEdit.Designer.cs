namespace BudgetSystem.OutMoney
{
    partial class frmOutMoneyEdit
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
            this.ucOutMoneyEdit1 = new BudgetSystem.OutMoney.ucOutMoneyEdit();
            this.btn_Submit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCommit = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCommit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ucOutMoneyEdit1);
            this.layoutControl1.Controls.Add(this.btn_Submit);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnSure);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(768, 100, 678, 586);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1152, 937);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ucOutMoneyEdit1
            // 
            this.ucOutMoneyEdit1.Location = new System.Drawing.Point(12, 12);
            this.ucOutMoneyEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucOutMoneyEdit1.Name = "ucOutMoneyEdit1";
            this.ucOutMoneyEdit1.Size = new System.Drawing.Size(1128, 877);
            this.ucOutMoneyEdit1.TabIndex = 49;
            this.ucOutMoneyEdit1.WorkModel = BudgetSystem.EditFormWorkModels.Default;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(784, 893);
            this.btn_Submit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(116, 32);
            this.btn_Submit.StyleController = this.layoutControl1;
            this.btn_Submit.TabIndex = 101;
            this.btn_Submit.Text = "提交";
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1024, 893);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 32);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 102;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(904, 893);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(116, 32);
            this.btnSure.StyleController = this.layoutControl1;
            this.btnSure.TabIndex = 100;
            this.btnSure.Text = "保存";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lciCancel,
            this.lciCommit,
            this.layoutControlItem1,
            this.lciSave});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1152, 937);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 881);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(772, 36);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.btnCancel;
            this.lciCancel.CustomizationFormText = "取消按钮";
            this.lciCancel.Location = new System.Drawing.Point(1012, 881);
            this.lciCancel.MaxSize = new System.Drawing.Size(120, 36);
            this.lciCancel.MinSize = new System.Drawing.Size(120, 20);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(120, 36);
            this.lciCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciCancel.Text = "取消按钮";
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextToControlDistance = 0;
            this.lciCancel.TextVisible = false;
            // 
            // lciCommit
            // 
            this.lciCommit.Control = this.btn_Submit;
            this.lciCommit.CustomizationFormText = "提交按钮";
            this.lciCommit.Location = new System.Drawing.Point(772, 881);
            this.lciCommit.MaxSize = new System.Drawing.Size(120, 36);
            this.lciCommit.MinSize = new System.Drawing.Size(93, 26);
            this.lciCommit.Name = "lciCommit";
            this.lciCommit.Size = new System.Drawing.Size(120, 36);
            this.lciCommit.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciCommit.Text = "提交按钮";
            this.lciCommit.TextSize = new System.Drawing.Size(0, 0);
            this.lciCommit.TextToControlDistance = 0;
            this.lciCommit.TextVisible = false;
            // 
            // lciSave
            // 
            this.lciSave.Control = this.btnSure;
            this.lciSave.CustomizationFormText = "保存按钮";
            this.lciSave.Location = new System.Drawing.Point(892, 881);
            this.lciSave.MaxSize = new System.Drawing.Size(120, 36);
            this.lciSave.MinSize = new System.Drawing.Size(120, 36);
            this.lciSave.Name = "lciSave";
            this.lciSave.Size = new System.Drawing.Size(120, 36);
            this.lciSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSave.Text = "保存按钮";
            this.lciSave.TextSize = new System.Drawing.Size(0, 0);
            this.lciSave.TextToControlDistance = 0;
            this.lciSave.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucOutMoneyEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1132, 881);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmOutMoneyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 937);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOutMoneyEdit";
            this.Text = "付款申请单";
            this.Load += new System.EventHandler(this.frmOutMemoryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCommit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraLayout.LayoutControlItem lciSave;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
        private DevExpress.XtraEditors.SimpleButton btn_Submit;
        private DevExpress.XtraLayout.LayoutControlItem lciCommit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ucOutMoneyEdit ucOutMoneyEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}