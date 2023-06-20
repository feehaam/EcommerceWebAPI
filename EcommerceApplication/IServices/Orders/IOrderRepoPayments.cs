using EcommerceApplication.Models.Orders;

namespace EcommerceApplication.IRepository.Orders
{
    public interface IOrderRepoPayments
    {
        public PaymentStatus ReadPaymentStatus(int OrderId);
        public bool AddPayment(Order Order, Payment Payment);
        public bool UpdatePayment(Order Order, Payment Payment);
    }
}
