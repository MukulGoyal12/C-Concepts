class FTC : Temprature
{
    public override void Display()
    {
        Console.WriteLine($"{((Temp-32)*(0.555))}C");
    }
}