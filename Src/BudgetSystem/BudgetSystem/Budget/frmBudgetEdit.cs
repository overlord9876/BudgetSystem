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

namespace BudgetSystem
{
    public partial class frmBudgetEdit : frmBaseDialogForm
    {
        public Budget Budget { get; set; }

        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private Bll.CustomerManager cm = new Bll.CustomerManager();
        private Bll.SupplierManager sm = new Bll.SupplierManager();
       
        public frmBudgetEdit()
        {
            InitializeComponent();
        }
     
        private void frmBudgetEditEx_Load(object sender, EventArgs e)
        {
            this.InitData();
            if (this.WorkModel == EditFormWorkModels.New)
            {
                BindingBudgetDefaultInfo();
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

        private void InitData()
        {
            List<Customer> customers = cm.GetAllCustomer();
            this.ucCustomerSelected.SetDataSource(customers);
            List<Supplier> suppliers = sm.GetAllSupplier();
            this.ucSupplierSelected.SetDataSource(suppliers);
        }
     
        private string GetCustomerNames(List<Customer> customers)
        {
            if (customers != null && customers.Any())
            {
                List<string> names = new List<string>();
                customers.ForEach(c => names.Add(c.Name));
               return  string.Join(",", names.ToArray());
            }
            else
            {
               return string.Empty;
            } 
        }
       
        private string GetSupplierNames(List<Supplier> suppliers)
        {
            if (suppliers != null && suppliers.Any())
            {
                List<string> names = new List<string>();
                suppliers.ForEach(c => names.Add(c.Name));
                return string.Join(",", names.ToArray());
            }
            else
            {
                return string.Empty;
            }
        }
      
        private void BindingBudgetDefaultInfo()
        {
            this.txtDepartment.Text = RunInfo.Instance.CurrentUser.Department + RunInfo.Instance.CurrentUser.DepartmentName;
            this.txtSalesman.Text = RunInfo.Instance.CurrentUser.RealName;
            BindingOutProductDetail(string.Empty);
            BindingInProductDetail(string.Empty);
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
                this.txtDepartment.EditValue = budget.DepartmentDesc;
                this.txtFeedMoney.EditValue = budget.FeedMoney;
                this.txtInSettlementMethod1.Text = budget.InSettlementMethod1;
                this.txtInSettlementMethod2.Text = budget.InSettlementMethod2;
                this.txtInterestRate.EditValue = budget.InterestRate;
                this.txtOutSettlementMethod.Text = budget.OutSettlementMethod;
                this.txtOutSettlementMethod2.Text=budget.OutSettlementMethod2;
                this.txtOutSettlementMethod3.Text = budget.OutSettlementMethod3;
                this.txtPremium.EditValue = budget.Premium;
                this.txtPriceClause.Text = budget.PriceClause;
                this.txtSalesman.Text = budget.SalesmanName;
                this.txtSeaport.Text = budget.Seaport;
                this.txtTotalAmount.EditValue = budget.TotalAmount;
                this.dteSignDate.EditValue = budget.SignDate;
                this.dteValidity.EditValue = budget.Validity;
                this.ucCustomerSelected.SetSelectedItems(budget.CustomerList);
                this.chkIsQualified.CheckedChanged -= chkIsQualified_CheckedChanged;
                this.chkIsQualified.Checked = budget.IsQualifiedSupplier;
                this.chkIsQualified.CheckedChanged += chkIsQualified_CheckedChanged;
                this.ucSupplierSelected.SetSelectedItems(budget.SupplierList, this.chkIsQualified.Checked); 
                this.pceCustomer.Text = this.GetCustomerNames(budget.CustomerList);
                this.pceSupplier.Text = this.GetSupplierNames(budget.SupplierList); 
                this.rgTradeMode.EditValue = budget.TradeMode;
                this.rgTradeNature.EditValue = budget.TradeNature;
                this.meDescription.Text = budget.Description;
                this.txtTaxRebateRate.EditValue = budget.TaxRebateRate;
                this.txtQuota.EditValue = budget.Quota;
                this.txtExchangeRate.EditValue = budget.ExchangeRate;
                this.BindingOutProductDetail(budget.OutProductDetail);
                this.txtDirectCosts.EditValue = budget.DirectCosts;
                this.BindingInProductDetail(budget.InProductDetail);
                this.CalcInproductInterest();
                this.CalcBudgetSubtotal();
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
            budget.AdvancePayment = Convert.ToDecimal(txtAdvancePayment.EditValue); 
            budget.BankCharges = Convert.ToDecimal(txtBankCharges.EditValue); 
            budget.Commission = Convert.ToDecimal(txtCommission.EditValue);
            budget.ContractNO = this.txtContractNO.Text.Trim(); 
            budget.Days = Convert.ToInt32(txtDays.EditValue);
            budget.Department = RunInfo.Instance.CurrentUser.Department; 
            budget.FeedMoney = Convert.ToDecimal(txtFeedMoney.EditValue);
            budget.InSettlementMethod1 = this.txtInSettlementMethod1.Text.Trim();
            budget.InSettlementMethod2 = this.txtInSettlementMethod2.Text.Trim();
            budget.InterestRate = Convert.ToSingle(txtInterestRate.EditValue);
            budget.OutSettlementMethod = this.txtOutSettlementMethod.Text;
            budget.OutSettlementMethod2 = this.txtOutSettlementMethod2.Text;
            budget.OutSettlementMethod3 = this.txtOutSettlementMethod3.Text;
                        
            budget.Premium = Convert.ToDecimal(txtPremium.EditValue);
            budget.PriceClause = this.txtPriceClause.Text;
            budget.Salesman = RunInfo.Instance.CurrentUser.UserName;
            budget.Seaport = this.txtSeaport.Text;
                        
            budget.TotalAmount = Convert.ToDecimal( txtTotalAmount.EditValue);
            budget.SignDate = dteSignDate.DateTime;
            budget.Validity = dteValidity.DateTime;
            budget.CustomerList = ucCustomerSelected.SelectedCustomers;
            budget.SupplierList = ucSupplierSelected.SelectedSuppliers;
            budget.IsQualifiedSupplier = chkIsQualified.Checked;
            budget.TradeMode = Convert.ToInt32(this.rgTradeMode.EditValue);
            budget.TradeNature = Convert.ToInt32(this.rgTradeNature.EditValue);
            budget.Description = this.meDescription.Text.Trim(); 
            budget.TaxRebateRate = Convert.ToSingle( txtTaxRebateRate.EditValue);
            budget.Quota = Convert.ToDecimal(txtQuota.EditValue);
            budget.ExchangeRate = Convert.ToSingle(txtExchangeRate.EditValue);
            budget.OutProductDetail = this.GetOutProductDetailString();
            budget.DirectCosts = Convert.ToDecimal(this.txtDirectCosts.EditValue);
            budget.InProductDetail = this.GetInProductDetailString();
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
              
            Budget.AdvancePayment =Convert.ToDecimal( this.txtAdvancePayment.EditValue);
            Budget.BankCharges = Convert.ToDecimal(this.txtBankCharges.EditValue);
            Budget.Commission = Convert.ToDecimal(this.txtCommission.EditValue);
            Budget.ContractNO = this.txtContractNO.Text.Trim(); 
            Budget.Days =Convert.ToInt32( this.txtDays.EditValue);
            //Budget.Department = this.txtDepartment.Text.Trim(); 
            Budget.FeedMoney = Convert.ToDecimal(this.txtFeedMoney.EditValue);
            Budget.InSettlementMethod1 = this.txtInSettlementMethod1.Text.Trim();
            Budget.InSettlementMethod2 = this.txtInSettlementMethod2.Text.Trim();  
            Budget.InterestRate =Convert.ToSingle( txtInterestRate.EditValue);
            Budget.OutSettlementMethod = this.txtOutSettlementMethod.Text;
            Budget.OutSettlementMethod2 = this.txtOutSettlementMethod2.Text;
            Budget.OutSettlementMethod3 = this.txtOutSettlementMethod3.Text; 
            Budget.Premium = Convert.ToDecimal( txtPremium.EditValue);
            Budget.PriceClause = this.txtPriceClause.Text;
            // Budget.Salesman = this.txtSalesman.Text;
            Budget.Seaport = this.txtSeaport.Text;
            
            Budget.TotalAmount = Convert.ToDecimal(txtTotalAmount.EditValue);
            Budget.SignDate = dteSignDate.DateTime;
            Budget.Validity = dteValidity.DateTime;
            Budget.CustomerList = this.ucCustomerSelected.SelectedCustomers;
            Budget.SupplierList = this.ucSupplierSelected.SelectedSuppliers;
            Budget.IsQualifiedSupplier = this.chkIsQualified.Checked;
            Budget.TradeMode = Convert.ToInt32(this.rgTradeMode.EditValue);
            Budget.TradeNature = Convert.ToInt32(this.rgTradeNature.EditValue);
            Budget.Description = this.meDescription.Text.Trim();
            Budget.TaxRebateRate = Convert.ToSingle(txtTaxRebateRate.EditValue);
            Budget.Quota = Convert.ToDecimal(txtQuota.EditValue);
            Budget.ExchangeRate = Convert.ToSingle(txtExchangeRate.EditValue);
            Budget.OutProductDetail = this.GetOutProductDetailString();
            Budget.DirectCosts = Convert.ToDecimal(this.txtDirectCosts.EditValue);
            Budget.InProductDetail = this.GetInProductDetailString();
            bm.ModifyBudget(Budget); 
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private string GetOutProductDetailString()
        {
            //保存更改
            gvOutProductDetail.CloseEditor();

            var dataSource = (IEnumerable<OutProductDetail>)gridOutProductDetail.DataSource;
            if (dataSource != null)
            {
                return JsonConvert.SerializeObject(dataSource);
            }
            else
            {
                return "";
            }
        }
      
        private void BindingOutProductDetail(string detail)
        {
            List<OutProductDetail> outProductDetailList;
            if (!string.IsNullOrEmpty(detail))
            {
                outProductDetailList = JsonConvert.DeserializeObject<List<OutProductDetail>>(detail);
            }
            else
            {
                outProductDetailList = new List<OutProductDetail>();
            }
            this.gridOutProductDetail.DataSource = new BindingList<OutProductDetail>(outProductDetailList);
            this.gridOutProductDetail.RefreshDataSource();
        }

        private string GetInProductDetailString()
        {
            //保存更改
            bgvInProductDetail.CloseEditor(); 
            var dataSource = (IEnumerable<InProductDetail>)gridInProductDetail.DataSource;
            if (dataSource != null)
            {
                return JsonConvert.SerializeObject(dataSource);
            }
            else
            {
                return "";
            }
        }
       
        private void BindingInProductDetail(string detail)
        {
            List<InProductDetail> inProductDetailList;
            if (!string.IsNullOrEmpty(detail))
            {
                inProductDetailList = JsonConvert.DeserializeObject<List<InProductDetail>>(detail);
            }
            else
            {
                inProductDetailList = new List<InProductDetail>();
            }
            this.gridInProductDetail.DataSource = new BindingList<InProductDetail>(inProductDetailList);
            this.gridInProductDetail.RefreshDataSource();
        }


        /// <summary>
        /// 计算外贸合同金额
        /// </summary>
        private void CalcOutProductTotalAmount()
        {
            var dataSource = (IEnumerable<OutProductDetail>)gridOutProductDetail.DataSource;
            if (dataSource != null)
            {
                txtTotalAmount.EditValue = dataSource.Sum(o => o.CNY);
            }
        }
        
        private void CalcInProductTotalAmount()
        {
            var dataSource = (IEnumerable<InProductDetail>)gridInProductDetail.DataSource;
            if (dataSource != null)
            {
                txtDirectCosts.EditValue = dataSource.Sum(o => (o.Count * o.Subtotal));
            }
        }
       
        /// <summary>
        /// 计算内贸利息部分
        /// </summary>
        private void CalcInproductInterest()
        {
            decimal directCosts = Convert.ToDecimal(txtDirectCosts.EditValue); //总进价
            if (directCosts == 0)
            {
                return;
            }
            this.txtPercentage.EditValue = Convert.ToDecimal(txtAdvancePayment.EditValue) / directCosts;//预付款占总进价百分比
            //利息=预付款*月利息*天数/30
            txtInterest.EditValue = Convert.ToDecimal(txtAdvancePayment.EditValue) * Convert.ToDecimal(txtInterestRate.EditValue) * Convert.ToDecimal(txtDays.EditValue) / 30;
        }

        /// <summary>
        /// 计算预算部分的小计
        /// </summary>
        private void CalcBudgetSubtotal()
        { 
            //小计=配额+佣金+运保费+银行费用+其它(预)+进料款
            this.txtSubtotal.EditValue = Convert.ToDecimal(txtQuota.EditValue)
                                       + Convert.ToDecimal(txtCommission.EditValue)
                                       + Convert.ToDecimal(txtPremium.EditValue)
                                       + Convert.ToDecimal(txtBankCharges.EditValue)
                                       + Convert.ToDecimal(txtOther.EditValue)
                                       + Convert.ToDecimal(txtFeedMoney.EditValue);
        }
        private void pceCustomer_QueryPopUp(object sender, CancelEventArgs e)
        {
            PopupContainerEdit popupedit = (PopupContainerEdit)sender;
            pccCustomer.Width = popupedit.Width;
            pccCustomer.Height = 300;
        }

        private void pceCustomer_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            List<Customer> customers = this.ucCustomerSelected.SelectedCustomers;
            e.Value = GetCustomerNames(customers);
        }

        private void pceSupplier_QueryPopUp(object sender, CancelEventArgs e)
        {
            PopupContainerEdit popupedit = (PopupContainerEdit)sender;
            pccSupplier.Width = popupedit.Width;
            pccSupplier.Height = 300;
        }

        private void pceSupplier_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            List<Supplier> suppliers = this.ucSupplierSelected.SelectedSuppliers;
            e.Value = GetSupplierNames(suppliers);
        }

        private void chkIsQualified_CheckedChanged(object sender, EventArgs e)
        {
            this.ucSupplierSelected.SetSelectedItems(this.ucSupplierSelected.SelectedSuppliers, this.chkIsQualified.Checked);
            this.pceSupplier.ShowPopup();
        }

        void gvOutProductDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvOutProductDetail.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void gvOutProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var detail = e.Row as OutProductDetail;
            
            if (string.IsNullOrEmpty(detail.Name))
            {
                e.ErrorText = "产品规格不能为空";
                e.Valid = false;
                return;
            }
            if (string.IsNullOrEmpty(detail.Unit))
            {
                e.ErrorText = "单位不能为空";
                e.Valid = false;
                return;
            }
            if (detail.Count <= 0)
            {
                e.ErrorText = "数量应大于0";
                e.Valid = false;
                return;
            }
            if (detail.Price <= 0)
            {
                e.ErrorText = "单价应大于0";
                e.Valid = false;
                return;
            }
            if (detail.ExchangeRate <= 0)
            {
                e.ErrorText = "汇率应大于0";
                e.Valid = false;
                return;
            } 

        }
       
