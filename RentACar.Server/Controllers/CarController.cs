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

        [HttpGet]
        [Route("api/Cars/Brands")]
        public IEnumerable<CarBrand> Index() => carDAO.GetAllBrands();

        [HttpGet]
        [Route("api/Cars/Brands/{year}")]
        public IEnumerable<CarBrand> Index(int year) => carDAO.GetAllBrandsForYear(year);

        //[HttpGet]
        //[Route("api/Cars/Brands/{engineType}")]
        //public IEnumerable<CarBrand> Index(int engineType) => carDAO.GetAllBrandsForEngineType(engineType);

        [HttpGet]
        [Route("api/Cars/Models/{id}")]
        public IEnumerable<CarModel> GetCarModels(int id) => carDAO.GetCarModelsByCarBrandId(id);

        [HttpGet]
        [Route("api/Cars/Years")]
        public IEnumerable<int> GetYears() => carDAO.GetYears();

        [HttpGet]
        [Route("api/Cars/Years/{carModelName}")]
        public IEnumerable<int> GetYearsForModelName(string carModelName) => carDAO.GetYearsForModelName(carModelName);

        [HttpGet]
        [Route("api/Cars/Engine")]
        public IEnumerable<EngineType> GetEngineTypes() => carDAO.GetAllEngineTypes();
    }
}
