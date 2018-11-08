using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class RunInfo
    {
        private  RunInfo()
        {
            this.Config = Config.Read();
        }

        private static object lockObj = new object();
        private static RunInfo instance = null;
        
        public static RunInfo Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new RunInfo();
                    }
                }
                return instance;
            
            }
        }

        public Config Config
        {
            get;
            private set;
        }

        public User CurrentUser
        {
            get;
            set;
        }

        public List<string> UserPermission
        {
            get;
            set;
        }

       
    }
}
