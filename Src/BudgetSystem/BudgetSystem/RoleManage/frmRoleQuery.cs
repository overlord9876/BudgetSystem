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
using System.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BudgetSystem.RoleManage
{
    public partial class frmRoleQuery : frmBaseQueryForm
    {
        Bll.UserManager um = new Bll.UserManager();
        Bll.RoleManager rm = new Bll.RoleManager();

        public frmRoleQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.RoleManagement;


            if (!this.CheckPermission(OperateTypes.DistributeRolePermission))
            {
                this.btnAddPermissionToRole.Enabled = false;
                this.btnRemvePermissionFromRole.Enabled = false;
            }
            if (!this.CheckPermission(OperateTypes.DistributeRoleUser))
            {
                this.btnAddUserToRole.Enabled = false;
                this.btnRemveUserFromRole.Enabled = false;
            }
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

        }

        public override void LoadData()
        {
            List<Role> roleList = rm.GetAllRole();
            this.gdRoleList.DataSource = roleList;


            BindAllUsers();
            BindAllPermissions();
         
        }

        private void gvRoleList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                BindRoleUsers();
                BindRolePermissions();
                BindAllPermissions();
            }
        }

        private void BindAllUsers()
        {
            List<User> allUser = um.GetAllUser();
            this.gdAllUser.DataSource = allUser;
        }

        //private void BindAllPermissions()
        //{
        //    List<Permisson> permissions = Permisson.Permissions;
        //    this.gdAllPermission.DataSource = permissions;
        //}

        private void BindAllPermissions()
        {
            List<Permisson> existPermission = this.gdRolePermissions.DataSource as List<Permisson>;
            List<Permisson> permissions = Permisson.Permissions;
            if (existPermission != null)
            {
                List<Permisson> NotContainPermissions = new List<Permisson>();
                NotContainPermissions.AddRange(permissions.Where(s => !existPermission.Contains(s)));
                NotContainPermissions = NotContainPermissions.OrderBy(s => s.DisplayOrder).ToList();
                this.gdAllPermission.DataSource = NotContainPermissions;
            }
            else
            {
                this.gdAllPermission.DataSource = permissions;
            }
            this.gvAllPermission.ExpandAllGroups();

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

        private void BindRolePermissions()
        {
            Role currentRole = this.gvRoleList.GetFocusedRow() as Role;
            if (currentRole != null)
            {
                List<string> rolePermission = rm.GetRolePermissions(currentRole.Code);

                List<Permisson> pList = new List<Permisson>();

                foreach (string s in rolePermission)
                {
                    var p = Permisson.GetPermission(s);
                    if (p != null)
                    {
                        pList.Add(p);
                    }
                   
                }
                pList= pList.OrderBy(s => s.DisplayOrder).ToList();
                this.gdRolePermissions.DataSource = pList;
                this.gvRolePermissons.ExpandAllGroups();
            }
        }


        private void btnAddUserToRole_Click(object sender, EventArgs e)
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

        private void btnRemveUserFromRole_Click(object sender, EventArgs e)
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



        private void btnAddPermissionToRole_Click(object sender, EventArgs e)
        {
            Role currentRole = this.gvRoleList.GetFocusedRow() as Role;
            if (currentRole == null)
            {
                XtraMessageBox.Show("请选中待分配角色");
                return;
            }

            List<string> ps = this.GetSelectPermissions(gvAllPermission);
            if (ps.Count == 0)
            {
                XtraMessageBox.Show("请选中要分配的权限");
                return;
            }

            this.rm.AddRolePermission(currentRole.Code, ps);
            BindRolePermissions();
            BindAllPermissions();
            this.gvAllPermission.ExpandAllGroups();
            this.gvRolePermissons.ExpandAllGroups();

        }

        private void btnRemvePermissionFromRole_Click(object sender, EventArgs e)
        {
            Role currentRole = this.gvRoleList.GetFocusedRow() as Role;
            if (currentRole == null)
            {
                XtraMessageBox.Show("请选中待分配角色");
                return;
            }

            List<string> ps = GetSelectPermissions(gvRolePermissons);
            if (ps.Count == 0)
            {
                XtraMessageBox.Show("请选中要撤销角色权限");
                return;
            }


            rm.RemoveRolePermission(currentRole.Code, ps);
            BindRolePermissions();
            BindAllPermissions();
            this.gvAllPermission.ExpandAllGroups();
            this.gvRolePermissons.ExpandAllGroups();
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


        private List<string> GetSelectPermissions(GridView view)
        {
            List<string> result = new List<string>();
            int[] selectRows = view.GetSelectedRows();
            foreach (int row in selectRows)
            {
                if (row >= 0)
                {
                    Permisson p = view.GetRow(row) as Permisson;
                    result.Add(p.Code);
                }
                else
                {
                    result.AddRange(GetGroupedRow(row, view).ToArray());
                }

             
            }
            return result.Distinct().ToList();
        }


        private List<string> GetGroupedRow(int row, GridView view)
        {
            int groupedRowCount = view.GetChildRowCount(row);
            List<string> result = new List<string>();
            for (int i = 0; i < groupedRowCount; i++)
            {
                int crow = view.GetChildRowHandle(row, i);
                Permisson p = view.GetRow(crow) as Permisson;
                result.Add(p.Code);
            }
            return result;
        
        
        }



        private void gv_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo GridGroupRowInfo = e.Info as GridGroupRowInfo;
            if (GridGroupRowInfo.Column == gridColumn2 || GridGroupRowInfo.Column == gridColumn1)
            {
                GridGroupRowInfo.GroupText = Permisson.Permissions.Single(s => s.DisplayOrder == (int)GridGroupRowInfo.EditValue).DisplayName;
            }
        
      
        }



    }
}
