using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate
{
    internal class Flat:Building,IRentCalculator
    {
        public int FlatNo { get; set; }

        public int calculateRent()
        {
            return 100;
        }
    }
}
