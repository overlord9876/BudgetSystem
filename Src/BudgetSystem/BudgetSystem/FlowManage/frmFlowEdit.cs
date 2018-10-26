using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;

namespace BudgetSystem.FlowManage
{
    public partial class frmFlowEdit : frmBaseDialogForm
    {
        public frmFlowEdit()
        {
            InitializeComponent();
        }


        public Flow Flow
        {
            get;
            set;
        }

        private Bll.UserManager um = new Bll.UserManager();
        private Bll.FlowManager fm = new Bll.FlowManager();
        private Bll.DepartmentManager dm = new Bll.DepartmentManager();

        private List<User> userList;
        private List<Department> departmentList;
        private List<FlowNode> currentFlowDetial;
        private Flow currentFlow;

        private void frmFlowEdit_Load(object sender, EventArgs e)
        {
            userList = um.GetAllEnabledUser();
            departmentList = dm.GetAllDepartment();
         
            if (this.WorkModel == EditFormWorkModels.Modify)
            {
                SetLayoutControlStyle(EditFormWorkModels.Modify);
                this.txtName.Properties.ReadOnly = true;
                this.Text = "修改流程配置";
                BindFlow(Flow.Name,Flow.VersionNumber);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
              


                SetLayoutControlStyle(EditFormWorkModels.View);

                for (int i = 1; i <= Flow.VersionNumber; i++)
                {
                    this.cboVersion.Properties.Items.Add(i);
                }
                if (this.Flow.VersionNumber > 0)
                {
                    this.cboVersion.SelectedItem = Flow.VersionNumber;
                }

                this.txtName.Properties.ReadOnly = true;
                this.txtRemark.Properties.ReadOnly = true;

                this.gvNodes.OptionsBehavior.Editable = false;

                this.Text = "修改流程配置及历史版本信息";
                BindFlow(Flow.Name, Flow.VersionNumber);
            }
        }

        private void BindFlow(string flowName, int flowVersion)
        {
            currentFlow = fm.GetFlow(flowName, flowVersion);
            this.txtName.Text = currentFlow.Name;
            this.txtRemark.Text = currentFlow.Remark;
            this.txtCreaateUser.Text = currentFlow.CreateUser;
            this.dtUpdateDate.EditValue = currentFlow.UpdateDate;

            currentFlowDetial = fm.GetFlowDetail(flowName, flowVersion);
            this.gdNodes.DataSource = currentFlowDetial;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }


        private void CheckInput()
        { 
        
        }

        protected override void SubmitModifyData()
        {
            //base.SubmitModifyData();
            //this.dxErrorProvider1.ClearErrors();
            //CheckUserRealNameInput();
            //if (dxErrorProvider1.HasErrors)
            //{
            //    return;
            //}

            //User user = new User();
            //user.UserName = this.txtUserName.Text.Trim();
            //user.RealName = this.txtRealName.Text.Trim();
            //user.Role = this.cboRole.SelectedItem as Role != null ? (this.cboRole.SelectedItem as Role).Code : "";
            //user.Department = this.cboDepartment.SelectedItem as Department != null ? (this.cboDepartment.SelectedItem as Department).Code : "";

            //um.ModifyUserInfo(user);

            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.currentFlowDetial.Add(new FlowNode());
            this.gdNodes.RefreshDataSource();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int i = this.gvNodes.FocusedRowHandle;
            if (i >= 0)
            {
                this.currentFlowDetial.Insert(i,new FlowNode());
                this.gdNodes.RefreshDataSource();
            }




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = this.gvNodes.FocusedRowHandle;
            if (i >= 0)
            {
                this.currentFlowDetial.RemoveAt(i);
                this.gdNodes.RefreshDataSource();
            }
        }
    }
}
