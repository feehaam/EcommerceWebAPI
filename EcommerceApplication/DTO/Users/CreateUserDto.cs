using EcommerceApplication.Models.Users;

namespace EcommerceApplication.DTO.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Contact? Contacts { get; set; }
        public Address? Address { get; set; }
    }
}
