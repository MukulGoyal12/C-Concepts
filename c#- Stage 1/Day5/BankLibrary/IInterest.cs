using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public interface IInterest   //abstract 
    {
        public double Calculate(double balance); //abstract method -- method without body
    }
}