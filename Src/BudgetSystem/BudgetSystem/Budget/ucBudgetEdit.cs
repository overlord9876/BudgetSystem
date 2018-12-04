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
    public partial class ucBudgetEdit : DataControl
    {
        public Budget CurrentBudget { get; set; }

        /// <summary>
        /// 增值税配置项值 
        /// </summary>
        private decimal vatOption = 0;

        private decimal totalOriginalCurrency = 0;

        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private string contractNoPrefix = string.Empty;
        private EditFormWorkModels _workModel;

        public EditFormWorkModels WorkModel
        {
            get { return this._workModel; }
            set
            {
                this._workModel = value;
                InitControlState();
            }
        }

        public ucBudgetEdit()
        {
            InitializeComponent();
        }

        public override void BindingData(int dataID)
        {
            BindingBudget(dataID);
        }

        public bool CheckInputData()
        {
            this.dxErrorProvider1.ClearErrors();
            this.CheckContractNOInput();
            this.CheckDateInput();
            this.CheckCustomerInput();
            if (txtExchangeRate.Value <= 0)
            {
                this.dxErrorProvider1.SetError(txtExchangeRate, "汇率值错误。");
            }

            if (dxErrorProvider1.HasErrors
                || CheckOutProductDetailInput() == false
                || CheckInProductDetailInput() == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void FillData()
        {
            if (this.CurrentBudget == null)
            {
                //新增
                this.CurrentBudget = new Budget();
                CurrentBudget.State = "待审批";
                CurrentBudget.CreateDate = DateTime.Now;
                CurrentBudget.Department = RunInfo.Instance.CurrentUser.Department;
                CurrentBudget.Salesman = RunInfo.Instance.CurrentUser.UserName;
                CurrentBudget.SalesmanName = RunInfo.Instance.CurrentUser.RealName;
                //主买方不允许修改，所以只有新增时获取选择值 
                CurrentBudget.CustomerID = Convert.ToInt32(this.pceMainCustomer.Tag);
            }
            CurrentBudget.AdvancePayment = this.txtAdvancePayment.Value;
            CurrentBudget.BankCharges = this.txtBankCharges.Value;
            CurrentBudget.Commission = this.txtCommission.Value;
            CurrentBudget.ContractNO = this.txtContractNO.Text.Trim();
            CurrentBudget.Days = Convert.ToInt32(this.txtDays.EditValue);
            CurrentBudget.FeedMoney = this.txtFeedMoney.Value;
            CurrentBudget.DirectCosts = this.txtDirectCosts.Value;
            CurrentBudget.InterestRate = Convert.ToSingle(txtInterestRate.EditValue);
            CurrentBudget.OutSettlementMethod = this.txtOutSettlementMethod.Text;
            CurrentBudget.OutSettlementMethod2 = this.txtOutSettlementMethod2.Text;
            CurrentBudget.OutSettlementMethod3 = this.txtOutSettlementMethod3.Text;
            CurrentBudget.Premium = txtPremium.Value;
            CurrentBudget.Profit = this.txtProfit.Value;
            CurrentBudget.PriceClause = this.txtPriceClause.Text;
            CurrentBudget.Port = this.luePort.Text;
            CurrentBudget.TotalAmount = txtTotalAmount.Value;
            CurrentBudget.USDTotalAmount = txtUSDTotalAmount.Value;
            CurrentBudget.SignDate = dteSignDate.DateTime;
            CurrentBudget.Validity = dteValidity.DateTime;
            CurrentBudget.CustomerList = this.ucCustomerSelected.SelectedCustomers;
            CurrentBudget.SupplierList = this.ucSupplierSelected.SelectedSuppliers;
            CurrentBudget.IsQualifiedSupplier = this.chkIsQualified.Checked;
            CurrentBudget.TradeMode = 0;
            if (chkTradeMode1.Checked)
            {
                CurrentBudget.TradeMode += (int)EnumTradeMode.一般贸易;
            }
            if (chkTradeMode2.Checked)
            {
                CurrentBudget.TradeMode += (int)EnumTradeMode.来料加工;
            }
            if (chkTradeMode3.Checked)
            {
                CurrentBudget.TradeMode += (int)EnumTradeMode.进料加工;
            }
            if (chkTradeMode4.Checked)
            {
                CurrentBudget.TradeMode += (int)EnumTradeMode.纯进口;
            }
            if (chkTradeMode5.Checked)
            {
                CurrentBudget.TradeMode += (int)EnumTradeMode.内贸;
            }
            CurrentBudget.TradeNature = Convert.ToInt32(this.rgTradeNature.EditValue);
            CurrentBudget.Description = this.meDescription.Text.Trim();
            CurrentBudget.ProfitLevel1 = this.txtProfitLevel1.Value;
            CurrentBudget.ProfitLevel2 = this.txtProfitLevel2.Value;
            CurrentBudget.ExchangeRate = Convert.ToSingle(txtExchangeRate.EditValue);
            CurrentBudget.OutProductDetail = this.GetOutProductDetailString();
            CurrentBudget.PurchasePrice = this.txtPurchasePrice.Value;
            CurrentBudget.InProductDetail = this.GetInProductDetailString();
            CurrentBudget.UpdateDate = DateTime.Now;
            CurrentBudget.UpdateUser = RunInfo.Instance.CurrentUser.UserName;
            CurrentBudget.UpdateUserName = RunInfo.Instance.CurrentUser.RealName;
        }

        public void InitData()
        {
            Bll.CustomerManager cm = new Bll.CustomerManager();
            List<Customer> customers = cm.GetAllCustomer();
            this.ucCustomerSelected.SetDataSource(customers);

            Bll.SupplierManager sm = new Bll.SupplierManager();
            List<Supplier> suppliers = sm.GetAllSupplier();
            this.ucSupplierSelected.SetDataSource(suppliers);

            Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
            List<Port> portList = scm.GetSystemConfigValue<List<Port>>(EnumSystemConfigNames.港口信息.ToString());
            this.luePort.Properties.DataSource = portList;
            this.vatOption = scm.GetSystemConfigValue<decimal>(EnumSystemConfigNames.增值税税率.ToString());

            List<MoneyType> moneyTypeList = scm.GetSystemConfigValue<List<MoneyType>>(EnumSystemConfigNames.币种.ToString());
            this.ricboOriginalCurrency.Items.Clear();
            moneyTypeList.ForEach(m => ricboOriginalCurrency.Items.Add(m.Name));

        }

        private void InitControlState()
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                BindingBudgetDefaultInfo();
            }
            else if (this.WorkModel == EditFormWorkModels.Modify)
            {
                this.txtContractNO.Properties.ReadOnly = true;
                this.pceMainCustomer.Properties.ReadOnly = true;
                BindingBudget(CurrentBudget.ID);
            }
            else if (this.WorkModel == EditFormWorkModels.View)
            {
                SetReadOnly();
                if (CurrentBudget != null)
                {
                    BindingBudget(CurrentBudget.ID);
                }
            }
        }

        private void SetReadOnly()
        {
            foreach (var control in this.layoutControl1.Controls)
            {
                if (control is BaseEdit)
                {
                    (control as BaseEdit).Properties.ReadOnly = true;
                }
            }

            this.btnSync.Enabled = false;
            this.gvOutProductDetail.Columns.Remove(this.colDelete);
            this.gvOutProductDetail.OptionsBehavior.Editable = false;

            this.bgvInProductDetail.Columns.Remove(this.gcInDelete);
            this.bgvInProductDetail.OptionsBehavior.Editable = false;
        }

        private void BindingBudgetDefaultInfo()
        {
            this.txtDepartment.Text = RunInfo.Instance.CurrentUser.Department + RunInfo.Instance.CurrentUser.DepartmentName;
            this.txtSalesman.Text = RunInfo.Instance.CurrentUser.RealName;
            contractNoPrefix = DateTime.Now.ToString("yy") + "-" + RunInfo.Instance.CurrentUser.Department + "-";

            this.txtContractNO.Text = contractNoPrefix;
            this.dteSignDate.EditValue = DateTime.Now;
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
                this.txtDirectCosts.EditValue = budget.DirectCosts;
                this.txtInterestRate.EditValue = budget.InterestRate;
                this.txtOutSettlementMethod.Text = budget.OutSettlementMethod;
                this.txtOutSettlementMethod2.Text = budget.OutSettlementMethod2;
                this.txtOutSettlementMethod3.Text = budget.OutSettlementMethod3;
                this.txtPremium.EditValue = budget.Premium;
                this.txtPriceClause.Text = budget.PriceClause;
                this.txtSalesman.Text = budget.SalesmanName;
                this.txtTotalAmount.EditValue = budget.TotalAmount;
                this.txtUSDTotalAmount.EditValue = budget.USDTotalAmount;
                this.dteSignDate.EditValue = budget.SignDate;
                this.dteValidity.EditValue = budget.Validity;
                this.chkIsQualified.CheckedChanged -= chkIsQualified_CheckedChanged;
                this.chkIsQualified.Checked = budget.IsQualifiedSupplier;
                this.ucSupplierSelected.SetSelectedItems(budget.SupplierList, this.chkIsQualified.Checked);
                this.chkIsQualified.CheckedChanged += chkIsQualified_CheckedChanged;

                this.pceCustomer.Text = budget.CustomerList.ToNameString();
                this.pceCustomer.Tag = budget.CustomerList;
                this.pceMainCustomer.Text = budget.CustomerName;
                this.pceMainCustomer.Tag = budget.CustomerID;
                this.pceSupplier.Text = budget.SupplierList.ToNameString();
                EnumTradeMode tradeMode = (EnumTradeMode)Enum.Parse(typeof(EnumTradeMode), budget.TradeMode.ToString());
                if ((tradeMode & EnumTradeMode.一般贸易) != 0)
                {
                    chkTradeMode1.Checked = true;
                }
                if ((tradeMode & EnumTradeMode.来料加工) != 0)
                {
                    chkTradeMode2.Checked = true;
                }
                if ((tradeMode & EnumTradeMode.进料加工) != 0)
                {
                    chkTradeMode3.Checked = true;
                }
                if ((tradeMode & EnumTradeMode.纯进口) != 0)
                {
                    chkTradeMode4.Checked = true;
                }
                if ((tradeMode & EnumTradeMode.内贸) != 0)
                {
                    chkTradeMode5.Checked = true;
                }
                this.rgTradeNature.EditValue = budget.TradeNature;
                this.meDescription.Text = budget.Description;
                this.txtExchangeRate.EditValue = budget.ExchangeRate;
                this.BindingOutProductDetail(budget.OutProductDetail);
                this.txtPurchasePrice.EditValue = budget.PurchasePrice;
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
        private void CheckDateInput()
        {
            if (this.dteSignDate.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteSignDate, "请输入签约日期");
            }
            if (this.dteValidity.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.dteValidity, "请输入有效期");
            }

            if (this.dteSignDate.DateTime > this.dteValidity.DateTime)
            {
                this.dxErrorProvider1.SetError(this.dteSignDate, "签约日期应早于有效期");
            }

            if (this.CurrentBudget == null || this.CurrentBudget.EnumFlowState == EnumDataFlowState.未审批)
            {
                if (this.dteSignDate.DateTime.AddYears(1) <= this.dteValidity.DateTime)
                {
                    this.dxErrorProvider1.SetError(this.dteValidity, "有效期最大阈值不能超过1年");
                }
            }
            if (string.IsNullOrEmpty(this.pceSupplier.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.pceSupplier, "请选择工厂");
            }
        }
        private void CheckContractNOInput()
        {
            string contractNo = this.txtContractNO.Text.Trim();
            if (string.IsNullOrEmpty(contractNo))
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "请输入合同编号");
            }
            Match match = Regex.Match(contractNo, "(" + contractNoPrefix + ")\\d{4}$");
            if (!match.Success)
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "合同编号格式应为：yy-部门编号-4位数字");
            }
            int id = this.CurrentBudget == null ? 0 : this.CurrentBudget.ID;
            if (bm.CheckContractNO(id, contractNo))
            {
                this.dxErrorProvider1.SetError(this.txtContractNO, "合同编号已存在");
            }
        }

        private void CheckCustomerInput()
        {
            if (string.IsNullOrEmpty(this.pceMainCustomer.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.pceMainCustomer, "请选择主买方");
            }
        }

        private bool CheckInProductDetailInput()
        {
            var dataSource = (gridInProductDetail.DataSource as BindingList<InProductDetail>).ToList();
            if (dataSource == null || dataSource.Count == 0)
            {
                XtraMessageBox.Show("请输入内贸部分信息！");
                return false;
            }
            if (dataSource.Exists(d => d.Subtotal == 0))
            {
                this.dxErrorProvider1.SetError(this.gridInProductDetail, "原料、辅料、加工应至少一项不为0");
                this.bgvInProductDetail.SetColumnError(gcRawMaterials, "原料、辅料、加工应至少一项不为0");
                return false;
            }
            if (dataSource.Exists(d => d.TaxRebateRate == 0))
            {
                this.bgvInProductDetail.SetColumnError(gcVat, "退税率应大于0");
                return false;
            }
            return true;
        }

        private bool CheckOutProductDetailInput()
        {
            var dataSource = (gridOutProductDetail.DataSource as BindingList<OutProductDetail>).ToList();
            if (dataSource == null || dataSource.Count == 0)
            {
                XtraMessageBox.Show("请输入外贸部分上商品信息！");
                return false;
            }
            return true;
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
        /// <summary>
        /// 计算内贸总进价
        /// </summary>
        private void CalcInProductTotalAmount()
        {
            var dataSource = (IEnumerable<InProductDetail>)gridInProductDetail.DataSource;
            if (dataSource != null)
            {
                txtPurchasePrice.EditValue = dataSource.Sum(o => (o.MoneySubtotal));
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
            txtNetIncomeCNY.EditValue = this.txtTotalAmount.Value - txtSubtotal.Value;
        }

        /// <summary>
        /// 计算总成本
        /// </summary>
        private void CalcTotalCost()
        {
            txtTotalCost.EditValue = txtPurchasePrice.Value - txtTaxRebateRateMoney.Value;
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
        /// 退税后换汇成本=总成本/合同金额（人民币）/汇率（USD）
        /// </summary>
        private void CalcExchangeCost()
        {
            if (txtTotalAmount.Value == 0 || txtExchangeRate.Value == 0)
            {
                txtExchangeCost.ToolTipTitle = "合同金额（RMB）或汇率（USD）的值为0";
                txtExchangeCost.EditValue = 0;
            }
            else
            {
                txtExchangeCost.ToolTipTitle = "退税后换汇成本=总成本/合同金额（人民币）/汇率（USD）";
                txtExchangeCost.EditValue = Math.Round(txtTotalCost.Value / txtTotalAmount.Value / txtExchangeRate.Value, 2);
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
            decimal directCosts = txtPurchasePrice.Value; //总进价
            if (directCosts != 0)
            {
                this.txtPercentage.EditValue = Math.Round((txtAdvancePayment.Value) / (directCosts + txtFeedMoney.Value * (1 + this.vatOption / 100)) * 100, 2);//预付款占总进价百分比
            }
            else
            {
                this.txtPercentage.EditValue = 0;
            }

            //利息=预付款*年利率/360/100*天数
            txtInterest.EditValue = txtAdvancePayment.Value * txtInterestRate.Value * txtDays.Value / 360 / 100;
        }

        /// <summary>
        /// 计算预算部分的小计
        /// </summary>
        private void CalcBudgetSubtotal()
        {
            //小计=佣金+运保费+银行费用+直接费用+进料款
            this.txtSubtotal.EditValue = txtCommission.Value + txtPremium.Value + txtBankCharges.Value + txtDirectCosts.Value + txtFeedMoney.Value;
        }

        /// <summary>
        /// 计算美元合同金额
        /// </summary>
        private void CalcUSDTotalAmount()
        {
            if (this.txtExchangeRate.Value != 0)
            {
                this.txtUSDTotalAmount.ToolTip = "汇率（USD）值为0。";
                this.txtUSDTotalAmount.EditValue = this.txtTotalAmount.Value / this.txtExchangeRate.Value;
            }
            else
            {
                this.txtUSDTotalAmount.ToolTip = "美元合同金额=合同金额（人民币）/汇率（USD）";
                this.txtUSDTotalAmount.EditValue = 0;
            }
        }

        #endregion

        #region Event Method

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

        private void gridOutProductDetail_Leave(object sender, EventArgs e)
        {
            if (this.WorkModel == EditFormWorkModels.New)
            {
                var dataSource = gridOutProductDetail.DataSource as BindingList<OutProductDetail>;
                if (dataSource != null && dataSource.Count > 0)
                {
                    var inProductDetailDataSource = gridInProductDetail.DataSource as BindingList<InProductDetail>;
                    if (inProductDetailDataSource != null && inProductDetailDataSource.Count > 0)
                    {
                        return;
                    }
                    else if (inProductDetailDataSource == null)
                    {
                        inProductDetailDataSource = new BindingList<InProductDetail>();
                    }
                    dataSource.ToList().ForEach(d => inProductDetailDataSource.Add(new InProductDetail() { Count = d.Count, Name = d.Name, Unit = d.Unit, Vat = this.vatOption }));
                    gridInProductDetail.DataSource = inProductDetailDataSource;
                    gridInProductDetail.RefreshDataSource();
                }
            }
        }

        private void gvOutProductDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvOutProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var detail = e.Row as OutProductDetail;

            if (string.IsNullOrEmpty(detail.Name))
            {
                e.ErrorText = "产品规格不能为空";
                e.Valid = false;
                gvOutProductDetail.SetColumnError(gcName, e.ErrorText);
            }
            else if (string.IsNullOrEmpty(detail.Unit))
            {
                e.ErrorText = "单位不能为空";
                e.Valid = false;
                gvOutProductDetail.SetColumnError(gcUnit, e.ErrorText);
            }
            else if (detail.Count <= 0)
            {
                e.ErrorText = "数量应大于0";
                e.Valid = false;
                gvOutProductDetail.SetColumnError(gcCount, e.ErrorText);
            }
            else if (detail.Price <= 0)
            {
                e.ErrorText = "单价应大于0";
                e.Valid = false;
                gvOutProductDetail.SetColumnError(gcPrice, e.ErrorText);
            }
            else if (detail.ExchangeRate <= 0)
            {
                e.ErrorText = "汇率应大于0";
                e.Valid = false;
                gvOutProductDetail.SetColumnError(gcExchangeRate, e.ErrorText);
            }
        }

        private void gvOutProductDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = false;
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (gvOutProductDetail.FocusedColumn == gcName)
                {
                    e.ErrorText = "产品规格不能为空";
                    gvOutProductDetail.SetColumnError(gcName, e.ErrorText);
                }
                else if (gvOutProductDetail.FocusedColumn == gcUnit)
                {
                    e.ErrorText = "单位不能为空";
                    gvOutProductDetail.SetColumnError(gcUnit, e.ErrorText);
                }
                else if (gvOutProductDetail.FocusedColumn == gcCount)
                {
                    e.ErrorText = "数量应大于0";
                    gvOutProductDetail.SetColumnError(gcCount, e.ErrorText);
                }
                else if (gvOutProductDetail.FocusedColumn == gcPrice)
                {
                    e.ErrorText = "单价应大于0";
                    gvOutProductDetail.SetColumnError(gcPrice, e.ErrorText);
                }
                else if (gvOutProductDetail.FocusedColumn == gcExchangeRate)
                {
                    e.ErrorText = "汇率应大于0";
                    gvOutProductDetail.SetColumnError(gcExchangeRate, e.ErrorText);
                }
                else
                {
                    e.Valid = true;
                }
            }
            else
            {
                decimal value = 0;
                bool isNumber = Decimal.TryParse(e.Value.ToString(), out value);
                string errorMsg = (isNumber ? "" : "的数字");
                if (gvOutProductDetail.FocusedColumn == gcCount && value <= 0)
                {
                    e.ErrorText = "数量应大于0" + errorMsg;
                    gvOutProductDetail.SetColumnError(gcCount, e.ErrorText);
                }
                else if (gvOutProductDetail.FocusedColumn == gcPrice && value <= 0)
                {
                    e.ErrorText = "单价应大于0" + errorMsg;
                    gvOutProductDetail.SetColumnError(gcPrice, e.ErrorText);
                }
                else if (gvOutProductDetail.FocusedColumn == gcExchangeRate && value <= 0)
                {
                    e.ErrorText = "汇率应大于0" + errorMsg;
                    gvOutProductDetail.SetColumnError(gcExchangeRate, e.ErrorText);
                }
                else
                {
                    e.Valid = true;
                }
            }
            if (e.Valid == true)
            {
                gvOutProductDetail.SetColumnError(gvOutProductDetail.FocusedColumn, null);
            }
        }

        private void gvOutProductDetail_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
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
            else if (e.Column == gcOriginalCurrency && e.Value != null)
            {
                if ("usd".Equals(e.Value.ToString().ToLower()))
                {
                    gvOutProductDetail.SetRowCellValue(e.RowHandle, gcExchangeRate, this.txtExchangeRate.Value);
                }
            }
        }

        private void riLinkDelete_Click(object sender, System.EventArgs e)
        {
            if (this.gvOutProductDetail.FocusedRowHandle < 0)
            {
                gvOutProductDetail.CloseEditor();
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
            e.Valid = false;
            if (string.IsNullOrEmpty(detail.Name))
            {
                e.ErrorText = "品名规格不能为空";
                bgvInProductDetail.SetColumnError(gcInName, e.ErrorText);
            }
            else if (string.IsNullOrEmpty(detail.Unit))
            {
                e.ErrorText = "单位不能为空";
                bgvInProductDetail.SetColumnError(gcInUnit, e.ErrorText);
            }
            else if (detail.Count <= 0)
            {
                e.ErrorText = "数量应大于0";
                bgvInProductDetail.SetColumnError(gcInCount, e.ErrorText);
            }
            else if (detail.Subtotal == 0)
            {
                e.ErrorText = "原料、辅料、加工应至少一项不为0";
                bgvInProductDetail.SetColumnError(gcSubtotal, e.ErrorText);
            }
            else if (detail.TaxRebateRate < 0)
            {
                e.ErrorText = "退税率应大于等于0";
                bgvInProductDetail.SetColumnError(gcTaxRebateRate, e.ErrorText);
            }
            else if (detail.Vat <= 0)
            {
                e.ErrorText = "增值税税率应大于0";
                bgvInProductDetail.SetColumnError(gcVat, e.ErrorText);
            }
            else
            {
                e.ErrorText = string.Empty;
                e.Valid = true;
            }
        }

        private void bgvInProductDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void bgvInProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gcInCount
               || e.Column == gcRawMaterials
               || e.Column == gcSubsidiaryMaterials
               || e.Column == gcProcessCost
               || e.Column == gcVat
               || e.Column == gcTaxRebateRate)
            {
                CalcInProductTotalAmount();
                CalcTaxRebateRateMoney();
            }
        }

        private void bgvInProductDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            InProductDetail detail = bgvInProductDetail.GetRow(e.RowHandle) as InProductDetail;
            detail.Vat = this.vatOption;
        }

        private void bgvInProductDetail_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void bgvInProductDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = false;
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (bgvInProductDetail.FocusedColumn == gcInName)
                {
                    e.ErrorText = "品名规格不能为空";
                    bgvInProductDetail.SetColumnError(gcInName, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcInUnit)
                {
                    e.ErrorText = "单位不能为空";
                    bgvInProductDetail.SetColumnError(gcInUnit, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcInCount)
                {
                    e.ErrorText = "数量应大于0";
                    bgvInProductDetail.SetColumnError(gcInCount, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcSubtotal)
                {
                    e.ErrorText = "原料、辅料、加工应至少一项不为0";
                    bgvInProductDetail.SetColumnError(gcSubtotal, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcTaxRebateRate)
                {
                    e.ErrorText = "退税率应大于等于0";
                    bgvInProductDetail.SetColumnError(gcTaxRebateRate, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcVat)
                {
                    e.ErrorText = "增值税税率应大于0";
                    bgvInProductDetail.SetColumnError(gcVat, e.ErrorText);
                }
                else
                {
                    e.Valid = true;
                }
            }
            else
            {
                decimal value = 0;
                bool isNumber = Decimal.TryParse(e.Value.ToString(), out value);
                string errorMsg = (isNumber ? "" : "的数字");
                if (bgvInProductDetail.FocusedColumn == gcInCount && value <= 0)
                {
                    e.ErrorText = "数量应大于0" + errorMsg;
                    bgvInProductDetail.SetColumnError(gcInCount, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcSubtotal && value <= 0)
                {
                    e.ErrorText = "原料、辅料、加工应至少一项不为0";
                    bgvInProductDetail.SetColumnError(gcSubtotal, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcTaxRebateRate && value < 0)
                {
                    e.ErrorText = "退税率应大于等于0" + errorMsg;
                    bgvInProductDetail.SetColumnError(gcTaxRebateRate, e.ErrorText);
                }
                else if (bgvInProductDetail.FocusedColumn == gcVat && value <= 0)
                {
                    e.ErrorText = "增值税税率应大于0" + errorMsg;
                    bgvInProductDetail.SetColumnError(gcVat, e.ErrorText);
                }
                else
                {
                    e.Valid = true;
                }
            }
            if (e.Valid == true)
            {
                if (bgvInProductDetail.FocusedColumn == gcRawMaterials
                    || bgvInProductDetail.FocusedColumn == gcSubsidiaryMaterials
                    || bgvInProductDetail.FocusedColumn == gcProcessCost)
                {
                    bgvInProductDetail.SetColumnError(gcSubtotal, null);
                }
                else
                {
                    bgvInProductDetail.SetColumnError(bgvInProductDetail.FocusedColumn, null);
                }
            }
        }

        private void riLinkEditInDelete_Click(object sender, System.EventArgs e)
        {
            if (this.bgvInProductDetail.FocusedRowHandle < 0)
            {
                bgvInProductDetail.CloseEditor();
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
            this.CalcInproductInterest();
            this.CalcBudgetSubtotal();
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            this.txtExchangeRateView.EditValue = this.txtExchangeRate.Value;
            CalcNetIncome();
            CalcProfitLevel1();
            CalcUSDTotalAmount();
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
            CalcUSDTotalAmount();
            CalcExchangeCost();
        }

        private void txtInterest_EditValueChanged(object sender, EventArgs e)
        {
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

        private void btnSync_Click(object sender, EventArgs e)
        {
            var dataSource = gridOutProductDetail.DataSource as BindingList<OutProductDetail>;
            if (dataSource != null && dataSource.Count > 0)
            {
                var inProductDetailDataSource = gridInProductDetail.DataSource as BindingList<InProductDetail>;
                if (inProductDetailDataSource == null)
                {
                    inProductDetailDataSource = new BindingList<InProductDetail>();
                    dataSource.ToList().ForEach(d => inProductDetailDataSource.Add(new InProductDetail() { Count = d.Count, Name = d.Name, Unit = d.Unit, Vat = this.vatOption }));
                }
                else
                {
                    InProductDetail inDetail = null;
                    foreach (OutProductDetail outDetail in dataSource)
                    {
                        inDetail = inProductDetailDataSource.FirstOrDefault(d => d.Name == outDetail.Name);
                        if (inDetail == null)
                        {
                            inProductDetailDataSource.Add(new InProductDetail() { Count = outDetail.Count, Name = outDetail.Name, Unit = outDetail.Unit, Vat = this.vatOption });
                        }
                        else
                        {
                            inDetail.Count = outDetail.Count;
                            inDetail.Unit = outDetail.Unit;
                        }
                    }
                }
                gridInProductDetail.DataSource = inProductDetailDataSource;
                gridInProductDetail.RefreshDataSource();
            }
        }
        #endregion
    }
}
