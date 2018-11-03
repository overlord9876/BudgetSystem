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

namespace BudgetSystem.WorkSpace
{
    public partial class frmApprove :  frmBaseDialogForm
    {
        public frmApprove()
        {
            InitializeComponent();
        }


        public FlowItem FlowItem
        {
            get;
            set;
        }

        private Bll.FlowManager fm = new Bll.FlowManager();


        public const string ApproveModel = "Approve";
        public const string ApproveViewModel = "ApproveView";
        public const string ConfirmModel = "Confirm";
        public const string ConfirmViewModel = "ConfirmView";

        private void frmApprove_Load(object sender, EventArgs e)
        {

            SetLayoutControlStyle();
            
            if (this.CustomWorkModel == ApproveModel)
            {
                this.Text = "流程审批";
            }
            else if (this.CustomWorkModel == ApproveViewModel)
            {
                this.Text = "查看流程审批";
            }
            else if (this.CustomWorkModel == ConfirmModel)
            {
                this.Text = "流程发起人确认审批结果";
            }
            else if (this.CustomWorkModel == ConfirmViewModel)
            {
                this.Text = "查看审批结果";
            }

            this.txtFlowName.Text = this.FlowItem.FlowName;
            this.txtDataItemID.Text = this.FlowItem.DateItemID.ToString();
            this.txtCreateUserRealName.Text = this.FlowItem.CreateUserRealName;
            this.dtCrateDate.EditValue = this.FlowItem.CreateDate;


            if (this.CustomWorkModel == ConfirmModel || this.CustomWorkModel == ConfirmViewModel)
            {
                this.txtResult.Text = this.FlowItem.ApproveResult ? "审批通过" : "审批不通过";
                this.dtEndDate.EditValue = this.FlowItem.CloseDateTime;
                this.txtCloseReason.Text = this.FlowItem.CloseReason;
            }

            List<FlowRunPoint> points = fm.GetFlowRunPointsByInstance(FlowItem.ID).Where(s=>s.State==true).ToList();
          
            

            this.gdApproveList.DataSource = points;


        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Submit(true);
        }

        private void btnNotAccept_Click(object sender, EventArgs e)
        {
            Submit(false);
        }

        private void Submit(bool result)
        {
            FlowRunState state = fm.SubmitFlow(this.FlowItem.RunPointID, result, this.txtMyInfo.Text.Trim());
            string info;
            if (state.Translate(out info))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(info);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!FlowItem.IsClosed)
            {
                XtraMessageBox.Show("当选中流程尚未审批完成，不可以确认");
                return;
            }


            FlowRunState state =fm.ConfirmFlowInstance(this.FlowItem.ID);
            string info;
            if (state.Translate(out info))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(info);
            }


        }

        private void txtDataItemID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShowDataItemView();    
        }

        private void ShowDataItemView()
        {
            //TODO:流程集成
            XtraMessageBox.Show("这里要基于DataItemID和DataType显示具体的业务数据View");
        }

    }
}
