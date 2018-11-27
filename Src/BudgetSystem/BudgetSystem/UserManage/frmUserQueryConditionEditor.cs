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
    public partial class frmUserQueryConditionEditor : frmUserQueryConditionEditorTransit
    {
        public frmUserQueryConditionEditor()
        {
            InitializeComponent();
        }


        public override bool CollectData()
        {
            UserQueryCondition c = new UserQueryCondition();

            c.UserName = "abc";


            this.QueryCondition = c;
            return true;
         
        }
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmUserQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<UserQueryCondition>
    { 
    
    }

}