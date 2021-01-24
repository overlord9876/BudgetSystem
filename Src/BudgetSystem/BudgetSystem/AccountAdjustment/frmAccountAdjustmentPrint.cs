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

        public int ID { get; private set; }

        public AdjustmentType AdjustmentType { get; private set; }

        public frmAccountAdjustmentPrint()
        {
            InitializeComponent();

            lcilciFlowNode1.Width = this.Width / 8;
            lcitxtFlowNode1.Width = this.Width / 8;
            lcilciFlowNode2.Width = this.Width / 8;
            lcitxtFlowNode2.Width = this.Width / 8;
            lcilciFlowNode3.Width = this.Width / 8;
            lcitxtFlowNode3.Width = this.Width / 8;
            lcilciFlowNode4.Width = this.Width / 8;
            lcitxtFlowNode4.Width = this.Width / 8;

            lciDepartment.Width = this.Width / 4;
            lcitxtDepartment.Width = this.Width / 4;
            lciBudget.Width = this.Width / 4;
            lcitxtBudget.Width = this.Width / 4;
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
            //EnumFlowDataType flowDataType = EnumFlowDataType.交单调账;
            //if (adjustment.Type == AdjustmentType.付款)
            //{
            //    flowDataType = EnumFlowDataType.付款调账;
            //}
            //else if (adjustment.Type == AdjustmentType.收款)
            //{
            //    flowDataType = EnumFlowDataType.收款调账;
            //}
            var adjustmentDetail = aamManager.GetAccountAdjustmentDetailByTypeId(this.ID, AdjustmentType);

            txtBudget.Text = adjustment.ContractNO;


            lciFlowNode1.Text = "";
            txtFlowNode1.Text = "";
            lciFlowNode2.Text = "";
            txtFlowNode2.Text = "";
            lciFlowNode3.Text = "";
            txtFlowNode3.Text = "";
            lciFlowNode4.Text = "";
            txtFlowNode4.Text = "";

            List<FlowRunPoint> points = fm.GetFlowRunPointsByInstance(adjustment.FlowInstanceID).ToList();
            if (points == null || points.Count == 0)
            {
                return;
            }
            if (adjustment.FlowName == EnumFlowNames.调账审批流程.ToString())
            {
                var flowNodes = fm.GetFlowDetail(EnumFlowNames.调账审批流程);
                if (flowNodes.Count == 4)
                {
                    lciFlowNode1.Text = flowNodes[0].NodeValueRemark;
                    lciFlowNode2.Text = flowNodes[1].NodeValueRemark;
                    lciFlowNode3.Text = flowNodes[2].NodeValueRemark;
                    lciFlowNode4.Text = flowNodes[3].NodeValueRemark;
                    foreach (FlowRunPoint point in points)
                    {
                        if (point.NodeValueRemark == null || point.NodeApproveResult == false)
                        {
                            continue;
                        }
                        else if (flowNodes[0].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode1.Text = point.RealName;
                        }
                        else if (flowNodes[1].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode2.Text = point.RealName;
                        }
                        else if (flowNodes[2].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode3.Text = point.RealName;
                        }
                        else if (flowNodes[3].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode4.Text = point.RealName;
                        }
                    }
                }
            }
            else if (adjustment.FlowName == EnumFlowNames.财务调账审批流程.ToString())
            {
                var flowNodes = fm.GetFlowDetail(EnumFlowNames.财务调账审批流程);
                if (flowNodes.Count == 2)
                {
                    lciFlowNode1.Text = flowNodes[0].NodeValueRemark;
                    lciFlowNode2.Text = flowNodes[1].NodeValueRemark;
                    foreach (FlowRunPoint point in points)
                    {
                        if (point.NodeValueRemark == null || point.State == false)
                        {
                            continue;
                        }
                        else if (flowNodes[0].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode1.Text = point.RealName;
                        }
                        else if (flowNodes[1].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode2.Text = point.RealName;
                        }
                    }
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

                txtApplyList.Text = "调账申请理由：\r\n\r\n\r\n";
                txtApplyList.Text += "\t" + message + "\r\n\r\n \t以上麻烦操作，谢谢。";
                txtApplyList.Text += "\r\n\r\n\r\n\t\t\t\t\t\t\t    " + user?.DepartmentName ?? "";
                txtApplyList.Text += "\r\n\r\n\t\t\t\t\t\t\t" + adjustment?.CreateDate.ToString("yyyy年MM月dd日") ?? "";
                txtApplyList.Text += "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            }
            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
        }

        public override void PrintData()
        {
            this.Height += 500;
            this.labelControl1.Focus();
            PrinterHelper.PrintControl(false, this.layoutControl2, false);
        }
    }
}