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
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.New, "新增入账", "操作", 1, 2));
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.Modify, "修改入账", "操作", 2, 3));
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.Delete, "删除入账", "操作", 3, 4));
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.View, "查看入账", "查看", 1, 22));
            this.ModelOperatePageName = "入帐单";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                XtraMessageBox.Show("新增入账");
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                XtraMessageBox.Show("修改入账");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                XtraMessageBox.Show("查看入账");
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
