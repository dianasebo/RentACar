namespace RentACar.Shared.Models
{
    public class LoginResponse
    {
        public bool IsSuccessful { get; set; } = true;
        public string Token { get; set; }
        public User User { get; set; }
    }
}
