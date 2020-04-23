using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;
using Alpaca_Telescope_DotNetStandard;
using ASCOM.DeviceInterface;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]

    public class moveaxisController : ApiController
    {
        private string methodName = nameof(moveaxisController).Substring(0, nameof(moveaxisController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] MoveAxisRequest request)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " PUT", "");
                TelescopeAxes axis = TelescopeAxes.axisPrimary;
 
                if (request.Axis == 2)
                {
                    axis = TelescopeAxes.axisSecondary;
                }
                if (request.Axis == 3)
                {
                    axis = TelescopeAxes.axisTertiary;
                }
                MyGlobals.Telescope.MoveAxis(axis, request.Rate);

                return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex)
            {

                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }

        }
    }

    public class MoveAxisRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public int Axis { get; set; }
        public double Rate { get; set; }
    }
}
