using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;
using ASCOM.DeviceInterface;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
  //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class axisratesController : ApiController
    {
        private string methodName = nameof(axisratesController).Substring(0, nameof(axisratesController).IndexOf("Controller"));

        [HttpGet]
        public AxisRatesResponse Get([FromBody] AxisRatesRequest request)
        {

            try
            {  //TODO: Return real value
                var result = MyGlobals.Telescope.AxisRates(request.Axis);
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());

                return new AxisRatesResponse(request.ClientTransactionID, request.ClientID, methodName,null);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                AxisRatesResponse response = new AxisRatesResponse(request.ClientTransactionID, request.ClientID, method:methodName,null);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

    }
    public class AxisRatesRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public TelescopeAxes Axis { get; set; }
    }
}