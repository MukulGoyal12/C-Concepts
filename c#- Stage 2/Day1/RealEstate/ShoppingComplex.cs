using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate
{
    internal class ShoppingComplex:Building,IRentCalculator
    {
        public int ShoppingFloor { get; set; }

        public int calculateRent()
        {
            return 500;
        }
    }
}
