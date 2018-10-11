using System;

namespace RentACar.Server.Services
{
    public interface IJwtTokenService
    {
        string BuildToken(string email);
    }
}
