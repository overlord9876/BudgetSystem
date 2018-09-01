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
    public partial class frmCustomerQuery : frmBaseQueryFormWithCondtion
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

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
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