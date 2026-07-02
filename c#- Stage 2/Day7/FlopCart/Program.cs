using EcommerceLibrary.Repository;
using ECommLibrary;
using ECommLibrary.Models;
namespace FlopCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemRepository<Item> itemRepository = new ItemRepository<Item>();
            Item i = new Item() { ItemName = "lays", Price = 30, QtyinStock = 30 };
            itemRepository.AddData(i);

            ItemRepository<Order> OrderRepository = new ItemRepository<Order>();
            Order o = new Order() { CustomerName = "nakul", GrossAmount = 400, Orderdate = DateTime.Now };
            OrderRepository.AddData(o);
        }
    }
}