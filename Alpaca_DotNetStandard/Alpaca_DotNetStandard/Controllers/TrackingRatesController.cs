using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_DotNetStandard.Controllers
{
    public class trackingratesController : ApiController
    {
        private string methodName = nameof(trackingratesController).Substring(0, nameof(trackingratesController).IndexOf("Controller"));

        [HttpGet]
        public TrackingRatesResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            { //TODO: Casting to int
                var result = MyGlobals.Telescope.TrackingRates;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                var resp = new TrackingRatesResponse(ClientTransactionID, ClientID, methodName);
                resp.Value = result;
                return resp;
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                TrackingRatesResponse response = new TrackingRatesResponse(ClientTransactionID, ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
