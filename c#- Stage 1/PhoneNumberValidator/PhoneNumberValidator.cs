using System.Globalization;

internal class PhoneNumberValidator
{
    internal string Number{get;set;}

    public void getInput()
    {
        Console.WriteLine("Enter Phone Number");
        Number=Console.ReadLine();
    }

    public bool Check(string Number)
    {
        string[] num=Number.Split('-');
        int n=0;
        foreach(string nums in num)
        {
            n+=nums.Length;
        }

        if (n!=10 || string.IsNullOrEmpty(Number) || !Number.All(ch=>char.IsDigit(ch) || ch=='-'))
        {
            return false;
        }

        return true;
    }

    public void Validate()
    {
        if (Check(Number))
        {
            Console.WriteLine("Valid");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}