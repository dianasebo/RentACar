using RentACar.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Server.DataAccess
{
    public class CarDAO
    {
        RentACarContext db = new RentACarContext();

        public IEnumerable<CarBrand> GetAllBrands()
        {
            try
            {
                return db.CarBrands.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CarModel> GetCarModelsByCarBrandId(int id)
        {
            try
            {
                return db.CarModels.Where(carModel => carModel.CarBrandId.Equals(id)).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
