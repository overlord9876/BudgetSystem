﻿using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;
using BudgetSystem.Entity.QueryCondition;

namespace BudgetSystem.Dal
{
    public class FlowDal
    {
        //string deleteSql = "Delete From `Flow` Where `Name` = @Name and `VersionNumber` = @VersionNumber";
        //string insertSql = "Insert Into `Flow` (`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled`) Values (@Name,@VersionNumber,@CreateUser,@UpdateDate,@Remark,@IsEnabled)";
        //string selectSql = "Select `Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where`Name` = @Name and `VersionNumber` = @VersionNumber";
        //string updateSql = "Update `Flow` Set `CreateUser` = @CreateUser,`UpdateDate` = @UpdateDate,`Remark` = @Remark,`IsEnabled` = @IsEnabled Where `Name` = @Name and `VersionNumber` = @VersionNumber";

        //string deleteSql = "Delete From `FlowNode` Where `ID` = @ID";
        //string insertSql = "Insert Into `FlowNode` (`ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`) Values (@ID,@Name,@VersionNumber,@OrderNo,@NodeConfig,@NodeValue,@NodeValueRemark)";
        //string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark` From `FlowNode` Where`ID` = @ID";
        //string updateSql = "Update `FlowNode` Set `Name` = @Name,`VersionNumber` = @VersionNumber,`OrderNo` = @OrderNo,`NodeConfig` = @NodeConfig,`NodeValue` = @NodeValue,`NodeValueRemark` = @NodeValueRemark Where `ID` = @ID";

        //string deleteSql = "Delete From `FlowInstance` Where `ID` = @ID";
        //string insertSql = "Insert Into `FlowInstance` (`ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`CloseDateTime`,`IsCreateUserConfirm`,`ConfirmDateTime`) Values (@ID,@FlowName,@FlowVersionNumber,@DateItemID,@DateItemType,@CreateDate,@CreateUser,@ApproveResult,@IsClosed,@CloseReason,@CloseDateTime,@IsCreateUserConfirm,@ConfirmDateTime)";
        //string selectSql = "Select `ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`CloseDateTime`,`IsCreateUserConfirm`,`ConfirmDateTime` From `FlowInstance` Where`ID` = @ID";
        //string updateSql = "Update `FlowInstance` Set `FlowName` = @FlowName,`FlowVersionNumber` = @FlowVersionNumber,`DateItemID` = @DateItemID,`DateItemType` = @DateItemType,`CreateDate` = @CreateDate,`CreateUser` = @CreateUser,`ApproveResult` = @ApproveResult,`IsClosed` = @IsClosed,`CloseReason`=@CloseReason,`CloseDateTime`=@CloseDateTime,`IsCreateUserConfirm` = @IsCreateUserConfirm,`ConfirmDateTime` = @ConfirmDateTime Where `ID` = @ID";

        //string deleteSql = "Delete From `FlowRunPoint` Where `ID` = @ID";
        //string insertSql = "Insert Into `FlowRunPoint` (`ID`,`NodeID`,`NodeOrderNo`,`InstanceID`,`NodeApproveUser`,`NodeApproveResult`,`NodeApproveRemark`,`State`,`RunPointCreateDate`,`NodeApproveDate`) Values (@ID,@NodeID,@NodeOrderNo,@InstanceID,@NodeApproveUser,@NodeApproveResult,@NodeApproveRemark,@State,@RunPointCreateDate,@NodeApproveDate)";
        //string selectSql = "Select `ID`,`NodeID`,`NodeOrderNo`,`InstanceID`,`NodeApproveUser`,`NodeApproveResult`,`NodeApproveRemark`,`State`,`RunPointCreateDate`,`NodeApproveDate` From `FlowRunPoint` Where`ID` = @ID";
        //string updateSql = "Update `FlowRunPoint` Set `NodeID` = @NodeID,`NodeOrderNo`=@NodeOrderNo,`InstanceID` = @InstanceID,`NodeApproveUser` = @NodeApproveUser,`NodeApproveResult` = @NodeApproveResult,`NodeApproveRemark` = @NodeApproveRemark,`State` = @State,`RunPointCreateDate` = @RunPointCreateDate,`NodeApproveDate` = @NodeApproveDate Where `ID` = @ID";


