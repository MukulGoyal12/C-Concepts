using Tomato.Models;
using Tomato.Repository;

namespace TomatoTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connstring = @"server=.\sqlexpress;initial catalog=tomato;integrated security=true;trustservercertificate=true";
            Customer c= new Customer() { Email="saujanyag756 @gmail.com", Name="Saujanya Goyal"};
            CustomerRepository repository= new CustomerRepository();
            //repository.addCustomer(c);

            foreach(Customer cu in repository.GetCustomers())
            {
                Console.WriteLine("id "+ cu.Id +" Name " + cu.Name + " Email "+ cu.Email);
                foreach(Order order in cu.Orders)
                {
                    Console.WriteLine(order.OrderDate+ " " + order.GrossAmount.ToString());
                }
            }
            
        }
    }
}
