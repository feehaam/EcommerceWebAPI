using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Carts
{
    public interface ICartRepoCRUD
    {
        public bool AddProduct(int UserId, Product Product);
        public Cart ReadCart(int UserId);
        public bool UpdateProduct(int UserId, Product Product, int quantity);
        public bool DeleteProduct(int UserId, Product Product);
    }
}
