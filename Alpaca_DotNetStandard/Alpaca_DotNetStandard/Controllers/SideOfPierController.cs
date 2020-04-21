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
     
    public class sideofpierController : ApiController
    {
        private string methodName = nameof(sideofpierController).Substring(0, nameof(sideofpierController).IndexOf("Controller"));
        // GET: api/SideOfPier
        [HttpGet]
        public PierSideResponse Get(int ClientID, int ClientTransactionID)
        {
           try
            {
                var result = MyGlobals.Telescope.SideOfPier;
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new PierSideResponse(ClientTransactionID, ClientID,result);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new PierSideResponse(ClientTransactionID, ClientID,PierSide.pierUnknown);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }


        // PUT: api/SideOfPier/5
        [HttpPut]
        public PierSideResponse Put(int ClientID, int ClientTransactionID,   ASCOM.DeviceInterface.PierSide SideOfPier)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.SideOfPier = SideOfPier;

            return new PierSideResponse(ClientTransactionID, ClientID, SideOfPier);
        }


    }
}
