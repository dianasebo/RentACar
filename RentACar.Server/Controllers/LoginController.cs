using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using RentACar.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Authorization;

namespace RentACar.Server.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IJwtTokenService tokenService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly UserDAO userDAO = new UserDAO();

        public LoginController(IJwtTokenService tokenService, UserManager<IdentityUser> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("api/Registration")]
        public async Task<RegistrationResponse> Registration([FromBody] RegistrationRequest registrationRequest)
        {
            var result = await userManager.CreateAsync(new IdentityUser()
            {
                UserName = registrationRequest.Email,
                Email = registrationRequest.Email
            }, registrationRequest.Password);

            if (result.Succeeded) 
                userDAO.AddUser(registrationRequest.CreateUser());

            var response = new RegistrationResponse() 
                            {
                                IsSuccessful = result.Succeeded,
                                Errors = result.Errors.ToDictionary(k => k.Code, v => v.Description)
                            };
            return response;
                            
        }

        [HttpPost]
        [Route ("api/Login")]
        public async Task<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            dynamic user;
            try 
            {
                user = await userManager.FindByEmailAsync(loginRequest.Email);
            } 
            catch
            {
                return new LoginResponse() { IsSuccessful = false };
                
            }
            var correctPassword = await userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!correctPassword) 
                return new LoginResponse() { IsSuccessful = false };

            return new LoginResponse { Token = GenerateToken(loginRequest.Email) };
        }   

        private string GenerateToken (string email) => tokenService.BuildToken(email);
    }
}
