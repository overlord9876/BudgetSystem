using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;

namespace BudgetSystem.DepartmentManage
{
    public partial class frmDepartmentEdit : frmBaseDialogForm
    {
        private string departmentCode;

        public frmDepartmentEdit()
        {
            InitializeComponent();
        }

        public Department Department
        {
            get;
            set;
        }

        private Bll.UserManager um = new Bll.UserManager();
        private Bll.DepartmentManager dm = new Bll.DepartmentManager();

        private void frmDepartmentEdit_Load(object sender, EventArgs e)
        {
            List<User> userList = um.GetAllEnabledUser();
            this.cboManager.Properties.Items.AddRange(userList);
            this.cboAssistantManager.Properties.Items.AddRange(userList);

            if (this.WorkModel == EditFormWorkModels.New)
            {
                SetLayoutControlStyle(EditFormWorkModels.New);
                this.Text = "创建新部门";
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                SetLayoutControlStyle(EditFormWorkModels.New);
                //this.txtCode.Properties.ReadOnly = true;
                this.Text = "编辑部门信息";
                departmentCode = Department.Code;
                BindDepartment(Department.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetLayoutControlStyle(EditFormWorkModels.Default);
                this.txtCode.Properties.ReadOnly = true;
                this.txtName.Properties.ReadOnly = true;
                this.txtCreateUser.Properties.ReadOnly = true;
                this.dtUpdateDate.Properties.ReadOnly = true;
                this.cboManager.Properties.ReadOnly = true;
                this.cboAssistantManager.Properties.ReadOnly = true;
                this.txtRemark.Properties.ReadOnly = true;

                this.Text = "查看部门信息";
                BindDepartment(Department.ID);
            }

        }


        private void BindDepartment(int deptID)
        {

            Department department = dm.GetDepartment(deptID);

            if (department != null)
            {
                this.txtCode.Text = department.Code;
                this.txtName.Text = department.Name;
                foreach (User user in this.cboManager.Properties.Items)
                {
                    if (user.UserName == department.Manager)
                    {
                        this.cboManager.SelectedItem = user;
                        break;
                    }
                }

                foreach (User user in this.cboAssistantManager.Properties.Items)
                {
                    if (user.UserName == department.Manager)
                    {
                        this.cboAssistantManager.SelectedItem = user;
                        break;
                    }
                }
                this.txtCreateUser.Text = department.CreateUser;
                this.dtUpdateDate.EditValue = department.UpdateDatetime;
                this.txtRemark.Text = department.Remark;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void CheckInput()
        {
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtCode, "请输入部门标识");
            }

            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txtName, "请输入部门名称");
            }

            if (this.cboManager.SelectedItem == null)
            {
                this.dxErrorProvider1.SetError(this.cboManager, "请选择部门经理");
            }

            if (this.cboAssistantManager.SelectedItem == null)
            {
                this.dxErrorProvider1.SetError(this.cboAssistantManager, "请选择部门副经理");
            }
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();
            CheckInput();

            if (dxErrorProvider1.HasErrors)
            {
                return;
            }

            Department department = new Department();
            department.Code = this.txtCode.Text.Trim();
            department.Name = this.txtName.Text.Trim();
            department.Remark = this.txtRemark.Text.Trim();
            department.Manager = (this.cboManager.SelectedItem as User).UserName;
            department.AssistantManager = (this.cboAssistantManager.SelectedItem as User).UserName;
            department.CreateUser = RunInfo.Instance.CurrentUser.UserName;
            if (dm.CheckDepartmentCode(department.ID, department.Code))
            {
                XtraMessageBox.Show("相同部门标识已存在，请检查！");
                return;
            }

            int result = dm.CreateDepartment(department);
            department.ID = result;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors();
            CheckInput();
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            if (dm.CheckDepartmentCode(Department.ID, this.txtCode.Text.Trim()))
            {
                XtraMessageBox.Show("相同部门标识已存在，请检查！");
                return;
            }
            this.Department.Code = this.txtCode.Text.Trim();
            this.Department.Name = this.txtName.Text.Trim();
            this.Department.Remark = this.txtRemark.Text.Trim();
            this.Department.Manager = (this.cboManager.SelectedItem as User).UserName;
            this.Department.AssistantManager = (this.cboAssistantManager.SelectedItem as User).UserName;
            this.Department.CreateUser = RunInfo.Instance.CurrentUser.UserName;

            dm.ModifyDepartmentInfo(this.Department);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }




    }

}
