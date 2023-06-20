using EcommerceApplication.Models.Orders;
using EcommerceApplication.Models.Users;
using System.Text.Json.Serialization;

namespace EcommerceApplication.DTO.Orders
{
    public class ReadOrderDto
    {
        public int OrderId { get; set; }
        public DateTime PlacementTime { get; set; }
        public string DeliveryTime { get; set; } = string.Empty;
        public ICollection<ReadOrderItemDto>? Products { get; set; }
        public double ProductsCost { get; set; }
        public double VoucherReduction { get; set; }
        public double DeliveryCharge { get; set; }
        public double Total { get; set; }
        public Address? DeliveryAddress { get; set; }
        public string? CustomerPhoneNo { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public string? DeliveryStatus { get; set; }

        // Parent reference 
        public int UserId { get; set; }
    }
}
