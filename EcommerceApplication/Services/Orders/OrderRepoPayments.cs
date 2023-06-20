using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.Models.Orders;

namespace EcommerceApplication.Repository.Orders
{
    public class OrderRepoPayments : IOrderRepoPayments
    {
        public bool AddPayment(Order Order, Payment Payment)
        {
            throw new NotImplementedException();
        }

        public PaymentStatus ReadPaymentStatus(int OrderId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePayment(Order Order, Payment Payment)
        {
            throw new NotImplementedException();
        }
    }
}
