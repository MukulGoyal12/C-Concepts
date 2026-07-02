internal class Shelves:Furniture
{
    internal int NoOfShelves{get;set;}

     public override void Accept()
    {
        base.Accept();
        Console.WriteLine("Enter Shelves:");
        NoOfShelves=int.Parse(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Shelves {NoOfShelves}");
    }
}