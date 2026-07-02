using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace FleetGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //adding ocelot configuration file
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            //register the ocelot services
            builder.Services.AddOcelot(builder.Configuration);
            var app = builder.Build();
            app.UseOcelot();
           // app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
