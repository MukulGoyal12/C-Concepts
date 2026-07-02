using System;
using System.Security.Principal;
using Bank_Library;

namespace DelegateEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Bank Account ka object banaya
            Bank_Account account = new Bank_Account() { AccountNo = 21544325, CustomerName = "Mukul" , Balance=200};

            // 2. Named Method use karke delegate pass karna
            // account.UpdateBalance(InterestCalculator);

            // 3. Lambda Expression use karke call karna (Modern Way)
            double balance = account.UpdateBalance((bal) =>
            {
                Console.WriteLine("Lambda calculation in progress...");
                return bal * 0.05; // Example: 5% interest logic
            });

            Console.WriteLine(balance);
        }

        // Static method jo delegate ke signature se match karta hai
        static double InterestCalculator(double b)
        {
            Console.WriteLine("Calculating interest via Named Method...");
            return b * 0.05;
        }
    }
}