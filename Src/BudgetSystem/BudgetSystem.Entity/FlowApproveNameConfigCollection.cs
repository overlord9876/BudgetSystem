using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BudgetSystem.Entity
{
    public class FlowApproveNameConfigCollection : List<FlowApproveNameConfig>
    {
        public string GetDisplayAcceptName(string flowName)
        {
            FlowApproveNameConfig fc = this.SingleOrDefault(s => s.FlowName == flowName);
            return fc == null ? "同意" : fc.AcceptDisplayName;

        }


        public string GetDisplayRefuseName(string flowName)
        {
            FlowApproveNameConfig fc = this.SingleOrDefault(s => s.FlowName == flowName);
            return fc == null ? "驳回" : fc.RefuseDisplayName;
        }


    }
}
