using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BudgetSystem
{
    public partial class frmRoleQuery : frmBaseQueryForm
    {
        public frmRoleQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();
        }


        public override void OperateHandled(ModelOperate operate)
        {

        }

        public override void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RoleName", typeof(string));
            dt.Columns.Add("RoleDescription", typeof(string));

            dt.Rows.Add("业务员", "提交审批单，修改审批单");
            dt.Rows.Add("业务部经理", "审批流程单");
            dt.Rows.Add("财务经理", "审批流程单，审批财务流程");
            dt.Rows.Add("总经理", "审理所有流程");
            this.gridControl3.DataSource = dt;


            DataTable userdt = new DataTable();
            userdt.Columns.Add("Name");
            userdt.Columns.Add("RealName");
            userdt.Columns.Add("Role");
            userdt.Columns.Add("State");

            userdt.Rows.Add("User1", "张三", "业务员", "可用");
            userdt.Rows.Add("User2", "李四", "业务员", "可用");
            this.gridControl1.DataSource = userdt;


            DataTable userdt2 = new DataTable();
            userdt2.Columns.Add("Name");
            userdt2.Columns.Add("RealName");
            userdt2.Columns.Add("Role");
            userdt2.Columns.Add("State");

            userdt2.Rows.Add("User3", "王五", "业务员", "可用");
            userdt2.Rows.Add("User4", "赵六", "业务员", "停用");
            this.gridControl2.DataSource = userdt2;
        }
    }
}
