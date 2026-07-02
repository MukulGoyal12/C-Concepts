using MaintenanceTypeService.Models;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceService.Data.Models
{
    public class MaintenaceDbContext:DbContext
    {
         

        public MaintenaceDbContext(DbContextOptions<MaintenaceDbContext> options) : base(options)
        {
        }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MaintenanceType>().HasKey(mt => new { mt.VehicleType,mt.Name });
        }
    }
}
