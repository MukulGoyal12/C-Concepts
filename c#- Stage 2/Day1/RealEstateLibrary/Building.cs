namespace RealEstateLibrary
{
    public class Building
    {
        public int Id;
        public string Name { get; set; }

        public void Accept()
        {
            Console.WriteLine("Enter id and Name:");
            Int32.TryParse(Console.ReadLine(), out Id);
            Name = Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine($"id:{Id} Name:{Name}");
        }

    }
}
