using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceTopDownApproach
{
    internal class Flat : Building       //Kind of relationship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }

        //Implicit overriding method 
        //public void Accept()
        //{
        //    //Some code
        //}

        //explicit overriding method

        void Building.Accept()
        {
            //some code
        }

        public void Display()
        {
            Console.WriteLine("Flat Display");
        }
    }
}
