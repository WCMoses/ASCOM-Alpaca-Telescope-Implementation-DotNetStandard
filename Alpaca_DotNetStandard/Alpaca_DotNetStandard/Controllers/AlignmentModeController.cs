using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
   //[Route("apis/v1/telescope/{device_number}")]
     
    public class alignmentmodeController : ApiController
    {
        private string methodName = nameof(alignmentmodeController).Substring(0, nameof(alignmentmodeController).IndexOf("Controller"));

        
        [HttpGet]
        public AlignmentModeResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = MyGlobals.Telescope.AlignmentMode;
                ////MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new AlignmentModeResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new AlignmentModeResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}