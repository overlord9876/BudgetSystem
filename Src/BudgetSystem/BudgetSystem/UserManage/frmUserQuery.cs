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
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.UserManage
{
    public partial class frmUserQuery : frmBaseQueryForm
    {

        private Bll.UserManager um = new Bll.UserManager();

        public frmUserQuery()
        {
            InitializeComponent();
            this.Module = BusinessModules.UserManagement;
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ReSetPassword));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));


            //注册查询我在基类里处理了，如果业务模块需要使用查询功能，可以像这里一样注册就行了
            // this.RegeditQueryOperate<UserQueryCondition>(true, new List<string> { "默认", "查询1", "查询2" });
            // this.RegeditPrintOperate();

            this.ModelOperatePageName = "用户管理";

        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

            base.OperateHandled(operate, e);

            if (operate.Operate == OperateTypes.New.ToString())
            {
                CreateUser();
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                ModifyUser();
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                ViewUser();
            }
            else if (operate.Operate == OperateTypes.Enabled.ToString())
            {
                EnableUser();
            }
            else if (operate.Operate == OperateTypes.Disabled.ToString())
            {
                DisableUser();
            }
            else if (operate.Operate == OperateTypes.ReSetPassword.ToString())
            {
                ReSetUserPassword();
            }
            else if (operate.Operate == OperateTypes.Print.ToString())
            {

            }
        }

        protected override void DoCommonQuery(string queryName)
        {
            XtraMessageBox.Show(queryName);
        }

        protected override void DoConditionQuery(BaseQueryCondition condition)
        {
            XtraMessageBox.Show(condition.ToString());
        }

        protected override QueryConditionEditorForm CreateConditionEditorForm()
        {
            frmUserQueryConditionEditor form = new frmUserQueryConditionEditor();
            form.QueryName = this.GetType().ToString();
            return form;
        }




        private void EnableUser()
        {
            if (this.gvUser.FocusedRowHandle < 0)
            {
                return;
            }
            User currentRowUser = this.gvUser.GetRow(this.gvUser.FocusedRowHandle) as User;
            if (currentRowUser != null)
            {
                um.ModifyUserState(currentRowUser.UserName, true);
                this.RefreshData();
                XtraMessageBox.Show("启用成功");
            }
        }

        private void DisableUser()
        {
            if (this.gvUser.FocusedRowHandle < 0)
            {
                return;
            }
            User currentRowUser = this.gvUser.GetRow(this.gvUser.FocusedRowHandle) as User;
            if (currentRowUser != null)
            {
                um.ModifyUserState(currentRowUser.UserName, false);
                this.RefreshData();
                XtraMessageBox.Show("停用成功");
            }
        }

        private void ReSetUserPassword()
        {
            if (this.gvUser.FocusedRowHandle < 0)
            {
                return;
            }
            User currentRowUser = this.gvUser.GetRow(this.gvUser.FocusedRowHandle) as User;
            if (currentRowUser != null)
            {
                um.ModifyUserPassword(currentRowUser.UserName, Util.SHA256.ToSHA256("1"));
                XtraMessageBox.Show("重置成功");
            }
        }

        private void CreateUser()
        {
            frmUserEdit form = new frmUserEdit();
            form.WorkModel = EditFormWorkModels.New;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.RefreshData();
            }
        }
        private void ModifyUser()
        {
            if (this.gvUser.FocusedRowHandle < 0)
            {
                return;
            }
            User currentRowUser = this.gvUser.GetRow(this.gvUser.FocusedRowHandle) as User;
            if (currentRowUser != null)
            {
                frmUserEdit form = new frmUserEdit();
                form.WorkModel = EditFormWorkModels.Modify;
                form.User = currentRowUser;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }

        private void ViewUser()
        {
            if (this.gvUser.FocusedRowHandle < 0)
            {
                return;
            }
            User currentRowUser = this.gvUser.GetRow(this.gvUser.FocusedRowHandle) as User;
            if (currentRowUser != null)
            {
                frmUserEdit form = new frmUserEdit();
                form.WorkModel = EditFormWorkModels.View;
                form.User = currentRowUser;
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            var list = um.GetAllUser();
            this.gridUser.DataSource = list;
        }

        protected override void InitGridViewAction()
        {
            this.gridViewAction.Add(this.gvUser, new ActionWithPermission() { MainAction = ModifyUser, MainOperate = OperateTypes.Modify, SecondAction = ViewUser, SecondOperate = OperateTypes.View });

        }

    }
}