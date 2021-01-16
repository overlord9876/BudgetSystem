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
        private CommonManager cm = new CommonManager();
        private BudgetManager bm = new BudgetManager();
        public Budget CurrentBudget { get; set; }
        Bll.SystemConfigManager scm = new Bll.SystemConfigManager();

        public List<AccountBill> AccountBillList { get; set; }

        public frmAccountBillView()
        {
            InitializeComponent();
            this.gvAccountBill.RowCellStyle += GvAccountBill_RowCellStyle;
            this.gcIsPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcIsPayment.DisplayFormat.Format = new MyExamFormat();
        }

        private void GvAccountBill_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            AccountBill row = gvAccountBill.GetRow(e.RowHandle) as AccountBill;
            if (row != null)
            {
                int adjustmentType = row.AdjustmentType;
                if (adjustmentType == 0)
                {

                }
                else if (adjustmentType == ((int)AdjustmentType.付款 + 1) || adjustmentType == ((int)AdjustmentType.收款 + 1) || adjustmentType == ((int)AdjustmentType.交单 + 1))
                {
                    e.Appearance.ForeColor = Color.Red;//改变字体颜色
                }
                else
                {
                    e.Appearance.ForeColor = Color.Blue;//改变字体颜色
                }
            }
        }

        private void frmAccountBillView_Load(object sender, EventArgs e)
        {
            var imtList = scm.GetSystemConfigValue<List<InMoneyType>>(EnumSystemConfigNames.收款类型.ToString());
            var umtList = scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString());

            this.Text = "按合同号查询收付情况";
            List<DateExchangeRate> dateExchanges = cm.GetDateExchanges();
            List<AccountBill> dataSource = bm.GetAccountBillDetailByBudgetId(CurrentBudget.ID);
            if (dataSource != null)
            {
                InMoneyType imt = null;
                UseMoneyType umt = null;
                foreach (var bs in dataSource)
                {
                    if (!string.IsNullOrEmpty(bs.NatureOfMoney))
                    {
                        imt = imtList.Where(o => o.Name == bs.NatureOfMoney).FirstOrDefault();
                        if (imt != null)
                        {
                            bs.UseType = imt.Type.ToString();
                        }
                    }
                    else if (!string.IsNullOrEmpty(bs.MoneyUsed))
                    {
                        umt = umtList.Where(o => o.Name == bs.MoneyUsed).FirstOrDefault();
                        if (umt != null)
                        {
                            bs.UseType = umt.Type.ToString();
                        }
                    }
                    if (!bs.IsUSD)
                    {
                        bs.ExchangeRate = ExchageRateUtil.GetExchageRate(bs.Date, dateExchanges, (decimal)CurrentBudget.ExchangeRate);
                        bs.USD = Math.Round(bs.CNY / bs.ExchangeRate, 2);
                    }
                }
            }
            this.gcAccountBill.DataSource = dataSource;
            this.gcAccountBill.RefreshDataSource();
            this.gvAccountBill.BestFitColumns();
            this.lblBudgetNO.Text = CurrentBudget.ContractNO;
            int width = layoutControlItem3.Width - lciTitle.Width;
            this.esiLeft.Width = width / 2;
            this.esiRight.Width = this.esiLeft.Width - lciBudget.Width;
            this.textEdit_Number1.EditValue = dataSource.Where(o => true.ToString().Equals(o.IsPayment)).Sum(o => o.PaymentMoney);
            this.textEdit_Number2.EditValue = dataSource.Where(o => false.ToString().Equals(o.IsPayment)).Sum(o => o.USD);
            this.textEdit_Number4.EditValue = dataSource.Where(o => false.ToString().Equals(o.IsPayment)).Sum(o => o.CNY);
            this.textEdit_Number3.EditValue = dataSource.Sum(o => o.CNY);
        }

    }
    public class MyExamFormat : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            bool.TryParse(arg?.ToString(), out bool result);
            return result ? "付款" : "收款";
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else return null;
        }
    }
}
