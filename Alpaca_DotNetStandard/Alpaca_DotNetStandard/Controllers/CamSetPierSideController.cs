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
     
    public class cansetpiersideController : ApiController
    {
        private string methodName = nameof(cansetpiersideController).Substring(0, nameof(cansetpiersideController).IndexOf("Controller"));

        // GET: api/CamSetPierSide
        [HttpGet]
        public BoolResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetPier = MyGlobals.Telescope.CanSetPierSide;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", CanSetPier.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetPier);
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


    }
}
