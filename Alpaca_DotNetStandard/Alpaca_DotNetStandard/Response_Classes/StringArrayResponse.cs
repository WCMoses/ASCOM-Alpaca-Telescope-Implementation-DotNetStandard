﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca_Telescope_DotNetStandard
{
    public class StringArrayResponse : RestResponseBase
    {
        private string[] stringArray;

        public StringArrayResponse() { }

        public StringArrayResponse(int clientTransactionID, int transactionID, string method, string[] value)
        {
            base.ServerTransactionID = transactionID;
            stringArray = value;
            base.ClientTransactionID = clientTransactionID;
        }

        public string[] Value
        {
            get { return stringArray; }
            set { stringArray = value; }
        }
    }
}
