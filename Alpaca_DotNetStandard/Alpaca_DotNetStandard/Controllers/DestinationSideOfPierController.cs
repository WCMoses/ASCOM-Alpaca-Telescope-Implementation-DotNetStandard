using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;
using ASCOM.DeviceInterface;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class destinationsideofpierController : ApiController
    {
        private string methodName = nameof(destinationsideofpierController).Substring(0, nameof(destinationsideofpierController).IndexOf("Controller"));

        [HttpGet]
        public PierSideResponse Get(int ClientID, int ClientTransactionID, double RightAscension, double Declination)
        {
 try
            {
                PierSide result = MyGlobals.Telescope.DestinationSideOfPier(RightAscension, RightAscension);
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new PierSideResponse(ClientTransactionID, ClientID,result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                PierSideResponse response = new PierSideResponse(ClientTransactionID, ClientID, 0, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}