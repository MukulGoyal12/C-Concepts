using CollectionsDemo;

namespace GenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> messages = new();
            messages.Push("hi");
            string s = messages.Pop();

            //=============================

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(s);

            //===============================================

            Dictionary<string,Action> actions = new Dictionary<string,Action>();
            actions.Add("func1", () => { Console.WriteLine("func1 val"); });
            actions.Add("func2", () => { Console.WriteLine("func2 val"); });
            foreach (KeyValuePair<string, Action> items in actions)
            {
                Console.WriteLine(items.Key);
                items.Value();
            }

            //=====================================================

            List<string> commands = new();
            commands.Add("hello");
            commands.Add("world");
            foreach(string str in commands)
            {
                Console.WriteLine(s);
            }
            commands.RemoveAt(1);

            List<Product> products = new();
            products.Add(new Product()
            {
                Id = 1,
                Name = "Test",
                Price = 40,
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Test2",
                Price = 31,
            });
            products.Add(new Product()
            {
                Id = 3,
                Name = "Test3",
                Price = 12,
            });

            //Filter Object Collections: Language Integrated Query : LINQ -> 
            //Sysntaxes - Query Comprehension Syntax, Extention Method Syntax


            //Query Comprehension Syntax
            IEnumerable<Product> IdFilter = from ids in products
                                            where ids.Id >= 2
                                            select ids;

            IEnumerable < Product > priceGreater = from p in products
                                                   where p.Price > 30
                                                   select p;

            List<Product> priceGreaterList = (from p in products
                                                where p.Price > 30
                                                orderby p.Price
                                                select p).ToList();

            foreach(Product p in priceGreaterList)
            {
                Console.WriteLine(p );
            }
            foreach (Product p1 in priceGreater)
            {
                Console.WriteLine(p1);
            }


            //Extention Method Syntax
            Console.WriteLine("Extention Method Syntax");
            foreach (var p in products.Where(obj => obj.Price > 30).ToList())
            {
                Console.WriteLine(p);
            }


            //===========================================================



        }
    }
}
