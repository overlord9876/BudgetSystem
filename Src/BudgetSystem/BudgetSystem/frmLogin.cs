using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Properties;


namespace BudgetSystem
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Icon = Resources.logo;
        }

        Bll.UserManager um = new Bll.UserManager();
        Bll.RoleManager rm = new Bll.RoleManager();
        private void btnExit_Click(object sender, EventArgs e)
        {

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                dxErrorProvider1.SetError(this.txtUserName, "请输入用户名");
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                dxErrorProvider1.SetError(this.txtPassword, "请输入密码");
            }

            if (dxErrorProvider1.HasErrors)
            {
                return;
            }




            User user = um.Login(this.txtUserName.Text.Trim(), Util.SHA256.ToSHA256(this.txtPassword.Text.Trim()));

            if (user == null)
            {
                XtraMessageBox.Show("登录失败，用户名或密码错误！");
                return;
            }


            RunInfo.Instance.CurrentUser = user;
            RunInfo.Instance.UserPermission = rm.GetRolePermissions(user.Role);


            RunInfo.Instance.Config.UserName = this.txtUserName.Text;
            RunInfo.Instance.Config.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUserName.Text = RunInfo.Instance.Config.UserName;
        }
    }
}