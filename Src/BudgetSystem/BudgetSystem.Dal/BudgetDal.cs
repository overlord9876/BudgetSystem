using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class BudgetDal
    {
        public Budget GetBudget(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT b.*,u.RealName AS SalesmanName,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
                                 FROM `Budget` b
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `Department` d ON b.Department=d.Code 
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType='{0}' AND f.IsRecent=1
                                 WHERE b.`ID` = @ID", EnumFlowDataType.预算单.ToString());
            Budget budget = con.Query<Budget>(selectSql, new { ID = id }, tran).SingleOrDefault();

            if (budget != null)
            {
                string supplierSelectSql = @"SELECT s.ID,s.`Name`,s.SupplierType FROM  Supplier s
                                                INNER JOIN BudgetSuppliers bs ON s.ID=bs.Sup_ID
                                                WHERE bs.ID=@ID";
                budget.SupplierList = con.Query<Supplier>(supplierSelectSql, new { ID = id }, tran).ToList();
                string custumerSelectSql = @"SELECT c.ID,c.`Name`,c.Country FROM  Customer c 
                                                INNER JOIN BudgetCustomers bc ON c.ID=bc.Cus_ID
                                                WHERE bc.Bud_ID=@ID";
                budget.CustomerList = con.Query<Customer>(custumerSelectSql, new { ID = id }, tran).ToList();
            }
            return budget;
        }

        public IEnumerable<Budget> GetAllBudget(IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT b.*,u.RealName  AS SalesmanName,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `Department` d ON b.Department=d.Code 
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID 								 
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType='{0}' AND f.IsRecent=1
                                 WHERE b.ID<>0", EnumFlowDataType.预算单.ToString());

            return con.Query<Budget>(selectSql, null, tran);
        }
        public int AddBudget(Budget budget, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"Insert Into `Budget` (`ContractNO`,`State`,`Salesman`,`Department`,`CreateDate`,`SignDate`,`Validity`,
                                           `TradeMode`,`TradeNature`,`OutProductDetail`,`PriceClause`,`OutSettlementMethod`,
                                           `OutSettlementMethod2`,`OutSettlementMethod3`,`TotalAmount`,`Country`,`IsQualifiedSupplier`,
                                           `InProductDetail`,`AdvancePayment`,`InterestRate`,
                                           `Days`,`Commission`,`Premium`,`BankCharges`,`DirectCosts`,`FeedMoney`,`ExchangeRate`,
                                           `Description`,`CustomerID`,`Port`,`TaxRebate`,`PurchasePrice`,`Profit`)
                                    Values (@ContractNO,@State,@Salesman,@Department,now(),@SignDate,@Validity,
                                            @TradeMode,@TradeNature,@OutProductDetail,@PriceClause,@OutSettlementMethod,
                                            @OutSettlementMethod2,@OutSettlementMethod3,@TotalAmount,@Country,@IsQualifiedSupplier,
                                            @InProductDetail,@AdvancePayment,@InterestRate,
                                            @Days,@Commission,@Premium,@BankCharges,@DirectCosts,@FeedMoney,@ExchangeRate,
                                            @Description,@CustomerID,@Port,@TaxRebate,@PurchasePrice,@Profit)";
            int id = con.Insert(insertSql, budget, tran);
            if (id > 0)
            {
                budget.ID = id;
                AddBudgetCustomers(budget, con, tran);
                AddBudgetSuppliers(budget, con, tran);
            }
            return id;
        }

        public void ModifyBudget(Budget budget, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = @"Update `Budget` Set `ContractNO` = @ContractNO,`State` = @State,`Salesman` = @Salesman,`Department` = @Department,
                                         `SignDate` = @SignDate,`Validity` = @Validity,`TradeMode` = @TradeMode,`TradeNature` = @TradeNature,
                                         `OutProductDetail` = @OutProductDetail,`PriceClause` = @PriceClause,`OutSettlementMethod` = @OutSettlementMethod,
                                         `OutSettlementMethod2` = @OutSettlementMethod2,`OutSettlementMethod3` = @OutSettlementMethod3,
                                         `TotalAmount` = @TotalAmount,`Country` = @Country,`IsQualifiedSupplier` = @IsQualifiedSupplier,
                                         `InProductDetail` = @InProductDetail,`AdvancePayment` = @AdvancePayment,`InterestRate` = @InterestRate,
                                         `Days` = @Days,`Commission` = @Commission,`Premium` = @Premium,`BankCharges` = @BankCharges,
                                         `DirectCosts` = @DirectCosts,`FeedMoney` = @FeedMoney,`ExchangeRate` = @ExchangeRate ,`Description`=@Description,
                                         `CustomerID`=@CustomerID,`Port`=@Port,`TaxRebate`=@TaxRebate ,`PurchasePrice`=@PurchasePrice,Profit=@Profit
                                Where `ID` = @ID";
            con.Execute(updateSql, budget, tran);
            string deleteSql = @"Delete From `BudgetCustomers` Where `Bud_ID` = @ID;
                                 Delete From `BudgetSuppliers` Where `ID` = @ID;  ";
            con.Execute(deleteSql, new { ID = budget.ID }, tran);
            AddBudgetSuppliers(budget, con, tran);
            AddBudgetCustomers(budget, con, tran);
        }

        /// <summary>
        /// 验证合同编号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractNo"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool CheckContractNO(int id, string contractNo, IDbConnection con)
        {
            string selectSql = @"SELECT  b.id FROM `Budget` b  
                                    WHERE ID<>@ID and ContractNO=@ContractNO";
            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ID", id));
            command.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("ContractNO", contractNo));
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ModifyBudgetState(int id, string state, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = "Update `Budget` Set  `State` = @State  Where `ID` = @ID";
            con.Execute(updateSql, new { ID = id, State = state }, tran);
        }

        private void AddBudgetCustomers(Budget budget, IDbConnection con, IDbTransaction tran)
        {
            if (budget.CustomerList != null && budget.CustomerList.Any())
            {
                string customerInsertSql = "INSERT INTO BudgetCustomers(Cus_ID,Bud_ID)VALUES(@CID,@BID); ";
                List<object> customers = new List<object>();
                budget.CustomerList.ForEach(c => customers.Add(new { BID = budget.ID, CID = c.ID }));
                con.Execute(customerInsertSql, customers, tran);
            }
        }

        private void AddBudgetSuppliers(Budget budget, IDbConnection con, IDbTransaction tran)
        {
            if (budget.SupplierList != null && budget.SupplierList.Any())
            {
                string supplerInserSql = "INSERT INTO BudgetSuppliers(Sup_ID,ID)VALUES(@SID,@ID); ";
                List<object> supplers = new List<object>();
                budget.SupplierList.ForEach(s => supplers.Add(new { SID = s.ID, ID = budget.ID }));
                con.Execute(supplerInserSql, supplers, tran);
            }
        }


    }
}
