using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Carts
{
    public interface ICartRepoCRUD
    {
        public bool AddProduct(int UserId, int ProductId, int Quantity);
        public Cart ReadCart(int UserId);
        public bool UpdateProduct(int UserId, int ProductId, int Quantity);
        public bool DeleteProduct(int UserId, int ProductId);
    }
}
