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
using System.Text.RegularExpressions;

namespace BudgetSystem
{
    public partial class frmBudgetEdit : frmBaseDialogForm
    {
        public Budget Budget { get; set; }

        private decimal totalOriginalCurrency = 0;

        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private string contractNoPrefix =string.Empty; 
        public frmBudgetEdit()
        {
            InitializeComponent();
        }

        protected override void SubmitNewData()
        {
            base.SubmitNewData();

            this.dxErrorProvider1.ClearErrors();
            this.CheckContractNOInput();
            this.CheckCustomerInput(); 
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
            budget.InterestRate = Convert.ToSingle(txtInterestRate.EditValue);
            budget.OutSettlementMethod = this.txtOutSettlementMethod.Text;
            budget.OutSettlementMethod2 = this.txtOutSettlementMethod2.Text;
            budget.OutSettlementMethod3 = this.txtOutSettlementMethod3.Text;

            budget.Premium = Convert.ToDecimal(txtPremium.EditValue);
            budget.PriceClause = this.txtPriceClause.Text;
            budget.Salesman = RunInfo.Instance.CurrentUser.UserName;

            budget.TotalAmount = Convert.ToDecimal(txtTotalAmount.EditValue);
            budget.SignDate = dteSignDate.DateTime;
            budget.Validity = dteValidity.DateTime;
            budget.CustomerID = Convert.ToInt32(this.pceMainCustomer.Tag);
            budget.CustomerList = this.pceCustomer.Tag as List<Customer>;
            budget.SupplierList = ucSupplierSelected.SelectedSuppliers;
            budget.IsQualifiedSupplier = chkIsQualified.Checked;
            budget.TradeMode = Convert.ToInt32(this.rgTradeMode.EditValue);
            budget.TradeNature = Convert.ToInt32(this.rgTradeNature.EditValue);
            budget.Description = this.meDescription.Text.Trim();
            budget.ExchangeRate = Convert.ToSingle(txtExchangeRate.EditValue);
            budget.OutProductDetail = this.GetOutProductDetailString();
            budget.DirectCosts = Convert.ToDecimal(this.txtDirectCosts.EditValue);
            budget.InProductDetail = this.GetInProductDetailString();
            budget.Port = this.luePort.Text;
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

            Budget.AdvancePayment = Convert.ToDecimal(this.txtAdvancePayment.EditValue);
            Budget.BankCharges = Convert.ToDecimal(this.txtBankCharges.EditValue);
            Budget.Commission = Convert.ToDecimal(this.txtCommission.EditValue);
            Budget.ContractNO = this.txtContractNO.Text.Trim();
            Budget.Days = Convert.ToInt32(this.txtDays.EditValue);
            Budget.FeedMoney = Convert.ToDecimal(this.txtFeedMoney.EditValue);
            Budget.InterestRate = Convert.ToSingle(txtInterestRate.EditValue);
            Budget.OutSettlementMethod = this.txtOutSettlementMethod.Text;
            Budget.OutSettlementMethod2 = this.txtOutSettlementMethod2.Text;
            Budget.OutSettlementMethod3 = this.txtOutSettlementMethod3.Text;
            Budget.Premium = Convert.ToDecimal(txtPremium.EditValue);
            Budget.PriceClause = this.txtPriceClause.Text;
            Budget.Port = this.luePort.Text;
            Budget.TotalAmount = Convert.ToDecimal(txtTotalAmount.EditValue);
            Budget.SignDate = dteSignDate.DateTime;
            Budget.Validity = dteValidity.DateTime;
            Budget.CustomerList = this.ucCustomerSelected.SelectedCustomers;
            Budget.SupplierList = this.ucSupplierSelected.SelectedSuppliers;
            Budget.IsQualifiedSupplier = this.chkIsQualified.Checked;
            Budget.TradeMode = Convert.ToInt32(this.rgTradeMode.EditValue);
            Budget.TradeNature = Convert.ToInt32(this.rgTradeNature.EditValue);
            Budget.Description = this.meDescription.Text.Trim();
            Budget.ExchangeRate = Convert.ToSingle(txtExchangeRate.EditValue);
            Budget.OutProductDetail = this.GetOutProductDetailString();
            Budget.DirectCosts = Convert.ToDecimal(this.txtDirectCosts.EditValue);
            Budget.InProductDetail = this.GetInProductDetailString();
            bm.ModifyBudget(Budget);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }



