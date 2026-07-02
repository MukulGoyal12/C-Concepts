
namespace EntensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string surname = new string("Goyal");
            Console.WriteLine(surname.Mukul());
        }
    }

    public static class MyExtentions
    {
        public static string Mukul(this string s)
        {
            return "Mukul " + s;
        }
    }
}
