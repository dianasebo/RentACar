using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;

namespace RentACar.Server.Controllers
{
    public class CarController : Controller
    {
        CarDAO carDAO = new CarDAO();        
        
        [HttpPost]
        [Route ("api/Cars/Create")]
        public void Create([FromBody] Car car) 
        {
            if (ModelState.IsValid)
                carDAO.AddCar (car);
        }

        [HttpGet]
        [Route("api/Cars/Brands")]
        public IEnumerable<string> GetAllBrands() => carDAO.GetAllBrands();

        [HttpGet]
        [Route("api/Cars/Brands/Random")]
        public string GetRandomBrand() => carDAO.GetRandomBrand();

        [HttpGet]
        [Route("api/Cars/Years")]
        public IEnumerable<int> GetAllYears() => carDAO.GetAllYears();

        [HttpGet]
        [Route("api/Cars/Years/Random")]
        public int GetRandomYear() => carDAO.GetRandomYear();

        [HttpGet]
        [Route("api/Cars/Engine")]
        public IEnumerable<EngineType> GetAllEngineTypes() => carDAO.GetAllEngineTypes();

        [HttpGet]
        [Route("api/Cars/{brand}/Models")]
        public IEnumerable<string> GetAllModelsForBrand(string brand) => carDAO.GetAllModelsForBrand(brand);

        [HttpGet]
        [Route("api/Cars/{brand}/Models/Random")]
        public string GetRandomModelForBrand(string brand) => carDAO.GetRandomModelForBrand(brand);

        [HttpGet]
        [Route("api/Cars/{model}/Years/Random")]
        public int GetRandomYearForModel(string model) => carDAO.GetRandomYearForModel(model);


        [HttpGet]
        [Route("api/Cars/Brands/{year}")]
        public IEnumerable<string> GetAllBrandsForYear(int year) => carDAO.GetAllBrandsForYear(year);


        [HttpGet]
        [Route("api/Cars/Years/{model}")]
        public IEnumerable<int> GetAllYearsForModel(string model) => carDAO.GetAllYearsForModel(model);


    }
}
