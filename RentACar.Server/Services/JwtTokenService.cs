using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace RentACar.Server.Services
{
    public class JwtTokenService : IJwtTokenService 
    {
        private readonly IConfiguration configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string BuildToken (string email) 
        {
            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credidentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], 
                                             configuration["Jwt:Audience"], 
                                             claims,
                                             expires: DateTime.Now.AddMinutes(double.Parse(configuration["Jwt:ExpireTime"])),
                                             signingCredentials: credidentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
