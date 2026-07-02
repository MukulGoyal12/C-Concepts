using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate
{
    internal class CalculateRent
    {
        public int calculateRent(IRentCalculator rc)
        {
            return rc.calculateRent();
        }
    }
}
