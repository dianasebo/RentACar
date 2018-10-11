using System.Collections.Generic;

namespace RentACar.Shared.Models 
{
    public class RegistrationResponse 
    {
        public bool IsSuccessful { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}