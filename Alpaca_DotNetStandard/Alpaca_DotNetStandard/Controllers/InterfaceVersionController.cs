using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{id}/[controller]")]
     
    public class interfaceversionController : ApiController
    {
        private string methodName = nameof(interfaceversionController).Substring(0, nameof(interfaceversionController).IndexOf("Controller"));

        [HttpGet()]
        public ShortResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                short interfaceVersion = MyGlobals.Telescope.InterfaceVersion;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", interfaceVersion.ToString());
                var response = new ShortResponse(ClientTransactionID, ClientID, methodName, interfaceVersion);
                return response;
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new ShortResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage= ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
