﻿using System;

namespace Alpaca_Telescope_DotNetStandard
{
    public class DoubleArray2DResponse : ImageArrayResponseBase
    {
        private double[,] doubleArray2D;

        private const int RANK = 2;
        private const ResponseTypes.ImageArrayElementTypes TYPE = ResponseTypes.ImageArrayElementTypes.Double;

        public DoubleArray2DResponse(int clientTransactionID, int transactionID, string method, double[,] value)
        {
            base.ServerTransactionID = transactionID;
            doubleArray2D = value;
            base.Type = (int)TYPE;
            base.Rank = RANK;
            base.ClientTransactionID = clientTransactionID;
        }

        public double[,] Value
        {
            get { return doubleArray2D; }
            set
            {
                doubleArray2D = value;
                base.Type = (int)TYPE;
                base.Rank = RANK;
            }
        }
    }
}
