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
     
    public class trackingrateController : ApiController
    {
        private string methodName = nameof(trackingrateController).Substring(0, nameof(trackingrateController).IndexOf("Controller"));
        // GET: api/DeclinationRate
        [HttpGet]
        public IntResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            { //TODO: Casting to int
                var result = MyGlobals.Telescope.TrackingRate;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new IntResponse(ClientTransactionID, ClientID, methodName, (int)result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                IntResponse response = new IntResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        [HttpPut]
        public MethodResponse Put([FromBody] TrackingRateRequest request)
        {
            try
            {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.TrackingRate = request.TrackingRate;
            return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex )
            {

                var response = new MethodResponse();
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                response.ClientTransactionID = request.ClientTransactionID;
                return response; ;
            }

        }

    }
    public class TrackingRateRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public ASCOM.DeviceInterface.DriveRates TrackingRate { get; set; }
    }
}