using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsDemo
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} Name:{Name} Price:{Price}";
        }

        //public partial int MyMethod()  Availale sdk 10 onwards
        //{

        //}

    }
}
