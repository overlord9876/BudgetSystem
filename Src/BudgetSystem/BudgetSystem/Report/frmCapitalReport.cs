using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BudgetSystem.Entity;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;
using BudgetSystem.Entity.QueryCondition;
using System.IO;
using System.Linq;

namespace BudgetSystem.Report
{
    public partial class frmCapitalReport : Base.frmBaseCommonReportForm
    {
        Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        private Dictionary<string, string> columnDic = new Dictionary<string, string>();
        private Dictionary<string, decimal> paymentmethodDic = new Dictionary<string, decimal>();
        private Dictionary<string, CapitalMoney> bankDic = new Dictionary<string, CapitalMoney>();
        private decimal exchangeRate = 0;
        private decimal temporaryReceipt = 0;
        private int count = 0;//收钱笔数
        private List<RecieptCapital> rcList = new List<RecieptCapital>();
        private DateTime beginTimestamp = DateTime.MinValue;
        private DateTime endTimestamp = DateTime.MaxValue;
        private IEnumerable<InMoneyType> imtList;

        public frmCapitalReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.RecieptCapital;

            this.imtList = scm.GetSystemConfigValue<List<InMoneyType>>(EnumSystemConfigNames.收款类型.ToString()).Where(o => o.Type == IMType.暂收款);
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();
        }

        protected override void InitModelOperate()
        {
            this.supportPivotGrid = false;
            this.supportPivotGridSaveView = false;
            base.supportPrint = true;
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
        }

        private void frmBudgetReport_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        public const string DepartmentCaption = "部门";
        public const string TotalCaption = "合计";

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            beginTimestamp = condition.BeginTimestamp;
            endTimestamp = condition.EndTimestamp;
            Bll.ReportManager um = new Bll.ReportManager();

            base.ClearColumns();

            columnDic.Clear();
            paymentmethodDic.Clear();
            bankDic.Clear();
            rcList.Clear();

            count = um.GetRecieptCapitalTotalCount(condition);

            exchangeRate = Math.Round(um.GetAverageUSDExchange(condition), 6);
            if (exchangeRate == 0) { return; }

            DataTable dt = new DataTable();

            //增加部门、合计列
            CreateColumn(dt, frmCapitalReport.DepartmentCaption, "departmentCode", typeof(string));


            if (condition.A != "人民币")
            {
                var withUSDRCList = um.GetRecieptCapitalWithUSD(condition);
                if (withUSDRCList == null || withUSDRCList.Count == 0)
                { return; }
                rcList.AddRange(withUSDRCList);
                //统计银行列。
                CalcOriginalCoin(dt, withUSDRCList, 0);
            }

            var withoutUSDRCList = um.GetRecieptCapitalWithOutUSD(condition);
            if (withoutUSDRCList != null && withoutUSDRCList.Count > 0)
            {
                rcList.AddRange(withoutUSDRCList);
                CalcOriginalCoin(dt, withoutUSDRCList, exchangeRate);
            }

            CreateColumn(dt, frmCapitalReport.TotalCaption, "totalcaption", typeof(decimal), valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());

            //行列数据转换
            foreach (RecieptCapital rc in rcList.OrderBy(o => o.Code))
            {
                DataRow[] rows = dt.Select(string.Format("{0}='{1}'", columnDic[frmCapitalReport.DepartmentCaption], rc.Department));
                if (rows != null && rows.Length > 0)
                {
                    decimal money = 0;
                    if (!(rows[0][columnDic[rc.BankCode]] is System.DBNull))
                    {
                        money = (decimal)rows[0][columnDic[rc.BankCode]];
                    }
                    rows[0][columnDic[rc.BankCode]] = money + rc.OriginalCoin;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow[columnDic[frmCapitalReport.DepartmentCaption]] = rc.Department;
                    newRow[columnDic[rc.BankCode]] = rc.OriginalCoin;
                    dt.Rows.Add(newRow);
                }
            }

            //银行总数合计行
            DataRow totalRow = dt.NewRow();
            dt.Rows.Add(totalRow);
            decimal totalMoney = 0;
            decimal totalCNYMoney = 0;
            totalRow[columnDic[frmCapitalReport.DepartmentCaption]] = "合计";
            foreach (string bankCode in bankDic.Keys)
            {
                if (dt.Columns.Contains(columnDic[bankCode]))
                {
                    totalRow[columnDic[bankCode]] = bankDic[bankCode].OriginalCoin;
                    totalMoney += bankDic[bankCode].OriginalCoin;
                    totalCNYMoney += bankDic[bankCode].CNY;
                }
            }

            //合计每行数据
            decimal rowTotal = 0;
            foreach (DataRow row in dt.Rows)
            {
                rowTotal = 0;
                for (int columnIndex = 1; columnIndex < dt.Columns.Count - 1; columnIndex++)
                {
                    if (row[columnIndex] is System.DBNull)
                    {
                        row[columnIndex] = 0;
                        continue;
                    }
                    rowTotal += ((decimal)row[columnIndex]);
                }
                row[columnDic[frmCapitalReport.TotalCaption]] = rowTotal;
            }

