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
    public partial class frmSupplierQuery : frmBaseQueryForm
    {
        public frmSupplierQuery()
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
            this.ModelOperatePageName = "供应商管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmSupplierEdit form = new frmSupplierEdit() { WorkModel = EditFormWorkModels.New };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmSupplierEdit form = new frmSupplierEdit() { WorkModel = EditFormWorkModels.View };
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Enabled.ToString())
            {
                XtraMessageBox.Show("启用供应商，如果是合格供商则发启合格供商发启流程。");
            }
            else if (operate.Operate == OperateTypes.Disabled.ToString())
            {
                XtraMessageBox.Show("停用供应商");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmSupplierEdit form = new frmSupplierEdit() { WorkModel = EditFormWorkModels.View };
                form.ShowDialog(this);
            }
        }


        public override void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("BankAccountName", typeof(string));
            dt.Columns.Add("BankNO", typeof(string));
            dt.Columns.Add("BankName", typeof(string));
            dt.Columns.Add("IsQualified", typeof(string));
            dt.Columns.Add("CreateDate", typeof(DateTime));
            dt.Columns.Add("CreateUser", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            dt.Rows.Add("常熟市新中华时装有限公司", "胡汉三", "2211231231231231231", "招商银行", "是", DateTime.Now, "李四");

            dt.Rows.Add("上海丝绸进口公司淀山湖真丝针织厂", "王五", "2211231231231235678", "交通银行", "否", DateTime.Now, "张三");

            this.gridControl1.DataSource = dt;
        }

    }
}
