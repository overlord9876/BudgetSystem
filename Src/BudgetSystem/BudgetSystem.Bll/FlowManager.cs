using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Dal;
using System.Linq;
using System.Data;

namespace BudgetSystem.Bll
{
    public class FlowManager : BaseManager
    {

        private FlowDal dal = new FlowDal();
        private UserDal uDal;
        private DepartmentDal dDal;

        private UserDal userDal
        {
            get
            {
                if (uDal == null)
                {
                    uDal = new UserDal();
                }
                return uDal;
            }
        }
        private DepartmentDal departmentDal
        {
            get
            {
                if (dDal == null)
                {
                    dDal = new DepartmentDal();
                }
                return dDal;
            }
        }

        public List<Flow> GetAllEnabledFlow()
        {
            var lst = this.Query<Flow>((con) =>
            {

                var uList = dal.GetAllEnabledFlow(con, null);
                return uList;

            });
            return lst.ToList();

        }

        public Flow GetFlow(string name, int version)
        {
            return this.Query<Flow>((con) =>
             {

                 return dal.GetFlow(name, version, con, null);
             });
        }


        public Flow GetFlowWithDetial(string name, int version)
        {
            return this.Query<Flow>((con) =>
            {
                Flow flow = dal.GetFlow(name, version, con, null);
                flow.Details = dal.GetFlowDetial(name, version, con, null).ToList();
                return flow;
            });
        }

        public List<FlowNode> GetFlowDetail(string name, int version)
        {
            var lst = this.Query<FlowNode>((con) =>
            {

                var uList = dal.GetFlowDetial(name, version, con, null);
                return uList;

            });
            return lst.ToList();
        }

        public FlowNode GetFlowNode(int runPointID)
        {
            return this.Query<FlowNode>((con) =>
            {
                FlowRunPoint runPoint = dal.GetFlowRunPoint(runPointID, con, null);
                FlowNode node = dal.GetFlowNode(runPoint.NodeID, con, null);
                return node;

            });
        }

        public void SaveFlow(Flow flow)
        {
            this.ExecuteWithTransaction((con, tran) =>
            {
                //获取最大版本号
                int version = dal.GetFlowEnableVersion(flow.Name, con, tran).VersionNumber;
                version++;

                flow.IsEnabled = true;
                flow.VersionNumber = version;
                for (int i = 0; i < flow.Details.Count; i++)
                {
                    flow.Details[i].OrderNo = i + 1;
                    flow.Details[i].Name = flow.Name;
                    flow.Details[i].VersionNumber = version;
                }

                //把流程的其它版本号都设置为无效
                dal.SetFlowDisable(flow.Name, con, tran);
                dal.AddFlow(flow, con, tran);
                dal.AddFlowDetial(flow.Details, con, tran);

            });
        }


        /// <summary>
        /// 发起流程
        /// </summary>
        /// <param name="dataID">数据项ID</param>
        /// <param name="dataType">数据项类型</param>
        /// <param name="CreateUser">发起人</param>
        /// <param name="flowName">流程名称</param>
        /// <returns>
        /// 1 启动成功
        /// 2 当前数据项已存在相同流程的未完成实例 
        /// 3 流程还未配置审批过程
        /// 4 创建运行点时失败，用户部门未配置。
        /// </returns>
        public FlowRunState StartFlow(string flowName, int dataID, string dataText, string dataType, string currentUser)
        {

            return this.ExecuteWithTransaction<FlowRunState>((con, tran) =>
            {
                //检查当时数据是否已存在未完成的流程了
                FlowInstance instance = dal.GetFlowNotClosedInstance(flowName, dataID, dataType, con, tran);

                if (instance != null && instance.IsClosed == false)
                {
                    return FlowRunState.数据项已正在;
                }

                //获取流程，如果流程的版本是0，说明流程还未配置，不可以运行。
                Flow flow = dal.GetFlowEnableVersion(flowName, con, tran);
                if (flow.VersionNumber == 0)
                {
                    return FlowRunState.流程未配置审批过程;
                }
                //更新数据已关联流程实例的IsRecent属性为false
                dal.UpdateFlowInstanceIsRecent(dataType, dataID, false, con, tran);
                //创建流程实例 
                int instanceID = dal.AddFlowInstance(flow.Name, flow.VersionNumber, dataID, dataText, dataType, currentUser, con, tran);

                //创建运行点
                FlowRunState createRunpointResult = ToNextRunPoint(flow.Name, flow.VersionNumber, instanceID, null, currentUser, con, tran);

                //如果运行点返回是3的，关闭实例 
                if (createRunpointResult == FlowRunState.流程发起人未配置部门)
                {
                    dal.UpdateFlowInstanceCloseInfo(instanceID, false, FlowConst.FlowNotApprovedMessage, con, tran);
                    return FlowRunState.流程发起人未配置部门;
                }
                return FlowRunState.启动流程成功;
            });
        }


