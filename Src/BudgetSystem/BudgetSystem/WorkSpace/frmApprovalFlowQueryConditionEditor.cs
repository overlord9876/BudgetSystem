using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using BudgetSystem.WorkSpace;

namespace BudgetSystem
{
    public partial class frmApprovalFlowQueryConditionEditor : frmApprovalFlowQueryConditionEditorTransit
    {
        private CommonManager commonManager = new CommonManager();
        public frmApprovalFlowQueryConditionEditor()
        {
            InitializeComponent();
        }
        private void frmApprovalFlowQueryConditionEditor_Load(object sender, EventArgs e)
        {
            DateTime dateTime = commonManager.GetDateTimeNow();
            this.deBeginTime.EditValue = dateTime;
            this.deEndTime.EditValue = dateTime;
        }
        public override bool CollectData()
        {
            ApprovalFlowQueryCondition c = new ApprovalFlowQueryCondition();
            c.CurrentUer = RunInfo.Instance.CurrentUser.UserName;
            DateTime beginTime = (DateTime)deBeginTime.EditValue;
            c.BeginTimestamp = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day);

            DateTime endTime = (DateTime)deEndTime.EditValue;
            c.EndTimestamp = new DateTime(endTime.Year, endTime.Month, endTime.Day).AddDays(1).AddMinutes(-1);
            this.QueryCondition = c;
            return true;
        }


    }

    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmApprovalFlowQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<ApprovalFlowQueryCondition>
    {

    }

}