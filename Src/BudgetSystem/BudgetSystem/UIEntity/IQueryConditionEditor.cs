using System;
using DevExpress.XtraEditors;
namespace BudgetSystem
{
    public interface IQueryConditionEditor
    {
        bool IsSavedNewCondition { get; set; }
        BudgetSystem.Entity.QueryCondition.BaseQueryCondition QueryCondition { get; set; }
        string QueryName { get; set; }
    }
}
