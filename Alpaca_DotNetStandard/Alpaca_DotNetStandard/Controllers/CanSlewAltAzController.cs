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
     
    public class canslewaltazController : ApiController
    {
        private string methodName = nameof(canslewaltazController).Substring(0, nameof(canslewaltazController).IndexOf("Controller"));

        // GET: api/CanSlewAltAz
        [HttpGet]
        public BoolResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetAltAz = MyGlobals.Telescope.CanSlewAltAz;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", CanSetAltAz.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetAltAz);
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