        private void InitData()
        {
            Bll.CustomerManager cm = new Bll.CustomerManager();
            List<Customer> customers = cm.GetAllCustomer();
            this.ucCustomerSelected.SetDataSource(customers);

            Bll.SupplierManager sm = new Bll.SupplierManager();
            List<Supplier> suppliers = sm.GetAllSupplier();
            this.ucSupplierSelected.SetDataSource(suppliers);

            Bll.SystenConfigManager scm = new Bll.SystenConfigManager();
            DataTable dtPort = scm.GetSystemConfigValue(EnumSystemConfigNames.港口信息.ToString());
            this.luePort.Properties.DataSource = dtPort;
        }

        private void BindingBudgetDefaultInfo()
        {
            this.txtDepartment.Text = RunInfo.Instance.CurrentUser.Department + RunInfo.Instance.CurrentUser.DepartmentName;
            this.txtSalesman.Text = RunInfo.Instance.CurrentUser.RealName;
            contractNoPrefix = DateTime.Now.ToString("yy") + "-" + RunInfo.Instance.CurrentUser.Department+"-";

            this.txtContractNO.Text = contractNoPrefix;
            //this.txtContractNO.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            //this.txtContractNO.Properties.Mask.EditMask = "("+contractNoPrefix+")\\d{4}";
            //this.txtContractNO.Properties.NullText = contractNoPrefix; 

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
                this.txtInterestRate.EditValue = budget.InterestRate;
                this.txtOutSettlementMethod.Text = budget.OutSettlementMethod;
                this.txtOutSettlementMethod2.Text = budget.OutSettlementMethod2;
                this.txtOutSettlementMethod3.Text = budget.OutSettlementMethod3;
                this.txtPremium.EditValue = budget.Premium;
                this.txtPriceClause.Text = budget.PriceClause;
                this.txtSalesman.Text = budget.SalesmanName;
                this.txtTotalAmount.EditValue = budget.TotalAmount;
                this.dteSignDate.EditValue = budget.SignDate;
                this.dteValidity.EditValue = budget.Validity;
                this.chkIsQualified.CheckedChanged -= chkIsQualified_CheckedChanged;
                this.chkIsQualified.Checked = budget.IsQualifiedSupplier;
                this.chkIsQualified.CheckedChanged += chkIsQualified_CheckedChanged;
                this.ucSupplierSelected.SetSelectedItems(budget.SupplierList, this.chkIsQualified.Checked);
                this.pceCustomer.Text = budget.CustomerList.ToNameString();
                this.pceCustomer.Tag = budget.CustomerList;
                this.pceMainCustomer.Text = budget.CustomerName;
                this.pceMainCustomer.Tag = budget.CustomerID;
                this.pceSupplier.Text = budget.SupplierList.ToNameString();
                this.rgTradeMode.EditValue = budget.TradeMode;
                this.rgTradeNature.EditValue = budget.TradeNature;
                this.meDescription.Text = budget.Description;
                this.txtExchangeRate.EditValue = budget.ExchangeRate;
                this.BindingOutProductDetail(budget.OutProductDetail);
                this.txtDirectCosts.EditValue = budget.DirectCosts;
                this.luePort.EditValue = budget.Port;
                this.BindingInProductDetail(budget.InProductDetail);
                this.CalcInproductInterest();
                this.CalcBudgetSubtotal();
            }
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

