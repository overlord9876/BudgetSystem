using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using BudgetSystem.Dal;
using System.Linq;

namespace BudgetSystem.Bll
{
    public class FlowManager:BaseManager
    {

        private FlowDal dal = new FlowDal();

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

        public List<FlowNode> GetFlowDetail(string name, int version)
        {
            var lst = this.Query<FlowNode>((con) =>
            {

                var uList = dal.GetFlowDetial(name,version,con, null);
                return uList;

            });
            return lst.ToList();
        }


        /// <summary>
        /// 发起流程
        /// </summary>
        /// <param name="dataID">数据项ID</param>
        /// <param name="dataType">数据项类型</param>
        /// <param name="CreateUser">发起人</param>
        public void StartFlow(int dataID, string dataType, string CreateUser)
        { 
        
        }


        /// <summary>
        /// 提交流程
        /// </summary>
        /// <param name="runPointID">运行点ID</param>
        /// <param name="approveResult">审批结果</param>
        /// <param name="approveRemark">审批意件</param>
        public void SubmitFlow(int runPointID, bool approveResult, string approveRemark)
        { 
        
        }

        /// <summary>
        /// 发起人确认流程结果
        /// </summary>
        /// <param name="instanceID"></param>
        public void ConfirmFlowInstance(int instanceID)
        {
        
        }

        /// <summary>
        /// 获取用户的待审批流程
        /// </summary>
        /// <returns></returns>
        public List<int> GetPendingFlowByUser()
        {
            throw new Exception();
        }


        /// <summary>
        /// 获取用户的待确认流程
        /// </summary>
        /// <returns></returns>
        public List<int> GetNeedConfirmFlowByUser()
        {
            throw new Exception();
        }


    


        //要获取数据项的RunPoint,用于处理是否已通过，或能否再发起审批

        //简单点处理，不考虑打回的，如果审批不通过，直接发回给原点。这里就有一个问题了，是手工重新发起流程，还是数据作废？
        //在流程引擎上处理
        //1.如果直接作废，那引擎不需要再多的处理。在个人确认完成数据后，业务删除数据即可
        //2.如果手工再发起流程，业务那边可以加一个按钮，重新发起流程，引擎端提交接口处理，重新发起流程时检查未审批通过或未审批过。
        //目前先计划按方法2处理。


    }
}
