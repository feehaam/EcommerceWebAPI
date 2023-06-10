using System.ComponentModel.DataAnnotations;
using EcommerceApplication.Models.Users;

namespace EcommerceApplication.Models.Carts
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public ICollection<CartItems> ? Products { get; set; }
        // Parent reference
        public int UserId { get; set; }
        public virtual User ? User { get; set; }
    }
}