        #region Check Method
        private void CheckContractNOInput()
        {
            string contractNo=this.txtContractNO.Text.Trim();
            if (string.IsNullOrEmpty(contractNo))
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "请输入合同编号");
                return ;
            }
            Match match= Regex.Match(contractNo,"("+contractNoPrefix+")\\d{4}$");
            if (!match.Success)
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "合同编号格式应为：yy-部门编号-4位数字");
                return;
            }
            int id=this.Budget==null?0:this.Budget.ID;
            if (bm.CheckContractNO(id, contractNo))
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "合同编号已存在");
                return;
            }
        }
        private void CheckCustomerInput()
        {
            if (string.IsNullOrEmpty(this.pceMainCustomer.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.pceMainCustomer, "请选择主买方");
                return;
            }
        }

        #endregion

        #region Calc Method

        /// <summary>
        /// 计算外贸合同金额
        /// </summary>
        private void CalcOutProductTotalAmount()
        {
            var dataSource = (IEnumerable<OutProductDetail>)gridOutProductDetail.DataSource;
            if (dataSource != null)
            {
                txtTotalAmount.EditValue = dataSource.Sum(o => o.CNY);
                totalOriginalCurrency = dataSource.Sum(o => o.OriginalCurrencyMoney);
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
        /// 计算净收入额（原币）=净收入额（人民币）/汇率
        /// </summary>
        private void CalcNetIncome()
        {
            if (txtExchangeRate.Value == 0)
            {
                txtNetIncome.EditValue = 0;
            }
            else
            {
                txtNetIncome.EditValue = Math.Round(txtNetIncomeCNY.Value / txtExchangeRate.Value, 2);
            }
        }

        /// <summary>
        /// 净收入额=外贸合约部分人民币小计（合同金额）-内贸合约部分的利息-预算部分的小计
        /// </summary>
        private void CalcNetIncomeCNY()
        {
            txtNetIncomeCNY.EditValue = this.txtTotalAmount.Value  - txtSubtotal.Value;
        }

        /// <summary>
        /// 计算总成本
        /// </summary>
        private void CalcTotalCost()
        {
            txtTotalCost.EditValue = txtDirectCosts.Value - txtTaxRebateRateMoney.Value;
        }

        /// <summary>
        /// 出口退税额
        /// </summary>
        private void CalcTaxRebateRateMoney()
        {
            var dataSource = (IEnumerable<InProductDetail>)gridInProductDetail.DataSource;
            if (dataSource != null)
            {
                txtTaxRebateRateMoney.EditValue = dataSource.Sum(o => (o.TaxRebate));
            } 
        }

        /// <summary>
        /// 税后换汇成本=总成本/净收入额（USD）
        /// </summary>
        private void CalcExchangeCost()
        {
            if (txtTotalAmount.Value == 0||txtExchangeRate.Value==0)
            {
                txtExchangeCost.EditValue = 0;
            }
            else
            {
                txtExchangeCost.EditValue = Math.Round(txtTotalCost.Value / txtTotalAmount.Value/txtExchangeRate.Value, 2);
            }
        }

        /// <summary>
        /// 盈利水平1=利润/合同金额/汇率(USD) 
        /// </summary>
        private void CalcProfitLevel1()
        {
            if (txtTotalAmount.Value == 0 || txtExchangeRate.Value == 0)
            {
                txtProfitLevel1.EditValue = 0;
            }
            else
            {
                txtProfitLevel1.EditValue = Math.Round(txtProfit.Value / txtTotalAmount.Value / txtExchangeRate.Value, 2);
            }
        }
        /// <summary>
        /// 盈利水平2=利润/净收入额(USD)
        /// </summary>
        private void CalcProfitLevel2()
        {
            if (txtNetIncome.Value == 0)
            {
                txtProfitLevel2.EditValue = 0;
            }
            else
            {
                txtProfitLevel2.EditValue = Math.Round(txtProfit.Value / txtNetIncome.Value, 2);
            }
        }

        /// <summary>
        /// 销售利润=销售收入（人民币）-销售成本-（运保、佣金、直接费用）小计-利息
        /// </summary>
        private void CalcProfit()
        {
            txtProfit.EditValue = txtNetIncomeCNY.Value - txtTotalCost.Value - txtInterest.Value;
        }

        /// <summary>
        /// 计算内贸利息部分
        /// </summary>
        private void CalcInproductInterest()
        {
            decimal directCosts = Convert.ToDecimal(txtDirectCosts.EditValue); //总进价
            if (directCosts != 0)
            { 
                this.txtPercentage.EditValue = Math.Round(txtAdvancePayment.Value / directCosts * 100, 2);//预付款占总进价百分比
            }
           
            //利息=预付款*年利率/360/100*天数
            txtInterest.EditValue = Convert.ToDecimal(txtAdvancePayment.EditValue) * Convert.ToDecimal(txtInterestRate.EditValue) * Convert.ToDecimal(txtDays.EditValue) / 360 / 100;
        }

        /// <summary>
        /// 计算预算部分的小计
        /// </summary>
        private void CalcBudgetSubtotal()
        {
            //小计=配额+佣金+运保费+银行费用+其它(预)+进料款
            this.txtSubtotal.EditValue = Convert.ToDecimal(txtCommission.EditValue)
                                       + Convert.ToDecimal(txtPremium.EditValue)
                                       + Convert.ToDecimal(txtBankCharges.EditValue)
                                       + Convert.ToDecimal(txtOther.EditValue)
                                       + Convert.ToDecimal(txtFeedMoney.EditValue);
        } 
        #endregion

        #region Event Method
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
                this.txtContractNO.Properties.ReadOnly = true;
                this.pceMainCustomer.Properties.ReadOnly = true;
                BindingBudget(Budget.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                this.Text = "查看预算单信息";
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

        private void pceCustomer_QueryPopUp(object sender, CancelEventArgs e)
        {
            this.pceCustomer.Properties.PopupControl = this.pccCustomer;
            pccCustomer.Width = this.pceCustomer.Width;
            pccCustomer.Height = 300;
            ucCustomerSelected.IsShowSelectedColumn = true;
            ucCustomerSelected.SetSelectedItems(this.pceCustomer.Tag as List<Customer>);
        }

        private void pceCustomer_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            List<Customer> customers = this.ucCustomerSelected.SelectedCustomers;
            e.Value = customers.ToNameString();
            pceCustomer.Tag = customers;
        }

        private void pceMainCustomer_QueryPopUp(object sender, CancelEventArgs e)
        {
            this.pceMainCustomer.Properties.PopupControl = this.pccCustomer;
            pccCustomer.Width = pceMainCustomer.Width;
            pccCustomer.Height = 300;
            ucCustomerSelected.IsShowSelectedColumn = false;
            ucCustomerSelected.SetFocusedItem(Convert.ToInt32(pceMainCustomer.Tag));
        }

        private void pceMainCustomer_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            Customer customer = this.ucCustomerSelected.FocusedCustomer;
            if (customer != null)
            {
                e.Value = customer.Name;
                pceMainCustomer.Tag = customer.ID;
                this.luePort.Text = customer.Port;
            }
            else
            {
                e.Value = string.Empty;
                pceMainCustomer.Tag = 0;
            }
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
            e.Value = suppliers.ToNameString();
        }

        private void chkIsQualified_CheckedChanged(object sender, EventArgs e)
        {
            this.ucSupplierSelected.SetSelectedItems(this.ucSupplierSelected.SelectedSuppliers, this.chkIsQualified.Checked);
            this.pceSupplier.ShowPopup();
        }

        private void gvOutProductDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            gvOutProductDetail.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvOutProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
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

        private void gvOutProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcCount
                || e.Column == gcPrice
                || e.Column == gcOriginalCurrencyMoney
                || e.Column == gcExchangeRate)
            {
                CalcOutProductTotalAmount();
            }
        }

        private void riLinkDelete_Click(object sender, System.EventArgs e)
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

        private void riLinkDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void bgvInProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
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
            if (detail.TaxRebateRate == 0)
            {
                e.ErrorText = "退税率应大于0";
                e.Valid = false;
                return;
            }
        }

        private void bgvInProductDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            bgvInProductDetail.SetColumnError(null, e.ErrorText);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void bgvInProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcInCount
               || e.Column == gcRawMaterials
               || e.Column == gcSubsidiaryMaterials
               || e.Column == gcProcessCost)
            {
                CalcInProductTotalAmount();
                CalcTaxRebateRateMoney();
            }
        }

        private void riLinkEditInDelete_Click(object sender, System.EventArgs e)
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
            CalcTaxRebateRateMoney();
        }

        private void riLinkEditInDelete_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "删除";
        }

        private void InProductDetail_EditValueChanged(object sender, EventArgs e)
        {
            CalcInproductInterest();
            CalcTotalCost();
        }

        private void Charges_EditValueChanged(object sender, EventArgs e)
        {
            this.CalcBudgetSubtotal();
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetIncome();
            CalcProfitLevel1();
            CalcExchangeCost();
        }

        

        private void txtTaxRebateRateMoney_EditValueChanged(object sender, EventArgs e)
        {
            CalcTotalCost();
        }

        private void txtTotalAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetIncomeCNY();
            CalcProfitLevel1();
            CalcExchangeCost();
        }

        private void txtInterest_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetIncomeCNY();
            CalcProfit();
        }

        private void txtSubtotal_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetIncomeCNY();

        }

        private void txtNetIncomeCNY_EditValueChanged(object sender, EventArgs e)
        {
            CalcNetIncome();
            CalcProfit();
        }

        private void txtTotalCost_EditValueChanged(object sender, EventArgs e)
        {
            CalcExchangeCost();
            CalcProfit();
        }

        private void txtNetIncome_EditValueChanged(object sender, EventArgs e)
        {
            CalcProfitLevel2();
        }

        private void txtProfit_EditValueChanged(object sender, EventArgs e)
        {
            CalcProfitLevel1();
            CalcProfitLevel2();
        } 
        #endregion
    }
}
