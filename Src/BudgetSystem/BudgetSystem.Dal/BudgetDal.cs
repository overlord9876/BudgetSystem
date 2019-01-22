using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Entity.QueryCondition;
using System.Data;
using Dapper_NET20;
using System.Linq;

namespace BudgetSystem.Dal
{
    public class BudgetDal
    {
        public Budget GetBudget(int id, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = string.Format(@"SELECT b.*,u.RealName AS SalesmanName,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,c.Country AS CustomerCountry,
                                                      IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName,u2.RealName AS UpdateUserName                                               
                                 FROM `Budget` b
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `User` u2 ON b.UpdateUser=u2.UserName 
                                 LEFT JOIN `Department` d ON b.Department=d.Code 
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType='{0}' AND f.IsRecent=1
                                 WHERE b.`ID` = @ID", EnumFlowDataType.预算单.ToString());
            Budget budget = con.Query<Budget>(selectSql, new { ID = id }, tran).SingleOrDefault();

            if (budget != null)
            {
                string supplierSelectSql = string.Format(@"SELECT s.ID,s.`Name`,s.SupplierType ,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState FROM  Supplier s
                                                INNER JOIN BudgetSuppliers bs ON s.ID=bs.Sup_ID
                                                LEFT JOIN `FlowInstance` f ON f.DateItemID=s.id AND f.DateItemType='{0}' AND f.IsRecent=1
                                                WHERE bs.ID=@ID", EnumFlowDataType.供应商.ToString());
                budget.SupplierList = con.Query<Supplier>(supplierSelectSql, new { ID = id }, tran).ToList();
                string custumerSelectSql = @"SELECT c.ID,c.`Name`,c.Country FROM  Customer c 
                                                INNER JOIN BudgetCustomers bc ON c.ID=bc.Cus_ID
                                                WHERE bc.Bud_ID=@ID";
                budget.CustomerList = con.Query<Customer>(custumerSelectSql, new { ID = id }, tran).ToList();
            }
            return budget;
        }

        public IEnumerable<Budget> GetAllBudget(IDbConnection con, IDbTransaction tran = null,BudgetQueryCondition condition=null)
        {
            string selectSql = string.Format(@"SELECT b.*,u.RealName  AS SalesmanName,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,c.Country AS CustomerCountry,
                                                      IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName,u2.RealName AS UpdateUserName
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName 
                                 LEFT JOIN `User` u2 ON b.UpdateUser=u2.UserName 
                                 LEFT JOIN `Department` d ON b.Department=d.Code 
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID 								 
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType=@DateItemType AND f.IsRecent=1
                                 {0}
                                 WHERE b.ID<>0 ",
                                 (condition!=null&&condition.IsManagerApproval)?
                                 @"LEFT JOIN  `FlowRunPoint` frp ON frp.InstanceID=f.ID LEFT JOIN `FlowNode` fn on frp.NodeID=fn.ID":"");
            DynamicParameters dp = new DynamicParameters();
            dp.Add("DateItemType", EnumFlowDataType.预算单.ToString(), null, null, null);
            if (condition != null)
            {
                List<string> strConditionList = new List<string>();
                if (condition.IsGeneralManagerApproval)
                {
                    strConditionList.Add(" b.`State`<>@State and f.FlowName=@FlowName and  (f.ApproveResult+f.IsClosed)=@FlowState");
                    dp.Add("State", EnumBudgetState.已结束, DbType.Int32, ParameterDirection.Input, null);
                    dp.Add("FlowName", EnumFlowNames.预算单审批流程.ToString(),DbType.String,null,null);
                    dp.Add("FlowState", EnumDataFlowState.审批通过,DbType.Int32, ParameterDirection.Input,null);
                }
                if (condition.IsManagerApproval)
                {
                    strConditionList.Add(" frp.State=0 and fn.NodeValueRemark='部门经理' and f.FlowName=@FlowName");
                    dp.Add("FlowName", EnumFlowNames.预算单审批流程.ToString(), DbType.String, null, null);
                }
                if ((int)condition.State != -1)
                {
                    strConditionList.Add(" b.`State`=@State ");
                    dp.Add("State", condition.State,DbType.Int32,ParameterDirection.Input,null);
                }
                if (condition.IsArchiveWarningQuery)
                {
                    strConditionList.Add("  b.Validity<now() and b.`State`<>@State ");
                    dp.Add("State", EnumBudgetState.已结束, DbType.Int32, ParameterDirection.Input, null);
                }
                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    strConditionList.Add(" b.Salesman=@Salesman ");
                    dp.Add("Salesman", condition.Salesman, null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.Department))
                {
                    strConditionList.Add(" b.Department=@Department ");
                    dp.Add("Department", condition.Department, null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.ContractNO))
                {
                    strConditionList.Add(" b.ContractNO like @ContractNO "); 
                    dp.Add("ContractNO", string.Format("%{0}%", condition.ContractNO), null, null, null);
                }
                
                if (!string.IsNullOrEmpty(condition.CustomerName))
                {
                    strConditionList.Add(" c.Name like @CustomerName ");
                    dp.Add("CustomerName", string.Format("%{0}%", condition.CustomerName), null, null, null);
                }
                if (strConditionList.Count > 0)
                {
                    selectSql += string.Format(" and {0}", string.Join(" and ", strConditionList.ToArray()));
                }
            }

            return con.Query<Budget>(selectSql, dp, tran);
        }


        public IEnumerable<Budget> GetBudgetListByCustomerId(string userName, int customerId, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT b.*,u.RealName  AS SalesmanName,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,c.Country AS CustomerCountry,
                                                      IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName,u2.RealName AS UpdateUserName
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName AND b.Salesman=@Salesman
                                 LEFT JOIN `User` u2 ON b.UpdateUser=u2.UserName
                                 LEFT JOIN `Department` d ON b.Department=d.Code 
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID AND b.CustomerID=@CustomerID
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType='{0}' AND f.IsRecent=1
                                 WHERE b.ID<>0 AND b.Salesman=@Salesman";

            return con.Query<Budget>(selectSql, new { Salesman = userName, CustomerID = customerId, DateItemType = EnumFlowDataType.预算单.ToString() }, tran);
        }

        public IEnumerable<Customer> GetCustomerListByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran = null)
        {
            string custumerSelectSql = @"SELECT c.ID,c.`Name`,c.Country FROM  Customer c 
                                                INNER JOIN BudgetCustomers bc ON c.ID=bc.Cus_ID
                                                WHERE bc.Bud_ID=@ID
                                        Union 
                                        SELECT c.ID,c.`Name`,c.Country FROM  Customer c 
                                        INNER join budget b on c.ID=b.CustomerID
                                        where b.ID=@ID";
            return con.Query<Customer>(custumerSelectSql, new { ID = budgetId }, tran);
        }

