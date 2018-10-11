namespace RentACar.Shared.Models 
{
    public class RegistrationRequest 
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public User CreateUser () => new User () 
        {
            Email = Email,
            Lastname = Lastname,
            Firstname = Firstname,
            City = City,
            Address = Address
        };
    }
}
