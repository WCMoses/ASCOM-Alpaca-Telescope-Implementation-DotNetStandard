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
     
    public class unparkController : ApiController
    {
        private string methodName = nameof(unparkController).Substring(0, nameof(unparkController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put( int ClientID,int ClientTransactionID)
        {
            MyGlobals.Telescope.Unpark();
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}