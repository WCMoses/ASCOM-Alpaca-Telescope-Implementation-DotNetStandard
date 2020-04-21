using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class canslewasyncController : ApiController
    {
        private string methodName = nameof(canslewasyncController).Substring(0, nameof(canslewasyncController).IndexOf("Controller"));

        // GET: api/CanSlew
        [HttpGet]
        public BoolResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSlewAsync = MyGlobals.Telescope.CanSlewAsync;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", CanSlewAsync.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSlewAsync);
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
