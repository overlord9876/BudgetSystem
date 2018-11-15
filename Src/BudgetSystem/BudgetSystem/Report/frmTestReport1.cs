using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BudgetSystem.Entity;

namespace BudgetSystem.Report
{
    public partial class frmTestReport1 : Base.frmBaseCommonReportForm
    {
        public frmTestReport1()
        {
            InitializeComponent();
        }

        protected override void InitData()
        {
            this.supportPivotGrid = true;
            this.supportPivotGridSaveView = true;


            this.GridToolBarActions.Add("上一个", this.Pre);
            this.GridToolBarActions.Add("下一个", this.Next);

        }


        private void frmTestReport1_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        private void Next()
        {
            MessageBox.Show("下一个");
        }

        private void Pre()
        {
            MessageBox.Show("上一个");
        }

        public override void LoadData()
        {
            Bll.UserManager um = new Bll.UserManager();
            var lst = um.GetAllUser();

            base.CreateGridColumn("用户名", "UserName");
            base.CreateGridColumn("用户姓名", "RealName");
            base.CreateGridColumn("用户部名", "DepartmentName");
            base.CreateGridColumn("用户角色", "RoleName");
            base.CreateGridColumn("创建人", "CreateUser");
            base.CreateGridColumn("更新时间", "UpdateDateTime");
            base.gridControl.DataSource = lst;


            base.CreatePivotGridField("用户名", "UserName");
            base.CreatePivotGridField("用户姓名", "RealName");
            base.CreatePivotGridField("用户部名", "DepartmentName");
            base.CreatePivotGridField("用户角色", "RoleName");
            base.CreatePivotGridField("创建人", "CreateUser");
           var field=  base.CreatePivotGridField("更新时间", "UpdateDateTime");

           field.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
           field.ValueFormat.FormatString = "D";


           base.CreatePivotGridDefaultRowField();

            this.pivotGridControl.DataSource = lst;
        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();


        }


    }
}
