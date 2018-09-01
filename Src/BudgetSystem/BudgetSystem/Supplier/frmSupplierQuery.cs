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
    public partial class frmSupplierQuery : frmBaseQueryFormWithCondtion
    {
        public frmSupplierQuery()
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
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Revoke));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));

            this.ModelOperatePageName = "供应商列表";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmSupplierEdit form = new frmSupplierEdit();
                form.ShowDialog(this);
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