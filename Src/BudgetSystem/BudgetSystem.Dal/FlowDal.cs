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
        //string insertSql = "Insert Into `FlowInstance` (`ID`,`Name`,`VersionNumber`,`DateItemID`,`DateItemValue`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`IsCreateUserConfirm`,`ConfirmDateTime`) Values (@ID,@Name,@VersionNumber,@DateItemID,@DateItemValue,@CreateDate,@CreateUser,@ApproveResult,@IsClosed,@IsCreateUserConfirm,@ConfirmDateTime)";
        //string selectSql = "Select `ID`,`Name`,`VersionNumber`,`DateItemID`,`DateItemValue`,`CreateDate`,`CreateUser`,`ApproveResult`,`IsClosed`,`IsCreateUserConfirm`,`ConfirmDateTime` From `FlowInstance` Where`ID` = @ID";
        //string updateSql = "Update `FlowInstance` Set `Name` = @Name,`VersionNumber` = @VersionNumber,`DateItemID` = @DateItemID,`DateItemValue` = @DateItemValue,`CreateDate` = @CreateDate,`CreateUser` = @CreateUser,`ApproveResult` = @ApproveResult,`IsClosed` = @IsClosed,`IsCreateUserConfirm` = @IsCreateUserConfirm,`ConfirmDateTime` = @ConfirmDateTime Where `ID` = @ID";

        //string deleteSql = "Delete From `FlowRunPoint` Where `ID` = @ID";
        //string insertSql = "Insert Into `FlowRunPoint` (`ID`,`NodeID`,`InstanceID`,`NodeApproveUser`,`NodeApproveResult`,`NodeApproveRemark`,`State`) Values (@ID,@NodeID,@InstanceID,@NodeApproveUser,@NodeApproveResult,@NodeApproveRemark,@State)";
        //string selectSql = "Select `ID`,`NodeID`,`InstanceID`,`NodeApproveUser`,`NodeApproveResult`,`NodeApproveRemark`,`State` From `FlowRunPoint` Where`ID` = @ID";
        //string updateSql = "Update `FlowRunPoint` Set `NodeID` = @NodeID,`InstanceID` = @InstanceID,`NodeApproveUser` = @NodeApproveUser,`NodeApproveResult` = @NodeApproveResult,`NodeApproveRemark` = @NodeApproveRemark,`State` = @State Where `ID` = @ID";


        public IEnumerable<Flow> GetAllEnabledFlow(IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where IsEnabled = 1";
            return con.Query<Flow>(selectSql, null, tran);
        }

        public Flow GetFlow(string name,int version,IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where`Name` = @Name and `VersionNumber` = @VersionNumber"; 
            return con.Query<Flow>(selectSql, new { Name = name, VersionNumber = version }, tran).SingleOrDefault();
        }


        public IEnumerable<FlowNode> GetFlowDetial(string name,int version,IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `ID`,`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark` From `FlowNode` Where`Name` = @Name and `VersionNumber` = @VersionNumber";
            return con.Query<FlowNode>(selectSql, new { Name = name, VersionNumber = version }, tran);
        }

        public Flow GetFlowEnableVersion(string flowName, IDbConnection con, IDbTransaction tran)
        {
            string selectSql = "Select `VersionNumber`,`CreateUser`,`UpdateDate`,`Remark`,`IsEnabled` From `Flow` Where`Name` = @Name  and `IsEnabled`=1";
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
            string insertSql = "Insert Into `FlowNode` (`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`) Values (@Name,@VersionNumber,@OrderNo,@NodeConfig,@NodeValue,@NodeValueRemark)";
            con.Execute(insertSql, nodes, tran);
        }
    }
}
