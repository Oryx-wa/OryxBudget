using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebapi.Filters
{
    public class BudgetAppException : Exception
    {
        public BudgetAppException()
        { }

        public BudgetAppException(string message)
        : base(message)
    { }

        public BudgetAppException(string message, Exception innerException)
        : base(message, innerException)
    { }
    }
}
