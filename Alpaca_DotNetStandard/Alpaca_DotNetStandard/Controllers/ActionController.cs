using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;
using ASCOM.Utilities;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]

    public class ActionController : ApiController
    {
        private string methodName = nameof(ActionController).Substring(0, nameof(ActionController).IndexOf("Controller"));
        Util util = new Util();
        [HttpPut()]
        public MethodResponse Put(int ClientID, int ClientTransactionID,  string Action,  string Parameters)
        {
            try
            {
                string platformversion = util.PlatformVersion;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0}, Parameters: {1} - Platform version: {2}", Action, Parameters, platformversion));
                MyGlobals.Telescope.Action(Action, Parameters);
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0} completed OK", Action));
                return new MethodResponse(ClientTransactionID, ClientID, methodName);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(ClientTransactionID, ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
