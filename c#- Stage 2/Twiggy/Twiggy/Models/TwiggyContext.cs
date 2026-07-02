using Microsoft.EntityFrameworkCore;

namespace Twiggy.Models
{
    public class TwiggyContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\sqlexpress;initial catalog=twiggy;integrated security=true;trustservercertificate=true");
        }
    }
}
