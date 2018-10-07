using RentACar.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Server.DataAccess
{
    public class CarDAO : BaseDAO 
    {
        

        public void AddCar(Car car) 
        {
            TryDatabaseQuery(() => {
                db.Cars.Add (car);
                db.SaveChanges ();
            });
        }

        public string GetRandomBrand() 
        {
            return TryDatabaseQuery(() => db.Cars.Select(c => c.Brand)
                                                 .AsEnumerable()
                                                 .OrderBy(b => Guid.NewGuid())
                                                 .First());
        }

        public int GetRandomYear() 
        {
            return TryDatabaseQuery(() => db.Cars.Select(c => c.Year)
                                                 .AsEnumerable()
                                                 .OrderBy(b => Guid.NewGuid())
                                                 .First());
        }

        public string GetRandomModelForBrand (string brand) 
        {    
            return TryDatabaseQuery(() => {
                return db.Cars.Where(c => brand.Equals(c.Brand))
                              .Select(c => c.Model)
                              .ToHashSet()
                              .AsEnumerable()
                              .OrderBy(m => Guid.NewGuid())
                              .First();
            });
        }

        public int GetRandomYearForModel (string model) 
        {
            return TryDatabaseQuery(() => db.Cars.Where(m => model.Equals(m.Model))
                                                 .Select(m => m.Year)
                                                 .ToHashSet()
                                                 .AsEnumerable()
                                                 .OrderBy(m => Guid.NewGuid())
                                                 .FirstOrDefault());
        }


        public IEnumerable<string> GetAllBrandsForYear(int year)
        {
            return TryDatabaseQuery(() => db.Cars.Where(m => m.Year == year)
                                                 .Select(m => m.Brand)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetAllModelsForBrand(string brand)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => c.Brand.Equals(brand))
                                                 .Select(c => c.Model)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetAllBrands()
        {
        
            return TryDatabaseQuery(() => db.Cars.Select(c => c.Brand)
                                                 .ToHashSet());
        }
        public IEnumerable<int> GetAllYears()
        {
            return TryDatabaseQuery(() => db.Cars.Select (c => c.Year)
                                                 .ToHashSet ());
        }

        public IEnumerable<EngineType> GetAllEngineTypes()
        {
            return TryDatabaseQuery(() =>db.Cars.Select(c => c.Engine)
                                                .ToHashSet());
        }

        public IEnumerable<int> GetAllYearsForModel(string model)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => model.Equals(c.Model))
                                                 .Select(m => m.Year)
                                                 .ToHashSet());
        }
    }
}
