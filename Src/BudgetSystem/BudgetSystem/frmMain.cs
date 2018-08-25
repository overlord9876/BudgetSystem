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

       
    }
}
