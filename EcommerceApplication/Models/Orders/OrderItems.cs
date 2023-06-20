using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Order ? Order { get; set; }
    }
}
