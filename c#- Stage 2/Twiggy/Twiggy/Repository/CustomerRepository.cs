using Twiggy.Models;

namespace Twiggy.Repository
{
    public class CustomerRepository
    {
        private TwiggyContext _context;

        public CustomerRepository()
        {
            _context = new TwiggyContext();
        }

        public bool AddCustomer(Customer customer)
        {
            customer.Id = null;
            _context.Customers.Add(customer);
            int result = _context.SaveChanges();
            if (result > 0) return true;
            return false;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
