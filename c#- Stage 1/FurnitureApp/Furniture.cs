internal abstract class Furniture
{
    internal int Id{get;set;}
    internal string Color{get;set;}
    internal string Name{get;set;}

    public virtual void Accept()
    {
        Console.WriteLine("Enter Id:");
        Id=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter name:");
        Name=Console.ReadLine();
        Console.WriteLine("Enter Colour:");
        Color=Console.ReadLine();
    }

    public virtual void Display()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Color: {Color}");
    }
}