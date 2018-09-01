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
    public partial class frmRoleQuery : frmBaseQueryForm
    {
        public frmRoleQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete));
            this.ModelOperatePageName = "部门管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.New };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.Modify };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                XtraMessageBox.Show("删除");
            }
        }
    }
}
