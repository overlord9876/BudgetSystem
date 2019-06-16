using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using BudgetSystem.Entity;
using BudgetSystem.Bll;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace BudgetSystem.Report
{
    public partial class frmCapitalPrint : frmBaseDialogForm
    {
        private bool isReciept = false;
        private Dictionary<string, string> columnDic = new Dictionary<string, string>();
        private Dictionary<string, decimal> paymentmethodDic = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> bankDic = new Dictionary<string, decimal>();

        private frmCapitalPrint()
        {
            InitializeComponent();
        }

        public frmCapitalPrint(string title, string timestamp, string unitName)
            : this()
        {
            this.Text = title;
            labelControl2.Text = title;
            labelControl4.Text = timestamp;
            layoutControlItem3.Text = unitName;
        }

        public void BindData(decimal exchangeRate, List<RecieptCapital> rcList, int count, bool isReciept = true)
        {
            this.isReciept = isReciept;
            if (rcList == null) { return; }

            DataTable dt = new DataTable();

            //增加部门、合计列
            CreateColumn(dt, frmCapitalReport.DepartmentCaption, "departmentCode", typeof(string));
            IFormatProvider provider = null;
            if (isReciept)
            {
                provider = new MyDecimalFormat();
            }
            else
            {
                provider = new MyDecimalFormat();
            }
            //统计银行列。
            for (int index = 0; index < rcList.Count; index++)
            {
                RecieptCapital rc = rcList[index];

                if (isReciept && !string.IsNullOrEmpty(rc.PaymentMethod))//如果是收款、并且支付方式不为空。
                {
                    rc.OriginalCoin = Math.Round(rc.CNY / exchangeRate, 2);
                    if (!paymentmethodDic.ContainsKey(rc.PaymentMethod))
                    {
                        paymentmethodDic.Add(rc.PaymentMethod, 0);
                    }
                    paymentmethodDic[rc.PaymentMethod] += rc.OriginalCoin;
                }
                else
                {
                    //付款。
                    rc.OriginalCoin = rc.CNY;
                }
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
                    CreateGridColumn(rc.BankCode, columnDic[rc.BankCode], valueFormatType: FormatType.Custom, formatProvider: provider);
                    dt.Columns.Add(columnDic[rc.BankCode], typeof(decimal));
                }
            }

            CreateColumn(dt, frmCapitalReport.TotalCaption, "totalcaption", typeof(decimal), valueFormatType: FormatType.Custom, formatProvider: provider);

            //行列数据转换
            foreach (RecieptCapital rc in rcList)
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
            if (isReciept)
            {
                //付款方式合计
                foreach (string paymentMethod in paymentmethodDic.Keys)
                {
                    DataRow paymentMethodRow = dt.NewRow();
                    dt.Rows.Add(paymentMethodRow);
                    paymentMethodRow[0] = paymentMethod;
                    paymentMethodRow[1] = paymentmethodDic[paymentMethod];
                }

                //平均汇率
                DataRow exchangeRateRow = dt.NewRow();
                dt.Rows.Add(exchangeRateRow);
                exchangeRateRow[columnDic[frmCapitalReport.DepartmentCaption]] = "平均汇率";
                exchangeRateRow[1] = exchangeRate;
            }

            //合计总数
            DataRow totalMoneyRow = dt.NewRow();
            dt.Rows.Add(totalMoneyRow);
            totalMoneyRow[columnDic[frmCapitalReport.DepartmentCaption]] = "本月合计";
            totalMoneyRow[1] = totalMoney;

            //总批次
            DataRow totalCountRow = dt.NewRow();
            dt.Rows.Add(totalCountRow);
            totalCountRow[columnDic[frmCapitalReport.DepartmentCaption]] = isReciept ? "汇总收款批次" : "汇总付款批次";
            totalCountRow[1] = count;

            this.gridControl.DataSource = dt;
        }

        private void frmCapitalPrint_Load(object sender, EventArgs e)
        {
        }

        int i;

        private void CreateColumn(DataTable dt, string caption, string fieldName, Type t, FormatType valueFormatType = FormatType.None, string valueFormatString = "", IFormatProvider formatProvider = null)
        {
            if (!columnDic.ContainsKey(caption))
            {
                columnDic.Add(caption, fieldName);
            }

            dt.Columns.Add(fieldName, t);
            CreateGridColumn(caption, fieldName, valueFormatType: valueFormatType, formatProvider: formatProvider);
        }

        private GridColumn CreateGridColumn(string caption, string fieldName, int width = 0, FormatType valueFormatType = FormatType.None, string valueFormatString = "", IFormatProvider formatProvider = null)
        {
            GridColumn gc = new GridColumn();
            gc.Name = caption;
            gc.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            gc.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gc.Caption = caption;
            gc.FieldName = fieldName;
            gc.DisplayFormat.FormatType = valueFormatType;
            if (valueFormatType == FormatType.Custom)
            {
                gc.DisplayFormat.Format = formatProvider;
                gc.DisplayFormat.FormatType = valueFormatType;
                gc.DisplayFormat.Format = formatProvider;
            }
            else
            {
                gc.DisplayFormat.FormatString = valueFormatString;
            }
            if (width > 0)
            {
                gc.Width = width;
            }
            gc.Visible = true;
            gc.VisibleIndex = i++;
            this.gridView.Columns.Add(gc);
            return gc;
        }

        public override void PrintData()
        {
            this.Height -= 50;
            this.labelControl1.Focus();
            PrinterHelper.PrintControl(true, this.layoutControl2, true);
        }
    }
}