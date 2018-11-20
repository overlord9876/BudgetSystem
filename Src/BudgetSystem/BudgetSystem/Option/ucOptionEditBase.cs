using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem
{
    public  class ucOptionEditBase:UserControl
    {
        protected Bll.SystemConfigManager scm =null; 


        public ucOptionEditBase()
        {
            scm = new Bll.SystemConfigManager(); 
            this.Load += new System.EventHandler(this.ucOptionEditBase_Load);
        }
        /// <summary>
        /// 是否允许修改
        /// </summary>
        public bool AllowEdit
        {
            get;
            set;
        }
        /// <summary>
        /// 是否修改
        /// </summary>
        public bool IsChanged
        {
            get;
            set;
        }
        /// <summary>
        /// 选项名称
        /// </summary>
        public string OptionName
        {
            get;
            set;
        }
       
        /// <summary>
        /// 保存
        /// </summary>
        public virtual bool Save()
        {
            return false;
        }
        /// <summary>
        /// 绑定选项数据
        /// </summary>
        protected virtual void BindingOption()
        {
        
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        protected virtual void RegisterEvent()
        { 
        
        }

       

        private void ucOptionEditBase_Load(object sender, EventArgs e)
        {
            this.BindingOption();
            this.RegisterEvent();
        }

    }
}
