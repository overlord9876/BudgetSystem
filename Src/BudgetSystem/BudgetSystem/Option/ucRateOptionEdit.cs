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
    /// 比率类配置项配置界面
    /// </summary>
    public partial class ucRateOptionEdit : ucOptionEditBase
    {
        public ucRateOptionEdit(EnumSystemConfigNames name)
            : base()
        {
            InitializeComponent();
            this.OptionName = name.ToString(); 
        }

        protected override void RegisterEvent()
        {
            this.txtValue.TextChanged += new EventHandler(txtValue_TextChanged);  
        }

      
        protected override void BindingOption()
        {
            this.txtValue.Properties.ReadOnly = !this.AllowEdit;
            decimal value = this.scm.GetSystemConfigValue<decimal>(this.OptionName);
            this.txtValue.EditValue = value;
        }
        public override bool Save()
        {
            decimal value = this.txtValue.Value;
            if (value <= 0)
            {
                XtraMessageBox.Show(this.OptionName+ "配置项值应大于0");
                return false;
            }

            this.scm.ModifySystemConfig<decimal>(this.OptionName, value);
            this.IsChanged = false;
            return true;
        }
        void txtValue_TextChanged(object sender, EventArgs e)
        {
            this.IsChanged = true;
        }
    }
}
