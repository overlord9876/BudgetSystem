using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using BudgetSystem.Entity;
using DevExpress.XtraEditors;

namespace BudgetSystem
{
    public partial class frmBudgetEditEx : frmBaseDialogForm
    {
        public Budget Budget { get; set; }

        private Bll.BudgetManager bm = new Bll.BudgetManager();

        public frmBudgetEditEx()
        {
            InitializeComponent();
        }
        private void frmBudgetEditEx_Load(object sender, EventArgs e)
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                this.Text = "创建预算单"; 
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.Text = "编辑预算单信息";
                BindingBudget(Budget.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看预算单信息";
                this.txtAdvancePayment.Properties.ReadOnly = true;
                this.txtBankCharges.Properties.ReadOnly = true;
                foreach (var control in this.layoutControl1.Controls)
                {
                    if (control is BaseEdit)
                    {
                        (control as BaseEdit).Properties.ReadOnly = true;
                    }
                }
                BindingBudget(Budget.ID);
            }
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            SubmitDataByWorkModel();
        }

        private void BindingBudget(int id)
        {
            Budget budget = bm.GetBudget(id);
            if (budget != null)
            {
                this.txtAdvancePayment.EditValue = budget.AdvancePayment;
                this.txtBankCharges.EditValue = budget.BankCharges;
                this.txtCommission.EditValue = budget.Commission;
                this.txtContractNO.Text = budget.ContractNO;
                this.txtDays.EditValue = budget.Days;
                this.txtDepartment.EditValue = budget.Department;
                this.txtFeedMoney.EditValue = budget.FeedMoney;
                this.txtInSettlementMethod1.Text = budget.InSettlementMethod1;
                this.txtInSettlementMethod2.Text = budget.InSettlementMethod2;
                this.txtInterestRate.EditValue = budget.InterestRate;
                this.txtOutSettlementMethod.Text = budget.OutSettlementMethod;
                this.txtOutSettlementMethod2.Text=budget.OutSettlementMethod2;
                this.txtOutSettlementMethod3.Text = budget.OutSettlementMethod3;
                this.txtPremium.EditValue = budget.Premium;
                this.txtPriceClause.Text = budget.PriceClause;
                this.txtSalesman.Text = budget.Salesman;
                this.txtSeaport.Text = budget.Seaport;
                this.txtTotalAmount.EditValue = budget.TotalAmount;
                this.dteSignDate.EditValue = budget.SignDate;
                this.dteValidity.EditValue = budget.Validity;
                if(budget.CustomerList!=null&& budget.CustomerList.Any())
                {
                    this.bteCustomer.Text=budget.CustomerList[0].ID.ToString();
                }
                if (budget.SupplierList != null && budget.SupplierList.Any())
                {
                    this.bteSupplier.Text = budget.SupplierList[0].ID.ToString();
                }
                this.rgTradeMode.EditValue = (int)budget.TradeMode;
                this.rgTradeNature.EditValue = (int)budget.TradeNature;

            }
        
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();
            //TODO:Check
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
            Budget budget = new Budget();
            budget.State = "待审批";
            decimal decimalValue=0;
            decimal.TryParse(this.txtAdvancePayment.Text.Trim(),out decimalValue);
            budget.AdvancePayment = decimalValue;
            decimal.TryParse(this.txtBankCharges.Text.Trim(), out decimalValue);
            budget.BankCharges = decimalValue;
            decimal.TryParse(this.txtCommission.Text.Trim(), out decimalValue);
            budget.Commission = decimalValue;
            budget.ContractNO = this.txtContractNO.Text.Trim();
            int intValue = 0;
            int.TryParse(this.txtDays.Text.Trim(), out intValue);
            budget.Days = intValue; 
            budget.Department = this.txtDepartment.Text.Trim();
            decimal.TryParse(this.txtFeedMoney.Text.Trim(), out decimalValue);
            budget.FeedMoney = decimalValue;
            budget.InSettlementMethod1 = this.txtInSettlementMethod1.Text.Trim();
            budget.InSettlementMethod2 = this.txtInSettlementMethod2.Text.Trim();
            float floatValue = 0;
            float.TryParse(this.txtInterestRate.Text.Trim(), out floatValue);
            budget.InterestRate = floatValue;  
             budget.OutSettlementMethod= this.txtOutSettlementMethod.Text;
             budget.OutSettlementMethod2= this.txtOutSettlementMethod2.Text;
             budget.OutSettlementMethod3= this.txtOutSettlementMethod3.Text;

             decimal.TryParse(this.txtPremium.Text.Trim(), out decimalValue);
             budget.Premium = decimalValue; 
             budget.PriceClause=this.txtPriceClause.Text;
             budget.Salesman=this.txtSalesman.Text;
             budget.Seaport=this.txtSeaport.Text;
             
             decimal.TryParse(this.txtTotalAmount.Text.Trim(), out decimalValue);
             budget.TotalAmount = decimalValue; 
             budget.SignDate = dteSignDate.DateTime;
             budget.Validity = dteValidity.DateTime;
             budget.CustomerList = new List<Customer>();
             if (!string.IsNullOrEmpty(this.bteCustomer.Text))
             {
                 budget.CustomerList.Add(new Customer() { ID = int.Parse(this.bteCustomer.Text.Trim()) });
             }
            budget.SupplierList=new List<Supplier>();
            if(!string.IsNullOrEmpty(this.bteSupplier.Text))
            {
                budget.SupplierList.Add(new Supplier(){ID=int.Parse(this.bteSupplier.Text)});  
            } 
            budget.TradeMode = (int)this.rgTradeMode.EditValue;
            budget.TradeNature = (int)this.rgTradeNature.EditValue; 
            int result = bm.AddBudget(budget); 
            if (result <= 0)
            {
                XtraMessageBox.Show("创建失败！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }



        protected override void SubmitModifyData()
        {
            base.SubmitModifyData();
            this.dxErrorProvider1.ClearErrors(); 
            if (dxErrorProvider1.HasErrors)
            {
                return;
            }
             
            decimal decimalValue = 0;
            decimal.TryParse(this.txtAdvancePayment.Text.Trim(), out decimalValue);
            Budget.AdvancePayment = decimalValue;
            decimal.TryParse(this.txtBankCharges.Text.Trim(), out decimalValue);
            Budget.BankCharges = decimalValue;
            decimal.TryParse(this.txtCommission.Text.Trim(), out decimalValue);
            Budget.Commission = decimalValue;
            Budget.ContractNO = this.txtContractNO.Text.Trim();
            int intValue = 0;
            int.TryParse(this.txtDays.Text.Trim(), out intValue);
            Budget.Days = intValue;
            Budget.Department = this.txtDepartment.Text.Trim();
            decimal.TryParse(this.txtFeedMoney.Text.Trim(), out decimalValue);
            Budget.FeedMoney = decimalValue;
            Budget.InSettlementMethod1 = this.txtInSettlementMethod1.Text.Trim();
            Budget.InSettlementMethod2 = this.txtInSettlementMethod2.Text.Trim();
            float floatValue = 0;
            float.TryParse(this.txtInterestRate.Text.Trim(), out floatValue);
            Budget.InterestRate = floatValue;
            Budget.OutSettlementMethod = this.txtOutSettlementMethod.Text;
            Budget.OutSettlementMethod2 = this.txtOutSettlementMethod2.Text;
            Budget.OutSettlementMethod3 = this.txtOutSettlementMethod3.Text;

            decimal.TryParse(this.txtPremium.Text.Trim(), out decimalValue);
            Budget.Premium = decimalValue;
            Budget.PriceClause = this.txtPriceClause.Text;
            Budget.Salesman = this.txtSalesman.Text;
            Budget.Seaport = this.txtSeaport.Text;

            decimal.TryParse(this.txtTotalAmount.Text.Trim(), out decimalValue);
            Budget.TotalAmount = decimalValue;
            Budget.SignDate = dteSignDate.DateTime;
            Budget.Validity = dteValidity.DateTime;
            Budget.CustomerList = new List<Customer>();
            if (!string.IsNullOrEmpty(this.bteCustomer.Text))
            {
                Budget.CustomerList.Add(new Customer() { ID = int.Parse(this.bteCustomer.Text.Trim()) });
            }
            Budget.SupplierList = new List<Supplier>();
            if (!string.IsNullOrEmpty(this.bteSupplier.Text))
            {
                Budget.SupplierList.Add(new Supplier() { ID = int.Parse(this.bteSupplier.Text) });
            }
            Budget.TradeMode = (int)this.rgTradeMode.EditValue;
            Budget.TradeNature = (int)this.rgTradeNature.EditValue;
            bm.ModifyBudget(Budget); 
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
