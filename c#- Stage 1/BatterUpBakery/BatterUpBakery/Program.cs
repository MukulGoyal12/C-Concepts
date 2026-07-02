namespace BatterUpBakery //Do not change the namespace name
{
    public class Program    //Do not change the class name
    {
        //Implement the property here
        public static List<Cake> CakeList = new List<Cake>();//{get;set;}

        public static void Main(string[] args) //Do not change the method signature
        {
            CakeUtility cu = new CakeUtility();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("1.Add cake details");
                Console.WriteLine("2. Get cake price");
                Console.WriteLine("3. Remove by flavour");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 4)
                    {
                        Console.WriteLine("Thank you");
                        cont = false;
                        return;
                    }
                    Console.WriteLine("Enter the cake flavour");
                    string flavour = Console.ReadLine();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the cake quantity");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the cake price");
                            double price = Convert.ToDouble(Console.ReadLine());
                            int before = Program.CakeList.Count;
                            cu.AddCakeDetails(flavour, quantity, price);
                            int after = Program.CakeList.Count;
                            if (after > before)
                            {
                                Console.WriteLine("Inserted successfully");
                            }
                            else
                            {
                                Console.WriteLine("Insertion failed");
                            }
                            break;
                        case 2:
                            Dictionary<string, double> dict = cu.GetCakePrice(flavour);
                            if (dict.Count == 0)
                            {
                                Console.WriteLine("No item found");
                            }
                            else
                            {
                                foreach (KeyValuePair<string, double> kp in dict)
                                {
                                    Console.WriteLine($"{kp.Key}    {kp.Value}");
                                }
                            }
                            break;
                        case 3:
                            List<string> list = cu.RemoveCakeDetails(flavour);
                            if(list.Count == 0)
                            {
                                Console.WriteLine("Empty list");

                            }
                            foreach (string cakes in list)
                            {
                                Console.WriteLine(cakes);
                            }
                            break;
                    }
                }
            }
        }
    }
}