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
        public MethodResponse Put([FromBody] UnParkRequest request)
        {
            try
            {
            MyGlobals.Telescope.Unpark();
            return new MethodResponse(request.ClientTransactionID, request. ClientID, methodName);
            }
            catch (Exception ex)
            {

                var resp = new MethodResponse(request.ClientID, request.ClientTransactionID, methodName);
                resp.ErrorMessage = ex.Message;
                resp.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return resp;

            }

        }
    }

    public class UnParkRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
    }
}