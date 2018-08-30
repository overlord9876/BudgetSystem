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
    public partial class frmCustomerQuery : frmBaseQueryForm
    {
        public frmCustomerQuery()
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
            this.ModelOperatePageName = "客户列表";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                XtraMessageBox.Show("View");
            }
            else if (operate.Operate == OperateTypes.Revoke.ToString())
            {
                XtraMessageBox.Show("Revoke");
            }
            else if (operate.Operate == "Test")
            {
                XtraMessageBox.Show("Test");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }




    }
}