using EcommerceApplication.Models.Orders;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.DTO.Orders
{
    public class CreateOrderOrderItemsDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
