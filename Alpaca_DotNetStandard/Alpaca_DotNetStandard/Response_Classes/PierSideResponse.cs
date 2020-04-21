using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;

namespace Alpaca_Telescope_DotNetStandard
{
    public class PierSideResponse : RestResponseBase
    {
         public double Declination { get; set; }
         public double RightAscension { get; set; }
         public PierSide PierSide { get; set; }

         public PierSideResponse()
         {
         }

         public PierSideResponse(int clientTransactionID, int transactionID,PierSide side)
         {
             base.ServerTransactionID = transactionID;
             base.ClientTransactionID = clientTransactionID;
             PierSide = side;
         }


         public PierSideResponse(int clientTransactionID, int transactionID, double declination, double RA)
         {
             base.ServerTransactionID = transactionID;
             base.ClientTransactionID = clientTransactionID;
             Declination = declination;
             RightAscension = RA;
             
         }
    }
}
