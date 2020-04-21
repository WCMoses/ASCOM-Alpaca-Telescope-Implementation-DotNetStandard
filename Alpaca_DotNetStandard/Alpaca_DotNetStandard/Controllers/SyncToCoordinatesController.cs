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
     
    public class synctocoordinatesController : ApiController
    {
        private string methodName = nameof(synctocoordinatesController).Substring(0, nameof(synctocoordinatesController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID,   double RightAscension,   double Declination)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.SyncToCoordinates(RightAscension, Declination);
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}