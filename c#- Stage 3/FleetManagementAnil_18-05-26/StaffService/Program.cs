using Microsoft.EntityFrameworkCore;

namespace StaffService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Models.StaffContext>((options) =>  
               options.UseSqlServer(builder.Configuration.GetConnectionString("StaffDb"))
            );

            builder.Services.AddControllers()
                .AddXmlSerializerFormatters();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
