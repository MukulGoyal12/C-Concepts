using Tomato.Models;
using Tomato.Repository;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant() { Id=1, Location="Siruseri", Name="Guntur Karam", Rating=5});
            restaurants.Add(new Restaurant() { Id =2, Location = "Hyderabad", Name = "Hyderabad Karam", Rating = 4 });
            restaurants.Add(new Restaurant() { Id =3, Location = "Bengaluru", Name = "Bengaluru Karam", Rating = 5 });
            restaurants.Add(new Restaurant() { Id =4, Location = "Chennai", Name = "Chennai Karam", Rating = 1 });
            //restaurants.Sort();    This is doing sorting on basis of rating because of IComparable 
            restaurants.Sort(new NameSorter());      // And this will do on basis of Name bcoz of IComparer
            restaurants.Sort(new LocationSorter());

            foreach (var items in restaurants)
            {
                Console.WriteLine(items);
            }

             


            //CustomerRepository customerRepository = new CustomerRepository();
            //customerRepository.GetCustomers().ToList().ForEach(customer =>
            //{
            //    Console.WriteLine(customer.Name+" "+customer.Email) ;
            //    Console.WriteLine("orders of Customer "+ customer.Name);
            //    foreach (Order o in customer.Orders)
            //    {
            //        Console.WriteLine(o.GrossAmount);
            //    }
            //});
        }
    }
}