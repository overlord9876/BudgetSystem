namespace BudgetSystem.Tools
{
    partial class frmTools
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
            this.labSystemInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateDBConnectionString = new System.Windows.Forms.Button();
            this.btnPublishVersion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labSystemInfo
            // 
            this.labSystemInfo.AutoSize = true;
            this.labSystemInfo.Location = new System.Drawing.Point(17, 33);
            this.labSystemInfo.Name = "labSystemInfo";
            this.labSystemInfo.Size = new System.Drawing.Size(0, 15);
            this.labSystemInfo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPublishVersion);
            this.groupBox1.Controls.Add(this.btnCreateDBConnectionString);
            this.groupBox1.Location = new System.Drawing.Point(43, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 151);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置项";
            // 
            // btnCreateDBConnectionString
            // 
            this.btnCreateDBConnectionString.Location = new System.Drawing.Point(60, 42);
            this.btnCreateDBConnectionString.Name = "btnCreateDBConnectionString";
            this.btnCreateDBConnectionString.Size = new System.Drawing.Size(396, 31);
            this.btnCreateDBConnectionString.TabIndex = 0;
            this.btnCreateDBConnectionString.Text = "生成链接字符串";
            this.btnCreateDBConnectionString.UseVisualStyleBackColor = true;
            this.btnCreateDBConnectionString.Click += new System.EventHandler(this.btnCreateDBConnectionString_Click);
            // 
            // btnPublishVersion
            // 
            this.btnPublishVersion.Location = new System.Drawing.Point(60, 79);
            this.btnPublishVersion.Name = "btnPublishVersion";
            this.btnPublishVersion.Size = new System.Drawing.Size(396, 31);
            this.btnPublishVersion.TabIndex = 1;
            this.btnPublishVersion.Text = "版本发布";
            this.btnPublishVersion.UseVisualStyleBackColor = true;
            this.btnPublishVersion.Click += new System.EventHandler(this.btnPublishVersion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labSystemInfo);
            this.groupBox2.Location = new System.Drawing.Point(43, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 150);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器信息";
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置工具";
            this.Load += new System.EventHandler(this.frmTools_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labSystemInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPublishVersion;
        private System.Windows.Forms.Button btnCreateDBConnectionString;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

