using System.ComponentModel.DataAnnotations;

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
        public virtual Order ? Order { get; set; }
    }
}
