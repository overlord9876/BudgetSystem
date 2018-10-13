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
    public partial class frmInMoneyQuery : frmBaseQueryFormWithCondtion
    {
        public frmInMoneyQuery()
        {
            InitializeComponent();
        }
        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New, "新增入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify, "分拆至合同"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete, "删除入账"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.SplitCost, "费用拆分"));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View, "查看详情"));

            this.ModelOperatePageName = "入帐单";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmInMemoryEdit form = new frmInMemoryEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmInMemorySplitToBudgetEdit form = new frmInMemorySplitToBudgetEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.SplitCost.ToString())
            {
                frmInMemorySplitCostEdit form = new frmInMemorySplitCostEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Delete.ToString())
            {
                XtraMessageBox.Show("删除入账");
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmInMemoryEdit form = new frmInMemoryEdit();
                form.ShowDialog(this);
            }
        }

        public override void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Customer", typeof(string));
            dt.Columns.Add("BankVoucherNumber", typeof(string));
            dt.Columns.Add("Currency", typeof(string));
            dt.Columns.Add("OriginalCoin", typeof(string));
            dt.Columns.Add("RMB", typeof(string));
            dt.Columns.Add("BankName", typeof(string));
            dt.Columns.Add("ExchangeRate", typeof(string));
            dt.Columns.Add("BankCharges", typeof(string));
            dt.Columns.Add("ReceiptDate", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("CreateUser", typeof(string));
            dt.Columns.Add("CreateDate", typeof(DateTime));
            dt.Columns.Add("Description", typeof(string));

            dt.Rows.Add("CRAFT OF SCANDINAVIA AB", "201809161234143143", "美元", "35000000.00", "242550000.00", "瑞士银行", "6.93", "0.00", DateTime.Now, "已收款", "张三", DateTime.Now, "");
            dt.Rows.Add("URDI PRY LTD CRAFTSPORTSWEAR NORTH", "201809161234143143", "美元", "35000000.00", "242550000.00", "瑞士银行", "6.93", "0.00", DateTime.Now, "已收款", "张三", DateTime.Now, "");
            dt.Rows.Add("UNITED BRANDS", "201809161234143143", "美元", "35000000.00", "242550000.00", "瑞士银行", "6.93", "0.00", DateTime.Now, "已收款", "张三", DateTime.Now, "");

            this.gridControl1.DataSource = dt;
        }
    }
}
