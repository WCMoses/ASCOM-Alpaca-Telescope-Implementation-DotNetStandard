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
     
    public class slewtoaltazasyncController : ApiController
    {
        private string methodName = nameof(slewtoaltazasyncController).Substring(0, nameof(slewtoaltazasyncController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID,   double Altitude,   double Azimuth)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.SlewToAltAzAsync(Azimuth,Altitude);

            return new MethodResponse(ClientTransactionID, ClientID, "SlewToAltAzAsync");

        }
    }
}