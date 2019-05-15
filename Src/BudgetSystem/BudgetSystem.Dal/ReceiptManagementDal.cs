using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Dal
{
    public class ReceiptManagementDal : DalBase
    {
        /// <summary>
        /// 添加入帐单
        /// </summary>
        /// <param name="addBankSlip"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int AddBankSlip(BankSlip addBankSlip, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `BankSlip` (`BSID`,`VoucherNo`,`Description`,`TradingPostscript`,`Cus_ID`,`CreateUser`,`OriginalCoin`,`CreateTimestamp`,`CNY`,`ReceiptDate`,`PaymentMethod`,`CNY2`,`ExchangeRate`,`BankName`,`Currency`,`State`,`TradeNature`,`ExportName`,`UpdateTimestamp`,`NatureOfMoney`,`IsActive`,`RemarkState`) Values (@BSID,@VoucherNo,@Description,@TradingPostscript,@Cus_ID,@CreateUser,@OriginalCoin,@CreateTimestamp,@CNY,@ReceiptDate,@PaymentMethod,@CNY2,@ExchangeRate,@BankName,@Currency,@State,@TradeNature,@ExportName,@UpdateTimestamp,@NatureOfMoney,@IsActive,@RemarkState)";
            int id = con.Insert(insertSql, addBankSlip, tran);
            if (id > 0)
            {
                addBankSlip.BSID = id;
            }
            return id;
        }

        /// <summary>
        /// 修改入帐单
        /// </summary>
        /// <param name="modifyBankSlip"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public DateTime ModifyBankSlipAmountMoney(BankSlip modifyBankSlip, IDbConnection con, IDbTransaction tran)
        {
            DateTime versionNumber = GetModifyDateTimeByTable("`BankSlip`", "`UpdateTimestamp`", modifyBankSlip.BSID, con, tran, "`BSID`");

            if (this.CheckExpired(versionNumber, modifyBankSlip.UpdateTimestamp))
            {
                throw new VersionNumberException("当前数据已过期，请刷新数据之后再完成修改。");
            }

            string updateSql = "Update `bankslip` Set `Description` = @Description,`CNY2` = @CNY2,`OriginalCoin2`=@OriginalCoin2,`State` = @State,`TradeNature` = @TradeNature,`ExportName` = @ExportName,`TradingPostscript`=@TradingPostscript,`NatureOfMoney`=@NatureOfMoney,`IsActive`=@IsActive,`RemarkState`=@RemarkState,`UpdateTimestamp` = @UpdateTimestamp Where `BSID` = @BSID";
            int id = con.Execute(updateSql, modifyBankSlip, tran);

            return GetModifyDateTimeByTable("`BankSlip`", "`UpdateTimestamp`", modifyBankSlip.BSID, con, tran, "`BSID`");
        }

        /// <summary>
        /// 删除入帐单信息
        /// </summary>
        /// <param name="deleteBankSlip"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        public void DeleteBankSlip(BankSlip deleteBankSlip, IDbConnection con, IDbTransaction tran)
        {
            string deleteReceiptnoticeSql = "delete from  receiptnotice where `BSID` = @BSID";
            con.Execute(deleteReceiptnoticeSql, new { BSID = deleteBankSlip.BSID }, tran);

            string deleteSql = "DELETE FROM `BankSlip` Where `BSID` = @BSID";
            con.Execute(deleteSql, new { BSID = deleteBankSlip.BSID }, tran);
        }

        /// <summary>
        /// 修改入帐单信息
        /// </summary>
        /// <param name="modifyBankSlip"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public DateTime ModifyBankSlip(BankSlip modifyBankSlip, IDbConnection con, IDbTransaction tran)
        {
            DateTime versionNumber = GetModifyDateTimeByTable("`BankSlip`", "`UpdateTimestamp`", modifyBankSlip.BSID, con, tran, "`BSID`");

            if (this.CheckExpired(versionNumber, modifyBankSlip.UpdateTimestamp))
            {
                throw new VersionNumberException("当前数据已过期，请刷新数据之后再完成修改。");
            }
            modifyBankSlip.UpdateTimestamp = DateTime.Now;
            string updateSql = "Update `BankSlip` Set `VoucherNo` = @VoucherNo,`Description` = @Description,`TradingPostscript` = @TradingPostscript,`Cus_ID` = @Cus_ID,`CreateUser` = @CreateUser,`OriginalCoin` = @OriginalCoin,`CreateTimestamp` = @CreateTimestamp,`CNY` = @CNY,`ReceiptDate` = @ReceiptDate,`PaymentMethod` = @PaymentMethod,`CNY2` = @CNY2,`OriginalCoin2`=OriginalCoin2,`ExchangeRate` = @ExchangeRate,`BankName` = @BankName,`Currency` = @Currency,`State` = @State,`TradeNature` = @TradeNature,`ExportName` = @ExportName,`UpdateTimestamp` = @UpdateTimestamp,`NatureOfMoney`=@NatureOfMoney,IsActive=@IsActive,RemarkState=@RemarkState Where `BSID` = @BSID";
            int id = con.Execute(updateSql, modifyBankSlip, tran);

            return GetModifyDateTimeByTable("`BankSlip`", "`UpdateTimestamp`", modifyBankSlip.BSID, con, tran, "`BSID`");
        }

        /// <summary>
        /// 修改入帐单信息
        /// </summary>
        /// <param name="modifyBankSlip"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public DateTime ModifyBankSlipState(BankSlip modifyBankSlip, IDbConnection con, IDbTransaction tran)
        {
            DateTime versionNumber = GetModifyDateTimeByTable("`BankSlip`", "`UpdateTimestamp`", modifyBankSlip.BSID, con, tran, "`BSID`");

            if (this.CheckExpired(versionNumber, modifyBankSlip.UpdateTimestamp))
            {
                throw new VersionNumberException("当前数据已过期，请刷新数据之后再完成修改。");
            }
            modifyBankSlip.UpdateTimestamp = DateTime.Now;
            string updateSql = "Update `BankSlip` Set `State` = @State Where `BSID` = @BSID";
            int id = con.Execute(updateSql, modifyBankSlip, tran);

            return GetModifyDateTimeByTable("`BankSlip`", "`UpdateTimestamp`", modifyBankSlip.BSID, con, tran, "`BSID`");
        }

        public void AddReceiptNotice(int bsID, string userName, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Insert Into `ReceiptNotice`(`UserName`,`BSID`)Values(@UserName,@BSID)";
            con.Execute(updateSql, new { UserName = userName, BSID = bsID }, tran);
        }

        public void DeleteReceiptNotice(int bsID, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Delete From `ReceiptNotice` Where BSID=@BSID";
            con.Execute(updateSql, new { BSID = bsID }, tran);
        }

        public IEnumerable<BankSlip> GetAllBankSlipListByCondition(InMoneyQueryCondition condition, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select bs.*,c.Name as Remitter,u.RealName as CreateRealName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState  From `bankslip` bs	
                LEFT JOIN Customer c on bs.Cus_ID=c.ID
                LEFT JOIN `FlowInstance` f ON f.DateItemID=bs.BSID AND f.DateItemType=@DateItemType  AND f.IsRecent=1
				LEFT JOIN `user` u on bs.CreateUser=u.UserName
                WHERE 1=1 ";

            DynamicParameters dp = new DynamicParameters();
            dp.Add("DateItemType", EnumFlowDataType.收款单.ToString(), null, null, null);
            if (condition != null)
            {
                List<string> strConditionList = new List<string>();
                if (!string.IsNullOrEmpty(condition.VoucherNo))
                {
                    strConditionList.Add(" bs.VoucherNo like @VoucherNo ");
                    dp.Add("VoucherNo", string.Format("%{0}%", condition.VoucherNo), null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.BudgetNO))
                {
                    strConditionList.Add(" bs.VoucherNo like @BudgetNO ");
                    dp.Add("BudgetNO", string.Format("%{0}%", condition.BudgetNO), null, null, null);
                }
                if (!string.IsNullOrEmpty(condition.Customer))
                {
                    strConditionList.Add(" bs.Cus_ID in (SELECT ID from customer where `Name` like @Customer)");
                    dp.Add("Customer", string.Format("%{0}%", condition.Customer), null, null, null);
                }
                if (condition.ReceiptDateBegin != DateTime.MinValue)
                {
                    strConditionList.Add(" bs.ReceiptDate >@ReceiptDateBegin ");
                    dp.Add("ReceiptDateBegin", condition.ReceiptDateBegin.ToString("yyyy-MM-dd"), null, null, null);
                }
                if (condition.ReceiptDateEnd != DateTime.MinValue)
                {
                    strConditionList.Add(" bs.ReceiptDate <@ReceiptDateEnd ");
                    dp.Add("ReceiptDateEnd", condition.ReceiptDateEnd.ToString("yyyy-MM-dd"), null, null, null);
                }

                if (condition.State == QueryReceiptState.Confirmed)
                {
                    strConditionList.Add(" bs.State=2 ");
                }
                else if (condition.State == QueryReceiptState.ToBeConfirmed)
                {
                    strConditionList.Add(" bs.State<>2 ");
                }

                if (!string.IsNullOrEmpty(condition.Salesman))
                {
                    selectSql = @"Select bs.*,c.Name as Remitter,u.RealName as CreateRealName,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState  From `bankslip` bs	
                            LEFT JOIN Customer c on bs.Cus_ID=c.ID
                            INNER JOIN ReceiptNotice rn ON bs.BSID=rn.BSID AND rn.UserName=@Username
                            INNER JOIN `User` u on rn.UserName=u.UserName
				            LEFT JOIN `user` u2 on bs.CreateUser=u2.UserName
                            INNER JOIN `department` d on u.DeptID=d.`ID`
                LEFT JOIN `FlowInstance` f ON f.DateItemID=bs.BSID AND f.DateItemType=@DateItemType  AND f.IsRecent=1
                WHERE 1=1 ";
                    strConditionList.Add(" rn.UserName=@Username or d.AssistantManager=@Username or d.Manager=@Username");
                    dp.Add("Username", condition.Salesman, null, null, null);
                }

                if (strConditionList.Count > 0)
                {
                    selectSql += string.Format(" and {0}", string.Join(" and ", strConditionList.ToArray()));
                }
            }
            return con.Query<BankSlip>(selectSql, dp, tran);
        }

        public BankSlip GetBankSlipByBSID(int bsID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select bs.*,c.Name as Remitter,IFNULL((f.ApproveResult+f.IsClosed),-1) FlowState
                                From `bankslip` bs 
                                    LEFT JOIN Customer c on bs.Cus_ID=c.ID
                                    LEFT JOIN `FlowInstance` f ON f.DateItemID=bs.BSID AND f.DateItemType=@DateItemType AND f.IsRecent=1
                                Where `BSID` = @BSID";

            return con.Query<BankSlip>(selectSql, new { DateItemType = EnumFlowDataType.收款单.ToString(), BSID = @bsID }, tran).SingleOrDefault();
        }

        public IEnumerable<BudgetBill> GetBudgetBillListByBankSlipID(int bsID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select bb.*,u.RealName as OperatorRealName,c.Name as Customer,b.ContractNO,bs.Currency,bs.BankName,bs.ExchangeRate,bs.ReceiptDate,c.Name as Remitter,bs.VoucherNo,bs.PaymentMethod,d.`Name` as DepartmentName
                                        From `BudgetBill`  bb 
                                        LEFT JOIN budget b on bb.BudgetID=b.ID
                                        LEFT JOIN Customer c on bb.Cus_ID=c.ID
                                        LEFT JOIN bankslip bs on bb.BSID=bs.BSID
										LEFT JOIN `user` u on bb.Operator=u.UserName
										LEFT JOIN department d on bb.DeptID=d.`ID`
                Where bb.`BSID` = @BSID";
            return con.Query<BudgetBill>(selectSql, new { BSID = bsID }, tran);
        }

        public IEnumerable<BudgetBill> GetBudgetBillListByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select bb.*,b.ContractNO,bs.Currency,bs.BankName,bs.ExchangeRate,bs.ReceiptDate,c.Name as Remitter,bs.VoucherNo,bs.PaymentMethod,d.`Name` as DepartmentName
                                        From `BudgetBill`  bb 
                                        LEFT JOIN budget b on bb.BudgetID=b.ID
                                        LEFT JOIN Customer c on bb.Cus_ID=c.ID
                                        LEFT JOIN bankslip bs on bb.BSID=bs.BSID
										LEFT JOIN department d on bb.DeptID=d.`ID`
                                Where bb.`BudgetID` = @BudgetID";
            return con.Query<BudgetBill>(selectSql, new { BudgetID = budgetId }, tran);
        }

        public IEnumerable<BudgetBill> GetBudgetBillListByCondition(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select bb.*,b.ContractNO,bs.Currency,bs.BankName,bs.ExchangeRate,bs.ReceiptDate,c.Name as Remitter,bs.VoucherNo,bs.PaymentMethod,d.`Name` as DepartmentName 
                                        From `BudgetBill`  bb 
                                        LEFT JOIN budget b on bb.BudgetID=b.ID
                                        LEFT JOIN Customer c on bb.Cus_ID=c.ID
                                        LEFT JOIN bankslip bs on bb.BSID=bs.BSID
										LEFT JOIN department d on bb.DeptID=d.`ID`
                                Where 1=1";
            return con.Query<BudgetBill>(selectSql, new { }, tran);
        }

        /// <summary>
        /// 添加合同金额
        /// </summary>
        /// <param name="addBudgetBill"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int AddBudgetBill(BudgetBill addBudgetBill, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `BudgetBill` (`ID`,`BudgetID`,`BSID`,`Cus_ID`,`OriginalCoin`,`CNY`,`Operator`,`DeptID`,`OperateTimestamp`,`IsDelete`,`Remark`,`Confirmed`) Values (@ID,@BudgetID,@BSID,@Cus_ID,@OriginalCoin,@CNY,@Operator,@DeptID,@OperateTimestamp,@IsDelete,@Remark,@Confirmed)";
            int id = con.Insert(insertSql, addBudgetBill, tran);
            if (id > 0)
            {
                addBudgetBill.BSID = id;
            }
            return id;
        }

        public void ConfirmSplitBankSlip(int bsID, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `BudgetBill` Set `Confirmed` = @Confirmed Where `BSID` = @BSID AND  `IsDelete` = 0";
            int id = con.Execute(updateSql, new { BSID = bsID, Confirmed = true }, tran);
        }

        /// <summary>
        /// 修改关联合同金额
        /// </summary>
        /// <param name="modifyBudgetBill"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public void ModifyBudgetBill(BudgetBill modifyBudgetBill, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `BudgetBill` Set `BudgetID` = @BudgetID,`BSID` = @BSID,Cus_ID=@Cus_ID,`OriginalCoin` = @OriginalCoin,`CNY` = @CNY,`Operator` = @Operator,`DeptID` = @DeptID,`OperateTimestamp` = @OperateTimestamp,`IsDelete` = @IsDelete,`Remark` = @Remark,`Confirmed` = @Confirmed Where `ID` = @ID";
            int id = con.Execute(updateSql, modifyBudgetBill, tran);
        }



        /// <summary>
        /// 根据合同ID获取所有收款人民币金额
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTotalAmountCNYByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select COUNT(CNY) From `BudgetBill` WHERE BudgetID=@BudgetID AND IsDelete=0 AND Confirmed=1";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "BudgetID";
            paramter.Value = budgetId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            decimal totalAmount = 0;
            decimal.TryParse(obj.ToString(), out totalAmount);
            return totalAmount;
        }

        /// <summary>
        /// 根据合同ID获取所有收款原币金额
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetTotalAmountOriginalCoinByBudgetId(int budgetId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select COUNT(OriginalCoin) From `BudgetBill` WHERE BudgetID=@BudgetID AND IsDelete=0 AND Confirmed=1";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "BudgetID";
            paramter.Value = budgetId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            decimal totalAmount = 0;
            decimal.TryParse(obj.ToString(), out totalAmount);
            return totalAmount;
        }

        /// <summary>
        /// 获取原单据已经分拆金额。
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public decimal GetAmountNotSplitBySourceId(int sourceId, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select COUNT(CNY) From `BudgetBill` WHERE BSID=@BSID AND IsDelete=0 AND Confirmed=1";

            IDbCommand command = con.CreateCommand();
            command.CommandText = selectSql;
            command.Transaction = tran;
            IDbDataParameter paramter = command.CreateParameter();
            paramter.DbType = DbType.Int32;
            paramter.ParameterName = "BSID";
            paramter.Value = sourceId;
            command.Parameters.Add(paramter);
            object obj = command.ExecuteScalar();
            decimal totalAmount = 0;
            decimal.TryParse(obj.ToString(), out totalAmount);
            return totalAmount;
        }

    }
}
