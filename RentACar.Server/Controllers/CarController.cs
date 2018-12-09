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
    public class CarController : Controller
    {
        CarDAO carDAO = new CarDAO();
        UserDAO userDAO = new UserDAO();

        [Authorize]
        [HttpPost]
        [Route ("api/Cars/Create")]
        public GenericResponse Create([FromBody] CreateCarRequest createCarRequest) {
            if (!ModelState.IsValid)
                return new GenericResponse { IsSuccessful = false };

            Car car = createCarRequest.Car;
            carDAO.AddCar (car);
            foreach (var picture in createCarRequest.Pictures)
                carDAO.AddCarPicture(new CarPicture 
                {
                    CarId = car.CarId,
                    Picture = Convert.FromBase64String(picture)
                });
            return new GenericResponse();
        }

        [Authorize]
        [HttpDelete]
        [Route("api/Cars/Delete/{carId}")]
        public void DeleteCarById(int carId)
        {
            carDAO.DeleteCarById(carId);
        }

        [HttpGet]
        [Route("api/Cars/Random/{count}")]
        public IEnumerable<Car> GetSomeCars(int count) => carDAO.GetRandomCars(count);

        [HttpGet]
        [Route("api/Cars/{carId}/Pictures")]
        public IActionResult GetPicture(int carId) 
        {
            return File(carDAO.GetPictureForCar(carId), "image/jpeg");
        }

        [HttpGet]
        [Route("api/Cars/{carId}/Pictures/{pictureId}")]
        public IActionResult GetPictureByIdForCar(int carId, int pictureId) 
        {
            try {
                return File(carDAO.GetPictureByIdForCar(carId, pictureId), "image/jpeg");
            } 
            catch
            {
                return NotFound();
            }
        }

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
            //TODO: search by ac && price
            return cars;
        }
    }
}
