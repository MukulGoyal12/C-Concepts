using System.Threading.Tasks;
using System;
using System.Collections.Generic;
 
 
namespace RealEstate{
    internal class Property{
        int _id;
        string _name;
        float _area;
        internal void Accept(){
            Console.WriteLine("Enter id");
            _id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter are(sqft)");
            _name=Console.ReadLine();
            Console.WriteLine("Enter area(sqft)");
            _area=Convert.ToSingle(Console.ReadLine());
 
 
        }
 
        internal void display(){
            Console.WriteLine($"id:{_id},Name:{_name},Area:{_area}");
 
        }
    }
}