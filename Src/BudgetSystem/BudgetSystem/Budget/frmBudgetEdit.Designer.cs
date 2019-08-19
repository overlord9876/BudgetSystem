namespace BudgetSystem
{
    partial class frmBudgetEdit
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
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.ucBudgetEdit1 = new BudgetSystem.ucBudgetEdit();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSubmit);
            this.layoutControl1.Controls.Add(this.ucBudgetEdit1);
            this.layoutControl1.Controls.Add(this.btnSure);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-48, 328, 1151, 769);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(900, 583);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(542, 549);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(116, 32);
            this.btnSubmit.StyleController = this.layoutControl1;
            this.btnSubmit.TabIndex = 58;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ucBudgetEdit1
            // 
            this.ucBudgetEdit1.CurrentBudget = null;
            this.ucBudgetEdit1.Location = new System.Drawing.Point(0, 0);
            this.ucBudgetEdit1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBudgetEdit1.Name = "ucBudgetEdit1";
            this.ucBudgetEdit1.Size = new System.Drawing.Size(900, 547);
            this.ucBudgetEdit1.TabIndex = 57;
            this.ucBudgetEdit1.WorkModel = BudgetSystem.EditFormWorkModels.Default;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(662, 549);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(116, 32);
            this.btnSure.StyleController = this.layoutControl1;
            this.btnSure.TabIndex = 56;
            this.btnSure.Text = "保存";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(782, 549);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 32);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "取消";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem50,
            this.layoutControlItem51,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(900, 583);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.btnCancel;
            this.layoutControlItem50.CustomizationFormText = "layoutControlItem50";
            this.layoutControlItem50.Location = new System.Drawing.Point(780, 547);
            this.layoutControlItem50.MaxSize = new System.Drawing.Size(120, 36);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(120, 36);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(120, 36);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.Text = "layoutControlItem50";
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextToControlDistance = 0;
            this.layoutControlItem50.TextVisible = false;
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.btnSure;
            this.layoutControlItem51.CustomizationFormText = "确定";
            this.layoutControlItem51.Location = new System.Drawing.Point(660, 547);
            this.layoutControlItem51.MaxSize = new System.Drawing.Size(120, 36);
            this.layoutControlItem51.MinSize = new System.Drawing.Size(120, 36);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(120, 36);
            this.layoutControlItem51.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem51.Text = "确定";
            this.layoutControlItem51.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem51.TextToControlDistance = 0;
            this.layoutControlItem51.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 547);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(540, 36);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucBudgetEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(900, 547);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSubmit;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(540, 547);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(120, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(120, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(120, 36);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmBudgetEdit
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(900, 583);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmBudgetEdit";
            this.Text = "预算单";
            this.Load += new System.EventHandler(this.frmBudgetEditEx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private ucBudgetEdit ucBudgetEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}