            //付款方式合计
            foreach (string paymentMethod in paymentmethodDic.Keys)
            {
                DataRow paymentMethodRow = dt.NewRow();
                dt.Rows.Add(paymentMethodRow);
                paymentMethodRow[0] = paymentMethod;
                paymentMethodRow[1] = paymentmethodDic[paymentMethod];
            }


            //平均汇率
            DataRow temporaryReceiptRow = dt.NewRow();
            dt.Rows.Add(temporaryReceiptRow);
            temporaryReceiptRow[columnDic[frmCapitalReport.DepartmentCaption]] = "暂收款";
            temporaryReceiptRow[1] = temporaryReceipt;

            //平均汇率
            DataRow exchangeRateRow = dt.NewRow();
            dt.Rows.Add(exchangeRateRow);
            exchangeRateRow[columnDic[frmCapitalReport.DepartmentCaption]] = "平均汇率";
            exchangeRateRow[1] = exchangeRate;

            //合计总数
            DataRow totalMoneyRow = dt.NewRow();
            dt.Rows.Add(totalMoneyRow);
            totalMoneyRow[columnDic[frmCapitalReport.DepartmentCaption]] = "本月合计（美元）";
            totalMoneyRow[1] = totalMoney;

            //合计总数
            DataRow totalMoneyCNYRow = dt.NewRow();
            dt.Rows.Add(totalMoneyCNYRow);
            totalMoneyCNYRow[columnDic[frmCapitalReport.DepartmentCaption]] = "本月合计（人民币）";
            totalMoneyCNYRow[1] = totalCNYMoney;

            //汇总收款批次
            DataRow totalCountRow = dt.NewRow();
            dt.Rows.Add(totalCountRow);
            totalCountRow[columnDic[frmCapitalReport.DepartmentCaption]] = "汇总收款批次";
            totalCountRow[1] = count;

            this.gridControl.DataSource = dt;
            this.gridView.BestFitColumns();
        }

        private void CreateColumn(DataTable dt, string caption, string fieldName, Type t, FormatType valueFormatType = FormatType.None, string valueFormatString = "", IFormatProvider formatProvider = null)
        {
            if (!columnDic.ContainsKey(caption))
            {
                columnDic.Add(caption, fieldName);
            }

            dt.Columns.Add(fieldName, t);
            CreateGridColumn(caption, fieldName, valueFormatType: valueFormatType, formatProvider: formatProvider);
        }

        private void CalcOriginalCoin(DataTable dt, List<RecieptCapital> rcList, decimal exchangeRate)
        {
            temporaryReceipt = 0;

            //统计银行列。
            for (int index = 0; index < rcList.Count; index++)
            {
                RecieptCapital rc = rcList[index];
                if (exchangeRate > 0)
                {
                    rc.OriginalCoin = Math.Round(rc.CNY / exchangeRate, 2);
                }
                if (!paymentmethodDic.ContainsKey(rc.PaymentMethod))
                {
                    paymentmethodDic.Add(rc.PaymentMethod, 0);
                }
                paymentmethodDic[rc.PaymentMethod] += rc.OriginalCoin;

                //银行总数合计
                if (!bankDic.ContainsKey(rc.BankCode))
                {
                    bankDic.Add(rc.BankCode, new CapitalMoney() { OriginalCoin = 0, CNY = 0 });
                }
                bankDic[rc.BankCode].OriginalCoin += rc.OriginalCoin;
                bankDic[rc.BankCode].CNY += rc.CNY;
                if (imtList.Any(o => o.Name == rc.NatureOfMoney))
                {
                    temporaryReceipt += rc.CNY;
                }

                //银行名称与Field对应关系维护
                if (!columnDic.ContainsKey(rc.BankCode))
                {
                    columnDic.Add(rc.BankCode, string.Format("code{0}", Guid.NewGuid().ToString().Replace("-", "")));
                }

                //创建银行列
                if (!dt.Columns.Contains(columnDic[rc.BankCode]))
                {
                    CreateGridColumn(rc.BankCode, columnDic[rc.BankCode], valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
                    dt.Columns.Add(columnDic[rc.BankCode], typeof(decimal));
                }
            }
        }

        public override void Print()
        {
            frmCapitalPrint print = new frmCapitalPrint("部门收款明细报表", string.Format("{0}-{1}", beginTimestamp.ToString("yyyy年MM月dd日"), endTimestamp.ToString("yyyy年MM月dd日")), "单位：万美元");
            print.BindData(exchangeRate, rcList, count);
            print.PrintItem();
        }

        protected override bool ShowFirstCombobox
        {
            get
            {
                return true;
            }
        }
    }
    public class CapitalMoney
    {
        public decimal OriginalCoin { get; set; }
        public decimal CNY { get; set; }
    }

}
