using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers  
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class equatorialsystemController : ApiController
    {
        private string methodName = nameof(equatorialsystemController).Substring(0, nameof(equatorialsystemController).IndexOf("Controller"));
        // GET: api/EquatorialSystem
        [HttpGet]
        public IntResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", "");
                var result = MyGlobals.Telescope.EquatorialSystem;
                return new IntResponse(ClientTransactionID, ClientID, methodName,(int)result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new IntResponse(ClientTransactionID, ClientID, methodName,5);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }

        }


    }
}
