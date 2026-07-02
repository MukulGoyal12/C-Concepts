
using System.Net;

namespace BookManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            LibraryManager libraryManager = new LibraryManager();
            while (flag)
            {
                Console.WriteLine("Welcome to Mukul Library🙏🏻");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Display all Books");
                Console.WriteLine("3. Update Book Details");
                Console.WriteLine("4. Exit the Program");

                if(int.TryParse(Console.ReadLine(),out int choice))
                {
                    if (choice == 4)
                    {
                        Console.WriteLine("Exiting the program...");
                        flag = false;
                    }
                
                    switch (choice)
                    {

                        case 1:
                            try
                            {
                                Console.WriteLine("Enter BookId");
                                int Id = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter Title");
                                string Title = Console.ReadLine();

                                Console.WriteLine("Enter Author");
                                string Author = Console.ReadLine();

                                Console.WriteLine("Enter Location");
                                string Location = Console.ReadLine();

                                libraryManager.AddBook(new Book(Id, Title, Author, Location));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            
                            break;

                        case 2:
                            libraryManager.DisplayAllBooks();
                            break;

                        case 3:
                            try
                            {
                                Console.WriteLine("Enter BookId");
                                int id = Convert.ToInt32(Console.ReadLine());
                                libraryManager.UpdateBookById(id);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                    }
                }
            }
        }
    }
}
