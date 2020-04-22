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
     
    public class doesrefractionController : ApiController
    {
        private string methodName = nameof(doesrefractionController).Substring(0, nameof(doesrefractionController).IndexOf("Controller"));

        // GET: api/DoesRefraction
        [HttpGet]
        public BoolResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool result = MyGlobals.Telescope.DoesRefraction;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                BoolResponse response = new BoolResponse(ClientTransactionID, ClientID, methodName, false);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        [HttpPut]
        public MethodResponse Put([FromBody] DoesRefractionRequest request)
        {
            MyGlobals.Telescope.DoesRefraction = request.DoesRefraction;
            return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
        }

    }
    public class DoesRefractionRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public bool DoesRefraction { get; set; }
    }
}
