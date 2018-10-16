using RentACar.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Client
{
    public class UserInput
    {
        public string Brand { get; set; } = null;
        public string Model { get; set; } = null;
        public EngineType? Engine { get; set; } = null;
        public string Year { get; set; } = null;
        public string City { get; set; } = null;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
