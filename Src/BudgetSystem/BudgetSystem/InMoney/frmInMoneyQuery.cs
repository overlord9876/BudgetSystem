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
    public partial class frmInMoneyQuery : frmBaseQueryForm
    {
        public frmInMoneyQuery()
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
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改关联合同"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改入帐（未关联合同）"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除入账（未关联合同）"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看入账"));
 
            this.ModelOperatePageName = "入帐单";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmInMemoryEdit form = new frmInMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmInMemoryEdit form = new frmInMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmInMemoryEdit form = new frmInMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == "Test1")
            {
                XtraMessageBox.Show("Test1");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作1");
            }
        }
    }
}
