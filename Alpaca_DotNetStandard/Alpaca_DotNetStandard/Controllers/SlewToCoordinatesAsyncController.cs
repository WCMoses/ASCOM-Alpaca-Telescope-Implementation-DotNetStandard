﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alpaca_Telescope_DotNetStandard;

namespace Alpaca_Telescope_DotNetStandard.Controllers
{
    //[Route("api/v1/telescope/{device_number}/[controller]")]
     
    public class slewtocoordinatesasyncController : ApiController
    {
        private string methodName = nameof(slewtocoordinatesasyncController).Substring(0, nameof(slewtocoordinatesasyncController).IndexOf("Controller"));

        [HttpPut]
        public MethodResponse Put([FromBody] SlewToCoordinatesAsyncRequest request)
        {
            try
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0}, Parameters: {1}", RightAscension, Declination));
                MyGlobals.Telescope.SlewToCoordinatesAsync(request.RightAscension, request.Declination);
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Command: {0} completed OK", methodName));
                return new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
            }
            catch (Exception ex)
            {
                //MyGlobals.Telescope.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(request.ClientTransactionID, request.ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - MyGlobals.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
    public class SlewToCoordinatesAsyncRequest
    {
        public int ClientID { get; set; }
        public int ClientTransactionID { get; set; }
        public double RightAscension { get; set; }
        public double Declination { get; set; }

    }
}