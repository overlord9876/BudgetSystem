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
    public partial class frmOutMoneyQuery : frmBaseQueryFormWithCondtion
    {
        public frmOutMoneyQuery()
        {
            InitializeComponent();

        }

        protected override void InitModelOperate()
        {
            base.InitModelOperate();

            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "修改付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除付款申请"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Confirm, "确认已付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.GiveUp, "放弃付款"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看审批记录"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Print));



            this.ModelOperatePageName = "付款管理";
        }

        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmOutMemoryEdit form = new frmOutMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmOutMemoryEdit form = new frmOutMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmOutMemoryEdit form = new frmOutMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == "Test1")
            {
                XtraMessageBox.Show("Test1");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作1");
            }
        }

        public override void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Supplier", typeof(string));
            dt.Columns.Add("Payment", typeof(string));
            dt.Columns.Add("Submitter", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Approver", typeof(string));
            dt.Columns.Add("ApproveTime", typeof(DateTime));
            dt.Columns.Add("PaymentDate", typeof(DateTime));
            dt.Columns.Add("Description", typeof(string));

            dt.Rows.Add("常熟市新中华时装有限公司", "50000", "张三", "审批中", "财务确认人", DateTime.Now, DateTime.Now, "");
            dt.Rows.Add("上海丝绸进口公司淀山湖真丝针织厂", "80000", "李四", "审批中", "财务确认人", DateTime.Now, DateTime.Now, "");

            this.gridControl1.DataSource = dt;
        }
    }
}
