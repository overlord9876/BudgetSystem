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
        void InitSkins()
        {
            SkinHelper.InitSkinGallery(rgbStyle, true);
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        public void ShowForm(Form form)
        {
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.Show();
        }


    }
}
