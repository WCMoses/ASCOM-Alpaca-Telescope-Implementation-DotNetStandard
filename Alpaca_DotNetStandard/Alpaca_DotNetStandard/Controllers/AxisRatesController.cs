using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;
using ASCOM.DeviceInterface;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]

    public class axisratesController : ApiController
    {
        private string methodName = nameof(axisratesController).Substring(0, nameof(axisratesController).IndexOf("Controller"));

        [HttpGet]
        public AxisRatesResponse Get(int ClientID, int ClientTransactionID, int Axis)
        {

            try
            {
                TelescopeAxes axis = TelescopeAxes.axisPrimary;
                if (Axis == 1)
                {
                    axis = TelescopeAxes.axisSecondary;
                }
                if (Axis == 2)
                {
                    axis = TelescopeAxes.axisTertiary;
                }
                //AxisRatesResponse result = MyGlobals.Telescope.AxisRates(axis);
                //
                //

                //dynamic deviceResponse = null;
                var deviceResponse = MyGlobals.Telescope.AxisRates(axis);

                List<RateResponse> rateResponse = new List<RateResponse>();

                                Type myType = null;
                IList<PropertyInfo> props = null;
                double max = 0;
                double min = 0;
                foreach (dynamic item in deviceResponse)
                {
                    myType = item.GetType();
                    props = new List<PropertyInfo>(myType.GetProperties());
                    foreach (PropertyInfo prop in props)
                    {
                        min = 0; max = 0;
                        Console.WriteLine(  "Property: " + prop.Name);
                        if (prop.Name == "Maximum")
                        {
                            max = prop.GetValue(item);
                        }
                        if (prop.Name == "Minimum")
                        {
                            min = prop.GetValue(item);
                        }
                    }
                                        
                    rateResponse.Add(new RateResponse(min, max));
                }

                //
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", result.ToString());

                return new AxisRatesResponse(ClientTransactionID, ClientID, methodName, rateResponse);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                AxisRatesResponse response = new AxisRatesResponse(ClientTransactionID, ClientID, method: methodName, null);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

    }
    public class AxisRatesRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public int Axis { get; set; }
    }
}