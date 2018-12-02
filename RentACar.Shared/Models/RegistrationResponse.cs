using System.Collections.Generic;

namespace RentACar.Shared.Models 
{
    public class RegistrationResponse : GenericResponse
    {
        public Dictionary<string, IEnumerable<string>> Errors { get; set; }
    }
}