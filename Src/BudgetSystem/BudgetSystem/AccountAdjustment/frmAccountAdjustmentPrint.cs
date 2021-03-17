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

        private Size size;

        public AdjustmentType AdjustmentType { get; private set; }
        public frmAccountAdjustmentPrint()
        {
            InitializeComponent();
            this.SizeChanged += FrmAccountAdjustmentPrint_SizeChanged;
            this.AutoSizeChanged += FrmAccountAdjustmentPrint_SizeChanged;
            int x = 210 + (this.layoutControlGroup1.Padding.Left * 2);
            var width = (int)(x * 100 / 25.4);
            int y = 297 + this.layoutControlGroup1.Padding.Top;
            var height = (int)(y * 100 / 25.4);
            //width = width - 20;
            //height = height - 110;
            this.size = new System.Drawing.Size(width, height);
            this.Size = this.size;
            //int y = 297;
            //this.Height = (int)(y * 100 / 25.4);
            //this.Size = new Size(this.Width, this.Height);
            panelControl1.Dock = DockStyle.Fill;
            layoutControl2.Dock = DockStyle.Fill;
            layoutControl1.Dock = DockStyle.Fill;
            //this.AutoScroll = false;
            //this.layoutControl1.AutoScroll = false;
            //this.layoutControl2.AutoScroll = false;
        }

        private void FrmAccountAdjustmentPrint_SizeChanged(object sender, EventArgs e)
        {
            var width = (this.layoutControl1.Width - this.layoutControlGroup1.Padding.Left - this.layoutControlGroup1.Padding.Right) / 8;
            width = width - 2;
            lcilciFlowNode1.Width = width;
            lcitxtFlowNode1.Width = width;
            lcilciFlowNode2.Width = width;
            lcitxtFlowNode2.Width = width;
            lcilciFlowNode3.Width = width;
            lcitxtFlowNode3.Width = width;
            lcilciFlowNode4.Width = width + 20;
            lcitxtFlowNode4.Width = width;

            var topWidth = (this.layoutControl1.Width - this.layoutControlGroup1.Padding.Left - this.layoutControlGroup1.Padding.Right) / 4;
            width = width - 2;
            lciDepartment.Width = topWidth;
            lcitxtDepartment.Width = topWidth;
            lciBudget.Width = topWidth;
            lcitxtBudget.Width = topWidth;
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

            if (points != null && adjustment.FlowName == EnumFlowNames.调账审批流程.ToString())
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
                            txtFlowNode1.Text = point.NodeActApproveRealName;
                        }
                        else if (flowNodes[1].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode2.Text = point.NodeActApproveRealName;
                        }
                        else if (flowNodes[2].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode3.Text = point.NodeActApproveRealName;
                        }
                        else if (flowNodes[3].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode4.Text = point.NodeActApproveRealName;
                        }
                    }
                }
            }
            else if (points != null && adjustment.FlowName == EnumFlowNames.财务调账审批流程.ToString())
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
                            txtFlowNode1.Text = point.NodeActApproveRealName;
                        }
                        else if (flowNodes[1].NodeValueRemark == point.NodeValueRemark)
                        {
                            txtFlowNode2.Text = point.NodeActApproveRealName;
                        }
                    }
                }
            }

            txtApplyList.Text += GeneraorMessage2(adjustment, adjustmentDetail, user);
            txtApplyList.Text += "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";

            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }
        }

        public static string GeneraorMessage(AccountAdjustment adjustment, List<AccountAdjustmentDetail> adjustmentDetail, User user, bool isMark = false)
        {
            string result = string.Empty;
            string date = adjustment.Date.ToString("yyyy年MM月dd日");
            string type = adjustment.Type == AdjustmentType.付款 ? "付给" : "收到";
            string message = adjustment.Remark;
            //string message = $"请将{adjustment.ContractNO}合同中{date}{type}{adjustment.Name}的￥{ adjustment.CNY.ToString("N2")}元中的￥{adjustment.AlreadySplitCNY.ToString("N2")}";
            //if (adjustmentDetail != null && adjustmentDetail.Count > 0)
            //{
            //    if (adjustmentDetail.Count > 1)
            //    {
            //        message += "分别转至";
            //        message += string.Join(",", adjustmentDetail.Select(o => $"{o.ContractNO}合同￥{o.CNY.ToString("N2")}").ToArray());
            //    }
            //    else
            //    {
            //        message += $"转至{ adjustmentDetail[0].ContractNO}合同￥{ adjustmentDetail[0].CNY.ToString("N2")}";
            //    }

            //    //result += "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            //}
            if (!isMark)
            {
                result = "调账申请理由：\r\n\r\n";
                result += "\t";
            }
            result += message;
            if (!isMark)
            {
                result += "\r\n";
            }
            result += "\r\n\t";
            result += "以上麻烦操作，谢谢。";
            if (!isMark)
            {
                result += "\r\n\r\n";
            }
            result += "\r\n\t\t\t\t\t    " + user?.DepartmentName ?? "";
            if (!isMark)
            {
                result += "\r\n";
            }
            result += "\r\n\t\t\t\t\t" + adjustment?.CreateDate.ToString("yyyy年MM月dd日") ?? "";

            return result;
        }

        public static string GeneraorMessage2(AccountAdjustment adjustment, List<AccountAdjustmentDetail> adjustmentDetail, User user, bool isMark = false)
        {
            Bll.BudgetManager bm = new BudgetManager();
            Bll.PaymentNotesManager pnm = new PaymentNotesManager();
            ReceiptMgmtManager rmm = new ReceiptMgmtManager();
            InvoiceManager im = new InvoiceManager();

            string result = string.Empty;
            string date = adjustment.Date.ToString("yyyy年MM月dd日");
            string type = adjustment.Type == AdjustmentType.付款 ? "付给" : "收到";
            string message = string.Empty;
            message = $"由于客户的原因，现申请{adjustment.Type}调账：\r\n";

            var CustomerExtension = bm.GetCustomerByBudgetId(adjustment.BudgetID);
            string appendLine = "，";
            if (!isMark)
            {
                appendLine = "\r\n\t";
            }
            if (adjustment.Type == AdjustmentType.付款)
            {
                var payment = pnm.GetPaymentNoteById(adjustment.RelationID);
                if (!isMark)
                {
                    message += "\t";
                }
                message += $"调出：从合同【{adjustment.ContractNO}】{appendLine}原付款时间【{payment.PaymentDate}】{appendLine}付款单号【{payment.VoucherNo}】{appendLine}原付款金额【{payment.CNY}】{appendLine}现调出付款金额【{adjustment.AlreadySplitCNY}】{appendLine}供应商名称【{payment.SupplierName}】{appendLine}用款类型【{payment.MoneyUsed}】";
                message += "\r\n";
                int index = 0;
                foreach (var detail in adjustmentDetail)
                {
                    index++;
                    CustomerExtension = bm.GetCustomerByBudgetId(adjustment.BudgetID);
                    message += "\r\n";
                    if (!isMark)
                    {
                        message += "\t";
                    }
                    message += $"调入（{index}）调整进入合同【{detail.ContractNO}】{appendLine}现调账金额【{detail.CNY}】{appendLine}供应商名称【{payment.SupplierName}】{appendLine}用款类型【{payment.MoneyUsed}】\r\n";
                }
            }
            else if (adjustment.Type == AdjustmentType.收款)
            {
                if (!isMark)
                {
                    message += "\t";
                }
                message += $"调出：从合同【{adjustment.ContractNO}】{appendLine}买方【{CustomerExtension.MainCustomer}】{appendLine}备注买方【{CustomerExtension.Customers}】\r\n";
                if (!isMark)
                {
                    message += "\t";
                }
                var budgetBill = rmm.GetBudgetBillBybbId(adjustment.RelationID);
                message += $"原收款时间【{budgetBill.ReceiptDate}】{appendLine}原收款金额【{budgetBill.CNY}】{appendLine}银行凭证号【{budgetBill.VoucherNo}】{appendLine}款项性质【{budgetBill.NatureOfMoney}】";
                message += "\r\n";
                int index = 0;
                foreach (var detail in adjustmentDetail)
                {
                    index++;
                    CustomerExtension = bm.GetCustomerByBudgetId(adjustment.BudgetID);
                    message += "\r\n";
                    if (!isMark)
                    {
                        message += "\t";
                    }
                    message += $"调入（{index}）调整进入合同【{detail.ContractNO}】{appendLine}买方【{CustomerExtension.MainCustomer}】{appendLine}付款公司【{CustomerExtension.Customers}】\r\n";
                    if (!isMark)
                    {
                        message += "\t";
                    }
                    message += $"现调账金额【{detail.CNY}】{appendLine}款项性质【{budgetBill.NatureOfMoney}】\r\n";
                }
            }
            else
            {
                var invoice = im.GetInvoice(adjustment.RelationID);
                if (!isMark)
                {
                    message += "\t";
                }
                message += $"调出：从合同【{adjustment.ContractNO}】{appendLine}原交单时间【{invoice.FinanceImportDate}】{appendLine}发票原币金额【{invoice.OriginalCoin}】{appendLine}发票人民币金额【{invoice.CNY}】{appendLine}销方名称【{invoice.SupplierName}】{appendLine}币种[USD]{appendLine}汇率【{invoice.ExchangeRate}】";
                message += "\r\n";
                int index = 0;
                foreach (var detail in adjustmentDetail)
                {
                    index++;
                    CustomerExtension = bm.GetCustomerByBudgetId(adjustment.BudgetID);
                    message += "\r\n";
                    if (!isMark)
                    {
                        message += "\t";
                    }
                    message += $"调入（{index}）调整进入合同【{detail.ContractNO}】{appendLine}调账发票原币金额【{detail.OriginalCoin}】{appendLine}调账发票人民币金额【{detail.CNY}】{appendLine}销方名称【{invoice.SupplierName}】{appendLine}币种[USD]{appendLine}汇率【{invoice.ExchangeRate}】\r\n";
                }
            }
            if (!isMark)
            {
                result = "调账申请理由：\r\n\r\n\r\n";
                result += "\t";
            }
            result += message;
            if (!isMark)
            {
                result += "\r\n";

                result += "\r\n\t";
                result += "以上麻烦操作，谢谢。";
            }
            if (!isMark)
            {
                result += "\r\n\r\n";

                result += "\r\n\t\t\t\t\t    " + user?.DepartmentName ?? "";
            }
            if (!isMark)
            {
                result += "\r\n";
            }
            result += "\r\n\t\t\t\t\t" + adjustment?.CreateDate.ToString("yyyy年MM月dd日") ?? "";

            return result;
        }
        public override void PrintData()
        {
            this.labelControl1.Focus();
            layoutControl2.Dock = DockStyle.None;
            this.layoutControl2.Size = this.size;
            PrinterHelper.PrintControl(false, this.layoutControl2, new System.Drawing.Size((int)(210 * 100 / 25.4), (int)(297 * 100 / 25.4)), true, System.Drawing.Printing.PaperKind.Custom, margins: new System.Drawing.Printing.Margins(10, 10, 100, 10));
            //PrinterHelper.PrintControl(false, this.layoutControl2, Size.Empty, true, System.Drawing.Printing.PaperKind.A4, margins: new System.Drawing.Printing.Margins(10, 10, 100, 10));
        }
    }
}