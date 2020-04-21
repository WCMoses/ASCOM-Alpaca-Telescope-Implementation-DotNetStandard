using Alpaca_Telescope_DotNetStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Alpaca_DotNetStandard.Controllers
{
    public class canslewaltazasyncController : ApiController
    {
        private string methodName = nameof(canslewaltazasyncController).Substring(0, nameof(canslewaltazasyncController).IndexOf("Controller"));

        // GET: api/CanSlewAltAz
        [HttpGet]
        public BoolResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetAltAzAsync = MyGlobals.Telescope.CanSlewAltAzAsync;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", CanSetAltAz.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetAltAzAsync);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                BoolResponse response = new BoolResponse(ClientTransactionID, ClientID, methodName, false);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
