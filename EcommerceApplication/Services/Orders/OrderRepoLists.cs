using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Orders
{
    public class OrderRepoLists : IOrderRepoLists
    {
        private readonly DataContext _context;

        public OrderRepoLists(DataContext context)
        {
            _context = context;
        }

        public ICollection<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Products)
                    .ThenInclude(p => p.Product)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.PaymentStatus)
                    .ThenInclude(ps => ps.Payments)
                .ToList();
        }

        public ICollection<Order> GetOrdersByStatus(string status)
        {
            return _context.Orders
                .Where(o => o.DeliveryStatus.Contains(status))
                .Include(o => o.Products)
                    .ThenInclude(p => p.Product)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.PaymentStatus)
                    .ThenInclude(ps => ps.Payments)
                .ToList();
        }

        public ICollection<Order> GetOrdersByUser(int UserId)
        {
            return _context.Orders
                .Where(o => o.UserId == UserId)
                .Include(o => o.Products)
                    .ThenInclude(p => p.Product)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.PaymentStatus)
                    .ThenInclude(ps => ps.Payments)
                .ToList();
        }
    }
}
