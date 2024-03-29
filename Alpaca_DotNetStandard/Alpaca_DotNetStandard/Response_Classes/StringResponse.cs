﻿using System;

namespace Alpaca_Telescope_DotNetStandard
{
    public class StringResponse : RestResponseBase
    {
        public StringResponse() { }

        public StringResponse(int clientTransactionID, int transactionID, string method, string value)
        {
            base.ServerTransactionID = transactionID;
            base.ClientTransactionID = clientTransactionID;
            Value = value;
        }

        public string Value { get; set; }
    }
}
