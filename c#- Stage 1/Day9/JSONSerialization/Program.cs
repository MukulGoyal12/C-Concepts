using static global::System.Console;
using System.Text.Json;
using System.Globalization;

namespace JSONSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteProducts();
            ReadProducts();
        }

        static void WriteProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Lays", Price = 10 });

            products.Add(new Product { Id = 2, Name = "Kurkure", Price = 10 });

            products.Add(new Product() { Id = 3, Name = "bingo", Price = 33 });

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string data = JsonSerializer.Serialize(products,options);
            File.WriteAllText(@"c:\newJson.txt", data);
        }

        static void ReadProducts()
        {
            string data = File.ReadAllText(@"c:\json.txt");
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
            foreach(Product product in products)
            {
                WriteLine(product);
            }
        }
    }
}