using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Tomato.Models
{
    public class TomatoContext:DbContext
    {

        //public string connstring;

        //public TomatoContext(string connstring)
        //{
        //    this.connstring = connstring;
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connstring);
            optionsBuilder
                .UseLazyLoadingProxies()    //Enable Lazy Loading. Child tables use krni h to krna pdega
                .UseSqlServer(@"server=.\sqlexpress;initial catalog=tomato;integrated security=true;trustservercertificate=true");
        }
    }
}
