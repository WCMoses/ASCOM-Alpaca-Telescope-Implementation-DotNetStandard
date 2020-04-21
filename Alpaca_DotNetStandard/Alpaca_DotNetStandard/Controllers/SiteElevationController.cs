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
     
    public class siteelevationController : ApiController
    {
        private string methodName = nameof(siteelevationController).Substring(0, nameof(siteelevationController).IndexOf("Controller"));
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = MyGlobals.Telescope.SiteElevation;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", "");

                return new DoubleResponse(ClientTransactionID, ClientID, methodName,result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new DoubleResponse(ClientTransactionID, ClientID, methodName,0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }


        // PUT: api/DeclinationRate/5
        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID,   int SiteElevation)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}