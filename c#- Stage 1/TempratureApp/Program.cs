internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Centigrade to Farenheit 2. Farenheit to Centigrade");
        int choice = int.Parse(Console.ReadLine());
        Temprature t=null;
        switch (choice)
        {
            case 1:
                t=new CTF();
                break;
            case 2:
                t=new FTC();
                break;
            default:
                break;
        }

        t.Accept();
        t.Display();
    }
}