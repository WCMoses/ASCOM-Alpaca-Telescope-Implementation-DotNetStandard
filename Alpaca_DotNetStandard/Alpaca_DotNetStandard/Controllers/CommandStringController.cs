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
     
    public class commandstringController : ApiController
    {
        private string methodName = nameof(commandstringController).Substring(0, nameof(commandstringController).IndexOf("Controller"));

        [HttpPut()]
        public StringResponse Put(int ClientID, int ClientTransactionID,   string Command,   bool Raw)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0}, Parameters: {1}", Command, Raw));
                string response = MyGlobals.Telescope.CommandString(Command, Raw);
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0} completed OK", Command));
                return new StringResponse(ClientTransactionID, ClientID, methodName, response);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                StringResponse response = new StringResponse(ClientTransactionID, ClientID, methodName, "");
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
