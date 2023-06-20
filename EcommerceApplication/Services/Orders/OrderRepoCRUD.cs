using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.Models.Orders;
using EcommerceApplication.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Orders
{
    public class OrderRepoCRUD : IOrderRepoCRUD
    {
        private readonly DataContext _context;
        public OrderRepoCRUD(DataContext context)
        {
            _context = context;
        }

        public bool Create(Order Order)
        {
            try
            {
                int userId = Order.UserId;
                User user = _context.Users
                    .Include(u => u.Orders)
                    .FirstOrDefault(x => x.UserId == userId);
                if (user == null)
                {
                    return false;
                }
                if (user.Orders == null)
                {
                    user.Orders = new List<Order>();
                }
                user.Orders.Add(Order);
                return _context.SaveChanges() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int OrderId)
        {
            Order Order = _context.Orders
                .Include(o => o.Products)
                .Include(o => o.PaymentStatus)
                .Include(o => o.DeliveryAddress)
                .FirstOrDefault(o => o.OrderId == OrderId);
            if (Order == null)
            {
                return false;
            }
            _context.Remove(Order);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public Order Read(int OrderId)
        {
            Order Order = _context.Orders
                .Include(o => o.Products)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.PaymentStatus)
                    .ThenInclude(p => p.Payments)
                .FirstOrDefault(o => o.OrderId == OrderId);
            if (Order == null)
            {
                return Order;
            }
            return Order;
        }
    }
}
