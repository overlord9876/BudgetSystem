using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetSystem.Entity;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;
using BudgetSystem.Dal;
using MySql.Data;
using BudgetSystem.Bll;

using System.Configuration;
namespace UpgradeTool
{
    public partial class Form1 : Form
    {
        BudgetManager dal = new BudgetManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();

                BaseManager.SetConnectionString(connectionString, false);
                var budgetList = dal.GetAllBudget();
                List<Budget> upgradeList = new List<Budget>();
                foreach (var budget in budgetList)
                {
                    EnumTradeMode tradeMode = (EnumTradeMode)budget.TradeMode;
                    if (tradeMode == EnumTradeMode.一般贸易)
                    {
                        budget.ContractNO = string.Format("{0} ", budget.ContractNO.Trim());
                        upgradeList.Add(budget);
                    }
                    else if ((tradeMode & EnumTradeMode.一般贸易) != 0)
                    {
                        if (budget.ContractNO.EndsWith("L") || budget.ContractNO.EndsWith("J") || budget.ContractNO.EndsWith("C") || budget.ContractNO.EndsWith("N"))
                        {
                            var c = budget.ContractNO.Substring(budget.ContractNO.Length - 1, 1);

                            var contranctNode = budget.ContractNO.Substring(0, budget.ContractNO.Length - 1);
                            budget.ContractNO = string.Format("{0} {1}", contranctNode.Trim(), c);
                            upgradeList.Add(budget);
                        }
                    }
                }

                dal.ModifyBudgetContractNO(upgradeList);

                MessageBox.Show(string.Format("更新{0}项数据。", budgetList.Count));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