        void gvOutProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcCount
                || e.Column == gcPrice
                || e.Column == gcOriginalCurrencyMoney
                || e.Column == gcExchangeRate)
            {
                CalcOutProductTotalAmount();
            }
        }
       
        void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvOutProductDetail.FocusedRowHandle < 0)
            {
                gvOutProductDetail.CancelUpdateCurrentRow();
            }
            else
            {
                gvOutProductDetail.DeleteRow(gvOutProductDetail.FocusedRowHandle);
            }
            CalcOutProductTotalAmount();
        }

        void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        void bgvInProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var detail = e.Row as InProductDetail;

            if (string.IsNullOrEmpty(detail.Name))
            {
                e.ErrorText = "品名规格不能为空";
                e.Valid = false;
                return;
            }
            if (string.IsNullOrEmpty(detail.Unit))
            {
                e.ErrorText = "单位不能为空";
                e.Valid = false;
                return;
            }
            if (detail.Count <= 0)
            {
                e.ErrorText = "数量应大于0";
                e.Valid = false;
                return;
            }
            if (detail.Subtotal == 0)
            {
                e.ErrorText = "原料、辅料、加工应至少一项不为0";
                e.Valid = false;
                return;
            }
        }

        void bgvInProductDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            bgvInProductDetail.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void bgvInProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcInCount
               || e.Column == gcRawMaterials
               || e.Column == gcSubsidiaryMaterials
               || e.Column == gcProcessCost)
            {
                CalcInProductTotalAmount();
            }
        }

        void riLinkEditInDelete_Click(object sender, System.EventArgs e)
        {
            if (this.bgvInProductDetail.FocusedRowHandle < 0)
            {
                bgvInProductDetail.CancelUpdateCurrentRow();
            }
            else
            {
                bgvInProductDetail.DeleteRow(bgvInProductDetail.FocusedRowHandle);
            }
            CalcInProductTotalAmount();
        }

        void riLinkEditInDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void InProductDetail_EditValueChanged(object sender, EventArgs e)
        {
            this.CalcInproductInterest();
        }

        private void Charges_EditValueChanged(object sender, EventArgs e)
        {
            this.CalcBudgetSubtotal();
        }
    }
}
