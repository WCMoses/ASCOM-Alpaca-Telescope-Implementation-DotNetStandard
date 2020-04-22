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
     
    public class slewtotargetasyncController : ApiController
    {
        private string methodName = nameof(slewtotargetasyncController).Substring(0, nameof(slewtotargetasyncController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] SlewtoTargetAsyncRequest request)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0}, Parameters: {1}", TargetRightAscension, TargetDeclination));
                MyGlobals.Telescope.SlewToCoordinatesAsync(request.TargetRightAscension, request.TargetDeclination);
                return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
            // return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }

    public class SlewtoTargetAsyncRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public double TargetRightAscension { get; set; }
        public double TargetDeclination { get; set; }
    }
}