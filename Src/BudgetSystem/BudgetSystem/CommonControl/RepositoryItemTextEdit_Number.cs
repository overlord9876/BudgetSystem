using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace BudgetSystem.CommonControl
{
    public class RepositoryItemTextEdit_Number : DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    {
        private bool isSupportNegative = false;
        /// <summary>
        /// 是否支持负数
        /// </summary>
        [Description("是否支持负数")]
        public bool IsSupportNegative
        {
            get { return isSupportNegative; }
            set { this.isSupportNegative = value; }
        }


        public RepositoryItemTextEdit_Number()
            : base()
        {
            this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Mask.EditMask = "n";
            this.Mask.UseMaskAsDisplayFormat = true;
            this.NullText = "0";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(TextEdit_Number_KeyDown);
            this.EditValueChanged += new EventHandler(TextEdit_Number_EditValueChanged);
        }

        void TextEdit_Number_EditValueChanged(object sender, EventArgs e)
        {
            if (this.OwnerEdit != null && "0.00".Equals(this.OwnerEdit.Text))
            {
                this.OwnerEdit.EditValue = null;
            }
        }

        void TextEdit_Number_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.isSupportNegative == true)
            {
                return;
            }
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
