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
     
    public class guideratedeclinationController : ApiController
    {
        private string methodName = nameof(guideratedeclinationController).Substring(0, nameof(guideratedeclinationController).IndexOf("Controller"));
        // GET: api/GuideRateDeclination

        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = MyGlobals.Telescope.GuideRateDeclination;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", "");

                return new DoubleResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        [HttpPut]
        public MethodResponse Put([FromBody] GuideRateDeclinationRequest request)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", "");
            MyGlobals.Telescope.GuideRateDeclination = request.GuideRateDeclination;

            return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
        }

    }
    public class GuideRateDeclinationRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public double GuideRateDeclination { get; set; }
    }
}
