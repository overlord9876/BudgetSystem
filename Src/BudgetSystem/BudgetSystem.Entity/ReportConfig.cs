using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{

    public class ReportConfig
    {
        public string Name { get; set; }
        public string FileName { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

   
}
