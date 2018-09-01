using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmMyFlowListQuery : frmBaseQueryForm
    {
        public frmMyFlowListQuery()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            XtraMessageBox.Show(this.Text);
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Revoke));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "我的流程单";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.View.ToString())
            {
                frmBudgetEditEx form = new frmBudgetEditEx();
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




    }
}