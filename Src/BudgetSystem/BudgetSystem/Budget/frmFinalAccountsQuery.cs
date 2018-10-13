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
    public partial class frmFinalAccountsQuery : frmBaseQueryFormWithCondtion
    {
        public frmFinalAccountsQuery()
        {
            InitializeComponent();

        }


        protected override void InitModelOperate()
        {
            base.InitModelOperate();
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewMoney));
            this.ModelOperateRegistry.Add(ModelOperateHelper.GetOperate(OperateTypes.ViewMoneyDetail));
            this.ModelOperatePageName = "决算管理";
        }


        public override void OperateHandled(ModelOperate operate)
        {

            if (operate.Operate == OperateTypes.ViewMoney.ToString())
            {
                frmMoneyInOutDetailEdit form = new frmMoneyInOutDetailEdit();
                form.ShowDialog(this);
            }
            else if (operate.Operate == OperateTypes.ViewMoneyDetail.ToString())
            {
                frmMoneyDetailEdit form = new frmMoneyDetailEdit();
                form.ShowDialog(this);
            }
            else
            {
                XtraMessageBox.Show("未定义的操作");
            }
        }

        public override void LoadData()
        {
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