using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MaintenanceService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Data.Models.MaintenaceDbContext>((options) =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("MaintenanceDb"))
            );
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            // Configure JWT authentication
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "fallback_super_secret_key_!ChangeThis!";
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "VehicleService";
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "VehicleServiceClients";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // set to true in production
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,

                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
         
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
