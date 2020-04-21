using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alpaca_Telescope_DotNetStandard
{
    public abstract class RestResponseBase
    {
        public int ClientTransactionID { get; set; }
        public int ServerTransactionID { get; set; }
        public int ErrorNumber { get; set; } = 0;
        public string ErrorMessage { get; set; } = "";
    }
}
