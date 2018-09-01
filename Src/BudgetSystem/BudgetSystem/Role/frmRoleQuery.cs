using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem
{
    public partial class frmDepartmentQuery : frmBaseQueryForm
    {
        public frmDepartmentQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "流程管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

        }
    }
}
