using Microsoft.EntityFrameworkCore;
using RentACar.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentACar.Server.DataAccess
{
    public class CarDAO : BaseDAO 
    {
        
        public void AddCarPicture(CarPicture carPicture)
        {
            TryDatabaseQuery(() => {
                db.CarPictures.Add (carPicture);
                db.SaveChanges ();
            });
        }

        public byte[] GetPictureForCar (int carId) {
            return TryDatabaseQuery(() => {
                var car = db.Cars.Where(c => c.CarId == carId).Include(c => c.Pictures).Single();
                return car.Pictures.First().Picture;
            });
        }
        
        public int AddCar(Car car) 
        {
            return TryDatabaseQuery(() => {
                db.Cars.Add (car);
                db.SaveChanges ();
                return car.CarId;
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

        public IEnumerable<Car> GetAllCars() => TryDatabaseQuery(() => db.Cars.AsEnumerable());

        public IEnumerable<string> GetAllBrandsForYear(int year)
        {
            return TryDatabaseQuery(() => db.Cars.Where(m => m.Year == year)
                                                 .Select(m => m.Brand)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetModelsForBrand(string brand)
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

        public IEnumerable<string> GetAllModels()
        {
            return TryDatabaseQuery(() => db.Cars.Select(c => c.Model)
                                                 .ToHashSet());
        }

        public IEnumerable<EngineType> GetAllEngineTypes()
        {
            return TryDatabaseQuery(() =>db.Cars.Select(c => c.Engine)
                                                .ToHashSet());
        }

        public IEnumerable<int> GetAllYears()
        {
            return TryDatabaseQuery(() => db.Cars.Select (c => c.Year)
                                                 .ToHashSet ());
        }

        public IEnumerable<string> GetAllCities()
        {
            return TryDatabaseQuery(() => db.Cars.Select(c => c.User)
                                                 .Select(u => u.City)
                                                 .ToHashSet());
        }

        public IEnumerable<int> GetAllYearsForModel(string model)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => model.Equals(c.Model))
                                                 .Select(m => m.Year)
                                                 .ToHashSet());
        }

        public IEnumerable<EngineType> GetEnginesForBrand(string brand)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => brand.Equals(c.Brand))
                                                 .Select(c => c.Engine)
                                                 .ToHashSet());
        }

        public IEnumerable<int> GetYearsForBrand(string brand)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => brand.Equals(c.Brand))
                                                 .Select(c => c.Year)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetCitiesForBrand(string brand)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => brand.Equals(c.Brand))
                                                 .Select(c => c.User)
                                                 .Select(u => u.City)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetBrandForModel(string model)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => model.Equals(c.Model))
                                                 .Select(c => c.Brand)
                                                 .ToHashSet());
        }

        public IEnumerable<EngineType> GetEnginesForModel(string model)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => model.Equals(c.Model))
                                                 .Select(c => c.Engine)
                                                 .ToHashSet());
        }

        public IEnumerable<int> GetYearsForModel(string model)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => model.Equals(c.Model))
                                                 .Select(c => c.Year)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetCitiesForModel(string  model)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => model.Equals(c.Model))
                                                 .Select(c => c.User)
                                                 .Select(u => u.City)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetBrandsForEngine(EngineType engine)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => engine.Equals(c.Engine))
                                                 .Select(c => c.Brand)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetModelsForEngine(EngineType engine)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => engine.Equals(c.Engine))
                                                 .Select(c => c.Model)
                                                 .ToHashSet());
        }

        public IEnumerable<int> GetYearsForEngine(EngineType engine)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => engine.Equals(c.Engine))
                                                 .Select(c => c.Year)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetCitiesForEngine(EngineType engine)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => engine.Equals(c.Engine))
                                                 .Select(c => c.User)
                                                 .Select(u => u.City)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetBrandsForYear(int year)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => year.Equals(c.Year))
                                                .Select(c => c.Brand)
                                                .ToHashSet());
        }

        public IEnumerable<string> GetModelsForYear(int year)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => year.Equals(c.Year))
                                                .Select(c => c.Model)
                                                .ToHashSet());
        }

        public IEnumerable<EngineType> GetEnginesForYear(int year)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => year.Equals(c.Year))
                                                 .Select(c => c.Engine)
                                                 .ToHashSet());
        }

        public IEnumerable<string> GetCitiesForYear(int year)
        {
            return TryDatabaseQuery(() => db.Cars.Where(c => year.Equals(c.Year))
                                                 .Select(c => c.User)
                                                 .Select(u => u.City)
                                                 .ToHashSet());
        }
    }
}
