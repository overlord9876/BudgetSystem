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
    public partial class frmBudgetQuery : frmBaseQueryFormWithCondtion
    {
        public frmBudgetQuery()
        {
            InitializeComponent();

        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.New));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Modify));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Delete));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Close));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.Revoke));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.View));
            this.ModelOperatePageName = "预算单";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.New.ToString())
            {
                frmBudgetEditEx form = new frmBudgetEditEx();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Modify.ToString())
            {
                frmBudgetEdit form = new frmBudgetEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.View.ToString())
            {
                frmBudgetEdit form = new frmBudgetEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.Revoke.ToString())
            {
                XtraMessageBox.Show("Revoke");
            }
            else if (operate.Operate == OperateTypes.Close.ToString())
            {
                XtraMessageBox.Show("关闭预算单");
            }
            else if (operate.Operate == "Test")
            {
                XtraMessageBox.Show("Test");
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }

        public override void LoadData()
        {
            //            
            //State
            //TotalAmount
            //Salesman
            //Department
            //CreateDate
            //SignDate
            //Validity
            //Purchaser
            //TradeMode
            //TradeNature
            //Seaport
            //AdvancePayment
            //Profit
            DataTable dt = new DataTable();
            dt.Columns.Add("ContractNO", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("TotalAmount", typeof(string));
            dt.Columns.Add("Salesman", typeof(string));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("CreateDate", typeof(DateTime));
            dt.Columns.Add("SignDate", typeof(DateTime));
            dt.Columns.Add("Validity", typeof(DateTime));
            dt.Columns.Add("Purchaser", typeof(string));
            dt.Columns.Add("TradeMode", typeof(string));
            dt.Columns.Add("TradeNature", typeof(string));
            dt.Columns.Add("Seaport", typeof(string));
            dt.Columns.Add("AdvancePayment", typeof(string));
            dt.Columns.Add("Profit", typeof(string));

            dt.Rows.Add("18G-002-001", "审批中", "19695000", "李佩", "002二部", DateTime.Now, DateTime.Now.AddDays(-10), DateTime.Now.AddMonths(10), "CRAFT OF SCANDINAVIA AB", "一般贸易", "做单", "SWE/瑞士", "800000", "900000");
            dt.Rows.Add("18G-002-002", "审批中", "19695000", "李佩", "002二部", DateTime.Now, DateTime.Now.AddDays(-10), DateTime.Now.AddMonths(10), "CRAFT OF SCANDINAVIA AB", "一般贸易", "做单", "SWE/瑞士", "800000", "900000");
            dt.Rows.Add("18G-002-003", "审批中", "19695000", "李佩", "002二部", DateTime.Now, DateTime.Now.AddDays(-10), DateTime.Now.AddMonths(10), "CRAFT OF SCANDINAVIA AB", "一般贸易", "做单", "SWE/瑞士", "800000", "900000");
            dt.Rows.Add("18G-002-004", "审批中", "19695000", "李佩", "002二部", DateTime.Now, DateTime.Now.AddDays(-10), DateTime.Now.AddMonths(10), "CRAFT OF SCANDINAVIA AB", "一般贸易", "做单", "SWE/瑞士", "800000", "900000");

            this.gridControl1.DataSource = dt;
        }


    }
}