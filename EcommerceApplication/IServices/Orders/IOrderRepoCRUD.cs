using EcommerceApplication.Models.Orders;

namespace EcommerceApplication.IRepository.Orders
{
    public interface IOrderRepoCRUD
    {
        public bool Create(Order Order);
        public Order Read(int OrdersId);
        public Order Update(Order Order);
        public void Delete(int OrdersId);
    }
}
