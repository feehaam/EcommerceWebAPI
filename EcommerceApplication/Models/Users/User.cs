using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Orders;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Contact ? Contacts { get; set; }
        public Address ? Address { get; set; }
        public Cart ? Cart { get; set; }
        public ICollection<Order> ? Orders { get; set; }
    }
}
