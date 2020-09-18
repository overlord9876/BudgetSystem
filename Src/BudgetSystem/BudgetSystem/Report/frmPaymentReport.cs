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
    public partial class frmPaymentReport : Base.frmBaseCommonReportForm
    {
        Bll.SystemConfigManager scm = new Bll.SystemConfigManager();
        private Dictionary<string, string> columnDic = new Dictionary<string, string>();
        private Dictionary<string, decimal> paymentmethodDic = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> bankDic = new Dictionary<string, decimal>();
        private List<RecieptCapital> rcList;
        private DateTime beginTimestamp = DateTime.MinValue;
        private DateTime endTimestamp = DateTime.MaxValue;
        private int count = 0;//付款笔数
        private decimal ProvisionalPayment = 0;//暂付款
        private IEnumerable<UseMoneyType> umtList;

        public frmPaymentReport()
        {
            InitializeComponent();
            this.Module = BusinessModules.PaymentCapital;
            this.umtList = scm.GetSystemConfigValue<List<UseMoneyType>>(EnumSystemConfigNames.用款类型.ToString()).Where(o => o.Type == PaymentType.暂付款);
        }

        protected override void InitLayout()
        {
            base.InitModelOperate();
        }

        protected override void InitModelOperate()
        {
            this.supportPivotGrid = false;
            this.supportPivotGridSaveView = false;
            this.supportPrint = true;
        }

        public override void OperateHandled(ModelOperate operate, ModeOperateEventArgs e)
        {
            base.OperateHandled(operate, e);
        }

        private void frmBudgetReport_Load(object sender, EventArgs e)
        {
            InitShowStyle();
        }

        protected override void LoadDataByCondition(BudgetQueryCondition condition)
        {
            ProvisionalPayment = 0;
            beginTimestamp = condition.BeginTimestamp;
            endTimestamp = condition.EndTimestamp;
            Bll.ReportManager um = new Bll.ReportManager();

            base.ClearColumns();

            columnDic.Clear();
            paymentmethodDic.Clear();
            bankDic.Clear();

            count = um.GetPaymentCapitalTotalCount(condition);

            if (count == 0) { return; }

            rcList = um.GetPaymentCapital(condition);

            if (rcList == null) { return; }

            DataTable dt = new DataTable();

            //增加部门、合计列
            CreateColumn(dt, frmCapitalReport.DepartmentCaption, "departmentCode", typeof(string));

            //统计银行列。
            for (int index = 0; index < rcList.Count; index++)
            {
                RecieptCapital rc = rcList[index];

                if (umtList.Any(o => o.Name == rc.NatureOfMoney))
                {
                    ProvisionalPayment += rc.CNY;
                }
                rc.OriginalCoin = rc.CNY;
                //if (!paymentmethodDic.ContainsKey(rc.PaymentMethod))
                //{
                //    paymentmethodDic.Add(rc.PaymentMethod, 0);
                //}
                //paymentmethodDic[rc.PaymentMethod] += rc.OriginalCoin;

                //银行总数合计
                if (!bankDic.ContainsKey(rc.BankCode))
                {
                    bankDic.Add(rc.BankCode, 0);
                }
                bankDic[rc.BankCode] += rc.OriginalCoin;

                //银行名称与Field对应关系维护
                if (!columnDic.ContainsKey(rc.BankCode))
                {
                    columnDic.Add(rc.BankCode, string.Format("code{0}", index));
                }

                //创建银行列
                if (!dt.Columns.Contains(columnDic[rc.BankCode]))
                {
                    CreateGridColumn(rc.BankCode, columnDic[rc.BankCode], valueFormatType: FormatType.Custom, formatProvider: new MyDecimalFormat());
                    dt.Columns.Add(columnDic[rc.BankCode], typeof(decimal));
                }
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
            totalRow[columnDic[frmCapitalReport.DepartmentCaption]] = "合计";
            foreach (string bankCode in bankDic.Keys)
            {
                if (dt.Columns.Contains(columnDic[bankCode]))
                {
                    totalRow[columnDic[bankCode]] = bankDic[bankCode];
                    totalMoney += bankDic[bankCode];
                }
            }

            //暂付款
            DataRow ProvisionalPaymentRow = dt.NewRow();
            dt.Rows.Add(ProvisionalPaymentRow);
            ProvisionalPaymentRow[columnDic[frmCapitalReport.DepartmentCaption]] = "暂付款";
            ProvisionalPaymentRow[1] = ProvisionalPayment;

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

            ////付款方式合计
            //foreach (string paymentMethod in paymentmethodDic.Keys)
            //{
            //    DataRow paymentMethodRow = dt.NewRow();
            //    dt.Rows.Add(paymentMethodRow);
            //    paymentMethodRow[0] = paymentMethod;
            //    paymentMethodRow[1] = paymentmethodDic[paymentMethod];
            //}

            //合计总数
            DataRow totalMoneyRow = dt.NewRow();
            dt.Rows.Add(totalMoneyRow);
            totalMoneyRow[columnDic[frmCapitalReport.DepartmentCaption]] = "本月合计（人民币）";
            totalMoneyRow[1] = totalMoney;

            //汇总付款批次
            DataRow totalCountRow = dt.NewRow();
            dt.Rows.Add(totalCountRow);
            totalCountRow[columnDic[frmCapitalReport.DepartmentCaption]] = "汇总付款批次";
            totalCountRow[1] = count;

            this.gridControl.DataSource = dt;
            base.gridView.BestFitColumns();
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

        public override void Print()
        {
            frmCapitalPrint print = new frmCapitalPrint("部门付款明细报表", string.Format("{0}-{1}", beginTimestamp.ToString("yyyy年MM月dd日"), endTimestamp.ToString("yyyy年MM月dd日")), "单位：元");
            print.BindData(1, rcList, count, false);
            print.PrintItem();
        }
    }
}
