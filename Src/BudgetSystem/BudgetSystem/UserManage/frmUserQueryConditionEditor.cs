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
    public partial class frmUserQueryConditionEditor : frmTestQueryConditionEditorransit
    {
        public frmUserQueryConditionEditor()
        {
            InitializeComponent();
            this.QueryName = "UserQuery";
        }


        public override bool CollectData()
        {
           
            this.QueryCondition = new UserQueryCondition();
            this.QueryCondition.UserName = "abc";
            return true;
         
        }
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmTestQueryConditionEditorransit : Base.frmBaseQueryConditionEditor<UserQueryCondition>
    { 
    
    }

}