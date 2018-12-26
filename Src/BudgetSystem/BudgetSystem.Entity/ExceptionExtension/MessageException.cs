using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class MessageException : Exception
    {
        private string message;

        public override string Message
        {
            get
            {
                return this.message;
            }
        }

        public MessageException()
        {

        }

        public MessageException(string message)
            : this()
        {
            this.message = message;
        }
    }
}
