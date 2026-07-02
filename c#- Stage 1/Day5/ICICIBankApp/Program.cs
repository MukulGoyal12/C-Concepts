using BankLibrary;
using static  System.Console;
namespace ICICIBankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount iciciaccount = null;
            do
            {
                WriteLine("1.CreateAccount , 2.Withdrawal 3. Deposit 4. UpdateBalance 5.Exit");
             
                if (int.TryParse(ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            iciciaccount = new BankAccount();
                            iciciaccount.Accept();
                            break;
                        case 2:
                            if (iciciaccount != null)
                            {

                            }
                            else { WriteLine("Account Does Not Exists"); }
                            break;
                        case 4:
                            if (iciciaccount != null)
                            {
                                
                                iciciaccount.UpdateBalance(new IciciInterest());
                                WriteLine(iciciaccount);
                            }
                            else { WriteLine("Account Does Not Exists"); }
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }

            } while (true);

        }
    }
}
