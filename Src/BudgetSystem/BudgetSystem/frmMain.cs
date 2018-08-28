using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace BudgetSystem
{
    public partial class frmMain : RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            InitSkins();

         
        }



        private void btnbudgetQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            
            
            frmBudgetQuery form = GetExistForm<frmBudgetQuery>();
            if (form == null)
            {
                form = new frmBudgetQuery();
            }
            else
            {
                form.RefreshData();
            }
            ShowForm(form);
        }

      

        private void btnInMoneyQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInMoneyQuery form = GetExistForm<frmInMoneyQuery>();
            if (form == null)
            {
                form = new frmInMoneyQuery();
            }
            else
            {
                form.RefreshData();
            }
            ShowForm(form);
        }

        private void btnOutMoneyQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOutMoneyQuery form = GetExistForm<frmOutMoneyQuery>();
            if (form == null)
            {
                form = new frmOutMoneyQuery();
            }
            else
            {
                form.RefreshData();
            }
            ShowForm(form);
        }


        private void rgbStyle_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            RunInfo.Instance.Config.SkinName = e.Item.Caption;
            RunInfo.Instance.Config.Save();
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

       
    }
}
