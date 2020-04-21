using System;

namespace Alpaca_Telescope_DotNetStandard
{
    public class IntResponse : RestResponseBase
    {
        public IntResponse() { }

        public IntResponse(int clientTransactionID, int transactionID, string method, int value)
        {
            base.ServerTransactionID = transactionID;
            base.ClientTransactionID = clientTransactionID;
            Value = value;
        }

        public int Value { get; set; }
    }
}
