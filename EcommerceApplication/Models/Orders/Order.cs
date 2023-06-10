using EcommerceApplication.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Orders
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime PlacementTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public ICollection <OrderItems> ? Products { get; set; }
        public double ProductsCost { get; set; }
        public double VoucherReduction { get; set; }
        public double DeliveryCharge { get; set; }
        public double Total { get; set; }
        public Address ? DeliveryAddress { get; set; }
        public string ? CustomerPhoneNo { get; set; }
        public PaymentStatus ? PaymentStatus { get; set; }
        public string ? DeliveryStatus { get; set; }

        // Parent reference 
        public virtual User ? User { get; set; }
        public int UserId { get; set; }
    }
}
