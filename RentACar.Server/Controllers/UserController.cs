// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using RentACar.Server.DataAccess;
// using RentACar.Shared.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace RentACar.Server.Controllers {
//     public class UserController : Controller {
//         UserDAO userDAO = new UserDAO ();

//         [HttpGet]
//         [Route ("api/Users/Index")]
//         public IEnumerable<User> Index () => userDAO.GetAllUsers ();

//         [HttpPost]
//         [Route ("api/Users/Create")]
//         public void Create ([FromBody] User user) {
//             if (ModelState.IsValid)
//                 userDAO.AddUser (user);
//         }

//         [HttpGet]
//         [Route ("api/Users/Details/{id}")]
//         public User Details (int id) {

//             return userDAO.GetUserById (id);
//         }

//         [HttpPut]
//         [Route ("api/Users/Edit")]
//         public void Edit ([FromBody]User user) {
//             if (ModelState.IsValid)
//                 userDAO.UpdateUser (user);
//         }

//         [HttpDelete]
//         [Route ("api/Users/Delete/{id}")]
//         public void Delete (int id) {
//             userDAO.DeleteById (id);
//         }
//     }
// }