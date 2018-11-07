using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class ActionWithPermission
    {
        public Action MainAction
        {
            get;
            set;
        }

        public OperateTypes MainOperate
        {
            get;
            set;
        }

        public Action SecondAction
        {
            get;
            set;
        }

        public OperateTypes SecondOperate
        {
            get;
            set;
        }
    }
}
