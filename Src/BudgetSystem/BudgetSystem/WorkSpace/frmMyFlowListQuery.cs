using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem.WorkSpace
{
    public partial class frmMyFlowListQuery : frmBaseQueryForm
    {
        public frmMyFlowListQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我的流程单";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.View.ToString())
            {
                frmBudgetEdit form = new frmBudgetEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Revoke.ToString())
            {
                XtraMessageBox.Show("撤回选中流程");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }



        public override void RefreshData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ApprovalType", typeof(string));
            dt.Columns.Add("ApprovalName", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("CommitDate", typeof(DateTime));
            dt.Columns.Add("CreateTime", typeof(DateTime));

            dt.Rows.Add("预算单审批", "XXX流程审批", "审批中", DateTime.Now, DateTime.Now);
            dt.Rows.Add("合格供方审批", "XXX流程审批", "审批不通过", DateTime.Now, DateTime.Now);
            dt.Rows.Add("财务付款", "XXX流程审批", "审批通过", DateTime.Now, DateTime.Now);
            dt.Rows.Add("预算单审批", "XXX流程审批", "审批中", DateTime.Now, DateTime.Now);

            this.gridControl1.DataSource = dt;
        }


    }
}