        /// <summary>
        /// 指向下一个运行点
        /// </summary>
        /// <param name="flowName"></param>
        /// <param name="flowVersion"></param>
        /// <param name="instanceID"></param>
        /// <param name="isFirst"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns>
        /// 1 成功创建了下一个运行点
        /// 2 下一个运行点不存在，流程运行完了
        /// 3 创建运行点时失败，用户部门未配置。
        /// </returns>
        private FlowRunState ToNextRunPoint(string flowName, int flowVersion, int instanceID, FlowRunPoint runPoint, string instanceCreateUser, IDbConnection con, IDbTransaction tran)
        {

            int orderNo = 1;


            //如果传进来的运行点是空的，说明是新实例 ，orderNo取1，否则获取这个运行点对应节点顺序号+1
            if (runPoint != null)
            {
                orderNo = runPoint.NodeOrderNo + 1;
            }

            FlowNode nextNode = dal.GetFlowNode(flowName, flowVersion, orderNo, con, tran);

            //如果下一个顺序号对应的节点不存在了，则说明实例运行完了。
            if (nextNode == null)
            {
                return FlowRunState.流程审批完成;
            }

            //计算下一个结点的审批人
            string nextApprove = "";

            if (nextNode.NodeConfig == 0)
            {
                if (nextNode.NodeValue == FlowConst.FlowCreateUser)
                {
                    nextApprove = instanceCreateUser;
                }
                else
                {
                    nextApprove = nextNode.NodeValue;
                }
            }
            else
            {

                string departMentCode;
                if (nextNode.NodeValue == FlowConst.FlowCreateUserDepartment)
                {
                    User user = userDal.GetUser(instanceCreateUser, con, tran);
                    departMentCode = user.DeptID.ToString();

                }
                else
                {
                    departMentCode = nextNode.NodeValue;
                }

                if (string.IsNullOrEmpty(departMentCode))
                {
                    //如果是基本用户所在部门分配时，如果用户未配置部门，返回错误3
                    return FlowRunState.流程发起人未配置部门;
                }

                Department department = departmentDal.GetDepartment(departMentCode, con, tran);

                if (nextNode.NodeConfig == 1)
                {
                    nextApprove = department.Manager;
                }
                else
                {
                    nextApprove = department.AssistantManager;
                }
            }

            dal.AddFlowRunPoint(nextNode.ID, nextNode.OrderNo, instanceID, nextApprove, con, tran);

            return FlowRunState.创建运行点成功;

        }




        /// <summary>
        /// 提交流程
        /// </summary>
        /// <param name="runPointID">运行点ID</param>
        /// <param name="approveResult">审批结果</param>
        /// <param name="approveRemark">审批意件</param>
        /// <returns>
        /// 1 成功创建了下一个运行点
        /// 2 流程已审核完成
        /// 3 此节点已经审批过了
        /// 4 创建运行点时失败，用户部门未配置。
        /// </returns>
        public FlowRunState SubmitFlow(int runPointID, bool approveResult, string approveRemark)
        {
            return this.ExecuteWithTransaction<FlowRunState>((con, tran) =>
            {
                //获取运行点
                FlowRunPoint runPoint = dal.GetFlowRunPoint(runPointID, con, tran);

                //检查运行点状态，以免多次提交。
                if (runPoint.State)
                {
                    return FlowRunState.提交的流程节点已审批过了;
                }

                //更新当前运行点状态、
                dal.UpdateFlowRunPointApproveInfo(runPointID, approveResult, approveRemark, con, tran);

                if (approveResult == false)
                {
                    //如果提交的是审批不通过，关闭实例，返回流程审核完成。
                    dal.UpdateFlowInstanceCloseInfo(runPoint.InstanceID, false, FlowConst.FlowNotApprovedMessage, con, tran);
                    return FlowRunState.流程审批完成;
                }

                //准备创建下一个运行点
                FlowInstance instance = dal.GetFlowInstance(runPoint.InstanceID, con, tran);

                FlowRunState jumpResult = ToNextRunPoint(instance.FlowName, instance.FlowVersionNumber, instance.ID, runPoint, instance.CreateUser, con, tran);

                if (jumpResult == FlowRunState.流程审批完成)
                {
                    //不需要创建下一个运行点了。关闭实例，返回流程审核完成
                    dal.UpdateFlowInstanceCloseInfo(runPoint.InstanceID, true, FlowConst.FlowApprovedMessage, con, tran);
                    return FlowRunState.流程审批完成;
                }
                else if (jumpResult == FlowRunState.流程发起人未配置部门)
                {
                    //如果创建运行点时是未能匹配审批人，提交关闭运行点，并返回结果
                    dal.UpdateFlowInstanceCloseInfo(instance.ID, false, FlowConst.FlowUserNotConfigDepartmentMessage, con, tran);
                    return FlowRunState.流程发起人未配置部门;
                }



                return FlowRunState.创建运行点成功;
            });



        }

