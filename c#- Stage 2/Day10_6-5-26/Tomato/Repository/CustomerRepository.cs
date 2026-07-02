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

        public void addCustomer(CustomerDTO customer)
        {
            Customer c = new Customer();
            c.Name = customer.Name;
            c.Email = customer.email;
            _context.Update(c);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Include(cc=>cc.Orders).ToList();
        }

        public Customer? FindById(int id)
        {
            return _context.Customers.Find(id);    //Find take primary  key
        }

        public List<Customer> FindByOrderCount(int greaterThan)
        {
            var item = _context.Customers.Where(o => o.Orders.Count > greaterThan).ToList();
            //select * from Customers where (select count(*) from orders where orders.customerId = customer.customerid)>greaterThan
            return item;
        }

        public List<Customer> FindByname(string name)
        {
            var item = _context.Customers.Where(c => c.Name.Contains(name)).ToList();
            return item;
        }

        public void DeleteCustomerById(int id)
        {
            var find = _context.Customers.Find(id);
            if (find != null)
            {
                _context.Customers.Remove(find);
            }
            _context.SaveChanges(true);

                            //OR

            //_context.Customers.Where(c => c.Id == id).ExecuteDelete(); 
        }

        public void DeleteCustomersByName(string name)
        {
            _context.Customers.Where(c => c.Name == name).ExecuteDelete();
        }

        //public void UpdateCustomerById(int id, Customer customer)
        //{
        //    var find = _context.Customers.Find(id);
        //    if (find != null)
        //    {
        //        find.Name= customer.Name;
        //        find.Email= customer.Email;
        //        _context.SaveChanges(true);
        //    }
        //}

        public void UpdateCustomerById(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }

    }
}
