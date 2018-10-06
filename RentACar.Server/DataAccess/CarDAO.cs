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

        public IEnumerable<CarBrand> GetAllBrandsForYear(int year)
        {
            try
            { 
                return db.CarModels.Where(m => m.Year == year).Select(m => m.CarBrand).ToList();
            }
            catch
            {
                throw;
            }
        }

        //public IEnumerable<CarBrand> GetAllCarBrandsForEngineType(int engineType)
        //{
        //    try
        //    {
        //        return db.CarModels.Where(m => m.EngineType == engineType).Select(m => m.CarBrand).ToList();
        //    }
        //}

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

        public IEnumerable<int> GetYears()
        {
            try
            {
                return db.CarModels.Select(m => m.Year).ToHashSet().ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<int> GetYearsForModelName(string carModelName)
        {
            try
            {
                return db.CarModels.Where(m => carModelName.Equals(m.Name)).Select(m => m.Year).ToHashSet().ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<EngineType> GetAllEngineTypes()
        {
            try
            {
                return db.CarModels.Select(m => m.EngineType).ToHashSet().ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
