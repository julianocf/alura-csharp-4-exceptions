using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class FinancialTransactionException : Exception
    {
        public FinancialTransactionException()
        {

        }
        public FinancialTransactionException(string message)
            : base(message)
        {
            
        }
        public FinancialTransactionException(string message, Exception internalException)
            : base(message, internalException)
        {

        }
    }
}
