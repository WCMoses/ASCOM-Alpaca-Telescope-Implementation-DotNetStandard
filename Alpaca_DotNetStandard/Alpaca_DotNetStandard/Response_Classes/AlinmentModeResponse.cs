using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;

namespace Alpaca_Telescope_DotNetStandard
{
    public class AlignmentModeResponse : RestResponseBase
    {
        public AlignmentModes Value { get; set; }

        public AlignmentModeResponse(int clientTransactionID, int transactionID, string method, AlignmentModes value)
        {
            base.ServerTransactionID = transactionID;
            base.ClientTransactionID = clientTransactionID;
            Value = value;
        }

    }
}
