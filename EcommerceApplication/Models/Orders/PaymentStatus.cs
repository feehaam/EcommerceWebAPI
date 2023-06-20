using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcommerceApplication.Models.Orders
{
    public class PaymentStatus
    {
        [Key]
        public int PaymentStatusId { get; set; }
        public byte CompletedPayment { get; set; }
        public ICollection<Payment> ? Payments { get; set; }

        // Parent reference
        public int OrderId { get; set; }
        [JsonIgnore]
        public virtual Order ? Order { get; set; }
    }
}
