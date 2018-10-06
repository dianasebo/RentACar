using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Shared.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarBrandId { get; set; }
        public int Year { get; set; }
        public EngineType EngineType { get; set; }

        public CarBrand CarBrand { get; set; }
    }
}
