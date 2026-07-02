internal abstract class Temprature
{
    internal int Temp{get;set;}

    public void Accept()
    {
        Console.WriteLine("Enter the temperature value.");
        Temp=int.Parse(Console.ReadLine());
    }

    public abstract void Display();
}