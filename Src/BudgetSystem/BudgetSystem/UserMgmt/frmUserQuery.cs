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
    public partial class frmUserQuery : frmBaseQueryForm

    {

        private Bll.UserManager um = new Bll.UserManager();
        public frmUserQuery()
        {
            InitializeComponent();
        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Enabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Disabled));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "用户管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmUserEdit form = new frmUserEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmUserEdit form = new frmUserEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmUserEdit form = new frmUserEdit();
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }

        public override void LoadData()
        {
            var list= um.GetAllUser();

            this.gridControl1.DataSource = list;
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("RealName");
            //dt.Columns.Add("Role");
            //dt.Columns.Add("Department");
            //dt.Columns.Add("State");

            //dt.Rows.Add("User1", "张三", "业务员", "业务部", "可用");
            //dt.Rows.Add("User2", "李四", "财务", "财务部", "可用");
            //dt.Rows.Add("User3", "王五", "财务管理员", "业务部", "可用");
            //dt.Rows.Add("User4", "赵六", "财务", "财务部", "停用");
            //this.gridControl1.DataSource = dt;
        }



    }
}