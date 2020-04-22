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


        // PUT: api/DeclinationRate/5
        [HttpPut]
        public MethodResponse Put([FromBody] SiteElevationRequest request)
        {
            try
            {
                MyGlobals.Telescope.SiteElevation = request.SiteElevation;
                return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
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
    public class SiteElevationRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public int SiteElevation { get; set; }
    }
}