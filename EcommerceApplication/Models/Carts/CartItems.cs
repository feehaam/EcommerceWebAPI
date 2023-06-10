using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Carts
{
    public class CartItems
    {
        [Key]
        public int CartItemsId { get; set; }
        public Product ? Product { get; set; }
        public int Quantity { get; set; }
        // Parent ref
        public int CartId { get; set; }
    }
}
