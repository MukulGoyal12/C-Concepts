internal class Program
{
    public static void Main(String[] args)
    {
        PhoneNumberValidator ph = new PhoneNumberValidator();
        ph.getInput();
        ph.Validate();
    }
}