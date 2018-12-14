using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BudgetSystem.Entity.QueryCondition;
using System.Reflection;
using System.Linq;
using BudgetSystem.Properties;
namespace BudgetSystem.Base
{
    public partial class frmBaseQueryConditionEditor<T> : QueryConditionEditorForm where T : Entity.QueryCondition.BaseQueryCondition
    {

        public frmBaseQueryConditionEditor()
        {
            InitializeComponent();

            this.Icon = Resources.logo;
        }


        protected virtual void Sure()
        {
            if (CollectData())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }


        /// <summary>
        /// 正常主要就是为重写这一个方法
        /// </summary>
        /// <returns></returns>
        public virtual bool CollectData()
        {
            return true;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            Sure();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CollectData())
            {
                frmInput input = new frmInput("请输入", "请输入要保存的查询名称");
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string conditionName = input.Result;
                    this.QueryCondition.Name = conditionName;

                    List<T> existCondition = UIEntity.QueryConditionHelper.GetExistCondition<T>(this.QueryName);
                    if (existCondition.Exists(s => s.Name == conditionName))
                    {
                        if (XtraMessageBox.Show("查询名称已存在，是否覆盖？", "请选择", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            existCondition.Remove(existCondition.Single(s => s.Name == conditionName));
                            existCondition.Add(this.QueryCondition as T);
                            UIEntity.QueryConditionHelper.SaveCondition(existCondition, this.QueryName);
                            IsSavedNewCondition = true;
                        }
                    }
                    else
                    {
                        existCondition.Add(this.QueryCondition as T);
                        UIEntity.QueryConditionHelper.SaveCondition(existCondition, this.QueryName);

                        IsSavedNewCondition = true;
                    }
                }
            }
        }


    }
}