using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Client;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;

namespace RentACar.Server.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        CarDAO carDAO = new CarDAO();
        UserDAO userDAO = new UserDAO();

        [HttpPost]
        [Route ("api/Cars/Create")]
        public void Create([FromBody] Car car) 
        {
            string email = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;
            User user = userDAO.GetUserByEmail(email);
            car.UserID = user.UserId;

            if (ModelState.IsValid)
                carDAO.AddCar (car);
        }


        //---------- functions used for initialization ----------

        [HttpGet]
        [Route("api/Cars")]
        public IEnumerable<Car> GetAllCars() => carDAO.GetAllCars();
    
        [HttpGet]
        [Route("api/Cars/Brands")]
        public IEnumerable<string> GetAllBrands() => carDAO.GetAllBrands();

        [HttpGet]
        [Route("api/Cars/Models")]
        public IEnumerable<string> GetAllModels() => carDAO.GetAllModels();

        [HttpGet]
        [Route("api/Cars/Engine")]
        public IEnumerable<EngineType> GetAllEngineTypes() => carDAO.GetAllEngineTypes();

        [HttpGet]
        [Route("api/Cars/Years")]
        public IEnumerable<int> GetAllYears() => carDAO.GetAllYears();

        [HttpGet]
        [Route("api/Cars/Cities")]
        public IEnumerable<string> GetAllCities() => carDAO.GetAllCities();



        [HttpPost]
        [Route("api/Cars/Search")]
        public IEnumerable<Car> Search([FromBody] UserInput UserInput)
        {
            IEnumerable<Car> cars = carDAO.GetAllCars();
            cars = !string.IsNullOrEmpty(UserInput.Brand) ? cars.Where(c => c.Brand.Equals(UserInput.Brand)) : cars;
            cars = !string.IsNullOrEmpty(UserInput.Model) ? cars.Where(c => c.Model.Equals(UserInput.Model)) : cars;
            cars = UserInput.Engine != null ? cars.Where(c => c.Engine.Equals(UserInput.Engine)) : cars;
            cars = UserInput.Year != null ? cars.Where(c => c.Year.Equals(UserInput.Year)) : cars;

            return cars;
        }
    }
}
