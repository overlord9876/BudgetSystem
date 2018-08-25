using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;

namespace BudgetSystem
{
    public partial class frmMain
    {
        private void InitSkins()
        {
           
            SkinHelper.InitSkinGallery(rgbStyle, true);
           // UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        private void ShowForm(Form form)
        {
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.Show();
        }


        private T GetExistForm<T>() where T : Form
        {
            foreach (Form form in this.MdiChildren)
            {
                if (typeof(T) == form.GetType())
                {
                    return (T)form;

                }
            }
            return null;
        }

        private void RefreshData()
        {
            frmBaseQueryForm form = this.ActiveMdiChild as frmBaseQueryForm;
            if (form != null && form.CanRefreshData)
            {
                form.RefreshData();
            }
        }

        private void btnReLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Restart();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.RefreshData();
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            frmBaseQueryForm form = this.ActiveMdiChild as frmBaseQueryForm;
            if (form != null && form.CanRefreshData)
            {
                this.btnRefresh.Enabled = true;

            }
            else
            {
                this.btnRefresh.Enabled = false;
            }
        }
    }
}
