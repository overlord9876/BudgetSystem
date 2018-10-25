using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace BudgetSystem
{
    public class TextEdit_Number:TextEdit
    {
        private bool isSupportNegative = false;
        /// <summary>
        /// 是否支持负数
        /// </summary>
        public bool IsSupportNegative
        {
            get { return isSupportNegative; }
            set { this.isSupportNegative = value; }
        }
        public TextEdit_Number()
            : base()
        {
            this.Properties.Mask.EditMask = "n";
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Properties.NullText = "0.00";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(TextEdit_Number_KeyDown);
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
