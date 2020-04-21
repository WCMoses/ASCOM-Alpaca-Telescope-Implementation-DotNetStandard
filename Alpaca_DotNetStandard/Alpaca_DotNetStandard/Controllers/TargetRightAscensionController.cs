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
     
    public class targetrightascensionController : ApiController
    {
        private string methodName = nameof(targetrightascensionController).Substring(0, nameof(targetrightascensionController).IndexOf("Controller"));

        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double result = MyGlobals.Telescope.TargetRightAscension;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, result);
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

        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID,   double TargetRightAscension)
        {

            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.TargetRightAscension = TargetRightAscension;
            return new MethodResponse(ClientTransactionID, ClientID, methodName);

        }
    }
}