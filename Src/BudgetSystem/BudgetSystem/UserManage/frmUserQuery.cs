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
            this.ModelOperatePageName = "用户管理";

            //this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查询", UITypes.LargeMenu, new List<string>() { "查询1", "查询2", "查询3" }));


        }


        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {

            //if (operate.Operate == OperateTypes.View.ToString())
            //{
            //    MessageBox.Show(e.SenderText);
            //    return;
            //}

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




        }



        private void EnableUser()
        {
            User currentRowUser = this.gvUser.GetFocusedRow() as User;
            if (currentRowUser != null)
            {
                um.ModifyUserState(currentRowUser.UserName, true);
                this.RefreshData();
                XtraMessageBox.Show("启用成功");
            }
        }

        private void DisableUser()
        {
            User currentRowUser = this.gvUser.GetFocusedRow() as User;
            if (currentRowUser != null)
            {
                um.ModifyUserState(currentRowUser.UserName, false);
                this.RefreshData();
                XtraMessageBox.Show("停用成功");
            }
        }

        private void ReSetUserPassword()
        {
            User currentRowUser = this.gvUser.GetFocusedRow() as User;
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

            User currentRowUser = this.gvUser.GetFocusedRow() as User;
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
            User currentRowUser = this.gvUser.GetFocusedRow() as User;
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