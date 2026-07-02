using System;
using System.Collections.Generic;
using System.Text;
using BillingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingLibrary.Repository
{
    public class BillContext:DbContext
    {
        public DbSet<Bill> Bills { get; set; }             //This DbSet is similar to List

        public BillContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\sqlexpress;initial catalog=cognizant;integrated security=true;trustservercertificate=true;");

        }
    }
}
