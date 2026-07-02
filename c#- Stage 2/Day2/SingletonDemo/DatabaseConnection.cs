using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonDemo
{
    internal class DatabaseConnection
    {
        //static member class se belong karta hai, object se nahi means kitne bhi objects banao(ya na banao),instance sirf EK hi rahega

        static DatabaseConnection Instance= new DatabaseConnection();
        private DatabaseConnection() { }
        public void Open()
        {
            //Establising connection to database
        }

        //User ko instance to chahie hi ab const private h to ye krna pdega
        public static DatabaseConnection GetInstance()
        {
            return GetInstance();
        }

    }
}


//public class FerrariP5
//{
//    static FerrariP5 instance = new FerrariP5();

//    FerrariP5()
//    {
//        Console.WriteLine("Car created for you.");
//    }

//    public static FerrariP5 getInstance()
//    {
//        return instance;
//    }
//}