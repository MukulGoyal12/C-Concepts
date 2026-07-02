using System;
using System.Collections.Generic;
using System.Text;

namespace Single_Responsibility
{
    internal class ShoppingCart
    {

        //In this , unnecessary classes are there, and it voilates Single Responsibility principle , so we move related methods to related classes.
        public int CalculatePrice()
        {
            //price code
            return 0;
        }

        //public void CartInvoicePrinter()
        //{
        //    //code
        //}

        //public void SaveToDB()
        //{
        //    //code
        //}
    }
}
