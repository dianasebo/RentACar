using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


        //---------- functions used for autocompletion ----------

        [HttpGet]
        [Route("api/Cars/Brands/Random")]
        public string GetRandomBrand() => carDAO.GetRandomBrand();

        [HttpGet]
        [Route("api/Cars/{brand}/Models/Random")]
        public string GetRandomModelForBrand(string brand) => carDAO.GetRandomModelForBrand(brand);

        [HttpGet]
        [Route("api/Cars/{model}/Years/Random")]
        public int GetRandomYearForModel(string model) => carDAO.GetRandomYearForModel(model);

        [HttpGet]
        [Route("api/Cars/Years/Random")]
        public int GetRandomYear() => carDAO.GetRandomYear();


        //---------- functions used for updating filters ----------

        //---------- brand selected ----------
        [HttpGet]
        [Route("api/Cars/{brand}/ModelsForBrand")]
        public IEnumerable<string> GetModelsForBrand(string brand) => carDAO.GetModelsForBrand(brand);

        [HttpGet]
        [Route("api/Cars/{brand}/EnginesForBrand")]
        public IEnumerable<EngineType> GetEngineTypesForBrand(string brand) => carDAO.GetEnginesForBrand(brand);
        
        [HttpGet]
        [Route("api/Cars/{brand}/YearsForBrand")]
        public IEnumerable<int> GetYearsForBrand(string brand) => carDAO.GetYearsForBrand(brand);

        [HttpGet]
        [Route("api/Cars/{brand}/CitiesForBrand")]
        public IEnumerable<string> GetCitiesForBrand(string brand) => carDAO.GetCitiesForBrand(brand);


        //---------- model selected ----------
        [HttpGet]
        [Route("api/Cars/{model}/BrandForModel")]
        public IEnumerable<string> GetBrandForModel(string model) => carDAO.GetBrandForModel(model);

        [HttpGet]
        [Route("api/Cars/{model}/EnginesForModel")]
        public IEnumerable<EngineType> GetEngineTypesForModel(string model) => carDAO.GetEnginesForModel(model);

        [HttpGet]
        [Route("api/Cars/{model}/YearsForModel")]
        public IEnumerable<int> GetYearsForModel(string model) => carDAO.GetYearsForModel(model);

        [HttpGet]
        [Route("api/Cars/{model}/CitiesForModel")]
        public IEnumerable<string> GetCitiesForModel(string model) => carDAO.GetCitiesForModel(model);


        //---------- engine type selected ----------
        [HttpGet]
        [Route("api/Cars/{engine}/BrandsForEngine")]
        public IEnumerable<string> GetBrandsForEngine(EngineType engine) => carDAO.GetBrandsForEngine(engine);

        [HttpGet]
        [Route("api/Cars/{engine}/ModelsForEngine")]
        public IEnumerable<string> GetModelsForEngine(EngineType engine) => carDAO.GetModelsForEngine(engine);

        [HttpGet]
        [Route("api/Cars/{engine}/YearsForEngine")]
        public IEnumerable<int> GetYearsForEngine(EngineType engine) => carDAO.GetYearsForEngine(engine);

        [HttpGet]
        [Route("api/Cars/{engine}/CitiesForEngine")]
        public IEnumerable<string> GetCitiesForEngine(EngineType engine) => carDAO.GetCitiesForEngine(engine);

        //---------- year selected ----------
        [HttpGet]
        [Route("api/Cars/{year}/BrandsForYear")]
        public IEnumerable<string> GetBrandsForYear(int year) => carDAO.GetBrandsForYear(year);

        [HttpGet]
        [Route("api/Cars/{year}/ModelsForYear")]
        public IEnumerable<string> GetModelsForEngine(int year) => carDAO.GetModelsForYear(year);

        [HttpGet]
        [Route("api/Cars/{year}/EnginesForYear")]
        public IEnumerable<EngineType> GetEnginesForYear(int year) => carDAO.GetEnginesForYear(year);

        [HttpGet]
        [Route("api/Cars/{year}/CitiesForYear")]
        public IEnumerable<string> GetCitiesForEngine(int year) => carDAO.GetCitiesForYear(year);

        //---------- year selected ----------
        //[HttpGet]
        //[Route("api/Cars/{city}/BrandsForCity")]
        //public IEnumerable<string> GetBrandsForCity(string city) => carDAO.GetBrandsForCity(city);

        //[HttpGet]
        //[Route("api/Cars/{city}/ModelsForCity")]
        //public IEnumerable<string> GetModelsForCity(string city) => carDAO.GetModelsForCity(city);

        //[HttpGet]
        //[Route("api/Cars/{city}/EnginesForCity")]
        //public IEnumerable<EngineType> GetEnginesForCity(string city) => carDAO.GetEnginesForCity(city);

        //[HttpGet]
        //[Route("api/Cars/{city}/YearsForCity")]
        //public IEnumerable<int> GetYearsForCity(string city) => carDAO.GetYearsForCity(city);
    }
}
