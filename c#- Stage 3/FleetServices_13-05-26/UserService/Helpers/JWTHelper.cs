using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StaffService.Models;

namespace StaffService.Helpers
{
    public class JWTHelper
    {
        // Generates a JWT token containing selected Staff properties as claims.
        public static string GenerateToken(Staff staff)

        {
            string SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET");
            string Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            string Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

            if (staff == null) throw new ArgumentNullException(nameof(staff));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("id", staff.Id.ToString()),
                new Claim("name", staff.Name ?? string.Empty),
                new Claim("email", staff.Email ?? string.Empty),
                new Claim("position", staff.Position ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Sub, staff.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
