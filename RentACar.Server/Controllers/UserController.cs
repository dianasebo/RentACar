using System.Collections.Generic;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RentACar.Server.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly UserDAO userDAO = new UserDAO();

        public UserController (UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/Users/Index")]
        public IEnumerable<User> Index() => userDAO.GetAllUsers();

        //[HttpPost]
        //[Route("api/Users/Create")]
        //public void Create([FromBody] User user)
        //{
        //    if (ModelState.IsValid)
        //        userDAO.AddUser(user);
        //}

        [HttpGet]
        [Route("api/Users/{id}")]
        public User GetUserById(int id)
        {
           return userDAO.GetUserById(id);
        }

        //[HttpPut]
        //[Route("api/Users/Edit")]
        //public void Edit([FromBody]User user)
        //{
        //    if (ModelState.IsValid)
        //        userDAO.UpdateUser(user);
        //}

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("api/Users/Delete/{id}")]
        public async Task Delete(int id)
        {
            var email = userDAO.GetUserById(id).Email;
            var userToDelete = await userManager.FindByEmailAsync(email);
            userDAO.DeleteById(id);
            await userManager.DeleteAsync(userToDelete);
        }
    }
}