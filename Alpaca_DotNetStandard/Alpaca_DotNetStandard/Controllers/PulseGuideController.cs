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
        public MethodResponse Put(int ClientID, int ClientTransactionID,   ASCOM.DeviceInterface.GuideDirections Direction,   int Duration)
        {
             //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.PulseGuide(Direction,Duration);

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}