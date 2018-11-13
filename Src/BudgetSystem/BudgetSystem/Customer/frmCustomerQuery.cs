using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmCustomerQuery : frmBaseQueryForm
    {
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private GridHitInfo hInfo;

        public frmCustomerQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.CustomerManagement;
        }
        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Relate, "业务员维护"));
            this.ModelOperatePageName = "客户列表";
        }
        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                this.CreateCustomer();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                this.ModifyCustomer();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                this.ViewCustomer();
            }
            else if (operate.Operate == OperateTypes.Relate.ToString())
            {
                XtraMessageBox.Show("业务员维护");
            }
            else if (operate.Operate == OperateTypes.Enabled.ToString())
            {
                EnableCustomer();
            }
            else if (operate.Operate == OperateTypes.Disabled.ToString())
            {
                DisabledCustomer();
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }
       

        private void CreateCustomer()
        {
            frmCustomerEdit form = new frmCustomerEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            } 
        }
        private void ModifyCustomer()
        {
            Customer customer = this.gvCustomer.GetFocusedRow() as Customer;
            if (customer != null)
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.Customer = customer;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                } 
            }
        }
        private void ViewCustomer()
        {
            Customer currentRowCustomer = this.gvCustomer.GetFocusedRow() as Customer;
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.Customer = currentRowCustomer;
                form.ShowDialog(this);
            }
        }
        private void EnableCustomer()
        {
            Customer currentRowCustomer = this.gvCustomer.GetFocusedRow() as Customer;
            if (currentRowCustomer != null)
            {
                cm.ModifyCustomerState(currentRowCustomer.ID, true);
                this.RefreshData();
                XtraMessageBox.Show("启用成功");
            }
        }
        private void DisabledCustomer()
        {
            Customer currentRowCustomer = this.gvCustomer.GetFocusedRow() as Customer;
            if (currentRowCustomer != null)
            {
                cm.ModifyCustomerState(currentRowCustomer.ID, false);
                this.RefreshData();
                XtraMessageBox.Show("停用成功");
            }
        }

        public override void LoadData()
        {
            var list = cm.GetAllCustomer();
            this.gridCustomer.DataSource = list;
        }

        private void gvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyCustomer();
            }
        }

        private void gvCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvCustomer.CalcHitInfo(e.Y, e.Y);
        }


    }
}