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

    public class sitelongitudeController : ApiController
    {
        private string methodName = nameof(sitelongitudeController).Substring(0, nameof(sitelongitudeController).IndexOf("Controller"));
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = MyGlobals.Telescope.SiteLongitude;
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
        public MethodResponse Put([FromBody] SiteLongitudeRequest request)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            try
            {
                MyGlobals.Telescope.SiteLongitude = request.SiteLongitude;
                return new MethodResponse(request.ClientTransactionID, request.ClientID, request.SiteLongitude.ToString());

            }
            catch (Exception ex)
            {

                var response = new MethodResponse();
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                response.ClientTransactionID = request.ClientTransactionID;
                return response;
            }

        }
    }
    public class SiteLongitudeRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public int SiteLongitude { get; set; }
    }
}