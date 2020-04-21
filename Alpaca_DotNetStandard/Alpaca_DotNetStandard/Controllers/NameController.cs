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
     
    public class nameController : ApiController
    {
        private string methodName = nameof(nameController).Substring(0, nameof(nameController).IndexOf("Controller"));

        [HttpGet()]
        public StringResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                string name = MyGlobals.Telescope.Name;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", name);
                return new StringResponse(ClientTransactionID, ClientID, methodName, name);
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
