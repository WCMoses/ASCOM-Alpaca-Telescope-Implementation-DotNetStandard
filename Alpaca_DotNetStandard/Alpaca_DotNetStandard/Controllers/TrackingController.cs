using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class trackingController : ApiController
    {
        private string methodName = nameof(trackingController).Substring(0, nameof(trackingController).IndexOf("Controller"));
        //
        //[HttpPut]
        //public async Task<string> PostRawBufferManual()
        //{
        //    string result = await Request.Content.ReadAsStringAsync();
        //    return result;
        //}
        //
        [HttpGet]
        public BoolResponse Get( int ClientID, int ClientTransactionID)
        {
            try
            {
                bool result = MyGlobals.Telescope.Tracking;                
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return  new BoolResponse(ClientTransactionID, ClientID, methodName, result);
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
        public MethodResponse Put([FromBody] int ClientID, [FromBody] int ClientTransactionID, [FromBody]  bool Tracking)
        {
            //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Put", "");
            MyGlobals.Telescope.Tracking = Tracking;
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}