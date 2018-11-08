using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    /// <summary>
    /// 增值税配置界面
    /// </summary>
    public partial class ucVATOptionEdit : ucOptionEditBase
    {
        public ucVATOptionEdit()
            : base()
        {
            InitializeComponent();
            this.OptionName = EnumSystemConfigNames.增值税.ToString(); 
        }

        protected override void RegisterEvent()
        {
            this.txtValue.TextChanged += new EventHandler(txtValue_TextChanged);  
        }

      
        protected override void BindingOption()
        {
            decimal value = this.scm.GetSystemConfigValue<decimal>(this.OptionName);
            this.txtValue.EditValue = value;
        }
        public override bool Save()
        {
            decimal value = this.txtValue.Value;
            if (value == 0)
            {
                XtraMessageBox.Show("增值税配置项值应大于0");
                return false;
            }

            this.scm.ModifySupplier<decimal>(this.OptionName, value);
            this.IsChanged = false;
            return true;
        }
        void txtValue_TextChanged(object sender, EventArgs e)
        {
            this.IsChanged = true;
        }
    }
}
