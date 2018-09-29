using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.Server.Controllers {
    public class UserController : Controller {
        UserDAO userDAO = new UserDAO ();

        [HttpGet]
        [Route ("api/User/Index")]
        public IEnumerable<User> Index () {
            return userDAO.GetAllUsers ();
        }

        [HttpPost]
        [Route ("api/User/Create")]
        public void Create ([FromBody] User user) {
            if (ModelState.IsValid)
                userDAO.AddUser (user);
        }

        [HttpGet]
        [Route ("api/User/Details/{id}")]
        public User Details (int id) {

            return userDAO.GetUserById (id);
        }

        [HttpPut]
        [Route ("api/User/Edit")]
        public void Edit ([FromBody]User user) {
            if (ModelState.IsValid)
                userDAO.UpdateUser (user);
        }

        [HttpDelete]
        [Route ("api/User/Delete/{id}")]
        public void Delete (int id) {
            userDAO.DeleteById (id);
        }
    }
}