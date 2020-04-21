using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
   //[Route("api/v1/telescope/{device_number}/[controller]")]

    public class abortslewController : ApiController
    {
        private string methodName = nameof(abortslewController).Substring(0, nameof(abortslewController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID)
        {
            try
            {
                ////MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("abort slew-try"));
                MyGlobals.Telescope.AbortSlew();
                ////MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0} completed OK", methodName));
                return new MethodResponse(ClientTransactionID, ClientID, methodName);
            }
            catch (Exception ex)
            {
                ////MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(ClientTransactionID, ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}