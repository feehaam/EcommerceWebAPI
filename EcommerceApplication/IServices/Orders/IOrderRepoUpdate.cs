using EcommerceApplication.Models.Orders;

namespace EcommerceApplication.IRepository.Orders
{
    public interface IOrderRepoUpdate
    {
        public PaymentStatus ReadPaymentStatus(int OrderId);
        public bool AddPayment(int OrderId, Payment Payment);
        public bool UpdateDeliveryStatus(int OrderId, string status);
    }
}
