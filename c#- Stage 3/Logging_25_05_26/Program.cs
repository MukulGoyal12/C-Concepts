using Logging_25_05_26.Filters;
using Serilog;
using Serilog.Events;

namespace Logging_25_05_26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<LogFilter>();
                options.Filters.Add<GlobalExceptionFilter>();
            });

            // Add services to the container.builder.Services.AddControllers();

            //configure serilog through code//
            //var log = new LoggerConfiguration().WriteTo.File(@"C:\mukul\c#- Stage 3\Logging_25_05_26\serilog_demo.log", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Debug).CreateLogger();
            //builder.Logging.AddSerilog(log);


            //injecting serilog into the logging pipeline::

            //Configure Serilog from appsettings.json
            builder.Host.UseSerilog((context, services, config) =>
            {

                config.ReadFrom.Configuration(context.Configuration)

                      .Enrich.FromLogContext();

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
