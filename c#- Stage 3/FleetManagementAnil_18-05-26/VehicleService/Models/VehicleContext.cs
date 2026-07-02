using Microsoft.EntityFrameworkCore;

namespace VehicleService.Models
{
    public class VehicleContext:DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options):base(options)
        {
            
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            //modelBuilder.Entity<Vehicle>().HasData(
            //    new Vehicle { Id = 1, Type = "Car", Model = "Toyota Camry", RegnNo = "ABC123", EngnieCapacity = 2500, Year = 2020 },
            //    new Vehicle { Id = 2, Type = "Motorcycle", Model = "Honda CBR500R", RegnNo = "XYZ789", EngnieCapacity = 500, Year = 2019 }
            //);
            modelBuilder.Entity<VehicleDTO>().HasNoKey();
        }
    }
}
