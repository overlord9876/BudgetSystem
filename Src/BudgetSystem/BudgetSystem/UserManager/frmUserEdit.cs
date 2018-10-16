﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Resources;
using BudgetSystem.Entity;
using BudgetSystem.Util;

namespace BudgetSystem.UserManager
{
    public partial class frmUserEdit : frmBaseDialogForm
    {
        public frmUserEdit()
        {
            InitializeComponent();
        }

        public User User
        {
            get;
            set;
        }

        public const string CustomWorkModel_ModifyPassword = "ModifyPassword";

        private Bll.UserManager um = new Bll.UserManager();


        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            this.layoutControl1.RestoreLayoutFromStream(this.GetResourceFileByCurrentWorkModel());
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "创建新用户";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.txtUserName.Properties.ReadOnly = true;
                this.Text = "编辑用户信息";
                BindingUser(User.UserName);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.txtUserName.Properties.ReadOnly = true;
                this.txtRealName.Properties.ReadOnly = true;
                this.txtCreateUser.Properties.ReadOnly = true;
                this.dtCreateDate.Properties.ReadOnly = true;
                this.cboDepartment.Properties.ReadOnly = true;
                this.cboRole.Properties.ReadOnly = true;
                
                this.Text = "查看用户信息";
                BindingUser(User.UserName);
            }
            else if (this.WorkModel == EditFormWorkModels.Custom && this.CustomWorkModel == CustomWorkModel_ModifyPassword)
            {
                this.Text = "修改密码";
            }
        }


        private void BindingUser(string userName)
        {
            User user = um.GetUser(userName);

            if (user != null)
            {
                this.txtUserName.Text = user.UserName;
                this.txtRealName.Text = user.RealName;
                this.txtCreateUser.Text = user.UpdateUser;
                this.dtCreateDate.EditValue = user.UpdateDateTime;
                this.chkIsEnable.Checked = user.State;
                //TODO: 绑定角色和部门
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
            
        }

       

        private void CheckUserNameInput()
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtUserName, "请输入用户名");
            }

        }

        private void CheckUserRealNameInput()
        {
            if (string.IsNullOrEmpty(this.txtRealName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtRealName, "请输入用户姓名");
            }
        }

        private void CheckPasswordInput()
        {

            if (string.IsNullOrEmpty(this.txtPasswrod.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtPasswrod, "请输入密码");
            }
            if (this.txtPasswrod.Text.Trim() != this.txtPasswordRepeat.Text.Trim())
            {
                this.dxErrorProvider1.SetError(this.txtPasswordRepeat, "两次输入密码不一致，请检查");
            }
        }


        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();
            CheckUserNameInput();
            CheckUserRealNameInput();
            CheckPasswordInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }

            User user = new User();
            user.UserName = this.txtUserName.Text.Trim();
            user.RealName = this.txtRealName.Text.Trim();
            user.Password = Util.SHA256.ToSHA256(this.txtPasswrod.Text.Trim());
            user.Role = this.cboRole.SelectedItem != null ? this.cboRole.SelectedItem.ToString() : "";
            user.Department = this.cboDepartment.SelectedItem != null ? this.cboDepartment.SelectedItem.ToString() : "";
            user.State = this.chkIsEnable.Checked;
            user.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
           
            int result= um.CreateUser(user);

            if (result == 2)
            {
                XtraMessageBox.Show("创建失败，相同用户名已存在，请检查！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();
            CheckUserRealNameInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }

            User user = new User();
            user.UserName = this.txtUserName.Text.Trim();
            user.RealName = this.txtRealName.Text.Trim();
            user.Role = this.cboRole.SelectedItem != null ? this.cboRole.SelectedItem.ToString() : "";
            user.Department = this.cboDepartment.SelectedItem != null ? this.cboDepartment.SelectedItem.ToString() : "";
            user.UpdateUser = RunInfo.Instance.CurrentUser.UserName;

            um.ModifyUserInfo(user);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitCustomData()
        {
            base.SubmitCustomData();
            if (this.CustomWorkModel == CustomWorkModel_ModifyPassword)
            {
                this.dxErrorProvider1.ClearErrors();
                CheckPasswordInput();
                if (dxErrorProvider1.HasErrors)
                {
                    return;
                }
                um.ModifyUserPassword(RunInfo.Instance.CurrentUser.UserName, Util.SHA256.ToSHA256(this.txtPasswrod.Text.Trim()), RunInfo.Instance.CurrentUser.UserName);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }



          



    }
}