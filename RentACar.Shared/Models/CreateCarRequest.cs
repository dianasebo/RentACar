using System.Collections.Generic;

namespace RentACar.Shared.Models
{
    public class CreateCarRequest
    {
        public Car Car { get; set; }
        public IEnumerable<string> Pictures { get; set; }
    }
}