        public FlowRunState RevokeFlow(int instanceID, bool checkFlowNotApproved)
        {
            return this.ExecuteWithTransaction<FlowRunState>((con, tran) =>
            {

                FlowInstance instance = dal.GetFlowInstance(instanceID, con, tran);
                if (instance.IsClosed)
                {
                    return FlowRunState.撤回的流程实例已经审批完成了;
                }

                if (checkFlowNotApproved)
                {
                    int runPointCount = dal.GetFlowRunPointsByInstance(instanceID, con, tran).Count();
                    if (runPointCount > 1)
                    {
                        return FlowRunState.撤回的流程实例已经有人审批过了;
                    }
                }

                dal.UpdateFlowInstanceCloseInfo(instance.ID, false, FlowConst.FlowRetractMessage, con, tran);
                return FlowRunState.撤回成功;

            });
        }

        /// <summary>
        /// 发起人确认流程结果
        /// </summary>
        /// <param name="instanceID"></param>
        public FlowRunState ConfirmFlowInstance(int instanceID)
        {

            return this.ExecuteWithTransaction<FlowRunState>((con, tran) =>
            {

                FlowInstance instance = dal.GetFlowInstance(instanceID, con, tran);
                if (!instance.IsClosed)
                {
                    return FlowRunState.确认的流程实例未审批完成;
                }
                if (instance.IsCreateUserConfirm)
                {
                    return FlowRunState.确认的流程实例已经确认过了;
                }

                dal.UpdateFlowInstanceConfirmInfo(instanceID, con, tran);
                return FlowRunState.确认成功;

            });

        }

        /// <summary>
        /// 获取用户的待审批流程
        /// </summary>
        /// <returns></returns>
        public List<FlowItem> GetPendingFlowByUser(string userName)
        {
            return this.Query<FlowItem>((con) =>
            {

                var fList = dal.GetPendingFlowByUser(userName, con, null);
                return fList;

            }).ToList();

        }


        /// <summary>
        /// 获取用户的待确认流程
        /// </summary>
        /// <returns></returns>
        public List<FlowItem> GetUnConfirmFlowByUser(string userName)
        {
            return this.Query<FlowItem>((con) =>
            {

                var fList = dal.GetUnConfirmFlowByUser(userName, con, null);
                return fList;

            }).ToList();
        }


        public List<FlowRunPoint> GetFlowRunPointsByInstance(int instanceID)
        {
            return this.Query<FlowRunPoint>((con) =>
            {

                var fList = dal.GetFlowRunPointsByInstance(instanceID, con, null);
                return fList;

            }).ToList();

        }

        public List<FlowRunPoint> GetFlowRunPointsByData(int dataID, string dataType)
        {
            return this.Query<FlowRunPoint>((con) =>
            {

                var fList = dal.GetFlowRunPointsByData(dataID, dataType, con, null);
                return fList;

            }).ToList();

        }



        //要获取数据项的RunPoint,用于处理是否已通过，或能否再发起审批

        //简单点处理，不考虑打回的，如果审批不通过，直接发回给原点。这里就有一个问题了，是手工重新发起流程，还是数据作废？
        //在流程引擎上处理
        //1.如果直接作废，那引擎不需要再多的处理。在个人确认完成数据后，业务删除数据即可
        //2.如果手工再发起流程，业务那边可以加一个按钮，重新发起流程，引擎端提交接口处理，重新发起流程时检查未审批通过或未审批过。
        //目前先计划按方法2处理。




    }
}
