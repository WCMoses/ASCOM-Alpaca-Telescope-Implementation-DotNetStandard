﻿using System;

namespace Alpaca_Telescope_DotNetStandard
{
    public class ShortResponse : RestResponseBase
    {
        public ShortResponse() { }

        public ShortResponse(int clientTransactionID, int transactionID, string method, short value)
        {
            base.ServerTransactionID = transactionID;
            base.ClientTransactionID = clientTransactionID;
            Value = value;
        }

        public short Value { get; set; }
    }
}
