﻿using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.ComponentModel;

namespace BudgetSystem.CommonControl
{
    public class TextEdit_Number : TextEdit
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

        /// <summary>
        /// 编辑数值
        /// </summary>
        public decimal Value
        {
            get
            {
                decimal result = 0;
                if (this.EditValue != null)
                {
                    decimal.TryParse(this.EditValue.ToString(), out result);
                }
                return result;
            }
        }


        public float FloatValue
        {
            get
            {
                float result = 0;
                if (this.EditValue != null)
                {
                    float.TryParse(this.EditValue.ToString(), out result);
                }
                return result;
            }
        }

        public TextEdit_Number()
            : base()
        {
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Properties.Mask.EditMask = "n";
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Properties.NullText = "0";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(TextEdit_Number_KeyDown);
            this.EditValueChanged += new EventHandler(TextEdit_Number_EditValueChanged);
        }

        void TextEdit_Number_EditValueChanged(object sender, EventArgs e)
        {
            if ("0.00".Equals(this.Text))
            {
                this.EditValue = null;
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
