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
     
    public class azimuthController : ApiController
    {
        private string methodName = nameof(azimuthController).Substring(0, nameof(azimuthController).IndexOf("Controller"));

        // GET: api/Azimuth
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double az =MyGlobals.Telescope.Azimuth;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", az.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, az);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult -MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

    }
}
