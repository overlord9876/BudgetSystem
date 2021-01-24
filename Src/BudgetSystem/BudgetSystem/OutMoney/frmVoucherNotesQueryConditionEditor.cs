using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public partial class frmVoucherNotesQueryConditionEditor : frmVoucherNotesQueryConditionEditorTransit
    {
        private Bll.BudgetManager bm = new Bll.BudgetManager();
        private Bll.SystemConfigManager scm = new Bll.SystemConfigManager();

        public frmVoucherNotesQueryConditionEditor()
        {
            InitializeComponent();

            var condition = new BudgetQueryCondition();
            condition = RunInfo.Instance.GetConditionByCurrentUser(condition) as BudgetQueryCondition;

            List<Budget> budgetList = bm.GetAllBudget(condition);
            this.cboBudget.Properties.DataSource = budgetList;

            List<Country> countryList = this.scm.GetSystemConfigValue<List<Country>>(EnumSystemConfigNames.国家地区.ToString());
            var brCountryList = countryList.Where(o => o.IsBR).Select(o => o.Name).ToArray();
            txtFinalCountry.Properties.Items.AddRange(brCountryList);
        }


        public override bool CollectData()
        {
            VoucherNotesQueryCondition c = new VoucherNotesQueryCondition();

            if (cboBudget.EditValue != null && cboBudget.EditValue is Budget)
            {
                c.BudgetId = (cboBudget.EditValue as Budget).ID;
            }

            c.TradeMode = this.txtTradeMode.Text;

            c.FinalCountry = this.txtFinalCountry.Text;


            if (this.deDateBegin.EditValue != null)
            {
                var exportBeginDate = (DateTime)this.deDateBegin.EditValue;
                c.ExportBeginDate = new DateTime(exportBeginDate.Year, exportBeginDate.Month, exportBeginDate.Day, 0, 0, 0);
            }
            else
            {
                c.ExportBeginDate = DateTime.MinValue;
            }
            if (this.deDateEnd.EditValue != null)
            {
                var exportEndDate = (DateTime)this.deDateEnd.EditValue;
                c.ExportEndDate = new DateTime(exportEndDate.Year, exportEndDate.Month, exportEndDate.Day).AddDays(1).AddMilliseconds(-1);
            }
            else
            {
                c.ExportEndDate = DateTime.MinValue;
            }
            this.QueryCondition = c;
            return true;

        }
    }


    /// <summary>
    /// 过渡一下，不然窗体编辑器无法打开
    /// </summary>
    public class frmVoucherNotesQueryConditionEditorTransit : Base.frmBaseQueryConditionEditor<VoucherNotesQueryCondition>
    {

    }

}