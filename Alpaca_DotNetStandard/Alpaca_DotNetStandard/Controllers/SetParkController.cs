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
     
    public class setparkController : ApiController
    {
        private string methodName = nameof(setparkController).Substring(0, nameof(setparkController).IndexOf("Controller"));
        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.SetPark();

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}