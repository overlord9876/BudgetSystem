﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem
{
    public partial class frmCustomerQuery : frmBaseQueryForm
    {
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private const string COMMONQUERY_MYCREATE = "我创建的";
        CustomerQueryCondition currentCondition = null;
        public frmCustomerQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.CustomerManagement;
            this.KeyPreview = true;
            KeyDown += new KeyEventHandler(frmCustomerQuery_KeyDown);
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));

            this.RegeditQueryOperate<CustomerQueryCondition>(true, new List<string> { COMMONQUERY_MYCREATE }, "客户查询");

            this.ModelOperatePageName = "客户列表";
        }
        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
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
            else if (operate.Operate == OperateTypes.Enabled.ToString())
            {
                EnableCustomer();
            }
            else if (operate.Operate == OperateTypes.Disabled.ToString())
            {
                DisabledCustomer();
            }

        }

        protected override void DoCommonQuery(string queryName)
        {
            if (COMMONQUERY_MYCREATE.Equals(queryName))
            {
                CustomerQueryCondition condition = new CustomerQueryCondition() { CreateUser = RunInfo.Instance.CurrentUser.UserName };
                LoadData(condition);
            }
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            this.LoadData((CustomerQueryCondition)condition);
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmCustomerQueryConditionEditor form = new frmCustomerQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            form.QueryCondition = this.currentCondition;
            return form;
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
            else
            {
                XtraMessageBox.Show("请选择需要修改的项");
            }
        }
        private void ViewCustomer()
        {
            Customer currentRowCustomer = this.gvCustomer.GetFocusedRow() as Customer;
            if (currentRowCustomer != null)
            {
                frmCustomerEdit form = new frmCustomerEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.Customer = currentRowCustomer;
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("请选择需要查看详情的项");
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
            else
            {
                XtraMessageBox.Show("请选择需要启用的项");
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
            else
            {
                XtraMessageBox.Show("请选择需要停用的项");
            }
        }

        private void LoadData(CustomerQueryCondition condition)
        {
            currentCondition = condition;
            var list = cm.GetAllCustomer(condition);
            this.gridCustomer.DataSource = list;
        }

        public override void LoadData()
        {
            LoadData(null);
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvCustomer, new ActionWithPermission() { MainAction = ModifyCustomer, MainOperate = OperateTypes.Modify, SecondAction = ViewCustomer, SecondOperate = OperateTypes.View });

        }

        private void frmCustomerQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I && e.Control)
            {
                frmCustomImport frm = new frmCustomImport();
                frm.ShowDialog();
            }
        }

    }
}