namespace RentACar.Shared.Models
{
    public class LoginResponse : GenericResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
