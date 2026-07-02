using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace ICICIBankApp
{
    internal class IciciInterest :IInterest
    {
        public double Calculate(double balance)
        {
            return (balance * .13) / 365;
        }
    }
}
//2025