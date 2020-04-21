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
     
    public class utcdateController : ApiController
    {
        private string methodName =
            nameof(utcdateController).Substring(0, nameof(utcdateController).IndexOf("Controller"));

        [HttpGet]
        public DateTimeResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var response = MyGlobals.Telescope.UTCDate;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", response.ToString());
                return new DateTimeResponse(ClientTransactionID, ClientID, methodName, response);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new DateTimeResponse(ClientTransactionID, ClientID, methodName, DateTime.UtcNow);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;

            }

        }

       
        [HttpPut]
        public MethodResponse Put(int ClientID, int ClientTransactionID,   string dateTime)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            if (dateTime !=null)
            {
                 MyGlobals.Telescope.UTCDate = DateTime.Parse(dateTime);
            }
           
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }

    }
}
