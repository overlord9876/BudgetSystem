namespace BudgetSystem
{
    partial class ucVATOptionEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtValue = new BudgetSystem.CommonControl.TextEdit_Number();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.IsSupportNegative = false;
            this.txtValue.Location = new System.Drawing.Point(4, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.Mask.EditMask = "n";
            this.txtValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtValue.Properties.NullText = "0";
            this.txtValue.Size = new System.Drawing.Size(182, 25);
            this.txtValue.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(193, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(15, 18);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "%";
            // 
            // ucVATOptionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtValue);
            this.Name = "ucVATOptionEdit";
            this.Size = new System.Drawing.Size(862, 124);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControl.TextEdit_Number txtValue;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}
