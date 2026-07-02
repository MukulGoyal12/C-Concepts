using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Models
{
    public class AuctionContext:DbContext
    {
        public  DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Bid> Bids { get; set;  }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\sqlexpress;initial catalog=auctiondb;integrated security=true;trustservercertificate=true");
        }
    }
}
