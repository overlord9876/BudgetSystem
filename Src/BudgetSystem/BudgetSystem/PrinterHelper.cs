using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;

namespace BudgetSystem
{
    public class PrinterHelper
    {
        public static void Print(EnumFlowDataType dataType,int dataID,bool needPre=true )
        {
            //查询对象，并打印
        
        }


        public static void Print(object data, bool needPre = true)
        {
            if (data is Budget)
            {
                PrintBudget(data as Budget,needPre);
            }
        
        
        
        }

        public static void PrintBudget(Budget budget, bool needPre = true)
        { 
        
        }


    }
}
