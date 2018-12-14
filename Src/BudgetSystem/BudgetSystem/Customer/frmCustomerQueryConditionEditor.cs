using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmCustomerQueryConditionEditor : frmCustomerQueryConditionEditorTransit
    {
        public frmCustomerQueryConditionEditor()
        {
            InitializeComponent(); 
        }
       
        public override bool CollectData()
        {
            CustomerQueryCondition c = new CustomerQueryCondition();
            c.Code = this.txtCode.Text;
            c.CustomName = this.txtName.Text;
            this.QueryCondition = c;
            return true;        
        } 
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmCustomerQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<CustomerQueryCondition>
    {

    }

}