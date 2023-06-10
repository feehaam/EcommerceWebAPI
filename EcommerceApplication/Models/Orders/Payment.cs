using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Orders
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string Type { get; set; } = string.Empty;
        public double Amount { get; set; }

        // Parent reference
        public int PaymentStatusId { get; set; }
        public virtual PaymentStatus ? PaymentStatus { get; set; }
    }
}
