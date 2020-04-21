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
     
    public class commandboolController : ApiController
    {
        private string methodName = nameof(commandboolController).Substring(0, nameof(commandboolController).IndexOf("Controller"));

        [HttpPut()]
        public BoolResponse Put(int ClientID, int ClientTransactionID,   string Command,   bool Raw)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0}, Parameters: {1}", Command, Raw));
                bool response = MyGlobals.Telescope.CommandBool(Command, Raw);
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0} completed OK", Command));
                return new BoolResponse(ClientTransactionID, ClientID, methodName, response);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                BoolResponse response = new BoolResponse(ClientTransactionID, ClientID, methodName, false);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
