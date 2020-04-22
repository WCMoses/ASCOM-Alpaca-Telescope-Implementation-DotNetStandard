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
     
    public class pulseguideController : ApiController
    {
        private string methodName = nameof(pulseguideController).Substring(0, nameof(pulseguideController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] PulseGuideRequest request)
        {
             //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.PulseGuide(request.Direction,request.Duration);

            return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
        }
    }

    public class PulseGuideRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public ASCOM.DeviceInterface.GuideDirections Direction { get; set; }
        public int Duration { get; set; }
    }
}