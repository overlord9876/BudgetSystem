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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BudgetSystem.DepartmentManage
{
    public partial class frmDepartmentQuery : frmBaseQueryForm
    {
        private Bll.DepartmentManager dm = new Bll.DepartmentManager();
        private Bll.UserManager um = new Bll.UserManager();
        private GridHitInfo hInfo;

        public frmDepartmentQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "部门管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {
            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreateDepartment();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyDepartment();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewDepartment();
            }
        }

        private void CreateDepartment()
        {
            
            frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.New };
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }

      
        private void ModifyDepartment()
        {
            Department currentRowDepartment = this.gvDepartment.GetFocusedRow() as Department;
            if (currentRowDepartment != null)
            {
                frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.Modify,Department = currentRowDepartment };
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
            
        }

        private void ViewDepartment()
        {
            Department currentRowDepartment = this.gvDepartment.GetFocusedRow() as Department;
            if (currentRowDepartment != null)
            {
                frmDepartmentEdit form = new frmDepartmentEdit() { WorkModel = EditFormWorkModels.View, Department = currentRowDepartment };
                form.ShowDialog(this);
            }
        }
        public override void LoadData()
        {
            List<Department> departmentList = dm.GetAllDepartment();
            this.gdDepartment.DataSource = departmentList;


            BindAllUsers();
        }

        private void gvDepartment_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                BindDepartmentUsers();

            }
        }


        private void BindAllUsers()
        {
            List<User> allUser = um.GetAllUser();
            this.gdAllUser.DataSource = allUser;
        }

        private void BindDepartmentUsers()
        {
            Department currentDepartment = this.gvDepartment.GetFocusedRow() as Department;
            if (currentDepartment != null)
            {
                List<User> departmentUsers = um.GetDepartmentUsers(currentDepartment.Code);
                this.gdDepartmentUser.DataSource = departmentUsers;

            }
        }

        private void btnAddToDepartment_Click(object sender, EventArgs e)
        {
            Department currentDepartment = this.gvDepartment.GetFocusedRow() as Department;
            if (currentDepartment == null)
            {
                XtraMessageBox.Show("请选中待分配部门");
                return;
            }

            List<string> users = GetSelectUsers(gvAllUser);
            if (users.Count == 0)
            {
                XtraMessageBox.Show("请选中要分配的用户");
                return;
            }

            um.SetUserDepartment(users, currentDepartment.Code);
            BindDepartmentUsers();
            BindAllUsers();
        }

        private void btnRemoveFromDepartment_Click(object sender, EventArgs e)
        {
            List<string> users = GetSelectUsers(gvDepartmentUser);
            if (users.Count == 0)
            {
                XtraMessageBox.Show("请选中要撤销部门的用户");
                return;
            }

            um.SetUserDepartment(users, "");
            BindDepartmentUsers();
            BindAllUsers();
        }

        private List<string> GetSelectUsers(GridView view)
        {
            List<string> result = new List<string>();
            int[] selectRows = view.GetSelectedRows();
            foreach (int row in selectRows)
            {
                User user = view.GetRow(row) as User;

                result.Add(user.UserName);
            }

            return result;

        }

        private void gvDepartment_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = this.gvDepartment.CalcHitInfo(e.Y, e.Y);
        }

        private void gvDepartment_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyDepartment();
            }
        }
    }
}
