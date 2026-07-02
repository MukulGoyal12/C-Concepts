namespace Medical_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MedicalEquipmentInventorySystem inv = new MedicalEquipmentInventorySystem();
            bool cont = true;

            while (cont)
            {
                Console.WriteLine("Medical Inventory Menu");
                Console.WriteLine("1. Add Equipment");
                Console.WriteLine("2. Get Equipment");
                Console.WriteLine("3. Remove Equipment");
                Console.WriteLine("4. Exit");
                Console.Write("Select Choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 4)
                    {
                        cont = false;
                        Console.WriteLine("Bye Bye Bhai");
                        continue;
                    }

                    if (choice >= 1 && choice <= 3)
                    {
                        Console.WriteLine("Enter Equipment Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Manufacturer:");
                        string manufacturer = Console.ReadLine();

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter Quantity:");
                                int qty = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Unit Cost:");
                                double cost = Convert.ToDouble(Console.ReadLine());
                                inv.AddEquipment(name, manufacturer, qty, cost);
                                break;

                            case 2:
                                try
                                {
                                    MedicalEquipment details = inv.GetEquipmentDetails(name, manufacturer);
                                    Console.WriteLine(details);
                                }
                                catch (EquipmentNotFoundException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            case 3:
                                try
                                {
                                    inv.RemoveEquipment(name, manufacturer);
                                }
                                catch (EquipmentNotFoundException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please select 1-4.");
                    }
                }
            }
        }
    }
}
