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
     
    public class apertureareaController : ApiController
    {
        private string methodName = nameof(apertureareaController).Substring(0, nameof(apertureareaController).IndexOf("Controller"));

        // GET: api/ApertureArea
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double aperature = MyGlobals.Telescope.ApertureArea;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", aperature.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, aperature);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        
   

    

       
    }
}
