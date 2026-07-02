using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace SBIApp
{
    internal class SBIInterest : IInterest
    {
        public double Calculate(double balance)
        {
            return (balance * .08) / 4;
        }
    }
}
