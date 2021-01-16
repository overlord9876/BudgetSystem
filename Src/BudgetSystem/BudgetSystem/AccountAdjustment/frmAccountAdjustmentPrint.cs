using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using Newtonsoft.Json;

namespace BudgetSystem
{
    public partial class frmAccountAdjustmentPrint : frmBaseDialogForm
    {
        private AccountAdjustmentManager aamManager = new AccountAdjustmentManager();
        private Bll.FlowManager fm = new FlowManager();
        private Bll.DepartmentManager dm = new DepartmentManager();
        private Bll.UserManager um = new UserManager();

        public PaymentNotes CurrentPaymentNotes { get; set; }

        public int ID { get; private set; }

        public AdjustmentType AdjustmentType { get; private set; }

        public frmAccountAdjustmentPrint()
        {
            InitializeComponent();
        }

        public void BindData(int id, AdjustmentType atType)
        {
            this.ID = id;
            this.AdjustmentType = atType;
        }

        private void frmAccountAdjustmentPrint_Load(object sender, EventArgs e)
        {
            this.Text = "调账信息打印";

            var adjustment = aamManager.GetAccountAdjustment(this.ID, AdjustmentType);
            if (adjustment == null)
            {
                XtraMessageBox.Show("调账信息缺失，请刷新后再试。");
                return;
            }
            var users = um.GetAllEnabledUser();
            var user = users?.FirstOrDefault(o => o.UserName == adjustment.CreateUser);
            txtDept.Text = user?.DepartmentName ?? "";
            EnumFlowDataType flowDataType = EnumFlowDataType.交单调账;
            if (adjustment.Type == AdjustmentType.付款)
            {
                flowDataType = EnumFlowDataType.付款调账;
            }
            else if (adjustment.Type == AdjustmentType.收款)
            {
                flowDataType = EnumFlowDataType.收款调账;
            }
            var adjustmentDetail = aamManager.GetAccountAdjustmentDetailByTypeId(this.ID, AdjustmentType);

            txtBudget.Text = adjustment.ContractNO;

            lcilciFlowNode1.Width = this.Width / 8;
            lcitxtFlowNode1.Width = this.Width / 8;
            lcilciFlowNode2.Width = this.Width / 8;
            lcitxtFlowNode2.Width = this.Width / 8;
            lcilciFlowNode3.Width = this.Width / 8;
            lcitxtFlowNode3.Width = this.Width / 8;
            lcilciFlowNode4.Width = this.Width / 8;
            lcitxtFlowNode4.Width = this.Width / 8;

            lciFlowNode1.Text = "";
            txtFlowNode1.Text = "";
            lciFlowNode2.Text = "";
            txtFlowNode2.Text = "";
            lciFlowNode3.Text = "";
            txtFlowNode3.Text = "";
            lciFlowNode4.Text = "";
            txtFlowNode4.Text = "";
            if (adjustment.EnumRole == AdjustmentRole.业务员调账 && adjustment.EnumFlowState == EnumDataFlowState.审批通过)
            {
                var flowNodes = fm.GetFlowDetail(EnumFlowNames.调账审批流程);
                List<FlowRunPoint> points = fm.GetIsRecentFlowRunPointsByData(adjustment.ID, flowDataType.ToString());

                if (flowNodes != null && flowNodes.Count == 4 && points != null && points.Count >= 4)
                {
                    lciFlowNode1.Text = flowNodes[0].NodeValueRemark;
                    txtFlowNode1.Text = users?.FirstOrDefault(o => o.UserName == points[points.Count - 4].NodeApproveUser).RealName;
                    lciFlowNode2.Text = flowNodes[1].NodeValueRemark;
                    txtFlowNode2.Text = users?.FirstOrDefault(o => o.UserName == points[points.Count - 3].NodeApproveUser).RealName;
                    lciFlowNode3.Text = flowNodes[2].NodeValueRemark;
                    txtFlowNode3.Text = users?.FirstOrDefault(o => o.UserName == points[points.Count - 2].NodeApproveUser).RealName;
                    lciFlowNode4.Text = flowNodes[3].NodeValueRemark;
                    txtFlowNode4.Text = users?.FirstOrDefault(o => o.UserName == points[points.Count - 1].NodeApproveUser).RealName;
                }
            }
            else if (adjustment.EnumFlowState == EnumDataFlowState.审批通过)
            {
                lciFlowNode1.Visible = true;
                lciFlowNode2.Visible = true;
                txtFlowNode1.Visible = true;
                txtFlowNode2.Visible = true;
                var flowNodes = fm.GetFlowDetail(EnumFlowNames.财务调账审批流程);
                List<FlowRunPoint> points = fm.GetIsRecentFlowRunPointsByData(adjustment.ID, flowDataType.ToString());

                if (flowNodes != null && flowNodes.Count == 2 && points != null && points.Count >= 2)
                {
                    lciFlowNode1.Text = flowNodes[0].NodeValueRemark;
                    lciFlowNode4.Text = flowNodes[1].NodeValueRemark;
                    txtFlowNode1.Text = users?.FirstOrDefault(o => o.UserName == points[points.Count - 2].NodeApproveUser).RealName;
                    txtFlowNode4.Text = users?.FirstOrDefault(o => o.UserName == points[points.Count - 1].NodeApproveUser).RealName;
                }
            }
            string date = adjustment.Date.ToString("yyyy年MM月dd日");
            string type = adjustment.Type == AdjustmentType.付款 ? "付给" : "收到";
            string message = $"请将{adjustment.ContractNO}合同中{date}{type}{adjustment.Name}的￥{ adjustment.CNY.ToString("N2")}元中的￥{adjustment.AlreadySplitCNY.ToString("N2")}";
            if (adjustmentDetail != null)
            {
                if (adjustmentDetail.Count > 1)
                {
                    message += "分别转至";
                    message = string.Join(",", adjustmentDetail.Select(o => $"{o.ContractNO}合同￥{o.CNY.ToString("N2")}").ToArray());
                }
                else
                {
                    message += $"转至{ adjustmentDetail[0].ContractNO}合同￥{ adjustmentDetail[0].CNY.ToString("N2")}";
                }

                txtApplyList.Text = "调账申请理由：\r\n";
                txtApplyList.Text += "\t" + message + "\r\n\r\n \t以上麻烦操作，谢谢。";
                txtApplyList.Text += "\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t    " + user?.DepartmentName ?? "";
                txtApplyList.Text += "\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t" + adjustment?.CreateDate.ToString("yyyy年MM月dd日") ?? "";
            }
            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public override void PrintData()
        {
            //this.Height -= 50;
            this.labelControl1.Focus();
            PrinterHelper.PrintControl(false, this.layoutControl2, false, System.Drawing.Printing.PaperKind.Custom);
        }
    }
}