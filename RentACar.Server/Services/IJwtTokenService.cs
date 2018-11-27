using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RentACar.Server.Services
{
    public interface IJwtTokenService
    {
        Task<string> BuildToken(IdentityUser user);
    }
}