        public IEnumerable<Flow> GetAllEnabledFlow(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where IsEnabled = 1";
            return con.Query<Flow>(selectSql, null, tran);
        }

        public Flow GetFlow(string name, int version, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where`Name` = @Name and `VersionNumber` = @VersionNumber";
            return con.Query<Flow>(selectSql, new { Name = name, VersionNumber = version }, tran).SingleOrDefault();
        }

        public IEnumerable<FlowNode> GetFlowDetial(string name, int version, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,`IsStartNode` From `FlowNode` Where`Name` = @Name and `VersionNumber` = @VersionNumber ORDER BY OrderNo";
            return con.Query<FlowNode>(selectSql, new { Name = name, VersionNumber = version }, tran);
        }

        public IEnumerable<FlowNode> GetFlowDetial(EnumFlowNames name, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "SELECT * from Flow WHERE `Name`= @Name and IsEnabled=1;";
            var flow = con.Query<Flow>(selectSql, new { Name = name.ToString() }, tran).FirstOrDefault();
            if (flow == null) { return null; }
            selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,`IsStartNode` From `FlowNode` Where`Name` = @Name and `VersionNumber` = @VersionNumber ORDER BY OrderNo";
            return con.Query<FlowNode>(selectSql, new { Name = name.ToString(), VersionNumber = flow.VersionNumber }, tran);
        }

        public FlowNode GetFlowNode(string name, int version, int order, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,`IsStartNode` From `FlowNode` Where`Name` = @Name and `VersionNumber` = @VersionNumber and @OrderNo=OrderNo";
            return con.Query<FlowNode>(selectSql, new { Name = name, VersionNumber = version, OrderNo = order }, tran).SingleOrDefault();
        }

        public FlowNode GetFlowNode(int nodeID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,`IsStartNode` From `FlowNode` Where`ID` = @ID";
            return con.Query<FlowNode>(selectSql, new { ID = nodeID }, tran).SingleOrDefault();
        }

        public Flow GetFlowEnableVersion(string flowName, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where`Name` = @Name  and `IsEnabled`=1";
            return con.Query<Flow>(selectSql, new { Name = flowName, }, tran).SingleOrDefault();
        }

        public void SetFlowDisable(string flowName, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `Flow` Set `IsEnabled` = 0 Where `Name` = @Name";
            con.Execute(updateSql, new { Name = flowName }, tran);
        }

        public void AddFlow(Flow flow, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `Flow` (`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled`) Values (@Name,@VersionNumber,@CreateUser,now(),@Remark,@IsEnabled)";
            con.Execute(insertSql, flow, tran);
        }

        public void AddFlowDetial(List<FlowNode> nodes, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = "Insert Into `FlowNode` (`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,`IsStartNode`) Values (@Name,@VersionNumber,@OrderNo,@NodeConfig,@NodeValue,@NodeValueRemark,@NodeExtEvent,@IsStartNode)";
            con.Execute(insertSql, nodes, tran);
        }

        public FlowInstance GetFlowNotClosedInstance(string flowName, int dataID, string dataType, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`IsCreateUserConfirm`,`ConfirmDateTime`,Description From `FlowInstance` Where`DateItemID` = @DateItemID and @DateItemType=DateItemType and FlowName=@FlowName and `IsClosed`=0";
            return con.Query<FlowInstance>(selectSql, new { FlowName = flowName, DateItemType = dataType, DateItemID = dataID }, tran).SingleOrDefault();
        }

        public FlowInstance GetFlowInstance(int instanceID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`CloseDateTime`,`IsCreateUserConfirm`,`ConfirmDateTime`,Description From `FlowInstance` Where`ID` = @ID";

            return con.Query<FlowInstance>(selectSql, new { ID = instanceID }, tran).SingleOrDefault();
        }

