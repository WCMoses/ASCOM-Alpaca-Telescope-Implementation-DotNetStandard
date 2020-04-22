//using System;
//using System.Collections.Generic;
//using ASCOM.DeviceInterface;

using ASCOM.DeviceInterface;
using System.Collections.Generic;

namespace Alpaca_Telescope_DotNetStandard
{
    public class TrackingRatesResponse : RestResponseBase
    {
        private List<DriveRates> rates;

        public TrackingRatesResponse() { }

        public TrackingRatesResponse(int clientTransactionID, int transactionID, string method)
        {
            base.ServerTransactionID = transactionID;
            base.ClientTransactionID = clientTransactionID;
           
        }
        public ITrackingRates Value { get; set; }

        public List<DriveRates> Rates
        {
            get => rates;
            set { rates = value; }
        }
    }
}