        public IEnumerable<Budget> GetBudgetListBySaleman(string userName, IDbConnection con, IDbTransaction tran = null)
        {
            string selectSql = @"SELECT b.*,u.RealName  AS SalesmanName,d.`Name` AS DepartmentName,c.`Name` AS CustomerName,c.Country AS CustomerCountry,
                                                      IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState,f.ID AS FlowInstanceID,f.FlowName,u2.RealName AS UpdateUserName
                                 FROM `Budget` b                                     
                                 LEFT JOIN `User` u ON b.Salesman=u.UserName  AND b.Salesman=@Salesman
                                 LEFT JOIN `User` u2 ON b.UpdateUser=u2.UserName
                                 LEFT JOIN `Department` d ON b.Department=d.Code
                                 LEFT JOIN `Customer` c ON b.CustomerID=c.ID
								 LEFT JOIN `FlowInstance` f ON f.DateItemID=b.id AND f.DateItemType='预算单' AND f.IsRecent=1
                                 WHERE b.ID<>0  AND b.Salesman=@Salesman";

            return con.Query<Budget>(selectSql, new { Salesman = userName}, tran);
        }


        public int AddBudget(Budget budget, IDbConnection con, IDbTransaction tran = null)
        {
            string insertSql = @"Insert Into `Budget` (`ContractNO`,`State`,`Salesman`,`Department`,`CreateDate`,`SignDate`,`Validity`,
                                           `TradeMode`,`TradeNature`,`OutProductDetail`,`PriceClause`,`OutSettlementMethod`,
                                           `OutSettlementMethod2`,`OutSettlementMethod3`,`TotalAmount`,`Country`,`IsQualifiedSupplier`,
                                           `InProductDetail`,`AdvancePayment`,`InterestRate`,
                                           `Days`,`Commission`,`Premium`,`BankCharges`,`DirectCosts`,`FeedMoney`,`ExchangeRate`,
                                           `Description`,`CustomerID`,`Port`,`TaxRebate`,`PurchasePrice`,`Profit`,
                                           `ProfitLevel1`,`ProfitLevel2`,`USDTotalAmount`,`UpdateDate`,`UpdateUser`,`VATRate`)
                                    Values (@ContractNO,@State,@Salesman,@Department,now(),@SignDate,@Validity,
                                            @TradeMode,@TradeNature,@OutProductDetail,@PriceClause,@OutSettlementMethod,
                                            @OutSettlementMethod2,@OutSettlementMethod3,@TotalAmount,@Country,@IsQualifiedSupplier,
                                            @InProductDetail,@AdvancePayment,@InterestRate,
                                            @Days,@Commission,@Premium,@BankCharges,@DirectCosts,@FeedMoney,@ExchangeRate,
                                            @Description,@CustomerID,@Port,@TaxRebate,@PurchasePrice,@Profit,
                                            @ProfitLevel1,@ProfitLevel2,@USDTotalAmount,now(),@UpdateUser,@VATRate)";
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
                                         `CustomerID`=@CustomerID,`Port`=@Port,`TaxRebate`=@TaxRebate ,`PurchasePrice`=@PurchasePrice,Profit=@Profit,
                                         `ProfitLevel1`=@ProfitLevel1,`ProfitLevel2`=@ProfitLevel2 ,`USDTotalAmount`=@USDTotalAmount,
                                         `UpdateDate`=now(),`UpdateUser`=@UpdateUser ,`VATRate`=@VATRate
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

        public void ModifyBudgetState(int id, EnumBudgetState state, IDbConnection con, IDbTransaction tran = null)
        {
            string updateSql = "Update `Budget` Set  `State` = @State  Where `ID` = @ID";
            con.Execute(updateSql, new { ID = id, State = state }, tran);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        public void DeleteBudget(int id, IDbConnection con, IDbTransaction tran)
        {
            string deleteSql = @"Delete From `BudgetCustomers` Where `Bud_ID` = @ID;
                                 Delete From `BudgetSuppliers` Where `ID` = @ID;  
                                 Delete From `Budget` Where `ID` = @ID";
            con.Execute(deleteSql, new { ID = id }, tran);
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
