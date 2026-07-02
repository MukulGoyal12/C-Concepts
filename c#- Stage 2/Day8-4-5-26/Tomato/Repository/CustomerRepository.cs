using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tomato.Models;

namespace Tomato.Repository
{
    public class CustomerRepository
    {
        private readonly TomatoContext _context;

        public CustomerRepository()
        {
            _context = new TomatoContext();
        }

        public void addCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Include(cc=>cc.Orders).ToList();
        }
    }
}
