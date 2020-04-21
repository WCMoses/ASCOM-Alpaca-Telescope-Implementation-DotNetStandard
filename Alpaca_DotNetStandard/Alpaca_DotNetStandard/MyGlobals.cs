using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASCOM;
using ASCOM.Utilities;
using ASCOM;

namespace Alpaca_Telescope_DotNetStandard
{
    public static  class MyGlobals
    {
        public static  int ASCOM_ERROR_NUMBER_OFFSET = unchecked((int)0x80040000);
        public static ASCOM.DeviceInterface.ITelescopeV3 Telescope = new ASCOM.DriverAccess.Telescope("ASCOM.Simulator.Telescope");
        public static TraceLogger TraceLogger;
    }
}