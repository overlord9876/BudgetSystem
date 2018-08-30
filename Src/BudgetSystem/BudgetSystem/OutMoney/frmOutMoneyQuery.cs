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
    public partial class frmOutMoneyQuery : frmBaseQueryForm
    {
        public frmOutMoneyQuery()
        {
            InitializeComponent();
            this.CanRefreshData = false;
        }

        public override void RefreshData()
        {
            XtraMessageBox.Show(this.Text);
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Revoke, "撤回"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "付款管理";
        }

        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmOutMemoryEdit form = new frmOutMemoryEdit();
                form.ShowDialog(this);
                XtraMessageBox.Show("付款");
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmOutMemoryEdit form = new frmOutMemoryEdit();
                form.ShowDialog(this);
                XtraMessageBox.Show("修改发票");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmOutMemoryEdit form = new frmOutMemoryEdit();
                form.ShowDialog(this);
                XtraMessageBox.Show("查看付款详情");
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
