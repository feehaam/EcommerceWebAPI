using EcommerceApplication.Models.Orders;
using EcommerceApplication.Models.Users;
using System.Text.Json.Serialization;

namespace EcommerceApplication.DTO.Orders
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public ICollection<CreateOrderOrderItemsDto>? Products { get; set; }
        public double VoucherReduction { get; set; }
        public double DeliveryCharge { get; set; }
        public Address? DeliveryAddress { get; set; }
        public string? CustomerPhoneNo { get; set; }
    }
}
