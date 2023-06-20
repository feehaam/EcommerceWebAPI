using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Orders
{
    public class OrderRepoUpdate : IOrderRepoUpdate
    {
        private readonly DataContext _context;
        public OrderRepoUpdate(DataContext context)
        {
            _context = context;
        }

        public bool AddPayment(int OrderId, Payment Payment)
        {
            try
            {
                Order Order = Read(OrderId);
                if (Order == null)
                {
                    return false;
                }
                if (Order.PaymentStatus == null)
                {
                    Order.PaymentStatus = new PaymentStatus();
                }
                if (Order.PaymentStatus.Payments == null)
                {
                    Order.PaymentStatus.Payments = new List<Payment>();
                }
                Order.PaymentStatus.Payments.Add(Payment);
                Order.PaymentStatus.CompletedPayment = 0;
                foreach (Payment p in Order.PaymentStatus.Payments)
                {
                    Order.PaymentStatus.CompletedPayment += (byte)p.Amount;
                }
                
                return _context.SaveChanges() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public PaymentStatus ReadPaymentStatus(int OrderId)
        {
            Order Order = Read(OrderId);
            if (Order == null) return null;
            return Order.PaymentStatus;
        }

        public bool UpdateDeliveryStatus(int OrderId, string status)
        {
            Order Order = Read(OrderId);
            if(Order == null) return false;
            Order.DeliveryStatus = status;
            return _context.SaveChanges() > 0 ? true : false;
        }

        private Order Read(int OrderId)
        {
            return _context.Orders
                .Include(o => o.PaymentStatus)
                    .ThenInclude(ps => ps.Payments)
                .FirstOrDefault(o => o.OrderId == OrderId);
        }
    }
}
