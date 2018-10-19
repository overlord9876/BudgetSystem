using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

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
            FormActivited(form);
        }

        private void FormActivited(frmBaseQueryForm form)
        {
            
            SetQueryFormRefreshState(form);
            SetQueryOperateRibbonUI(form);
        }

        private void SetQueryFormRefreshState(frmBaseQueryForm form)
        {
            if (form != null && form.CanRefreshData)
            {
                this.btnRefresh.Enabled = true;

            }
            else
            {
                this.btnRefresh.Enabled = false;
            }
        }

        private void SetQueryOperateRibbonUI(frmBaseQueryForm form)
        {
            string currentFormID = form == null ? "" : form.FormID;
            SetOperatonGroupNotVisibleAndClearNotExistFormPage(currentFormID);

            if (form != null)
            {
                RibbonPage page = GetPageByID(form.FormID);
                if (page == null)
                {
                    page = CreateRibbonPage(form);
                }
                else
                {
                    page.Visible = true;
                }
                if (page != null)
                {
                    this.ribbonControl1.SelectedPage = page;
                }
            }
        }




        private void SetOperatonGroupNotVisibleAndClearNotExistFormPage(string exceptFormID)
        {
            List<string> currentFormIds = new List<string>();
            foreach (var form in this.MdiChildren)
            {
                if (form is frmBaseQueryForm)
                {
                    currentFormIds.Add((form as frmBaseQueryForm).FormID);
                }
            }

            for (int i = this.ribbonControl1.Pages.Count - 1; i >= 0; i--)
            {
                if ( this.ribbonControl1.Pages[i].Tag != null)
                {
                    string formID = this.ribbonControl1.Pages[i].Tag.ToString();

                    if (!currentFormIds.Contains(formID))
                    {
                        this.ribbonControl1.Pages.RemoveAt(i);

                    }
                    else
                    {
                        this.ribbonControl1.Pages[i].Visible = formID == exceptFormID;
                    }
                }
            }
        }

        private RibbonPage GetPageByID(string id)
        {
            foreach (RibbonPage page in this.ribbonControl1.Pages)
            {
                if (page.Tag != null && page.Tag.ToString() == id)
                {
                    return page;
                }
            }
            return null;
        }

        private RibbonPage CreateRibbonPage(frmBaseQueryForm form)
        {

            if (form.ModelOperateRegistry.Count == 0)
            {
                return null;
            }

            RibbonPage page = new RibbonPage(form.ModelOperatePageName);
            page.Tag = form.FormID;


            this.ribbonControl1.Pages.Insert(0, page);


            Dictionary<string ,RibbonPageGroup> dict = new Dictionary<string,RibbonPageGroup>();

            foreach (ModelOperate mo in form.ModelOperateRegistry)
            {
                RibbonPageGroup group = null;
                if (!dict.ContainsKey(mo.GroupText))
                {
                    group = new RibbonPageGroup(mo.GroupText);
                    page.Groups.Add(group);
                    dict.Add(mo.GroupText, group);
                }
                else
                {
                    group = dict[mo.GroupText];
                }


                if (mo.UIType == UITypes.LargerButton)
                {
                    BarButtonItem button = new BarButtonItem();
                    button.RibbonStyle = RibbonItemStyles.Large;
                  
                  
                    button.Caption = mo.Text;
                    button.GroupIndex = mo.Order;
                    button.ItemClick += new ItemClickEventHandler(RibbonButtonClick);
                    button.Tag = mo;
                    group.ItemLinks.Add(button);

                    button.ImageIndex = mo.ImageIndex;
                }
            }
         
            return page;
        }

        private void RibbonButtonClick(object sender, ItemClickEventArgs e)
        {

            frmBaseQueryForm form = this.ActiveMdiChild as frmBaseQueryForm;

            form.OperateHandled(e.Item.Tag as ModelOperate);

        }

        private void rgbStyle_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            RunInfo.Instance.Config.SkinName = e.Item.Caption;
            RunInfo.Instance.Config.Save();
        }
    }
}
