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

namespace BudgetSystem.UserManager
{
    public partial class frmUserQuery : frmBaseQueryForm

    {

        private Bll.UserManager um = new Bll.UserManager();
        private GridHitInfo hInfo;

        public frmUserQuery()
        {
            InitializeComponent();
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
        }


        public override void OperateHandled(ModelOperate operate)
        {

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
            var list= um.GetAllUser();
            this.gridUser.DataSource = list;
        }

        private void gvUser_DoubleClick(object sender, EventArgs e)
        {
            if (hInfo.InRow)
            {
                ModifyUser();
            }
        }
       
        private void gvUser_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvUser.CalcHitInfo(e.Y, e.Y);
        }



    }
}