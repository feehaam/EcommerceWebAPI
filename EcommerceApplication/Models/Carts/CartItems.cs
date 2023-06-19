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


        public CartItems()
        {

        }

        public CartItems(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }
        public void DecreaseQuantity(int quantity)
        {
            Quantity -= quantity;
            if (Quantity < 0)
            {
                Quantity = 0;
            }
        }
    }
}
