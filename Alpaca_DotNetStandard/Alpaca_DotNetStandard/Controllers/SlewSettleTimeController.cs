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

    public class slewsettletimeController : ApiController
    {
        private string methodName = nameof(slewsettletimeController).Substring(0, nameof(slewsettletimeController).IndexOf("Controller"));

        [HttpGet]
        public IntResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = MyGlobals.Telescope.SlewSettleTime;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", "");

                return new IntResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new IntResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        [HttpPut]
        public MethodResponse Put([FromBody] SlewSettleTimeRequest request)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            try
            {
                MyGlobals.Telescope.SlewSettleTime = request.SlewSettleTime;

                return new MethodResponse(request.ClientTransactionID, request.ClientID, request.SlewSettleTime.ToString());

            }
            catch (Exception ex )
            {

                var response = new MethodResponse();
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                response.ClientTransactionID = request.ClientTransactionID;
                return response;
            }

        }
    }
    public class SlewSettleTimeRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public short SlewSettleTime { get; set; }
    }
}