using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using DevExpress.XtraGrid.Views.Grid;

namespace BudgetSystem
{
    public partial class frmCustomerEdit : frmBaseDialogForm
    {
        public Customer Customer { get; set; }
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.UserManager um = new Bll.UserManager();

        public frmCustomerEdit()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmCustomerEdit_Load);
        }


        private void frmCustomerEdit_Load(object sender, EventArgs e)
        {
            BindingAllUser();
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "创建客户";
                this.lcCreateUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lcCreateDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.gridSalesman.DataSource = new List<User>();
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑客户信息";
                BindingCustomer(Customer.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看客户信息";
                this.txtCountry.Properties.ReadOnly = true;
                this.txtName.Properties.ReadOnly = true;
                this.chkState.Properties.ReadOnly = true;
                this.meDescription.Properties.ReadOnly = true;
                this.btnAddSalesman.Enabled = false;
                this.btnRemoveSalesman.Enabled = false;
                BindingCustomer(Customer.ID);
            }
        }
        private void btnAddSalesman_Click(object sender, EventArgs e)
        {
            User currentUser = this.gvUser.GetFocusedRow() as User;
            if (currentUser == null)
            {
                XtraMessageBox.Show("请选中待选业务员");
                return;
            }

            List<User> selectUsers = GetSelectUsers(gvUser);
            if (selectUsers.Count == 0)
            {
                XtraMessageBox.Show("请选中待选业务员");
                return;
            }
            List<User> users = gvUser.DataSource as List<User>;
            List<User> salesmans = gvSalesman.DataSource as List<User>;
            selectUsers.ForEach(u => { users.Remove(u); salesmans.Add(u); });
            this.gridUser.RefreshDataSource();
            this.gridSalesman.RefreshDataSource();
        }

        private void btnRemoveSalesman_Click(object sender, EventArgs e)
        {
            User currentUser = this.gvSalesman.GetFocusedRow() as User;
            if (currentUser == null)
            {
                XtraMessageBox.Show("请选中跟单业务员");
                return;
            }

            List<User> selectUsers = GetSelectUsers(gvSalesman);
            if (selectUsers.Count == 0)
            {
                XtraMessageBox.Show("请选中跟单业务员");
                return;
            }
            List<User> users = gvUser.DataSource as List<User>;
            List<User> salesmans = gvSalesman.DataSource as List<User>;
            selectUsers.ForEach(u => { users.Add(u); salesmans.Remove(u); });
            this.gridUser.RefreshDataSource();
            this.gridSalesman.RefreshDataSource();
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
             SubmitDataByWorkModel();
        }
        private void BindingAllUser()
        {
            List<User> users = um.GetAllUser();
            this.gridUser.DataSource = users;
        }
        private void BindingCustomer(int id)
        {
            Customer customer = cm.GetCustomer(id);
            if (customer != null)
            {
                this.txtName.Text = customer.Name;
                this.txtCountry.Text = customer.Country;
                this.txtCreateDate.EditValue = customer.CreateDate;
                this.txtCreateUser.Text = customer.CreateUserName;
                this.chkState.Checked = customer.State;
                this.meDescription.Text = customer.Description;
                List<User> salesmanUserList = new List<User>();
                if (customer.SalesmanList != null && customer.SalesmanList.Count > 0)
                {
                    List<User> allUsers = this.gridUser.DataSource as List<User>;
                    User user;
                    foreach (var s in customer.SalesmanList)
                    {
                        user = allUsers.Find(u => u.UserName == s.Salesman);
                        salesmanUserList.Add(user);
                        allUsers.Remove(user);
                    }
                }
                this.gridSalesman.DataSource = salesmanUserList;
                this.gridUser.RefreshDataSource();
            }
        }

        private List<User> GetSelectUsers(GridView view)
        {
            List<User> result = new List<User>();
            int[] selectRows = view.GetSelectedRows();
            foreach (int row in selectRows)
            {
                User user = view.GetRow(row) as User;
                result.Add(user);
            }
            return result;
        }

        private void CheckNameInput()
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入客户名称");
            }
        }
        private void CheckCountry()
        {
            if (string.IsNullOrEmpty(this.txtCountry.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入国家或地区");
            }
        }


        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();
            this.CheckNameInput();
            this.CheckCountry();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            Customer customer = new Entity.Customer();
            customer.Name = this.txtName.Text.Trim();
            customer.Country = this.txtCountry.Text.Trim();
            customer.State = this.chkState.Checked;
            customer.Description = this.meDescription.Text.Trim();
            customer.CreateUser = RunInfo.Instance.CurrentUser.UserName;

            List<CustomerSalesman> salesmans = new List<CustomerSalesman>();
            List<User> users = this.gridSalesman.DataSource as List<User>;
            if (users != null && users.Count > 0)
            {
                users.ForEach(u => salesmans.Add(new CustomerSalesman() { Salesman = u.UserName }));
            }
            customer.SalesmanList = salesmans;
            int result = cm.AddCustomer(customer);

            if (result <= 0)
            {
                XtraMessageBox.Show("创建失败！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }



        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();
            this.CheckNameInput();
            this.CheckCountry();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }

            Customer.Name = this.txtName.Text.Trim();
            Customer.Country = this.txtCountry.Text.Trim();
            Customer.State = this.chkState.Checked;
            Customer.Description = this.meDescription.Text.Trim();
            List<CustomerSalesman> salesmans = new List<CustomerSalesman>();
            List<User> users = this.gridSalesman.DataSource as List<User>;
            if (users != null && users.Count > 0)
            {
                users.ForEach(u => salesmans.Add(new CustomerSalesman() { Salesman = u.UserName }));
            }
            Customer.SalesmanList = salesmans;
            cm.ModifyCustomer(Customer);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

      
    }
}