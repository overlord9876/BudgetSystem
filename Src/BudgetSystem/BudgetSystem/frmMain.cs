

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using BudgetSystem.UserManage;
using BudgetSystem.RoleManage;
using BudgetSystem.DepartmentManage;
using BudgetSystem.InMoney;
using BudgetSystem.FlowManage;
using BudgetSystem.WorkSpace;
using System.Reflection;

namespace BudgetSystem
{
    public partial class frmMain : RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            InitSkins();

# if (!IgnorePermission)

            CheckUserPermission();
#endif

            bsiLoginInfo.Caption = string.Format("当前登陆用户为：{0}{1}", RunInfo.Instance.CurrentUser.DepartmentName, RunInfo.Instance.CurrentUser.ToString());

        }

    

        private void btnbudgetQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBudgetQuery form = GetExistForm<frmBudgetQuery>();
            if (form == null)
            {
                form = new frmBudgetQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }



        private void btnInMoneyQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInMoneyQuery form = GetExistForm<frmInMoneyQuery>();
            if (form == null)
            {
                form = new frmInMoneyQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnOutMoneyQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOutMoneyQuery form = GetExistForm<frmOutMoneyQuery>();
            if (form == null)
            {
                form = new frmOutMoneyQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }




        private void btnAddBudget_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnModifyBudget_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //当填写数据错误，或者回撤、审批未通过的修改编辑窗口
        }

        private void btnRecallBudget_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //当发现自己填写有问题的单子，可以直接撤回，重新填写提交第一级领导审批
        }

        private void btnInMoneyAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //1.创建收款单，此时，财务只根据银行收款填写相关信息
            //2.转由业务部门认领
            //3.最终进行系统核算，并修改单据状态。

        }

        private void btnOutMoneyAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //1.创建付款单据，填写发票、单据和凭证信息
            //2.系统审核，是否符合付款条件
            //3.财务审核
        }

        private void btnCustomerQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCustomerQuery form = GetExistForm<frmCustomerQuery>();
            if (form == null)
            {
                form = new frmCustomerQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnSupplierQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSupplierQuery form = GetExistForm<frmSupplierQuery>();
            if (form == null)
            {
                form = new frmSupplierQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnInvoiceQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInvoiceQuery form = GetExistForm<frmInvoiceQuery>();
            if (form == null)
            {
                form = new frmInvoiceQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnVoucherNotesQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVoucherNotesQuery form = GetExistForm<frmVoucherNotesQuery>();
            if (form == null)
            {
                form = new frmVoucherNotesQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnUserQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUserQuery form = GetExistForm<frmUserQuery>();
            if (form == null)
            {
                form = new frmUserQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnFlowConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFlowQuery form = GetExistForm<frmFlowQuery>();
            if (form == null)
            {
                form = new frmFlowQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnApprovalList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmApprovalListQuery form = GetExistForm<frmApprovalListQuery>();
            if (form == null)
            {
                form = new frmApprovalListQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);

        }

        private void btnMyOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMyFlowListQuery form = GetExistForm<frmMyFlowListQuery>();
            if (form == null)
            {
                form = new frmMyFlowListQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDepartmentQuery form = GetExistForm<frmDepartmentQuery>();
            if (form == null)
            {
                form = new frmDepartmentQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnRoleManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRoleQuery form = GetExistForm<frmRoleQuery>();
            if (form == null)
            {
                form = new frmRoleQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnOptionManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOptionQuery form = GetExistForm<frmOptionQuery>();
            if (form == null)
            {
                form = new frmOptionQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFinalAccountsQuery form = GetExistForm<frmFinalAccountsQuery>();
            if (form == null)
            {
                form = new frmFinalAccountsQuery();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnModifyPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUserEdit editor = new frmUserEdit();
            editor.WorkModel = EditFormWorkModels.Custom;
            editor.CustomWorkModel = frmUserEdit.CustomWorkModel_ModifyPassword;
            editor.ShowDialog();
        }

        private void btnReport1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.frmTestReport1 form = GetExistForm<Report.frmTestReport1>();
            if (form == null)
            {
                form = new Report.frmTestReport1();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnBudgetReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.frmBudgetReport form = GetExistForm<Report.frmBudgetReport>();
            if (form == null)
            {
                form = new Report.frmBudgetReport();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnInMoneyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.frmInMoneyReport form = GetExistForm<Report.frmInMoneyReport>();
            if (form == null)
            {
                form = new Report.frmInMoneyReport();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void btnOutMoney_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.frmOutMoneyReport form = GetExistForm<Report.frmOutMoneyReport>();
            if (form == null)
            {
                form = new Report.frmOutMoneyReport();
                form.RefreshData();
            }
            else
            {
                FormActivited(form);
            }
            ShowForm(form);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RunInfo.Instance.MainForm = this;
            string formName = RunInfo.Instance.Config.LastForm;
            try
            {
                frmBaseQueryForm form = Assembly.GetExecutingAssembly().CreateInstance(formName) as frmBaseQueryForm;
                if (form != null)
                {
                    if (form.CanRefreshData)
                    {
                        form.RefreshData();
                    }
                    ShowForm(form);
                }
            }
            catch
            {


            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = this.ActiveMdiChild;
            if (form != null)
            {
                RunInfo.Instance.Config.LastForm = form.GetType().FullName;
                RunInfo.Instance.Config.Save();
            }


        }
    }
}
