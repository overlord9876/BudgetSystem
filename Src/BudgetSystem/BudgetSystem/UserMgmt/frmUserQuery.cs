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
    public partial class frmUserQuery : frmBaseQueryForm
    {
        public frmUserQuery()
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
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.New, "新增", "操作", 1, 2));
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.Modify, "修改", "操作", 2, 3));
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.Delete, "删除", "操作", 3, 4));
            this.ModelOperateRegistry.Add(new ModelOperate(OperateTypes.View, "查看", "查看", 1, 22));
            this.ModelOperatePageName = "用户管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                XtraMessageBox.Show("新增用户");
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                XtraMessageBox.Show("修改用户");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                XtraMessageBox.Show("查看用户信息");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }




    }
}