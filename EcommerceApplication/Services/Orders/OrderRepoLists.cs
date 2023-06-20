using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.Models.Orders;

namespace EcommerceApplication.Repository.Orders
{
    public class OrderRepoLists : IOrderRepoLists
    {
        public ICollection<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrdersByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrdersByUser(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
