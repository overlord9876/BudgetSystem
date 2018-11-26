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
namespace BudgetSystem.Base
{
    public partial class frmBaseQueryConditionEditor<T> : DevExpress.XtraEditors.XtraForm where T:Entity.QueryCondition.BaseQueryCondition
    {

        public frmBaseQueryConditionEditor()
        {
            InitializeComponent();
        }

        protected string QueryName
        {
            get;
            set;
        }

        
        protected virtual void Sure()
        {
            if (CollectData())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        public T QueryCondition
        {
            get;
            protected set;
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

                    List<T> existCondition = GetExistCondition();
                    if (existCondition.Exists(s => s.Name == conditionName))
                    {
                        if (XtraMessageBox.Show("查询名称已存在，是否覆盖？", "请选择", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            existCondition.Remove(existCondition.Single(s => s.Name == conditionName));
                            existCondition.Add(this.QueryCondition);
                            this.SaveCondition(existCondition);
                        }
                    }
                    else
                    {
                        existCondition.Add(this.QueryCondition);
                        this.SaveCondition(existCondition);
                    }
                }
            }
        }

        private string GetQuerySaveFileName()
        {
            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "Query");
            if (!System.IO.Directory.Exists(fileName))
            {
                System.IO.Directory.CreateDirectory(fileName);
            }

            fileName = System.IO.Path.Combine(fileName, this.QueryName + ".json");
            return fileName;
        }

        private List<T> GetExistCondition()
        {
            string queryFileName = GetQuerySaveFileName();
            try
            {
                if (System.IO.File.Exists(queryFileName))
                {
                    string str = System.IO.File.ReadAllText(queryFileName, Encoding.UTF8);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(str);
                }
                return new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }

        private void SaveCondition(List<T> conditions)
        {
            try
            {

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(conditions);

                System.IO.File.WriteAllText(GetQuerySaveFileName(), json, Encoding.UTF8);

            }
            catch
            {

            }
        
        
        }
    }
}