using static System.Console;
namespace BankLibrary
{
    public class BankAccount
    {
        public string AccountNo {  get; set; }
        public string CustomerName {  get; set; }
        public double Balance {  get; set; }
        public BankAccount() { }
        public BankAccount(string accountNo, string customerName, double balance)
        {
            AccountNo = accountNo;
            CustomerName = customerName;
            Balance = balance;
        }
        public void Accept()
        {
            Write("AccountNo:");
            AccountNo = ReadLine();
            Write("Name:");
            CustomerName = ReadLine();
            Write("OpeningBalance:");
            Balance = double.Parse(ReadLine());

        }
        public override string ToString()
        {
            return $"AccountNo: {AccountNo} Name: {CustomerName} Balance: {Balance}";
        }

        public double UpdateBalance(IInterest i)
        {
            return Balance = Balance + i.Calculate(Balance);
        }
    }
}