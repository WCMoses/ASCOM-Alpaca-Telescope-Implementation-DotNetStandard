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
     
    public class parkController : ApiController
    {
        private string methodName = nameof(parkController).Substring(0, nameof(parkController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] ParkRequest request)
        {
            try
            {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.Park();

            return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex )
            {

                var resp = new MethodResponse(request.ClientID, request.ClientTransactionID, methodName);
                resp.ErrorMessage = ex.Message;
                resp.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return resp;
            }

        
        }
    }

    public class ParkRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
    }
}