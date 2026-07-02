using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnected.Miscellaneous;
    internal class Menu
    {

        public static void Main(String[] args)
    {
        ShowMenu();
    }
        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t Welcome to Product Management");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t ================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t 1.Add 2.Display 3.Update 4.Delete 5.Save 6.Exit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t -----------------------------------------");
        }
    }
