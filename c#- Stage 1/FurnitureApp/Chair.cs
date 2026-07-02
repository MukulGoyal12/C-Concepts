internal class Chair:Furniture
{
    internal int NoOfLegs{get;set;}

    public override void Accept()
    {
        base.Accept();
        Console.WriteLine("Enter Legs:");
        NoOfLegs=int.Parse(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Legs: {NoOfLegs}");
    }
}