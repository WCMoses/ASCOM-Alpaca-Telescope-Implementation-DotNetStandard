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
     
    public class altitudeController : ApiController
    {
        private string methodName = nameof(altitudeController).Substring(0, nameof(altitudeController).IndexOf("Controller"));

        // GET: api/Altitude
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double altitude = MyGlobals.Telescope.Altitude;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", altitude.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, altitude);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }

}


