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
     
    public class synctoaltazController : ApiController
    {
        private string methodName = nameof(synctoaltazController).Substring(0, nameof(synctoaltazController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID,   double Altitude,   double Azimuth)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.SyncToAltAz(Azimuth, Altitude);
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}