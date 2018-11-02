using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;
using System.Linq;
using BudgetSystem.Entity;
using BudgetSystem.WorkSpace;

namespace BudgetSystem.WorkSpace
{
    public partial class frmApprovalListQuery : frmBaseQueryForm
    {


        FlowManager manager = new FlowManager();
        public frmApprovalListQuery()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            var list = manager.GetPendingFlowByUser(RunInfo.Instance.CurrentUser.UserName);

            this.gdPendingFlow.DataSource = list;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Approve, "审批"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "待审流程";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            FlowItem item = this.gvPendingFlow.GetFocusedRow() as FlowItem;
            if (item == null)
            {
                return;
            }
            if (operate.Operate == OperateTypes.Approve.ToString())
            {

                frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ApproveModel };
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }

            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmApprove form = new frmApprove() { FlowItem = item, WorkModel = EditFormWorkModels.Custom, CustomWorkModel = frmApprove.ApproveViewModel };
                form.ShowDialog(this);
      
            }
        }




    }
}