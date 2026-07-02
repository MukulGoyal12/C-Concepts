using Microsoft.EntityFrameworkCore;

namespace StaffService.Models
{
    public class StaffContext:DbContext
    {
        public StaffContext(DbContextOptions<StaffContext> options) : base(options)
        {
        }
        public  DbSet<Staff> Staffs { get; set; }

         
    }
}
