using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Orders
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }

        // Parent reference 
        public int OrderId { get; set; }
        public virtual Order ? Order { get; set; }
    }
}
