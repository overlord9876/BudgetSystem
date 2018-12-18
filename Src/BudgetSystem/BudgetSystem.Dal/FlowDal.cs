using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using System.Data;
using Dapper_NET20;
using System.Linq;

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
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent` From `FlowNode` Where`Name` = @Name and `VersionNumber` = @VersionNumber";
            return con.Query<FlowNode>(selectSql, new { Name = name, VersionNumber = version }, tran);
        }

        public FlowNode GetFlowNode(string name, int version, int order, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent` From `FlowNode` Where`Name` = @Name and `VersionNumber` = @VersionNumber and @OrderNo=OrderNo";
            return con.Query<FlowNode>(selectSql, new { Name = name, VersionNumber = version, OrderNo = order }, tran).SingleOrDefault();
        }

        public FlowNode GetFlowNode(int nodeID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent` From `FlowNode` Where`ID` = @ID";
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
            string insertSql = "Insert Into `FlowNode` (`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`) Values (@Name,@VersionNumber,@OrderNo,@NodeConfig,@NodeValue,@NodeValueRemark,@NodeExtEvent)";
            con.Execute(insertSql, nodes, tran);
        }

        public FlowInstance GetFlowNotClosedInstance(string flowName, int dataID, string dataType, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`IsCreateUserConfirm`,`ConfirmDateTime` From `FlowInstance` Where`DateItemID` = @DateItemID and @DateItemType=DateItemType and FlowName=@FlowName and `IsClosed`=0";
            return con.Query<FlowInstance>(selectSql, new { FlowName = flowName, DateItemType = dataType, DateItemID = dataID }, tran).SingleOrDefault();
        }

        public FlowInstance GetFlowInstance(int instanceID, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`CloseReason`,`CloseDateTime`,`IsCreateUserConfirm`,`ConfirmDateTime` From `FlowInstance` Where`ID` = @ID";

            return con.Query<FlowInstance>(selectSql, new { ID = instanceID }, tran).SingleOrDefault();
        }

        public int AddFlowInstance(string flowName, int flowVersion, int dataID, string dataText, string dataType, string createUser, IDbConnection con, IDbTransaction tran)
        {
            string insertSql = @"Insert Into `FlowInstance` 
                                (`FlowName`,`FlowVersionNumber`,`DateItemID`,`DateItemText`,`DateItemType`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`IsCreateUserConfirm`,`IsRecent`) 
                                Values 
                                (@FlowName,@FlowVersionNumber,@DateItemID,@DateItemText,@DateItemType,now(),@CreateUser,0,0,0,1)";
            return con.Insert(insertSql, new { FlowName = flowName, FlowVersionNumber = flowVersion, DateItemID = dataID, DateItemText = dataText, DateItemType = dataType, CreateUser = createUser }, tran);
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
            string sql = @"select t1.ID as RunPointID,t1.NodeID,t2.ID,t2.FlowName,t2.FlowVersionNumber,t2.DateItemID,t2.DateItemText,t2.DateItemType,t2.CreateDate,t2.CreateUser,t3.RealName as CreateUserRealName,t1.NodeApproveUser 
                        from FlowRunpoint t1 
                        left join FlowInstance t2 on t1.InstanceID = t2.ID
                        left join `User` t3 on t2.CreateUser= t3.UserName
                        where t1.NodeApproveUser=@NodeApproveUser and t1.State=0";


            return con.Query<FlowItem>(sql, new { NodeApproveUser = userName }, tran);
        }

        public IEnumerable<FlowItem> GetUnConfirmFlowByUser(string userName, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"Select t1.`ID`,t1.`FlowName`,t1.`FlowVersionNumber`,t1.`DateItemID`,t1.DateItemText,t1.`DateItemType`,t1.`CreateDate`,t1.`CreateUser`,t1.`ApproveResult`,t1.`IsClosed`,t1.`CloseReason`,t1.`CloseDateTime`,t1.`IsCreateUserConfirm`,`ConfirmDateTime` ,t2.RealName as CreateUserRealName
                        From `FlowInstance` t1
                        Left join `User` t2 on t1.CreateUser = t2.UserName
                        Where t1.`CreateUser` = @CreateUser and IsCreateUserConfirm=0";


            return con.Query<FlowItem>(sql, new { CreateUser = userName }, tran);
        }

        public IEnumerable<FlowRunPoint> GetFlowRunPointsByInstance(int instanceID, IDbConnection con, IDbTransaction tran)
        {
                string sql = @"Select `ID`,`NodeID`,`NodeOrderNo`,`InstanceID`,`NodeApproveUser`,`NodeApproveResult`,`NodeApproveRemark`,`State`,`RunPointCreateDate`,`NodeApproveDate` 
                    From `FlowRunPoint` 
                    Where`InstanceID` = @InstanceID
                    ORDER BY NodeOrderNo";
            return con.Query<FlowRunPoint>(sql, new { InstanceID = instanceID }, tran);
        }

        public IEnumerable<FlowRunPoint> GetFlowRunPointsByData(int dataID, string dataType, IDbConnection con, IDbTransaction tran)
        {
            string sql = @"Select t2.`ID`,t2.`NodeID`,t2.`NodeOrderNo`,t2.`InstanceID`,t2.`NodeApproveUser`,t2.`NodeApproveResult`,t2.`NodeApproveRemark`,t2.`State`,t2.`RunPointCreateDate`,t2.`NodeApproveDate` 
                        From `FlowInstance` t1  left join `FlowRunPoint` t2 on t1.ID = t2.InstanceID 
                        Where t1.`DateItemID` = @DateItemID and t1.DateItemType=@DateItemType
                        ORDER BY t2.NodeOrderNo";
            return con.Query<FlowRunPoint>(sql, new { DateItemID = dataID, DateItemType = dataType }, tran);
        }
    }
}
