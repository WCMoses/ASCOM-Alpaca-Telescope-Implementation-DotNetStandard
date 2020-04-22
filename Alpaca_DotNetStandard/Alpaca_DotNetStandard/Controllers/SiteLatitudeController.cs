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
     
    public class sitelatitudeController : ApiController
    {
        private string methodName = nameof(sitelatitudeController).Substring(0, nameof(sitelatitudeController).IndexOf("Controller"));
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = MyGlobals.Telescope.SiteLatitude;
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
        public MethodResponse Put([FromBody] SiteLatitudeRequest request)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            try
            {
            MyGlobals.Telescope.SiteLatitude = request.SiteLatitude;
            return new MethodResponse(request.ClientTransactionID, request.ClientID, request.SiteLatitude.ToString());

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
    public class SiteLatitudeRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public int SiteLatitude { get; set; }
    }
}