namespace BudgetSystem.Deploy
{
    partial class frmVersionUpdate
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labInfo = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            this.labInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Location = new System.Drawing.Point(20, 24);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(705, 129);
            this.labInfo.TabIndex = 0;
            // 
            // progressBarControl
            // 
            this.progressBarControl.Location = new System.Drawing.Point(20, 184);
            this.progressBarControl.Name = "progressBarControl";
            this.progressBarControl.Properties.Step = 1;
            this.progressBarControl.Size = new System.Drawing.Size(705, 38);
            this.progressBarControl.TabIndex = 1;
            // 
            // frmVersionUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 257);
            this.Controls.Add(this.progressBarControl);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVersionUpdate";
            this.Padding = new System.Windows.Forms.Padding(20, 24, 20, 24);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "版本更新";
            this.Load += new System.EventHandler(this.frmVersionUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labInfo;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl;

    }
}

