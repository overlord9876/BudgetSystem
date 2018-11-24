using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class VersionNumberException : Exception
    {
        private string message;

        public override string Message
        {
            get
            {
                return this.message;
            }
        }

        public VersionNumberException()
        {

        }

        public VersionNumberException(string message)
            : this()
        {
            this.message = message;
        }
    }
}
