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

    public class declinationrateController : ApiController
    {
        private string methodName = nameof(declinationrateController).Substring(0, nameof(declinationrateController).IndexOf("Controller"));
        // GET: api/DeclinationRate
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double result = MyGlobals.Telescope.DeclinationRate;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, -1);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }


        // PUT: api/DeclinationRate/5
        [HttpPut]
        public MethodResponse Put([FromBody] DeclinationRateRequest request)
        {
            try
            {
                MyGlobals.Telescope.DeclinationRate = request.DeclinationRate;
                return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex)
            {

                MethodResponse response = new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }

        }


    }
    public class DeclinationRateRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public double DeclinationRate { get; set; }
    }
}
