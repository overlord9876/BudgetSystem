namespace BudgetSystem
{
    partial class frmSupplierLeaderReviewEventForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboItem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.rgDiscredited = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDiscredited.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(58, 43);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 18);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "复评结果：";
            // 
            // cboItem
            // 
            this.cboItem.EditValue = "合格";
            this.cboItem.Location = new System.Drawing.Point(144, 40);
            this.cboItem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboItem.Name = "cboItem";
            this.cboItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItem.Properties.Items.AddRange(new object[] {
            "合格",
            "不合格"});
            this.cboItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboItem.Size = new System.Drawing.Size(493, 25);
            this.cboItem.TabIndex = 5;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(529, 125);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // btnSure
            // 
            this.btnSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSure.Location = new System.Drawing.Point(418, 125);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(98, 39);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确认";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // rgDiscredited
            // 
            this.rgDiscredited.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgDiscredited.Location = new System.Drawing.Point(143, 78);
            this.rgDiscredited.Margin = new System.Windows.Forms.Padding(0);
            this.rgDiscredited.Name = "rgDiscredited";
            this.rgDiscredited.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgDiscredited.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgDiscredited.Properties.Appearance.Options.UseBackColor = true;
            this.rgDiscredited.Properties.Appearance.Options.UseFont = true;
            this.rgDiscredited.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgDiscredited.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "非失信企业"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "失信企业")});
            this.rgDiscredited.Properties.ReadOnly = true;
            this.rgDiscredited.Size = new System.Drawing.Size(322, 27);
            this.rgDiscredited.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 81);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 18);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "企业信用信息：";
            // 
            // frmSupplierLeaderReviewEventForm
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(668, 176);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.rgDiscredited);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Name = "frmSupplierLeaderReviewEventForm";
            ((System.ComponentModel.ISupportInitialize)(this.cboItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDiscredited.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboItem;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.RadioGroup rgDiscredited;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}