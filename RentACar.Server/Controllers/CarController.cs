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
        [Route("api/Car/GetCarBrands")]
        public IEnumerable<CarBrand> Index()
        {
            return carDAO.GetAllBrands();
        }

        [HttpGet]
        [Route("api/Car/GetCarModels/{id}")]
        public IEnumerable<CarModel> GetCarModels(int id)
        {
            return carDAO.GetCarModelsByCarBrandId(id);
        }
    }
}
