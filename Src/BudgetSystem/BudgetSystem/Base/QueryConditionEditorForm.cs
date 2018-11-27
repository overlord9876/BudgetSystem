using System;
using DevExpress.XtraEditors;
namespace BudgetSystem
{
    public abstract class QueryConditionEditorForm : XtraForm, IQueryConditionEditor
    {


        public bool IsSavedNewCondition
        {
            get;
            set;
        }

        public Entity.QueryCondition.BaseQueryCondition QueryCondition
        {
            get;
            set;
        }

        public string QueryName
        {
            get;
            set;
        }
    }
}
