using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using BudgetSystem.Entity;
using DevExpress.XtraEditors;
using BudgetSystem.Bll;

namespace BudgetSystem
{
    public partial class frmAccountBillView : frmBaseDialogForm
    {
        BudgetManager bm = new BudgetManager();
        public Budget CurrentBudget { get; set; }

        public List<AccountBill> AccountBillList { get; set; }

        public frmAccountBillView()
        {
            InitializeComponent();
        }

        private void frmAccountBillView_Load(object sender, EventArgs e)
        {
            this.Text = "按合同号查询收付情况";
            List<AccountBill> dataSource = bm.GetAccountBillDetailByBudgetId(CurrentBudget.ID);
            this.gcAccountBill.DataSource = dataSource;
            this.gcAccountBill.RefreshDataSource();

            this.lblBudgetNO.Text = CurrentBudget.ContractNO;

            this.textEdit_Number1.EditValue = dataSource.Sum(o => o.PaymentMoney);
            this.textEdit_Number2.EditValue = dataSource.Sum(o => o.RecieptMoney);
            this.textEdit_Number3.EditValue = dataSource.Sum(o => o.CNY);
        }


    }
}
