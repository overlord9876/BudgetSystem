using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmBaseQueryFormWithCondtion : frmBaseQueryForm
    {
        public frmBaseQueryFormWithCondtion()
        {
            InitializeComponent();
            this.LoadMyQuery();
        }

        protected virtual void LoadMyQuery()
        {
            //TODO:Load
            var item = new DevExpress.XtraNavBar.NavBarItem();
            item.Tag = "这里是从配置加载的查询器的值，系统按配置进行查询";
            item.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(item_LinkClicked);
            item.Caption = "我的查询1";
            this.nbgMyCondition.ItemLinks.Add(item);
            var item2 = new DevExpress.XtraNavBar.NavBarItem();
            item2.Tag = "这里是从配置加载的查询器的值，系统按配置进行查询";
            item2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(item_LinkClicked);
            item2.Caption = "我的查询2";
            this.nbgMyCondition.ItemLinks.Add(item2);
        }

        private void item_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string queryInfo = e.Link.Item.Tag.ToString();
            this.DoMyQuery(queryInfo);
        }

        protected virtual void SaveMyQuery()
        {
            string fileName = this.FormID;

            //TODO:SAVE
        }


        protected virtual void DoMyQuery(string queryInfo)
        {
            XtraMessageBox.Show(queryInfo);
        }

    }
}
