namespace Bank_Library
{
    public delegate double InterestDelegate(double balance);
    public class Bank_Account
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        public void Accept()
        {
        }

        public double UpdateBalance(InterestDelegate ic)
        {
            Balance = Balance + ic(Balance);
            return Balance;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}


