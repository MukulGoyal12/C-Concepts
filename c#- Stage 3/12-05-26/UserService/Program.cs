using Microsoft.EntityFrameworkCore;
using StaffService.Models;
namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("StaffContext") ?? throw new InvalidOperationException("Connection string 'StaffContext' not found.");

            builder.Services.AddDbContext<StaffContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
