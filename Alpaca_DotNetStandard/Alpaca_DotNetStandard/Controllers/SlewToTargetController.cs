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

    public class slewtotargetController : ApiController
    {
        private string methodName = nameof(slewtotargetController).Substring(0, nameof(slewtotargetController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] SlewtoTargetRequest request)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
                MyGlobals.Telescope.SlewToTarget();
                return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex )
            {

                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", string.Format("Exception: {0}", ex.ToString()));
                var response = new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }

        }
    }

    public class SlewtoTargetRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
    }
}