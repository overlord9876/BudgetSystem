namespace BudgetSystem.Deploy
{
    partial class frmSetting
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
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtConnectoinString = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectoinString.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(412, 186);
            this.btnSure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(105, 43);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(533, 186);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 43);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 18);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "服务器连接：";
            // 
            // txtConnectoinString
            // 
            this.txtConnectoinString.Location = new System.Drawing.Point(128, 29);
            this.txtConnectoinString.Name = "txtConnectoinString";
            this.txtConnectoinString.Size = new System.Drawing.Size(510, 138);
            this.txtConnectoinString.TabIndex = 5;
            // 
            // frmSetting
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(679, 248);
            this.Controls.Add(this.txtConnectoinString);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置";
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectoinString.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtConnectoinString;
    }
}