using EcommerceApplication.Models.Orders;

namespace EcommerceApplication.IRepository.Orders
{
    public interface IOrderRepoLists
    {
        public ICollection<Order> GetAllOrders();
        public ICollection<Order> GetOrdersByUser(int UserId);
        public ICollection<Order> GetOrdersByStatus(string status);
    }
}