        public int AddFlowInstance(string flowName, int flowVersion, int dataID, string dataText, string dataType, string createUser, string description, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = @"Insert Into `FlowInstance` 
                                (`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`IsCreateUserConfirm`,`IsRecent`,Description) 
                                Values 
                                (@FlowName,@FlowVersionNumber,@DateItemID,@DateItemText,@DateItemType,now(),@CreateUser,0,0,0,1,@Description)";
            return con.Insert(insertSql, new { FlowName = flowName, FlowVersionNumber = flowVersion, DateItemID = dataID, DateItemText = dataText, DateItemType = dataType, CreateUser = createUser, Description = description }, tran);
        }
        /// <summary>
        /// 更新流程IsRecent值，新创建FlowInstance前更新流程数据已有Instance的IsRecent为false
        /// </summary>
        /// <param name="flowName"></param>
        /// <param name="dataItemType"></param>
        /// <param name="dataID"></param>
        /// <param name="isRecent"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        public void UpdateFlowInstanceIsRecent(string dataItemType, int dataID, bool isRecent, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `FlowInstance` Set `IsRecent` = @IsRecent Where `DateItemID` = @DateItemID and DateItemType=@DateItemType";
            con.Execute(updateSql, new { IsRecent = isRecent, DateItemID = dataID, DateItemType = dataItemType }, tran);
        }

        public void UpdateFlowInstanceCloseInfo(int instanceID, bool approveReslt, string closeReason, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `FlowInstance` Set `ApproveResult` = @ApproveResult,`IsClosed` = 1,`CloseReason`=@CloseReason,`CloseDateTime` = now() Where `ID` = @ID";
            con.Execute(updateSql, new { ApproveResult = approveReslt, closeReason = closeReason, ID = instanceID }, tran);

        }


        public void UpdateFlowInstanceConfirmInfo(int instanceID, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `FlowInstance` Set `IsCreateUserConfirm` = 1,`ConfirmDateTime` = now() Where `ID` = @ID";
            con.Execute(updateSql, new { ID = instanceID }, tran);
        }

        public int AddFlowRunPoint(int nodeID, int nodeOrderNo, int instanceID, string approve, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = @"Insert Into `FlowRunPoint` 
                                (`NodeID`,`NodeOrderNo`,`InstanceID`,`NodeApproveUser`,`State`,`RunPointCreateDate`) 
                                Values 
                                (@NodeID,@NodeOrderNo,@InstanceID,@NodeApproveUser,0,now())";

            return con.Insert(insertSql, new { NodeID = nodeID, NodeOrderNo = nodeOrderNo, InstanceID = instanceID, NodeApproveUser = approve }, tran);
        }

        public void DeleteFlowInstanceByDateItem(int dataItemId, string dataItemType, IDbConnection con, IDbTransaction tran)
        {
            string flowRunpointSql = "DELETE from FlowRunpoint where InstanceID in (select ID from FlowInstance where DateItemID=@DateItemID  and DateItemType=@DateItemType)";

            con.Execute(flowRunpointSql, new { DateItemID = dataItemId, DateItemType = dataItemType }, tran);

            string flowInstanceSql = "DELETE from FlowInstance where DateItemID=@DateItemID  and DateItemType=@DateItemType;";
            con.Execute(flowInstanceSql, new { DateItemID = dataItemId, DateItemType = dataItemType }, tran);

        }

        public FlowRunPoint GetFlowRunPoint(int runPointID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`NodeID`,`NodeOrderNo`,`InstanceID`,`NodeApproveUser`,`NodeApproveResult`,`NodeApproveRemark`,`State`,`RunPointCreateDate`,`NodeApproveDate` From `FlowRunPoint` Where`ID` = @ID";

            return con.Query<FlowRunPoint>(selectSql, new { ID = runPointID }, tran).SingleOrDefault();
        }

        public void UpdateFlowRunPointApproveInfo(int runPointID, bool result, string remark, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = "Update `FlowRunPoint` Set `NodeApproveResult` = @NodeApproveResult,`NodeApproveRemark` = @NodeApproveRemark,`State` = 1,`NodeApproveDate` = now() Where `ID` = @ID";
            con.Execute(updateSql, new { ID = runPointID, NodeApproveResult = result, NodeApproveRemark = remark }, tran);
        }


        public IEnumerable<FlowItem> GetPendingFlowByUser(string userName, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"select t1.ID as RunPointID,t1.NodeID,t2.ID,t2.FlowName,t2.FlowVersionNumber,t2.DateItemID,t2.DateItemText,t2.DateItemType,t2.CreateDate,t2.CreateUser,t3.RealName as CreateUserRealName,t1.NodeApproveUser,t2.Description 
                        from FlowRunpoint t1 
                        left join FlowInstance t2 on t1.InstanceID = t2.ID
                        left join `User` t3 on t2.CreateUser= t3.UserName
                        where t1.NodeApproveUser=@NodeApproveUser and t1.State=0 and t2.IsClosed=0";


            return con.Query<FlowItem>(sql, new { NodeApproveUser = userName }, tran);
        }

        public FlowInstance GetFlowInstanceByDateItem(int dateItemId, EnumFlowDataType dateItemType, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = @"Select `ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`CloseDateTime`,`IsCreateUserConfirm`,`ConfirmDateTime`,Description 
                                    From `FlowInstance` 
                                    Where DateItemID=@DateItemID AND DateItemType=@DateItemType AND IsRecent=1";


            return con.Query<FlowItem>(selectSql, new { DateItemID = dateItemId, DateItemType = dateItemType.ToString() }, tran).FirstOrDefault();
        }

        public IEnumerable<FlowItem> GetUnConfirmFlowByUser(string userName, IDbConnection con, IDbTransaction tran)
        {
            //            string sql = @"Select t1.`ID`,t1.`FlowName`,t1.`FlowVersionNumber`,t1.`DateItemID`,t1.DateItemText,t1.`DateItemType`,t1.`CreateDate`,t1.`CreateUser`,t1.`ApproveResult`,t1.`IsClosed`,t1.`CloseReason`,t1.`CloseDateTime`,t1.`IsCreateUserConfirm`,`ConfirmDateTime` ,t2.RealName as CreateUserRealName
            //                        From `FlowInstance` t1
            //                        Left join `User` t2 on t1.CreateUser = t2.UserName
            //                        Where t1.`CreateUser` = @CreateUser and IsCreateUserConfirm=0";

            string sql = @"select t2.`ID`,t2.`FlowName`,t2.`FlowVersionNumber`,t2.`DateItemID`,t2.`DateItemText`,t2.`DateItemType`,t2.`CreateDate`,t2.`CreateUser`,t2.`ApproveResult`,t2.`IsClosed`,t2.`CloseReason`,t2.`CloseDateTime`,t2.`IsCreateUserConfirm`,`ConfirmDateTime` ,t3.RealName as CreateUserRealName,t4.RealName as NextUserRealName,t2.Description
                            from FlowRunpoint t1 
                            left join FlowInstance t2 on t1.InstanceID = t2.ID
                            left join `User` t3 on t2.CreateUser= t3.UserName
                            left join `User` t4 on t1.NodeApproveUser = t4.UserName
                            where t2.CreateUser=@CreateUser and t1.State=0  and t2.IsClosed=0

                            UNION  ALL

                            Select t1.`ID`,t1.`FlowName`,t1.`FlowVersionNumber`,t1.`DateItemID`,t1.`DateItemText`,t1.`DateItemType`,t1.`CreateDate`,t1.`CreateUser`,t1.`ApproveResult`,t1.`IsClosed`,t1.`CloseReason`,t1.`CloseDateTime`,t1.`IsCreateUserConfirm`,`ConfirmDateTime` ,t2.RealName as CreateUserRealName,'' as NextUserRealName,t1.Description
                            From `FlowInstance` t1
                            Left join `User` t2 on t1.CreateUser = t2.UserName
                            Where t1.`CreateUser` = @CreateUser and IsCreateUserConfirm=0 and IsClosed = 1";
            return con.Query<FlowItem>(sql, new { CreateUser = userName }, tran);
        }

        public IEnumerable<FlowItem> GetAprrovalFlowByCondition(ApprovalFlowQueryCondition condition, IDbConnection con)
        {
            string sql = @"SELECT t2.`ID`,t2.`FlowName`,t2.`FlowVersionNumber`,t1.NodeApproveDate,t2.`DateItemID`,t2.`DateItemText`,t2.`DateItemType`,t2.`CreateDate`,t2.`CreateUser`,t2.`ApproveResult`,t2.`IsClosed`,t2.`CloseReason`,t2.`CloseDateTime`,t2.`IsCreateUserConfirm`,`ConfirmDateTime` ,t3.RealName as CreateUserRealName,t4.RealName as NextUserRealName,t2.Description
                            FROM FlowRunpoint t1
                            LEFT JOIN FlowInstance t2 on t1.InstanceID = t2.ID
                            LEFT JOIN `User` t3 on t2.CreateUser= t3.UserName
                            LEFT JOIN `User` t4 on t1.NodeApproveUser = t4.UserName
                            WHERE t1.State=1 ";
            DynamicParameters dp = new DynamicParameters();
            if (condition != null)
            {
                sql += " AND NodeApproveUser=@NodeApproveUser ";
                dp.Add("NodeApproveUser", condition.CurrentUer, DbType.String, ParameterDirection.Input, null);
                if (!condition.BeginTimestamp.Equals(condition.EndTimestamp))
                {
                    sql += "AND NodeApproveDate BETWEEN @BeginTime and @EndTime ";
                    dp.Add("BeginTime", condition.BeginTimestamp, DbType.DateTime, ParameterDirection.Input, null);
                    dp.Add("EndTime", condition.EndTimestamp, DbType.DateTime, ParameterDirection.Input, null);
                }
            }
            return con.Query<FlowItem>(sql, dp);
        }

        public IEnumerable<FlowRunPoint> GetFlowRunPointsByInstance(int instanceID, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"Select frp.*,fn.NodeExtEvent,fn.NodeValueRemark,u.RealName
                    From `FlowRunPoint` frp
										LEFT JOIN flownode fn on frp.NodeID=fn.ID
										LEFT JOIN `user` u on frp.NodeApproveUser=u.UserName
                    Where`InstanceID` = @InstanceID
                    ORDER BY NodeOrderNo";
            return con.Query<FlowRunPoint>(sql, new { InstanceID = instanceID }, tran);
        }

        public bool DeleteLastRunPointById(int runPointID, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"DELETE FROM FlowRunPoint where ID=@ID";
            return con.Execute(sql, new { ID = runPointID }, tran) > 0;
        }

        public bool ModifyCurrentUserRunPoint(int runPointID, string nodeApproveUser, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"Update FlowRunPoint set  NodeApproveResult=null,NodeApproveRemark=NULL,State=0,RunPointCreateDate=NOW(),NodeApproveDate=NULL where ID=@ID AND NodeApproveUser=@NodeApproveUser;";
            return con.Execute(sql, new { ID = runPointID, NodeApproveUser = nodeApproveUser }, tran) > 0;
        }

        public void RevokePaymentFlowClosedInstance(int instanceID, IDbConnection con, IDbTransaction tran)
        {
            string updateSql = @"Update `FlowInstance` Set `ApproveResult` = 0,`IsClosed` = 0,`CloseReason`=null,`CloseDateTime` = null Where `ID` = @ID";
            con.Execute(updateSql, new { ID = instanceID }, tran);

        }

        public IEnumerable<FlowRunPoint> GetFlowRunPointsByData(int dataID, string dataType, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"Select frp.*,fn.NodeExtEvent,fn.NodeValueRemark,u.RealName,t1.FlowName,t1.CloseReason
                    From `FlowInstance` t1  
						LEFT JOIN `FlowRunPoint` frp on t1.ID = frp.InstanceID 
						LEFT JOIN flownode fn on frp.NodeID=fn.ID
						LEFT JOIN `user` u on frp.NodeApproveUser=u.UserName
                        Where t1.`DateItemID` = @DateItemID and t1.DateItemType=@DateItemType
                        ORDER BY  t1.IsRecent,frp.NodeOrderNo";
            return con.Query<FlowRunPoint>(sql, new { DateItemID = dataID, DateItemType = dataType }, tran);
        }

        public IEnumerable<FlowRunPoint> GetIsRecentFlowRunPointsByData(int dataID, string dataType, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"Select frp.*,fn.NodeExtEvent,fn.NodeValueRemark,u.RealName
                    From `FlowInstance` t1  
						LEFT JOIN `FlowRunPoint` frp on t1.ID = frp.InstanceID 
						LEFT JOIN flownode fn on frp.NodeID=fn.ID
						LEFT JOIN `user` u on frp.NodeApproveUser=u.UserName
                        Where t1.`DateItemID` = @DateItemID and t1.DateItemType=@DateItemType  AND IsRecent=1
                        ORDER BY  t1.IsRecent,frp.NodeOrderNo";
            return con.Query<FlowRunPoint>(sql, new { DateItemID = dataID, DateItemType = dataType }, tran);
        }
    }
}
