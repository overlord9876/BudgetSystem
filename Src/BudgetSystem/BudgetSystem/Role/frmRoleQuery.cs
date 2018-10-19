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

namespace BudgetSystem
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



            List<User> allUser = um.GetAllUser();
            this.gdAllUser.DataSource = allUser;
           // List<User> userList = um.GetAllUser();
           // List<User> roleUserList = um.GetUsersByRole()


            //DataTable dt = new DataTable();
            //dt.Columns.Add("RoleName", typeof(string));
            //dt.Columns.Add("RoleDescription", typeof(string));

            //dt.Rows.Add("业务员", "提交审批单，修改审批单");
            //dt.Rows.Add("业务部经理", "审批流程单");
            //dt.Rows.Add("财务经理", "审批流程单，审批财务流程");
            //dt.Rows.Add("总经理", "审理所有流程");
            //this.gdRoleList.DataSource = dt;


            //DataTable userdt = new DataTable();
            //userdt.Columns.Add("Name");
            //userdt.Columns.Add("RealName");
            //userdt.Columns.Add("Role");
            //userdt.Columns.Add("State");

            //userdt.Rows.Add("User1", "张三", "业务员", "可用");
            //userdt.Rows.Add("User2", "李四", "业务员", "可用");
            //this.gdRoleUsers.DataSource = userdt;


            //DataTable userdt2 = new DataTable();
            //userdt2.Columns.Add("Name");
            //userdt2.Columns.Add("RealName");
            //userdt2.Columns.Add("Role");
            //userdt2.Columns.Add("State");

            //userdt2.Rows.Add("User3", "王五", "业务员", "可用");
            //userdt2.Rows.Add("User4", "赵六", "业务员", "停用");
            //this.gdAllUser.DataSource = userdt2;
        }

        private void gvRoleList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                BindingRoleUsers();
            
            }
        }

        private void BindingRoleUsers()
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
            BindingRoleUsers();


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
            BindingRoleUsers();
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
