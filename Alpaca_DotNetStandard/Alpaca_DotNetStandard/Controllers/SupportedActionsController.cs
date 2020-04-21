using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class supportedactionsController : ApiController
    {
        private string methodName = nameof(supportedactionsController).Substring(0, nameof(supportedactionsController).IndexOf("Controller"));

        [HttpGet()]
        public StringListResponse Get(int ClientID, int ClientTransactionID)
        {

            try
            {
                List<string> resultStringArray = new List<string>();
                var result = MyGlobals.Telescope.SupportedActions;
                if (result != null)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        resultStringArray.Add(result[i].ToString());
                    }
                }

                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", resultStringArray.ToString());
                return new StringListResponse(ClientTransactionID, ClientID, methodName, resultStringArray);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName,
                   // string.Format("Exception calling {0}: {1}", methodName, ex.ToString()));
                StringListResponse response =
                    new StringListResponse(ClientTransactionID, ClientID, methodName, new List<string>());
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
