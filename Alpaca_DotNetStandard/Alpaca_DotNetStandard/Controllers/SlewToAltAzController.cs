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

    public class slewtoaltazController : ApiController
    {
        private string methodName = nameof(slewtoaltazController).Substring(0, nameof(slewtoaltazController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] SlewToAltAzRequest request)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
                MyGlobals.Telescope.SlewToAltAz(request.Azimuth, request.Altitude);
                return new MethodResponse(request.ClientTransactionID, request.ClientID, "SlewToAltAz");
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;

            }


        }
    }

    public class SlewToAltAzRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public double Altitude { get; set; }
        public double Azimuth { get; set; }
    }
}