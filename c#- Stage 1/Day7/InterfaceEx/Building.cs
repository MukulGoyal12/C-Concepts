using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceTopDownApproach
{
    interface Building
    {
        public static int cnt = 0;   //static methods and fields are also not inherited and override
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        void Accept();     //By default public
        void Display()     //Interface default Methods.These functions can not inherited but can override.
        {
            Console.WriteLine(Id + Name + Area);
        }

        public static void Increment
        {
            cnt++;
        }
    }
}
