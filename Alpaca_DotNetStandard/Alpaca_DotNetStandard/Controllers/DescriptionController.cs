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
     
    public class descriptionController : ApiController
    {
        private string methodName = nameof(descriptionController).Substring(0, nameof(descriptionController).IndexOf("Controller"));

        //[HttpGet()]
        public StringResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                string description = MyGlobals.Telescope.Description;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", description);
                return new StringResponse(ClientTransactionID, ClientID, methodName, description);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                StringResponse response = new StringResponse(ClientTransactionID, ClientID, methodName, "");
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
