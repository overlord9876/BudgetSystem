using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace BudgetSystem.RoleManage
{
    public partial class frmRoleQuery : frmBaseQueryForm
    {
        Bll.UserManager um = new Bll.UserManager();
        Bll.RoleManager rm = new Bll.RoleManager();

        public frmRoleQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
        }


        public override void OperateHandled(ModelOperate operate)
        {

        }

        public override void LoadData()
        {
            List<Role> roleList = rm.GetAllRole();
            this.gdRoleList.DataSource = roleList;


            BindAllUsers();
         
        }

      

        private void gvRoleList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                BindRoleUsers();
            
            }
        }

        private void BindAllUsers()
        {
            List<User> allUser = um.GetAllUser();
            this.gdAllUser.DataSource = allUser;
        }

        private void BindRoleUsers()
        {
            Role currentRole = this.gvRoleList.GetFocusedRow() as Role;
            if (currentRole != null)
            {
                List<User> roleUser = um.GetRoleUsers(currentRole.Code);
                this.gdRoleUsers.DataSource = roleUser;

            }
        }

        private void btnAddToRole_Click(object sender, EventArgs e)
        {
            Role currentRole = this.gvRoleList.GetFocusedRow() as Role;
            if (currentRole==null)
            {
                XtraMessageBox.Show("请选中待分配角色");
                return;
            }

            List<string> users = GetSelectUsers(gvAllUser);
            if (users.Count == 0)
            {
                XtraMessageBox.Show("请选中要分配的用户");
                return;
            }

            um.SetUserRole(users, currentRole.Code);
            BindRoleUsers();
            BindAllUsers();

        }

        private void btnRemveFromRole_Click(object sender, EventArgs e)
        {
            List<string> users = GetSelectUsers(gvRoleUsers);
            if (users.Count == 0)
            {
                XtraMessageBox.Show("请选中要撤销角色的用户");
                return;
            }

            um.SetUserRole(users, "");
            BindRoleUsers();
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
    }
}
