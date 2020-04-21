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
        public MethodResponse Put(int ClientID, int ClientTransactionID,   TelescopeAxes axis,   double rate)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " PUT", "");
            MyGlobals.Telescope.MoveAxis(axis,rate); 

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
        }
    }
