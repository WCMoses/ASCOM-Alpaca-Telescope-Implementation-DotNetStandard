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
     
    public class connectedController : ApiController
    {
        private string methodName = nameof(connectedController).Substring(0, nameof(connectedController).IndexOf("Controller"));

        [HttpGet()]
        public BoolResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool connected = MyGlobals.Telescope.Connected;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", connected.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, connected);
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

        [HttpPut()]
        public MethodResponse Put(int ClientID, int ClientTransactionID, bool Connected)
        {
            try
            {
                MyGlobals.Telescope.Connected = Connected;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Set", string.Format("Connected set {0} OK", Connected));
                return new MethodResponse(ClientTransactionID, ClientID, methodName);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Set", string.Format("Exception when setting {0} {1} {2}", methodName, Connected, ex.ToString()));
                MethodResponse response = new MethodResponse(ClientTransactionID, ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
