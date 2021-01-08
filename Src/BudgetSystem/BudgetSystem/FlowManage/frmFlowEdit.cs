using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using System.Linq;
using DevExpress.XtraEditors;

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
        private bool isInit = true;

        private void frmFlowEdit_Load(object sender, EventArgs e)
        {


            userList = um.GetAllUser();
            userList.Insert(0, new User() { UserName = FlowConst.FlowCreateUser, RealName = FlowConst.FlowCreateUserDisplayName, State = true });

            departmentList = dm.GetAllDepartment();
            departmentList.Insert(0, new Department() { Code = FlowConst.FlowCreateUserDepartment, Name = FlowConst.FlowCreateUserDepartmentDisplayName, ID = -1 });


            if (this.WorkModel == EditFormWorkModels.Modify)
            {
                SetLayoutControlStyle(EditFormWorkModels.Modify);
                this.txtName.Properties.ReadOnly = true;
                this.Text = "修改流程配置";

                this.cboNodeUser.Properties.Items.AddRange(userList.Where(u => u.State == true).ToList());

                this.cboNodeDepartment.Properties.Items.AddRange(departmentList);

                BindFlow(Flow.Name, Flow.VersionNumber);
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

            isInit = false;
        }

        public void SetVersionReadOnly()
        {
            this.cboVersion.Properties.ReadOnly = true;
        }



        private void BindFlow(string flowName, int flowVersion)
        {
            currentFlow = fm.GetFlow(flowName, flowVersion);
            this.txtName.Text = currentFlow.Name;
            this.txtRemark.Text = currentFlow.Remark;
            this.txtCreaateUser.Text = currentFlow.CreateUser;
            this.dtUpdateDate.EditValue = currentFlow.UpdateDate;

            currentFlowDetial = fm.GetFlowDetail(flowName, flowVersion);
            currentFlowDetial.RemoveAll(o => o.IsStartNode);

            foreach (var node in currentFlowDetial)
            {
                if (node.NodeConfig == 0)
                {
                    node.NodeValueDisplayValue = userList.Single(s => s.UserName == node.NodeValue).ToString();
                }
                else
                {
                    Department department = departmentList.SingleOrDefault(s => s.Code.Equals(node.NodeValue) || s.ID.ToString().Equals(node.NodeValue));
                    if (department != null)
                    {
                        node.NodeValueDisplayValue = department.ToString();
                    }
                }
            }


            this.gdNodes.DataSource = currentFlowDetial;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }


        private bool CheckInput()
        {
            if (this.currentFlowDetial.Count == 0)
            {
                XtraMessageBox.Show("流程配置信息为空，请配置审批过程！");
                return false;
            }

            foreach (var node in currentFlowDetial)
            {
                if (string.IsNullOrEmpty(node.NodeValue) || string.IsNullOrEmpty(node.NodeValueRemark))
                {

                    XtraMessageBox.Show("请配置节点的审批人及职位信息");
                    return false;
                }

            }

            return true;
        }

        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();

            if (!CheckInput())
            {
                return;
            }

            Flow flow = new Flow();
            flow.Name = Flow.Name;
            flow.Remark = this.txtRemark.Text.Trim();
            flow.CreateUser = RunInfo.Instance.CurrentUser.UserName;

            flow.Details = new List<FlowNode>();
            currentFlowDetial.Insert(0, new FlowNode() { IsStartNode = true, Name = Flow.Name, NodeConfig = 0, NodeValue = "%StartUser%", NodeValueRemark = "业务发起人" });
            flow.Details.AddRange(currentFlowDetial);

            fm.SaveFlow(flow);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                this.currentFlowDetial.Insert(i, new FlowNode());
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

        private void repositoryItemPopupContainerEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.gvNodes.FocusedRowHandle < 0)
            {
                return;
            }
            FlowNode node = this.gvNodes.GetRow(this.gvNodes.FocusedRowHandle) as FlowNode;
            if (node != null)
            {
                if (node.NodeConfig == 0)
                {
                    this.tabControl.SelectedTabPage = tpUser;
                    this.cboNodeUser.SelectedItem = userList.SingleOrDefault(u => u.UserName == node.NodeValue);
                    this.cboNodeDepartment.SelectedItem = null;
                }
                else
                {
                    this.tabControl.SelectedTabPage = tpDepartment;
                    this.cboNodeDepartment.SelectedItem = departmentList.SingleOrDefault(d => d.ID.ToString() == node.NodeValue || d.Code.ToString() == node.NodeValue);
                    this.rgNodeDepartmentUserType.EditValue = node.NodeConfig;
                    this.cboNodeUser.SelectedItem = null;
                }

            }
        }

        private void btnSureNodeValue_Click(object sender, EventArgs e)
        {
            if (this.gvNodes.FocusedRowHandle < 0)
            {
                return;
            }
            FlowNode node = this.gvNodes.GetRow(this.gvNodes.FocusedRowHandle) as FlowNode;
            if (node != null)
            {
                CheckAndCollectNodeInput(ref node);
                if (dxErrorProvider1.HasErrors)
                {
                    return;
                }
            }
            this.gdNodes.RefreshDataSource();

            this.gvNodes.CloseEditor();
        }

        private void CheckAndCollectNodeInput(ref FlowNode node)
        {
            this.dxErrorProvider1.ClearErrors();
            if (this.tabControl.SelectedTabPage == tpUser)
            {
                if (this.cboNodeUser.SelectedItem == null)
                {
                    this.dxErrorProvider1.SetError(this.cboNodeUser, "请选择审批人");
                    return;
                }

                node.NodeConfig = 0;
                node.NodeValue = (this.cboNodeUser.SelectedItem as User).UserName;
                node.NodeValueDisplayValue = this.cboNodeUser.SelectedItem.ToString();
            }
            else if (this.tabControl.SelectedTabPage == tpDepartment)
            {
                if (this.cboNodeDepartment.SelectedItem == null)
                {
                    this.dxErrorProvider1.SetError(this.cboNodeDepartment, "请选择审批部门");
                    return;
                }
                node.NodeConfig = (int)this.rgNodeDepartmentUserType.EditValue;
                int deptId = (this.cboNodeDepartment.SelectedItem as Department).ID;
                if (deptId == -1)
                {
                    node.NodeValue = (this.cboNodeDepartment.SelectedItem as Department).Code.ToString();
                }
                else
                {
                    node.NodeValue = deptId.ToString();
                }
                node.NodeValueDisplayValue = this.cboNodeDepartment.SelectedItem.ToString();
            }



        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInit)
            {
                BindFlow(Flow.Name, (int)this.cboVersion.SelectedItem);
            }
        }




    }
}
